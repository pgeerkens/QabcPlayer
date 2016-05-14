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
	public static class Clef {
		private static PathDefinition[] apTrebleClef;
		private static PathDefinition[] apBassClef;
		private static PathDefinition[] apAltoClef;
		static Clef() {
			#region apTrebleClef
			apTrebleClef = new PathDefinition[] {
				new PathDefinition(CurveType.Bezier,
					new float[] {
						12.04F, 3.5F,	12.35F, 6.65F, 10.02F, 9.18F,
						 7.97F,11.23F,	 7.03F,12.12F,	 7.81F,11.37F,
						 7.32F,11.8F,	 7.22F,11.345F, 7.02F,10.09F,
						 7.04F, 9.71F,	 7.17F, 7.02F,	 9.36F, 3.12F,
						11.28F, 1.6F,	11.59F, 2.26F, 11.84F, 2.31F,
						12.04F, 3.53F
					}),
				new PathDefinition(CurveType.Bezier,
					new float[] {
						12.70F,19.63F,	11.46F, 18.7F,  9.85F,18.52F,
						 8.36F,18.78F,	 8.17F,17.53F,  7.98F,16.27F,
						 7.79F,15.02F,	10.14F,12.6F,  12.69F, 9.99F,
						12.83F, 6.4F,	12.89F, 4.2F,	12.55F, 1.81F,
						11.15F, 0.00F,  9.45F, 0.12F,  8.25F, 2.15F,
						7.35F,  3.4F,	 5.86F, 6.08F,	 6.21F, 9.33F,
						 6.78F,12.21F,	 5.97F,13.16F,  4.85F,13.95F,
						 4.05F,14.94F,	 1.69F,17.25F,	-0.35F,20.37F,
						 0.05F,23.82F,	 0.23F,27.15F,  2.64F,30.25F,
						 5.92F,31.05F,	 7.16F,31.36F,	 8.48F,31.39F,
						 9.74F,31.15F,	 9.96F,33.40F, 10.77F,35.78F,
						 9.83F,37.96F,	 9.13F,39.56F,	 7.05F,40.96F,
						 5.50F,40.15F,	 4.90F,39.84F,  5.39F,40.10F,
						 5.02F,39.90F,	 6.09F,39.64F,	 7.02F,38.86F,
						 7.28F,38.33F,	 8.12F,36.87F,  6.88F,34.70F,
						 5.13F,34.98F,	 2.87F,35.02F,	 1.94F,38.12F,
						 3.39F,39.66F,	 4.74F,41.18F,  7.22F,40.97F,
						 8.82F,39.98F,	10.63F,38.80F,	10.86F,36.44F,
						10.65F, 34.4F,	10.58F,33.74F, 10.25F,31.75F,
						10.21F, 31.0F,	10.91F,30.78F,	10.42F,30.97F,
						11.40F, 30.5F,	14.06F,29.53F, 15.76F,26.32F,
						15.00F, 23.4F,	14.68F,21.99F,	13.95F,20.54F,
						12.70F, 19.6F
					}),
				new PathDefinition(CurveType.Bezier,
					new float[] {
						13.26F,25.42F,	13.47F,27.42F,	12.20F,29.75F,
						10.18F,30.38F,	10.04F,29.59F,	10.01F,29.37F,
						 9.91F,28.91F,	 9.43F,26.45F,	 9.17F,23.92F,
						 8.80F,21.43F,	10.42F,21.26F,	12.26F,21.97F,
						12.82F,23.61F,	13.07F,24.19F,	13.16F,24.81F,
						13.26F,25.42F
					}),
				new PathDefinition(CurveType.Bezier,
					new float [] {
						 8.11F,30.62F,	 5.56F,30.76F,	 3.11F,29.02F,
						 2.47F,26.54F,	 1.72F,24.39F,	 1.94F,21.91F,
						 3.29F,20.03F,	 4.41F,18.33F,	 5.90F,16.93F,
						 7.32F,15.49F,	 7.51F,16.62F,	 7.69F,17.75F,
						 7.87F,18.87F,	 4.88F,19.66F,	 2.87F,23.60F,
						 4.66F,26.32F,	 5.19F,27.09F,	 6.63F,28.55F,
						 7.42F,27.96F,	 6.32F,27.28F,	 5.42F,26.10F,
						 5.61F,24.73F,	 5.53F,23.45F,	 6.98F,21.82F,
						 8.26F,21.53F,	 8.70F,24.40F,	 9.20F,27.61F,
						 9.64F,30.48F,	 9.14F,30.58F,	 8.62F,30.62F,
						 8.11F,30.62F
					})
			};
			for (int i=0; i<apTrebleClef.Count(); i++) {
				for (int j=0; j< apTrebleClef[i].Points.Count(); j+=2) {
					apTrebleClef[i].Points[j+0] += 5F; 
					apTrebleClef[i].Points[j+1] +=-7F; 
				}
			}
			#endregion
			#region apBassClef
			apBassClef = new PathDefinition[] {
				new PathDefinition( CurveType.Bezier,
					new float[] { 
						248.25F,536.80200F, 
						248.26F,537.17F, 248.11F,537.54F, 247.82F,537.78F,
						247.46F,538.11F, 246.91F,538.17F, 246.47F,538.01F,
						246.02F,537.83F, 245.69F,537.39F, 245.67F,536.92F,
						245.63F,536.54F, 245.75F,536.15F, 246.02F,535.88F,
						246.28F,535.61F, 246.66F,535.48F, 247.03F,535.50F,
						247.41F,535.51F, 247.77F,535.70F, 248.00F,536.01F, 
						248.17F,536.23F, 248.26F,536.51F, 248.25F,536.80F
					}),
				new PathDefinition( CurveType.Bezier,
					new float[] { 
						248.25F,542.64F, 
						248.26F,543.01F, 248.11F,543.38F, 247.82F,543.62F,
						247.46F,543.95F, 246.91F,544.02F, 246.47F,543.85F,
						246.02F,543.68F, 245.69F,543.24F, 245.67F,542.76F,
						245.63F,542.38F, 245.76F,542.00F, 246.02F,541.73F,
						246.27F,541.45F, 246.66F,541.32F, 247.02F,541.34F,
						247.51F,541.36F, 247.95F,541.69F, 248.15F,542.12F,
						248.22F,542.28F, 248.26F,542.46F, 248.25F,542.64F
					}),
				new PathDefinition( CurveType.Bezier,
					new float[] { 
						243.97F,540.86F, 
						244.02F,543.69F, 242.76F,546.43F, 240.76F,548.40F,
						238.27F,550.89F, 235.01F,552.47F, 231.69F,553.53F,
						231.25F,553.77F, 230.58F,553.45F, 231.28F,553.13F,
						232.62F,552.52F, 234.01F,552.00F, 235.24F,551.18F,
						237.96F,549.49F, 240.26F,546.84F, 240.82F,543.61F,
						241.14F,541.65F, 241.05F,539.60F, 240.56F,537.67F,
						240.20F,536.25F, 239.22F,534.79F, 237.66F,534.58F,
						236.25F,534.36F, 234.74F,534.85F, 233.74F,535.88F,
						233.47F,536.14F, 232.95F,536.89F, 233.04F,537.74F,
						233.64F,537.27F, 233.60F,537.32F, 234.09F,537.10F,
						235.23F,536.60F, 236.74F,537.32F, 237.02F,538.57F,
						237.32F,539.72F, 237.09F,541.18F, 235.96F,541.79F,
						234.77F,542.44F, 233.02F,542.17F, 232.36F,540.90F,
						231.26F,538.95F, 231.87F,536.28F, 233.64F,534.92F,
						235.44F,533.42F, 238.07F,533.37F, 240.19F,534.13F,
						242.38F,534.95F, 243.68F,537.21F, 243.89F,539.45F,
						243.95F,539.92F, 243.97F,540.39F, 243.97F,540.86F
					})
			};
			for (int i=0; i<apBassClef.Count(); i++) {
				for (int j=0; j< apBassClef[i].Points.Count(); j+=2) {
					apBassClef[i].Points[j+0] += -230.95F +5F; 
					apBassClef[i].Points[j+1] += -533.65F; 
				}
			}
			#endregion
			#region AltoClef
			apAltoClef = new PathDefinition[] {
				new PathDefinition(
					CurveType.Line,
					new float[] {
					312.20F,551.91F,	309.36F,551.91F,	309.36F,527.66F,
					312.20F,527.66F, 	312.20F,551.91F
				} ),
				new PathDefinition(
					CurveType.Line,
					new float[]{
					314.95F,551.91F,	314.08F,551.91F,	314.08F,527.66F,
					314.95F,527.66F,	314.95F,539.38F,	314.95F,551.91F
				} ),
				new PathDefinition(
					CurveType.Bezier,
					new float[]{
					314.45F,539.80F,
					316.35F,538.08F, 317.58F,536.43F, 317.84F,534.50F,
					318.34F,535.94F, 319.32F,537.53F, 320.97F,537.75F,
					322.18F,537.82F, 322.52F,536.34F, 322.76F,535.42F,
					323.08F,533.68F, 323.12F,531.83F, 322.56F,530.14F,
					322.17F,528.95F, 320.88F,527.97F, 319.60F,528.29F,
					318.57F,529.04F, 320.60F,529.59F, 320.26F,530.56F,
					320.48F,531.95F, 318.76F,533.04F, 317.57F,532.31F,
					316.28F,531.61F, 316.38F,529.72F, 317.37F,528.80F,
					318.04F,528.10F, 319.33F,527.65F, 320.27F,527.66F,
					321.22F,527.67F, 321.78F,527.74F, 322.64F,528.04F,
					324.56F,528.72F, 325.72F,530.70F, 325.88F,532.67F,
					326.17F,534.90F, 324.92F,537.33F, 322.82F,538.21F,
					321.45F,538.74F, 319.87F,538.29F, 318.82F,537.31F,
					318.65F,538.29F, 318.22F,539.22F, 317.68F,539.90F,
					318.11F,540.61F, 318.58F,541.75F, 318.82F,542.14F,
					320.14F,540.94F, 322.46F,540.80F, 323.82F,541.98F,
					325.22F,543.13F, 326.08F,544.95F, 325.90F,546.76F,
					325.77F,548.73F, 324.67F,550.74F, 322.76F,551.48F,
					321.12F,552.08F, 319.06F,552.18F, 317.63F,551.02F,
					316.57F,550.23F, 316.16F,548.44F, 317.27F,547.51F,
					318.34F,546.51F, 320.39F,547.42F, 320.26F,548.90F,
					320.68F,549.92F, 318.52F,550.54F, 319.66F,551.26F,
					320.96F,551.60F, 322.30F,550.53F, 322.63F,549.29F,
					323.12F,547.50F, 323.10F,545.58F, 322.67F,543.79F,
					322.44F,542.90F, 321.89F,541.53F, 320.73F,541.89F,
					319.20F,542.24F, 318.34F,543.75F, 317.86F,545.13F,
					317.58F,543.18F, 316.36F,541.50F, 314.45F,539.80F
				} )
			};
			for (int i=0; i<apAltoClef.Count(); i++) {
				for (int j=0; j< apAltoClef[i].Points.Count(); j+=2) {
					apAltoClef[i].Points[j+0] += -309.36F + 5F; 
					apAltoClef[i].Points[j+1] += -543.94F + 0.15F; 
				}
			}
			#endregion AltoClef
		}

		public static void DrawTreble(Graphics g, PointF loc) { DrawMe(g,loc,apTrebleClef); }
		public static void DrawBass(Graphics g, PointF loc)	{ DrawMe(g,loc,apBassClef); }
		public static void DrawAlto(Graphics g, PointF loc)	{ DrawMe(g,loc,apAltoClef); }

		private static void DrawMe(Graphics g, PointF loc, PathDefinition[] pathDef) {
			using (GraphicsPath path = new GraphicsPath()) {
				path.AddPolys(pathDef);
				path.FillMode = FillMode.Alternate;

				GraphicsState gs = g.Save();
				g.TranslateTransform(loc.X, loc.Y);
				g.FillPath(Brushes.Black, path);
				g.Restore(gs);
			}
		}
	}
	public  enum CurveType {
		Line,
		Bezier
	}
	public struct PathDefinition {
		public CurveType CurveType;
		public float[]	Points;

		public PathDefinition(CurveType curveType, float[] points) {
			CurveType	= curveType;
			Points		= points;
		}
	}
	public static class PathExtensions {
		public static void AddPolyBezier(this GraphicsPath path, float[] coords, bool close = true) {
			if (coords.Count() % 6 != 2  ||  coords.Count() < 8) 
				throw new ArgumentException("Incorrect number of elements for parameter array.", "coords");

			int j = 0;
			path.StartFigure();
			while (j+2 < coords.Count()) {
				path.AddBezier(coords[j+0], coords[j+1], coords[j+2], coords[j+3],
									coords[j+4], coords[j+5], coords[j+6], coords[j+7]);
				j += 6;
			}
			if (close)
				path.CloseFigure();
		}
		public static void AddPolyLine(this GraphicsPath path, float[] coords, bool close = true) {
			if (coords.Count() % 2 != 0  ||  coords.Count() < 4) 
				throw new ArgumentException("Incorrect number of elements for parameter array.", "coords");

			int j = 0;
			path.StartFigure();
			while (j+2 < coords.Count()) {
				path.AddLine(coords[j+0], coords[j+1], coords[j+2], coords[j+3]);
				j += 2;
			}
			if (close)
				path.CloseFigure();
		}
		public static void AddPolys(this GraphicsPath path, PathDefinition[] pathDefinition) {
			foreach(PathDefinition curve in pathDefinition) {
				switch (curve.CurveType) {
					case CurveType.Bezier:	path.AddPolyBezier(curve.Points);	break;
					case CurveType.Line:		path.AddPolyLine(curve.Points);		break;
					default:						throw new ArgumentOutOfRangeException(
						"CurveTYpe",curve.CurveType,"Invalid path construct encountered.");
				}
			}
		}
	}
}
