namespace Doumi.Types
{
    using Doumi.Nexon.Net;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class SpellEffect
    {
        /*
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ushort <Icon>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <Name>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private ushort <Time>k__BackingField;
        */

        public SpellEffect(NexonPacket packet)
        {
            this.Icon = packet.ReadU2();
            this.Name = packet.ReadC1();
            this.Time = packet.ReadU2();
        }

        public ushort Icon { get; private set; }

        public string Name { get; private set; }

        public ushort Time { get; private set; }
    }
}

