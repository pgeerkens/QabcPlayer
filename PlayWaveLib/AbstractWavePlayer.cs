#region License
////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
#endregion
using System;

namespace PGSoftwareSolutions.Music {
    using NextNoteEvent = EventHandler<NextNoteEventArgs>;
    using PlayCompletedEvent = EventHandler<PlayCompletedEventArgs>;

    /// <summary>TODO</summary>
    public interface IPlayer {
        /// <summary>TODO</summary>
        void PlayAsync();

        /// <summary>TODO</summary>
        event PlayCompletedEvent PlayCompleted;
        /// <summary>TODO</summary>
        event NextNoteEvent NextNote;
    }

    /// <summary>TODO</summary>
	public abstract class AbstractWavePlayer : IPlayer, ICancelablePlayer {
        /// <summary>TODO</summary>
        public AbstractWavePlayer(ISynthesizerControls synth) { Synthesizer = synth;	}

        /// <inheritdoc/>
		public abstract void PlayAsync();
        /// <inheritdoc/>
		public abstract void Cancel();
        /// <inheritdoc/>
		public virtual event PlayCompletedEvent PlayCompleted;
        /// <inheritdoc/>
		public virtual event NextNoteEvent NextNote;

        /// <inheritdoc/>
		protected virtual void OnPlayCompleted(PlayCompletedEventArgs e) => PlayCompleted?.Invoke(this,e);

        /// <summary>TODO</summary>
		protected ISynthesizerControls Synthesizer { get; set; }
	}
}
