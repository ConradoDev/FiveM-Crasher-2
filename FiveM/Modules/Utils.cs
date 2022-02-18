﻿using MaterialSkin.Controls;
using Scylla.Game;
using Scylla.Game.Objects;
using System;
using System.IO;

namespace Scylla.Modules {

    internal class Utils {

        public static string Version { get; set; }

        public static System.Diagnostics.Process Process() {
            var procs = System.Diagnostics.Process.GetProcesses();
            foreach(System.Diagnostics.Process prc in procs) {
                var process = prc.ProcessName;
                if(process.Contains("_GTAProcess") || process.Contains("_GameProcess")) {

                    Version = "Unknown"; /* not supported */

                    /* case switch not needed here */
                    if(process.Contains("b2060"))
                        Version = "b2060";
                    else if(process.Contains("b2189"))
                        Version = "b2189";
                    else if(process.Contains("b2372"))
                        Version = "b2372";
                    else if (process.Contains("b2545"))
                        Version = "b2545";
                    else
                        return null;

                    return prc;
                }
            }
            return null;
        }

        public static bool IsGameRunning() {
            if(Process() != null)
                return true;

            return false;
        }

        public static bool IsGameOnDisplay() {
            var w = NativeImport.GetActiveWindowTitle();
            if(w != null && w.Contains("FiveM"))
                return true;
            return false;
        }

        internal static bool DisableConsoleQuickEdit() {
            const uint ENABLE_QUICK_EDIT = 0x0040;
            const int STD_INPUT_HANDLE = -10;

            IntPtr consoleHandle = NativeImport.GetStdHandle(STD_INPUT_HANDLE);

            // get current console mode
            uint consoleMode;
            if(!NativeImport.GetConsoleMode(consoleHandle, out consoleMode)) {
                // ERROR: Unable to get console mode.
                return false;
            }

            // Clear the quick edit bit in the mode flags
            consoleMode &= ~ENABLE_QUICK_EDIT;

            // set the new mode
            if(!NativeImport.SetConsoleMode(consoleHandle, consoleMode)) {
                // ERROR: Unable to set console mode
                return false;
            }

            return true;
        }

        public static string ToHex(IntPtr d) {
            return d.ToString("X");
        }

        public static string ToHex(string d) {
            return Convert.ToUInt64(d).ToString("X");
        }

        public static string RandomStr() {
            string rStr = Path.GetRandomFileName();
            rStr = rStr.Replace(".", "");
            return rStr;
        }

        public static bool IsKeyPressed(System.Windows.Forms.Keys keys) {
            return 0 != (NativeImport.GetAsyncKeyState((int)keys) & 0x8000);
        }

        public static bool IsKeyPressed(uint keys) {
            return 0 != (NativeImport.GetAsyncKeyState((int)keys) & 0x8000);
        }

        public static void Message(string text, string subtext, System.Windows.Forms.Form location) {
            MaterialSnackBar SnackBarMessage =
                    new MaterialSnackBar(text, subtext);
            SnackBarMessage.Show(location);
        }

        public static bool IsDigitsOnly(string str) {
            foreach(char c in str) {
                if(c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        /* we need to use repeat due to FiveM */
        public static void Repeat(int count,Action action) {
            for (int i = 0; i < count; i++) {
                action();
            }
        }
        public static cPed GetCurrentPed()
        {
            cPed ped = new cPed();
            ped.Address = OffsetManager.mem.Read<IntPtr>(OffsetManager.Game.WorldPtr + 0x8);
            return ped;
        }
    }

}