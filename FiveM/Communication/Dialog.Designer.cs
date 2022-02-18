﻿
namespace Scylla.Communication {
    partial class Dialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog));
            this.btnDialog = new MaterialSkin.Controls.MaterialButton();
            this.contentDialog = new System.Windows.Forms.Label();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // btnDialog
            // 
            this.btnDialog.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnDialog.AutoSize = false;
            this.btnDialog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDialog.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDialog.Depth = 0;
            this.btnDialog.HighEmphasis = true;
            this.btnDialog.HoverColor = true;
            this.btnDialog.Icon = null;
            this.btnDialog.Location = new System.Drawing.Point(18, 178);
            this.btnDialog.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDialog.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDialog.Name = "btnDialog";
            this.btnDialog.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnDialog.Ripples = true;
            this.btnDialog.Size = new System.Drawing.Size(366, 25);
            this.btnDialog.TabIndex = 0;
            this.btnDialog.Text = "MESSAGE_BOX_DISPLAY_BUTTON";
            this.btnDialog.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDialog.UseAccentColor = false;
            this.btnDialog.UseVisualStyleBackColor = true;
            this.btnDialog.Click += new System.EventHandler(this.btnDialog_Click);
            // 
            // contentDialog
            // 
            this.contentDialog.BackColor = System.Drawing.SystemColors.Control;
            this.contentDialog.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold);
            this.contentDialog.ForeColor = System.Drawing.Color.SteelBlue;
            this.contentDialog.Location = new System.Drawing.Point(15, 37);
            this.contentDialog.Name = "contentDialog";
            this.contentDialog.Size = new System.Drawing.Size(369, 131);
            this.contentDialog.TabIndex = 2;
            this.contentDialog.Text = "MESSAGE_BOX_DISPLAY_TEXT";
            this.contentDialog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialButton1
            // 
            this.materialButton1.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.materialButton1.AutoSize = false;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.HoverColor = false;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(-4, 0);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.materialButton1.Ripples = false;
            this.materialButton1.Size = new System.Drawing.Size(408, 24);
            this.materialButton1.TabIndex = 3;
            this.materialButton1.Text = "MESSAGE_BOX_DISPLAY_TITLE";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 216);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.contentDialog);
            this.Controls.Add(this.btnDialog);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog";
            this.Opacity = 0.95D;
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dialog_FormClosing);
            this.Load += new System.EventHandler(this.Dialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnDialog;
        private System.Windows.Forms.Label contentDialog;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}