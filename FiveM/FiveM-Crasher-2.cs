﻿using Scylla.Events;
using Scylla.Loader;
using Scylla.Modules;
using System;


namespace FiveM_Crasher_2 {
    static class FiveM_Crasher_2 {

        /* Config */
        public static IniFile Ini = new IniFile($"{System.AppDomain.CurrentDomain.BaseDirectory}/Launcher/config.ini");

        /* Forms */
        public static LoaderForm Loader = new LoaderForm();
        public static Base       Base   = new Base      ();

        [STAThread]
        static void Main() {
            LogService.Log("                                                                          \n",Scylla.Enums.LogLevel.Warn,false);
            LogService.Log("  .oooooo.                                                  .o8           \n",Scylla.Enums.LogLevel.Warn,false);
            LogService.Log(" d8P'  `Y8b                                                '888           \n",Scylla.Enums.LogLevel.Warn,false);
            LogService.Log("888           .ooooo.  ooo. .oo.   oooo d8b  .oooo.    .oooo888   .ooooo. \n",Scylla.Enums.LogLevel.Warn,false);
            LogService.Log("888          d88' `88b `888P'Y88b  `888''8P `P  )88b  d88' `888  d88' `88b\n",Scylla.Enums.LogLevel.Warn,false);
            LogService.Log("888          888   888  888   888   888      .oP'888  888   888  888   888\n",Scylla.Enums.LogLevel.Warn,false);
            LogService.Log("`88b    ooo  888   888  888   888   888     d8(  888  888   888  888   888\n",Scylla.Enums.LogLevel.Warn,false);
            LogService.Log(" `Y8bood8P'  `Y8bod8P' o888o o888o d888b    `Y888''8o `Y8bod88P' `Y8bod8P \n",Scylla.Enums.LogLevel.Warn,false);
            LogService.Log("                                                                          \n",Scylla.Enums.LogLevel.Warn,false);

            EventsManager.SubscribeToEvents();

            Loader.ShowDialog();
        }
    }
}