#region License
////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
#endregion
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using PGSoftwareSolutions.Qabc;
using PGSoftwareSolutions.Music;

namespace PGSoftwareSolutions.ScoreDisplay {
    /// <summary>TODO</summary>
	public partial class MusicSplitContainer : SplitContainer, ISupportInitialize, IScoreProvider {
        private bool _disposed = false;
        /// <summary> Clean up any resources being used. </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
			if (!_disposed) {
				if (disposing) {
					_penThick.Dispose();
					_penMedium.Dispose();
					_penThin.Dispose();
				}
				// large fields set to null
				_tune		= null;
				_score		= null;

				// Almost done now.
				base.Dispose(disposing);
				_disposed	= true;
			}
		}

		#region ISupportInitialize implementation
		void ISupportInitialize.EndInit() {	
			base.EndInit();

			Panel2.VerticalScroll.LargeChange = (int)Math.Round(_scale * (_height + _spacing));
			Panel2.VerticalScroll.SmallChange = (int)Math.Round(_scale * (_height + _spacing))/10;
			Panel2.Paint		+= Panel2_Paint;
			Panel2.Resize		+= Panel2_Resize;
			Panel2.MouseWheel += Panel2_MouseWheel;

			// Reflect to set Double-Buffering on Panel2
			typeof(Control)
				.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
				.SetValue(Panel2, true, null);
		}
		#endregion

		#region IScoreProvider implementation
		/// <inheritdoc />
		IAwareNote			IScoreProvider.MouseToNote(MouseEventArgs e) {
			return (_score == null) ? null : _tune[((IScoreProvider)this).GetNotePosition(e).NoteNo];
		}
		/// <summary>Returns <code>IAwareNote</code> at given offset from start of music source.</summary>
		/// <param name="position">Offset of current note from start of music source.</param>
		/// <returns></returns>
		IAwareNote			IScoreProvider.SourceToNote(int position) {
			return (	from note in _tune
						where note.SpanEndPos > position 						
						select note).FirstOrDefault();
		}
		/// <summary>Returns <code>IScoreNotePosition</code> for note undermouse-click</summary>
		/// <param name="e">MouseEventArgs</param>
		/// <returns><code>IScoreNotePosition</code></returns>
		IScoreNotePosition	IScoreProvider.GetNotePosition(MouseEventArgs e) {
			if (_score == null) return null;
			return (	from scoreLine in _score
						from notePosition in scoreLine
						where e.Y >= (int)scoreLine.Matrix.OffsetY
							&& e.Y <  (int)scoreLine.Matrix.OffsetY + _scale * (_height + _spacing)
							&& e.X >= _scale * notePosition.X
							&&	e.X <  _scale * (notePosition.X + notePosition.Width)
						select notePosition).FirstOrDefault();
		}
		/// <summary>Highlights current note on score, and scrolls highlight window if requested.</summary>
		/// <param name="position">Offset of current note from start of music source.</param>
		/// <param name="scroll">Set true/false to enable/disable scrolling of the score to the highlighted note.</param>
		/// <remarks>Uses a closure to enable <code>ScoreHighlighter</code> to draw on its
		/// own Graphics using data private to <code>ScorePanel</code></remarks>
		Rectangle			IScoreProvider.ShowScorePosition(int position, bool scroll) {
			Rectangle r = new Rectangle();
			if (_score != null  && _score.Count != 0) {
				var scoreLine = ( from sl in _score
                                  where sl.MaxNotePosition >= position
                                  select sl
                                ).FirstOrDefault();
				if (scoreLine != null) {
					if (scroll) {
						Panel2.AutoScrollPosition = new System.Drawing.Point(0, (int) (
							( Panel2.AutoScrollMinSize.Height / _score.Count )
							* ( (float)scoreLine.Index - 1.5F
							+ ( (float)(          position        - scoreLine[0].Position)
							  / (float)(scoreLine.MaxNotePosition - scoreLine[0].Position) )
							)
						));
					}
                    if (ScoreHighlighter != null) {
                        var note = (from n in scoreLine
                                    where n.Position >= position
                                    select n).FirstOrDefault();
                        if (note != null) {
                            r = new Rectangle(note.X - 5, 0, 25, _height + _spacing);
                            ScoreHighlighter.HighlightNote(note, r, g => {
                                g.Transform = scoreLine.Matrix;
                                g.DrawEllipse(Pens.Purple, note.X - 5, 0, 25, _height + _spacing);
                            } );
                        }
                    }
                }
			}
			return r;
		}
        /// <summary>TODO</summary>
		public bool				 HighQuality {
			get {return _highQuality;}
			set {_highQuality = value; Invalidate();} 
		} bool _highQuality;
        /// <summary>TODO</summary>
        [CLSCompliant(false)]
        public Tune<INote>		 Tune	     { 
			get { return _tuneNote; } 
			set { 
				_tuneNote = value; 
				if (value != null)
					_tune = ( from note in value
							  where value.All(n => n is IAwareNote)
							  select note
                            ).Cast<IAwareNote>().ToList<IAwareNote>();
				else {
					_tune = null;
					_score = null;
					if (ScoreHighlighter != null) 
						ScoreHighlighter.HighlightNote(null,Rectangle.Empty,null);
				}
				_isLayoutDirty = true;
				Panel2.Invalidate();
			} 
		} Tune<INote> _tuneNote; List<IAwareNote> _tune;
        /// <summary>TODO</summary>
        public new void          Invalidate(){ Panel2.Invalidate(); }
        /// <summary>TODO</summary>
        public new void          Invalidate(Rectangle r){ Panel2.Invalidate(r); }
        /// <summary>TODO</summary>
        public IScoreHighlighter ScoreHighlighter	{ get; set; }
		#endregion

