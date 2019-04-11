namespace Doumi.Types
{
    using Doumi.Nexon.Net;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class Stock : SlotObject
    {
        /*
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private uint <CurrentDurability>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private byte <Flag>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private ushort <Icon>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private ushort <Mass>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private uint <MaximumDurability>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private string <Meta>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ushort <Tint>k__BackingField;
        */

        public Stock(NexonPacket packet)
        {
            base.Slot = packet.ReadU1();
            this.Icon = packet.ReadU2();
            this.Tint = packet.ReadU2();
            base.Name = packet.ReadC1();
            this.Meta = packet.ReadC1();
            packet.ReadU2();
            this.Mass = packet.ReadU2();
            this.Flag = packet.ReadU1();
            this.MaximumDurability = packet.ReadU4();
            this.CurrentDurability = packet.ReadU4();
            uint num = packet.ReadU1();
            uint num2 = packet.ReadU2();
        }

        public Stock(byte slot, ushort icon, ushort tint, string name, string meta, ushort mass, byte flag, uint maximumDurability, uint currentDurability, uint num3, uint num4)
        {
            base.Slot = slot;
            this.Icon = icon;
            this.Tint = tint;
            base.Name = name;
            this.Meta = meta;
            this.Mass = mass;
            this.Flag = flag;
            this.MaximumDurability = maximumDurability;
            this.CurrentDurability = currentDurability;
            uint num = num3;
            uint num2 = num4;
        }

        public Stock CopyFrom(Stock value)
        {
            base.Slot = value.Slot;
            this.Icon = value.Icon;
            this.Tint = value.Tint;
            base.Name = value.Name;
            this.Meta = value.Meta;
            this.Mass = value.Mass;
            this.Flag = value.Flag;
            this.MaximumDurability = value.MaximumDurability;
            this.CurrentDurability = value.CurrentDurability;
            return this;
        }

        public uint CurrentDurability { get; set; }

        public byte Flag { get; set; }

        public ushort Icon { get; set; }

        public ushort Mass { get; set; }

        public uint MaximumDurability { get; set; }

        public string Meta { get; set; }

        public ushort Tint { get; set; }
    }
}

