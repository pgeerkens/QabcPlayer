#region License
////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
#endregion

namespace PGSoftwareSolutions.QabcPlayer {
	partial class PlayMidiForm {
		/// <summary> Required designer variable. </summary>
		private System.ComponentModel.IContainer components = null;

        private bool _disposed = false;
        /// <summary> Clean up any resources being used. </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
			if (!_disposed) {
				if (disposing) {	// clean-up managed objects
					components?.Dispose();
					_highlighter?.Dispose();
					txtMusicString?.Dispose();
					_resourceSet?.Dispose();
					_waveStream?.Dispose();
				}
				// large fields set to null
				_midiPlayer = null;

				// Almost done now.
				base.Dispose(disposing);
				_disposed	= true;
			}
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayMidiForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonShowWave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.CheckBox();
            this.buttonPause = new System.Windows.Forms.CheckBox();
            this.buttonPlay = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtSynthesizer = new FastColoredTextBoxNS.FastColoredTextBox();
            this.labelSynthesizerFunctions = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.labelMidiInstrument = new System.Windows.Forms.Label();
            this.panelMidiGenus = new System.Windows.Forms.Panel();
            this.labelGenus = new System.Windows.Forms.Label();
            this.radioButtonGenus0 = new System.Windows.Forms.RadioButton();
            this.panelMidiSpecies = new System.Windows.Forms.Panel();
            this.labelSpecies = new System.Windows.Forms.Label();
            this.radioButtonSpecies0 = new System.Windows.Forms.RadioButton();
            this.grpTunes = new System.Windows.Forms.GroupBox();
            this._mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.radioButton36 = new System.Windows.Forms.RadioButton();
            this.radioButton35 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.musicSplitContainer1 = new PGSoftwareSolutions.ScoreDisplay.MusicSplitContainer();
            this.txtMusicString = new PGSoftwareSolutions.ScoreDisplay.MusicSourceTextBox();
            this.pbHighlight = new PGSoftwareSolutions.ScoreDisplay.HighlightScorePanel();
            this.labelAbcScore = new System.Windows.Forms.Label();
            this.gridCompileErrors = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSynthesizer)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panelMidiGenus.SuspendLayout();
            this.panelMidiSpecies.SuspendLayout();
            this.grpTunes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mediaPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.musicSplitContainer1)).BeginInit();
            this.musicSplitContainer1.Panel1.SuspendLayout();
            this.musicSplitContainer1.Panel2.SuspendLayout();
            this.musicSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusicString)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompileErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.AutoScrollMinSize = new System.Drawing.Size(500, 0);
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel1.Controls.Add(this.buttonShowWave);
            this.splitContainer1.Panel1.Controls.Add(this.buttonLoad);
            this.splitContainer1.Panel1.Controls.Add(this.buttonPause);
            this.splitContainer1.Panel1.Controls.Add(this.buttonPlay);
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.grpTunes);
            this.splitContainer1.Panel1MinSize = 525;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 200;
            this.splitContainer1.Size = new System.Drawing.Size(1238, 492);
            this.splitContainer1.SplitterDistance = 622;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(163, 173);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(200, 8);
            this.progressBar1.TabIndex = 20;
            this.toolTip1.SetToolTip(this.progressBar1, "Progress for WAVE synthesis and loading.");
            // 
            // buttonShowWave
            // 
            this.buttonShowWave.Enabled = false;
            this.buttonShowWave.Location = new System.Drawing.Point(85, 167);
            this.buttonShowWave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonShowWave.Name = "buttonShowWave";
            this.buttonShowWave.Size = new System.Drawing.Size(56, 23);
            this.buttonShowWave.TabIndex = 19;
            this.buttonShowWave.Text = "Show";
            this.toolTip1.SetToolTip(this.buttonShowWave, "Inspect WAVE header");
            this.buttonShowWave.UseVisualStyleBackColor = true;
            this.buttonShowWave.Click += new System.EventHandler(this.ButtonShowWave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonLoad.Location = new System.Drawing.Point(16, 167);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(56, 23);
            this.buttonLoad.TabIndex = 18;
            this.buttonLoad.Text = "&Load";
            this.buttonLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.buttonLoad, "Load/Unload Wave music");
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonPause.AutoCheck = false;
            this.buttonPause.Enabled = false;
            this.buttonPause.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonPause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonPause.Location = new System.Drawing.Point(453, 168);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(56, 22);
            this.buttonPause.TabIndex = 17;
            this.buttonPause.Text = "Pause";
            this.buttonPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.buttonPause, "Pause/Resume MIDI music");
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.ButtonPause_CheckedChanged);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonPlay.Location = new System.Drawing.Point(383, 167);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(56, 23);
            this.buttonPlay.TabIndex = 16;
            this.buttonPlay.Text = "&Play";
            this.buttonPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.buttonPlay, "Play/Stop MIDI music (F5)");
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 194);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(618, 295);
            this.tabControl1.TabIndex = 13;
            this.toolTip1.SetToolTip(this.tabControl1, "Select a music player.");
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_TabIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.txtSynthesizer);
            this.tabPage1.Controls.Add(this.labelSynthesizerFunctions);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(610, 269);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "WAVE Player";
            // 
            // txtSynthesizer
            // 
            this.txtSynthesizer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSynthesizer.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtSynthesizer.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.txtSynthesizer.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.txtSynthesizer.BackBrush = null;
            this.txtSynthesizer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSynthesizer.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.txtSynthesizer.CharHeight = 14;
            this.txtSynthesizer.CharWidth = 8;
            this.txtSynthesizer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSynthesizer.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtSynthesizer.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtSynthesizer.IsReplaceMode = false;
            this.txtSynthesizer.Language = FastColoredTextBoxNS.Language.CSharp;
            this.txtSynthesizer.LeftBracket = '(';
            this.txtSynthesizer.LeftBracket2 = '{';
            this.txtSynthesizer.Location = new System.Drawing.Point(4, 19);
            this.txtSynthesizer.Name = "txtSynthesizer";
            this.txtSynthesizer.Paddings = new System.Windows.Forms.Padding(0);
            this.txtSynthesizer.RightBracket = ')';
            this.txtSynthesizer.RightBracket2 = '}';
            this.txtSynthesizer.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtSynthesizer.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtSynthesizer.ServiceColors")));
            this.txtSynthesizer.Size = new System.Drawing.Size(607, 245);
            this.txtSynthesizer.TabIndex = 2;
            this.txtSynthesizer.TabLength = 2;
            this.toolTip1.SetToolTip(this.txtSynthesizer, "Adjust the manner in which the WAVE data is synhesized.");
            this.txtSynthesizer.Zoom = 100;
            // 
            // labelSynthesizerFunctions
            // 
            this.labelSynthesizerFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSynthesizerFunctions.AutoSize = true;
            this.labelSynthesizerFunctions.Location = new System.Drawing.Point(2, 2);
            this.labelSynthesizerFunctions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSynthesizerFunctions.Name = "labelSynthesizerFunctions";
            this.labelSynthesizerFunctions.Size = new System.Drawing.Size(157, 13);
            this.labelSynthesizerFunctions.TabIndex = 1;
            this.labelSynthesizerFunctions.Text = "Synthesizer Function Definitions";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.splitContainer3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(610, 269);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MIDI Player";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Location = new System.Drawing.Point(-1, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel1.Controls.Add(this.labelMidiInstrument);
            this.splitContainer3.Panel1.Controls.Add(this.panelMidiGenus);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.panelMidiSpecies);
            this.splitContainer3.Size = new System.Drawing.Size(517, 262);
            this.splitContainer3.SplitterDistance = 337;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 15;
            // 
            // labelMidiInstrument
            // 
            this.labelMidiInstrument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMidiInstrument.AutoSize = true;
            this.labelMidiInstrument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMidiInstrument.Location = new System.Drawing.Point(4, 4);
            this.labelMidiInstrument.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMidiInstrument.Name = "labelMidiInstrument";
            this.labelMidiInstrument.Size = new System.Drawing.Size(137, 13);
            this.labelMidiInstrument.TabIndex = 11;
            this.labelMidiInstrument.Text = "Select MIDI Instrument";
            // 
            // panelMidiGenus
            // 
            this.panelMidiGenus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMidiGenus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMidiGenus.Controls.Add(this.labelGenus);
            this.panelMidiGenus.Controls.Add(this.radioButtonGenus0);
            this.panelMidiGenus.Location = new System.Drawing.Point(2, 20);
            this.panelMidiGenus.Margin = new System.Windows.Forms.Padding(2);
            this.panelMidiGenus.Name = "panelMidiGenus";
            this.panelMidiGenus.Size = new System.Drawing.Size(333, 236);
            this.panelMidiGenus.TabIndex = 12;
            this.panelMidiGenus.Tag = "0";
            this.toolTip1.SetToolTip(this.panelMidiGenus, "Select the instrument family to display.");
            // 
            // labelGenus
            // 
            this.labelGenus.AutoSize = true;
            this.labelGenus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGenus.Location = new System.Drawing.Point(14, 12);
            this.labelGenus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGenus.Name = "labelGenus";
            this.labelGenus.Size = new System.Drawing.Size(78, 13);
            this.labelGenus.TabIndex = 29;
            this.labelGenus.Text = "MIDI &Genus:";
            this.toolTip1.SetToolTip(this.labelGenus, "Select the instrument family to display.");
            // 
            // radioButtonGenus0
            // 
            this.radioButtonGenus0.AutoSize = true;
            this.radioButtonGenus0.Checked = true;
            this.radioButtonGenus0.Location = new System.Drawing.Point(16, 35);
            this.radioButtonGenus0.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonGenus0.Name = "radioButtonGenus0";
            this.radioButtonGenus0.Size = new System.Drawing.Size(52, 17);
            this.radioButtonGenus0.TabIndex = 20;
            this.radioButtonGenus0.TabStop = true;
            this.radioButtonGenus0.Tag = 0;
            this.radioButtonGenus0.Text = "Piano";
            this.radioButtonGenus0.UseVisualStyleBackColor = true;
            this.radioButtonGenus0.CheckedChanged += new System.EventHandler(this.RadioButtonGenus_Click);
            // 
            // panelMidiSpecies
            // 
            this.panelMidiSpecies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMidiSpecies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMidiSpecies.Controls.Add(this.labelSpecies);
            this.panelMidiSpecies.Controls.Add(this.radioButtonSpecies0);
            this.panelMidiSpecies.Location = new System.Drawing.Point(2, 19);
            this.panelMidiSpecies.Margin = new System.Windows.Forms.Padding(2);
            this.panelMidiSpecies.Name = "panelMidiSpecies";
            this.panelMidiSpecies.Size = new System.Drawing.Size(184, 237);
            this.panelMidiSpecies.TabIndex = 31;
            this.panelMidiSpecies.Tag = "0";
            this.toolTip1.SetToolTip(this.panelMidiSpecies, "Select the specific instrument to play.");
            // 
            // labelSpecies
            // 
            this.labelSpecies.AutoSize = true;
            this.labelSpecies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpecies.Location = new System.Drawing.Point(15, 14);
            this.labelSpecies.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSpecies.Name = "labelSpecies";
            this.labelSpecies.Size = new System.Drawing.Size(87, 13);
            this.labelSpecies.TabIndex = 38;
            this.labelSpecies.Text = "MIDI &Species:";
            this.toolTip1.SetToolTip(this.labelSpecies, "Select the specific instrument to play.");
            // 
            // radioButtonSpecies0
            // 
            this.radioButtonSpecies0.AutoSize = true;
            this.radioButtonSpecies0.Checked = true;
            this.radioButtonSpecies0.Location = new System.Drawing.Point(17, 36);
            this.radioButtonSpecies0.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonSpecies0.Name = "radioButtonSpecies0";
            this.radioButtonSpecies0.Size = new System.Drawing.Size(65, 17);
            this.radioButtonSpecies0.TabIndex = 30;
            this.radioButtonSpecies0.TabStop = true;
            this.radioButtonSpecies0.Tag = 0;
            this.radioButtonSpecies0.Text = "Popcorn";
            this.radioButtonSpecies0.UseVisualStyleBackColor = true;
            this.radioButtonSpecies0.Click += new System.EventHandler(this.RadioButtonSpecies_Click);
            // 
            // grpTunes
            // 
            this.grpTunes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTunes.Controls.Add(this._mediaPlayer);
            this.grpTunes.Controls.Add(this.buttonExit);
            this.grpTunes.Controls.Add(this.buttonHelp);
            this.grpTunes.Controls.Add(this.radioButton36);
            this.grpTunes.Controls.Add(this.radioButton35);
            this.grpTunes.Controls.Add(this.radioButton5);
            this.grpTunes.Controls.Add(this.radioButton6);
            this.grpTunes.Controls.Add(this.radioButton7);
            this.grpTunes.Controls.Add(this.radioButton8);
            this.grpTunes.Controls.Add(this.radioButton9);
            this.grpTunes.Controls.Add(this.radioButton10);
            this.grpTunes.Controls.Add(this.radioButton4);
            this.grpTunes.Controls.Add(this.radioButton3);
            this.grpTunes.Controls.Add(this.radioButton2);
            this.grpTunes.Controls.Add(this.radioButton1);
            this.grpTunes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpTunes.Location = new System.Drawing.Point(2, 2);
            this.grpTunes.Margin = new System.Windows.Forms.Padding(2);
            this.grpTunes.Name = "grpTunes";
            this.grpTunes.Padding = new System.Windows.Forms.Padding(2);
            this.grpTunes.Size = new System.Drawing.Size(621, 158);
            this.grpTunes.TabIndex = 1;
            this.grpTunes.TabStop = false;
            this.grpTunes.Tag = "QABC_WillTell";
            this.grpTunes.Text = "Sample Tunes";
            this.toolTip1.SetToolTip(this.grpTunes, "Select a tune to play.");
            // 
            // _mediaPlayer
            // 
            this._mediaPlayer.Enabled = true;
            this._mediaPlayer.Location = new System.Drawing.Point(457, 54);
            this._mediaPlayer.Name = "_mediaPlayer";
            this._mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mediaPlayer.OcxState")));
            this._mediaPlayer.Size = new System.Drawing.Size(142, 55);
            this._mediaPlayer.TabIndex = 3;
            this._mediaPlayer.Visible = false;
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Location = new System.Drawing.Point(543, 124);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(56, 23);
            this.buttonExit.TabIndex = 14;
            this.buttonExit.Text = "E&xit";
            this.toolTip1.SetToolTip(this.buttonExit, "Exit application (ALT-F4)");
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHelp.Location = new System.Drawing.Point(543, 20);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(2);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(56, 23);
            this.buttonHelp.TabIndex = 13;
            this.buttonHelp.Text = "&Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.ButtonHelp_Click);
            // 
            // radioButton36
            // 
            this.radioButton36.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButton36.AutoSize = true;
            this.radioButton36.Location = new System.Drawing.Point(256, 130);
            this.radioButton36.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton36.Name = "radioButton36";
            this.radioButton36.Size = new System.Drawing.Size(151, 17);
            this.radioButton36.TabIndex = 11;
            this.radioButton36.Tag = "QABC_Unknown";
            this.radioButton36.Text = "&B - Can You Recognize It?";
            this.toolTip1.SetToolTip(this.radioButton36, "Select a tune to play.");
            this.radioButton36.UseVisualStyleBackColor = true;
            this.radioButton36.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // radioButton35
            // 
            this.radioButton35.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButton35.AutoSize = true;
            this.radioButton35.Location = new System.Drawing.Point(256, 108);
            this.radioButton35.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton35.Name = "radioButton35";
            this.radioButton35.Size = new System.Drawing.Size(97, 17);
            this.radioButton35.TabIndex = 10;
            this.radioButton35.Tag = "QABC_Doe_a_deer";
            this.radioButton35.Text = "&A - Doe, a deer";
            this.toolTip1.SetToolTip(this.radioButton35, "Select a tune to play.");
            this.radioButton35.UseVisualStyleBackColor = true;
            this.radioButton35.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(14, 108);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(80, 17);
            this.radioButton5.TabIndex = 5;
            this.radioButton5.Tag = "QABC_Ecuador";
            this.radioButton5.Text = "&4 - Ecuador";
            this.toolTip1.SetToolTip(this.radioButton5, "Select a tune to play.");
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(14, 130);
            this.radioButton6.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(145, 17);
            this.radioButton6.TabIndex = 6;
            this.radioButton6.Tag = "QABC_GodSaveTheQueen";
            this.radioButton6.Text = "&5 - God Save The Queen";
            this.toolTip1.SetToolTip(this.radioButton6, "Select a tune to play.");
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // radioButton7
            // 
            this.radioButton7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(256, 20);
            this.radioButton7.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(114, 17);
            this.radioButton7.TabIndex = 7;
            this.radioButton7.Tag = "QABC_YankeeDoodle";
            this.radioButton7.Text = "&6 - Yankee Doodle";
            this.toolTip1.SetToolTip(this.radioButton7, "Select a tune to play.");
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // radioButton8
            // 
            this.radioButton8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(256, 42);
            this.radioButton8.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(108, 17);
            this.radioButton8.TabIndex = 8;
            this.radioButton8.Tag = "QABC_FuneralMarch";
            this.radioButton8.Text = "&7 - Funeral March";
            this.toolTip1.SetToolTip(this.radioButton8, "Select a tune to play.");
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // radioButton9
            // 
            this.radioButton9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(256, 64);
            this.radioButton9.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(192, 17);
            this.radioButton9.TabIndex = 9;
            this.radioButton9.Tag = "QABC_TakeMeOutToTheBallGame";
            this.radioButton9.Text = "&8 - Take Me Out To The Ball Game";
            this.toolTip1.SetToolTip(this.radioButton9, "Select a tune to play.");
            this.radioButton9.UseVisualStyleBackColor = true;
            this.radioButton9.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // radioButton10
            // 
            this.radioButton10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(256, 86);
            this.radioButton10.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(88, 17);
            this.radioButton10.TabIndex = 0;
            this.radioButton10.Tag = "QABC_Macarena";
            this.radioButton10.Text = "&9 - Macarena";
            this.toolTip1.SetToolTip(this.radioButton10, "Select a tune to play.");
            this.radioButton10.UseVisualStyleBackColor = true;
            this.radioButton10.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(14, 86);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(80, 17);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.Tag = "QABC_Popcorn";
            this.radioButton4.Text = "&3 - Popcorn";
            this.toolTip1.SetToolTip(this.radioButton4, "Select a tune to play.");
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(14, 64);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(156, 17);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Tag = "QABC_TheLionSleepsTonight";
            this.radioButton3.Text = "&2 - The Lion Sleeps Tonight";
            this.toolTip1.SetToolTip(this.radioButton3, "Select a tune to play.");
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(14, 42);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(92, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Tag = "QABC_JingleBells";
            this.radioButton2.Text = "&1 - Jingle Bells";
            this.toolTip1.SetToolTip(this.radioButton2, "Select a tune to play.");
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(14, 20);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(168, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "QABC_WillTell";
            this.radioButton1.Text = "&0 - Finale William Tell Overture";
            this.toolTip1.SetToolTip(this.radioButton1, "Select a tune to play.");
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.musicSplitContainer1);
            this.splitContainer2.Panel1.Controls.Add(this.labelAbcScore);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.gridCompileErrors);
            this.splitContainer2.Size = new System.Drawing.Size(613, 492);
            this.splitContainer2.SplitterDistance = 443;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // musicSplitContainer1
            // 
            this.musicSplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.musicSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.musicSplitContainer1.HighQuality = false;
            this.musicSplitContainer1.Location = new System.Drawing.Point(0, 15);
            this.musicSplitContainer1.Name = "musicSplitContainer1";
            this.musicSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // musicSplitContainer1.Panel1
            // 
            this.musicSplitContainer1.Panel1.Controls.Add(this.txtMusicString);
            this.musicSplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // musicSplitContainer1.Panel2
            // 
            this.musicSplitContainer1.Panel2.Controls.Add(this.pbHighlight);
            this.musicSplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.musicSplitContainer1.ScoreHighlighter = null;
            this.musicSplitContainer1.Size = new System.Drawing.Size(613, 428);
            this.musicSplitContainer1.SplitterDistance = 142;
            this.musicSplitContainer1.TabIndex = 29;
            this.musicSplitContainer1.Tune = null;
            // 
            // txtMusicString
            // 
            this.txtMusicString.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtMusicString.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.txtMusicString.BackBrush = null;
            this.txtMusicString.CharHeight = 14;
            this.txtMusicString.CharWidth = 8;
            this.txtMusicString.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMusicString.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtMusicString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMusicString.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtMusicString.IsReplaceMode = false;
            this.txtMusicString.Location = new System.Drawing.Point(0, 0);
            this.txtMusicString.Name = "txtMusicString";
            this.txtMusicString.Paddings = new System.Windows.Forms.Padding(0);
            this.txtMusicString.ScoreProvider = null;
            this.txtMusicString.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtMusicString.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtMusicString.ServiceColors")));
            this.txtMusicString.Size = new System.Drawing.Size(609, 138);
            this.txtMusicString.TabIndex = 1;
            this.txtMusicString.Zoom = 100;
            this.txtMusicString.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.TxtMusicString_TextChanged);
            // 
            // pbHighlight
            // 
            this.pbHighlight.BackColor = System.Drawing.Color.Transparent;
            this.pbHighlight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbHighlight.Location = new System.Drawing.Point(0, 0);
            this.pbHighlight.Name = "pbHighlight";
            this.pbHighlight.ScoreProvider = null;
            this.pbHighlight.Size = new System.Drawing.Size(609, 278);
            this.pbHighlight.SourceProvider = null;
            this.pbHighlight.TabIndex = 0;
            // 
            // labelAbcScore
            // 
            this.labelAbcScore.AutoSize = true;
            this.labelAbcScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAbcScore.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelAbcScore.Location = new System.Drawing.Point(0, 0);
            this.labelAbcScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAbcScore.Name = "labelAbcScore";
            this.labelAbcScore.Size = new System.Drawing.Size(245, 15);
            this.labelAbcScore.TabIndex = 28;
            this.labelAbcScore.Text = "Score (1 voice) in QBasic version of ABC Notation";
            // 
            // gridCompileErrors
            // 
            this.gridCompileErrors.AllowUserToAddRows = false;
            this.gridCompileErrors.AllowUserToDeleteRows = false;
            this.gridCompileErrors.AllowUserToResizeRows = false;
            this.gridCompileErrors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.gridCompileErrors.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridCompileErrors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCompileErrors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridCompileErrors.ColumnHeadersHeight = 24;
            this.gridCompileErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridCompileErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCompileErrors.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridCompileErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCompileErrors.Location = new System.Drawing.Point(0, 0);
            this.gridCompileErrors.MultiSelect = false;
            this.gridCompileErrors.Name = "gridCompileErrors";
            this.gridCompileErrors.ReadOnly = true;
            this.gridCompileErrors.RowHeadersVisible = false;
            this.gridCompileErrors.RowTemplate.Height = 24;
            this.gridCompileErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridCompileErrors.Size = new System.Drawing.Size(609, 42);
            this.gridCompileErrors.TabIndex = 27;
            this.toolTip1.SetToolTip(this.gridCompileErrors, "Error messages from QABC Parser");
            this.gridCompileErrors.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCompileErrors_CellDoubleClick);
            this.gridCompileErrors.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCompileErrors_CellDoubleClick);
            this.gridCompileErrors.Resize += new System.EventHandler(this.GridCompileErrors_Resize);
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "L, C";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 35;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.ToolTipText = "Double-click grid cell to locate in source code";
            this.dataGridViewTextBoxColumn3.Width = 35;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "Error Message";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "State";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.HeaderText = "Parse State";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 65;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Double-click grid cell to navigate to state details";
            this.dataGridViewTextBoxColumn1.Width = 68;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.BackColor = System.Drawing.Color.Transparent;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            // 
            // PlayMidiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 492);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(16, 530);
            this.Name = "PlayMidiForm";
            this.Text = "PG Software Solutions Inc. - Music Sunthesizer for QBasic Play_ABC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayMidiForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlayMidiForm_FormClosed);
            this.Load += new System.EventHandler(this.PlayMidiForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PlayMidiForm_KeyUp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSynthesizer)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panelMidiGenus.ResumeLayout(false);
            this.panelMidiGenus.PerformLayout();
            this.panelMidiSpecies.ResumeLayout(false);
            this.panelMidiSpecies.PerformLayout();
            this.grpTunes.ResumeLayout(false);
            this.grpTunes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mediaPlayer)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.musicSplitContainer1.Panel1.ResumeLayout(false);
            this.musicSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.musicSplitContainer1)).EndInit();
            this.musicSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMusicString)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompileErrors)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		#region Definitions
		private System.Windows.Forms.SplitContainer splitContainer1; 
		private System.Windows.Forms.GroupBox grpTunes;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.RadioButton radioButton7;
		private System.Windows.Forms.RadioButton radioButton8;
		private System.Windows.Forms.RadioButton radioButton9;
		private System.Windows.Forms.RadioButton radioButton10;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton36;
		private System.Windows.Forms.RadioButton radioButton35;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Label labelAbcScore;
		private System.Windows.Forms.DataGridView gridCompileErrors;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label labelSynthesizerFunctions;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.Label labelMidiInstrument;
		private System.Windows.Forms.Panel panelMidiGenus;
		private System.Windows.Forms.Label labelGenus;
		private System.Windows.Forms.RadioButton radioButtonGenus0;
		private System.Windows.Forms.Panel panelMidiSpecies;
		private System.Windows.Forms.RadioButton radioButtonSpecies0;
		private System.Windows.Forms.Label labelSpecies;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.Button buttonHelp;
		private FastColoredTextBoxNS.FastColoredTextBox txtSynthesizer;
		private System.Windows.Forms.ToolTip toolTip1;

        private PGSoftwareSolutions.ScoreDisplay.MusicSplitContainer musicSplitContainer1;

        private PGSoftwareSolutions.ScoreDisplay.MusicSourceTextBox txtMusicString;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonShowWave;
        private System.Windows.Forms.CheckBox buttonLoad;
        private System.Windows.Forms.CheckBox buttonPause;
        private System.Windows.Forms.CheckBox buttonPlay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        #endregion

        private PGSoftwareSolutions.ScoreDisplay.HighlightScorePanel pbHighlight;
        private AxWMPLib.AxWindowsMediaPlayer _mediaPlayer;
    }
}