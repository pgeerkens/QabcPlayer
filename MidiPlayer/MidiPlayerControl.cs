using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PGSoftwareSolutions.Util;

namespace PGSoftwareSolutions.Music {
    public partial class MidiPlayerControl: UserControl {
        public MidiPlayerControl() {
            InitializeComponent();
            InitRadioButtonGenus(MidiPlayer.Instruments);
        }

        RadioButton[] _radioButtonGenus = new RadioButton[16];
        void InitRadioButtonGenus(IList<IInstrumentGenus> instruments) {
            var master = radioButtonGenus0;
            _radioButtonGenus[0] = master;

            for (int i = 1; i < 16; i++) {
                _radioButtonGenus[i] = new RadioButton();
                panelMidiGenus.Controls.Add(_radioButtonGenus[i]);

                _radioButtonGenus[i].AutoSize = master.AutoSize;
                _radioButtonGenus[i].Checked = false;
                _radioButtonGenus[i].Location = master.Location + new Size(185 * (i / 8), 25 * (i % 8));
                _radioButtonGenus[i].Name = "radioButtonGenus" + i;
                _radioButtonGenus[i].Size = master.Size;
                _radioButtonGenus[i].TabIndex = master.TabIndex + i;
                _radioButtonGenus[i].TabStop = master.TabStop;
                _radioButtonGenus[i].UseVisualStyleBackColor = master.UseVisualStyleBackColor;
                _radioButtonGenus[i].Click += radioButtonGenus_Click;
                _radioButtonGenus[i].Visible = true;
            }
            SetRadioButtonGenus(instruments);

            InitRadioButtonSpecies(instruments[0].Species);
        }
        void SetRadioButtonGenus(IList<IInstrumentGenus> instruments) {
            for (int i = 0; i < 16; i++) {
                _radioButtonGenus[i].Tag = instruments[i];
                _radioButtonGenus[i].Text = instruments[i].Name;
            }
        }

        RadioButton[] _radioButtonSpecies = new RadioButton[8];
        void InitRadioButtonSpecies(IList<IInstrument> species) {
            _radioButtonSpecies[0] = radioButtonSpecies0;
            for (int i = 1; i < 8; i++) {
                _radioButtonSpecies[i] = new RadioButton();
                panelMidiSpecies.Controls.Add(_radioButtonSpecies[i]);

                _radioButtonSpecies[i].AutoSize = radioButtonSpecies0.AutoSize;
                _radioButtonSpecies[i].Location = radioButtonSpecies0.Location + new Size(0, 25 * i);
                _radioButtonSpecies[i].Name = "radioButtonSpecies" + i;
                _radioButtonSpecies[i].Size = radioButtonSpecies0.Size;
                _radioButtonSpecies[i].TabIndex = radioButtonSpecies0.TabIndex + i;
                _radioButtonSpecies[i].UseVisualStyleBackColor = radioButtonSpecies0.UseVisualStyleBackColor;
                _radioButtonSpecies[i].Click += radioButtonSpecies_Click;
            }
            SetRadioButtonSpecies(species);
        }
        void SetRadioButtonSpecies(IList<IInstrument> species) {
            for (int i = 0; i < 8; i++) {
                _radioButtonSpecies[i].Tag = species[i];
                _radioButtonSpecies[i].Text = species[i].Name;
            }
        }

        private void radioButtonGenus_Click(object sender, EventArgs e) {
            var genus = (IInstrumentGenus)((RadioButton)sender).Tag;
            SetRadioButtonSpecies(genus.Species);
            radioButtonSpecies_Click((from b in _radioButtonSpecies
                                      where b.Checked
                                      select b).First(), e);
        }
        private void radioButtonSpecies_Click(object sender, EventArgs e) {
            var species = ((IInstrument)((RadioButton)sender).Tag);
            panelMidiSpecies.Tag = species;
            (_midiPlayer as IInstrumentSettableMidiPlayer)?.SetInstrument(species);
        }
        private IAsyncPlayer _midiPlayer;
    }
}
