////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using System.Linq;

namespace PGSoftwareSolutions.Music {
    internal class MidiGenus : IInstrumentGenus {
        public short                      Index   { get; }
        public string                     Name    { get; }
        public IReadOnlyList<IInstrument> Species { get; }

        public MidiGenus(short index, string name) {
            Index   = index;
            Name    = name;
            Species = ( from species in Enumerable.Range(0, 8)
                         select new MidiSpecies(this,(short)species) as IInstrument
                      ).ToList().AsReadOnly();

        }
    }
}