		#region Panel2 events
		private int			_oldPanelWidth;
		///<inheritdoc cref="Control.Paint"/>
		protected void Panel2_Paint(object sender, PaintEventArgs e) {
			LayoutNotes(e.Graphics,(int)((Panel2.Width-20)/_scale));
			PaintNotes(e.Graphics);
		}
		///<inheritdoc cref="Control.Resize"/>
		protected void Panel2_Resize(object sender, EventArgs e)
		{
			_isLayoutDirty = (Panel2.Width != _oldPanelWidth);
			_oldPanelWidth = Panel2.Width;
		}
		///<inheritdoc cref="Control.MouseWheel"/>
		protected void Panel2_MouseWheel(object sender, MouseEventArgs e) {
			Trace.WriteLine(string.Format("Delta = {0}",e.Delta));
		}
		#endregion

		#region Panel2 Painting
		#region private fields
		private readonly Pen	_penThick	= new Pen(Brushes.Black, 3.0F);
		private readonly Pen	_penMedium	= new Pen(Brushes.Black, 1.2F);
		private readonly Pen	_penThin	= new Pen(Brushes.Black, 0.8F);

		private const float		_scale		= 1.4F;
		private readonly int	_height		= (int)Math.Floor(150/_scale);
		private const int		_spacing	= 0;		// extra spacing between staffs
		private int				_oldWidth	= 0;
		private Score			_score;					// cache the score layout
		private bool			_isLayoutDirty;

//		private const bool		_debug		= false;
		#endregion

		private void LayoutNotes(Graphics g, int widthStave) {
            DebugWrite(string.Format("Layout({0}/{1}): ",_isLayoutDirty,widthStave != _oldWidth));
			if (_tune != null  &&  _tune.Count > 0  
			&&  (_isLayoutDirty || widthStave != _oldWidth) ) {
				_isLayoutDirty = false;
				int x				= widthStave;
				g.ScaleTransform(_scale,_scale);

				_score = new Score(widthStave);
				MusicPaths.StartUp(new Size(widthStave-10,0));
				ScoreLine scoreLine	= null;
				IAwareNote note		= null;
				for (int iNote=0; iNote < _tune.Count; iNote++) {
					if (iNote == 0) {
						scoreLine = new ScoreLine(_score.Count, g.Transform, iNote);
						x = 35; 
					}
					if (widthStave < x + 24) {
						scoreLine.MaxNoteNo			= iNote;
						scoreLine.MaxNotePosition	= note.SpanPosition;
						_score += scoreLine;
						g.TranslateTransform(0F,_height);

						scoreLine = new ScoreLine(_score.Count, g.Transform, iNote);
						x = 35; 
					}

					note	= _tune[iNote];
					int y	= 32;
					if (note.PianoKey != PianoKey.Rest) {
                        y += 18 -  3 * (note.NoteLetter.NoteIndex() - NoteLetter.C.NoteIndex())
                                - 21 * (note.PianoKey.Octave() - PianoKey.C_4.Octave());
                    }
                    var width	= 20 + Math.Abs((int)note.SharpFlat) * 7 + note.Length.DotCount * 4;
					var notePos = new ScoreNotePosition(x, y, width, note.SpanPosition, note.SpanLength, iNote);
					scoreLine  += notePos;
					x += width;
				}
				scoreLine.MaxNoteNo			= _tune.Count-1;
				scoreLine.MaxNotePosition	= note.SpanPosition;
				_score							+= scoreLine;
				_oldWidth						= widthStave;
				Panel2.AutoScrollMinSize	= new SizeF(_oldWidth,
													75 + _height+(int)g.Transform.Elements[5]).ToSize();
                DebugWrite(" done");
			} else if (_tune == null  ||  _tune.Count == 0) {
				Panel2.AutoScrollMinSize	= g.VisibleClipBounds.Size.ToSize();
                DebugWrite(" skipped");
			}
            DebugWriteLine();
		}

