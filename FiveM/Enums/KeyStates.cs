﻿using System;

namespace Scylla.Enums {

    [Flags]
    enum KeyStates {
        None = 0,
        Down = 1,
        Toggled = 2
    }
}