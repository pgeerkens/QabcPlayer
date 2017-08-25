#region License
////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
#endregion
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

using Irony.GrammarExplorer.Highlighter;

using PGSoftwareSolutions.Util;
using PGSoftwareSolutions.Util.PlayWaveLib;
using PGSoftwareSolutions.Qabc;
using PGSoftwareSolutions.ScoreDisplay;
using PGSoftwareSolutions.Music;
using System.Collections.Generic;
using System.Linq;

namespace PGSoftwareSolutions.QabcPlayer {
    /// <summary>TODO</summary>
    [CLSCompliant(false)]
	public partial class PlayMidiForm : Form, IMessageFilter, IQabcPlayerView {
        /// <inheritdoc />
        public PlayMidiForm() {
			InitializeComponent();
            InitRadioButtonGenus(MidiPlayer.Instruments);
            
            _resourceSet                 = Resources.ResourceManager.GetResourceSet
											 (CultureInfo.InvariantCulture, true, false);
            txtSynthesizer.Text          = Synthesizer.Code_Synthesizer;
			tabControl1.SelectedIndex	 = 1;

            Application.AddMessageFilter(this);

			PBScore.HighQuality			 = true;
            PBScore.ScoreHighlighter	 = pbHighlight;
            
            txtMusicString.ScoreProvider =
            pbHighlight.ScoreProvider    = PBScore;
        }

        /// <inheritdoc/>
        public event EventHandler<TuneSelectionEventArgs> TuneSelected;
        /// <inheritdoc/>
        public event EventHandler PlayStopRequested;
        /// <inheritdoc/>
        public event EventHandler PauseResumeRequested;
        /// <inheritdoc/>
        public event EventHandler ExitRequested;
        /// <inheritdoc/>
        public event EventHandler WaveLoadUnloadRequested;
        /// <inheritdoc/>
        public event EventHandler FormHelpRequested;
       
        #region MIDI Player Control
        private QabcIronyParser _qabcParser => QabcIronyParser.Instance;
		private IPlayer<INote>  _midiPlayer;

		private void SetEnablings(bool PlayEnabled) {
			txtMusicString.Enabled	= PlayEnabled;
			grpTunes.Enabled		= PlayEnabled;
			buttonPause.Enabled		= !PlayEnabled;
			buttonPlay.Text			= PlayEnabled ? "&Play" : "&Stop";

			txtSynthesizer.Enabled	= PlayEnabled;
			grpTunes.Enabled		= PlayEnabled;
			buttonShowWave.Enabled	= !PlayEnabled;

			tabControl1.TabPages[1-tabControl1.SelectedIndex].Enabled = PlayEnabled;
			PBScore.HighQuality		= PlayEnabled;
		}

		private void ButtonPlay_Click(object sender, EventArgs e) {
			if (!buttonPlay.Checked) {
				_midiPlayer?.Cancel();
				buttonPause.Checked = false;
				SetEnablings(true);	// Aborted, so enable interface
			} else if (PBScore.Tune == null  ||  PBScore.Tune.Count == 0) 
					MessageBox.Show("No music ready to play.");
			else {
				try {
					SetEnablings(false);
					_midiPlayer                = MidiPlayer.New(((IInstrument)panelMidiSpecies.Tag));
                    _midiPlayer.NextNote      += OnNextNote;
                    _midiPlayer.PlayCompleted += PlayCompleted;
					_midiPlayer.PlayAsync(PBScore.Tune);

                    buttonPause.Enabled = _midiPlayer.AsPausablePlayer != null;
				} catch (Exception ex) {
                    var message = ex.Message + Environment.NewLine + Environment.NewLine + ex.StackTrace;
                    MessageBox.Show(message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Stop);
					SetEnablings(true);	// Aborted, so enable interface
				}
			}
		}

		private void PlayCompleted(object sender, PlayCompletedEventArgs e) {
			if (InvokeRequired)
				Invoke( (Action) (()=> PlayCompleted()));
			else
				PlayCompleted();
		}
        private void PlayCompleted() {
			SetEnablings(true);
			BouncingBall(0,1);
            _midiPlayer.NextNote      -= OnNextNote;
            _midiPlayer.PlayCompleted -= PlayCompleted;
            _midiPlayer = null;
        }

