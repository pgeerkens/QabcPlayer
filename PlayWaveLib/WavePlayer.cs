﻿////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
using System;
using System.Media;

namespace PGSoftwareSolutions.Music {
	public class WavePlayer : AbstractWavePlayer, IDisposable {
		/// <summary> Clean up all managed & unmanaged resources being used. </summary>
		public virtual void Dispose() { Dispose (true); }
		/// <summary> Clean up all resources being used. </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected virtual void Dispose(bool disposing) {
			if (!_disposed) {
				if (disposing && (Player != null)) {
					Player.Dispose();
				}
				_disposed	= true;
			}
		} bool _disposed = false;

//		public WavePlayer(Tune<INote> tune) 
//			: this(tune,new CustomSynthesizer()) { }
		public WavePlayer(Tune<INote> tune, ISynthesizerControls synth) : base(synth) {
			if (tune == null)		throw new ArgumentNullException("tune");
			Tune = tune;
			Player = new SoundPlayer();
		}
		public override void PlayAsync() {
			if (Player.Stream != null) Player.Stream.Dispose();
			Player.Stream = new WaveStream(Tune, Synthesizer, null); ;
			Player.Play();
		}
		public override void Cancel() {
			if (Player != null) Player.Stop();
			OnPlayCompleted(new PlayCompletedEventArgs(true));
		}

		protected Tune<INote> Tune		{ get; private set; }
		protected SoundPlayer Player	{ get; private set; }
	}
}