#region License
////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
#endregion
using System;

namespace PGSoftwareSolutions.Music {
    /// <summary>TODO</summary>
	public abstract class AbstractWavePlayer : IPlayer<INote> {
        /// <summary>TODO</summary>
        protected AbstractWavePlayer(ISynthesizerControls synth) { Synthesizer = synth;	}

        /// <inheritdoc/>
		public abstract void PlayAsync(Tune<INote> tune);
        /// <inheritdoc/>
		public abstract void Cancel();
 
        /// <summary>TODO</summary>
        public IPausablePlayer                 AsPausablePlayer                => null;
        /// <inheritdoc/>
        public abstract void SetInstrument(IInstrument instrument);

        /// <inheritdoc/>
		public event EventHandler<PlayCompletedEventArgs> PlayCompleted;
        /// <inheritdoc/>
		public event EventHandler<NextNoteEventArgs>      NextNote;

        /// <inheritdoc/>
		protected virtual void OnPlayCompleted(PlayCompletedEventArgs e) => PlayCompleted?.Invoke(this,e);
        /// <inheritdoc/>
		protected virtual void OnNextNote(NextNoteEventArgs e)           => NextNote?.Invoke(this,e);

        /// <summary>TODO</summary>
		protected ISynthesizerControls Synthesizer { get; }
	}
}
