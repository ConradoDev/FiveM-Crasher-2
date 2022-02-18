﻿using System;
using Process.NET;
using Process.NET.Memory;
using Process.NET.Patterns;
using Scylla.Modules;
using Scylla.Enums;
using System.Threading.Tasks;

namespace Scylla.Game {
    internal class OffsetManager {

        internal struct Game {
            public static IntPtr WorldPtr { get; set; }

            public static String Version  { get { return Utils.Version; } }
        }

        internal struct Object {
            /* cPed Offsets */
            public static int pCModelInfo = 0x20;
            public static int pCPlayerInfo = 0x10C8;
            public static int oInvisibility = 0x2C;

            /* CModelInfo */
            public static int oModelHash = 0x18;

            /* pCPlayerInfo */
            public static int Identifier = 0x88; //not needed
        }

        internal static ProcessSharp      process = 
        new ProcessSharp(Utils.Process(), MemoryType.Remote);

        internal static ExternalProcessMemory mem = 
        new ExternalProcessMemory(process.Handle);

        //Patterns

        internal static readonly IMemoryPattern CPedFactorySig =
        new DwordPattern("48 8B 05 ?? ?? ?? ?? 45 ?? ?? ?? ?? 48 8B 48 08 48 85 C9 74 07");
 

        public static bool GetLocalCPed() {
            LogService.Log(" └ Looking for World... ", Enums.LogLevel.Neutral, false);

            IntPtr cPedAddr = IntPtr.Zero;
            bool fullLoaded = false;

            /* WorldPtr */
            IntPtr addr = Find(process.ModuleFactory.MainModule.Name, CPedFactorySig, process).ReadAddress;       

            if (addr == IntPtr.Zero)
                return false;

            addr                 = addr + mem.Read<int>(addr + 3) + 7;
            IntPtr cPedFactory   = mem.Read<IntPtr>(addr);

            /* Avoiding Loading Characters */
            while (!fullLoaded) {
                cPedAddr = mem.Read<IntPtr>(cPedFactory + 0x8);

                if (cPedAddr == IntPtr.Zero)
                    continue;

                IntPtr ModelInfo = mem.Read<IntPtr>(cPedAddr + 0x20);
                var ModelHash = mem.Read<long>(ModelInfo + 0x18);

                if (ModelHash == 0xD7114C9)
                    continue;

                /*
                Utils.Repeat(100, () => {
                    System.Threading.Thread.Sleep(10);
                    mem.Write<long>(ModelInfo + 0x18, 0x705E61F2);
                });
                */

                fullLoaded = !fullLoaded;
            }

            cPedAddr = mem.Read<IntPtr>(cPedFactory + 0x8);
            Game.WorldPtr = cPedFactory;

            LogService.Log($" <0x{Utils.ToHex(Game.WorldPtr)}> \n", LogLevel.Hex, false);

            return true;
        }

        public static Task ScanPatterns() {

            LogService.Log("Scanning...", Enums.LogLevel.Info);

            Task.Run(async () => {

                await Task.Run(() => GetLocalCPed());

            }).GetAwaiter().GetResult();

            return Task.CompletedTask;
        }

        internal static PatternScanResult Find(string moduleName, IMemoryPattern pattern, ProcessSharp prcss) {
            var scanner = new PatternScanner(prcss[moduleName]);
            return scanner.Find(pattern);
        }

    }
}