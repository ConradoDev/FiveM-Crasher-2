﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Scylla.Modules {
    internal class NativeImport {
        public const int SW_HIDE           = 0;
        public const int SW_SHOW           = 5;
        public const int MY_CODE_PAGE      = 437;
        public const uint GENERIC_WRITE    = 0x40000000;
        public const uint GENERIC_READ     = 0x80000000;
        public const uint FILE_SHARE_WRITE = 0x2;
        public const uint OPEN_EXISTING    = 0x3;
        public const int MF_BYCOMMAND      = 0x00000000;
        public const int SC_CLOSE          = 0xF060;
        public const int SC_MINIMIZE       = 0xF020;
        public const int SC_MAXIMIZE       = 0xF030;
        public const int SC_SIZE           = 0xF000;
        public const int WM_NCLBUTTONDOWN  = 0xA1;
        public const int HTCAPTION         = 0x2;

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static string GetActiveWindowTitle() {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0) {
                return Buff.ToString();
            }
            return null;
        }

        [DllImport("user32.dll")]
        public static extern int SetWindowText(IntPtr hWnd, string text);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern bool FreeConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateFile(
        string lpFileName,
        uint dwDesiredAccess,
        uint dwShareMode,
        uint lpSecurityAttributes,
        uint dwCreationDisposition,
        uint dwFlagsAndAttributes,
        uint hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        [DllImport("kernel32.dll")]
        public static extern bool SetStdHandle(int nStdHandle, IntPtr hHandle);

        [DllImport("user32.dll")]
        public static extern ushort GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);
    }
}