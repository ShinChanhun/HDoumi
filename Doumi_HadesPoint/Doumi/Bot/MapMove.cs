namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Nexon.Net;
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class MapMove
    {
        private bool _flag;
        //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        //private ProxyPatron <Patron>k__BackingField;
        private Thread _thread;

        private FormPatron _form;

        public MapMove(ProxyPatron patron)
        {
            this.Patron = patron;
            _form = this.Patron.Form;
        }

        public void Abort()
        {
            this._flag = false;
            this._thread = null;
        }

        public void Auto()
        {
            try
            {
                while ((this.Patron != null) && this._flag)
                {
                    //this.Patron.GroupMemberPosUpdate_On();
                    Field field = this.Patron.Field;
                    if (((field != null) && (field.Area != null)) && this.Patron.Form.chk맵이동.Checked)
                    {
                        if (!field.Loaded)
                        {
                            this.Patron.Refresh();
                            Thread.Sleep(0x3e8);
                        }
                        else
                        {
                            if (this.Patron.Form.tb층.Text != String.Empty && this.Patron.Field.Name.Contains(this.Patron.Form.tb층.Text))
                            {
                                continue;
                            }

                            if (this.Patron.Field.Name.Contains("노엠") || this.Patron.Field.Name.Contains("아슬론"))
                            {
                                if (this.Patron.TryGetStockS("시장리콜"))
                                {
                                    this.Patron.UseStockS("시장리콜");
                                }
                            }

                            if (this.Patron.Field.Name.EndsWith("빛의신전002"))
                            {
                                uint guid = 0;
                                foreach (KeyValuePair<uint, Mundane> pair in field.Mundanes)
                                {
                                    if (pair.Value.Icon == 0x4028)
                                    {
                                        guid = pair.Value.Guid;
                                        break;
                                    }
                                }
                                NexonClientPacket packet = new NexonClientPacket(this.Patron, 0x43);
                                packet.WriteU1(1);
                                packet.WriteU4(guid);
                                packet.WriteU1(0);
                                this.Patron.Server.Send(packet);
                                Thread.Sleep(500);
                                for (byte i = 1; i < 4; i = (byte)(i + 1))
                                {
                                    packet = new NexonClientPacket(this.Patron, 0x3a);
                                    packet.WriteU1(1);
                                    packet.WriteU4(guid);
                                    packet.WriteU2(0xc1);
                                    packet.WriteU2(i);
                                    packet.WriteU2(0);
                                    this.Patron.Server.Send(packet);
                                    Thread.Sleep(100);
                                }
                                packet = new NexonClientPacket(this.Patron, 0x3a);
                                packet.WriteU1(1);
                                packet.WriteU4(guid);
                                packet.WriteU2(0xc1);
                                packet.WriteU2(5);
                                packet.WriteU1(1);
                                packet.WriteU1(1);
                                packet.WriteU1(0);
                                this.Patron.Server.Send(packet);
                                Thread.Sleep(100);
                            }
                            if (this.Patron.Field.Name.EndsWith("뮤레칸의방004"))
                            {
                                uint guid = 0;
                                foreach (KeyValuePair<uint, Mundane> pair2 in field.Mundanes)
                                {
                                    if (pair2.Value.Icon == 0x402d)
                                    {
                                        guid = pair2.Value.Guid;
                                        break;
                                    }
                                }
                                if (guid == 0)
                                {
                                    Thread.Sleep(0x3e8);
                                }
                                else
                                {
                                    NexonClientPacket packet = new NexonClientPacket(this.Patron, 0x43);
                                    packet.WriteU1(1);
                                    packet.WriteU4(guid);
                                    packet.WriteU1(0);
                                    this.Patron.Server.Send(packet);
                                    Thread.Sleep(500);
                                    for (byte i = 1; i < 6; i = (byte)(i + 1))
                                    {
                                        packet = new NexonClientPacket(this.Patron, 0x3a);
                                        packet.WriteU1(1);
                                        packet.WriteU4(guid);
                                        packet.WriteU2(0);
                                        packet.WriteU2(2);
                                        packet.WriteU2(0);
                                        this.Patron.Server.Send(packet);
                                        Thread.Sleep(100);
                                    }
                                    Thread.Sleep(300);
                                }
                            }


                            this.Patron.mTeleport.WaitOne();
                            Thread.Sleep(100);

                            if(field.Name.StartsWith("시장은행"))
                            {
                                if (this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)") == false )
                                {
                                    this.Patron.MoveToDestination(10, 5);

                                    uint guid = 0;
                                    foreach (KeyValuePair<uint, Mundane> pair2 in field.Mundanes)
                                    {
                                        if (pair2.Value.Name == "세리카")
                                        {
                                            guid = pair2.Value.Guid;
                                            break;
                                        }
                                    }

                                    this.Patron.Speak("주세요");

                                    NexonClientPacket packet = new NexonClientPacket(this.Patron, 0x3a);
                                    packet.WriteU1(1);
                                    packet.WriteU4(guid);
                                    packet.WriteU1(0);
                                    packet.WriteU1(0);
                                    packet.WriteU1(0);
                                    packet.WriteU1(2);
                                    packet.WriteU1(1);
                                    packet.WriteU1(2);
                                    packet.WriteU1(0);
                                    this.Patron.Server.Send(packet);
                                    this.Patron.PanelClose();
                                    

                                    Thread.Sleep(100);
                                }

                                if(this.Patron.TryGetStockS("[TEST]세토아의가호(Lev2)") == false)
                                {
                                    uint guid = 0;
                                    foreach (KeyValuePair<uint, Mundane> pair2 in field.Mundanes)
                                    {
                                        if (pair2.Value.Name == "세리카")
                                        {
                                            guid = pair2.Value.Guid;
                                            break;
                                        }
                                    }

                                    this.Patron.Speak("주세요");

                                    NexonClientPacket packet  = new NexonClientPacket(this.Patron, 0x3a);
                                    packet.WriteU1(1);
                                    packet.WriteU4(guid);
                                    packet.WriteU1(0);
                                    packet.WriteU1(0);
                                    packet.WriteU1(0);
                                    packet.WriteU1(2);
                                    packet.WriteU1(1);
                                    packet.WriteU1(9);
                                    packet.WriteU1(0);
                                    this.Patron.Server.Send(packet);
                                    this.Patron.PanelClose();
                                }

                            }


                            if (field.Name.StartsWith("시장2"))
                            {
                                //if(this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)") == false)
                                //{
                                //    this.Patron.MoveToDestination(9, 7);

                                //    Thread.Sleep(100);

                                //    continue;
                                //}

                                uint guid = 0;
                                foreach (KeyValuePair<uint, Mundane> pair2 in field.Mundanes)
                                {
                                    if (pair2.Value.Name == "백원만")
                                    {
                                        guid = pair2.Value.Guid;
                                        break;
                                    }
                                }

                                NexonClientPacket packet = new NexonClientPacket(this.Patron, 0x43);
                                packet.WriteU1(1);
                                packet.WriteU4(guid);
                                packet.WriteU1(0);
                                this.Patron.Server.Send(packet);
                                Thread.Sleep(100);

                                packet = new NexonClientPacket(this.Patron, 0x3a);
                                packet.WriteU1(1);
                                packet.WriteU4(guid);
                                packet.WriteU1(0);
                                packet.WriteU1(0);
                                packet.WriteU1(0);
                                packet.WriteU1(2);
                                packet.WriteU1(1);
                                packet.WriteU1(1);
                                packet.WriteU1(0);
                                this.Patron.Server.Send(packet);
                                Thread.Sleep(100);

                                packet = new NexonClientPacket(this.Patron, 0x3a);
                                packet.WriteU1(1);
                                packet.WriteU4(guid);
                                packet.WriteU1(0);
                                packet.WriteU1(0);
                                packet.WriteU1(0);
                                packet.WriteU1(2);
                                packet.WriteU1(1);
                                packet.WriteU1(1);
                                packet.WriteU1(0);
                                this.Patron.Server.Send(packet);
                                Thread.Sleep(100);

                                //this.Patron.MoveByTeleport(this.Patron, 7, 1);
                                //this.Patron.Walk(0, 0);
                            }
                            else if (field.Name.StartsWith("죽음의마을입구5"))
                            {
                                uint guid = 0;
                                foreach (KeyValuePair<uint, Mundane> pair2 in field.Mundanes)
                                {
                                    if (pair2.Value.Name == "적룡굴이동")
                                    {
                                        guid = pair2.Value.Guid;
                                        break;
                                    }
                                }

                                this.Patron.MoveByTeleport(this.Patron, 8, 8);

                                this.Patron.Speak("다 고쳐줘");

                                NexonClientPacket packet = new NexonClientPacket(this.Patron, 0x43);
                                packet.WriteU1(1);
                                packet.WriteU4(guid);
                                packet.WriteU1(0);
                                this.Patron.Server.Send(packet);
                                Thread.Sleep(100);

                                packet = new NexonClientPacket(this.Patron, 0x39);
                                packet.WriteU1(1);
                                packet.WriteU4(guid);
                                packet.WriteU1(0x04);
                                packet.WriteU1(0xe6);
                                packet.WriteU1(0);
                                packet.WriteU1(0);
                                this.Patron.Server.Send(packet);
                                Thread.Sleep(100);

                                packet = new NexonClientPacket(this.Patron, 0x3a);
                                packet.WriteU1(1);
                                packet.WriteU4(guid);
                                packet.WriteU1(0);
                                packet.WriteU1(0xe6);
                                packet.WriteU1(0);
                                packet.WriteU1(4);
                                packet.WriteU1(0);
                                this.Patron.Server.Send(packet);
                                Thread.Sleep(100);
                            }
                            else if (field.Name.StartsWith("적룡플라밋"))
                            {
                                Thread.Sleep(1000);
                                //승길
                                //this.Patron.MoveByTeleport(this.Patron, 2, 14);
                                //this.Patron.Walk(3, 0);

                                if (_form.check브론.Checked == true)
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 26, 13);
                                    this.Patron.Walk(1, 0);
                                }
                                else if (_form.check블루.Checked == true)
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 26, 16);
                                    this.Patron.Walk(1, 0);
                                }
                                else if (_form.check레드.Checked == true)
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 26, 22);
                                    this.Patron.Walk(1, 0);
                                }
                                else if (_form.check블랙.Checked == true)
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 26, 13);
                                    this.Patron.Walk(1, 0);
                                }
                            }
                            else if (field.Name.Contains("오피온"))
                            {
                                if (field.Name.EndsWith("오피온의굴1") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 0x43, 0x21);
                                    this.Patron.Walk(1, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴2") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 0x4c, 0x27);
                                    this.Patron.Walk(1, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴3-1") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 0x29, 0x2f);
                                    this.Patron.Walk(2, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴4") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 0x43, 0x30);
                                    this.Patron.Walk(1, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴5") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 0x4d, 0x27);
                                    this.Patron.Walk(1, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴6") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 0x44, 0x12);
                                    this.Patron.Walk(1, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴7") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 6, 0x3a);
                                    this.Patron.Walk(2, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴8") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 0x1d, 0x44);
                                    this.Patron.Walk(2, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴9") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 15, 0x4e);
                                    this.Patron.Walk(2, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴10") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 0x12, 0x62);
                                    this.Patron.Walk(2, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴11") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 0x4e, 0x26);
                                    this.Patron.Walk(1, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴20") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 0x62, 50);
                                    this.Patron.Walk(1, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴21") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 30, 0x4e);
                                    this.Patron.Walk(2, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴22") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 0x44, 6);
                                    this.Patron.Walk(1, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴23-1") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 30, 0x30);
                                    this.Patron.Walk(2, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴24") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 0x3a, 0x4e);
                                    this.Patron.Walk(2, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴25") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 30, 0x44);
                                    this.Patron.Walk(2, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴26") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 4, 40);
                                    this.Patron.Walk(3, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴27") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 5, 0x30);
                                    this.Patron.Walk(2, 0);
                                }
                                else if (field.Name.EndsWith("오피온의굴28") && !field.Name.StartsWith("블랙"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 1, 63);
                                    this.Patron.Walk(3, 0);

                                    //int num = this.Patron.WhatisMyClass();
                                    //if ((this.Patron.Form != null))
                                    //{
                                    //    switch (num)
                                    //    {
                                    //        case 0:
                                    //            this.Patron.Form.chk자동사냥.Checked = true;
                                    //            if (this.Patron.Form._hunt_Warrior == null)
                                    //            {
                                    //                this.Patron.Form._hunt_Warrior = new Hunt_Warrior(this.Patron);
                                    //                this.Patron.Form._hunt_Warrior.Start();
                                    //            }
                                    //            break;
                                    //        case 1:
                                    //            this.Patron.Form.chk자동사냥.Checked = true;

                                    //            if (this.Patron.Form._hunt_Rogue == null)
                                    //            {

                                    //                this.Patron.Form._hunt_Rogue = new Hunt_Rogue(this.Patron);
                                    //                this.Patron.Form._hunt_Rogue.Start();
                                    //            }
                                    //            break;
                                    //        //case 2:
                                    //        //    this.Patron.Form._hunt_Bard = new Hunt_Bard(this.Patron);
                                    //        //    this.Patron.Form._hunt_Bard.Start();
                                    //        //    break;

                                    //        //case 3:
                                    //        //    this.Patron.Form._hunt_Wizard = new Hunt_Wizard(this.Patron);
                                    //        //    this.Patron.Form._hunt_Wizard.Start();
                                    //        //    break;
                                    //        case 4:
                                    //            this.Patron.Form.chk자동사냥.Checked = true;

                                    //            if (this.Patron.Form._hunt_Monk == null)
                                    //            {

                                    //                this.Patron.Form._hunt_Monk = new Hunt_Monk(this.Patron);
                                    //                this.Patron.Form._hunt_Monk.Start();
                                    //            }
                                    //            break;
                                    //    }
                                    //}

                                }
                                //if (field.Name.EndsWith("블랙오피온의굴1"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 5, 0x30);
                                //    this.Patron.Walk(2, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴1"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 0x44, 15);
                                //    this.Patron.Walk(1, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴2"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 30, 1);
                                //    this.Patron.Walk(0, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴3"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x17);
                                //    this.Patron.Walk(1, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴4"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 0x1d, 5);
                                //    this.Patron.Walk(0, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴5"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 0x23, 8);
                                //    this.Patron.Walk(3, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴6"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 0x20, 1);
                                //    this.Patron.Walk(0, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴7"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 1, 0x1f);
                                //    this.Patron.Walk(3, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴8"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 0x19, 1);
                                //    this.Patron.Walk(0, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴9"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 0x17, 1);
                                //    this.Patron.Walk(0, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴10"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 1, 0x1b);
                                //    this.Patron.Walk(3, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴11"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 1, 30);
                                //    this.Patron.Walk(3, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴12"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 1, 0x19);
                                //    this.Patron.Walk(3, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴13"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 1, 0x4d);
                                //    this.Patron.Walk(3, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴14"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 1, 0x2f);
                                //    this.Patron.Walk(3, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴15"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 1, 0x2c);
                                //    this.Patron.Walk(3, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴16"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 0x1a, 1);
                                //    this.Patron.Walk(0, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴17"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 0x1a, 1);
                                //    this.Patron.Walk(0, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴18"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 1, 0x13);
                                //    this.Patron.Walk(3, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴19"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 0x1a, 1);
                                //    this.Patron.Walk(0, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴20"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 2, 1);
                                //    this.Patron.Walk(0, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴21"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 70, 1);
                                //    this.Patron.Walk(0, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴22"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 0x2e, 1);
                                //    this.Patron.Walk(0, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴23"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 0x1a, 1);
                                //    this.Patron.Walk(0, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴24"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 8, 1);
                                //    this.Patron.Walk(0, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴25"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 1, 0x1b);
                                //    this.Patron.Walk(3, 0);
                                //}
                                //if (field.Name.EndsWith("블랙오피온의굴26"))
                                //{
                                //    this.Patron.MoveByTeleport(this.Patron, 1, 50);
                                //    this.Patron.Walk(3, 0);
                                //}
                            }
                            else if (field.Name.StartsWith("죽음의마을지하마을"))
                            {
                                ////this.Patron.MoveByTeleport(this.Patron, 19, 14);
                                //Thread.Sleep(3000);
                                //string[] strArr = { "예언자미리암", "농부후안", "컴파일러입문", "추출하는폴", "브라운팜" };

                                //foreach(string str in strArr)
                                //{
                                //    bool compareG = false;
                                //    bool compareF = false;
                                //    this.Patron.mGroupMember.WaitOne();
                                //    this.Patron.GroupMemberPosUpdate_On();

                                //    if (str == this.Patron.Name) continue;

                                //    foreach (var groupMember in this.Patron.GroupMembers)
                                //    {
                                //        if (groupMember.Name == str) compareG = true;
                                //    }

                                //    if (compareG == true) continue;

                                //    foreach (var pair in this.Patron.Field.Aislings)
                                //    {
                                //        if (pair.Value.Name == str) compareF = true;
                                //    }

                                //    if (compareF == false) continue;


                                //    NexonClientPacket nexonClientPacket = new NexonClientPacket(this.Patron, (byte)46);
                                //    nexonClientPacket.WriteU1((byte)2);
                                //    nexonClientPacket.WriteC1(str.Trim());
                                //    nexonClientPacket.WriteU1((byte)0);
                                //    nexonClientPacket.WriteU1((byte)0);
                                //    this.Patron.Server.Send((NexonPacket)nexonClientPacket);
                                //    Thread.Sleep(500);
                                //    this.Patron.GroupMemberPosUpdate_Off();
                                //    this.Patron.mGroupMember.ReleaseMutex();

                                //}


                            }
                            else if (field.Name.Contains("죽음의마을1"))
                            {
                                Thread.Sleep(100);

                                this.Patron.MoveByTeleport(this.Patron, 43, 1);
                                this.Patron.Walk(0, 0);

                            }
                            else if (field.Name.Contains("죽음의마을2"))
                            {
                                Thread.Sleep(100);

                                this.Patron.MoveByTeleport(this.Patron, 61, 1);
                                this.Patron.Walk(0, 0);

                            }
                            else if (field.Name.Contains("죽음의마을3"))
                            {
                                Thread.Sleep(100);

                                this.Patron.MoveByTeleport(this.Patron, 53, 1);
                                this.Patron.Walk(0, 0);

                            }
                            else if (field.Name.Contains("죽음의마을4-1"))
                            {
                                Thread.Sleep(100);
                                this.Patron.MoveByTeleport(this.Patron, 5, 4);
                                this.Patron.Walk(3, 0);
                            }
                            else if (field.Name.Contains("죽음의마을4"))
                            {
                                Thread.Sleep(100);
                                int r = Patron.r.Next(0, 2);
                                this.Patron.MoveByTeleport(this.Patron, 28, 2 + r);
                                this.Patron.Walk(3, 0);

                            }

                            else if (field.Name.Contains("지하실1"))
                            {
                                Thread.Sleep(100);
                                this.Patron.MoveByTeleport(this.Patron, 10, 1);
                                this.Patron.Walk(0, 0);
                            }
                            else if (field.Name.Contains("죽음의마을던전"))
                            {
                                Thread.Sleep(100);
                                if (field.Name == "죽음의마을던전1")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 39, 2);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전2")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 89, 23);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전3")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 53, 2);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전4")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 28, 23);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전5")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 4, 31);
                                    this.Patron.Walk(3, 0);
                                }
                                else if (field.Name == "죽음의마을던전6")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 14, 29);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전7")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 47, 53);
                                    this.Patron.Walk(3, 0);
                                }
                                else if (field.Name == "죽음의마을던전8")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 47, 72);
                                    this.Patron.Walk(3, 0);
                                }
                                else if (field.Name == "죽음의마을던전9")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 60, 15);
                                    this.Patron.Walk(3, 0);
                                }
                                else if (field.Name == "죽음의마을던전10")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 57, 47);
                                    this.Patron.Walk(3, 0);
                                }
                                else if (field.Name == "죽음의마을던전11")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 69, 31);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전12")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 12, 9);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전13")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 60, 6);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전14")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 78, 9);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전15")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 83, 56);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전16")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 23, 2);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전17")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 60, 29);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전18")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 36, 71);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전19")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 82, 64);
                                    this.Patron.Walk(3, 0);
                                }
                                else if (field.Name == "죽음의마을던전20")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 83, 60);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전21")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 71, 17);
                                    this.Patron.Walk(3, 0);
                                }
                                else if (field.Name == "죽음의마을던전22")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 36, 76);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전23")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 69, 54);
                                    this.Patron.Walk(3, 0);
                                }
                                else if (field.Name == "죽음의마을던전24")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 56, 74);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전25")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 66, 34);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name == "죽음의마을던전26")
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 3, 12);
                                    this.Patron.Walk(3, 0);
                                }
                                else if (field.Name.Contains("죽음의마을던전27"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 85, 3);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name.Contains("죽음의마을던전28"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 14, 72);
                                    this.Patron.Walk(3, 0);
                                }
                                else if (field.Name.Contains("죽음의마을던전29"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 72, 45);
                                    this.Patron.Walk(3, 0);
                                }
                                else if (field.Name.Contains("죽음의마을던전30"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 77, 23);
                                }
                            }
                            else if (field.Name.StartsWith("죽음의마을"))
                            {
                                Thread.Sleep(100);

                                if (field.Name.Contains("32"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 34, 27);
                                    Thread.Sleep(1000);
                                    this.Patron.MoveByTeleport(this.Patron, 4, 2);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name.Contains("33"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 2, 3);
                                    this.Patron.Walk(3, 0);
                                }
                                else if (field.Name.Contains("34"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 26, 3);
                                    Thread.Sleep(1000);
                                    this.Patron.Walk(0, 0);
                                    this.Patron.Walk(0, 0);
                                }

                                else if (field.Name.Contains("35"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 44, 2);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name.Contains("37"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 23, 2);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name.Contains("38"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 2, 19);
                                    this.Patron.Walk(3, 0);
                                }

                                else if (field.Name.Contains("39"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 56, 31);
                                    Thread.Sleep(100);

                                    this.Patron.MoveByTeleport(this.Patron, 53, 2);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name.Contains("40"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 12, 1);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name.Contains("41"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 48, 60);
                                    Thread.Sleep(1000);
                                    this.Patron.MoveByTeleport(this.Patron, 75, 42);
                                    Thread.Sleep(1000);
                                    this.Patron.MoveByTeleport(this.Patron, 97, 69);
                                    Thread.Sleep(1000);
                                    this.Patron.Walk(1, 0);
                                }
                                else if (field.Name.Contains("42"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 2, 33);
                                    this.Patron.Walk(3, 0);
                                }

                                else if (field.Name.Contains("43"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 21, 2);
                                    Thread.Sleep(1000);

                                    this.Patron.Walk(0, 0);
                                    Thread.Sleep(100);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name.Contains("44"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 8, 1);
                                    this.Patron.Walk(0, 0);
                                }
                                else if (field.Name.Contains("45"))
                                {
                                    this.Patron.MoveByTeleport(this.Patron, 2, 22);
                                    Thread.Sleep(1000);

                                    this.Patron.Walk(3, 0);
                                    Thread.Sleep(100);
                                    this.Patron.Walk(3, 0);
                                }
                            }
                            this.Patron.mTeleport.ReleaseMutex();
                        }
                    }
                    Thread.Sleep(300);
                    if (this.Patron == null)
                    {
                        this.Abort();
                    }
                    //this.Patron.GroupMemberPosUpdate_Off();
                }
            }
            catch
            {
            }
        }

        public void Start()
        {
            this._flag = true;
            this._thread = new Thread(new ThreadStart(this.Auto));
            this._thread.Start();
        }

        public ProxyPatron Patron { get; set; }
    }
}

