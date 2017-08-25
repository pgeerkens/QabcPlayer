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
using Midi;

using PGSoftwareSolutions.Qabc;

namespace PGSoftwareSolutions.Music {
    using NextNoteEvent      = EventHandler<NextNoteEventArgs>;
    using PlayCompletedEvent = EventHandler<PlayCompletedEventArgs>;

    // The static methods, collected together.
    public partial class MidiPlayer {
        /// <summary>TODO</summary>
        public static IAsyncPlayer New()                                            => New(_defaultInstrument);
        /// <summary>TODO</summary>
        public static IAsyncPlayer New(IInstrument instrument)                      => New(instrument, _defaultDevice);
        /// <summary>TODO</summary>
        public static IAsyncPlayer New(IInstrument instrument, OutputDevice device) => New(instrument, device, _defaultChannel);
        /// <summary>TODO</summary>
        public static IAsyncPlayer New(IInstrument instrument, OutputDevice device, Channel channel) =>
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
    [CLSCompliant(false)]
    public sealed partial class MidiPlayer : IDisposable, IAsyncPlayer,
        IInstrumentSettableMidiPlayer, IPausablePlayer, ICancelablePlayer {
        private MidiPlayer(Instrument instrument, OutputDevice device, Channel channel) {
            Device     = device;
            Channel    = channel;
            Instrument = instrument;
        }

        /// <summary>TODO</summary>
        public OutputDevice Device      { get; }
        /// <summary>TODO</summary>
		public Channel      Channel     { get; }
        /// <summary>TODO</summary>
		public Instrument   Instrument  { get; private set; }

        ///<inheritdoc/>
		public void PlayAsync<TNote>(Tune<TNote> tune) where TNote : INote {
            if (_isDisposed) throw new ObjectDisposedException(nameof(MidiPlayer));
            if (tune == null) throw new ArgumentNullException(nameof(tune));

            Device.Open();
            Device.SendPitchBend(Channel, 8192);        // 8192 = Centred

            _clock = new Clock(120F);
            new ProgramChangeMessage(Device, Channel, Instrument, 0).SendNow();

            float time = 0.100F;
            foreach (INote note in tune) {
                var ni = new NoteInfo(note);
                if (note is IAwareNote)
                    _clock.Schedule(new HighlightMessage(OnNextNote, time, note as IAwareNote));
                if (note.PianoKey != 0) {
                    _clock.Schedule(new NoteOnOffMessage(Device, Channel, ni.Pitch, ni.Velocity, time,
                            _clock, ni.Duration));
                }
                time += ni.Length;
            }
            _clock.Schedule(new CallbackMessage(PlayCompletedCallback, time));
            _clock.Start();
        }
        ///<inheritdoc/>
		public void PauseResume() => AsyncAction(IsRunning ? (Action)_clock.Stop : (Action)_clock.Start);

        ///<inheritdoc/>
        public bool IsRunning {
            get { if (_isDisposed) throw new ObjectDisposedException(nameof(MidiPlayer));
                  return _clock?.IsRunning ?? false;
                }
        }
        ///<inheritdoc/>
		public void Cancel() => AsyncAction(ShutDown);
        ///<inheritdoc/>
        public void SetInstrument(IInstrument instrument) {
            Instrument = instrument.Instrument; 
            if (Device.IsOpen) new ProgramChangeMessage(Device, Channel, Instrument, 0).SendNow();
        }

        ///<inheritdoc/>
		public event PlayCompletedEvent PlayCompleted;
        ///<inheritdoc/>
        public event NextNoteEvent NextNote;

        private void AsyncAction(Action action)         => action.BeginInvoke((ar) => { action.EndInvoke(ar); }, null);

        private void PlayCompletedCallback(float time)  => Cancel();

        private void ShutDown() {
            OnPlayCompleted(new PlayCompletedEventArgs(true));
            Dispose();
        }
        private void OnPlayCompleted(PlayCompletedEventArgs e)  => PlayCompleted?.Invoke(this, e);

        private void OnNextNote(NextNoteEventArgs e)            => NextNote?.Invoke(this, e);

        private Clock _clock;

        #region Standard sealed IDisposable implementation - with finalizer
        private bool _isDisposed = false;
        /// <inheritdoc/>
        public void Dispose() => Dispose(false);
        private void Dispose(bool isDisposing) {
            if (! _isDisposed) {
                if (! isDisposing) {
                    try {if (_clock?.IsRunning??false) { _clock.Stop(); _clock.Reset(); } } catch (Exception) { ; }
                    try {if (Device.IsOpen) Device.Close(); } catch (Exception) { ; }
                }
            }
            _isDisposed = true;
        }

        /// <summary>Finalizer - TODO - checck if needed.</summary>
        ~MidiPlayer() { Dispose(true); }
        #endregion
    }
}
