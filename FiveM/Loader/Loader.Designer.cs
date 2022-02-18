﻿
namespace Scylla.Loader {
    partial class LoaderForm {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoaderForm));
            this.progressBar = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.progressFX = new System.Windows.Forms.PictureBox();
            this.bg = new System.Windows.Forms.PictureBox();
            this.HUD = new System.Windows.Forms.Panel();
            this.AudioBtn = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.proglabel = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.progressFX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg)).BeginInit();
            this.HUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.progressBar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.progressBar.Location = new System.Drawing.Point(0, 381);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(653, 19);
            this.progressBar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 38.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(453, 68);
            this.label1.TabIndex = 4;
            this.label1.Text = "CONRADO\'s  Crasher";
            // 
            // progressFX
            // 
            this.progressFX.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.progressFX.Location = new System.Drawing.Point(0, 381);
            this.progressFX.Name = "progressFX";
            this.progressFX.Size = new System.Drawing.Size(662, 19);
            this.progressFX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.progressFX.TabIndex = 5;
            this.progressFX.TabStop = false;
            // 
            // bg
            // 
            this.bg.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bg.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.bg.Location = new System.Drawing.Point(0, 0);
            this.bg.Name = "bg";
            this.bg.Size = new System.Drawing.Size(653, 384);
            this.bg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bg.TabIndex = 0;
            this.bg.TabStop = false;
            // 
            // HUD
            // 
            this.HUD.BackColor = System.Drawing.Color.Transparent;
            this.HUD.Controls.Add(this.AudioBtn);
            this.HUD.Controls.Add(this.label2);
            this.HUD.Controls.Add(this.label3);
            this.HUD.Controls.Add(this.Exit);
            this.HUD.Controls.Add(this.proglabel);
            this.HUD.Controls.Add(this.label1);
            this.HUD.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.HUD.Location = new System.Drawing.Point(0, 3);
            this.HUD.Name = "HUD";
            this.HUD.Size = new System.Drawing.Size(653, 381);
            this.HUD.TabIndex = 8;
            // 
            // AudioBtn
            // 
            this.AudioBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AudioBtn.Image = global::FiveM_Crasher_2.Properties.Resources.Mute;
            this.AudioBtn.Location = new System.Drawing.Point(9, 329);
            this.AudioBtn.Name = "AudioBtn";
            this.AudioBtn.Size = new System.Drawing.Size(30, 30);
            this.AudioBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AudioBtn.TabIndex = 10;
            this.AudioBtn.TabStop = false;
            this.AudioBtn.Click += new System.EventHandler(this.AudioBtn_Click);
            this.AudioBtn.MouseEnter += new System.EventHandler(this.AudioBtn_MouseEnter);
            this.AudioBtn.MouseLeave += new System.EventHandler(this.AudioBtn_MouseLeave);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(42, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 29);
            this.label2.TabIndex = 11;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Corbel", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(596, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 40);
            this.label3.TabIndex = 9;
            this.label3.Text = "—";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            this.label3.MouseEnter += new System.EventHandler(this.Exit_MouseEnter);
            this.label3.MouseLeave += new System.EventHandler(this.Exit_MouseLeave);
            // 
            // proglabel
            // 
            this.proglabel.BackColor = System.Drawing.Color.Transparent;
            this.proglabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.proglabel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.proglabel.ForeColor = System.Drawing.Color.Snow;
            this.proglabel.Location = new System.Drawing.Point(0, 355);
            this.proglabel.Name = "proglabel";
            this.proglabel.Size = new System.Drawing.Size(653, 26);
            this.proglabel.TabIndex = 8;
            this.proglabel.Text = "Initializing...";
            this.proglabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.Font = new System.Drawing.Font("Arial", 100F, System.Drawing.FontStyle.Bold);
            this.Exit.ForeColor = System.Drawing.Color.White;
            this.Exit.Location = new System.Drawing.Point(122, 142);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(395, 145);
            this.Exit.TabIndex = 6;
            this.Exit.Text = "EXIT";
            this.Exit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            this.Exit.MouseEnter += new System.EventHandler(this.Exit_MouseEnter);
            this.Exit.MouseLeave += new System.EventHandler(this.Exit_MouseLeave);
            // 
            // LoaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 398);
            this.ControlBox = false;
            this.Controls.Add(this.HUD);
            this.Controls.Add(this.bg);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.progressFX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoaderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoaderForm_FormClosing);
            this.Load += new System.EventHandler(this.Start);
            ((System.ComponentModel.ISupportInitialize)(this.progressFX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg)).EndInit();
            this.HUD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AudioBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bg;
        private System.Windows.Forms.FlowLayoutPanel progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox progressFX;
        private System.Windows.Forms.Panel HUD;
        private System.Windows.Forms.Label proglabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox AudioBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Exit;
    }
}

