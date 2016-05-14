#region License
////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
#endregion
using System;
using System.Windows.Forms;

using FastColoredTextBoxNS;

using PGSoftwareSolutions.Util.PlayWaveLib;

namespace PGSoftwareSolutions.ScoreDisplay {
	public interface ISourceProvider {
		/// <summary> Highlight txtMusicString at <i>position</i> for <i>length</i>  </summary>
		/// <param name="position"></param>
		/// <param name="length"></param>
		void ShowSourcePosition(int position, int length);
	}
	public class MusicSourceTextBox : FastColoredTextBox, ISourceProvider {
		public MusicSourceTextBox() {}
		public	IScoreProvider ScoreProvider { get; set; }

		protected override void OnHelpRequested(HelpEventArgs e) { base.OnHelpRequested(e);
			using (FormHelp formHelp = new FormHelp()) { formHelp.ShowDialog(); }
		}
		protected override void OnKeyUp(KeyEventArgs e) { base.OnKeyUp(e);
			switch (e.KeyCode) {
				case Keys.Left:	case Keys.Right:
				case Keys.Up:		case Keys.Down:	
					if (!e.Shift) ScoreProvider.ShowScorePosition(SelectionStart,true);
					break;
			}
		}
		protected override void OnMouseClick(MouseEventArgs e) { base.OnMouseClick(e);
			int position	= PointToPosition(e.Location);
			ScoreProvider.ShowScorePosition(position,true);
		}
 		protected override void OnMouseDoubleClick(MouseEventArgs e) { base.OnMouseDoubleClick(e);
			var note					= ScoreProvider.SourceToNote(PointToPosition(e.Location));
			if (note != null)	{
				SelectionStart		= note.SpanPosition;
				SelectionLength	= note.SpanLength;
				Invalidate();
			}
		}

		#region ISourceProvider implementation
		/// <summary> Highlight txtMusicString at <i>position</i> for <i>length</i>  </summary>
		/// <param name="position"></param>
		/// <param name="length"></param>
		public void ShowSourcePosition(int position, int length) {
			if (position >= 0) {
				SelectionStart		= position;
				SelectionLength	= length;
				DoCaretVisible();
			}
		}
		#endregion
	}
}
