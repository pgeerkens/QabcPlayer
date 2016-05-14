#region License
////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
#endregion
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using PGSoftwareSolutions.Util;
using PGSoftwareSolutions.Qabc;
using PGSoftwareSolutions.Music;

namespace PGSoftwareSolutions.ScoreDisplay {
    /// <summary>TODO</summary>
	public interface IScoreNotePosition {
		int X			{ get; }			// location on stave
		int Y			{ get; }            // location on stave
        int Width		{ get; }            // width on stave
        int Position	{ get; }			// location in text source
		int Length		{ get; }			// length in text source
		int NoteNo		{ get; }			// index into _tune
	}
    /// <summary>TODO</summary>
	public interface IScoreLine : IList<IScoreNotePosition> {
		int		Index			{ get; }
		Matrix	Matrix			{ get; }
		int		MinNoteNo		{ get; }
		int		MaxNoteNo		{ get; set; }
		int		MaxNotePosition	{ get; set; }
	}
    /// <summary>TODO</summary>
	public interface IScore : IList<IScoreLine> {
		int Width { get; }
	}
    /// <summary>TODO</summary>
	public interface IScoreProvider {
		/// <summary>Returns <code>IAwareNote</code> under mouse-click.</summary>
		/// <param name="e">MouseEventArgs</param>
		/// <returns>IAwareNote</returns>
		IAwareNote				MouseToNote(MouseEventArgs e);
		/// <summary>Returns <code>IAwareNote</code> at given offset from start of music source.</summary>
		/// <param name="position">Offset of current note from start of music source.</param>
		/// <returns></returns>
		IAwareNote				SourceToNote(int position);
		/// <summary>Returns <code>IScoreNotePosition</code> for note undermouse-click</summary>
		/// <param name="e">MouseEventArgs</param>
		/// <returns><code>IScoreNotePosition</code></returns>
		IScoreNotePosition	    GetNotePosition(MouseEventArgs e);
		/// <summary>Highlights current note on score, and scrolls highlight window if requested.</summary>
		/// <param name="position">Offset of current note from start of music source.</param>
		/// <param name="scroll">Set false to disable scrolling of score on highlight.</param>
		/// <remarks>Uses a closure to enable <code>ScoreHighlighter</code> to draw on its
		/// own Graphics using data private to <code>ScorePanel</code></remarks>
		Rectangle				ShowScorePosition(int position, bool scroll = true);
		/// <summary>Gets or sets whether graphics is optimized for quality or speed.</summary>
		bool					HighQuality { get; set; }
        /// <summary>Gets or sets the <see cref="Tune&lt;INote&gt;"/> to be displayed.</summary>
        /// <remarks>If a <see cref="Tune&lt;INote&gt;"/> is provided, the <i>hot-note</i> functionality is enabled.</remarks>
        Tune<INote>				Tune			{ get; set; }
		/// <summary>Request redraw of entire visible client area.</summary>
		void					Invalidate();
		/// <summary>Request redraw of specified portion of client area.</summary>
		/// <param name="r">Boudning <c>Rectangle</c> that requires redrawing.</param>
		void					Invalidate(Rectangle r);
		/// <summary> </summary>
		IScoreHighlighter		ScoreHighlighter	{ get; set; }
	}

    /// <summary>TODO</summary>
	public class HighlightScorePanel : TransparentPanel, IScoreHighlighter {
		/// <inheritdoc />
		public HighlightScorePanel() : base() {
			InitializeComponent();
		}
	
		/// <summary>Gets or sets the <c>ScoreProvider</c> to be used.</summary>
		public IScoreProvider	ScoreProvider	{ get; set; }
		/// <summary>Gets or sets the <c>SOurceProvider</c> to be used.</summary>
		public ISourceProvider	SourceProvider { get; set; }

		Rectangle				_oldHighlightedRectangle;
		IScoreNotePosition		_oldHighlightedNote;
		/// <summary>Draws new note-highlight graphics on specified note after erasing old,
		/// scrolling score display only as requested, and moves source-highlight to new note. </summary>
		/// <param name="notePosition"></param>
		/// <param name="scroll"></param>
		protected virtual void HighlightNotePosition(IScoreNotePosition notePosition, Rectangle r, bool scroll) {
			if (!_oldHighlightedRectangle.IsEmpty)	InvalidateEx(_oldHighlightedRectangle);
			InvalidateEx(_oldHighlightedRectangle = r);
            // = ScoreProvider.ShowScorePosition(notePosition.Position, scroll));
            //			SourceProvider.ShowSourcePosition(notePosition.Position, notePosition.Length);
            _oldHighlightedNote = notePosition;
		}
		/// <inheritdoc />
		/// <summary><see cref="Panel.OnResize"/></summary>
		protected override void OnResize(EventArgs e) {
			InvalidateEx();
			if (_oldHighlightedNote != null)
                HighlightNotePosition(_oldHighlightedNote, Rectangle.Empty, true);
		}
		/// <inheritdoc />
		/// <summary><see cref="Control.OnPaint"/></summary>
		protected override void OnPaint(PaintEventArgs e) { base.OnPaint(e);
			if (_highlightNoteDelegate != null)	_highlightNoteDelegate(e.Graphics);
		}

