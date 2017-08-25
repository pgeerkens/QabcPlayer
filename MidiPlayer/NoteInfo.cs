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
		public Midi.Pitch Pitch    { get; }
        /// <summary>TODO</summary>
		public int        Velocity { get; }
        /// <summary>TODO</summary>
		public float      Duration { get; }
        /// <summary>TODO</summary>
		public float      Length   { get; }

        /// <summary>TODO</summary>
        /// <param name="note"></param>
		public NoteInfo(INote note) : this(note,120) {}
        /// <summary>TODO</summary>
        /// <param name="note">The <see cref="INote"/> descrioption for this note.</param>
        /// <param name="tempo">whole-notes / minute</param>
		public NoteInfo(INote note, float tempo) {
			var beatTime = 60.0F * 4.0F / tempo;
			Pitch        = (Midi.Pitch)(note.PianoKey + 20);
			Velocity     = (int)Math.Pow(10, note.Energy/10) * 80;
			Duration     = (float)(note.Duration      * beatTime);
			Length       = (float)(note.LengthSeconds * beatTime * 0.95);

            var lengthFactor = note.Style;
		}
	}
}
