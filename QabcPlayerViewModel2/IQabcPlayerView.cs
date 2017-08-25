using System;

namespace PGSoftwareSolutions.QabcPlayer {
    /// <summary>Interface to be implemented by any event source for the QabcPlayerViewModel.</summary>
    public interface IQabcPlayerView {
        event EventHandler<TuneSelectionEventArgs> TuneSelected;
        event EventHandler PlayStopRequested;
        event EventHandler PauseResumeRequested;
        event EventHandler ExitRequested;
        event EventHandler WaveLoadUnloadRequested;
        event EventHandler FormHelpRequested;
    }

    public class TuneSelectionEventArgs : EventArgs {
        public TuneSelectionEventArgs(string tuneName){ }

        public Tune Tune { get; }
    }

    public class Tune {
        public Tune(string name) {
            Name = name;
        }
        public string Name { get; }
    }
}