		private void ButtonPause_CheckedChanged(object sender, EventArgs e) {
            var player = _midiPlayer.AsPausablePlayer;

            if (player != null) {
                player.PauseResume();
                PBScore.HighQuality = 
                buttonPause.Checked = ! player.IsRunning;
                buttonPause.Text    = player.IsRunning ? "Pause" : "Resume" ;
                buttonPause.Invalidate();
            }
        }
		#endregion MIDI Player control

		#region MIDI Instruments
		RadioButton[]	_radioButtonGenus = new RadioButton[16];
		void InitRadioButtonGenus(IReadOnlyList<IInstrumentGenus> instruments) {
            var master                = radioButtonGenus0;
            _radioButtonGenus[0]      = master;

            for (int i = 1; i < 16; i++) {
                _radioButtonGenus[i] = new RadioButton();
                panelMidiGenus.Controls.Add(_radioButtonGenus[i]);

                _radioButtonGenus[i].AutoSize = master.AutoSize;
                _radioButtonGenus[i].Checked  = false;
                _radioButtonGenus[i].Location = master.Location + new Size(185 * (i / 8), 25 * (i % 8));
                _radioButtonGenus[i].Name     = "radioButtonGenus" + i;
                _radioButtonGenus[i].Size     = master.Size;
                _radioButtonGenus[i].TabIndex = master.TabIndex + i;
                _radioButtonGenus[i].TabStop  = master.TabStop;
                _radioButtonGenus[i].UseVisualStyleBackColor = master.UseVisualStyleBackColor;
                _radioButtonGenus[i].Click   += RadioButtonGenus_Click;
                _radioButtonGenus[i].Visible  = true;
            }
            SetRadioButtonGenus(instruments);

            InitRadioButtonSpecies(instruments[0].Species);
        }
        void SetRadioButtonGenus(IReadOnlyList<IInstrumentGenus> instruments) {
            for (int i = 0; i < 16; i++) {
                _radioButtonGenus[i].Tag  = instruments[i];
                _radioButtonGenus[i].Text = instruments[i].Name;
            }
        }

        RadioButton[]	_radioButtonSpecies = new RadioButton[8];
		void InitRadioButtonSpecies(IReadOnlyList<IInstrument> species) {
			_radioButtonSpecies[0]      = radioButtonSpecies0;
            for (int i=1; i<8; i++) {
				_radioButtonSpecies[i]			= new RadioButton();
				panelMidiSpecies.Controls.Add(_radioButtonSpecies[i]);

				_radioButtonSpecies[i].AutoSize	= radioButtonSpecies0.AutoSize;
				_radioButtonSpecies[i].Location	= radioButtonSpecies0.Location + new Size(0,25*i);
				_radioButtonSpecies[i].Name		= "radioButtonSpecies" + i;
				_radioButtonSpecies[i].Size		= radioButtonSpecies0.Size;
				_radioButtonSpecies[i].TabIndex	= radioButtonSpecies0.TabIndex + i;
				_radioButtonSpecies[i].UseVisualStyleBackColor = radioButtonSpecies0.UseVisualStyleBackColor;
				_radioButtonSpecies[i].Click   += RadioButtonSpecies_Click;
			}
            SetRadioButtonSpecies(species);
        }
        void SetRadioButtonSpecies(IReadOnlyList<IInstrument> species) {
            for (int i = 0; i < 8; i++) {
                _radioButtonSpecies[i].Tag  = species[i];
                _radioButtonSpecies[i].Text = species[i].Name;
            }
        }

		private void PlayMidiForm_Load(object sender, EventArgs e) {
            RadioButtonGenus_Click(_radioButtonGenus[0],EventArgs.Empty);
			InvokeBouncingBall(0,1);
		}

