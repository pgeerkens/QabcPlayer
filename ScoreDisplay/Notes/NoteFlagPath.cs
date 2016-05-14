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
	public class NoteFlagPath : MusicPath {
		public NoteFlagPath() {
			Beziers = new PointF[][] {
				new PointF[] {
					new PointF(355.64087F,534.50670F), new PointF(356.05925F,536.43346F),
					new PointF(357.79685F,537.93980F), new PointF(359.09566F,539.29772F),
					new PointF(360.00232F,540.26777F), new PointF(361.07070F,541.12502F),
					new PointF(361.68096F,542.33020F), new PointF(362.22847F,543.32497F),
					new PointF(362.53043F,544.45397F), new PointF(362.52561F,545.59100F),
					new PointF(362.55523F,547.70041F), new PointF(361.59345F,549.72003F),
					new PointF(360.14610F,551.22017F), new PointF(359.85055F,551.58759F), 
					new PointF(359.04629F,552.27401F), new PointF(358.90096F,552.17196F), 
					new PointF(358.71377F,552.04052F), new PointF(359.37760F,551.43876F),
					new PointF(359.71032F,551.11874F), new PointF(361.17865F,549.59402F),
					new PointF(362.04044F,547.42643F), new PointF(361.74674F,545.30372F),
					new PointF(361.36799F,543.36784F), new PointF(359.78964F,541.96920F),
					new PointF(358.24068F,540.89646F), new PointF(357.26129F,540.22519F),
					new PointF(356.21650F,539.64737F), new PointF(355.11860F,539.19400F) }
			};
			for (int i=0; i<Beziers.Count(); i++) {
				for (int j=0; j<Beziers[i].Count(); j++) {
					Beziers[i][j].X += -355.1186F;
					Beziers[i][j].Y += -534.5257F + 5F;
				}
			}
			Lines = new PointF[][] {
				new PointF[] {
					new PointF(355.11860F,533.90500F),
					new PointF(355.61860F,533.90500F) }
			};
			for (int i=0; i<Lines.Count(); i++) {
				for (int j=0; j<Lines[i].Count(); j++) {
					Lines[i][j].X += -355.1186F;
					Lines[i][j].Y += -534.5257F + 5F;
				}
			}
		}
	}
}
