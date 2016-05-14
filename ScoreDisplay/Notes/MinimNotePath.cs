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
	class MinimNotePath : MusicPath {
		public MinimNotePath() {
			Beziers = new PointF[][] {
				new PointF[] {
					new PointF(183.32F,537.99F), 
					new PointF(183.25F,538.79F), new PointF(182.64F,539.39F), new PointF(182.13F,539.95F),
					new PointF(180.97F,541.06F), new PointF(179.56F,541.94F), new PointF(178.01F,542.32F),
					new PointF(177.55F,542.40F), new PointF(176.80F,542.47F), new PointF(176.67F,541.87F),
					new PointF(176.54F,541.23F), new PointF(177.02F,540.67F), new PointF(177.38F,540.20F),
					new PointF(178.32F,539.11F), new PointF(179.54F,538.29F), new PointF(180.84F,537.71F),
					new PointF(181.52F,537.46F), new PointF(182.30F,537.13F), new PointF(183.01F,537.44F),
					new PointF(183.20F,537.55F), new PointF(183.34F,537.76F), new PointF(183.32F,537.99F) },
				new PointF[] {
					new PointF(181.39F,536.34F), 
					new PointF(179.63F,536.36F), new PointF(177.96F,537.33F), new PointF(176.88F,538.70F),
					new PointF(176.15F,539.64F), new PointF(175.67F,541.00F), new PointF(176.26F,542.13F),
					new PointF(176.70F,543.03F), new PointF(177.76F,543.39F), new PointF(178.70F,543.34F),
					new PointF(180.33F,543.30F), new PointF(181.83F,542.40F), new PointF(182.91F,541.21F),
					new PointF(183.71F,540.30F), new PointF(184.29F,538.98F), new PointF(183.83F,537.77F),
					new PointF(183.50F,536.89F), new PointF(182.58F,536.37F), new PointF(181.68F,536.35F),
					new PointF(181.58F,536.35F), new PointF(181.48F,536.34F), new PointF(181.39F,536.34F) }
			};
			for (int i=0; i<Beziers.Count(); i++) {
				for (int j=0; j< Beziers[i].Count(); j++) {
					Beziers[i][j].X += -180.25F +5F; 
					Beziers[i][j].Y += -538.5F; 
				}
			}
			Lines = new PointF[][] { new PointF[] {} };
		}
	}
}
