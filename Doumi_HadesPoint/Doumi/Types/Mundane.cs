namespace Doumi.Types
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class Mundane : Sprite<Mundane>
    {
        /*
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private byte <Face>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ushort <Icon>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private string <Name>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte <Tint>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private byte <Type>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private uint <UnkA>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private byte <UnkB>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte <UnkC>k__BackingField;
        */

        public Mundane(ushort x, ushort y, uint guid, ushort icon, uint unka, byte face, byte unkb, byte tint, byte unkc, byte type, string name)
        {
            base.X = x;
            base.Y = y;
            base.Guid = guid;
            this.Icon = icon;
            this.UnkA = unka;
            this.Face = face;
            this.UnkB = unkb;
            this.Tint = tint;
            this.UnkC = unkc;
            this.Type = type;
            this.Name = name;
        }

        public override Mundane CopyFrom(Mundane value)
        {
            base.X = value.X;
            base.Y = value.Y;
            base.Guid = value.Guid;
            this.Icon = value.Icon;
            this.UnkA = value.UnkA;
            this.Face = value.Face;
            this.UnkB = value.UnkB;
            this.Tint = value.Tint;
            this.UnkC = value.UnkC;
            this.Type = value.Type;
            this.Name = value.Name;
            return this;
        }

        public byte Face { get; set; }

        public ushort Icon { get; set; }

        public string Name { get; set; }

        public byte Tint { get; set; }

        public byte Type { get; set; }

        public uint UnkA { get; set; }

        public byte UnkB { get; set; }

        public byte UnkC { get; set; }
    }
}

