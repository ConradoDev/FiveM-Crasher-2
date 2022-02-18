﻿using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scylla.Communication;
using Scylla.Game;
using Scylla.Modules;

namespace Scylla.Loader {
    public partial class LoaderForm : Form {

        public int Progress;
        WMPLib.WindowsMediaPlayer Player = null;
        private bool _playing;

        public LoaderForm() {
            InitializeComponent();
        }

        private async void Start(object sender,EventArgs e) {                    

            IniFile i = FiveM_Crasher_2.FiveM_Crasher_2.Ini;
            HUD.Parent = bg;

            if (i.Read("Console","CONFIG") == "1") {
                NativeImport.AllocConsole();
                Utils.DisableConsoleQuickEdit();
                NativeImport.SetWindowText(NativeImport.GetConsoleWindow(),Utils.RandomStr());
            }

            if (!Utils.IsGameRunning()) {
                LogService.Log($"Error : " +
                    $"Process isn't opened or the game version isn't supported.",Enums.LogLevel.Error);

                Report($"Process isn't opened or the game version isn't supported.", 15, true);
            }

            Report("Enjoy the only and working \"CRASHER\" of entirely FiveM.\n\n" +
                "Created by devConrado. (comradefy on gh)\nDiscord => Conrado#0001.\n\n" +
                "ps: dont make stupid questions in my dm, read the README.md in the same place u downloaded this.", 0, false);

            label2.Text = FiveM_Crasher_2.FiveM_Crasher_2.Ini.Read("AudioName","AUDIO");

            PlayAudio(FiveM_Crasher_2.FiveM_Crasher_2.Ini.Read("AudioPath","AUDIO"), true);

            LogService.Log("Found FiveM Process!",Enums.LogLevel.Success);

            /* hud */
            try {
                SetLoaderImg(i);

                /* initialize modules form */
                await Task.Delay(0x512); /* for the harmony */

                /* Scan for Patterns */
                IncreaseProgressPercent(25,"Fetching Information...");
                await Task.Run(OffsetManager.ScanPatterns);
                IncreaseProgressPercent(75,"Operating.");

                FiveM_Crasher_2.FiveM_Crasher_2.Base.Show();

            } catch (FileNotFoundException) {
                Report($"An attempt to open the img file denoted by a specified pathname in 'config.ini' has failed.", 15, true);
            } catch (DllNotFoundException) {
                Report($"We can't keep up. One or more files are missing.", 15, true);
            } catch (Exception exc) {
                Report($"An major error ocurred.\n {exc.Message}", 15, true);
            }
        }

        private void PlayAudio(string stream, bool play_looping) {

            _playing = true;

            if (stream == null) return;

            Player = new WMPLib.WindowsMediaPlayer();
            Player.URL = stream;
            Player.settings.autoStart = true;

            if (play_looping)
                Player.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);

        }

        private void Player_PlayStateChange(int NewState) {
            if (NewState == 8)
                Player.controls.play();
        }

        public void IncreaseProgressPercent(int num) {
            for (int i = num * 4; i > 0; i--) {
                var sz = new Size(progressBar.Size.Width - 2,progressBar.Size.Height);
                var loc = new Point(progressBar.Location.X + 2,progressBar.Location.Y);
                progressBar.Size = sz;
                progressBar.Location = loc;
            }
        }

        public void IncreaseProgressPercent(int num,string status) {
            proglabel.Text = status;
            IncreaseProgressPercent(num);
        }

        private void SetLoaderImg(IniFile i) {
            bg.Image = Image.FromFile(i.Read("SplashPath","DESIGN"));
            progressFX.Image = Image.FromFile(i.Read("LoadingPath","DESIGN"));
        }

        private void Exit_Click(object sender,EventArgs e) {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void Report(string msg,int time, bool quit) {
            new Dialog(msg,time, quit).ShowDialog();
        }

        static double ConvertBytesToMegabytes(long bytes) {
            return Math.Round((bytes / 1024f) / 1024f, 3);
        }

        private void LoaderForm_FormClosing(object sender,FormClosingEventArgs e) {
            Environment.Exit(1);
        }

        private void label3_Click(object sender,EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Exit_MouseEnter(object sender,EventArgs e) {
            var btn = sender as Label;
            btn.ForeColor = Color.RoyalBlue;
        }

        private void Exit_MouseLeave(object sender,EventArgs e) {
            var btn = sender as Label;
            btn.ForeColor = Color.White;
        }

        private void AudioBtn_MouseEnter(object sender,EventArgs e) {
            if (_playing) {
                AudioBtn.Image = FiveM_Crasher_2.Properties.Resources.MuteHover; 
                return;
            }

            AudioBtn.Image = FiveM_Crasher_2.Properties.Resources.PlayHover;
        }

        private void AudioBtn_MouseLeave(object sender,EventArgs e) {
            if (_playing) {
                AudioBtn.Image = FiveM_Crasher_2.Properties.Resources.Mute; 
                return;
            }

            AudioBtn.Image = FiveM_Crasher_2.Properties.Resources.Play;
        }

        private void AudioBtn_Click(object sender,EventArgs e) {
            _playing = !_playing;           

            if (_playing) {
                AudioBtn.Image = FiveM_Crasher_2.Properties.Resources.MuteHover;
                Player.controls.play();
                return;
            }
         
            AudioBtn.Image = FiveM_Crasher_2.Properties.Resources.PlayHover;
            Player.controls.stop();
        }
    }
}