namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Nexon.Net;
    using Doumi.Types;
    using System.Threading;

    public class AutoExpSell
    {
        private bool _flag;
        private Thread _thread;
        private FormPatron _form;
        uint npc_SeonJin = 0;
        uint npc_Can = 0;
        uint npc_Seo = 0;
        uint npc_Upgrade = 0;
        int mClass = 0;
        int minHp = 0;
        int maxHp = 0;

        public AutoExpSell(ProxyPatron patron)
        {
            this.Patron = patron;
            this._form = patron.Form;

        }
        public void Start()
        {
            this._flag = true;
            this._thread = new Thread(new ThreadStart(this.Auto));
            this._thread.Start();
        }

        public void Abort()
        {
            this._flag = false;
            this._thread = null;
        }

        public void Auto()
        {
            if (this.Patron.TotalEXP >= 4290000000 && this.Patron.TryGetStockS("밀레스리콜") && !this.Patron.Field.Name.Contains("밀레스마을"))
            {
                this.Patron.UseStockS("밀레스리콜");
                Thread.Sleep(1000);
            }

            while ((this.Patron != null) && this._flag)
            {


                Field field = this.Patron.Field;

                SetHPValue();

                if (((field != null) && (field.Area != null)))
                {
                    if (field.Name.StartsWith("밀레스마을"))
                    {
                        Thread.Sleep(1000);
                        this.Patron.MoveByTeleport(this.Patron, 101, 17);
                        this.Patron.Walk(0, 0);
                        Thread.Sleep(350);
                    }
                    else if (field.Name.StartsWith("직업"))
                    {
                        foreach (var pair in field.Mundanes)
                        {
                            if (pair.Value.Name == "선진")
                            {
                                npc_SeonJin = pair.Value.Guid;
                                break;
                            }
                        }

                        if (_form.chkPoint.Checked == true && Patron.MaximumHP.Get() - 50 >= maxHp)
                        {
                            SendPacketSeonJin_Upgrage();
                        }
                        else
                        {
                            SendPacketSeonJin_Health();
                        }
                    }
                    else if (field.Name.StartsWith("신들의세계"))
                    {
                        if (this.Patron.Form.chk밀신경팔체.Checked == true)
                        {
                            int r = this.Patron.r.Next(0, 2);
                            this.Patron.MoveByTeleport(this.Patron, 23, 24 + r);
                            this.Patron.Walk(3, 0);
                            this.Patron.MoveByTeleport(this.Patron, 4, 4);
                        }
                        else if (this.Patron.Form.chk밀신경팔마.Checked == true)
                        {
                            int r = this.Patron.r.Next(0, 2);
                            this.Patron.MoveByTeleport(this.Patron, 13, 18 + r);
                            this.Patron.Walk(3, 0);
                            this.Patron.MoveByTeleport(this.Patron, 4, 4);
                        }
                    }
                    else if (field.Name.Contains("세오"))
                    {
                        foreach (var pair in field.Mundanes)
                        {
                            if (pair.Value.Name == "세오")
                            {
                                npc_Seo = pair.Value.Guid;
                                break;
                            }
                        }

                        if(_form.chkPoint.Checked == true)
                        {
                            if(Patron.MaximumHP.Get() - 50 >= maxHp )
                            {
                                NexonClientPacket packet31 = new NexonClientPacket(this.Patron, 58);
                                packet31.WriteU1(1);
                                packet31.WriteU4(npc_Seo);
                                packet31.WriteU1(0);
                                packet31.WriteU1(0);
                                packet31.WriteU1(0);
                                packet31.WriteU1(1);
                                packet31.WriteU1(0);

                                this.Patron.Server.Send(packet31);

                                Thread.Sleep(300);


                                if (this.Patron.TryGetStockS("밀레스리콜"))
                                {
                                    this.Patron.UseStockS("밀레스리콜");
                                }

                                Thread.Sleep(1000);
                                continue;
                            }
                        }

                        this.Patron.Chant("은총");
                        Thread.Sleep(10);

                        NexonClientPacket packet3 = new NexonClientPacket(this.Patron, 58);
                        packet3.WriteU1(1);
                        packet3.WriteU4(npc_Seo);
                        packet3.WriteU1(0);
                        packet3.WriteU1(0);
                        packet3.WriteU1(0);
                        packet3.WriteU1(2);
                        packet3.WriteU1(1);
                        packet3.WriteU1(1);
                        packet3.WriteU1(0);

                        this.Patron.Server.Send(packet3);

                        Thread.Sleep(1);

                        if (Patron.TotalEXP < 100000000)
                        {
                            Abort();
                        }
                    }
                    else if (field.Name.StartsWith("칸"))
                    {

                        foreach (var pair in field.Mundanes)
                        {
                            if (pair.Value.Name == "칸")
                            {
                                npc_Can = pair.Value.Guid;
                                break;
                            }
                        }

                        this.Patron.Chant("은총");
                        Thread.Sleep(10);

                        NexonClientPacket packet3 = new NexonClientPacket(this.Patron, 58);
                        packet3.WriteU1(1);
                        packet3.WriteU4(npc_Can);
                        packet3.WriteU1(0);
                        packet3.WriteU1(0);
                        packet3.WriteU1(0);
                        packet3.WriteU1(2);
                        packet3.WriteU1(1);
                        packet3.WriteU1(1);
                        packet3.WriteU1(0);
                        this.Patron.Server.Send(packet3);

                        Thread.Sleep(1);
                        if (Patron.TotalEXP < 100000000)
                        {
                            Abort();

                        }
                    }
                    else if(field.Name.Contains("승급신전"))
                    {
                        SendPacketPoint();
                    }
                }
            }
            if (this.Patron == null)
            {
                this.Abort();
            }
        }

        public ProxyPatron Patron { get; set; }

        void SendPacketSeonJin_Health()
        {
            this.Patron.Chant("체력");
            Thread.Sleep(100);

            NexonClientPacket packet1 = new NexonClientPacket(this.Patron, 58);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_SeonJin);
            packet1.WriteU1(1);
            packet1.WriteU1(0x53);
            packet1.WriteU1(0);
            packet1.WriteU1(1);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            NexonClientPacket packet2 = new NexonClientPacket(this.Patron, 58);
            packet2.WriteU1(1);
            packet2.WriteU4(npc_SeonJin);
            packet2.WriteU1(1);
            packet2.WriteU1(0x53);
            packet2.WriteU1(0);
            packet2.WriteU1(2);
            packet2.WriteU1(0);
            this.Patron.Server.Send(packet2);
            Thread.Sleep(100);

            NexonClientPacket packet3 = new NexonClientPacket(this.Patron, 58);
            packet3.WriteU1(1);
            packet3.WriteU4(npc_SeonJin);
            packet3.WriteU1(1);
            packet3.WriteU1(0x53);
            packet3.WriteU1(0);
            packet3.WriteU1(3);
            packet3.WriteU1(0);
            this.Patron.Server.Send(packet3);
            Thread.Sleep(100);

            NexonClientPacket packet4 = new NexonClientPacket(this.Patron, 58);
            packet4.WriteU1(1);
            packet4.WriteU4(npc_SeonJin);
            packet4.WriteU1(1);
            packet4.WriteU1(0x53);
            packet4.WriteU1(0);
            packet4.WriteU1(4);
            packet4.WriteU1(0);
            this.Patron.Server.Send(packet4);
            Thread.Sleep(100);

            NexonClientPacket packet5 = new NexonClientPacket(this.Patron, 58);
            packet5.WriteU1(1);
            packet5.WriteU4(npc_SeonJin);
            packet5.WriteU1(1);
            packet5.WriteU1(0x53);
            packet5.WriteU1(0);
            packet5.WriteU1(5);
            packet5.WriteU1(1);
            packet5.WriteU1(1);
            packet5.WriteU1(0);
            this.Patron.Server.Send(packet5);
            Thread.Sleep(100);

            NexonClientPacket packet6 = new NexonClientPacket(this.Patron, 58);
            packet6.WriteU1(1);
            packet6.WriteU4(npc_SeonJin);
            packet6.WriteU1(1);
            packet6.WriteU1(0x53);
            packet6.WriteU1(0);
            packet6.WriteU1(12);
            packet6.WriteU1(0);
            this.Patron.Server.Send(packet6);
            Thread.Sleep(100);

            NexonClientPacket packet7 = new NexonClientPacket(this.Patron, 58);
            packet7.WriteU1(1);
            packet7.WriteU4(npc_SeonJin);
            packet7.WriteU1(1);
            packet7.WriteU1(0x53);
            packet7.WriteU1(0);
            packet7.WriteU1(37);
            packet7.WriteU1(0);
            this.Patron.Server.Send(packet7);
            Thread.Sleep(100);

            NexonClientPacket packet8 = new NexonClientPacket(this.Patron, 58);
            packet8.WriteU1(1);
            packet8.WriteU4(npc_SeonJin);
            packet8.WriteU1(1);
            packet8.WriteU1(0x53);
            packet8.WriteU1(0);
            packet8.WriteU1(38);
            packet8.WriteU1(0);
            this.Patron.Server.Send(packet8);

            Thread.Sleep(100);
            NexonClientPacket packet9 = new NexonClientPacket(this.Patron, 58);
            packet9.WriteU1(1);
            packet9.WriteU4(npc_SeonJin);
            packet9.WriteU1(1);
            packet9.WriteU1(0x53);
            packet9.WriteU1(0);
            packet9.WriteU1(39);
            packet9.WriteU1(0);
            this.Patron.Server.Send(packet9);
            Thread.Sleep(100);
            NexonClientPacket packet10 = new NexonClientPacket(this.Patron, 58);
            packet10.WriteU1(1);
            packet10.WriteU4(npc_SeonJin);
            packet10.WriteU1(1);
            packet10.WriteU1(0x53);
            packet10.WriteU1(0);
            packet10.WriteU1(40);
            packet10.WriteU1(1);
            packet10.WriteU1(1);
            packet10.WriteU1(0);
            this.Patron.Server.Send(packet10);
            Thread.Sleep(100);
            NexonClientPacket packet11 = new NexonClientPacket(this.Patron, 58);
            packet11.WriteU1(1);
            packet11.WriteU4(npc_SeonJin);
            packet11.WriteU1(1);
            packet11.WriteU1(0x53);
            packet11.WriteU1(0);
            packet11.WriteU1(48);
            packet11.WriteU1(0);
            this.Patron.Server.Send(packet11);
            Thread.Sleep(100);
            NexonClientPacket packet12 = new NexonClientPacket(this.Patron, 58);
            packet12.WriteU1(1);
            packet12.WriteU4(npc_SeonJin);
            packet12.WriteU1(1);
            packet12.WriteU1(0x53);
            packet12.WriteU1(0);
            packet12.WriteU1(53);
            packet12.WriteU1(0);
            this.Patron.Server.Send(packet12);
            Thread.Sleep(100);
            NexonClientPacket packet13 = new NexonClientPacket(this.Patron, 58);
            packet13.WriteU1(1);
            packet13.WriteU4(npc_SeonJin);
            packet13.WriteU1(1);
            packet13.WriteU1(0x53);
            packet13.WriteU1(0);
            packet13.WriteU1(54);
            packet13.WriteU1(0);
            this.Patron.Server.Send(packet13);
            Thread.Sleep(100);
            NexonClientPacket packet14 = new NexonClientPacket(this.Patron, 58);
            packet14.WriteU1(1);
            packet14.WriteU4(npc_SeonJin);
            packet14.WriteU1(1);
            packet14.WriteU1(0x53);
            packet14.WriteU1(0);
            packet14.WriteU1(55);
            packet14.WriteU1(0);
            this.Patron.Server.Send(packet14);
            Thread.Sleep(100);
            NexonClientPacket packet15 = new NexonClientPacket(this.Patron, 58);
            packet15.WriteU1(1);
            packet15.WriteU4(npc_SeonJin);
            packet15.WriteU1(1);
            packet15.WriteU1(0x53);
            packet15.WriteU1(0);
            packet15.WriteU1(56);
            packet15.WriteU1(0);
            this.Patron.Server.Send(packet15);
            Thread.Sleep(100);
            NexonClientPacket packet16 = new NexonClientPacket(this.Patron, 58);
            packet16.WriteU1(1);
            packet16.WriteU4(npc_SeonJin);
            packet16.WriteU1(1);
            packet16.WriteU1(0x53);
            packet16.WriteU1(0);
            packet16.WriteU1(57);
            packet16.WriteU1(0);
            this.Patron.Server.Send(packet16);
            Thread.Sleep(350);
        }

        void SendPacketSeonJin_Upgrage()
        {
            this.Patron.Chant("승급");
            Thread.Sleep(100);

            NexonClientPacket packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_SeonJin);
            packet1.WriteU1(1);
            packet1.WriteU1(0x56);
            packet1.WriteU1(0);
            packet1.WriteU1(0x4);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_SeonJin);
            packet1.WriteU1(1);
            packet1.WriteU1(0x56);
            packet1.WriteU1(0);
            packet1.WriteU1(0x5);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_SeonJin);
            packet1.WriteU1(1);
            packet1.WriteU1(0x56);
            packet1.WriteU1(0);
            packet1.WriteU1(0x6);
            packet1.WriteU1(1);
            packet1.WriteU1(1);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_SeonJin);
            packet1.WriteU1(1);
            packet1.WriteU1(0x56);
            packet1.WriteU1(0);
            packet1.WriteU1(0x0d);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_SeonJin);
            packet1.WriteU1(1);
            packet1.WriteU1(0x56);
            packet1.WriteU1(0);
            packet1.WriteU1(0x24);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_SeonJin);
            packet1.WriteU1(1);
            packet1.WriteU1(0x56);
            packet1.WriteU1(0);
            packet1.WriteU1(0x25);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_SeonJin);
            packet1.WriteU1(1);
            packet1.WriteU1(0x56);
            packet1.WriteU1(0);
            packet1.WriteU1(0x26);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_SeonJin);
            packet1.WriteU1(1);
            packet1.WriteU1(0x56);
            packet1.WriteU1(0);
            packet1.WriteU1(0x27);
            packet1.WriteU1(1);
            packet1.WriteU1(1);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_SeonJin);
            packet1.WriteU1(1);
            packet1.WriteU1(0x56);
            packet1.WriteU1(0);
            packet1.WriteU1(0x2f);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_SeonJin);
            packet1.WriteU1(1);
            packet1.WriteU1(0x56);
            packet1.WriteU1(0);
            packet1.WriteU1(0x34);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_SeonJin);
            packet1.WriteU1(1);
            packet1.WriteU1(0x56);
            packet1.WriteU1(0);
            packet1.WriteU1(0x35);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_SeonJin);
            packet1.WriteU1(1);
            packet1.WriteU1(0x56);
            packet1.WriteU1(0);
            packet1.WriteU1(0x36);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_SeonJin);
            packet1.WriteU1(1);
            packet1.WriteU1(0x56);
            packet1.WriteU1(0);
            packet1.WriteU1(0x37);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);


            Thread.Sleep(350);
        }

        void SendPacketPoint()
        {
            if (_form.chkSTR.Checked == false &&
                _form.chkCON.Checked == false &&
                _form.chkINT.Checked == false &&
                _form.chkWIS.Checked == false &&
                _form.chkDEX.Checked == false)
                return;

            foreach (var pair in Patron.Field.Mundanes)
            {
                npc_Upgrade = pair.Value.Guid;
                break;
            }

            this.Patron.Chant("능력");
            Thread.Sleep(100);

            NexonClientPacket packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_Upgrade);
            packet1.WriteU1(1);
            packet1.WriteU1(0x95);
            packet1.WriteU1(0);
            packet1.WriteU1(0x5);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_Upgrade);
            packet1.WriteU1(1);
            packet1.WriteU1(0x95);
            packet1.WriteU1(0);
            packet1.WriteU1(0x6);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_Upgrade);
            packet1.WriteU1(1);
            packet1.WriteU1(0x95);
            packet1.WriteU1(0);
            packet1.WriteU1(0x7);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_Upgrade);
            packet1.WriteU1(1);
            packet1.WriteU1(0x95);
            packet1.WriteU1(0);


            //체력측정
            if (mClass == 0)
            {
                packet1.WriteU1(0x23);
            }
            else if (mClass == 1)
            {
                packet1.WriteU1(0x56);
            }
            else if (mClass == 2)
            {
                packet1.WriteU1(0xac);
            }
            else if (mClass == 3)
            {
                packet1.WriteU1(0x81);
            }
            else if (mClass == 4)
            {
                packet1.WriteU1(0xd7);
            }

            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_Upgrade);
            packet1.WriteU1(1);
            packet1.WriteU1(0x95);
            packet1.WriteU1(0);
            if (mClass == 0)
            {
                packet1.WriteU1(0x2b);
            }
            else if (mClass == 1)
            {
                packet1.WriteU1(0x5c);
            }
            else if (mClass == 2)
            {
                packet1.WriteU1(0xb2);
            }
            else if (mClass == 3)
            {
                packet1.WriteU1(0x87);
            }
            else if (mClass == 4)
            {
                packet1.WriteU1(0xdd);

            }

            packet1.WriteU1(1);

            if(_form.chkSTR.Checked == true)
            {
                packet1.WriteU1(1);
            }
            else if (_form.chkCON.Checked == true)
            {
                packet1.WriteU1(2);
            }
            else if (_form.chkINT.Checked == true)
            {
                packet1.WriteU1(3);
            }
            else if (_form.chkWIS.Checked == true)
            {
                packet1.WriteU1(4);
            }
            else if (_form.chkDEX.Checked == true)
            {
                packet1.WriteU1(5);
            }
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);


            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_Upgrade);
            packet1.WriteU1(1);
            packet1.WriteU1(0x95);
            packet1.WriteU1(0);
            packet1.WriteU1(0x8);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            packet1 = new NexonClientPacket(this.Patron, 0x3a);
            packet1.WriteU1(1);
            packet1.WriteU4(npc_Upgrade);
            packet1.WriteU1(1);
            packet1.WriteU1(0x95);
            packet1.WriteU1(0);
            packet1.WriteU1(0x8);
            packet1.WriteU1(0);
            this.Patron.Server.Send(packet1);
            Thread.Sleep(100);

            if(Patron.MaximumHP.Get() <= minHp + 300)
            {
                if (this.Patron.TryGetStockS("밀레스리콜"))
                {
                    this.Patron.UseStockS("밀레스리콜");
                }
            }
        }

        void SetHPValue()
        {
            mClass = Patron.WhatisMyClass();
            minHp = 0;
            maxHp = 0;

            if (mClass == 0)
            {
                minHp = 17000;
                maxHp = 20000;
            }
            else if (mClass == 1)
            {
                minHp = 13000;
                maxHp = 16000;
            }
            else if (mClass == 2)
            {
                minHp = 13000;
                maxHp = 16000;
            }
            else if (mClass == 3)
            {
                minHp = 12000;
                maxHp = 15000;
            }
            else if (mClass == 4)
            {
                minHp = 16000;
                maxHp = 19000;
            }

        }
    }
}