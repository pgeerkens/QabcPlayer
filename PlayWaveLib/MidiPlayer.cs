#region License
////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Midi;

using PGSoftwareSolutions.Qabc;

namespace PGSoftwareSolutions.Music {
    // The static methods, collected together.
    public partial class MidiPlayer {
        /// <summary>Returns a new instance of {MidiPlayer}.</summary>
        public static IPlayer<INote> New()                                            => New(_defaultInstrument);
        /// <summary>Returns a new instance of {MidiPlayer}.</summary>
        public static IPlayer<INote> New(IInstrument instrument)                      => New(instrument, _defaultDevice);
        /// <summary>Returns a new instance of {MidiPlayer}.</summary>
        public static IPlayer<INote> New(IInstrument instrument, OutputDevice device) => New(instrument, device, _defaultChannel);
        /// <summary>Returns a new instance of {MidiPlayer}.</summary>
        public static IPlayer<INote> New(IInstrument instrument, OutputDevice device, Channel channel) =>
            new MidiPlayer(instrument.Instrument, device, channel);

        readonly static OutputDevice _defaultDevice     = OutputDevice.InstalledDevices[0];
        readonly static Channel      _defaultChannel    = Channel.Channel15;
        readonly static IInstrument  _defaultInstrument = Instruments[0].Species[0];

        static string[] InstrumentGenus => new string[] {
            "Piano",             "Chromatic Percussion",
            "Organ",             "Guitar",
            "Bass",              "Strings",
            "Ensemble",          "Brass",
            "Reed",              "Pipe",
            "Synthetic Lead",    "Synthetic Pad",
            "Synthetic Effects", "Ethnic",
            "Percussive",        "Effects"
        };

        /// <summary>MIDI Instruments.</summary>
        public static IReadOnlyList<IInstrumentGenus> Instruments => (
                from genus in Enumerable.Range(0,InstrumentGenus.Length)
                select new MidiGenus((short)genus, InstrumentGenus[genus])
                as IInstrumentGenus
            ).ToList().AsReadOnly();
    }

    /// <summary>TODO</summary>
    [CLSCompliant(true)]
    public sealed partial class MidiPlayer : IPlayer<INote>, IDisposable, IPausablePlayer {
        private MidiPlayer(Instrument instrument, OutputDevice device, Channel channel) {
            Device     = device;
            Channel    = channel;
            Instrument = instrument;
        }

        ///<inheritdoc/>
        public IPausablePlayer                  AsPausablePlayer                => this;

		private Channel      Channel    { get; }
        private Clock        Clock      { get; set; }
        private OutputDevice Device     { get; set; }
		private Instrument   Instrument { get; set; }

        ///<inheritdoc/>
        ///<exception cref="ObjectDisposedException">ObjectDisposedException</exception>
        ///<exception cref="ArgumentNullException">ArgumentNullException</exception>
		public void PlayAsync(Tune<INote> tune) {
            if (IsRunning) throw new InvalidOperationException("Player already running!");
            if (tune == null) throw new ArgumentNullException(nameof(tune));

            Device.Open();
            Device.SendPitchBend(Channel, 8192);        // 8192 = Centred

            Clock = new Clock(120F);
            new ProgramChangeMessage(Device, Channel, Instrument, 0).SendNow();

            float time = 0.100F;
            foreach (INote note in tune) {
                var ni = new NoteInfo(note);
                if (note is IAwareNote)
                    Clock.Schedule(new HighlightMessage(OnNextNote, time, note as IAwareNote));
                if (note.PianoKey != 0) {
                    Clock.Schedule(new NoteOnOffMessage(Device, Channel, ni.Pitch, ni.Velocity, time, Clock, ni.Duration));
                }
                time += ni.Length;
            }
            Clock.Schedule(new CallbackMessage(PlayCompletedCallback, time));
            Clock.Start();
        }
        ///<inheritdoc/>
        ///<exception cref="ObjectDisposedException">ObjectDisposedException</exception>
		public void PauseResume() => AsyncAction(IsRunning ? (Action)Clock.Stop : Clock.Start);

        ///<summary>TODO</summary>
        ///<exception cref="ObjectDisposedException">ObjectDisposedException</exception>
        public bool IsRunning {
            get { if (_isDisposed) throw new ObjectDisposedException(nameof(MidiPlayer));
                  return Clock?.IsRunning ?? false;
                }
        }
        /// <summary>Asynchronously stops, and disposes, this instance.</summary>
		public void Cancel() => AsyncAction(ShutDown);
        /// <summary>Dynamically changes the current instrument for this instance.</summary>
        ///<exception cref="ObjectDisposedException">ObjectDisposedException</exception>
        public void SetInstrument(IInstrument instrument) {
            if (IsRunning) {
                Instrument = instrument.Instrument; 
                if (Device.IsOpen) new ProgramChangeMessage(Device, Channel, Instrument, 0).SendNow();
            }
        }

        ///<inheritdoc/>
		public event EventHandler<PlayCompletedEventArgs> PlayCompleted;
        ///<inheritdoc/>
        public event EventHandler<NextNoteEventArgs>      NextNote;

        /// <summary>Runs the supplied action asynchronously.</summary>
        /// <param name="action">The "action" to be performed.</param>
        /// <remarks> <a href="https://stackoverflow.com/questions/10340871/difference-between-delegate-begininvoke-and-using-threadpool-threads-in-c-sharp">More efficient than using Begin-/End-Invoke</a>/></remarks>
        private void AsyncAction(Action action)         => ThreadPool.QueueUserWorkItem(state => action()); 

        private void PlayCompletedCallback(float time)  => Cancel();

        /// <summary>Synchronously stops, and disposes, this instance.</summary>
        private void ShutDown() {
            OnPlayCompleted(new PlayCompletedEventArgs(true));
            Dispose();
        }
        private void OnPlayCompleted(PlayCompletedEventArgs e)  => PlayCompleted?.Invoke(this, e);

        private void OnNextNote(NextNoteEventArgs e)            => NextNote?.Invoke(this, e);

        #region Standard sealed IDisposable implementation - with finalizer
        /// <inheritdoc/>
        public void Dispose() { Dispose(true); GC.SuppressFinalize(this); }
        private bool _isDisposed = false;
        private void Dispose(bool isDisposing) {
            if (! _isDisposed) {
                if (isDisposing) {  // release other disposable objects (and event-handlers)
                    NextNote      = null;
                    PlayCompleted = null;
                }
                try {if (Clock?.IsRunning ?? false) { Clock.Stop(); Clock.Reset(); } } catch (Exception) { ; } finally { Clock  = null;}
                try {if (Device?.IsOpen ?? false) { Device.Close(); } } catch (Exception) { ; } finally { Device  = null;}
            }
            _isDisposed = true;
        }

        /// <summary>Finalizer - TODO - checck if needed.</summary>
        ~MidiPlayer() { Dispose(false); }
        #endregion
    }
}
