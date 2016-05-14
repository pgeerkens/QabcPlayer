////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

using PGSoftwareSolutions.Util.PlayWaveLib;
using PGSoftwareSolutions.Qabc;
using PGSoftwareSolutions.Music;

namespace PGSoftwareSolutions.ScoreDisplay {
	public enum Stem {
		Up,
		Down
	}
	public static class MusicDrawingExtensions {
        public static void DrawNote(this INote note, Graphics g, PointF loc, Stem stem ) {
			MusicHelpers.DrawNote(note.Length.Type, g, loc, stem);
		}
		public static void DrawRest(this INote note, Graphics g, PointF loc) {
			MusicHelpers.DrawRest(note.Length.Type,g,loc);
		}
	}
	public static class MusicHelpers {
		static private readonly Pen _pen = new Pen(Brushes.Black,0.75F);

		private static PointF[][] _longRests;

		static MusicHelpers() {
			#region LongRests
			_longRests = new PointF[][] {
				new PointF[] {new PointF(-4F,-4F), new PointF( 4F,-4F),	new PointF( 4F, 8F), new PointF(-4F, 8F)},
				new PointF[] {new PointF(-4F,-4F), new PointF( 4F,-4F),	new PointF( 4F, 2F), new PointF(-4F, 2F)},
				new PointF[] {new PointF(-4F,-4F), new PointF( 4F,-4F),	new PointF( 4F,-1F), new PointF(-4F,-1F)},
				new PointF[] {new PointF(-4F,+2F), new PointF( 4F,+2F),	new PointF( 4F,-1F), new PointF(-4F,-1F)}
			};
			#endregion
		}

		public static void DrawNote(NoteType noteType, Graphics g, PointF loc, Stem stem) {
			switch(noteType) {
				case NoteType.Breve:	 DrawBreveNote(g,loc,true);				 break;
				case NoteType.SemiBreve: DrawBreveNote(g,loc,false);			 break;
				case NoteType.Minim:	 DrawMinimNote(g,loc,stem);				 break;
				default:				 DrawQuaver(g,loc,(int)noteType-2,stem); break;
			}
		}
		private static void DrawQuaver(Graphics g, PointF loc, int flags, Stem stem = Stem.Up) {
			var gs = g.Save();
			g.TranslateTransform(loc.X, loc.Y);
			if (stem == Stem.Up) {
				g.DrawLine(_pen, 7.90F, 2.00F, 7.90F,-15.00F);
			} else {
				g.DrawLine(_pen, 0.60F, 2.25F, 0.60F, 20.25F);
			}
			g.Restore(gs);

			gs = g.Save();
			g.TranslateTransform(loc.X, loc.Y);
			g.TranslateTransform(4.35F, 2.45F);
			g.RotateTransform(-25F);
			g.FillEllipse(Brushes.Black, -4.35F,-3.35F, 8.70F,5.8F);
			g.Restore(gs);

			gs = g.Save();
			g.TranslateTransform(loc.X-1.2F, loc.Y+3.0F);
			if (stem == Stem.Up) {
				g.TranslateTransform(8.7F,-18.0F);
				g.MultiplyTransform(new Matrix(0.85F,0F, 0F, 0.85F, 0F,0F));
			} else {
				g.TranslateTransform(1.3F, 18.0F);
				g.MultiplyTransform(new Matrix(0.85F,0F, 0F,-0.85F, 0F,0F));
			}
			for (int i=0; i<flags; i++) {
				MusicPaths.Get.NoteFlag.Draw(ref g, new PointF(0, -5F));
			}
			g.Restore(gs);
		}

		private static GraphicsPath BreveNoteHeadPath() {
			GraphicsPath path = new GraphicsPath();
			Matrix matrix;
			(matrix = new Matrix()).Rotate(55); 
			path.AddEllipse(-2.8F,-1.90F, 5.6F,3.80F);
			path.Transform(matrix);
			path.AddEllipse(-4.350F,-3.00F, 8.70F,6.00F);
			path.FillMode = FillMode.Alternate;
			return path;
		}
		private static GraphicsPath LongPath(int index) {
			GraphicsPath path = new GraphicsPath();
			path.AddLines (_longRests[index]);
			path.CloseFigure();
			path.FillMode = FillMode.Alternate;
			return path;
		}

		private static void DrawBreveNote(Graphics g, PointF loc, bool isBreve = false) {
			GraphicsState gs = g.Save();
			g.TranslateTransform(4.350F + loc.X, 2.00F + loc.Y);
			g.FillPath(Brushes.Black, BreveNoteHeadPath());
			if (isBreve) {
				g.DrawLine(_pen,-5.5F,-3.0F, -5.5F,3.0F);
				g.DrawLine(_pen,-4.5F,-3.0F, -4.5F,3.0F);
				g.DrawLine(_pen, 4.5F,-3.0F,  4.5F,3.0F);
				g.DrawLine(_pen, 5.5F,-3.0F,  5.5F,3.0F);
			}

			g.Restore(gs);
		}
		private static void DrawMinimNote(Graphics g, PointF loc, Stem stem = Stem.Up) {
			if (stem == Stem.Up) {
				g.DrawLine(_pen, 8.25F+loc.X, 2.00F+loc.Y, 8.25F+loc.X,-18.00F+loc.Y);
			} else {
				g.DrawLine(_pen, 0.60F+loc.X, 2.25F+loc.Y, 0.60F+loc.X, 23.25F+loc.Y);
			}
			MusicPaths.Get.MinimNote.Draw(g, loc);
		}

        public static void DrawRest(NoteType noteType, Graphics g,PointF loc) {
			switch(noteType) {
				case NoteType.Longa:
                case NoteType.Breve:			
				case NoteType.SemiBreve:
                case NoteType.Minim:
					DrawLongRest(g,loc,(int)noteType + 2);	break;
				case NoteType.Crotchet:
					MusicPaths.Get.CrotchetRest.Draw(g,loc); break;
				default:
					DrawQuaverRest(g,loc,(int)noteType-2);	break;
			}
		}

		private static void DrawQuaverRest(Graphics g, PointF loc, int flags) {
			var gs = g.Save();
			g.TranslateTransform(loc.X-1.8F, loc.Y - 2*flags - 5);
			for (int i=0; i< flags; i++) {
				MusicPaths.Get.RestFlag.Draw(ref g, new PointF(-1.2F,4.0F));
			}
			g.Restore(gs);
		}
		private static void DrawLongRest(Graphics g, PointF loc, int index) {
			var gs = g.Save();
			g.TranslateTransform(loc.X, loc.Y);
			g.TranslateTransform(2,0);
			using (var path = LongPath(index)) g.FillPath(Brushes.Black, path);
			g.Restore(gs);
		}
	}
}
