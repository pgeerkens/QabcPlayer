#region License
////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
#endregion
using System;
using System.Collections.Generic;
using Midi;

using PGSoftwareSolutions.Qabc;

namespace PGSoftwareSolutions.Music {

    /// <summary>TODO</summary>
    [CLSCompliant(true)]
    public interface IPlayer<TNote> where TNote:INote {
        /// <summary>TODO</summary>
        void PlayAsync(Tune<INote> tune);

        /// <summary>Cancel an asynchronous player.</summary>
        void Cancel();

        /// <summary>TODO</summary>
        IPausablePlayer                 AsPausablePlayer                { get; }

        /// <summary>Set the currently playing <see cref="Instrument"/> as specified</summary>
        /// <param name="instrument"></param>
        void SetInstrument(IInstrument instrument);

        /// <summary>TODO</summary>
        event EventHandler<PlayCompletedEventArgs> PlayCompleted;
        /// <summary>TODO</summary>
        event EventHandler<NextNoteEventArgs>      NextNote;
    }

    /// <summary>Interface for an asynchronous player that can be paused and resumed.</summary>
    public interface IPausablePlayer {
        /// <summary>Pause/Resume an asynchronous player.</summary>
        void PauseResume();
        /// <summary>Return the paused status of the player.</summary>
        bool IsRunning { get; }
    }

    /// <summary>TODO</summary>
    public class NextNoteEventArgs : EventArgs {
        /// <summary>The SpanPosition of the current {IAwareNote}.</summary>
        public int Position { get { return _position; } } readonly int _position;
        /// <summary>The Spanength of the current {IAwareNote}.</summary>
        public int Length   { get { return _length;   } } readonly int _length;

        /// <summary>Creates a new instance announcing the specifi.</summary>
        [CLSCompliant(false)]
        public NextNoteEventArgs(IAwareNote note) : base() {
            _position = note.SpanPosition;
            _length   = note.SpanLength;
        }
    }

    /// <summary>TODO</summary>
    public class PlayCompletedEventArgs : EventArgs {
        /// <summary>TODO</summary>
        public PlayCompletedEventArgs(bool success) : this(success, null) { }
        /// <summary>TODO</summary>
        public PlayCompletedEventArgs(bool success, Exception ex) {
            Success = success;
            Error   = ex;
        }
        /// <summary>TODO</summary>
        public bool      Success { get; }
        /// <summary>TODO</summary>
        public Exception Error   { get; }
    }

    /// <summary>TODO</summary>
    [CLSCompliant(true)]
    public interface IInstrument {
        /// <summary>The Genus of this instrument.</summary>
        IInstrumentGenus Genus      { get; }
        /// <summary>The index in its Genus for this instrument.</summary>
        short            Index      { get; }
        #pragma warning disable CS3003 // Type is not CLS-compliant
        /// <summary>The {Midi.Instrument} details for this instrument.</summary>
        Instrument Instrument { get; }
        #pragma warning restore CS3003 // Type is not CLS-compliant
                              /// <summary>The name of this instrument.</summary>
        string           Name       { get; }
    }

    /// <summary>TODO</summary>
    [CLSCompliant(true)]
    public interface IInstrumentGenus {
        /// <summary>The index in the MIDI Genus List for this Instrument Genus.</summary>
        short                      Index   { get; }
        /// <summary>The name of this Instrument Genus.</summary>
        string                     Name    { get; }
        /// <summary>The list of specific {IInstrument}'s in thie Instrument Genus.</summary>
        IReadOnlyList<IInstrument> Species { get; }
    }
}
