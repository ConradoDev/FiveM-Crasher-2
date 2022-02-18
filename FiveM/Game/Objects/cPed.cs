﻿using System;

namespace Scylla.Game.Objects {
    internal class cPed : Entity {

        public bool Invisibility {
            set {
                OffsetManager.mem.Write(Address + OffsetManager.Object.oInvisibility, value ? 0 : 15);
            }
        }
        public int Identifier
        {
            get
            {
                var pCPlayerInfo = OffsetManager.mem.Read<IntPtr>(Address + OffsetManager.Object.pCPlayerInfo);
                return OffsetManager.mem.Read<int>(pCPlayerInfo + OffsetManager.Object.Identifier);
            }
            set
            {
                var pCPlayerInfo = OffsetManager.mem.Read<IntPtr>(Address + OffsetManager.Object.pCPlayerInfo);
                OffsetManager.mem.Write<int>(pCPlayerInfo + OffsetManager.Object.Identifier, value);
            }
        }

        public long ModelHash {
            get {
                var pCModelInfo = OffsetManager.mem.Read<IntPtr>(Address + OffsetManager.Object.pCModelInfo);
                return OffsetManager.mem.Read<long>(pCModelInfo + OffsetManager.Object.oModelHash);
            }
            set {
                var pCModelInfo = OffsetManager.mem.Read<IntPtr>(Address + OffsetManager.Object.pCModelInfo);
                OffsetManager.mem.Write<long>(pCModelInfo + OffsetManager.Object.oModelHash, value);
            }
        }
    }
}