﻿namespace MidiPlayerTest {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.midiPlayerControl1 = new PGSoftwareSolutions.Music.MidiPlayerControl();
            this.SuspendLayout();
            // 
            // midiPlayerControl1
            // 
            this.midiPlayerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.midiPlayerControl1.Location = new System.Drawing.Point(0, 0);
            this.midiPlayerControl1.Name = "midiPlayerControl1";
            this.midiPlayerControl1.Size = new System.Drawing.Size(534, 262);
            this.midiPlayerControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 262);
            this.Controls.Add(this.midiPlayerControl1);
            this.MinimumSize = new System.Drawing.Size(550, 300);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private PGSoftwareSolutions.Music.MidiPlayerControl midiPlayerControl1;
    }
}

