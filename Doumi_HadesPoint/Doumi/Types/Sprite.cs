namespace Doumi.Types
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public abstract class Sprite
    {
        /*
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private uint <Guid>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private ushort <X>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private ushort <Y>k__BackingField;
        */

        protected Sprite()
        {
        }

        public uint Guid { get; set; }

        public ushort X { get; set; }

        public ushort Y { get; set; }
    }
}

