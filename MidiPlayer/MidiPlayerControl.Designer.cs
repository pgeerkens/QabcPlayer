namespace PGSoftwareSolutions.Music {
    partial class MidiPlayerControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                (_midiPlayer as System.IDisposable)?.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.labelMidiInstrument = new System.Windows.Forms.Label();
            this.panelMidiGenus = new System.Windows.Forms.Panel();
            this.labelGenus = new System.Windows.Forms.Label();
            this.radioButtonGenus0 = new System.Windows.Forms.RadioButton();
            this.panelMidiSpecies = new System.Windows.Forms.Panel();
            this.labelSpecies = new System.Windows.Forms.Label();
            this.radioButtonSpecies0 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panelMidiGenus.SuspendLayout();
            this.panelMidiSpecies.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel1.Controls.Add(this.labelMidiInstrument);
            this.splitContainer3.Panel1.Controls.Add(this.panelMidiGenus);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.panelMidiSpecies);
            this.splitContainer3.Size = new System.Drawing.Size(781, 411);
            this.splitContainer3.SplitterDistance = 509;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 16;
            // 
            // labelMidiInstrument
            // 
            this.labelMidiInstrument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMidiInstrument.AutoSize = true;
            this.labelMidiInstrument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMidiInstrument.Location = new System.Drawing.Point(4, 4);
            this.labelMidiInstrument.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMidiInstrument.Name = "labelMidiInstrument";
            this.labelMidiInstrument.Size = new System.Drawing.Size(137, 13);
            this.labelMidiInstrument.TabIndex = 11;
            this.labelMidiInstrument.Text = "Select MIDI Instrument";
            // 
            // panelMidiGenus
            // 
            this.panelMidiGenus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMidiGenus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMidiGenus.Controls.Add(this.labelGenus);
            this.panelMidiGenus.Controls.Add(this.radioButtonGenus0);
            this.panelMidiGenus.Location = new System.Drawing.Point(2, 20);
            this.panelMidiGenus.Margin = new System.Windows.Forms.Padding(2);
            this.panelMidiGenus.Name = "panelMidiGenus";
            this.panelMidiGenus.Size = new System.Drawing.Size(505, 385);
            this.panelMidiGenus.TabIndex = 12;
            this.panelMidiGenus.Tag = "0";
            // 
            // labelGenus
            // 
            this.labelGenus.AutoSize = true;
            this.labelGenus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGenus.Location = new System.Drawing.Point(14, 12);
            this.labelGenus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGenus.Name = "labelGenus";
            this.labelGenus.Size = new System.Drawing.Size(78, 13);
            this.labelGenus.TabIndex = 29;
            this.labelGenus.Text = "MIDI &Genus:";
            // 
            // radioButtonGenus0
            // 
            this.radioButtonGenus0.AutoSize = true;
            this.radioButtonGenus0.Checked = true;
            this.radioButtonGenus0.Location = new System.Drawing.Point(16, 35);
            this.radioButtonGenus0.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonGenus0.Name = "radioButtonGenus0";
            this.radioButtonGenus0.Size = new System.Drawing.Size(52, 17);
            this.radioButtonGenus0.TabIndex = 20;
            this.radioButtonGenus0.TabStop = true;
            this.radioButtonGenus0.Tag = 0;
            this.radioButtonGenus0.Text = "Piano";
            this.radioButtonGenus0.UseVisualStyleBackColor = true;
            // 
            // panelMidiSpecies
            // 
            this.panelMidiSpecies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMidiSpecies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMidiSpecies.Controls.Add(this.labelSpecies);
            this.panelMidiSpecies.Controls.Add(this.radioButtonSpecies0);
            this.panelMidiSpecies.Location = new System.Drawing.Point(2, 19);
            this.panelMidiSpecies.Margin = new System.Windows.Forms.Padding(2);
            this.panelMidiSpecies.Name = "panelMidiSpecies";
            this.panelMidiSpecies.Size = new System.Drawing.Size(262, 386);
            this.panelMidiSpecies.TabIndex = 31;
            this.panelMidiSpecies.Tag = "0";
            // 
            // labelSpecies
            // 
            this.labelSpecies.AutoSize = true;
            this.labelSpecies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpecies.Location = new System.Drawing.Point(15, 14);
            this.labelSpecies.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSpecies.Name = "labelSpecies";
            this.labelSpecies.Size = new System.Drawing.Size(87, 13);
            this.labelSpecies.TabIndex = 38;
            this.labelSpecies.Text = "MIDI &Species:";
            // 
            // radioButtonSpecies0
            // 
            this.radioButtonSpecies0.AutoSize = true;
            this.radioButtonSpecies0.Checked = true;
            this.radioButtonSpecies0.Location = new System.Drawing.Point(17, 36);
            this.radioButtonSpecies0.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonSpecies0.Name = "radioButtonSpecies0";
            this.radioButtonSpecies0.Size = new System.Drawing.Size(65, 17);
            this.radioButtonSpecies0.TabIndex = 30;
            this.radioButtonSpecies0.TabStop = true;
            this.radioButtonSpecies0.Tag = 0;
            this.radioButtonSpecies0.Text = "Popcorn";
            this.radioButtonSpecies0.UseVisualStyleBackColor = true;
            // 
            // MidiPlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer3);
            this.Name = "MidiPlayerControl";
            this.Size = new System.Drawing.Size(781, 411);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panelMidiGenus.ResumeLayout(false);
            this.panelMidiGenus.PerformLayout();
            this.panelMidiSpecies.ResumeLayout(false);
            this.panelMidiSpecies.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label labelMidiInstrument;
        private System.Windows.Forms.Panel panelMidiGenus;
        private System.Windows.Forms.Label labelGenus;
        private System.Windows.Forms.RadioButton radioButtonGenus0;
        private System.Windows.Forms.Panel panelMidiSpecies;
        private System.Windows.Forms.Label labelSpecies;
        private System.Windows.Forms.RadioButton radioButtonSpecies0;
    }
}
