namespace Doumi.Types
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class SlotObject
    {
        /*
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte <Slot>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private string <Name>k__BackingField;
        */

        public SlotObject()
        {
            this.Name = "Empty";
        }

        public byte Slot { get; set; }

        public string Name { get; set; }
    }
}

