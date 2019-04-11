namespace Doumi.Types
{
    using Doumi.Nexon.Net;
    using System;

    public class Dialog2F
    {
        private ushort clr1;
        private ushort clr2;
        private byte dialogType;
        private DialogType00 dialogType00;
        private DialogType04 dialogType04;
        private DialogType05 dialogType05;
        private uint guid;
        private ushort img1;
        private ushort img2;
        private string name;
        private byte objectType;
        private string text;
        private byte unka;
        private byte unkb;
        private byte unkc;

        public Dialog2F(NexonPacket packet)
        {
            this.dialogType = packet.ReadU1();
            this.objectType = packet.ReadU1();
            this.guid = packet.ReadU4();
            this.unka = packet.ReadU1();
            this.img1 = packet.ReadU2();
            this.clr1 = packet.ReadU2();
            this.unkb = packet.ReadU1();
            this.img2 = packet.ReadU2();
            this.clr2 = packet.ReadU2();
            this.unkc = packet.ReadU1();
            this.name = packet.ReadC1();
            this.text = packet.ReadC2();
            switch (this.dialogType)
            {
                case 0:
                    this.dialogType00 = new DialogType00(packet);
                    break;

                case 4:
                    this.dialogType04 = new DialogType04(packet);
                    break;

                case 5:
                    this.dialogType05 = new DialogType05(packet);
                    break;
            }
        }

        public class DialogType00
        {
            public Item[] Items;

            public DialogType00(NexonPacket packet)
            {
                this.Items = new Item[packet.ReadU2()];
                for (int i = 0; i < this.Items.Length; i++)
                {
                    this.Items[i] = new Item();
                    this.Items[i].Text = packet.ReadC1();
                    this.Items[i].Step = packet.ReadU2();
                }
            }

            public class Item
            {
                public ushort Step;
                public string Text;
            }
        }

        public class DialogType04
        {
            public Item[] List;
            public ushort Step;

            public DialogType04(NexonPacket packet)
            {
                this.Step = packet.ReadU2();
                this.List = new Item[packet.ReadU2()];
                for (int i = 0; i < this.List.Length; i++)
                {
                    this.List[i] = new Item();
                    this.List[i].Icon = packet.ReadU2();
                    this.List[i].Tint = packet.ReadU2();
                    this.List[i].Mass = packet.ReadU4();
                    this.List[i].Name = packet.ReadC1();
                    this.List[i].UnkA = packet.ReadC1();
                    this.List[i].Meta = packet.ReadC1();
                    this.List[i].Time = (packet.ReadU1() == 0) ? null : new uint?(packet.ReadU4());
                }
            }

            public class Item
            {
                public ushort Icon;
                public uint Mass;
                public string Meta;
                public string Name;
                public uint? Time;
                public ushort Tint;
                public string UnkA;
            }
        }

        public class DialogType05
        {
            public byte[] List;
            public ushort Step;

            public DialogType05(NexonPacket packet)
            {
                this.Step = packet.ReadU2();
                this.List = packet.ReadB1();
            }
        }
    }
}

