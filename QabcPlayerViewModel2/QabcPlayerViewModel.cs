using System;

namespace PGSoftwareSolutions.QabcPlayer {
    public class QabcPlayerViewModel {
        public QabcPlayerViewModel (IQabcPlayerView view) {
            View = view;
        }

        private IQabcPlayerView View {get;}
    }
}
