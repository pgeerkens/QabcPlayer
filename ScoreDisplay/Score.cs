#region License
////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
#endregion
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PGSoftwareSolutions.ScoreDisplay {
	public class Score : List<IScoreLine>, IScore {
		public Score(int width) : base() { Width = width; }
		public int Width { get; private set; }
		public static Score operator + (Score lhs, IScoreLine rhs) { lhs.Add(rhs); return lhs; }
	}

	public class ScoreLine		: List<IScoreNotePosition>, IScoreLine {
		public int		Index			{ get; private set; }
		public Matrix	Matrix			{ get; private set; }
		public int		MinNoteNo		{ get; private set; }
		public int		MaxNoteNo		{ get; set; }
		public int		MaxNotePosition	{ get; set; }
		public ScoreLine(int index, Matrix	matrix, int minNoteNo) {
			Index = index; Matrix = matrix; MinNoteNo = minNoteNo;
		}
		public static ScoreLine operator + (ScoreLine lhs, IScoreNotePosition rhs)  { 
			lhs.Add(rhs); return lhs; 
		}
	}
	public class ScoreNotePosition : IScoreNotePosition {
		public int X			{ get; private set; }	// location on stave
		public int Y			{ get; private set; }	// location on stave
		public int Width		{ get; private set; }	// width on stave
		public int Position	    { get; private set; }	// location in text source
		public int Length		{ get; private set; }	// length in text source
		public int NoteNo		{ get; private set; }	// index into _tune
		public ScoreNotePosition(int x, int y, int width, int position, int length, int noteNo) { 
			X=x; Y=y; Width = width; Position = position; Length = length; NoteNo = noteNo;
		}
	}
}
