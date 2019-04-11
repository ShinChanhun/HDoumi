namespace Doumi.Types
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class Monster : Sprite<Monster>
    {
        public Monster(ushort x, ushort y, uint guid, ushort icon, uint unka, byte face, byte unkb, byte tint, byte unkc, byte type)
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
            this.Soruma = false;
            this.Narcoli = false;
            this.Illumena = false;
            this.Venomi = false;
            this.Liberato = false;
            this.Horrama = false;
            this.Immortal = false;
            this.Confusio = false;
            this.Seo = false;
            this.HPBar = 100;
            this.기습 = false;
        }

        public override Monster CopyFrom(Monster value)
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
            return this;
        }

        public uint HPBar { get; set; }

        public byte Face { get; set; }

        public ushort Icon { get; set; }

        public byte Tint { get; set; }

        public byte Type { get; set; }

        public uint UnkA { get; set; }

        public byte UnkB { get; set; }

        public byte UnkC { get; set; }

        public bool Soruma { get; set; }

        public bool Narcoli { get; set; }

        public bool Illumena { get; set; }

        public bool Venomi { get; set; }

        public bool Liberato { get; set; }

        public bool Horrama { get; set; }

        public bool Seo { get; set; }

        public bool Immortal { get; set; }

        public bool Amnesia { get; set; }

        public bool Confusio { get; set; }

        public bool 기습 { get; set; }

        public DateTime DateTime_0 { get; set; }

    }
}

