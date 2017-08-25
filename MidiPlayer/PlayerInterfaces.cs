////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using Midi;

using PGSoftwareSolutions.Qabc;

namespace PGSoftwareSolutions.Music {
    /// <summary>TODO</summary>
    [CLSCompliant(false)]
    public interface IAsyncPlayer {
        /// <summary>TODO</summary>
        void PlayAsync<TNote>(Tune<TNote> tune) where TNote : INote;

        /// <summary>TODO</summary>
        event EventHandler<NextNoteEventArgs> NextNote;
        /// <summary>TODO</summary>
        event EventHandler<PlayCompletedEventArgs> PlayCompleted;
    }

    /// <summary>Interface for a Midi player that can dynamically change instrument.</summary>
    [CLSCompliant(false)]
    public interface IInstrumentSettableMidiPlayer {
        /// <summary>Set the currently playing <see cref="Midi.Instrument"/> as specified</summary>
        void SetInstrument(IInstrument instrument);

        /// <summary>TODO</summary>
        IReadOnlyList<IInstrumentGenus> Instruments { get; }
    }

    /// <summary>Interface for an asynchronous player that can be paused and resumed.</summary>
    public interface IPausablePlayer {
        /// <summary>Pause/Resume an asynchronous player.</summary>
        void PauseResume();
        /// <summary>Return the paused status of the player.</summary>
        bool IsPaused { get; }
    }
    /// <summary>Interface for an asynchronous player that can be canceled.</summary>
    public interface ICancelablePlayer {
        /// <summary>Cancel an asynchronous player.</summary>
        void Cancel();
    }

    /// <summary>TODO</summary>
    public class NextNoteEventArgs : EventArgs {
        /// <summary>TODO</summary>
        public int Position { get; }
        /// <summary>TODO</summary>
        public int Length   { get; }

        /// <summary>Creates a new instance announcing the specifi.</summary>
        [CLSCompliant(false)]
        public NextNoteEventArgs(IAwareNote note) : base() {
            Position = note.SpanPosition;
            Length   = note.SpanLength;
        }
    }

    /// <summary>TODO</summary>
    public class PlayCompletedEventArgs : EventArgs {
        /// <summary>TODO</summary>
        public PlayCompletedEventArgs(bool success) : this(success, null) { }
        /// <summary>TODO</summary>
        public PlayCompletedEventArgs(bool success, Exception ex) {
            Success = success;
            Error = ex;
        }
        /// <summary>TODO</summary>
        public bool Success     { get; }
        /// <summary>TODO</summary>
        public Exception Error  { get; }
    }

    /// <summary>TODO</summary>
    [CLSCompliant(false)]
    public interface IInstrument {
        /// <summary>TODO</summary>
        IInstrumentGenus Genus { get; }
        /// <summary>TODO</summary>
        short Index { get; }
        /// <summary>TODO</summary>
        Instrument Instrument { get; }
        /// <summary>TODO</summary>
        string Name { get; }
    }

    /// <summary>TODO</summary>
    [CLSCompliant(false)]
    public interface IInstrumentGenus {
        /// <summary>TODO</summary>
        short Index { get; }
        /// <summary>TODO</summary>
        string Name { get; }
        /// <summary>TODO</summary>
        IReadOnlyList<IInstrument> Species { get; }
    }
}
