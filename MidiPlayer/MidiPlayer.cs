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

    /// <summary>TODO</summary>
    [CLSCompliant(false)]
    public sealed class MidiPlayer : IDisposable, IAsyncPlayer,
        IInstrumentSettableMidiPlayer, IPausablePlayer, ICancelablePlayer {
        readonly static OutputDevice _defaultDevice = OutputDevice.InstalledDevices[0];
        /// <summary>TODO</summary>
        public static IAsyncPlayer New() => 
            new MidiPlayer(Instrument.AcousticGrandPiano, _defaultDevice);
        /// <summary>TODO</summary>
        public static IAsyncPlayer New(IInstrument instrument) => 
            new MidiPlayer(instrument.Instrument, _defaultDevice);
        /// <summary>TODO</summary>
        public static IAsyncPlayer New(IInstrument instrument, OutputDevice device, Channel channel) =>
            new MidiPlayer(instrument.Instrument, device, channel);

        /// <summary>MIDI Instruments.</summary>
        public static IReadOnlyList<IInstrumentGenus> Instruments { get { return _instruments; } }

        /// <summary>TODO</summary>
        public OutputDevice Device    { get { return _device; } } readonly OutputDevice _device;
        /// <summary>TODO</summary>
		public Channel      Channel   { get { return _channel; } } readonly Channel _channel;
        /// <summary>TODO</summary>
		public Instrument   Instrument { get { return _instrument; }
            private set {
                _instrument = value;
                if (_clock != null)
                    new ProgramChangeMessage(Device, Channel, Instrument, 0).SendNow();
            }
        } Instrument _instrument;

        ///<inheritdoc/>
		public void PlayAsync<TNote>(Tune<TNote> tune) where TNote : INote {
            Device.Open();
            try {
                Device.SendPitchBend(Channel, 8192);        // 8192 = Centred

                var tempo = 120F;
                _clock = new Clock(tempo);
                new ProgramChangeMessage(Device, Channel, Instrument, 0).SendNow();

                float time = 0.100F;
                foreach (INote note in tune) {
                    var ni = new NoteInfo(note);
                    if (note is IAwareNote)
                        _clock.Schedule(new HighlightMessage(OnNextNote, time, (IAwareNote)note));
                    if (note.PianoKey != 0) {
                        _clock.Schedule(new NoteOnOffMessage(Device, Channel, ni.Pitch, ni.Velocity, 
                            time, _clock, ni.Duration));
                    }
                    time += ni.Length;
                }
                _clock.Schedule(new CallbackMessage(PlayCompletedCallback, time));
                _clock.Start();
            } catch (Exception) {
                Device.Close();
                throw;
            }
        }

        ///<inheritdoc/>
		public void PauseResume() {
            AsyncAction(_clock.IsRunning ? (Action)_clock.Stop
                                         : (Action)_clock.Start);
        }
        ///<inheritdoc/>
        public bool IsPaused { get { return ! _clock.IsRunning; } }

        ///<inheritdoc/>
		public void Cancel() { AsyncAction(ShutDown); }
        ///<inheritdoc/>
        public void SetInstrument(IInstrument instrument) { Instrument = instrument.Instrument; }

        ///<inheritdoc/>
		public event PlayCompletedEvent PlayCompleted;
        ///<inheritdoc/>
        public event NextNoteEvent NextNote;

        private MidiPlayer(
            Instrument   instrument, 
            OutputDevice device, 
            Channel      channel = Channel.Channel15
        ) {
            _device    = device;
            _channel   = channel;
            Instrument = instrument;
        }

        private void AsyncAction(Action action) {
            action.BeginInvoke((ar) => { action.EndInvoke(ar); }, null);
        }

        private void PlayCompletedCallback(float time) {
            Cancel();
        }
        private void ShutDown() {
            try {
                if (_clock.IsRunning) _clock.Stop();
                _clock.Reset();
                Device.Close();
                OnPlayCompleted(new PlayCompletedEventArgs(true));
            }
            catch (Exception ex) {
                OnPlayCompleted(new PlayCompletedEventArgs(true, ex));
            }
        }
        private void OnPlayCompleted(PlayCompletedEventArgs e) => PlayCompleted?.Invoke(this, e);

        private void OnNextNote(NextNoteEventArgs e) => NextNote?.Invoke(this, e);

        IReadOnlyList<IInstrumentGenus> IInstrumentSettableMidiPlayer.Instruments { get { return _instruments; } }

        private Clock _clock;

        readonly static string[] InstrumentGenus = {
            "Piano",             "Chromatic Percussion",
            "Organ",             "Guitar",
            "Bass",              "Strings",
            "Ensemble",          "Brass",
            "Reed",              "Pipe",
            "Synthetic Lead",    "Synthetic Pad",
            "Synthetic Effects", "Ethnic",
            "Percussive",        "Effects"
        };
        readonly static IReadOnlyList<IInstrumentGenus> _instruments = (
                from genus in Enumerable.Range(0,InstrumentGenus.Length)
                select new MidiGenus((short)genus, InstrumentGenus[genus])
                as IInstrumentGenus
            ).ToList().AsReadOnly();

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: dispose managed state (managed objects).
                    Cancel();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MidiPlayer() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose() {
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
