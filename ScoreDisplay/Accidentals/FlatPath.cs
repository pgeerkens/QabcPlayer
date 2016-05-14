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
	public class FlatPath : MusicPath {
		public FlatPath() {
			Beziers = new PointF[2][];
			Beziers[0] = new PointF[] {
				new PointF(95.51F,443.84F),
				new PointF(95.66F,443.44F), new PointF(95.90F,443.12F), new PointF(96.21F,442.87F),
				new PointF(96.51F,442.63F), new PointF(96.83F,442.50F), new PointF(97.14F,442.50F),
				new PointF(97.66F,442.50F), new PointF(97.99F,442.80F), new PointF(98.14F,443.39F),
				new PointF(98.15F,443.44F), new PointF(98.16F,443.52F), new PointF(98.16F,443.65F),
				new PointF(98.16F,444.23F), new PointF(97.95F,444.78F), new PointF(97.35F,445.52F),
				new PointF(96.73F,446.30F), new PointF(96.20F,446.75F), new PointF(95.51F,447.28F)
			};
			Beziers[1] = new PointF[] {
				new PointF(94.94F,447.75F), 
				new PointF(94.94F,448.10F), new PointF(95.04F,448.28F), new PointF(95.23F,448.28F),
				new PointF(95.34F,448.28F), new PointF(95.48F,448.18F), new PointF(95.69F,448.06F),
				new PointF(96.27F,447.71F), new PointF(96.63F,447.48F), new PointF(97.03F,447.23F),
				new PointF(97.48F,446.95F), new PointF(97.99F,446.63F), new PointF(98.66F,445.99F),
				new PointF(99.12F,445.52F), new PointF(99.45F,445.05F), new PointF(99.66F,444.58F),
				new PointF(99.87F,444.11F), new PointF(99.97F,443.64F), new PointF(99.97F,443.17F),
				new PointF(99.97F,442.49F), new PointF(99.79F,442.00F), new PointF(99.42F,441.71F),
				new PointF(99.01F,441.40F), new PointF(98.56F,441.25F), new PointF(98.09F,441.25F),
				new PointF(97.66F,441.25F), new PointF(97.22F,441.37F), new PointF(96.77F,441.61F),
				new PointF(96.33F,441.85F), new PointF(95.90F,442.17F), new PointF(95.51F,442.56F)//,
			};
			for (int i=0; i < Beziers.Count(); i++) {
				for (int j=0; j<Beziers[i].Count(); j++) {
					Beziers[i][j].X += -94.94F;
					Beziers[i][j].Y += -433.75F - 9F;
				}
			}
			Lines = new PointF[1][];
			Lines[0] = new PointF[] {
				new PointF(95.51F,442.56F),
				new PointF(95.51F,435.29F), 
				new PointF(94.94F,435.29F), 
				new PointF(94.94F,447.75F)
			};
			for (int i=0; i < Lines.Count(); i++) {
				for (int j=0; j<Lines[i].Count(); j++) {
					Lines[i][j].X += -94.947F;
					Lines[i][j].Y += -433.75F - 9F;
				}
			}
		}
	}
}