        private void PaintNotes(Graphics g) {
			DebugWrite("PaintList: ");
			if (_tune != null  &&  _score != null  &&  _score.Count != 0  &&  !g.IsClipEmpty) {
				var loc			= new PointF(5,22);
				var size		= new Size(_score.Width-10,0);
				var paths		= MusicPaths.Get;
				g.SmoothingMode	= _highQuality	? SmoothingMode.HighQuality 
												: SmoothingMode.Default;
				g.SmoothingMode	= SmoothingMode.HighQuality;
                DebugWrite(g.VisibleClipBounds.ToString());
				foreach(IScoreLine scoreLine in _score) {
					g.Transform = scoreLine.Matrix;
					g.TranslateTransform(0,Panel2.AutoScrollPosition.Y,MatrixOrder.Append);
					var r = new RectangleF(0,0, _score.Width-10,_height+50);
					if (InClip(g.VisibleClipBounds, r)) {
                        DebugWrite(scoreLine.Index + ", ");
						DrawPianoStaff(g, loc, size, _spacing);
						foreach(IScoreNotePosition notePos in scoreLine) {
							IAwareNote note = (IAwareNote)_tune[notePos.NoteNo];

							int x = notePos.X, y = notePos.Y;
							if (InClip(g.VisibleClipBounds, new RectangleF(x,0,notePos.Width,_height+50))) {
								if (note.PianoKey == PianoKey.Rest) {
									note.DrawRest(g, new Point(x,y));
								} else if (note.PianoKey == PianoKey.Bar) {
                                    DrawBar(g, new Point(x,y), _spacing);
                                } else {
									int i = (int)note.SharpFlat;
									while(i > 0) { paths.Sharp.Draw(g,new PointF(x,y)); x+=7; i--; }
									while(i < 0) { paths.Flat.Draw( g,new PointF(x,y)); x+=7; i++; }

//									Stem stem = y < 23 ? Stem.Down : Stem.Up;		// middle treble staff
									Stem stem = y > 51 ? Stem.Down : Stem.Up;		// Middle-C
									note.DrawNote(g,new Point(x,y),stem);

									// Draw staff-extension (leger) lines for note
									if (y == 50) g.DrawLine(_penThin, x-3,52, x+12,52);
									int y2=y, y3=88, y4=16;
									while(y2 > 83) { g.DrawLine(_penThin, x-3,y3, x+12,y3); y2-=6; y3+=6; }
									while(y2 < 17) { g.DrawLine(_penThin, x-3,y4, x+12,y4); y2+=6; y4-=6; }
								}
								x += 20;
								for (int i=0; i< note.Length.DotCount; i++) {
									g.FillEllipse(Brushes.Black, x-10F, ((y+3)/6) * 6, 3F,3F);
									x += 4;
								}
							}
						}
					}
				}
			}
            DebugWriteLine();
		}
		private bool InClip(RectangleF clip, RectangleF obj) {
			return (obj.X >= clip.X - obj.Width)	&& (obj.Y >= clip.Y - obj.Height)
				&&  (obj.X <= clip.X + clip.Width)	&& (obj.Y <= clip.Y + clip.Height);
		}
		private void DrawPianoStaff(Graphics g, PointF loc, Size size, float spacing = 0F) {
			float height = 36F + spacing;
			g.DrawLine(_penThick, loc.X,loc.Y, loc.X, loc.Y + height + 24F);

			Staff.DrawMe(g,loc,size);
			Clef.DrawTreble(g,loc);
			g.TranslateTransform(0,height);

			Staff.DrawMe(g,loc,size);
			Clef.DrawBass(g,loc);
			g.TranslateTransform(0,-height);

			g.DrawLine(_penMedium, loc.X+size.Width,loc.Y, loc.X+size.Width,loc.Y + height + 24F);
		}
        private void DrawBar(Graphics g, PointF loc, float spacing = 0F) {
            float height = 36F + spacing;
            g.DrawLine(_penMedium, loc.X, loc.Y,                  loc.X, loc.Y + height/2);
            g.DrawLine(_penMedium, loc.X, loc.Y + height/2 + 24F, loc.X, loc.Y + height + 24F);
        }
        #endregion

        partial void DebugWrite(string s);
        partial void DebugWriteLine(string s = "");
#if DEBUG
        partial void DebugWrite(string s)     { Debug.Write(s); }
        partial void DebugWriteLine(string s) { Debug.WriteLine(s); }
#endif
    }
    /// <summary>TODO</summary>
	public interface IScoreHighlighter {
		/// <summary>Highlights note on score display from a closure provided by <c>IScoreProvider</c>
		/// acting on a <c>Graphics</c>.</summary>
		/// <param name="noteHighlight"></param>
		void HighlightNote(IScoreNotePosition note, Rectangle r, Action<Graphics> noteHighlight);
	}
}
