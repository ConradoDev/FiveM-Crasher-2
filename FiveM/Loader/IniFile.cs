﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Scylla.Loader {
    class IniFile {

        public string Path;
        string EXE = "config";

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string Section, int Key, string Value, [MarshalAs(UnmanagedType.LPArray)] byte[] Result, int Size, string FileName);

        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(int Section, string Key, string Value, [MarshalAs(UnmanagedType.LPArray)] byte[] Result, int Size, string FileName);


        public IniFile(string iniPath = null) {
            Path = new FileInfo(iniPath ?? EXE + ".ini").FullName;
            if (!File.Exists(Path)) {
                System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Launcher");

                /* basis */
                Append("\n");
                Append("                                                                          \n");
                Append("  .oooooo.                                                  .o8           \n");
                Append(" d8P'  `Y8b                                                '888           \n");
                Append("888           .ooooo.  ooo. .oo.   oooo d8b  .oooo.    .oooo888   .ooooo. \n");
                Append("888          d88' `88b `888P'Y88b  `888''8P `P  )88b  d88' `888  d88' `88b\n");
                Append("888          888   888  888   888   888      .oP'888  888   888  888   888\n");
                Append("`88b    ooo  888   888  888   888   888     d8(  888  888   888  888   888\n");
                Append(" `Y8bood8P'  `Y8bod8P' o888o o888o d888b    `Y888''8o `Y8bod88P' `Y8bod8P \n");
                Append("                                                                          \n");
                Append("                                                       /* by devConrado */\n\n\n");


                Append("                             ##############                    \n");
                Append("                             # DISCLAIMER #                    \n");
                Append("           ######################################################\n");
                Append("           # We're NOT affiliated with FiveM cfx.re or Rockstar #\n");
                Append("           # and this product is distributed entirely for free. #\n");
                Append("           # If you paid for it, you were scammed.              #\n");
                Append("           ######################################################\n\n\n\n");

                DesignSection(1);
                Append("\n");
                AudioSection (1);

                return;
            }
        }

        private void Append(string s) {
            File.AppendAllText(Path, s);
        }

        public void DesignSection(int code) {
            if(code == 1) {
                Write("SplashPath", AppDomain.CurrentDomain.BaseDirectory + @"Launcher\SplashScreen.png", "DESIGN");
                Write("LoadingPath", AppDomain.CurrentDomain.BaseDirectory + @"Launcher\Loading.png", "DESIGN");
                return;
            }
            DeleteSection("DESIGN");
        }

        public void AudioSection(int code) {
            if (code == 1) {
                Write("AudioName","ANSI.SYS","AUDIO");
                Write("AudioPath",AppDomain.CurrentDomain.BaseDirectory + @"Launcher\ANSI.SYS.mp3","AUDIO");
                return;
            }
            DeleteSection("AUDIO");
        } 

        public string[] GetEntryKeyNames(string section) {
            for(int maxsize = 500;true;maxsize *= 2) {
                byte[]  bytes   = new byte[maxsize];
                int     size    = GetPrivateProfileString(section, 0, "", bytes, maxsize, Path);

                if(size < maxsize - 2) {
                    string entries = Encoding.ASCII.GetString(bytes, 0,
                          size - (size > 0 ? 1 : 0));
                    return entries.Split(new char[] { '\0' });
                }
            }
        }      

        public string Read(string Key, string Section = null) {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null) {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null) {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null) {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null) {
            return Read(Key, Section).Length > 0;
        }
    }
}

