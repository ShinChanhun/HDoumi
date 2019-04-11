namespace Doumi.Types
{
    using Doumi.Nexon.Net;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class Aisling : Sprite<Aisling>
    {
        /*
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private bool <StrengthenAttribute>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool <Liberato>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool <Horrama>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private bool <Kolama>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private bool <Immortal>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private bool <Rento>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool <Bardo>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool <Depreco>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool <Pravo>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool <Dark>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private bool <Sex>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private bool <Soruma>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private bool <Narcoli>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool <Illumena>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool <Venom>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool <Coma>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private bool <Um>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte <Type>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private uint <Hide>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private uint <HPBar>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte <NameTint>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte <Face>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private string <Name>k__BackingField;
        [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        private byte <Tint>k__BackingField;
        */

        public Aisling(NexonPacket packet)
        {
            base.X = packet.ReadU2();
            base.Y = packet.ReadU2();
            this.Face = packet.ReadU1();
            base.Guid = packet.ReadU4();
            this.Tint = packet.ReadU1();
            packet.ReadU1();
            packet.ReadU1();
            packet.ReadU1();
            packet.Offset += (packet.ReadU2() == 0xffff) ? 11 : 0x35;
            this.Type = packet.ReadU1();
            this.NameTint = packet.ReadU1();
            this.Name = packet.ReadC1();
            this.HPBar = 100;
            this.Soruma = false;
            this.Narcoli = false;
            this.Illumena = false;
            this.Venom = false;
            this.Liberato = false;
            this.Coma = false;
            this.Rento = false;
            this.Bardo = false;
            this.Depreco = false;
            this.Pravo = false;
            this.Dark = false;
            this.Kolama = false;
            this.Immortal = false;
            this.Horrama = false;
            this.StrengthenAttribute = false;
            this.Um = false;
        }

        public override Aisling CopyFrom(Aisling value)
        {
            base.X = value.X;
            base.Y = value.Y;
            base.Guid = value.Guid;
            this.Tint = value.Tint;
            this.NameTint = value.NameTint;
            return this;
        }

        public bool StrengthenAttribute { get; set; }

        public bool Liberato { get; set; }

        public bool Horrama { get; set; }

        public bool Kolama { get; set; }

        public bool Immortal { get; set; }

        public bool Rento { get; set; }

        public bool Bardo { get; set; }

        public bool Depreco { get; set; }

        public bool Pravo { get; set; }

        public bool Dark { get; set; }

        public bool Sex { get; set; }

        public bool Soruma { get; set; }

        public bool Narcoli { get; set; }

        public bool Illumena { get; set; }

        public bool Venom { get; set; }

        public bool Coma { get; set; }

        public bool Um { get; set; }

        public byte Type { get; set; }

        public uint Hide { get; set; }

        public uint HPBar { get; set; }

        public byte NameTint { get; set; }

        public byte Face { get; set; }

        public string Name { get; set; }

        public byte Tint { get; set; }
    }
}

