////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
using System;
using System.Windows.Forms;

namespace PGSoftwareSolutions.QabcPlayer {
	static class Program {

        static PlayMidiForm         Form        { get; set; }
        static QabcPlayerViewModel  ViewModel   { get; set; }

		/// <summary>The main entry point for the application.</summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            Form        = new PlayMidiForm();
            ViewModel   = new QabcPlayerViewModel(Form);
			Application.Run(Form);
		}
	}
}
