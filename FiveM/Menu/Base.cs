﻿using System;
using System.Drawing;
using System.Windows.Forms;
using FiveM_Crasher_2.Devices;
using MaterialSkin;
using MaterialSkin.Controls;
using Scylla.Enums;
using Scylla.Game;
using Scylla.Modules;

namespace FiveM_Crasher_2 {
    public partial class Base : MaterialForm {

        /* ===================================================================================== */
        /* =                                                                                   = */
        /* =                                 Material Style                                    = */
        /* =                                                                                   = */
        /* ===================================================================================== */

        public Base() {

            var materialSkinManager = MaterialSkinManager.Instance;

            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            materialSkinManager.ColorScheme = new ColorScheme
                (Primary.Blue600,Primary.Blue700,Primary.Blue200,Accent.Blue400,TextShade.WHITE);

            InitializeComponent();
        }

        /* ===================================================================================== */
        /* =                                                                                   = */
        /* =                                      Menu                                         = */
        /* =                                                                                   = */
        /* ===================================================================================== */

        private bool etc;

        private void Base_Load(object sender,EventArgs e) {
            Loop.Start();
        }

        private void Title_MouseDown(object sender,MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle,WM_NCLBUTTONDOWN,HT_CAPTION,0);
            }
        }

        private void Minimize_Click(object sender,EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Close_Click(object sender,EventArgs e) {
            this.Close();
        }

        private void Loop_Tick(object sender,EventArgs e) {

            if (!Utils.IsGameRunning())
                System.Diagnostics.Process.GetCurrentProcess().Kill();

            var ped = Utils.GetCurrentPed();

            if (etc) {
                label1.ForeColor = Color.GreenYellow;
                label1.Text = "Crasher Enabled";
            } else {
                label1.ForeColor = Color.IndianRed;
                label1.Text = "Crasher Disabled";
            }

            if (Keyboard.IsKeyDown(Keys.Insert))
                Toggle();
        }

        private void materialButton1_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Base_FormClosing(object sender, FormClosingEventArgs e) {
            Environment.Exit(0);
        }

        private void materialButton2_Click(object sender, EventArgs e) {
            Toggle();
        }

        /* Repeat is needed bcz some anticheats are returning to old model */
        private void Toggle() {
            etc = !etc;

            var ped = Utils.GetCurrentPed();
                    
            if (etc)
            {
                ped.Invisibility = true;

                System.Threading.Thread.Sleep(200);

                Utils.Repeat(100, () =>
                {
                    ped.ModelHash = 0x2D7030F3;
                });

                return;
            }

            Utils.Repeat(900, () =>
            {
                ped.ModelHash = 0x705E61F2;
            });

            System.Threading.Thread.Sleep(600);

            ped.Invisibility = false;            
        }

    }
}