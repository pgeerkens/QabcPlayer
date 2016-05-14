////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
using System;

namespace PGSoftwareSolutions.Music {
    /// <summary>TODO</summary>
    internal static class InstrumentExtensions {
        /// <summary>TODO</summary>
        public static string InstrumentName(this byte @this) =>
            ((Midi.Instrument)(@this)).ToString();
    }
}
