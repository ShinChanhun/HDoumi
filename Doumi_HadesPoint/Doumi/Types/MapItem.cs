namespace Doumi.Types
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class MapItem : Sprite<MapItem>
    {
        /*
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private ushort <Icon>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private string <Name>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ushort <Tint>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte <UnkA>k__BackingField;
        */

        public MapItem(ushort xpos, ushort ypos, uint guid, ushort icon, ushort tint, byte unka, string name)
        {
            base.X = xpos;
            base.Y = ypos;
            base.Guid = guid;
            this.Icon = icon;
            this.Tint = tint;
            this.UnkA = unka;
            this.Name = name;
        }

        public override MapItem CopyFrom(MapItem value)
        {
            base.X = value.X;
            base.Y = value.Y;
            base.Guid = value.Guid;
            this.Icon = value.Icon;
            this.UnkA = value.UnkA;
            this.Tint = value.Tint;
            this.Name = value.Name;
            return this;
        }

        public ushort Icon { get; private set; }

        public string Name { get; private set; }

        public ushort Tint { get; private set; }

        public byte UnkA { get; private set; }
    }
}

