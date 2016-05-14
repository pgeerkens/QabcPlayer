////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
using System;
using Midi;

using PGSoftwareSolutions.Qabc;

namespace PGSoftwareSolutions.Music {
    /// <summary>TODO</summary>
    internal class HighlightMessage : Message {
        private Action<NextNoteEventArgs> _msgSink;
        private IAwareNote _note;

        /// <summary>TODO</summary>
        public HighlightMessage(Action<NextNoteEventArgs> sink, float time, IAwareNote note) : base(time) {
            _note = note;
            _msgSink = sink;
        }
        /// <summary>TODO</summary>
        public override void SendNow() => _msgSink?.Invoke(new NextNoteEventArgs(_note));

        /// <summary>TODO</summary>
        public override Message MakeTimeShiftedCopy(float delta) =>
            new HighlightMessage(_msgSink, Time + delta, _note);
    }
}
