﻿using System;
using System.Windows.Forms;
using System.IO;
using Scylla.Enums;
using Microsoft.Win32.SafeHandles;
using System.Reflection;

namespace Scylla.Modules {
    internal class LogService {
        public static void CreateConsole() {
            NativeImport.AllocConsole();

            var outFile = NativeImport.CreateFile("CONOUT$", NativeImport.GENERIC_WRITE | NativeImport.GENERIC_READ, NativeImport.FILE_SHARE_WRITE, 0, NativeImport.OPEN_EXISTING, /*FILE_ATTRIBUTE_NORMAL*/0, 0);
            var safeHandle = new SafeFileHandle(outFile, true);

            NativeImport.SetStdHandle(11, outFile);

            FileStream fs = new FileStream(safeHandle, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs) { AutoFlush = true };

            Console.SetOut(writer);

            if (NativeImport.GetConsoleMode(outFile, out var cMode)) NativeImport.SetConsoleMode(outFile, cMode | 0x0200);

            Console.Title = $"Debug Window - {Assembly.GetExecutingAssembly().GetName().Name}";
        }

        public static void DestroyConsole() {
            if (NativeImport.GetConsoleWindow() != IntPtr.Zero) {
                NativeImport.FreeConsole();
            } else {
                MessageBox.Show(null, "Error: There is no debug console running!", $"{Assembly.GetExecutingAssembly().GetName().Name}");
                return;
            }
        }

        public static string Log(object str, LogLevel FormatColor = LogLevel.Debug, bool Newline = true) {
            if (NativeImport.GetConsoleWindow() != IntPtr.Zero) {
                var ConsoleColour = Console.ForegroundColor;

                string Prefix = "";
                string Sufix  = "";
                if (Newline) {
                    Prefix = $"[{DateTime.Now.ToString("h:mm:ss tt")}- {Assembly.GetExecutingAssembly().GetName().Name}] => ";
                    Sufix  = "\n";
                }        

                switch (FormatColor) {
                    case LogLevel.Debug:
                        ConsoleColour = ConsoleColor.Cyan;
                        break;
                    case LogLevel.Error:
                        ConsoleColour = ConsoleColor.DarkRed;
                        break;
                    case LogLevel.Warn:
                        ConsoleColour = ConsoleColor.Blue;
                        break;
                    case LogLevel.Success:
                        ConsoleColour = ConsoleColor.DarkGreen;
                        break;
                    case LogLevel.Info:
                        ConsoleColour = ConsoleColor.DarkYellow;
                        break;
                    case LogLevel.Neutral:
                        ConsoleColour = ConsoleColor.Gray;
                        break;
                    case LogLevel.Hex:
                        ConsoleColour = ConsoleColor.DarkGray;
                        break;
                    default:
                        // Default color
                        break;
                }

                Console.ForegroundColor = ConsoleColour;

                string Format = str.ToString();

                if (String.IsNullOrEmpty(Format)) {
                    Console.Write($"{Prefix} StringNullOrEmpty Occured at LogService.Log {Sufix}");
                    return $"{Prefix} StringNullOrEmpty Occured at LogService.Log {Sufix}";
                }

                Console.Write($"{Prefix}{Format}{Sufix}");
                return $"{Prefix}{Format}{Sufix}";
            } else {
                //MessageBox.Show(null, "Error: There is no debug console running!", $"{Assembly.GetExecutingAssembly().GetName().Name}");
                return "Error: There is no debug console running!";
            }
        }

        public static void Clear() {
            if (NativeImport.GetConsoleWindow() != IntPtr.Zero) {
                Console.Clear();
            } else {
                MessageBox.Show(null, "Error: There is no debug console running!", $"{Assembly.GetExecutingAssembly().GetName().Name}");
                return;
            }
        }

        public static void ShowConsole() {
            if (NativeImport.GetConsoleWindow() != IntPtr.Zero) {
                var handle = NativeImport.GetConsoleWindow();
                NativeImport.ShowWindow(handle, NativeImport.SW_SHOW);
            } else {
                MessageBox.Show(null, "Error: There is no debug console running!", $"{Assembly.GetExecutingAssembly().GetName().Name}");
                return;
            }
        }

        public static void HideConsole() {
            if (NativeImport.GetConsoleWindow() != IntPtr.Zero) {
                var handle = NativeImport.GetConsoleWindow();
                NativeImport.ShowWindow(handle, NativeImport.SW_HIDE);
            } else {
                MessageBox.Show(null, "Error: There is no debug console running!", $"{Assembly.GetExecutingAssembly().GetName().Name}");
                return;
            }
        }

        public static IntPtr GetConsoleHandle() {
            if (NativeImport.GetConsoleWindow() != IntPtr.Zero) {
                return NativeImport.GetConsoleWindow();
            } else {
                MessageBox.Show(null, "Error: There is no debug console running!", $"{Assembly.GetExecutingAssembly().GetName().Name}");
                return IntPtr.Zero;
            }
        }
    }
}