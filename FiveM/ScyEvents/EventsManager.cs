﻿using Scylla.Enums;
using Scylla.Modules;
using System;
using System.Management;

namespace Scylla.Events {
    class EventsManager {
        private static ManagementEventWatcher ProcessStartEvent = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");
        private static ManagementEventWatcher ProcessStopEvent  = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStopTrace" );

        public static void SubscribeToEvents() {
            LogService.Log("Subscribing to Events...", Enums.LogLevel.Info);

            try {
                AppDomain.CurrentDomain.ProcessExit        += new EventHandler(OnProcessExit);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnProcessException);

                LogService.Log("Successfully subscribed to Events!", LogLevel.Success);
            } catch (Exception Ex) {
                LogService.Log(Ex.ToString(), LogLevel.Error);
                throw new Exception("EventSubscriptionException");
            }
        }

        private static void OnProcessExit(object sender, EventArgs e) {
        }

        private static void OnProcessException(object sender, UnhandledExceptionEventArgs e) {
            LogService.Log($"Error : {(e.ExceptionObject as Exception).Message}", LogLevel.Error);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}