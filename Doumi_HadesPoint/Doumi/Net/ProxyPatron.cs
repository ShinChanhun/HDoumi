namespace Doumi.Net
{
    using Doumi;
    using Doumi.Nexon.Net;
    using Doumi.Pathfinding;
    using Doumi.Types;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;

    public class ProxyPatron : NexonPatron<ProxyPatron>
    {
        public SignalProperty<uint> CurrentHP;
        public SignalProperty<uint> CurrentMP;
        public SignalProperty<uint> MaximumHP;
        public SignalProperty<uint> MaximumMP;
        public SignalProperty<ushort> MaxWeight;
        public SignalProperty<ushort> CurrentWeight;
        public SignalProperty<uint> CurrentGold;
        public SignalProperty<byte> CurrentOffenseAttribute;
        public SignalProperty<byte> CurrentDefenceAttribute;
        public string Name;
        public byte NameTint;
        public uint Guid;
        public uint ShopNpc;
        public uint EXPNpc;
        public byte num;
        public byte b1;
        public byte b2;
        public byte b3;
        public byte b4;
        public byte b5;
        public byte b6;
        public byte b7;
        public byte b8;
        public byte b9;
        public byte b10;
        public string NPCName;
        public ushort X;
        public ushort Y;
        public Doumi.Types.Certificate certificate;
        public ProtectList protectList;
        public DeSpellList deSpellList;
        public List<PathFinder.Node> TeleportPath;
        public List<PathFinder.Node> WalkPath;
        public bool Certificate;
        public string Version;
        public int Lv;
        public uint TotalEXP;
        //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        //private ProxyPatronSettings <Settings>k__BackingField;
        //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        //private Doumi.Types.Field <Field>k__BackingField;
        //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        //private FormPatron <Form>k__BackingField;
        internal NexonPatron<ProxyPatron>.Handler[] ClientHandlers;
        internal NexonPatron<ProxyPatron>.Handler[] ServerHandlers;
        public Random r;
        public Dictionary<string, SpellEffect> SpellEffects;
        public SlotObjectCollection<ProxyPatron, Skill> Skillbook;
        public SlotObjectCollection<ProxyPatron, Spell> Spellbook;
        public SlotObjectCollection<ProxyPatron, Stock> Inventory;
        public SlotObjectCollection<ProxyPatron, Equip> Equipment;
        public List<GroupMember> GroupMembers;
        public ConcurrentDictionary<byte, Stock> Bag;
        public ConcurrentDictionary<string, Buff> BuffNote;
        public Mutex mBuff;
        public Mutex mSpell;
        public Mutex mBuffControl;
        public Mutex mGroupMember;
        public Mutex mTeleport;
        public Mutex mMonster;
        public Mutex mAisling;
        public Mutex mInventory;
        public double QuickPercentage;

        [field: DebuggerBrowsable(0), CompilerGenerated]
        public event Action<uint, ushort> CasterEffectReceived;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event Action FieldChanged;

        [field: DebuggerBrowsable(0), CompilerGenerated]
        public event Action<string, string, ushort, ushort> GroupMemberReceived;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event Action<string> OnChantMessageReceived;

        [field: DebuggerBrowsable(0), CompilerGenerated]
        public event Action<string> OnCommandReceived;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event Action<ProxyPatron, byte> OnEquipRemoved;

        [field: DebuggerBrowsable(0), CompilerGenerated]
        public event Action<string> OnGuildMessageReceived;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event Action<string> OnPartyMessageReceived;

        [field: DebuggerBrowsable(0), CompilerGenerated]
        public event Action<string> OnPrivyMessageReceived;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event Action<string> OnShoutMessageReceived;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event Action<string> OnSpeakMessageReceived;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event Action<string> OnSystemMessageReceived;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event Action PositionChanged;

        [field: DebuggerBrowsable(0), CompilerGenerated]
        public event Action<string> ServerMessageReceived;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event Action<SpellEffect> SpellEffectAdded;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event Action<SpellEffect> SpellEffectRemoved;

        [field: DebuggerBrowsable(0), CompilerGenerated]
        public event Action<uint, ushort> TargetEffectReceived;

        public ProxyPatron(NexonSocket client, NexonSocket server) : base(client, server)
        {
            this.certificate = new Doumi.Types.Certificate();
            this.Version = "1.0.0.0";
            this.Lv = 0;
            this.TotalEXP = 0;
            this.ClientHandlers = new NexonPatron<ProxyPatron>.Handler[0x100];
            this.ServerHandlers = new NexonPatron<ProxyPatron>.Handler[0x100];
            this.Bag = new ConcurrentDictionary<byte, Stock>();
            this.BuffNote = new ConcurrentDictionary<string, Buff>();
            base.Client = client;
            base.Server = server;
            this.SpellEffects = new Dictionary<string, SpellEffect>();
            this.CurrentHP = new SignalProperty<uint>();
            this.CurrentMP = new SignalProperty<uint>();
            this.MaximumHP = new SignalProperty<uint>();
            this.MaximumMP = new SignalProperty<uint>();
            this.CurrentGold = new SignalProperty<uint>();
            this.MaxWeight = new SignalProperty<ushort>();
            this.CurrentWeight = new SignalProperty<ushort>();
            this.CurrentOffenseAttribute = new SignalProperty<byte>();
            this.CurrentDefenceAttribute = new SignalProperty<byte>();
            this.Equipment = new SlotObjectCollection<ProxyPatron, Equip>(this, 0x16);
            this.Skillbook = new SlotObjectCollection<ProxyPatron, Skill>(this, 90);
            this.Spellbook = new SlotObjectCollection<ProxyPatron, Spell>(this, 90);
            this.Inventory = new SlotObjectCollection<ProxyPatron, Stock>(this, 60);
            this.GroupMembers = new List<GroupMember>();
            this.Bag = new ConcurrentDictionary<byte, Stock>();
            this.mGroupMember = new Mutex();
            this.mMonster = new Mutex();
            this.mTeleport = new Mutex();
            this.mAisling = new Mutex();
            this.mBuff = new Mutex();
            this.mInventory = new Mutex();
            this.mBuffControl = new Mutex();
            this.mSpell = new Mutex();
            this.r = new Random((int) DateTime.Now.Ticks);
            this.protectList = new ProtectList();
            this.deSpellList = new DeSpellList();
            this.certificate.Start();
        }

        public void Bag_in(ProxyPatron patron, byte slot, ushort mass = 1)
        {
            NexonClientPacket packet = new NexonClientPacket(this, 0x72);
            packet.WriteU1(5);
            packet.WriteU1(0);
            packet.WriteU1(0);
            packet.WriteU1(slot);
            packet.WriteU1(0);
            packet.WriteU4(0xf63);
            packet.WriteU2(0);
            packet.WriteU2(mass);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public void Bag_Out(ProxyPatron patron, byte slot, ushort mass = 1)
        {
            NexonClientPacket packet = new NexonClientPacket(this, 0x72);
            packet.WriteU1(5);
            packet.WriteU1(0);
            packet.WriteU1(1);
            packet.WriteU1(slot);
            packet.WriteU1(0);
            packet.WriteU4(0x3500ef);
            packet.WriteU2(0);
            packet.WriteU2(mass);
            packet.WriteU1(0);
        }

        public void BasicAttack()
        {
            NexonClientPacket packet = new NexonClientPacket(this, 0x13);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public bool CanUseSkill(string name)
        {
            Skill skill;
            return (this.TryGetSkill(name, out skill) && skill.CanUse);
        }

        public void Chant(string text)
        {
            NexonClientPacket packet = new NexonClientPacket(this, 0x4e);
            packet.WriteC1(text);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public void ChantMessageReceived(string text)
        {
            if (this.OnChantMessageReceived != null)
            {
                this.OnChantMessageReceived(text);
            }
        }

        public bool chooseBackAttackPostion(ProxyPatron patron, ushort inX, ushort inY, out ushort outX, out ushort outY, int face)
        {
            Doumi.Types.Field field = patron.Field;
            int num = 0;
            int num2 = 1;
            int num3 = 0;
            if (!this.Form.isAttackable(inX, inY))
            {
                outX = 0;
                outY = 0;
                return false;
            }
            while (num3 < 100)
            {
                num3++;
                switch (face)
                {
                    case -1:
                        num = this.r.Next(-1, 2);
                        num2 = this.r.Next(-1, 2);
                        break;

                    case 0:
                        num = 0;
                        num2 = 1;
                        break;

                    case 1:
                        num = -1;
                        num2 = 0;
                        break;

                    case 2:
                        num = 0;
                        num2 = -1;
                        break;

                    case 3:
                        num = 1;
                        num2 = 0;
                        break;

                    default:
                        num = 1;
                        num2 = 0;
                        break;
                }
                outX = (ushort) (inX + num);
                outY = (ushort) (inY + num2);
                if ((((num == 0) && (num2 == 0)) || ((num == 1) && (num2 == 1))) || ((((num == -1) && (num2 == -1)) || ((num == 1) && (num2 == -1))) || ((num == -1) && (num2 == 1))))
                {
                    face = -1;
                }
                else if (((outX > field.Cols) || (outY > field.Rows)) || ((outX < 0) || (outY < 0)))
                {
                    face = -1;
                }
                else
                {
                    if ((!field.IsSolid((ushort) (inX + num), (ushort) (inY + num2)) && !field.IsMonster((ushort) (inX + num), (ushort) (inY + num2))) && !field.IsAisling((ushort) (inX + num), (ushort) (inY + num2)))
                    {
                        break;
                    }
                    face = -1;
                }
            }
            outX = (ushort) (inX + num);
            outY = (ushort) (inY + num2);
            if (num3 == 100)
            {
                return false;
            }
            return true;
        }

        public bool chooseClosePosition(ProxyPatron patron, ushort inX, ushort inY, out ushort outX, out ushort outY, int face = -1)
        {
            int num = 0;
            int num2 = 1;
            int num3 = 0;
            while (num3 < 100)
            {
                Doumi.Types.Field field = patron.Field;
                num3++;
                switch (face)
                {
                    case -1:
                        num = this.r.Next(-1, 2);
                        num2 = this.r.Next(-1, 2);
                        break;

                    case 0:
                        num = 0;
                        num2 = 1;
                        break;

                    case 1:
                        num = -1;
                        num2 = 0;
                        break;

                    case 2:
                        num = 0;
                        num2 = -1;
                        break;

                    case 3:
                        num = 1;
                        num2 = 0;
                        break;

                    default:
                        num = 1;
                        num2 = 0;
                        break;
                }
                outX = (ushort) (inX + num);
                outY = (ushort) (inY + num2);
                if ((((num == 0) && (num2 == 0)) || ((num == 1) && (num2 == 1))) || ((((num == -1) && (num2 == -1)) || ((num == 1) && (num2 == -1))) || ((num == -1) && (num2 == 1))))
                {
                    face = -1;
                }
                else if (((outX >= (field.Cols - 2)) || (outY >= (field.Rows - 2))) || ((outX <= 0) || (outY <= 0)))
                {
                    face = -1;
                }
                else
                {
                    if ((!field.IsSolid((ushort) (inX + num), (ushort) (inY + num2)) && !field.IsMonster((ushort) (inX + num), (ushort) (inY + num2))) && !field.IsAisling((ushort) (inX + num), (ushort) (inY + num2)))
                    {
                        break;
                    }
                    face = -1;
                }
            }
            outX = (ushort) (inX + num);
            outY = (ushort) (inY + num2);
            if (num3 == 100)
            {
                return false;
            }
            return true;
        }

        public bool chooseFarMinDistancePostion(ProxyPatron patron, ushort inX, ushort inY, out ushort outX, out ushort outY, int range = 1)
        {
            int num = -1;
            int num2 = -1;
            int num3 = 100;
            for (int i = 0 - range; i <= range; i++)
            {
                if (((inX + i) >= 0) && ((inX + i) < this.Field.Cols))
                {
                    for (int j = 0 - range; j <= range; j++)
                    {
                        if ((((inY + j) >= 0) && ((inY + j) < this.Field.Rows)) && ((!this.Field.IsSolid(inX + i, inY + j) && !this.Field.IsMonster(inX + i, inY + j)) && !this.Field.IsAisling(inX + i, inY + j)))
                        {
                            int num6 = inX + i;
                            int num7 = inY + j;
                            int num8 = (int) Math.Sqrt(Math.Pow((double) (num6 - patron.X), 2.0) + Math.Pow((double) (num7 - patron.Y), 2.0));
                            if ((num3 != 0) && (num8 < num3))
                            {
                                num = num6;
                                num2 = num7;
                                num3 = num8;
                            }
                        }
                    }
                }
            }
            if (num3 == 100)
            {
                outX = 0;
                outY = 0;
                return false;
            }
            outX = (ushort) num;
            outY = (ushort) num2;
            return true;
        }

        public void chooseFarPosition(ProxyPatron patron, ushort inX, ushort inY, out ushort outX, out ushort outY, int howFar = 30)
        {
            int num;
            int num2;
            int num3;
            Doumi.Types.Field field = patron.Field;
            do
            {
                num = this.r.Next(3, field.Cols - 4);
                num2 = this.r.Next(3, field.Rows - 4);
                num3 = (int) Math.Sqrt(Math.Pow((double) (num - inX), 2.0) + Math.Pow((double) (num2 - inY), 2.0));
            }
            while ((num3 >= howFar) || field[num, num2].Solid);
            outX = (ushort) num;
            outY = (ushort) num2;
        }

        public void chooseFarPositionWithoutMonster(ProxyPatron patron, ushort inX, ushort inY, out ushort outX, out ushort outY, int howFar = 30)
        {
            int num;
            int num2;
            int num3;
            Doumi.Types.Field field = patron.Field;
            do
            {
                num = this.r.Next(3, field.Cols - 4);
                num2 = this.r.Next(3, field.Rows - 4);
                num3 = (int) Math.Sqrt(Math.Pow((double) (num - inX), 2.0) + Math.Pow((double) (num2 - inY), 2.0));
            }
            while (((num3 >= howFar) || field[num, num2].Solid) || !patron.Form.isSafeZone(num, num2));
            outX = (ushort) num;
            outY = (ushort) num2;
        }

        public bool chooseMinDistancePostion(ProxyPatron patron, ushort inX, ushort inY, out ushort outX, out ushort outY)
        {
            int num = -1;
            int num2 = -1;
            int num3 = 100;
            for (int i = -1; i <= 1; i++)
            {
                if (((inX + i) >= 0) && ((inX + i) < this.Field.Cols))
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if ((((inY + j) >= 0) && ((inY + j) < this.Field.Rows)) && ((!this.Field.IsSolid(inX + i, inY + j) && !this.Field.IsMonster(inX + i, inY + j)) && !this.Field.IsAisling(inX + i, inY + j)))
                        {
                            int num6 = inX + i;
                            int num7 = inY + j;
                            int num8 = (int) Math.Sqrt(Math.Pow((double) (num6 - patron.X), 2.0) + Math.Pow((double) (num7 - patron.Y), 2.0));
                            if (((num3 != 0) && (num3 > num8)) && (((((num6 == (inX + 1)) && (num7 == inY)) || ((num6 == (inX - 1)) && (num7 == inY))) || ((num6 == inX) && (num7 == (inY + 1)))) || ((num6 == inX) && (num7 == (inY - 1)))))
                            {
                                num = num6;
                                num2 = num7;
                                num3 = num8;
                            }
                        }
                    }
                }
            }
            if (num3 == 100)
            {
                outX = 0;
                outY = 0;
                return false;
            }
            outX = (ushort) num;
            outY = (ushort) num2;
            return true;
        }

        public void chooseNearPosition(ProxyPatron patron, ushort inX, ushort inY, int delta1, int delta2, out ushort outX, out ushort outY)
        {
            int num = 1;
            int num2 = 1;
            int num3 = 0;
            Doumi.Types.Field field = patron.Field;
            while (num3 < 500)
            {
                num3++;
                num = this.r.Next(delta1, delta2);
                num2 = this.r.Next(delta1, delta2);
                if ((((num != 0) || (num2 != 0)) && (((((ushort) (inX + num)) < (field.Cols - 2)) && (((ushort) (inY + num2)) < (field.Rows - 2))) && ((((ushort) (inX + num)) >= 1) && (((ushort) (inY + num2)) >= 1)))) && (((((ushort) (inX + num)) <= 500) && (((ushort) (inY + num2)) <= 500)) && !field[(ushort) (inX + num), (ushort) (inY + num2)].Solid))
                {
                    break;
                }
            }
            outX = (ushort) (inX + num);
            outY = (ushort) (inY + num2);
        }

        public void chooseNearPosition2(ProxyPatron patron, ushort inX, ushort inY, int delta1, int delta2, out ushort outX, out ushort outY)
        {
            int num = 1;
            int num2 = 1;
            int num3 = 0;
            Doumi.Types.Field field = patron.Field;
            while (num3 < 500)
            {
                num3++;
                num = this.r.Next(delta1, delta2);
                num2 = this.r.Next(delta1, delta2);
                if ((((num != 0) || (num2 != 0)) && (((((ushort) (inX + num)) < (field.Cols - 2)) && (((ushort) (inY + num2)) < (field.Rows - 2))) && ((((ushort) (inX + num)) >= 1) && (((ushort) (inY + num2)) >= 1)))) && (((((ushort) (inX + num)) <= 500) && (((ushort) (inY + num2)) <= 500)) && !field[(ushort) (inX + num), (ushort) (inY + num2)].Solid))
                {
                    break;
                }
            }
            outX = (ushort) (inX + num);
            outY = (ushort) (inY + num2);
        }

        public void chooseNextPlace(ProxyPatron patron, ushort inX, ushort inY, out ushort outX, out ushort outY, int cnt)
        {
            int num;
            int num2;
            int num3;
            Doumi.Types.Field field = patron.Field;
            do
            {
                num = 1;
                int num4 = (int) Math.Floor((double) (((double) num) / ((double) field.Cols)));
                num2 = 1;
                num3 = (int) Math.Sqrt(Math.Pow((double) (num - inX), 2.0) + Math.Pow((double) (num2 - inY), 2.0));
            }
            while ((num3 >= 0x19) || field[num, num2].Solid);
            outX = (ushort) num;
            outY = (ushort) num2;
        }

        public void CommandReceived(string text)
        {
            if (this.OnCommandReceived != null)
            {
                this.OnCommandReceived(text);
            }
        }

        private static void DefaultClientHandler(ProxyPatron patron, NexonPacket packet)
        {
            patron.Server.Send(packet);
        }

        private static void DefaultServerHandler(ProxyPatron patron, NexonPacket packet)
        {
            patron.Client.Send(packet);
        }

        public void DropMoney(uint mass, ushort xpos, ushort ypos)
        {
            NexonClientPacket packet = new NexonClientPacket(this, 0x24);
            packet.WriteU4(mass);
            packet.WriteU2(xpos);
            packet.WriteU2(ypos);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public void DropStock(byte slot, ushort xpos, ushort ypos, uint mass)
        {
            NexonClientPacket packet = new NexonClientPacket(this, 8);
            packet.WriteU1(slot);
            packet.WriteU2(xpos);
            packet.WriteU2(ypos);
            packet.WriteU4(mass);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public byte EmptySlot()
        {
            for (byte i = 1; i < this.Inventory.Length; i = (byte) (i + 1))
            {
                try
                {
                    if (this.Inventory[i].Name != null)
                    {
                    }
                }
                catch
                {
                    return i;
                }
            }
            return 0;
        }

        public void GetStock(byte slot, ushort xpos, ushort ypos)
        {
            NexonClientPacket packet = new NexonClientPacket(this, 7);
            packet.WriteU1(slot);
            packet.WriteU2(xpos);
            packet.WriteU2(ypos);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public void GroupMemberPosUpdate_Off()
        {
            NexonClientPacket packet = new NexonClientPacket(this, 0x2e);
            packet.WriteU1(8);
            packet.WriteC1(this.Name);
            packet.WriteU1(0);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public void GroupMemberPosUpdate_On()
        {
            NexonClientPacket packet = new NexonClientPacket(this, 0x2e);
            packet.WriteU1(8);
            packet.WriteC1(this.Name);
            packet.WriteU1(1);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public void GuildMessageReceived(string text)
        {
            if (this.OnGuildMessageReceived != null)
            {
                this.OnGuildMessageReceived(text);
            }
        }

        public bool isState()
        {
            this.mBuff.WaitOne();
            if ((this.protectList.is디소루마 || this.protectList.is디나르콜리) || this.protectList.is코마)
            {
                this.mBuff.ReleaseMutex();
                return true;
            }
            this.mBuff.ReleaseMutex();
            return false;
        }

        public void ItemRepair()
        {
            if (this.UseStockS("만능원격상점"))
            {
                Thread.Sleep(250);
                NexonClientPacket packet = new NexonClientPacket(this, 0x39);
                packet.WriteU1(1);
                packet.WriteU4(this.ShopNpc);
                packet.WriteU1(0);
                packet.WriteU1(0x48);
                packet.WriteU1(0);
                base.Server.Send(packet);
                Thread.Sleep(250);
                NexonClientPacket packet2 = new NexonClientPacket(this, 0x39);
                packet2.WriteU1(1);
                packet2.WriteU4(this.ShopNpc);
                packet2.WriteU1(0);
                packet2.WriteU1(0x5c);
                packet2.WriteU1(0);
                base.Server.Send(packet2);
                Thread.Sleep(300);
                this.PanelClose();
            }
        }

        public bool MoveByTeleport(ProxyPatron patron, int x, int y)
        {
            Stock stock;
            Doumi.Types.Field field = patron.Field;
            if ((patron.X == x) && (patron.Y == y))
            {
                return true;
            }

            if (patron.Field.Name == "레드오피온의굴29" &&
                x >= 24 && x <= 29 && y == 1) return false;

            if (patron.TryGetStockS("[TEST]테슬러의깃털(1일)", out stock) || patron.TryGetStockS("[TEST]테슬러의깃털(1일)", out stock))
            {
                if (this.Field.GetPath(this.X, this.Y, x, y, out this.TeleportPath) == false)
                    return false;
                List<PathFinder.Node> list = new List<PathFinder.Node>();
                try
                {
                    int num = this.TeleportPath.Count - 1;
                    if (num <= 13)
                    {
                        NexonClientPacket packet = new NexonClientPacket(patron, 0x83);
                        packet.WriteU1(stock.Slot);
                        if (field.TryTeleport2(packet, patron.X, patron.Y, this.TeleportPath[num].X, this.TeleportPath[num].Y))
                        {
                            patron.Server.Send(packet);
                            patron.X = (ushort) this.TeleportPath[num].X;
                            patron.Y = (ushort) this.TeleportPath[num].Y;
                            patron.Refresh();
                        }
                    }
                    if (num > 13)
                    {
                        int num2 = num;
                        int num3 = 1;
                        PathFinder.Node item = new PathFinder.Node();
                        while (num2 > 13)
                        {
                            num2 -= 13;
                            num3 += 13;
                            item.X = this.TeleportPath[num3].X;
                            item.Y = this.TeleportPath[num3].Y;
                            list.Add(item);
                        }
                        item.X = this.TeleportPath[num].X;
                        item.Y = this.TeleportPath[num].Y;
                        list.Add(item);
                    }
                    foreach (PathFinder.Node node2 in list)
                    {
                        NexonClientPacket packet = new NexonClientPacket(patron, 0x83);
                        packet.WriteU1(stock.Slot);
                        if (field.TryTeleport2(packet, patron.X, patron.Y, node2.X, node2.Y))
                        {
                            patron.Server.Send(packet);
                            patron.X = (ushort) node2.X;
                            patron.Y = (ushort) node2.Y;
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }
            else if (patron.TryGetStockS("텔리포트의깃털", out stock))
            {
                this.Field.GetPath(this.X, this.Y, x, y, out this.TeleportPath);
                List<PathFinder.Node> list2 = new List<PathFinder.Node>();
                try
                {
                    int num5 = this.TeleportPath.Count - 1;
                    if (num5 <= 6)
                    {
                        NexonClientPacket packet = new NexonClientPacket(patron, 0x83);
                        packet.WriteU1(stock.Slot);
                        if (field.TryTeleport2(packet, patron.X, patron.Y, this.TeleportPath[num5].X, this.TeleportPath[num5].Y))
                        {
                            patron.Server.Send(packet);
                            patron.X = (ushort) this.TeleportPath[num5].X;
                            patron.Y = (ushort) this.TeleportPath[num5].Y;
                        }
                    }
                    if (num5 > 6)
                    {
                        int num6 = num5;
                        int num7 = 1;
                        PathFinder.Node item = new PathFinder.Node();
                        while (num6 > 6)
                        {
                            num6 -= 6;
                            num7 += 6;
                            item.X = this.TeleportPath[num7].X;
                            item.Y = this.TeleportPath[num7].Y;
                            list2.Add(item);
                        }
                        item.X = this.TeleportPath[num5].X;
                        item.Y = this.TeleportPath[num5].Y;
                        list2.Add(item);
                    }
                    foreach (PathFinder.Node node4 in list2)
                    {
                        NexonClientPacket packet = new NexonClientPacket(patron, 0x83);
                        packet.WriteU1(stock.Slot);
                        if (field.TryTeleport2(packet, patron.X, patron.Y, node4.X, node4.Y))
                        {
                            patron.Server.Send(packet);
                            patron.X = (ushort) node4.X;
                            patron.Y = (ushort) node4.Y;
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }
            return ((patron.X == x) && (patron.Y == y));
        }

        public void MoveSkill(byte curr, byte next)
        {
            NexonClientPacket packet = new NexonClientPacket(this, 0x30);
            packet.WriteU1(2);
            packet.WriteU1(curr);
            packet.WriteU1(next);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public void MoveSpell(byte curr, byte next)
        {
            NexonClientPacket packet = new NexonClientPacket(this, 0x30);
            packet.WriteU1(1);
            packet.WriteU1(curr);
            packet.WriteU1(next);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public void MoveStock(byte curr, byte next)
        {
            NexonClientPacket packet = new NexonClientPacket(this, 0x30);
            packet.WriteU1(0);
            packet.WriteU1(curr);
            packet.WriteU1(next);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public bool MoveToDestination(int x, int y, int cnt = 0, int sleep = 250)
        {
            this.mMonster.WaitOne();
            this.Field.GetWalkePath(this.X, this.Y, x, y, out this.WalkPath);
            this.mMonster.ReleaseMutex();
            if (this.WalkPath == null)
            {
                return false;
            }
            Direction direction = Doumi.Types.Field.GetDirection(this.WalkPath[0].X, this.WalkPath[0].Y, this.WalkPath[1].X, this.WalkPath[1].Y);
            this.Turn((byte) direction);
            for (int i = 1; i < this.WalkPath.Count; i++)
            {
                Direction direction2 = Doumi.Types.Field.GetDirection(this.WalkPath[i - 1].X, this.WalkPath[i - 1].Y, this.WalkPath[i].X, this.WalkPath[i].Y);
                if (direction != direction2)
                {
                    direction = direction2;
                    this.Turn((byte) direction);
                }
                this.Walk((byte) direction2, 0);
                this.Refresh();
            }
            return true;
        }

        public void OnCasterEffectReceived(uint guid, ushort effect)
        {
            if (this.CasterEffectReceived != null)
            {
                this.CasterEffectReceived(guid, effect);
            }
        }

        public void OnChangeField(Doumi.Types.Field field)
        {
            this.Field = field;
            if (this.FieldChanged != null)
            {
                this.FieldChanged();
            }
        }

        public void OnGroupMemberReceived(string name, string area, ushort x, ushort y)
        {
            if (this.GroupMemberReceived != null)
            {
                this.GroupMemberReceived(name, area, x, y);
            }
        }

        public void OnPositionChanged(ushort xpos, ushort ypos)
        {
            this.X = xpos;
            this.Y = ypos;
            if (this.PositionChanged != null)
            {
                this.PositionChanged();
            }
        }

        public void OnServerMessageReceived(string text)
        {
            if (this.ServerMessageReceived != null)
            {
                this.ServerMessageReceived(text);
            }
        }

        public void OnSpellEffectAdded(SpellEffect spellEffect)
        {
            if (!this.SpellEffects.ContainsKey(spellEffect.Name))
            {
                this.SpellEffects.Add(spellEffect.Name, spellEffect);
            }
            else
            {
                this.SpellEffects[spellEffect.Name] = spellEffect;
            }
            if (this.SpellEffectAdded != null)
            {
                this.SpellEffectAdded(spellEffect);
            }
        }

        public void OnSpellEffectRemoved(SpellEffect spellEffect)
        {
            this.SpellEffects.Remove(spellEffect.Name);
            if (this.SpellEffectRemoved != null)
            {
                this.SpellEffectRemoved(spellEffect);
            }
        }

        public void OnTargetEffectReceived(uint guid, ushort effect)
        {
            if (this.TargetEffectReceived != null)
            {
                this.TargetEffectReceived(guid, effect);
            }
        }

        public void PanelClose()
        {
            NexonServerPacket packet = new NexonServerPacket(this, 0x30);
            packet.WriteU1(15);
            packet.WriteU1(0);
            base.Client.Send(packet);
        }

        public void PartyMessageReceived(string text)
        {
            if (this.OnPartyMessageReceived != null)
            {
                this.OnPartyMessageReceived(text);
            }
        }

        public void PrivyMessageReceived(string text)
        {
            if (this.OnPrivyMessageReceived != null)
            {
                this.OnPrivyMessageReceived(text);
            }
        }

        public void Refresh()
        {
            NexonClientPacket packet = new NexonClientPacket(this, 0x38);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public void RemoveEquip(byte slot)
        {
            if (slot > 0)
            {
                this.Equipment[slot - 1] = null;
                if (this.OnEquipRemoved != null)
                {
                    this.OnEquipRemoved(this, slot);
                }
            }
        }

        public void SellExpForHP()
        {
            if (this.UseStockS("신경험치변환"))
            {
                Thread.Sleep(350);
                NexonClientPacket packet = new NexonClientPacket(this, 0x3a);
                packet.WriteU1(2);
                packet.WriteU4(this.EXPNpc);
                packet.WriteU1(0);
                packet.WriteU1(0);
                packet.WriteU1(0);
                packet.WriteU1(2);
                packet.WriteU1(1);
                packet.WriteU1(2);
                packet.WriteU1(0);
                base.Server.Send(packet);
                Thread.Sleep(350);
                for (int i = 0; i < 100; i++)
                {
                    NexonClientPacket packet2 = new NexonClientPacket(this, 0x3a);
                    packet2.WriteU1(2);
                    packet2.WriteU4(this.EXPNpc);
                    packet2.WriteU1(0);
                    packet2.WriteU1(0);
                    packet2.WriteU1(0);
                    packet2.WriteU1(2);
                    packet2.WriteU1(0);
                    base.Server.Send(packet2);
                    Thread.Sleep(350);
                }
            }
        }

        public void SellExpForMP()
        {
            if (this.UseStockS("신경험치변환"))
            {
                Thread.Sleep(350);
                NexonClientPacket packet = new NexonClientPacket(this, 0x3a);
                packet.WriteU1(2);
                packet.WriteU4(this.EXPNpc);
                packet.WriteU1(0);
                packet.WriteU1(0);
                packet.WriteU1(0);
                packet.WriteU1(2);
                packet.WriteU1(1);
                packet.WriteU1(3);
                packet.WriteU1(0);
                base.Server.Send(packet);
                Thread.Sleep(350);
                for (int i = 0; i < 30; i++)
                {
                    NexonClientPacket packet2 = new NexonClientPacket(this, 0x3a);
                    packet2.WriteU1(2);
                    packet2.WriteU4(this.EXPNpc);
                    packet2.WriteU1(0);
                    packet2.WriteU1(0);
                    packet2.WriteU1(0);
                    packet2.WriteU1(2);
                    packet2.WriteU1(0);
                    base.Server.Send(packet2);
                    Thread.Sleep(350);
                }
            }
        }

        public void SendMessage(byte type, string text)
        {
            NexonClientPacket packet = new NexonClientPacket(this, 10);
            packet.WriteU1(type);
            packet.WriteC2(text);
            packet.WriteU1(0);
            base.Client.Send(packet);
        }

        public void ShoutMessageReceived(string text)
        {
            if (this.OnShoutMessageReceived != null)
            {
                this.OnShoutMessageReceived(text);
            }
        }

        public void Speak(string text)
        {
            byte byteCount = (byte) Encoding.Default.GetByteCount(text);
            NexonClientPacket packet = new NexonClientPacket(this, 14);
            packet.WriteU1(byteCount);
            packet.WriteC1(text);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public void SpeakParty(string text)
        {
            NexonServerPacket packet = new NexonServerPacket(this, 0x19);
            packet.WriteU1(02);
            packet.WriteU1(0x21);
            packet.WriteU1(0x21);
            packet.WriteC1(text);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public void SpeakH(string text, byte type = 0)
        {
            NexonServerPacket packet = new NexonServerPacket(this, 13);
            packet.WriteU1(type);
            packet.WriteU4(this.Guid);
            packet.WriteC1(text);
            packet.WriteU1(0);
            base.Client.Send(packet);
        }

        public void SpeakMessageReceived(string text)
        {
            if (this.OnSpeakMessageReceived != null)
            {
                this.OnSpeakMessageReceived(text);
            }
        }

        public void SystemMessageReceived(string text)
        {
            if (this.OnSystemMessageReceived != null)
            {
                this.OnSystemMessageReceived(text);
            }
        }

        public void ThreadTeleport(ProxyPatron patron, int x, int y)
        {
            new Thread(() => this.MoveByTeleport(patron, x, y)).Start();
        }

        public uint TotalStockCount()
        {
            uint num = 0;
            using (IEnumerator<Stock> enumerator = this.Inventory.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current != null)
                    {
                        num++;
                    }
                }
            }
            return num;
        }

        public bool TryGetSkill(string name)
        {
            foreach (Skill skill in this.Skillbook)
            {
                if ((skill != null) && skill.Text.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public bool TryGetSkill(string name, out Skill skill)
        {
            foreach (Skill skill2 in this.Skillbook)
            {
                if ((skill2 != null) && skill2.Text.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                {
                    skill = skill2;
                    return true;
                }
            }
            skill = null;
            return false;
        }

        public bool TryGetSpell(string name)
        {
            foreach (Spell spell in this.Spellbook)
            {
                if ((spell != null) && spell.Text.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public bool TryGetSpell(string name, out Spell spell)
        {
            foreach (Spell spell2 in this.Spellbook)
            {
                if ((spell2 != null) && spell2.Text.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                {
                    spell = spell2;
                    return true;
                }
            }
            spell = null;
            return false;
        }

        public bool TryGetStock(string startname, string endname, out Stock stock)
        {
            foreach (Stock stock2 in this.Inventory)
            {
                if (((stock2 != null) && stock2.Name.StartsWith(startname, StringComparison.OrdinalIgnoreCase)) && stock2.Name.EndsWith(endname, StringComparison.OrdinalIgnoreCase))
                {
                    stock = stock2;
                    return true;
                }
            }
            stock = null;
            return false;
        }

        public bool TryGetStockE(string name)
        {
            foreach (Stock stock in this.Inventory)
            {
                if ((stock != null) && stock.Name.EndsWith(name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public bool TryGetStockE(string name, out Stock stock)
        {
            foreach (Stock stock2 in this.Inventory)
            {
                if ((stock2 != null) && stock2.Name.EndsWith(name, StringComparison.OrdinalIgnoreCase))
                {
                    stock = stock2;
                    return true;
                }
            }
            stock = null;
            return false;
        }

        public bool TryGetStockS(string name)
        {
            foreach (Stock stock in this.Inventory)
            {
                if ((stock != null) && stock.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public bool TryGetStockS(string name, out Stock stock)
        {
            foreach (Stock stock2 in this.Inventory)
            {
                if ((stock2 != null) && stock2.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                {
                    stock = stock2;
                    return true;
                }
            }
            stock = null;
            return false;
        }

        public void Turn(byte face)
        {
            NexonClientPacket packet = new NexonClientPacket(this, 0x11);
            packet.WriteU1(face);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public void UseSkill(Skill skill)
        {
            if (skill.CanUse)
            {
                NexonClientPacket packet = new NexonClientPacket(this, 0x3e);
                packet.WriteU1(skill.Slot);
                packet.WriteU1(0);
                base.Server.Send(packet);
            }
        }

        public void UseSkill(string name)
        {
            Skill skill;
            if (this.TryGetSkill(name, out skill))
            {
                this.UseSkill(skill);
            }
        }

        public void UseSpell(Spell spell, Sprite target = null)
        {
            if (spell.Span > 0)
            {
                NexonClientPacket packet2 = new NexonClientPacket(this, 0x4d);
                packet2.WriteU1(spell.Span);
                packet2.WriteU1(0);
                base.Server.Send(packet2);
                if (((spell.Name.StartsWith("프라") || spell.Name.StartsWith("데프")) || spell.Name.StartsWith("바르도")) || spell.Name.StartsWith("렌토"))
                {
                    for (int i = spell.Span / 8; i > 0; i--)
                    {
                        Thread.Sleep(550);
                    }
                }
                else
                {
                    for (int i = spell.Span / 8; i > 0; i--)
                    {
                        Thread.Sleep(0x3e8);
                    }
                }
                this.Chant(spell.Name);
            }
            NexonClientPacket packet = new NexonClientPacket(this, 15);
            packet.WriteU1(spell.Slot);
            if (target != null)
            {
                packet.WriteU4(target.Guid);
                packet.WriteU2(target.X);
                packet.WriteU2(target.Y);
            }
            else
            {
                packet.WriteU4(this.Guid);
                packet.WriteU2(this.X);
                packet.WriteU2(this.Y);
            }
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public void UseSpell(Spell spell, string message)
        {
            if (spell.Span > 0)
            {
                NexonClientPacket packet2 = new NexonClientPacket(this, 0x4d);
                packet2.WriteU1(spell.Span);
                packet2.WriteU1(0);
                base.Server.Send(packet2);
                for (int i = spell.Span / 8; i > 0; i--)
                {
                    Thread.Sleep(500);
                }
                this.Chant(spell.Name);
            }
            NexonClientPacket packet = new NexonClientPacket(this, 15);
            packet.WriteU1(spell.Slot);
            packet.WriteC0(message);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public bool UseSpell(string name, Sprite target = null)
        {
            Spell spell;
            if (this.TryGetSpell(name, out spell))
            {
                this.UseSpell(spell, target);
                return true;
            }
            return false;
        }

        public void UseSpell(string name, string message)
        {
            Spell spell;
            if (this.TryGetSpell(name, out spell))
            {
                this.UseSpell(spell, message);
            }
        }

        public void UseSpell(Spell spell, uint guid, ushort x, ushort y)
        {
            if (spell.Span > 0)
            {
                NexonClientPacket packet2 = new NexonClientPacket(this, 0x4d);
                packet2.WriteU1(spell.Span);
                packet2.WriteU1(0);
                base.Server.Send(packet2);
                if (((spell.Name.StartsWith("프라") || spell.Name.StartsWith("데프")) || spell.Name.StartsWith("바르도")) || spell.Name.StartsWith("렌토"))
                {
                    for (int i = spell.Span / 8; i > 0; i--)
                    {
                        Thread.Sleep(550);
                    }
                }
                else
                {
                    for (int i = spell.Span / 8; i > 0; i--)
                    {
                        Thread.Sleep(0x3e8);
                    }
                }
                this.Chant(spell.Name);
            }
            NexonClientPacket packet = new NexonClientPacket(this, 15);
            packet.WriteU1(spell.Slot);
            packet.WriteU4(guid);
            packet.WriteU2(x);
            packet.WriteU2(y);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public bool UseSpell(string name, uint guid, ushort x, ushort y)
        {
            Spell spell;
            if (this.TryGetSpell(name, out spell))
            {
                this.UseSpell(spell, guid, x, y);
                return true;
            }
            return false;
        }

        public void UseStock(Stock stock)
        {
            NexonClientPacket packet = new NexonClientPacket(this, 0x1c);
            packet.WriteU1(stock.Slot);
            packet.WriteU1(0);
            base.Server.Send(packet);
        }

        public bool UseStock(string name, byte type)
        {
            Stock stock;
            if (this.TryGetStockS(name, out stock))
            {
                this.UseStock(stock);
                return true;
            }
            return false;
        }

        public bool UseStock(string startname, string endname)
        {
            Stock stock;
            if (this.TryGetStock(startname, endname, out stock))
            {
                this.UseStock(stock);
                return true;
            }
            return false;
        }

        public bool UseStockE(string name)
        {
            Stock stock;
            if (this.TryGetStockE(name, out stock))
            {
                this.UseStock(stock);
                return true;
            }
            return false;
        }

        public bool UseStockS(string name)
        {
            Stock stock;
            if (this.TryGetStockS(name, out stock))
            {
                this.UseStock(stock);
                return true;
            }
            return false;
        }

        public void Walk(byte face, byte type = 0)
        {
            ushort x = this.X;
            ushort y = this.Y;
            this.Turn(face);
            NexonClientPacket packet = new NexonClientPacket(this, 6);
            packet.WriteU1(face);
            packet.WriteU1(0);
            base.Server.Send(packet);
            NexonServerPacket packet2 = new NexonServerPacket(this, 12);
            packet2.WriteU4(this.Guid);
            packet2.WriteU2(this.X);
            packet2.WriteU2(this.Y);
            packet2.WriteU1(face);
            packet2.WriteU1(0);
            base.Client.Send(packet2);
        }

        public int WhatisMyClass()
        {
            Skill skill;
            int num = -1;
            if (this.TryGetSkill("돌진", out skill) || (this.Name == "huntw"))
            {
                num = 0;
            }
            if (this.TryGetSkill("기습", out skill) || (this.Name == "huntr"))
            {
                num = 1;
            }
            if (this.TryGetSkill("연주", out skill) || (this.Name == "huntb") || (this.Name == "스낵"))
            {
                num = 2;
            }
            if (this.TryGetSkill("소환술", out skill) || (this.Name == "hunts"))
            {
                num = 3;
            }
            if (this.TryGetSkill("허공답보", out skill) || (this.Name == "huntm"))
            {
                num = 4;
            }
            return num;
        }

        public ProxyPatronSettings Settings { get; set; }

        public Doumi.Types.Field Field { get; set; }

        public FormPatron Form { get; set; }


        public void method_11(
         ProxyPatron gclass0_0,
         ushort ushort_2,
         ushort ushort_3,
         out ushort ushort_4,
         out ushort ushort_5,
         int int_1 = 30)
        {
            Field gclass220 = gclass0_0.Field;
            int index1;
            int index2;
            do
            {
                index1 = this.r.Next(3, (int)gclass220.Cols - 4);
                index2 = this.r.Next(3, (int)gclass220.Rows - 4);
            }
            while ((int)Math.Sqrt(Math.Pow((double)(index1 - (int)ushort_2), 2.0) + Math.Pow((double)(index2 - (int)ushort_3), 2.0)) >= int_1 || gclass220[index1, index2].Solid);
            ushort_4 = (ushort)index1;
            ushort_5 = (ushort)index2;
        }
    }
}

