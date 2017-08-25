#region License
////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
#endregion
using System;
using System.Media;

namespace PGSoftwareSolutions.Music {
    /// <summary>TODO</summary>
	public class WavePlayer : AbstractWavePlayer, IDisposable {
		/// <summary> Clean up all managed & unmanaged resources being used. </summary>
		public virtual void Dispose() { Dispose (true); GC.SuppressFinalize(this); }
		/// <summary> Clean up all resources being used. </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected virtual void Dispose(bool disposing) {
			if (!_isDdisposed) {
				if (disposing) {
					Player?.Dispose();  Player = null;
				}
				_isDdisposed	= true;
			}
		} bool _isDdisposed = false;

        /// <summary>TODO</summary>
		public WavePlayer(ISynthesizerControls synth) : base(synth) => Player = new SoundPlayer();

        /// <inheritdoc/>
        public override void SetInstrument(IInstrument instrument) => throw new NotImplementedException();

        /// <summary>TODO</summary>
        public override void PlayAsync(Tune<INote> tune) {
			Tune = tune??throw new ArgumentNullException("tune");

            if(Player.Stream != null) Player.Stream.Dispose();
			Player.Stream = new WaveStream(Tune, Synthesizer, null); ;
			Player.Play();
        }

        /// <summary>TODO</summary>
		public override void Cancel() {
			Player?.Stop();
			OnPlayCompleted(new PlayCompletedEventArgs(true));
		}

        /// <summary>TODO</summary>
		protected Tune<INote> Tune		{ get; private set; }
        /// <summary>TODO</summary>
		protected SoundPlayer Player	{ get; private set; }
	}
}
