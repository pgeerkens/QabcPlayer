#region License
////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
#endregion
using System;
using System.Windows.Forms;

namespace PGSoftwareSolutions.Util.PlayWaveLib {
	public partial class FormHelp : Form {
		public FormHelp() {
			InitializeComponent();
		}

		private void buttonOK_Click(object sender, EventArgs e) {
			Hide();
		}
	}
}