		private void RadioButtonGenus_Click(object sender, EventArgs e) {
			var genus = (IInstrumentGenus)((RadioButton)sender).Tag;
            SetRadioButtonSpecies(genus.Species);
            RadioButtonSpecies_Click(( from b in _radioButtonSpecies
                                       where b.Checked
                                       select b).First(), e);
		}
		private void RadioButtonSpecies_Click(object sender, EventArgs e) {
            var species = ((IInstrument)((RadioButton)sender).Tag);
            panelMidiSpecies.Tag = species;
            _midiPlayer?.SetInstrument(species);
		}
		#endregion MIDI Instruments

		#region Bouncing-ball
        private void OnNextNote(object sender, NextNoteEventArgs e) {
            InvokeBouncingBall(e.Position, e.Length);
        }

		private void InvokeBouncingBall(int position, int length) {
			if (InvokeRequired) {
				Invoke( (Action<int,int>) ((p,l)=>BouncingBall(p,l)), position, length);
			} else {
				BouncingBall(position,length);
			}
		}
		private void BouncingBall(int position, int length) {
            var noteRectangle = PBScore.ShowScorePosition(position);
            PBScore.Invalidate();
			txtMusicString.ShowSourcePosition(position,length);
			pbHighlight.InvalidateEx(noteRectangle);

            Console.WriteLine($"position: {position}; length: {length}; noteRectangle:{noteRectangle}");
		}
		#endregion Bouncing Ball

		#region Source Highlighting
		FastColoredTextBoxHighlighter _highlighter;
		private void StartHighlighter(QabcIronyParser parser) {
			if (_highlighter != null)			StopHighlighter();
			if (parser != null  &&  parser.Language.CanParse()) {
				_highlighter = new FastColoredTextBoxHighlighter(txtMusicString, parser.Language);
				_highlighter.Adapter.Activate();
			}
		}
		private void StopHighlighter() {
			if (_highlighter != null) {
				_highlighter.Dispose();
				_highlighter = null;
				ClearHighlighting();
			}
		}
		private void ClearHighlighting() {
			var selectedRange = txtMusicString.Selection;
			var visibleRange = txtMusicString.VisibleRange;
			var firstVisibleLine = Math.Min(visibleRange.Start.iLine, visibleRange.End.iLine);

			var txt = txtMusicString.Text;
			txtMusicString.Clear();
			txtMusicString.Text = txt; //remove all old highlighting

			txtMusicString.SetVisibleState(firstVisibleLine, FastColoredTextBoxNS.VisibleState.Visible);
			txtMusicString.Selection = selectedRange;
		}
		private void EnableHighlighter(QabcIronyParser parser, bool enable) {
			if (_highlighter != null)		StopHighlighter();
			if (enable)						StartHighlighter(parser);
		}
		#endregion Source Highlighting

		#region Music String
		private void TxtMusicString_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) {
			if (txtMusicString.Text == null) {
				MessageBox.Show("No music to parse."); return;
			}
			gridCompileErrors.Rows.Clear();
			try {
				PBScore.Tune = (_qabcParser.Parse(txtMusicString.Text));
				foreach (var err in _qabcParser.Errors)
					gridCompileErrors.Rows.Add(err.Location, err, err.ParserState);
			} catch (ArgumentOutOfRangeException ex) {
//				gridCompileErrors.Rows.Add(new SourceLocation(0,0,0),ex.Message,"N/A");
				gridCompileErrors.Rows.Add("(0:0)",ex.Message,"N/A");
			} catch (InvalidCastException ex) {
//				gridCompileErrors.Rows.Add(new SourceLocation(0,0,0),ex.Message,"N/A");
                gridCompileErrors.Rows.Add("(0:0)",ex.Message,"N/A");
            }
        }

