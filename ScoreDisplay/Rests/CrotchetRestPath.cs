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
	class CrotchetRestPath : MusicPath {
		public CrotchetRestPath() {
			Beziers = new PointF[][] {
				new PointF[] {
					new PointF(181.69F,588.76F), 
					new PointF(182.47F,589.08F), new PointF(182.37F,590.46F), new PointF(181.42F,589.80F),
					new PointF(180.70F,588.91F), new PointF(179.33F,588.14F), new PointF(178.34F,589.11F),
					new PointF(177.51F,589.87F), new PointF(177.78F,591.27F), new PointF(178.71F,591.81F),
					new PointF(179.37F,591.94F), new PointF(179.86F,593.05F), new PointF(178.79F,592.64F),
					new PointF(177.25F,592.11F), new PointF(175.60F,590.79F), new PointF(175.72F,588.99F),
					new PointF(175.70F,587.77F), new PointF(176.95F,587.02F), new PointF(178.07F,587.10F),
					new PointF(178.52F,586.94F), new PointF(179.75F,587.58F), new PointF(179.70F,587.30F),
					new PointF(178.94F,586.14F), new PointF(178.08F,585.05F), new PointF(177.41F,583.84F),
					new PointF(177.17F,583.12F), new PointF(177.69F,582.42F), new PointF(177.91F,581.75F),
					new PointF(178.39F,580.55F), new PointF(178.93F,579.37F), new PointF(179.37F,578.16F),
					new PointF(179.41F,577.41F), new PointF(178.75F,576.88F), new PointF(178.40F,576.27F),
					new PointF(178.01F,575.64F), new PointF(177.49F,575.07F), new PointF(177.20F,574.38F),
					new PointF(177.22F,573.50F), new PointF(178.13F,574.48F), new PointF(178.37F,574.84F),
					new PointF(179.45F,576.11F), new PointF(180.57F,577.34F), new PointF(181.61F,578.65F),
					new PointF(182.30F,579.49F), new PointF(181.66F,580.48F), new PointF(181.32F,581.32F),
					new PointF(180.82F,582.58F), new PointF(180.19F,583.79F), new PointF(179.82F,585.09F),
					new PointF(179.77F,586.16F), new PointF(180.56F,587.05F), new PointF(181.06F,587.94F),
					new PointF(181.25F,588.22F), new PointF(181.47F,588.50F), new PointF(181.69F,588.76F) }
			};
			for (int i=0; i<Beziers.Count(); i++) {
				for (int j=0; j<Beziers[i].Count(); j++) {
					Beziers[i][j].X += -178.72F + 5F; 	
					Beziers[i][j].Y += -582.00F;
				}
			}
			Lines = new PointF[][] { new PointF[] {} };
		}
	}
}
