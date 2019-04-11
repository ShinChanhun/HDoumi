namespace Doumi.Types
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class Buff
    {
        /*
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private uint <Guid>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private string <Name>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private string <Area>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ushort <X>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ushort <Y>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private DateTime <Horrama>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private DateTime <Kolama>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DateTime <StrengthenAttribute>k__BackingField;
        */

        public Buff(string name)
        {
            this.Name = name;
        }

        public Buff CopyForm(Buff value)
        {
            this.Name = value.Name;
            this.X = value.X;
            this.Y = value.Y;
            this.Area = value.Area;
            return this;
        }

        public Buff Guid_Set(Buff value)
        {
            this.Guid = value.Guid;
            return this;
        }

        public Buff Horrama_Set(DateTime value)
        {
            this.Horrama = value;
            return this;
        }

        public Buff Kolama_Set(DateTime value)
        {
            this.Kolama = value;
            return this;
        }

        public Buff StrengthenAttribute_Set(DateTime value)
        {
            this.StrengthenAttribute = value;
            return this;
        }

        public uint Guid { get; set; }

        public string Name { get; set; }

        public string Area { get; set; }

        public ushort X { get; set; }

        public ushort Y { get; set; }

        [Category("Timing")]
        public DateTime Horrama { get; set; }

        public DateTime Kolama { get; set; }

        public DateTime StrengthenAttribute { get; set; }
    }
}

