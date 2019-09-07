namespace Doumi.Net
{
    using Doumi;
    using Doumi.Nexon.Net;
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class ProxyServer
    {
        private IPEndPoint clientEndPoint;
        private IPEndPoint serverEndPoint;
        private Socket socket;
        private Thread thread;

        public ProxyServer(IPAddress address, int port)
        {
            this.clientEndPoint = new IPEndPoint(IPAddress.Loopback, port);
            this.serverEndPoint = new IPEndPoint(address, port);
        }

        public void Abort()
        {
            this.socket.Close();
            this.socket = null;
            this.thread.Abort();
            this.thread.Join();
            this.thread = null;
        }

        private void Accept()
        {
            try
            {
                NexonSocket socket;
                goto Label_0097;
            Label_0007:
                socket = new NexonSocket(this.socket.Accept());
                ProxyPatron patron = new ProxyPatron(socket, new NexonSocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
                if (patron.Client.Connected)
                {
                    patron.Server.Connect(this.serverEndPoint);
                    if (patron.Server.Connected)
                    {
                        this.PatronConnected(patron);
                        patron.Client.BeginReceiveHeader(new AsyncCallback(this.ClientHeaderResult), patron);
                        patron.Server.BeginReceiveHeader(new AsyncCallback(this.ServerHeaderResult), patron);

                    }
                }
            Label_0097:
                goto Label_0007;
            }
            catch
            {
            }
        }

        private void Client0E(ProxyPatron patron, NexonPacket packet)
        {
            packet.Decrypt();
            packet.ReadU1();
            string str = packet.ReadC1();
            if ((str.Length > 1) && (str[0] == '/'))
            {
                patron.CommandReceived(str.Substring(1));
            }
            else
            {
                patron.Server.Send(packet);
            }
        }

        private void Client0F(ProxyPatron patron, NexonPacket packet)
        {
            byte slot = packet.ReadU1();
            if (patron.Spellbook[slot] == null)
            {
                Trace.WriteLine("Client attempted to use a null spell (#" + slot + ")");
            }
            else
            {
                patron.Spellbook.Use(slot);
                patron.Server.Send(packet);
            }
        }

        private void Client10(ProxyPatron patron, NexonPacket packet)
        {
            patron.Seed = packet.ReadU1();
            patron.Hash = packet.ReadB1();
            patron.Name = packet.ReadC1();
            if (!patron.Name.StartsWith("socket["))
            {
                Program.Form.EnqueuePatron(patron);
            }
            patron.Server.Send(packet);
        }

        private void Client1C(ProxyPatron patron, NexonPacket packet)
        {
            byte slot = packet.ReadU1();
            if (patron.Inventory[slot] == null)
            {
                Trace.WriteLine("Client attempted to use a null stock (# " + slot + ")");
            }
            else
            {
                patron.Inventory.Use(slot);
                patron.Server.Send(packet);
            }
        }

        private void Client2E(ProxyPatron patron, NexonPacket packet)
        {
            packet.ReadU1();
            string str = packet.ReadC1();
            byte num = packet.ReadU1();
            patron.Server.Send(packet);
            if (((num == 0) && (patron.Form != null)) && patron.Form.chk그룹원위치추적.Checked)
            {
                patron.GroupMemberPosUpdate_On();
            }
        }

        private void Client3A(ProxyPatron patron, NexonPacket packet)
        {
            packet.ReadU1();
            uint num = packet.ReadU4();
            uint num2 = packet.ReadU4();
            packet.ReadU1();
            uint num3 = packet.ReadU1();
            if (((num == 0x1389) && (num2 == 2)) && ((num3 > 0) && (num3 <= 5)))
            {
                patron.Server.Send(packet);
            }
            else
            {
                patron.Server.Send(packet);
            }
        }

        private void Client3E(ProxyPatron patron, NexonPacket packet)
        {
            byte slot = packet.ReadU1();
            if (patron.Skillbook[slot] == null)
            {
                Trace.WriteLine("Client attempted to use a null skill (#" + slot + ")");
            }
            else
            {
                patron.Skillbook.Use(slot);
                patron.Server.Send(packet);
            }
        }

        private void Client4D(ProxyPatron patron, NexonPacket packet)
        {
            NexonServerPacket packet2 = new NexonServerPacket(patron, 0x4d);
            packet2.WriteU1(0);
            packet2.WriteU1(0);
            patron.Client.Send(packet2);
        }

        private void ClientHeaderResult(IAsyncResult result)
        {
            ProxyPatron asyncState = result.AsyncState as ProxyPatron;
            NexonSocket client = asyncState.Client;
            if (client.EndReceiveHeader(result) == 0)
            {
                this.PatronDisconnected(asyncState);
            }
            else if (client.HeaderComplete)
            {
                 client.BeginReceivePacket(new AsyncCallback(this.ClientPacketResult), asyncState);
            }
            else
            {
                client.BeginReceiveHeader(new AsyncCallback(this.ClientHeaderResult), asyncState);
            }
        }

        private void ClientPacketResult(IAsyncResult result)
        {
            ProxyPatron asyncState = result.AsyncState as ProxyPatron;
            NexonSocket client = asyncState.Client;
            if (client.EndReceivePacket(result) == 0)
            {
                this.PatronDisconnected(asyncState);
            }
            else if (!client.PacketComplete)
            {
                client.BeginReceivePacket(new AsyncCallback(this.ClientPacketResult), asyncState);
            }
            else
            {
                asyncState.ClientPacketReceived(new NexonClientPacket(asyncState, client));
                client.BeginReceiveHeader(new AsyncCallback(this.ClientHeaderResult), asyncState);
            }
        }

        protected void PatronConnected(ProxyPatron patron)
        {
            patron.Initialize();
            patron.HookClient(14, new NexonPatron<ProxyPatron>.Handler(this.Client0E));
            patron.HookClient(15, new NexonPatron<ProxyPatron>.Handler(this.Client0F));
            patron.HookClient(0x10, new NexonPatron<ProxyPatron>.Handler(this.Client10));
            patron.HookClient(0x1c, new NexonPatron<ProxyPatron>.Handler(this.Client1C));
            patron.HookClient(0x2e, new NexonPatron<ProxyPatron>.Handler(this.Client2E));
            patron.HookClient(0x3e, new NexonPatron<ProxyPatron>.Handler(this.Client3E));
            patron.HookClient(0x3a, new NexonPatron<ProxyPatron>.Handler(this.Client3A));
            patron.HookServer(0, new NexonPatron<ProxyPatron>.Handler(this.Server00));
            patron.HookServer(3, new NexonPatron<ProxyPatron>.Handler(this.Server03));
            patron.HookServer(4, new NexonPatron<ProxyPatron>.Handler(this.Server04));
            patron.HookServer(5, new NexonPatron<ProxyPatron>.Handler(this.Server05));
            patron.HookServer(7, new NexonPatron<ProxyPatron>.Handler(this.Server07));
            patron.HookServer(8, new NexonPatron<ProxyPatron>.Handler(this.Server08));
            patron.HookServer(0x11, new NexonPatron<ProxyPatron>.Handler(this.Server11));//나르 코마?
            patron.HookServer(10, new NexonPatron<ProxyPatron>.Handler(this.Server0A));
            patron.HookServer(11, new NexonPatron<ProxyPatron>.Handler(this.Server0B));
            patron.HookServer(12, new NexonPatron<ProxyPatron>.Handler(this.Server0C));
            patron.HookServer(13, new NexonPatron<ProxyPatron>.Handler(this.Server0D));
            patron.HookServer(14, new NexonPatron<ProxyPatron>.Handler(this.Server0E));
            patron.HookServer(15, new NexonPatron<ProxyPatron>.Handler(this.Server0F));
            patron.HookServer(0x10, new NexonPatron<ProxyPatron>.Handler(this.Server10));
            patron.HookServer(0x13, new NexonPatron<ProxyPatron>.Handler(this.Server13));
            patron.HookServer(0x15, new NexonPatron<ProxyPatron>.Handler(this.Server15));
            patron.HookServer(0x17, new NexonPatron<ProxyPatron>.Handler(this.Server17));
            patron.HookServer(0x18, new NexonPatron<ProxyPatron>.Handler(this.Server18));
            patron.HookServer(0x1a, new NexonPatron<ProxyPatron>.Handler(this.Server1A));//모션
            patron.HookServer(0x29, new NexonPatron<ProxyPatron>.Handler(this.Server29));//타겟이펙트
            patron.HookServer(0x2c, new NexonPatron<ProxyPatron>.Handler(this.Server2C));
            patron.HookServer(0x2d, new NexonPatron<ProxyPatron>.Handler(this.Server2D));
            patron.HookServer(0x2f, new NexonPatron<ProxyPatron>.Handler(this.Server2F));
            patron.HookServer(0x30, new NexonPatron<ProxyPatron>.Handler(this.Server30));
            patron.HookServer(0x33, new NexonPatron<ProxyPatron>.Handler(this.Server33));
            patron.HookServer(0x37, new NexonPatron<ProxyPatron>.Handler(this.Server37));
            patron.HookServer(0x3a, new NexonPatron<ProxyPatron>.Handler(this.Server3A));
            patron.HookServer(0x3f, new NexonPatron<ProxyPatron>.Handler(this.Server3F));
            patron.HookServer(0x61, new NexonPatron<ProxyPatron>.Handler(this.Server61));
            patron.HookServer(0x63, new NexonPatron<ProxyPatron>.Handler(this.Server63));
            patron.HookServer(100, new NexonPatron<ProxyPatron>.Handler(this.Server64));
            patron.HookServer(139, new NexonPatron<ProxyPatron>.Handler(this.ServerT));
            patron.HookServer(140, new NexonPatron<ProxyPatron>.Handler(this.Server64));
        }

        protected void PatronDisconnected(ProxyPatron patron)
        {
            Program.Form.DequeuePatron(patron);
            if (patron.Client.Connected)
            {
                patron.Client.Disconnect(false);
            }
            if (patron.Server.Connected)
            {
                patron.Server.Disconnect(false);
            }
        }

        private void Server00(ProxyPatron patron, NexonPacket packet)
        {
            if (packet.ReadU1() == 0)
            {
                packet.ReadU4();
                patron.Seed = packet.ReadU1();
                patron.Hash = packet.ReadB1();
            }
            patron.Client.Send(packet);
        }

        private void Server03(ProxyPatron patron, NexonPacket packet)
        {
            packet.WriteU4(0x100007f);
            patron.Client.Send(packet);
        }

        private void Server04(ProxyPatron patron, NexonPacket packet)
        {
            packet.Decrypt();
            patron.OnPositionChanged(packet.ReadU2(), packet.ReadU2());
            packet.Code = patron.Server04;
            patron.Client.Send(packet);
        }

        private void Server05(ProxyPatron patron, NexonPacket packet)
        {
            packet.Decrypt();
            patron.Guid = packet.ReadU4();
            packet.Code = patron.Server05;
            patron.Client.Send(packet);
        }

        public void Server07(ProxyPatron patron, NexonPacket packet)
        {
            packet.Decrypt();
            if (patron.Field != null)
            {
                ushort num3 = packet.ReadU2();
                for (int i = 0; i < num3; i++)
                {
                    ushort xpos = packet.ReadU2();
                    ushort ypos = packet.ReadU2();
                    uint guid = packet.ReadU4();
                    ushort icon = packet.ReadU2();
                    if (icon >= 0x8000)
                    {
                        ushort tint = packet.ReadU2();
                        byte unka = packet.ReadU1();
                        string name = packet.ReadC1();
                        MapItem mapItem = new MapItem(xpos, ypos, guid, icon, tint, unka, name);
                        patron.Field.MapItems.AddOrUpdate(mapItem.Guid, mapItem, (key, value) => value.CopyFrom(mapItem));
                    }
                    else
                    {
                        uint unka = packet.ReadU4();
                        byte face = packet.ReadU1();
                        byte unkb = packet.ReadU1();
                        byte tint = packet.ReadU1();
                        byte unkc = packet.ReadU1();
                        byte type = packet.ReadU1();
                        if (type != 2)
                        {
                            Monster monster = new Monster(xpos, ypos, guid, icon, unka, face, unkb, tint, unkc, type);
                            patron.mMonster.WaitOne();
                            patron.Field.Monsters.AddOrUpdate(monster.Guid, monster, (key, value) => value.CopyFrom(monster));
                            patron.mMonster.ReleaseMutex();
                        }
                        else
                        {
                            string name = packet.ReadC1();
                            Mundane mundane = new Mundane(xpos, ypos, guid, icon, unka, face, unkb, tint, unkc, type, name);
                            patron.Field.Mundanes.AddOrUpdate(mundane.Guid, mundane, (key, value) => value.CopyFrom(mundane));
                        }
                    }
                }
            }
            packet.Code = patron.Server07;
            patron.Client.Send(packet);
        }

        private void Server08(ProxyPatron patron, NexonPacket packet)
        {
            packet.Decrypt();
            ushort num = 0;
            byte num2 = packet.ReadU1();
            uint num3 = 0;
            switch (num2)
            {
                case 4:
                    num = packet.ReadU2();
                    packet.ReadU2();
                    packet.ReadU2();
                    patron.CurrentOffenseAttribute.Set(packet.ReadU1());
                    patron.CurrentDefenceAttribute.Set(packet.ReadU1());
                    packet.ReadU1();
                    packet.ReadU1();
                    packet.ReadU1();
                    packet.ReadU1();
                    packet.ReadU1();
                    if (((patron.Form != null) && patron.Form.chk연막무시.Checked) && (num == 8))
                    {
                        return;
                    }
                    break;

                case 8:
                    patron.TotalEXP = packet.ReadU4();
                    num3 = packet.ReadU4();
                    packet.ReadU4();
                    packet.ReadU4();
                    packet.ReadU4();
                    packet.ReadU4();
                    packet.ReadU4();
                    patron.CurrentGold.Set(packet.ReadU4());
                    break;

                case 0x10:
                    patron.CurrentHP.Set(packet.ReadU4());
                    patron.CurrentMP.Set(packet.ReadU4());
                    break;

                case 0x11:
                    patron.CurrentHP.Set(packet.ReadU4());
                    patron.CurrentMP.Set(packet.ReadU4());
                    break;

                case 0x20:
                    packet.ReadU1();
                    packet.ReadU2();
                    patron.Lv = packet.ReadU1();
                    packet.ReadU1();
                    packet.ReadU1();
                    patron.MaximumHP.Set(packet.ReadU4());
                    patron.MaximumMP.Set(packet.ReadU4());
                    packet.ReadU2();
                    packet.ReadU2();
                    packet.ReadU2();
                    packet.ReadU2();
                    packet.ReadU2();
                    packet.ReadU2();
                    patron.MaxWeight.Set(packet.ReadU2());
                    patron.CurrentWeight.Set(packet.ReadU2());
                    packet.ReadU4();
                    break;

                case 0x24:
                    packet.ReadU1();
                    packet.ReadU2();
                    patron.Lv = packet.ReadU1();
                    packet.ReadU1();
                    packet.ReadU1();
                    patron.MaximumHP.Set(packet.ReadU4());
                    patron.MaximumMP.Set(packet.ReadU4());
                    packet.ReadU2();
                    packet.ReadU2();
                    packet.ReadU2();
                    packet.ReadU2();
                    packet.ReadU2();
                    packet.ReadU2();
                    patron.MaxWeight.Set(packet.ReadU2());
                    patron.CurrentWeight.Set(packet.ReadU2());
                    packet.ReadU4();
                    packet.ReadU4();
                    packet.ReadU2();
                    patron.CurrentOffenseAttribute.Set(packet.ReadU1());
                    patron.CurrentDefenceAttribute.Set(packet.ReadU1());
                    packet.ReadU1();
                    packet.ReadU1();
                    packet.ReadU1();
                    packet.ReadU1();
                    packet.ReadU1();
                    break;

                case 60:
                    packet.ReadU1();
                    packet.ReadU2();
                    patron.Lv = packet.ReadU1();
                    packet.ReadU1();
                    packet.ReadU1();
                    patron.MaximumHP.Set(packet.ReadU4());
                    patron.MaximumMP.Set(packet.ReadU4());
                    packet.ReadU2();
                    packet.ReadU2();
                    packet.ReadU2();
                    packet.ReadU2();
                    packet.ReadU2();
                    packet.ReadU2();
                    patron.MaxWeight.Set(packet.ReadU2());
                    patron.CurrentWeight.Set(packet.ReadU2());
                    packet.ReadU4();
                    patron.CurrentHP.Set(packet.ReadU4());
                    patron.CurrentMP.Set(packet.ReadU4());
                    patron.TotalEXP = packet.ReadU4();
                    num3 = packet.ReadU4();
                    packet.ReadU4();
                    packet.ReadU4();
                    packet.ReadU4();
                    packet.ReadU4();
                    packet.ReadU4();
                    patron.CurrentGold.Set(packet.ReadU4());
                    packet.ReadU4();
                    packet.ReadU2();
                    patron.CurrentOffenseAttribute.Set(packet.ReadU1());
                    patron.CurrentDefenceAttribute.Set(packet.ReadU1());
                    packet.ReadU1();
                    packet.ReadU1();
                    packet.ReadU1();
                    packet.ReadU1();
                    packet.ReadU1();
                    break;
            }
            packet.Code = patron.Server08;
            patron.Client.Send(packet);
            if (((patron.Form != null) && patron.Form.chk경팔체력.Checked) && (patron.TotalEXP > 0xfa56ea00))
            {
                new Thread(new ThreadStart(patron.SellExpForHP)).Start();
            }
            if (((patron.Form != null) && patron.Form.chk경팔마력.Checked) && (patron.TotalEXP > 0xfa56ea00))
            {
                new Thread(new ThreadStart(patron.SellExpForMP)).Start();
            }
        }

        private void Server0A(ProxyPatron patron, NexonPacket packet)
        {
            packet.Decrypt();
            //byte num = packet.ReadU1();
            //uint key = packet.ReadU4();
            //string text = packet.ReadC1();
            byte num = packet.ReadU1();
            string text = packet.ReadC2();
            switch (num)
            {
                case 0:
                    patron.PrivyMessageReceived(text);
                    break;

                case 3:
                    patron.SystemMessageReceived(text);
                    break;

                case 8:
                    patron.OnServerMessageReceived(text);
                    if (!((patron.Form != null) && patron.Form.chk시스템창.Checked))
                    {
                        break;
                    }
                    return;

                case 11:
                    patron.PartyMessageReceived(text);

                    if (text.Contains("코마") && ((patron.UseSpell("코마디아", (Sprite)null) && (patron.CurrentMP.Get() >= 520)) || patron.TryGetStockS("코마디움")))
                    {
                        string[] t = text.Split(' ');


                        if (t.Length >= 4)
                        {
                            ushort dx = 0;
                            ushort dy = 0;

                            foreach (var m in patron.GroupMembers)
                            {
                                if(m.Name == t[4])
                                {
                                    dx = (ushort)m.X;
                                    dy = (ushort)m.Y;
                                }
                            }

                            //ushort dx = (ushort)int.Parse(t[2]);
                            //ushort dy = (ushort)int.Parse(t[3]);


                            double introduced42 = Math.Pow((double)(dx - patron.X), 2.0);
                            //int num = (int)Math.Sqrt(introduced42 + Math.Pow((double)(dy - patron.Y), 2.0));

                            ushort x;
                            ushort y;
                            if ((((patron.X == dx) && (patron.Y == (dy + 1))) || ((patron.X == dx) && (patron.Y == (dy - 1)))) || (((patron.X == (dx + 1)) && (patron.Y == dy)) || (((patron.X - 1) == dx) && (patron.Y == dy))))
                            {
                                x = patron.X;
                                y = patron.Y;
                            }
                            else
                            {
                                if (!patron.Form.isAttackable(dx, dy))
                                {
                                    break;
                                }
                                if (patron.chooseClosePosition(patron, dx, dy, out x, out y, -1) && (patron.TryGetStockS("텔리포트의깃털") || patron.TryGetStockS("[TEST]테슬러의깃털(1일)")))
                                {
                                    patron.mTeleport.WaitOne();
                                    patron.MoveByTeleport(patron, x, y);
                                    patron.mTeleport.ReleaseMutex();
                                }
                            }
                            if ((y == (dy + 1)) && (x == dx))
                            {
                                patron.Turn(0);
                            }
                            if ((x == (dx - 1)) && (y == dy))
                            {
                                patron.Turn(1);
                            }
                            if ((y == (dy - 1)) && (x == dx))
                            {
                                patron.Turn(2);
                            }
                            if ((x == (dx + 1)) && (y == dy))
                            {
                                patron.Turn(3);
                            }
                            if ((patron.UseSpell("코마디아", (Sprite)null) && (patron.CurrentMP.Get() >= 520)) || patron.TryGetStockS("코마디움"))
                            {
                                patron.UseStockS("코마디움");
                            }
                            else
                            {
                                //patron.UseSpell("홀리쿠라노", pair.Value);
                            }
                        }


                    }

                    break;

                case 12:
                    patron.GuildMessageReceived(text);
                    break;
            }
            patron.Client.Send(packet);
            if (((((patron.Form != null) && patron.Form.chk걸리적.Checked) && ((num == 3) && text.StartsWith("걸리적"))) && !patron.Field.Name.StartsWith("카타콤")) && !patron.Field.Name.StartsWith("직업"))
            {
                ushort num3;
                ushort num4;
                patron.chooseNearPosition(patron, patron.X, patron.Y, -2, 2, out num3, out num4);
                patron.mTeleport.WaitOne();
                patron.MoveByTeleport(patron, num3, num4);
                patron.mTeleport.ReleaseMutex();
            }
        }

        private void Server0B(ProxyPatron patron, NexonPacket packet)
        {
            Aisling aisling;
            packet.Decrypt();
            byte num = packet.ReadU1();
            ushort num2 = packet.ReadU2();
            ushort num3 = packet.ReadU2();
            ushort num4 = packet.ReadU2();
            ushort num5 = packet.ReadU2();
            byte num6 = packet.ReadU1();
            if (((patron.Form != null) && patron.Form.SpeedFlag) && (patron.Form.Speed > 100))
            {
                NexonClientPacket packet2 = new NexonClientPacket(patron, 11);
                packet2.WriteU1(num);
                packet2.WriteU2(num2);
                packet2.WriteU2(num3);
                packet2.WriteU2(patron.Form.Speed);
                packet2.WriteU2(num5);
                packet2.WriteU1(num6);
                patron.Client.Send(packet2);
            }
            else
            {
                packet.Code = patron.Server0B;
                patron.Client.Send(packet);
            }
            patron.mAisling.WaitOne();
            if ((patron.Field != null) && patron.Field.Aislings.TryGetValue(patron.Guid, out aisling))
            {
                aisling.X = num2;
                aisling.Y = num3;
            }
            patron.mAisling.ReleaseMutex();
            patron.OnPositionChanged(num2, num3);
            if ((patron.Form != null) && patron.Form.chk동전깔기.Checked)
            {
                patron.DropMoney(1, num2, num3);
            }
        }

        private void Server0C(ProxyPatron patron, NexonPacket packet)
        {
            packet.Decrypt();
            bool flag = false;
            if (patron.Field != null)
            {
                Aisling aisling;
                Monster monster;
                Mundane mundane;
                uint key = packet.ReadU4();
                ushort num2 = packet.ReadU2();
                ushort num3 = packet.ReadU2();
                byte num4 = packet.ReadU1();
                patron.Client.Send(packet);
                switch (num4)
                {
                    case 0:
                        num3 = (ushort)(num3 - 1);
                        break;

                    case 1:
                        num2 = (ushort)(num2 + 1);
                        break;

                    case 2:
                        num3 = (ushort)(num3 + 1);
                        break;

                    case 3:
                        num2 = (ushort)(num2 - 1);
                        break;
                }
                patron.mAisling.WaitOne();
                if (patron.Field.Aislings.TryGetValue(key, out aisling))
                {
                    aisling.X = num2;
                    aisling.Y = num3;
                    aisling.Narcoli = false;
                    aisling.Soruma = false;
                    aisling.Coma = false;
                }
                patron.mAisling.ReleaseMutex();
                if ((((patron.Form != null) && patron.Form.chk유저회피.Checked) & flag) && ((aisling.Name == "") || (aisling.NameTint != 5)))
                {
                    ushort num6;
                    ushort num7;
                    patron.chooseFarPosition(patron, aisling.X, aisling.Y, out num6, out num7, 30);
                    patron.mTeleport.WaitOne();
                    patron.MoveByTeleport(patron, num6, num7);
                    patron.mTeleport.ReleaseMutex();
                }
                if ((((patron.Form != null) && patron.Form.chk노룹따라가기.Checked) && ((aisling != null) && (patron.Form.tbTarget.Text != null))) && (patron.Form.tbTarget.Text == aisling.Name))
                {
                    int num8 = (int)Math.Sqrt(Math.Pow((double)(aisling.X - patron.X), 2.0) + Math.Pow((double)(aisling.Y - patron.Y), 2.0));
                    if (num8 > 4)
                    {
                        ushort num9;
                        ushort num10;
                        patron.chooseFarPosition(patron, aisling.X, aisling.Y, out num9, out num10, 3);
                        patron.mTeleport.WaitOne();
                        patron.MoveByTeleport(patron, num9, num10);
                        patron.mTeleport.ReleaseMutex();
                    }
                }
                patron.mMonster.WaitOne();
                if (patron.Field.Monsters.TryGetValue(key, out monster))
                {
                    monster.X = num2;
                    monster.Y = num3;
                    monster.Face = num4;
                    monster.Narcoli = false;
                    monster.Soruma = false;
                }
                patron.mMonster.ReleaseMutex();
                if (patron.Field.Mundanes.TryGetValue(key, out mundane))
                {
                    mundane.X = num2;
                    mundane.Y = num3;
                }
            }
        }

        private void Server0D(ProxyPatron patron, NexonPacket packet)
        {
            Aisling aisling;
            packet.Decrypt();
            byte num = packet.ReadU1();
            uint key = packet.ReadU4();
            string text = packet.ReadC1();
            patron.Client.Send(packet);
            switch (num)
            {
                case 0:
                    {
                        patron.SpeakMessageReceived(text);
                        char[] separator = new char[] { ':', ' ' };
                        string[] strArray = text.Split(separator);
                        if (strArray.Length >= 3)
                        {
                            string str2 = strArray[0];
                            string str3 = strArray[2];
                            if ((((patron.Form != null) && str3.StartsWith(patron.Name)) && patron.Form.chkTalk1.Checked) && (patron.Form.tbTalk1.Text != null))
                            {
                                patron.Speak(patron.Form.tbTalk1.Text);
                            }
                            if ((((str3.StartsWith("ㄴ") || str3.StartsWith("s")) || str3.StartsWith("눈")) || str3.StartsWith("ㅇㄹ")) && patron.Field.Aislings.TryGetValue(key, out aisling))
                            {
                                aisling.Illumena = true;
                            }
                            if (str3.StartsWith("힐") && patron.Field.Aislings.TryGetValue(key, out aisling))
                            {
                                aisling.HPBar = 0;
                            }
                        }
                        break;
                    }
                case 1:
                    patron.ShoutMessageReceived(text);
                    break;

                case 2:
                    patron.ChantMessageReceived(text);
                    if ((text.StartsWith("힐") || text.StartsWith("ㅎ")) && patron.Field.Aislings.TryGetValue(key, out aisling))
                    {
                        aisling.HPBar = 0;
                    }
                    break;
            }
        }

        private void Server0E(ProxyPatron patron, NexonPacket packet)
        {
            Monster monster;
            Aisling aisling;
            Field field = patron.Field;
            uint key = packet.ReadU4();
            patron.Client.Send(packet);
            patron.mMonster.WaitOne();
            field.Monsters.TryRemove(key, out monster);
            patron.mMonster.ReleaseMutex();
            if ((monster == null) && !field.Aislings.TryRemove(key, out aisling))
            {
                MapItem item;
                field.MapItems.TryRemove(key, out item);
            }
        }

        private void Server0F(ProxyPatron patron, NexonPacket packet)
        {
            Stock item = new Stock(packet);
            patron.Client.Send(packet);
            patron.mInventory.WaitOne();
            patron.Inventory.Add(item);
            patron.mInventory.ReleaseMutex();
            if (((patron.Form != null) && patron.Form.chk자동루팅.Checked) && patron.Form.isTrashItem(item.Name))
            {
                patron.DropStock(item.Slot, patron.X, patron.Y, 0);
            }
        }

        private void Server10(ProxyPatron patron, NexonPacket packet)
        {
            patron.mInventory.WaitOne();
            patron.Inventory.Remove(packet.ReadU1());
            patron.Client.Send(packet);
            patron.mInventory.ReleaseMutex();
        }

        private void Server11(ProxyPatron patron, NexonPacket packet)
        {
            packet.Decrypt();
            if (patron.Field != null)
            {
                Aisling aisling;
                Monster monster;
                uint key = packet.ReadU4();
                byte num2 = packet.ReadU1();
                patron.Client.Send(packet);
                patron.mAisling.WaitOne();
                if (patron.Field.Aislings.TryGetValue(key, out aisling))
                {
                    aisling.Narcoli = false;
                    aisling.Soruma = false;
                    aisling.Coma = false;
                }
                patron.mAisling.ReleaseMutex();
                patron.mMonster.WaitOne();
                if (patron.Field.Monsters.TryGetValue(key, out monster))
                {
                    monster.Face = num2;
                    monster.Narcoli = false;
                    monster.Soruma = false;
                }
                patron.mMonster.ReleaseMutex();
            }
        }

        private void Server13(ProxyPatron patron, NexonPacket packet)
        {
            Aisling aisling;
            Monster monster;
            packet.ReadU4();
            uint key = packet.ReadU4();
            uint num2 = packet.ReadU4() >> 0x10;
            uint num3 = packet.ReadU2();
            packet.ReadU1();
            patron.Client.Send(packet);
            patron.mAisling.WaitOne();
            if (patron.Field.Aislings.TryGetValue(key, out aisling))
            {
                aisling.HPBar = num2;
                if (num3 > 0)
                {
                    aisling.Narcoli = false;
                }
            }
            patron.mAisling.ReleaseMutex();
            patron.mMonster.WaitOne();
            if (patron.Field.Monsters.TryGetValue(key, out monster) && (num3 > 0))
            {
                monster.HPBar = num2;
                monster.Narcoli = false;
            }
            patron.mMonster.ReleaseMutex();
        }

        private void Server15(ProxyPatron patron, NexonPacket packet)
        {
            Field field = new Field(packet);
            patron.Client.Send(packet);
            patron.OnChangeField(field);
        }

        private void Server17(ProxyPatron patron, NexonPacket packet)
        {
            Spell spell = new Spell(packet);
            patron.Client.Send(packet);
            patron.Spellbook.Add(spell);
            if (patron.Form.macroModule != null)
            {
                Program.Form.ThreadSafeInvoke(() => patron.Form.macroModule.lstSpells.Items[spell.Slot - 1].ImageIndex = spell.Icon);
            }
        }

        private void Server18(ProxyPatron patron, NexonPacket packet)
        {
            Spell spell = new Spell(packet);
            patron.Client.Send(packet);
            patron.Spellbook.Remove(spell.Slot);
            if (patron.Form.macroModule != null)
            {
                Program.Form.ThreadSafeInvoke(() => patron.Form.macroModule.lstSpells.Items[spell.Slot - 1].ImageIndex = -1);
            }
        }

        private void Server1A(ProxyPatron patron, NexonPacket packet)
        {
            Monster monster;
            Aisling aisling;
            packet.Decrypt();
            uint key = packet.ReadU4();
            if (((key != patron.Guid) || (patron.Form == null)) || !patron.Form.chk모션제거.Checked)
            {
                patron.Client.Send(packet);
            }
            patron.mAisling.WaitOne();
            if (patron.Field.Aislings.TryGetValue(key, out aisling))
            {
                aisling.Narcoli = false;
                aisling.Soruma = false;
                aisling.Coma = false;
            }
            patron.mAisling.ReleaseMutex();
            patron.mMonster.WaitOne();
            if (patron.Field.Monsters.TryGetValue(key, out monster))
            {
                monster.Narcoli = false;
                monster.Soruma = false;
            }
            patron.mMonster.ReleaseMutex();
        }

        private void Server29(ProxyPatron patron, NexonPacket packet)
        {
            packet.Decrypt();
            packet.ReadU1();
            uint guid = packet.ReadU4();
            uint num2 = packet.ReadU4();
            ushort effect = packet.ReadU2();
            patron.Client.Send(packet);
            patron.OnTargetEffectReceived(guid, effect);
            patron.OnCasterEffectReceived(num2, effect);
        }

        private void Server2C(ProxyPatron patron, NexonPacket packet)
        {
            Skill skill = new Skill(packet);
            patron.Client.Send(packet);
            patron.Skillbook.Add(skill);
            if (patron.Form.macroModule != null)
            {
                Program.Form.ThreadSafeInvoke(() => patron.Form.macroModule.lstSkills.Items[skill.Slot - 1].ImageIndex = skill.Icon);
            }
        }

        private void Server2D(ProxyPatron patron, NexonPacket packet)
        {
            Skill skill = new Skill(packet);
            patron.Client.Send(packet);
            patron.Skillbook.Remove(skill.Slot);
            if (patron.Form.macroModule != null)
            {
                Program.Form.ThreadSafeInvoke(() => patron.Form.macroModule.lstSkills.Items[skill.Slot - 1].ImageIndex = -1);
            }
        }

        private void Server2F(ProxyPatron patron, NexonPacket packet)
        {
            if (packet.ReadU1() == 5)
            {
                packet.ReadU1();
                packet.ReadU4();
                packet.ReadU1();
                packet.ReadU2();
                packet.ReadU2();
                packet.ReadU1();
                packet.ReadU2();
                packet.ReadU2();
                packet.ReadU1();
                packet.ReadC1();
                packet.ReadC2();
                packet.ReadU2();
                IEnumerable<byte> source = from e in patron.Inventory
                                           where e != null
                                           select e.Slot;
                packet.WriteU1((byte)source.Count<byte>());
                foreach (byte num in source)
                {
                    packet.WriteU1(num);
                }
                packet.WriteU1(0);
                packet.Length = packet.Offset;
            }
            else if (packet.ReadU1() == 1)
            {
                patron.ShopNpc = packet.ReadU4();
            }
            patron.Client.Send(packet);
        }


        private void Server30(ProxyPatron patron, NexonPacket packet)
        {
            byte num = packet.ReadU1();
            packet.ReadU1();
            patron.EXPNpc = packet.ReadU4();
            packet.ReadU1();
            packet.ReadU1();
            packet.ReadU1();
            packet.ReadU1();
            packet.ReadU1();
            packet.ReadU1();
            packet.ReadU1();
            packet.ReadU1();
            packet.ReadU1();
            packet.ReadU1();
            patron.NPCName = packet.ReadC1();

            if (patron.NPCName == "꼬마도우미")
            {
                NexonClientPacket packet3 = new NexonClientPacket(patron, 58);
                packet3.WriteU1(1);
                packet3.WriteU4(patron.EXPNpc);
                packet3.WriteU1(0);
                packet3.WriteU1(0);
                packet3.WriteU1(0);
                packet3.WriteU1(1);
                packet3.WriteU1(0);
                packet3.WriteU1(0);

                patron.Server.Send(packet3);

                if (patron.isLoad == false)
                {
                    patron.Form.Mil();
                }

            }



            patron.Client.Send(packet);

        }
        private void Server33(ProxyPatron patron, NexonPacket packet)
        {
            bool flag = false;
            Aisling aisling = new Aisling(packet);
            patron.mAisling.WaitOne();
            patron.Field.Aislings.AddOrUpdate(aisling.Guid, aisling, (key, value) => value.CopyFrom(aisling));
            patron.mAisling.ReleaseMutex();
            if (((aisling.Name == "") && (aisling.Guid != patron.Guid)) && ((patron.Form != null) && patron.Form.chk센서스핵.Checked))
            {
                packet = new NexonServerPacket(patron, 0x33);
                packet.WriteU2(aisling.X);
                packet.WriteU2(aisling.Y);
                packet.WriteU1(aisling.Face);
                packet.WriteU4(aisling.Guid);
                packet.WriteU1(aisling.Tint);
                packet.WriteU1(0);
                packet.WriteU2(0);
                packet.WriteU2(0);
                packet.WriteU1(80);
                packet.Offset += 0x30;
                packet.WriteU1(aisling.Type);
                packet.WriteC1("");
                packet.WriteU1(0);
                packet.WriteU1(0);
                packet.WriteU2(0);
                packet.WriteU2(0);
                packet.WriteU2(0);
            }
            if (aisling.Guid == patron.Guid)
            {
                patron.X = aisling.X;
                patron.Y = aisling.Y;
            }
            if ((((patron.Form != null) && patron.Form.chk걸리적.Checked) && ((aisling.Guid != patron.Guid) && (aisling.X == patron.X))) && (aisling.Y == patron.Y))
            {
                ushort num;
                ushort num2;
                patron.chooseNearPosition(patron, patron.X, patron.Y, -2, 2, out num, out num2);
                patron.mTeleport.WaitOne();
                patron.MoveByTeleport(patron, num, num2);
                patron.mTeleport.ReleaseMutex();
            }
            if (aisling.Guid == patron.Guid)
            {
                patron.NameTint = aisling.NameTint;
                if (patron.Form.TransformFlag)
                {
                    packet = new NexonServerPacket(patron, 0x33);
                    packet.WriteU2(aisling.X);
                    packet.WriteU2(aisling.Y);
                    packet.WriteU1(aisling.Face);
                    packet.WriteU4(aisling.Guid);
                    packet.WriteU1(aisling.Tint);
                    packet.WriteU1(0);
                    packet.WriteU2(0x30);
                    packet.WriteU2(0xffff);
                    packet.WriteU1(0x40);
                    packet.WriteU1(patron.Form.Transform);
                    packet.WriteU1(0);
                    packet.WriteU2(0);
                    packet.WriteU2(0);
                    packet.WriteU2(0);
                    packet.WriteU1(0);
                    packet.WriteU1(aisling.NameTint);
                    packet.WriteC1(aisling.Name);
                    packet.WriteU1(0);
                    packet.WriteU1(0);
                    packet.WriteU2(0);
                    packet.WriteU2(0);
                }
            }
            packet.Code = patron.Server33;
            patron.Client.Send(packet);
            if ((((patron.Form != null) && patron.Form.chk노룹따라가기.Checked) && (patron.Form.tbTarget.Text != null)) && (aisling.Name == patron.Form.tbTarget.Text))
            {
                int num3 = (int)Math.Sqrt(Math.Pow((double)(aisling.X - patron.X), 2.0) + Math.Pow((double)(aisling.Y - patron.Y), 2.0));
                if (num3 > 4)
                {
                    ushort num4;
                    ushort num5;
                    patron.chooseFarPosition(patron, aisling.X, aisling.Y, out num4, out num5, 3);
                    patron.mTeleport.WaitOne();
                    patron.MoveByTeleport(patron, num4, num5);
                    patron.mTeleport.ReleaseMutex();
                }
            }
            if ((((patron.Form != null) && patron.Form.chk유저회피.Checked) & flag) && ((aisling.Name == "") || (aisling.NameTint != 5)))
            {
                ushort num6;
                ushort num7;
                patron.chooseFarPosition(patron, aisling.X, aisling.Y, out num6, out num7, 30);
                patron.mTeleport.WaitOne();
                patron.MoveByTeleport(patron, num6, num7);
                patron.mTeleport.ReleaseMutex();
            }
            if ((((patron.Form != null) && (aisling.Guid == patron.Guid)) && (aisling.NameTint == 5)) && !patron.Form.chk그룹원위치추적.Checked)
            {
                Program.Form.ThreadSafeInvoke(() => patron.Form.chk그룹원위치추적.Checked = true);
            }
            if ((((patron.Form != null) && (aisling.Guid == patron.Guid)) && (aisling.NameTint != 5)) && patron.Form.chk그룹원위치추적.Checked)
            {
                Program.Form.ThreadSafeInvoke(() => patron.Form.chk그룹원위치추적.Checked = false);
            }
        }

        private void Server37(ProxyPatron patron, NexonPacket packet)
        {
            packet.ReadU1();
            Stock stock = new Stock(packet);
            patron.Client.Send(packet);
            double num = Math.Floor((double)((((double)stock.CurrentDurability) / ((double)stock.MaximumDurability)) * 100.0));
            if (((patron.Form != null) && patron.Form.chk원격수리.Checked) && (num < 50.0))
            {
                new Thread(new ThreadStart(patron.ItemRepair)).Start();
            }
        }

        private void Server38(ProxyPatron patron, NexonPacket packet)
        {
            byte num = packet.ReadU1();
            patron.Client.Send(packet);
        }

        private void Server3A(ProxyPatron patron, NexonPacket packet)
        {
            SpellEffect spellEffect = new SpellEffect(packet);
            if (spellEffect.Time == 0)
            {
                patron.OnSpellEffectRemoved(spellEffect);
            }
            else
            {
                patron.OnSpellEffectAdded(spellEffect);
            }
            patron.Client.Send(packet);
            if (((spellEffect.Time == 0) && (patron.Form != null)) && (patron.protectList != null))
            {
                patron.mBuff.WaitOne();
                if ((spellEffect.Name.StartsWith("엘리게이터") || spellEffect.Name.StartsWith("늑대")) || spellEffect.Name.StartsWith("독수리"))
                {
                    patron.protectList.is변신 = false;
                }
                if (spellEffect.Name.StartsWith("ExpBooster"))
                {
                    patron.protectList.is세토아가호 = false;
                }
                if (spellEffect.Name.StartsWith("ApBooster"))
                {
                    patron.protectList.is이아가호 = false;
                }
                if (spellEffect.Name.StartsWith("코마"))
                {
                    patron.protectList.is코마 = false;
                }
                if (spellEffect.Name.StartsWith("속성강화"))
                {
                    patron.protectList.is속성강화 = false;
                }
                if (spellEffect.Name.StartsWith("영혼약화"))
                {
                    patron.protectList.is영혼약화 = false;
                }
                if (spellEffect.Name.StartsWith("이모탈") || spellEffect.Name.StartsWith("금강불괴"))
                {
                    patron.protectList.is이모탈 = false;
                }
                if (spellEffect.Name.StartsWith("리플렉토") || spellEffect.Name.StartsWith("반탄신공"))
                {
                    patron.protectList.is리플렉토 = false;
                }
                if (spellEffect.Name.StartsWith("호르라마") || spellEffect.Name.StartsWith("자기보호"))
                {
                    patron.protectList.is호르라마 = false;
                }
                if (spellEffect.Name.StartsWith("콜라마") || spellEffect.Name.StartsWith("철포삼"))
                {
                    patron.protectList.is콜라마 = false;
                }
                if (spellEffect.Name.StartsWith("포트리스"))
                {
                    patron.protectList.is포트리스 = false;
                }
                if (spellEffect.Name.StartsWith("델리스펠라스"))
                {
                    patron.protectList.is델리스펠라스 = false;
                }
                if (spellEffect.Name.StartsWith("쿠랄툼"))
                {
                    patron.protectList.is쿠랄툼 = false;
                }
                if (spellEffect.Name.StartsWith("하이드"))
                {
                    patron.protectList.is하이드 = false;
                }
                if (spellEffect.Name.StartsWith("센서스"))
                {
                    patron.protectList.is센서스 = false;
                }
                if (spellEffect.Name.StartsWith("라이트닝무브") || spellEffect.Name.StartsWith("미종보법"))
                {
                    patron.protectList.is라이트닝무브 = false;
                }
                if (((spellEffect.Name.StartsWith("소루네아") || spellEffect.Name.StartsWith("소루마")) || spellEffect.Name.StartsWith("발경")) || spellEffect.Name.StartsWith("마비"))
                {
                    patron.protectList.is디소루마 = false;
                }
                if (spellEffect.Name.StartsWith("나르콜리"))
                {
                    patron.protectList.is디나르콜리 = false;
                }
                if ((spellEffect.Name.StartsWith("중독") || spellEffect.Name.StartsWith("독")) || spellEffect.Name.StartsWith("베노미"))
                {
                    patron.protectList.is디베노모 = false;
                }
                if (spellEffect.Name.StartsWith("일음") || spellEffect.Name.StartsWith("절망"))
                {
                    patron.protectList.is일루메나 = false;
                }
                if (spellEffect.Name.StartsWith("바티아"))
                {
                    patron.protectList.is바투 = false;
                }
                if (spellEffect.Name.StartsWith("렌"))
                {
                    patron.protectList.is렌토 = false;
                }
                if (spellEffect.Name.StartsWith("바르"))
                {
                    patron.protectList.is바르도 = false;
                }
                if (spellEffect.Name.StartsWith("데프"))
                {
                    patron.protectList.is데프레코 = false;
                }
                if (spellEffect.Name.StartsWith("프라"))
                {
                    patron.protectList.is프라보 = false;
                }
                if (spellEffect.Name.StartsWith("어둠의각인"))
                {
                    patron.protectList.is어둠의각인 = false;
                }
                if (spellEffect.Name.EndsWith("집중"))
                {
                    patron.protectList.is집중 = false;
                }
                if (spellEffect.Name.StartsWith("집중력"))
                {
                    patron.protectList.is집중력저하 = false;
                }
                if (spellEffect.Name.StartsWith("슈페이아움"))
                {
                    patron.protectList.is움 = false;
                }
                patron.mBuff.ReleaseMutex();
            }
            if (((spellEffect.Time != 0) && (patron.Form != null)) && (patron.protectList != null))
            {
                patron.mBuff.WaitOne();
                if ((spellEffect.Name.StartsWith("엘리게이터") || spellEffect.Name.StartsWith("늑대")) || spellEffect.Name.StartsWith("독수리"))
                {
                    patron.protectList.is변신 = true;
                }
                if (spellEffect.Name.StartsWith("ExpBooster"))
                {
                    patron.protectList.is세토아가호 = true;
                }
                if (spellEffect.Name.StartsWith("ApBooster"))
                {
                    patron.protectList.is이아가호 = true;
                }
                if (spellEffect.Name.StartsWith("코마"))
                {
                    patron.protectList.is코마 = true;
                }
                if (spellEffect.Name.StartsWith("속성강화"))
                {
                    patron.protectList.is속성강화 = true;
                }
                if (spellEffect.Name.StartsWith("영혼약화"))
                {
                    patron.protectList.is영혼약화 = true;
                }
                if (spellEffect.Name.StartsWith("이모탈") || spellEffect.Name.StartsWith("금강불괴"))
                {
                    patron.protectList.is이모탈 = true;
                }
                if (spellEffect.Name.StartsWith("리플렉토") || spellEffect.Name.StartsWith("반탄신공"))
                {
                    patron.protectList.is리플렉토 = true;
                }
                if (spellEffect.Name.StartsWith("호르라마") || spellEffect.Name.StartsWith("자기보호"))
                {
                    patron.protectList.is호르라마 = true;
                }
                if (spellEffect.Name.StartsWith("콜라마") || spellEffect.Name.StartsWith("철포삼"))
                {
                    patron.protectList.is콜라마 = true;
                }
                if (spellEffect.Name.StartsWith("포트리스"))
                {
                    patron.protectList.is포트리스 = true;
                }
                if (spellEffect.Name.StartsWith("델리스펠라스"))
                {
                    patron.protectList.is델리스펠라스 = true;
                }
                if (spellEffect.Name.StartsWith("쿠랄툼"))
                {
                    patron.protectList.is쿠랄툼 = true;
                }
                if (spellEffect.Name.StartsWith("하이드"))
                {
                    patron.protectList.is하이드 = true;
                }
                if (spellEffect.Name.StartsWith("센서스"))
                {
                    patron.protectList.is센서스 = true;
                }
                if (spellEffect.Name.StartsWith("라이트닝무브") || spellEffect.Name.StartsWith("미종보법"))
                {
                    patron.protectList.is라이트닝무브 = true;
                }
                if (((spellEffect.Name.StartsWith("소루네아") || spellEffect.Name.StartsWith("소루마")) || spellEffect.Name.StartsWith("발경")) || spellEffect.Name.StartsWith("마비"))
                {
                    patron.protectList.is디소루마 = true;
                }
                if (spellEffect.Name.StartsWith("나르콜리"))
                {
                    patron.protectList.is디나르콜리 = true;
                }
                if (spellEffect.Name.StartsWith("렌"))
                {
                    patron.protectList.is렌토 = true;
                }
                if (spellEffect.Name.StartsWith("바르"))
                {
                    patron.protectList.is바르도 = true;
                }
                if (spellEffect.Name.StartsWith("데프"))
                {
                    patron.protectList.is데프레코 = true;
                }
                if (spellEffect.Name.StartsWith("프라"))
                {
                    patron.protectList.is프라보 = true;
                }
                if (spellEffect.Name.StartsWith("어둠의각인"))
                {
                    patron.protectList.is어둠의각인 = true;
                }
                if ((spellEffect.Name.StartsWith("중독") || spellEffect.Name.StartsWith("독")) || spellEffect.Name.StartsWith("베노미"))
                {
                    patron.protectList.is디베노모 = true;
                }
                if (spellEffect.Name.StartsWith("일음") || spellEffect.Name.StartsWith("절망"))
                {
                    patron.protectList.is일루메나 = true;
                }
                if (spellEffect.Name.StartsWith("바티아"))
                {
                    patron.protectList.is바투 = true;
                }
                if (spellEffect.Name.EndsWith("집중"))
                {
                    patron.protectList.is집중 = true;
                }
                if (spellEffect.Name.StartsWith("집중력"))
                {
                    patron.protectList.is집중력저하 = true;
                }
                if (spellEffect.Name.StartsWith("슈페이아움"))
                {
                    patron.protectList.is움 = true;
                }
                patron.mBuff.ReleaseMutex();
            }
        }

        private void Server3F(ProxyPatron patron, NexonPacket packet)
        {
            packet.Decrypt();
            byte num = packet.ReadU1();
            byte num2 = packet.ReadU1();
            int num3 = packet.ReadS4();
            patron.Client.Send(packet);
            if (num2 > 0)
            {
                switch (num)
                {
                    case 0:
                        patron.Spellbook[num2].LastUsed = DateTime.Now;
                        patron.Spellbook[num2].Recharge = TimeSpan.FromSeconds(((double)num3) / 8.0);
                        break;

                    case 1:
                        patron.Skillbook[num2].LastUsed = DateTime.Now;
                        patron.Skillbook[num2].Recharge = TimeSpan.FromSeconds(((double)num3) / 8.0);
                        break;
                }
            }
        }

        private void Server61(ProxyPatron patron, NexonPacket packet)
        {
            packet.ReadU1();
            switch (packet.ReadU1())
            {
                case 0:
                    {
                        ushort num2 = packet.ReadU1();
                        packet.ReadU4();
                        byte num3 = packet.ReadU1();
                        for (int i = 0; i < num3; i++)
                        {
                            byte slot = packet.ReadU1();
                            ushort icon = packet.ReadU2();
                            ushort tint = packet.ReadU2();
                            string name = packet.ReadC1();
                            string meta = packet.ReadC1();
                            packet.ReadU2();
                            ushort mass = packet.ReadU2();
                            byte flag = packet.ReadU1();
                            uint maximumDurability = packet.ReadU4();
                            uint currentDurability = packet.ReadU4();
                            uint num12 = packet.ReadU1();
                            uint num13 = packet.ReadU2();
                            Stock stock = new Stock(slot, icon, tint, name, meta, mass, flag, maximumDurability, currentDurability, num12, num13);
                            patron.Bag.AddOrUpdate(stock.Slot, stock, (key, value) => value.CopyFrom(stock));
                        }
                        break;
                    }
                case 2:
                    {
                        byte slot = packet.ReadU1();
                        ushort icon = packet.ReadU2();
                        ushort tint = packet.ReadU2();
                        string name = packet.ReadC1();
                        string meta = packet.ReadC1();
                        packet.ReadU2();
                        ushort mass = packet.ReadU2();
                        byte flag = packet.ReadU1();
                        uint maximumDurability = packet.ReadU4();
                        uint currentDurability = packet.ReadU4();
                        uint num21 = packet.ReadU1();
                        uint num22 = packet.ReadU2();
                        Stock stock1 = new Stock(slot, icon, tint, name, meta, mass, flag, maximumDurability, currentDurability, num21, num22);
                        patron.Bag.AddOrUpdate(stock1.Slot, stock1, (key, value) => value.CopyFrom(stock1));
                        break;
                    }
                case 3:
                    {
                        Stock stock;
                        byte num23 = packet.ReadU1();
                        patron.Bag.TryRemove(num23, out stock);
                        break;
                    }
            }
            patron.Client.Send(packet);
        }

        public void Server63(ProxyPatron patron, NexonPacket packet)
        {
            if (packet.ReadU1() == 6)
            {
                byte num2 = packet.ReadU1();
                patron.mGroupMember.WaitOne();
                patron.GroupMembers.Clear();
                for (int i = 0; i < num2; i++)
                {
                    string name = packet.ReadC1();
                    string area = packet.ReadC1();
                    ushort x = packet.ReadU2();
                    ushort y = packet.ReadU2();
                    if (!name.Equals(patron.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        patron.GroupMembers.Add(new GroupMember(name, area, x, y));
                        patron.OnGroupMemberReceived(name, area, x, y);
                    }
                }
                patron.mGroupMember.ReleaseMutex();
            }
            packet.Code = patron.Server63;
            patron.Client.Send(packet);
        }

        private void Server64(ProxyPatron patron, NexonPacket packet)
        {
            packet.Decrypt();
            byte num = packet.ReadU1();
            if (packet.ReadU1() != 1)
            {
                patron.Client.Send(packet);
            }
            else
            {
                NexonClientPacket packet2 = new NexonClientPacket(patron, 0x6a);
                packet2.WriteU1(num);
                packet2.WriteU1(2);
                packet2.WriteU1(1);
                patron.Server.Send(packet2);
            }
        }

        private void ServerT(ProxyPatron patron, NexonPacket packet)
        {
            packet.Decrypt();
            byte num = packet.ReadU1();
            if (packet.ReadU1() != 1)
            {
                patron.Client.Send(packet);
            }
            else
            {
                NexonClientPacket packet2 = new NexonClientPacket(patron, 0x6a);
                packet2.WriteU1(num);
                packet2.WriteU1(2);
                packet2.WriteU1(1);
                patron.Server.Send(packet2);
            }
        }

        private void Server140(ProxyPatron patron, NexonPacket packet)
        {
            int num1 = (int)packet.ReadU1();
            int num2 = (int)packet.ReadU1();
            int num3 = (int)packet.ReadU2();
            int num4 = (int)packet.ReadU2();
            int num5 = (int)packet.ReadU1();
            int num6 = (int)packet.ReadU1();
            int num7 = (int)packet.ReadU1();
            int num8 = (int)packet.ReadU2();
            packet.ReadC1();
            packet.ReadC1();
            if (patron != null && patron.Form != null && num8 > 0)
            {
                patron.QuickPercentage = (double)(num8 / (int)100);
                System.Console.WriteLine(patron.QuickPercentage);
            }
            else if (patron != null && patron.Form != null)
            {
                patron.QuickPercentage = 0;
                System.Console.WriteLine("Null " + patron.QuickPercentage);

            }
            patron.Client.Send(packet);
        }

        private void Server6F(ProxyPatron patron, NexonPacket packet)
        {
            if (packet.ReadU1() == 1)
            {
                Metafile.List(packet);
            }
            patron.Client.Send(packet);
        }

        private void ServerHeaderResult(IAsyncResult result)
        {
            ProxyPatron asyncState = result.AsyncState as ProxyPatron;
            NexonSocket server = asyncState.Server;
            if (server.EndReceiveHeader(result) == 0)
            {
                this.PatronDisconnected(asyncState);
            }
            else if (server.HeaderComplete)
            {
                server.BeginReceivePacket(new AsyncCallback(this.ServerPacketResult), asyncState);
                
            }
            else
            {
                server.BeginReceiveHeader(new AsyncCallback(this.ServerHeaderResult), asyncState);
            }
        }

        private void ServerPacketResult(IAsyncResult result)
        {
            ProxyPatron asyncState = result.AsyncState as ProxyPatron;
            NexonSocket server = asyncState.Server;
            if (server.EndReceivePacket(result) == 0)
            {
                this.PatronDisconnected(asyncState);
            }
            else if (!server.PacketComplete)
            {
                server.BeginReceivePacket(new AsyncCallback(this.ServerPacketResult), asyncState);
            }
            else
            {
                asyncState.ServerPacketReceived(new NexonServerPacket(asyncState, server));
                server.BeginReceiveHeader(new AsyncCallback(this.ServerHeaderResult), asyncState);
            }
        }

        public void Start()
        {
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.socket.Bind(this.clientEndPoint);
            this.socket.Listen(30);
            this.thread = new Thread(new ThreadStart(this.Accept));
            this.thread.Start();
        }

        /*
        [Serializable, CompilerGenerated]
        private sealed class c
        {
            public static readonly ProxyServer.c 9= new ProxyServer.c();
            public static Func<Stock, bool> 9__41_0;
            public static Func<Stock, byte> 9__41_1;

            internal bool <Server2F>b__41_0(Stock e) => 
                (e != null);

            internal byte <Server2F>b__41_1(Stock e) => 
                e.Slot;
        }
        */
    }
}

