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

namespace PGSoftwareSolutions.ScoreDisplay {
	public abstract class MusicPath : IMusicPath, IDisposable {
		/// <summary>Draws <c>Path</c> and preserves current location.</summary>
		/// <param name="g"></param>
		/// <param name="loc"></param>
		public void Draw(Graphics g, PointF loc) {
			Draw(ref g, loc);
			g.TranslateTransform(-loc.X, -loc.Y);
		}
		/// <summary>Draws <c>Path</c> and advances current location by <c>loc</c>.</summary>
		/// <param name="g"></param>
		/// <param name="loc"></param>
		public void Draw(ref Graphics g, PointF loc) {
			g.TranslateTransform(loc.X, loc.Y);
			g.FillPath(Brushes.Black, Path); 
		}
		public GraphicsPath Path { 
			get { 
				if (_path == null) {
					_path = new GraphicsPath();
					for (int i=0; i < Beziers.Count(); i++) {
						if (Beziers[i].Count() > 0) _path.AddBeziers(Beziers[i]);
					}
					for (int i=0; i < Lines.Count(); i++) {
						if (Lines[i].Count() > 0) _path.AddLines(Lines[i]);
					}
					_path.FillMode = FillMode.Alternate;
					Path.CloseAllFigures();
				}
				return (GraphicsPath)_path;
			}
		} GraphicsPath _path;
		protected PointF[][] Beziers	{ get; set; }
		protected PointF[][] Lines	{ get; set; }

		#region IDispose implementation
		private bool _disposed = false;
		public void Dispose() { Dispose(false); }
		protected void Dispose(bool disposing){
			if (!_disposed) {
				if (disposing) {
					_path.Dispose(); _path = null;
				}
			}
		}
		#endregion
	}
}
