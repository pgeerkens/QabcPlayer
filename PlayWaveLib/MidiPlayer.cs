////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using Midi;

using PGSoftwareSolutions.Qabc;
using PGSoftwareSolutions.Util;

namespace PGSoftwareSolutions.Music {
    using NextNoteEvent      = EventHandler<NextNoteEventArgs>;
    using PlayCompletedEvent = EventHandler<PlayCompletedEventArgs>;

    /// <summary>TODO</summary>
    public sealed class MidiPlayer : IAsyncPlayer,
        IInstrumentSettableMidiPlayer, IPausablePlayer, ICancelablePlayer {
        #pragma warning disable    // non-CLS compliance: Channel; OutputDevice; Instrument;
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
        public static IList<IInstrumentGenus> Instruments { get { return _instruments; } }

        /// <summary>TODO</summary>
        public OutputDevice Device  { get { return _device;  } } readonly OutputDevice _device;
        /// <summary>TODO</summary>
		public Channel      Channel { get { return _channel; } } readonly Channel _channel;
        /// <summary>TODO</summary>
		public Instrument   Instrument { get { return _instrument; }
            private set {
                _instrument = value;
                //if (_clock != null)
                if (Device.IsOpen)
                    new ProgramChangeMessage(Device, Channel, Instrument, 0).SendNow();
            }
        } Instrument _instrument;

        ///<inheritdoc/>
		public void PlayAsync<TNote>(Tune<TNote> tune) where TNote : INote {
            Device.Open();
            try {
                Device.SendPitchBend(Channel, 8192);        // 8192 = Centred

                int tempo = 120;
                _clock = new Clock(tempo);
                new ProgramChangeMessage(Device, Channel, Instrument, 0).SendNow();

                float time = 0.100F;
                foreach (INote note in tune) {
                    var ni = new NoteInfo(note);
                    if (note is IAwareNote)
                        _clock.Schedule(new HighlightMessage(OnNextNote, time, (IAwareNote)note));
                    if (note.PianoKey != 0) {
                        _clock.Schedule(new NoteOnOffMessage(Device, Channel, ni.Pitch, ni.Velocity, time,
                                _clock, ni.Duration));
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
        #pragma warning restore

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
                if (Device.IsOpen) Device.Close();
                OnPlayCompleted(new PlayCompletedEventArgs(true));
            }
            catch (Exception ex) {
                OnPlayCompleted(new PlayCompletedEventArgs(true, ex));
            }
        }
        private void OnPlayCompleted(PlayCompletedEventArgs e) =>
            PlayCompleted.RaiseEvent(this, e);

        private void OnNextNote(NextNoteEventArgs e) => NextNote.RaiseEvent(this, e);

        IList<IInstrumentGenus> IInstrumentSettableMidiPlayer.Instruments { get { return _instruments; } }

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
        readonly static IList<IInstrumentGenus> _instruments = (
                from genus in Enumerable.Range(0,InstrumentGenus.Length)
                select new MidiGenus((short)genus, InstrumentGenus[genus])
                as IInstrumentGenus
            ).ToList().AsReadOnly();
    }

    //internal class MidiGenus : IInstrumentGenus {
    //    public short              Index   { get { return _index;  } } readonly short _index;
    //    public string             Name    { get { return _name;   } } readonly string _name;
    //    public IList<IInstrument> Species { get { return _species;} } readonly IList<IInstrument> _species;

    //    public MidiGenus(short index, string name) {
    //        _index   = index;
    //        _name    = name;
    //        _species = ( from species in Enumerable.Range(0, 8)
    //                     select new MidiSpecies(this,(short)species) as IInstrument
    //                   ).ToList().AsReadOnly();

    //    }
    //}

    //internal class MidiSpecies : IInstrument {
    //    public IInstrumentGenus Genus      { get { return _genus;      } } readonly IInstrumentGenus _genus;
    //    public short            Index      { get { return _index;      } } readonly short _index;
    //    public Instrument       Instrument { get { return _instrument; } } readonly Instrument _instrument;
    //    public string           Name       { get { return _name;       } } readonly string _name;

    //    public MidiSpecies(IInstrumentGenus genus, short index) {
    //        _index      = index;
    //        _genus      = genus;
    //        _instrument = (Midi.Instrument)(_genus.Index * 8 + _index);
    //        _name = Enum.GetName(typeof(Midi.Instrument), _instrument); ;
    //    }
    //}

    ///// <summary>TODO</summary>
    //internal static class InstrumentExtensions {
    //    /// <summary>TODO</summary>
    //    public static string InstrumentName(this byte @this) =>
    //        ((Midi.Instrument)(@this)).ToString();
    //}

 //   /// <summary>TODO</summary>
 //   internal struct	NoteInfo {
 //       /// <summary>TODO</summary>
	//	public Midi.Pitch Pitch    { get { return _pitch;} }     readonly Midi.Pitch _pitch;
 //       /// <summary>TODO</summary>
	//	public int        Velocity { get { return _velocity; } } readonly int	     _velocity;
 //       /// <summary>TODO</summary>
	//	public float      Duration { get { return _duration; } } readonly float	     _duration;
 //       /// <summary>TODO</summary>
	//	public float      Length   { get { return _length; } }   readonly float	     _length;

 //       /// <summary>TODO</summary>
 //       /// <param name="note"></param>
	//	public NoteInfo(INote note) : this(note,120) {}
 //       /// <summary>TODO</summary>
 //       /// <param name="note"></param>
 //       /// <param name="tempo">whole-notes / second</param>
	//	public NoteInfo(INote note, Int32 tempo) {
	//		float beatTime = 60.0F * 4.0F / tempo;
	//		_pitch			= (Midi.Pitch)(note.PianoKey + 20);
	//		_velocity		= (int)Math.Pow(10, note.Energy/10) * 80;
	//		_duration		= (float)(note.Duration      * beatTime * 0.95);
	//		_length			= (float)(note.LengthSeconds * beatTime);
	//	}
	//}

    ///// <summary>TODO</summary>
    //internal class HighlightMessage : Message {
    //    private Action<NextNoteEventArgs> _msgSink;
    //    private IAwareNote _note;

    //    /// <summary>TODO</summary>
    //    public HighlightMessage(Action<NextNoteEventArgs> sink, float time, IAwareNote note) : base(time) {
    //        _note = note;
    //        _msgSink = sink;
    //    }
    //    /// <summary>TODO</summary>
    //    public override void SendNow() => _msgSink?.Invoke(new NextNoteEventArgs(_note));

    //    /// <summary>TODO</summary>
    //    public override Message MakeTimeShiftedCopy(float delta) =>
    //        new HighlightMessage(_msgSink, Time + delta, _note);
    //}
}