		private void GridCompileErrors_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			if (e.RowIndex < 0 || e.RowIndex >= gridCompileErrors.Rows.Count) return;
            var err = gridCompileErrors.Rows[e.RowIndex].Cells[1].Value
																as PGSoftwareSolutions.PGIrony.LogMessage;
            if (err == null) {
                dynamic err2 = gridCompileErrors.Rows[e.RowIndex].Cells[1].Value;
                txtMusicString.ShowSourcePosition(err2.Location.Position, 2);
            } else {
                txtMusicString.ShowSourcePosition(err.Location.Position, err.Span.Length);
            }
        }
        #endregion

        #region Form events & Misc.
        private IScoreProvider PBScore { get { return musicSplitContainer1; } }
		private void GridCompileErrors_Resize(object sender, EventArgs e) {
			dataGridViewTextBoxColumn4.Width = gridCompileErrors.Width - 5
					- (dataGridViewTextBoxColumn1.Width + dataGridViewTextBoxColumn3.Width);
		}

		private System.Resources.ResourceSet _resourceSet;
		private void RadioButton_Click(object sender, EventArgs e) {
			try {
				txtMusicString.Text = _resourceSet.GetString((string)((RadioButton)sender).Tag);
                PBScore.Tune = QabcIronyParser.Instance.Parse(txtMusicString.Text);
       //         this.gridCompileErrors = QabcIronyParser.First.Errors;
                InvokeBouncingBall(0,1);
				StartHighlighter(_qabcParser);
			} finally {;}
		}

		private void ButtonHelp_Click(object sender, EventArgs e) {
			using (FormHelp formHelp = new FormHelp()) { formHelp.ShowDialog(); }
		}

		private void PlayMidiForm_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.F5) {
				if (tabControl1.SelectedIndex == 0) 	ButtonLoad_Click(sender,e);
				else												ButtonPlay_Click(sender,e);
			}
		}
		#endregion Form events & Misc.

		#region Wave Player Control
		private void ButtonLoad_Click(object sender, EventArgs e) {
			Cursor					= Cursors.WaitCursor;
			if (buttonLoad.Checked)	LoadWaveFile();
			else							UnloadWaveFile();
			buttonLoad.Text			= buttonLoad.Checked ? "Unload" : "Load";
		//	mediaPlayer.Visible		= buttonLoad.Checked;
			Cursor					= Cursors.Default;
		}
		private WaveStream _waveStream;
		private void LoadWaveFile() {
			const string _urlPrefix = @"file://";
			try {
				SetEnablings(false);

				string sTmpFilename	    = Path.GetTempFileName();
				File.Delete(sTmpFilename);
				sTmpFilename			= Path.ChangeExtension(sTmpFilename, "wav");

				_waveStream				= GetWaveStream(txtSynthesizer.Text, txtMusicString.Text);
				using(var fileStream	= new FileStream(sTmpFilename,FileMode.OpenOrCreate,FileAccess.Write)) {
					_waveStream.CopyTo(fileStream);
				}

                _mediaPlayer.settings.autoStart = true;
                //	mediaPlayer.Visible	            = true;
                _mediaPlayer.URL                    = _urlPrefix + sTmpFilename;
                _mediaPlayer.Tag		            = sTmpFilename;	// to aid in clean-up later
                _mediaPlayer.Ctlcontrols.play();
			}
			catch (SynthesizerParseErrorsException ex) {
				MessageBox.Show(ex.Message);
				SetEnablings(true);		// Aborted, so enable interface
			}
			finally {
				Refresh();
			}
		}

        private Task<WaveStream> WaveStreamAsync(string synthesizerText, string musicText) => 
            Task.Run<WaveStream>(() => GetWaveStream(synthesizerText, musicText));

        private void UnloadWaveFile() {
			_waveStream.Dispose();
			_waveStream			= null;
		//	mediaPlayer.Visible	= false;
            _mediaPlayer.URL	    = string.Empty;
			try {
				if (_mediaPlayer.Tag is string) File.Delete((string)_mediaPlayer.Tag);
			} catch (Exception) { ; /* ignore file-system errors */ }
            _mediaPlayer.close();
            SetEnablings(true);
		}
		private void SetProgressBarValue(int value) {
			Invoke((Action<int>)(var => progressBar1.Value = var), value);
		}
		private WaveStream GetWaveStream(string stringSynth, string stringMusic) {
			try {
				Tune<INote> tune		= PBScore.Tune;

				progressBar1.Maximum	= tune.Count;
				progressBar1.Value	    = 0;
				progressBar1.Visible	= true;

				var synth		        = Synthesizer.ParseSynthesizer(stringSynth);
				var waveStream	        = new WaveStream(tune, synth, SetProgressBarValue);
				return waveStream;
			} finally {
				progressBar1.Visible	= false;
			}
		}
		private void ButtonShowWave_Click(object sender, EventArgs e) {
			var scol	= _waveStream.DisplayString();
			var sb	= new StringBuilder();
			for (int i = 0; i < 20; i++) { sb.Append(scol[i] + Environment.NewLine); }
			MessageBox.Show(sb.ToString());
		}
        private void MediaPlayer_MediaError(object sender, AxWMPLib._WMPOCXEvents_MediaErrorEvent e) {
            var errSource = e.pMediaObject as IWMPMedia2;
            if (errSource != null) {
                var errorItem = errSource.Error;
                MessageBox.Show("Error #" + errorItem.errorCode.ToString("X")
                                          + " in " + errSource.sourceURL);
            }
        }
        #endregion Wave Player Controlo

        #region IMessageFilter implementation
        /// <summary> Redirect WM_MouseWheel messages to window under mouse (rather than that with 
        /// focus) with adjusted delta.</summary>
        /// <remarks><see href="http://www.flounder.com/virtual_screen_coordinates.htm"/></remarks>
        /// <param name="m"></param>
        /// <returns>Success (true) or failure (false) to OS.</returns>
        [System.Security.Permissions.PermissionSetAttribute(
			System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
		bool IMessageFilter.PreFilterMessage(ref Message m) {
			if (m.Msg == (int)WM.MOUSEHWHEEL) {
				var pos = MouseInput.GetPointLParam(m.LParam);

				// Determine window and control at these coordinates.
				var hWnd = WindowFromPoint(pos);
				var ctl	= Control.FromHandle(hWnd);
				if (hWnd != IntPtr.Zero  &&  hWnd != m.HWnd  &&  ctl != null) {
					if (ctl == pbHighlight) {
						// forward delta of +/- 40 instead of +/- 120
						var keyState	= MouseInput.GetKeyStateWParam(m.WParam);
						var mult			= keyState.HasFlag(MouseKeys.Control) ? 5 : 1;
						keyState			= keyState &= ~MouseKeys.Control;
						var wheelDelta	= MouseInput.WheelDelta(m.WParam);
						var newWparam	= MouseInput.WParam((Int16)(mult*wheelDelta*30/120), keyState);
						SendMessage(hWnd, m.Msg, newWparam, m.LParam);
						return true;
					} else if (ctl == txtMusicString) {
						// forward delta of +/- 54 instead of +/- 120
						// 54 = 3 * 18 (default point height in pixels?)
						var keyState	= MouseInput.GetKeyStateWParam(m.WParam);
						var wheelDelta	=  MouseInput.WheelDelta(m.WParam);
						var newWparam	= MouseInput.WParam((Int16)(wheelDelta*54/120), keyState);
						SendMessage(hWnd, m.Msg, newWparam, m.LParam);
						return true;
					}
				}
			}
			return false;
		}
		/// <summary>P/Invoke declaration for user32.dll.WindowFromPoint</summary>
		/// <remarks><see href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms633558(v=vs.85).aspx"/></remarks>
		/// <param name="pt">(Sign-extended) screen coordinates as a Point structure.</param>
		/// <returns>Window handle (hWnd).</returns>
		[DllImport("user32.dll")]
		private static extern IntPtr WindowFromPoint(Point pt);
        /// <summary>P/Invoke declaration for user32.dll.SendMessage</summary>
        /// <param name="hWnd">Window handle</param>
        /// <param name="msg">Windows message</param>
        /// <param name="wParam">WParam</param>
        /// <param name="lParam">LParam</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
		#endregion

		#region Shutdown
		private void ButtonExit_Click(object sender, EventArgs e) { Close();	}
		private void PlayMidiForm_FormClosing(object sender, FormClosingEventArgs e) {
			Application.Exit();
		}
		private void PlayMidiForm_FormClosed(object sender, FormClosedEventArgs e) {
            _midiPlayer?.Cancel();
            _midiPlayer = null;
        }
        #endregion Shutdown

        private void TabControl1_TabIndexChanged(object sender, EventArgs e) {
            progressBar1.Visible =
            buttonLoad.Visible =
            buttonShowWave.Visible = (tabControl1.SelectedIndex == 0);
        }
    }
}
