﻿using Scylla.Enums;
using Scylla.Modules;
using System.Windows.Forms;

namespace FiveM_Crasher_2.Devices {
    class Keyboard {
        private static KeyStates GetKeyState(Keys key) {
            KeyStates state = KeyStates.None;

            short retVal = NativeImport.GetKeyState((int)key);

            if ((retVal & 0x8000) == 0x8000)
                state |= KeyStates.Down;

            if ((retVal & 1) == 1)
                state |= KeyStates.Toggled;

            return state;
        }

        public static bool IsKeyDown(Keys key) {
            return KeyStates.Down == (GetKeyState(key) & KeyStates.Down);
        }

        public static bool IsKeyToggled(Keys key) {
            return KeyStates.Toggled == (GetKeyState(key) & KeyStates.Toggled);
        }
    }
}
