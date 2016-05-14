////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
using System;

namespace PGSoftwareSolutions.Music {
    /// <summary>TODO</summary>
    internal struct	NoteInfo {
        /// <summary>TODO</summary>
		public Midi.Pitch Pitch    { get { return _pitch;    } } readonly Midi.Pitch _pitch;
        /// <summary>TODO</summary>
		public int        Velocity { get { return _velocity; } } readonly int	     _velocity;
        /// <summary>TODO</summary>
		public float      Duration { get { return _duration; } } readonly float	     _duration;
        /// <summary>TODO</summary>
		public float      Length   { get { return _length;   } } readonly float	     _length;

        /// <summary>TODO</summary>
        /// <param name="note"></param>
		public NoteInfo(INote note) : this(note,120) {}
        /// <summary>TODO</summary>
        /// <param name="note"></param>
        /// <param name="tempo">whole-notes / second</param>
		public NoteInfo(INote note, int tempo) {
			var beatTime = 60.0F * 4.0F / tempo;
			_pitch       = (Midi.Pitch)(note.PianoKey + 20);
			_velocity    = (int)Math.Pow(10, note.Energy/10) * 80;
			_duration    = (float)(note.Duration      * beatTime);
			_length      = (float)(note.LengthSeconds * beatTime * 0.95);

            var lengthFactor = note.Style;
		}
	}
}
