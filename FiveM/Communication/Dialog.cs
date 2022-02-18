﻿using System;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace Scylla.Communication {
    public partial class Dialog : MaterialForm {

        int _counter = 10;
        string _content;
        private bool _preventMove = true;
        private bool _quit;

        public Dialog(string content, int t, bool quit) {

            var materialSkinManager = MaterialSkinManager.Instance;

            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme
                (Primary.Blue600,Primary.Blue700,Primary.Blue200,Accent.Blue400,TextShade.WHITE);

            InitializeComponent();

            _counter = t;           
            DialogFormat(content, quit);
        }

        private void DialogFormat(string content, bool quit) {
            _content = content;
            contentDialog.Text = $"{content}\n";
            _quit = quit;

            if (quit)
            {
                Timer t = new Timer();
                t.Start();
                t.Interval = 1000;
                t.Tick += new EventHandler(TimerTick);
                return;
            }

            btnDialog.Text = $"OK";
        }

        private void TimerTick(object sender, EventArgs e) {
            btnDialog.Text = $"Exiting in {_counter}";
            _counter -= 1;

            if (_counter >= 0)
                return;

            Environment.Exit(0);
        }

        private void btnDialog_Click(object sender, EventArgs e) {
            if (_quit)
                Environment.Exit(1);
            else
                this.Close();
        }

        private void Dialog_Load(object sender, EventArgs e) {
        }

        private void Dialog_FormClosing(object sender, FormClosingEventArgs e) {
            if (_quit)
                Environment.Exit(1);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            if (_preventMove)
            {
                switch(m.Msg)
                {
                    case WM_SYSCOMMAND:
                        int command = m.WParam.ToInt32() & 0xfff0;
                        if (command == SC_MOVE)
                            return;
                        break;
                }
            }
            base.WndProc(ref m);
        }

    }
}
