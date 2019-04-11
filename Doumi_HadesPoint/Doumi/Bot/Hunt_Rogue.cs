namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Hunt_Rogue
    {
        private readonly TimeSpan timeSpan_0 = new TimeSpan(0, 0, 36);
        private bool bool_0;
        private Thread thread_0;
        private int int_0;
        private int int_1;

        public Hunt_Rogue(ProxyPatron patron)
        {
            this.Patron = patron;
        }

        public void Abort()
        {
            this.bool_0 = false;
            this.thread_0 = (Thread)null;
        }

        public void Start()
        {
            this.bool_0 = true;
            this.thread_0 = new Thread(new ThreadStart(this.method_3));
            this.thread_0.Start();
        }

        public ProxyPatron Patron { get; set; }

        private void method_2(string string_0)
        {
        }

        private void method_3()
        {
            //this.Patron.Form.tbTarget.Text = "브라운팜";
            this.Patron.Form.chk자동보호.Checked = true;
            this.Patron.Form.chk시스템창.Checked = true;
            this.Patron.Form.chkShot.Checked = true;
            

            Aisling gclass33;
            this.Patron.Field.Aislings.TryGetValue(this.Patron.Guid, out gclass33);
            Thread.Sleep(1000);
            uint key1 = 0;
            int num1 = 0;
            int num2 = 0;
            Monster gclass35_1 = (Monster)null;
            while (this.Patron.Form != null && this.bool_0)
            {

                int cDis = int.MaxValue;
                bool flag1 = false;
                uint guid = 0;
                Field field = this.Patron.Field;
                Monster mMonster;
                field.Monsters.TryGetValue(key1, out mMonster);
                this.Patron.mMonster.WaitOne();
                if (mMonster == null)
                {
                    foreach (KeyValuePair<uint, Monster> pair in field.Monsters)
                    {
                        int num4 = (int)Math.Sqrt(Math.Pow((double)((int)pair.Value.X - (int)this.Patron.X), 2.0) + Math.Pow((double)((int)pair.Value.Y - (int)this.Patron.Y), 2.0));
                        if (field.method_1(pair.Value.Icon) && num4 < 8)
                        {
                            if (this.Patron.Form.CheckMonster(pair.Value.Icon) == false)
                            {
                                continue;
                            }
                            flag1 = true;
                        }
                        if (this.Patron.Field.method_1(pair.Value.Icon) && pair.Value.Tint == (byte)1 && (num4 < cDis && this.Patron.Form.isAttackable((int)pair.Value.X, (int)pair.Value.Y)))
                        {
                            if (this.Patron.Form.CheckMonster(pair.Value.Icon) == false)
                            {
                                continue;
                            }
                            cDis = num4;
                            guid = pair.Key;
                        }
                    }
                    if (!flag1)
                    {
                        foreach (KeyValuePair<uint, Monster> pair in field.Monsters)
                        {
                            int dis = (int)Math.Sqrt(Math.Pow((double)((int)pair.Value.X - (int)this.Patron.X), 2.0) + Math.Pow((double)((int)pair.Value.Y - (int)this.Patron.Y), 2.0));
                            if (!this.Patron.Field.method_2(pair.Value.Icon) && pair.Value.Tint == (byte)1 && (dis < cDis && this.Patron.Form.isAttackable((int)pair.Value.X, (int)pair.Value.Y)))
                            {
                                if (this.Patron.Form.CheckMonster(pair.Value.Icon) == false)
                                {
                                    continue;
                                }
                                cDis = dis;
                                guid = pair.Key;
                            }
                            if (cDis == 1)
                                break;
                        }
                    }
                }
                else
                {
                    cDis = (int)Math.Sqrt(Math.Pow((double)((int)mMonster.X - (int)this.Patron.X), 2.0) + Math.Pow((double)((int)mMonster.Y - (int)this.Patron.Y), 2.0));
                    guid = mMonster.Guid;
                }
                Monster m;
                field.Monsters.TryGetValue(guid, out m);
                if (m != null && (int)key1 == (int)m.Guid)
                {
                    ++num1;
                    key1 = m.Guid;
                }
                else if (m != null)
                {
                    num1 = 0;
                    key1 = m.Guid;
                }
                if (num1 > 20)
                {
                    Monster gclass35_4;
                    field.Monsters.TryRemove(key1, out gclass35_4);
                    num1 = 0;
                    cDis = int.MaxValue;
                }
                this.Patron.mMonster.ReleaseMutex();
                if (cDis != int.MaxValue && cDis < 9 && m != null)
                {
                    ushort x = 999;
                    ushort y = 62;
                    bool flag2 = false;
                    if (field.Name.StartsWith("블랙오피온의굴8") && m.X == (ushort)21 && m.Y == (ushort)12 && !this.Patron.Form.CheckMonster(m.Icon))
                    {
                        Monster m2;
                        field.Monsters.TryRemove(key1, out m2);
                    }
                    else if (this.Patron.Form.isNearPosition((int)this.Patron.X, (int)this.Patron.Y, (int)m.X, (int)m.Y))
                    {
                        x = this.Patron.X;
                        y = this.Patron.Y;
                        flag2 = true;
                    }
                    else if (this.Patron.chooseMinDistancePostion(this.Patron, m.X, m.Y, out x, out y))
                    {
                        if (!this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)") && !this.Patron.TryGetStockS("텔리포트의깃털"))
                        {
                            this.Patron.Form._moveX = (int)x;
                            this.Patron.Form._moveY = (int)y;
                            this.Patron.Form._moveFlag = true;
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            this.Patron.mTeleport.WaitOne();
                            this.Patron.MoveByTeleport(this.Patron, (int)x, (int)y);
                            this.Patron.mTeleport.ReleaseMutex();
                            flag2 = true;
                        }
                    }
                    if (flag2)
                    {
                        if ((int)x == (int)m.X && (int)y == (int)m.Y + 1)
                            this.Patron.Turn((byte)0);
                        else if ((int)x == (int)m.X - 1 && (int)y == (int)m.Y)
                            this.Patron.Turn((byte)1);
                        else if ((int)x == (int)m.X && (int)y == (int)m.Y - 1)
                            this.Patron.Turn((byte)2);
                        else if ((int)x == (int)m.X + 1 && (int)y == (int)m.Y)
                            this.Patron.Turn((byte)3);

                        if (gclass35_1 != m && this.Patron.CanUseSkill("센스몬스터"))
                        {
                            this.Patron.UseSkill("센스몬스터");
                            mMonster = m;
                        }

                        if (!m.Immortal)
                        {

                            Thread.Sleep(150);
                            this.Patron.UseSkill("아머크래쉬");
                            this.Patron.UseSkill("완전방어");
                            this.Patron.UseSkill("라이트닝트랩");
                            this.Patron.UseSkill("피닉스모드");

                            if (!this.Patron.protectList.is이모탈)
                            {
                                this.Patron.UseSpell("회심의저격", (Sprite)m);

                                //this.Patron.UseSkill("기본공격");
                                m.Amnesia = true;
                            }

                            if (m.Amnesia && this.Patron.CanUseSkill("아무네지아") && (this.Patron.CanUseSkill("기습") || this.Patron.CanUseSkill("습격") || (this.Patron.CanUseSkill("저격") || this.Patron.CanUseSkill("백스"))))
                            {
                                int num4 = 0;
                                int num5 = 0;
                                if ((int)this.Patron.X == (int)m.X && (int)this.Patron.Y == (int)m.Y + 1)
                                {
                                    num4 = (int)m.X;
                                    num5 = (int)m.Y + 2;
                                }
                                else if ((int)this.Patron.X == (int)m.X - 1 && (int)this.Patron.Y == (int)m.Y)
                                {
                                    num4 = (int)m.X - 2;
                                    num5 = (int)m.Y;
                                }
                                else if((int)this.Patron.X == (int)m.X && (int)this.Patron.Y == (int)m.Y - 1)
                                {
                                    num4 = (int)m.X;
                                    num5 = (int)m.Y - 2;
                                }
                                else if((int)this.Patron.X == (int)m.X + 1 && (int)this.Patron.Y == (int)m.Y)
                                {
                                    num4 = (int)m.X + 2;
                                    num5 = (int)m.Y;
                                }

                                if (!this.Patron.Field.IsSolid(num4, num5) && !this.Patron.Field.IsMonster(num4, num5) && !this.Patron.Field.IsAisling(num4, num5))
                                {
                                    this.Patron.mTeleport.WaitOne();
                                    this.Patron.MoveByTeleport(this.Patron, num4, num5);
                                    this.Patron.mTeleport.ReleaseMutex();
                                    if (num4 == (int)m.X && num5 == (int)m.Y + 2)
                                        this.Patron.Turn((byte)0);
                                    else if (num4 == (int)m.X - 2 && num5 == (int)m.Y)
                                        this.Patron.Turn((byte)1);
                                    else if (num4 == (int)m.X && num5 == (int)m.Y - 2)
                                        this.Patron.Turn((byte)2);
                                    else if (num4 == (int)m.X + 2 && num5 == (int)m.Y)
                                        this.Patron.Turn((byte)3);

                                    Thread.Sleep(300);

                                    if ((int)Math.Sqrt(Math.Pow((double)((int)this.Patron.X - (int)m.X), 2.0) + Math.Pow((double)((int)this.Patron.Y - (int)m.Y), 2.0)) == 2)
                                    {
                                        this.Patron.UseSkill("아무네지아");
                                        m.Amnesia = false;
                                    }
                                    this.Patron.mTeleport.WaitOne();
                                    this.Patron.MoveByTeleport(this.Patron, (int)x, (int)y);
                                    this.Patron.mTeleport.ReleaseMutex();
                                    if ((int)x == (int)m.X && (int)y == (int)m.Y + 1)
                                        this.Patron.Turn((byte)0);
                                    if ((int)x == (int)m.X - 1 && (int)y == (int)m.Y)
                                        this.Patron.Turn((byte)1);
                                    if ((int)x == (int)m.X && (int)y == (int)m.Y - 1)
                                        this.Patron.Turn((byte)2);
                                    if ((int)x == (int)m.X + 1 && (int)y == (int)m.Y)
                                        this.Patron.Turn((byte)3);
                                }
                            }

                            Thread.Sleep(1000);


                            if (this.Patron.CanUseSkill("기습"))
                            {
                                if (cDis > 1) continue;
                                this.Patron.UseSkill("기습");
                                m.Amnesia = true;

                                //this.Patron.UseSkill("기본공격");
                            }
                            else if (this.Patron.CanUseSkill("저격"))
                            {
                                if (cDis > 1) continue;
                                this.Patron.UseSkill("저격");
                                m.Amnesia = true;

                                //this.Patron.UseSkill("기본공격");
                            }
                            else if (this.Patron.CanUseSkill("백스"))
                            {
                                if (cDis > 1) continue;
                                this.Patron.UseSkill("백스");
                                m.Amnesia = true;

                                //this.Patron.UseSkill("기본공격");
                            }
                            else if (this.Patron.CanUseSkill("습격"))
                            {
                                if (cDis > 1) continue;
                                this.Patron.UseSkill("습격");
                                m.Amnesia = true;

                                //this.Patron.UseSkill("기본공격");
                            }
                            else if (this.Patron.Form.chkShot.Checked)
                            {
                                if (this.Patron.CanUseSkill("크래셔"))
                                {
                                    if (cDis > 1) continue;
                                    this.Patron.UseStockE("버섯");
                                    this.Patron.UseSkill("크래셔");
                                    this.Patron.UseSpell("쿠로토", (Sprite)m);
                                    m.Amnesia = true;

                                    //this.Patron.UseSkill("기본공격");
                                }
                                else if (this.Patron.CanUseSkill("매드소울"))
                                {
                                    if (cDis > 1) continue;
                                    this.Patron.UseSkill("매드소울");
                                    this.Patron.UseSpell("쿠로토", (Sprite)m);
                                    m.Amnesia = true;

                                    //this.Patron.UseSkill("기본공격");
                                }
                                else if (this.Patron.CanUseSkill("암살격"))
                                {
                                    if (cDis > 1) continue;
                                    this.Patron.UseSkill("암살격");
                                    this.Patron.UseSpell("쿠로토", (Sprite)m);
                                    m.Amnesia = true;

                                    //this.Patron.UseSkill("기본공격");
                                }
                            }
                        }
                    }
                }

                else
                {
                    int countMonster = 0;

                    foreach (KeyValuePair<uint, Monster> pair in this.Patron.Field.Monsters)
                    {
                        int num = (int)Math.Sqrt(Math.Pow((double)((int)pair.Value.X - (int)this.Patron.X), 2.0) + Math.Pow((double)((int)pair.Value.Y - (int)this.Patron.Y), 2.0));
                        if (num <= 8 && pair.Value.Tint == (byte)1 && this.Patron.Form.CheckMonster(pair.Value.Icon) == true)
                        {
                            ++countMonster;
                        }
                        else
                        {
                            Monster gclass35_4;
                            field.Monsters.TryRemove(pair.Value.Guid, out gclass35_4);
                        }
                    }
                    if (countMonster > 0)
                    {
                        num2 = 0;
                        Thread.Sleep(3000);
                    }
                    else if (!this.Patron.Form.chk따라가기.Checked)
                    {
                        ushort x;
                        ushort y;
                        this.Patron.method_11(this.Patron, this.Patron.X, this.Patron.Y, out x, out y, 30);
                        if (!this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)") && !this.Patron.TryGetStockS("텔리포트의깃털"))
                        {
                            this.Patron.Form._moveX = (int)x;
                            this.Patron.Form._moveY = (int)y;
                            this.Patron.Form._moveFlag = true;
                        }
                        else
                        {
                            this.Patron.mTeleport.WaitOne();
                            this.Patron.MoveByTeleport(this.Patron, (int)x, (int)y);
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