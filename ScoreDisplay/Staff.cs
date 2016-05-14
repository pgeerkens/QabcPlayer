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
	public class Staff {
		public static void DrawMe(Graphics g, PointF loc, SizeF size) {
			using (Pen pen = new Pen(Brushes.Black,0.5F)) {
				for (int i=0; i<5; i++) 
					g.DrawLine(pen,  loc.X, loc.Y + 6*i,	loc.X+size.Width, loc.Y + 6*i);
			}
		}
	}
}
