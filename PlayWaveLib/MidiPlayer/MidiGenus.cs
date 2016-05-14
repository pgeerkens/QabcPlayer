////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;

namespace PGSoftwareSolutions.Music {
    internal class MidiGenus : IInstrumentGenus {
        public short              Index   { get { return _index;  } } readonly short _index;
        public string             Name    { get { return _name;   } } readonly string _name;
        public IList<IInstrument> Species { get { return _species;} } readonly IList<IInstrument> _species;

        public MidiGenus(short index, string name) {
            _index   = index;
            _name    = name;
            _species = ( from species in Enumerable.Range(0, 8)
                         select new MidiSpecies(this,(short)species) as IInstrument
                       ).ToList().AsReadOnly();

        }
    }
}
