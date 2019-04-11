namespace Doumi.Types
{
    using Doumi.Nexon.Net;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class Equip : SlotObject
    {
        /*
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private uint <CurrentDurability>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private ushort <Icon>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private uint <MaximumDurability>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string <Meta>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ushort <Tint>k__BackingField;
        */

        public Equip(NexonPacket packet)
        {
            base.Slot = packet.ReadU1();
            this.Icon = packet.ReadU2();
            this.Tint = packet.ReadU2();
            base.Name = packet.ReadC1();
            this.Meta = packet.ReadC1();
            this.MaximumDurability = packet.ReadU4();
            this.CurrentDurability = packet.ReadU4();
            packet.ReadU1();
            packet.ReadU1();
            packet.ReadU1();
        }

        public uint CurrentDurability { get; set; }

        public ushort Icon { get; set; }

        public uint MaximumDurability { get; set; }

        public string Meta { get; set; }

        public ushort Tint { get; set; }
    }
}

