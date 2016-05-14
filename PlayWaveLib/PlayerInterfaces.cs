////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
using System;
using Midi;

using PGSoftwareSolutions.Qabc;
using PGSoftwareSolutions.Music;

namespace PGSoftwareSolutions.Util.PlayWaveLib {
    using System.Collections.Generic;
    using NextNoteEvent = EventHandler<NextNoteEventArgs>;
    using PlayCompletedEvent = EventHandler<PlayCompletedEventArgs>;

    /// <summary>TODO</summary>
    [CLSCompliant(false)]
    public interface IAsyncPlayer {
        /// <summary>TODO</summary>
        void PlayAsync<TNote>(Tune<TNote> tune) where TNote : INote;

        /// <summary>TODO</summary>
        event PlayCompletedEvent PlayCompleted;
        /// <summary>TODO</summary>
        event NextNoteEvent NextNote;
    }

    /// <summary>Interface for a Midi player that can dynamically change instrument.</summary>
    [CLSCompliant(false)]
    public interface IInstrumentSettableMidiPlayer {
        /// <summary>Set the currently playing <see cref="Midi.Instrument"/> as specified</summary>
        void SetInstrument(IInstrument instrument);

        /// <summary>TODO</summary>
        IList<IInstrumentGenus> Instruments { get; }
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
        public int Position { get { return _position; } } readonly int _position;
        /// <summary>TODO</summary>
        public int Length   { get { return _length;   } } readonly int _length;

        /// <summary>Creates a new instance announcing the specifi.</summary>
        [CLSCompliant(false)]
        public NextNoteEventArgs(IAwareNote note) : base() {
            _position = note.SpanPosition;
            _length = note.SpanPosition;
        }
    }

    /// <summary>TODO</summary>
    [CLSCompliant(false)]
    public interface IInstrument {
        /// <summary>TODO</summary>
        IInstrumentGenus Genus      { get; }
        /// <summary>TODO</summary>
        short            Index      { get; }
        /// <summary>TODO</summary>
        Instrument       Instrument { get; }
        /// <summary>TODO</summary>
        string           Name       { get; }
    }

    /// <summary>TODO</summary>
    [CLSCompliant(false)]
    public interface IInstrumentGenus {
        /// <summary>TODO</summary>
        short              Index   { get; }
        /// <summary>TODO</summary>
        string             Name    { get; }
        /// <summary>TODO</summary>
        IList<IInstrument> Species { get; }
    }

    public class PlayCompletedEventArgs : EventArgs {
        public PlayCompletedEventArgs(bool success) : this(success, null) { }
        public PlayCompletedEventArgs(bool success, Exception ex) {
            Success = success;
            Error = ex;
        }
        public bool Success { get; private set; }
        public Exception Error { get; private set; }
    }
}