		#region IScoreHighlighter implementation
		private Action<Graphics> _highlightNoteDelegate;
		/// <inheritdoc />
		public void HighlightNote(IScoreNotePosition note, Rectangle r, Action<Graphics> highlightNote) {
			_highlightNoteDelegate = highlightNote;
            if (note != null)          HighlightNotePosition(note, r, false);
            InvalidateEx(_oldHighlightedRectangle);
        }
        #endregion

        #region ToolTip
        /// <inheritdoc />
        protected override void OnMouseClick(MouseEventArgs e) {	base.OnMouseClick(e);
			var notePosition = ScoreProvider.GetNotePosition(e);
			if (notePosition != null) {
				if (e.Button.HasFlag(MouseButtons.Right)) {
					toolTip1.BackColor = Color.FromArgb(148,223,223,223);
					_isNoteToolTip = true;
					_mousePoint = PointToScreen(e.Location);
					toolTip1.Show(ToolTipText(e), this, 2500);
				}
				HighlightNotePosition(notePosition, Rectangle.Empty, false);
			}
		}
		/// <inheritdoc />
		protected override void OnMouseMove(MouseEventArgs e) { base.OnMouseMove(e);
			var notePosition = ScoreProvider.GetNotePosition(e);
			if (notePosition != null  &&  notePosition != _oldHighlightedNote) {
//				toolTip1.Hide(this);
			}
		}
		/// <inheritdoc />
		protected void ScoreHighlightPanel_MouseEnter(object sender, System.EventArgs e) {
			toolTip1.BackColor = SystemColors.ControlLight;
			toolTip1.SetToolTip(this,"Right-click for note details.");
			_isNoteToolTip = false;
		}
		/// <inheritdoc />
		protected void toolTip1_Popup(object sender, PopupEventArgs e) {
			_mousePoint = System.Windows.Forms.Cursor.Position;// + new Size(0,0);
		}
		/// <inheritdoc />
		protected string ToolTipText(MouseEventArgs e) {
			var note = ScoreProvider.MouseToNote(e);
			return (note.PianoKey == PianoKey.Rest)
				? string.Format("Rest:{0}", note.Length)
				: string.Format("{1}{2}{3}{4}\nkey#{0}", (int)note.PianoKey, 
					note.NoteLetter, note.PianoKey.Octave(), note.SharpFlat.AsString(), note.Length);
		}

		private Point _mousePoint;
		private bool _isNoteToolTip = false;
		void toolTip1_Draw(object sender, DrawToolTipEventArgs e) {
			if (_isNoteToolTip) {
				e.Graphics.CompositingMode = CompositingMode.SourceOver;
				e.Graphics.CopyFromScreen(_mousePoint,e.Bounds.Location,e.Bounds.Size);
				e.Graphics.FillRectangle(new SolidBrush(toolTip1.BackColor),e.Bounds);
				toolTip1.ForeColor = Color.Black;
				e.DrawText(TextFormatFlags.TextBoxControl|TextFormatFlags.ModifyString|TextFormatFlags.HorizontalCenter);
			} else {
				e.DrawBackground();
				e.DrawBorder();
				e.DrawText();
			}
		}
		#endregion

		#region Designer
		/// <summary> Clean up any resources being used. </summary>
		/// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
		private bool _disposed;
		protected override void Dispose(bool disposing) {
			if (!_disposed) {
				if (disposing && (components != null)) {
					components.Dispose();
				}
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
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// toolTip1
			// 
			this.toolTip1.AutomaticDelay = 200;
			this.toolTip1.OwnerDraw = true;
			this.toolTip1.ToolTipTitle = "Note Info:";
			this.toolTip1.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip1_Draw);
			this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
			// 
			// ScoreHighlightPanel
			// 
			this.toolTip1.SetToolTip(this, "Right-click for note details.");
			this.MouseEnter += new System.EventHandler(this.ScoreHighlightPanel_MouseEnter);
			this.ResumeLayout(false);

		}
		/// <summary> Required designer variable. </summary>
		private System.ComponentModel.IContainer components = null;
		#endregion

		private ToolTip			toolTip1;
		#endregion
	}
}
