namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Hunt_Monk
    {
        private readonly TimeSpan timeSpan_0 = new TimeSpan(0, 0, 36);
        private bool _flag;
        private Thread _thread;
        private ProxyPatron _proxyPatron;
        private DateTime dateTime_0;

        public Hunt_Monk(ProxyPatron patron)
        {
            this.Patron = patron;
        }

        public void Abort()
        {
            this._flag = false;
            this._thread = (Thread)null;
        }

        public void Start()
        {
            this._flag = true;
            this._thread = new Thread(new ThreadStart(this.Auto));
            this._thread.Start();
        }

        public ProxyPatron Patron { get; set; }


        private void Auto()
        {
            this.Patron.Form.chk자동보호.Checked = true;

            //this.Patron.Form.chk자동보호.Checked = true;
            //this.Patron.Form.chk변신.Checked = true;
            //this.Patron.Form.checkBox_27.Checked = false;
            //this.Patron.Form.checkBox_29.Checked = false;
            //this.Patron.Form.checkBox_22.Checked = false;
            //this.Patron.Form.checkBox_24.Checked = false;
            //this.Patron.Form.checkBox_15.Checked = true;
            Aisling gclass33;
            this.Patron.Field.Aislings.TryGetValue(this.Patron.Guid, out gclass33);
            Thread.Sleep(1000);
            uint key1 = 0;
            int num1 = 0;
            int num2 = 0;
            while (this.Patron.Form != null && this._flag)
            {
                int num3 = int.MaxValue;
                bool flag1 = false;
                uint key2 = 0;
                Field gclass220 = this.Patron.Field;
                Monster gclass35_1;
                gclass220.Monsters.TryGetValue(key1, out gclass35_1);
                this.Patron.mMonster.WaitOne();
                if (gclass35_1 == null)
                {
                    foreach (KeyValuePair<uint, Monster> keyValuePair in gclass220.Monsters)
                    {
                        int num4 = (int)Math.Sqrt(Math.Pow((double)((int)keyValuePair.Value.X - (int)this.Patron.X), 2.0) + Math.Pow((double)((int)keyValuePair.Value.Y - (int)this.Patron.Y), 2.0));
                        if (gclass220.method_1(keyValuePair.Value.Icon) && num4 < 8)
                        {
                            if (this.Patron.Form.CheckMonster(keyValuePair.Value.Icon) == false)
                            {
                                continue;
                            }
                            flag1 = true;
                        }
                        if (this.Patron.Field.method_1(keyValuePair.Value.Icon) && keyValuePair.Value.Tint == 1 && (num4 < num3 && this.Patron.Form.isAttackable((int)keyValuePair.Value.X, (int)keyValuePair.Value.X)))
                        {
                            if (this.Patron.Form.CheckMonster(keyValuePair.Value.Icon) == false)
                            {
                                continue;
                            }
                            num3 = num4;
                            key2 = keyValuePair.Key;
                        }
                    }
                    if (!flag1)
                    {
                        foreach (KeyValuePair<uint, Monster> keyValuePair in gclass220.Monsters)
                        {
                            int num4 = (int)Math.Sqrt(Math.Pow((double)((int)keyValuePair.Value.X - (int)this.Patron.X), 2.0) + Math.Pow((double)((int)keyValuePair.Value.Y - (int)this.Patron.Y), 2.0));
                            if (!this.Patron.Field.method_2(keyValuePair.Value.Icon) && keyValuePair.Value.Tint == 1 && (num4 < num3 && this.Patron.Form.isAttackable((int)keyValuePair.Value.X, (int)keyValuePair.Value.Y)))
                            {
                                if (this.Patron.Form.CheckMonster(keyValuePair.Value.Icon) == false)
                                {
                                    continue;
                                }
                                num3 = num4;
                                key2 = keyValuePair.Key;
                            }
                            if (num3 == 1)
                                break;
                        }
                    }
                }
                else
                {
                    num3 = (int)Math.Sqrt(Math.Pow((double)((int)gclass35_1.X - (int)this.Patron.X), 2.0) + Math.Pow((double)((int)gclass35_1.Y - (int)this.Patron.Y), 2.0));
                    key2 = gclass35_1.Guid;
                }
                Monster gclass35_2;
                gclass220.Monsters.TryGetValue(key2, out gclass35_2);
                if (gclass35_2 != null && (int)key1 == (int)gclass35_2.Guid)
                {
                    ++num1;
                    key1 = gclass35_2.Guid;
                }
                else if (gclass35_2 != null)
                {
                    num1 = 0;
                    key1 = gclass35_2.Guid;
                }
                if (num1 > 20)
                {
                    Monster gclass35_3;
                    gclass220.Monsters.TryRemove(key1, out gclass35_3);
                    num1 = 0;
                    num3 = int.MaxValue;
                }
                this.Patron.mMonster.ReleaseMutex();
                if (num3 != int.MaxValue && num3 < 9 && gclass35_2 != null)
                {
                    ushort ushort_4 = 999;
                    ushort ushort_5 = 62;
                    bool flag2 = false;
                    if (this.Patron.CurrentMP.Get() > 1440U && this.Patron.Form.chkShot.Checked)
                    {
                        if (!gclass35_2.Immortal)
                        {
                            Thread.Sleep(500);
                            this.Patron.UseSpell("쿠로토", (Sprite)gclass35_2);
                            this.Patron.UseSpell("다라밀공", (Sprite)gclass35_2);
                        }
                    }
                    else if (gclass220.Name.StartsWith("블랙오피온의굴8") && gclass35_2.X == (ushort)21 && gclass35_2.Y == (ushort)12)
                    {
                        Monster gclass35_3;
                        gclass220.Monsters.TryRemove(key1, out gclass35_3);
                    }
                    else if (this.Patron.Form.isNearPosition((int)this.Patron.X, (int)this.Patron.Y, (int)gclass35_2.X, (int)gclass35_2.Y))
                    {
                        ushort_4 = this.Patron.X;
                        ushort_5 = this.Patron.Y;
                        flag2 = true;
                    }
                    else if (this.Patron.chooseMinDistancePostion(this.Patron, gclass35_2.X, gclass35_2.Y, out ushort_4, out ushort_5))
                    {
                        if (!this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)") && !this.Patron.TryGetStockS("텔리포트의깃털"))
                        {
                            this.Patron.Form._moveX = (int)ushort_4;
                            this.Patron.Form._moveY = (int)ushort_5;
                            this.Patron.Form._moveFlag = true;
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            this.Patron.mTeleport.WaitOne();
                            this.Patron.MoveByTeleport(this.Patron, (int)ushort_4, (int)ushort_5);
                            this.Patron.mTeleport.ReleaseMutex();
                            flag2 = true;
                        }
                    }
                    if (flag2)
                    {
                        if ((int)ushort_4 == (int)gclass35_2.X && (int)ushort_5 == (int)gclass35_2.Y + 1)
                            this.Patron.Turn((byte)0);
                        if ((int)ushort_4 == (int)gclass35_2.X - 1 && (int)ushort_5 == (int)gclass35_2.Y)
                            this.Patron.Turn((byte)1);
                        if ((int)ushort_4 == (int)gclass35_2.X && (int)ushort_5 == (int)gclass35_2.Y - 1)
                            this.Patron.Turn((byte)2);
                        if ((int)ushort_4 == (int)gclass35_2.X + 1 && (int)ushort_5 == (int)gclass35_2.Y)
                            this.Patron.Turn((byte)3);
                        
                        if (!gclass35_2.Immortal)
                        {
                            this.Patron.UseSkill("파천각");
                            this.Patron.UseSkill("붕신선각");
                            this.Patron.UseSkill("연천단각");
                            this.Patron.UseSkill("허공답");
                            this.Patron.UseSkill("꼬리치기");
                            this.Patron.UseSkill("할퀴기");
                            this.Patron.UseSkill("포이즌어택");
                            this.Patron.UseSkill("마구때리기");
                            this.Patron.UseSkill("양손공격");
                            this.Patron.UseSkill("지열참");
                            this.Patron.UseSkill("쪼기");
                            this.Patron.UseSkill("매의위상");
                            this.Patron.UseSkill("윈드쉐이커");
                            if (this.Patron.Form.chkShot.Checked && this.dateTime_0 < DateTime.Now - this.timeSpan_0)
                            {
                                gclass35_2.Amnesia = false;
                                Thread.Sleep(500);
                                this.Patron.UseSkill("구양신공");
                                this.dateTime_0 = DateTime.Now;
                            }
                        }
                    }
                }
                else
                {
                    int num4 = 0;
                    foreach (KeyValuePair<uint, Monster> keyValuePair in gclass220.Monsters)
                    {
                        if ((int)Math.Sqrt(Math.Pow((double)((int)keyValuePair.Value.X - (int)this.Patron.X), 2.0) + Math.Pow((double)((int)keyValuePair.Value.Y - (int)this.Patron.Y), 2.0)) <= 8 && keyValuePair.Value.Tint == 1
                            && this.Patron.Form.CheckMonster(keyValuePair.Value.Icon) == true)
                        {
                            ++num4;
                        }
                        else
                        {
                            Monster gclass35_3;
                            gclass220.Monsters.TryRemove(keyValuePair.Value.X, out gclass35_3);
                        }
                    }
                    if (num4 > 0)
                    {
                        num2 = 0;
                        Thread.Sleep(3000);
                    }
                    else if (!this.Patron.Form.chk따라가기.Checked)
                    {
                        ushort ushort_4;
                        ushort ushort_5;
                        this.Patron.method_11(this.Patron, this.Patron.X, this.Patron.Y, out ushort_4, out ushort_5, 30);
                        if (!this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)") && !this.Patron.TryGetStockS("텔리포트의깃털"))
                        {
                            this.Patron.Form._moveX = (int)ushort_4;
                            this.Patron.Form._moveY = (int)ushort_5;
                            this.Patron.Form._moveFlag = true;
                        }
                        else
                        {
                            this.Patron.mTeleport.WaitOne();
                            this.Patron.MoveByTeleport(this.Patron, (int)ushort_4, (int)ushort_5);
                            this.Patron.mTeleport.ReleaseMutex();
                            ++num2;
                            Thread.Sleep(500);
                            if (this.Patron.Field.Name.Contains("[유리드]") && (DateTime.Now - this.Patron.Form.dateTime_1).TotalMinutes > 10.0)
                            {
                                this.Patron.mTeleport.WaitOne();
                                this.Patron.MoveByTeleport(this.Patron, this.Patron.Form.int_6, this.Patron.Form.int_7);
                                this.Patron.mTeleport.ReleaseMutex();
                                this.Patron.Form.dateTime_1 = DateTime.Now;
                                Thread.Sleep(3000);
                            }
                        }
                        Thread.Sleep(3000);
                    }
                }
                Thread.Sleep(550);
                if (this.Patron == null)
                    this.Abort();
            }
        }
    }
}