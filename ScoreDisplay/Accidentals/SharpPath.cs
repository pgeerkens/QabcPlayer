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
	public class SharpPath : MusicPath {
		public SharpPath() {
			Beziers = new PointF[0][]; 
			Lines = new PointF[2][];
			Lines[0] = new PointF[] {
				new PointF(86.10F,447.45F), new PointF(86.10F,442.75F),	new PointF(88.10F,442.20F),
				new PointF(88.10F,446.88F), new PointF(86.10F,447.45F)
			};
			Lines[1] = new PointF[] {
				new PointF(90.04F,446.31F),	new PointF(88.66F,446.71F),	new PointF(88.66F,442.03F),
				new PointF(90.04F,441.64F),	new PointF(90.04F,439.70F),	new PointF(88.66F,440.08F),
				new PointF(88.66F,435.30F),	new PointF(88.10F,435.30F),	new PointF(88.10F,440.23F),
				new PointF(86.10F,440.80F),	new PointF(86.10F,436.15F),	new PointF(85.57F,436.15F),
				new PointF(85.57F,440.98F),	new PointF(84.19F,441.37F),	new PointF(84.19F,443.31F),
				new PointF(85.57F,442.93F),	new PointF(85.57F,447.60F),	new PointF(84.19F,447.98F),
				new PointF(84.19F,449.92F),	new PointF(85.57F,449.54F),	new PointF(85.57F,454.29F),
				new PointF(86.10F,454.29F),	new PointF(86.10F,449.37F),	new PointF(88.10F,448.82F),
				new PointF(88.10F,453.45F),	new PointF(88.66F,453.45F),	new PointF(88.66F,448.65F),
				new PointF(90.04F,448.26F),	new PointF(90.04F,446.31F)
			};
			for (int i=0; i < Lines.Count(); i++) {
				for (int j=0; j<Lines[i].Count(); j++) {
					Lines[i][j].X +=  -84.19F;
					Lines[i][j].Y += -436.06F - 7F;
				}
			}
		}
	}
}
