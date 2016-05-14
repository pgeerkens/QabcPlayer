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
	public class RestFlagPath : MusicPath {
		public RestFlagPath() {
			Lines			= new PointF[0][];
			Beziers		= new PointF[1][];
			Beziers[0]	= new PointF[] {
				new PointF(192.60F,579.98F),
				new PointF(191.53F,583.48F), new PointF(190.45F,586.98F), new PointF(189.38F,590.48F),
				new PointF(189.17F,590.48F), new PointF(188.97F,590.48F), new PointF(188.76F,590.49F),
				new PointF(189.58F,587.76F), new PointF(190.41F,585.02F), new PointF(191.24F,582.29F),
				new PointF(190.29F,583.17F), new PointF(188.92F,583.40F), new PointF(187.67F,583.30F),
				new PointF(186.75F,583.21F), new PointF(185.86F,582.45F), new PointF(185.86F,581.48F),
				new PointF(185.76F,580.59F), new PointF(186.52F,579.69F), new PointF(187.43F,579.73F),
				new PointF(188.41F,579.70F), new PointF(189.26F,580.73F), new PointF(188.96F,581.68F),
				new PointF(188.92F,582.14F), new PointF(188.48F,582.37F), new PointF(188.28F,582.68F),
				new PointF(188.62F,582.89F), new PointF(189.07F,582.68F), new PointF(189.44F,582.61F),
				new PointF(190.40F,582.31F), new PointF(191.32F,581.66F), new PointF(191.72F,580.71F),
				new PointF(191.79F,580.47F), new PointF(191.87F,580.23F), new PointF(191.95F,579.99F),
				new PointF(192.17F,579.99F), new PointF(192.38F,579.98F), new PointF(192.60F,579.98F)
			};
			for (int i=0; i<Beziers.Count(); i++) {
				for (int j=0; j<Beziers[i].Count(); j++) {
					Beziers[i][j].X += -185.85F + 5F; 	
					Beziers[i][j].Y += -583.00F + 3F;
				}
			}
		}
	}
}
