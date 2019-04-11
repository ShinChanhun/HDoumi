namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Hunt_Warrior
    {
        private readonly TimeSpan timeSpan_0 = new TimeSpan(0, 0, 36);
        private TimeSpan timeSpan_1 = new TimeSpan(0, 10, 0);
        private bool _flag;
        private Thread thread_0;
        private ProxyPatron gclass0_1;
        private DateTime dateTime_0;
        private int int_0;
        private int int_1;
        private DateTime dateTime_1;

        public Hunt_Warrior(ProxyPatron patron)
        {
            this.Patron = patron;
        }

        public void Abort()
        {
            this._flag = false;
            this.thread_0 = (Thread)null;
        }

        public void Start()
        {
            this._flag = true;
            this.thread_0 = new Thread(new ThreadStart(this.method_2));
            this.thread_0.Start();
        }

        public ProxyPatron Patron { get; set; }

        private void method_2()
        {
            this.Patron.Form.chk자동보호.Checked = true;
            this.Patron.Form.chk집중.Checked = true;
            Aisling gclass33;
            this.Patron.Field.Aislings.TryGetValue(this.Patron.Guid, out gclass33);
            Thread.Sleep(1000);
            uint g = 0;
            int num1 = 0;
            Monster tMonster = (Monster)null;
            while (this.Patron.Form != null && this._flag)
            {
                int dis = int.MaxValue;
                bool flag1 = false;
                uint guid = 0;
                Field field = this.Patron.Field;
                Monster mmonster;
                field.Monsters.TryGetValue(g, out mmonster);
                this.Patron.mMonster.WaitOne();
                if (mmonster == null)
                {
                    foreach (KeyValuePair<uint, Monster> pair in field.Monsters)
                    {
                        int num4 = (int)Math.Sqrt(Math.Pow((double)((int)pair.Value.X - (int)this.Patron.X), 2.0) + Math.Pow((double)((int)pair.Value.Y - (int)this.Patron.Y), 2.0));

                        if (field.method_1(pair.Value.Icon) && num4 < 8)
                        {
                            flag1 = true;
                        }
                        if (this.Patron.Field.method_1(pair.Value.Icon) /*&& (pair.Value.Tint == (byte)1 */ /*&& this.Patron.Form.CheckMonster(pair.Value.Icon)*//*)*/ && (num4 < dis && this.Patron.Form.isAttackable((int)pair.Value.X, (int)pair.Value.Y)))
                        {
                            if (this.Patron.Form.CheckMonster(pair.Value.Icon) == true)
                            {
                                dis = num4;
                                guid = pair.Key;
                            }
                            else
                            {
                                if (field.Name.Contains("레드오피온의굴29") == true) continue;
                                if (pair.Value.Tint == (byte)1)
                                {
                                    dis = num4;
                                    guid = pair.Key;
                                }
                            }
                        }
                    }
                    if (!flag1)
                    {
                        foreach (KeyValuePair<uint, Monster> pair in field.Monsters)
                        {
                            int distance = (int)Math.Sqrt(Math.Pow((double)((int)pair.Value.X - (int)this.Patron.X), 2.0) + Math.Pow((double)((int)pair.Value.Y - (int)this.Patron.Y), 2.0));
                            if (!this.Patron.Field.method_2(pair.Value.Icon) && /*(*//*pair.Value.Tint == (byte)1 &&*/ /*this.Patron.Form.CheckMonster(pair.Value.Icon)) &&*/ (distance < dis && this.Patron.Form.isAttackable((int)pair.Value.Y, (int)pair.Value.Y)))
                            {
                                if (this.Patron.Form.CheckMonster(pair.Value.Icon) == true)
                                {
                                    dis = distance;
                                    guid = pair.Key;
                                }
                                else
                                {
                                    if (field.Name.Contains("레드오피온의굴29") == true) continue;
                                    if (pair.Value.Tint == (byte)1)
                                    {
                                        dis = distance;
                                        guid = pair.Key;
                                    }
                                }
                            }
                            if (dis == 1)
                                break;
                        }
                    }
                }
                else
                {
                    dis = (int)Math.Sqrt(Math.Pow((double)((int)mmonster.X - (int)this.Patron.X), 2.0) + Math.Pow((double)((int)mmonster.Y - (int)this.Patron.Y), 2.0));
                    guid = mmonster.Guid;
                }

                Monster monster;
                field.Monsters.TryGetValue(guid, out monster);

                if (monster != null && (int)g == (int)monster.Guid)
                {
                    //++num1;
                    //g = monster.Guid;
                }
                else if (monster != null)
                {
                    num1 = 0;
                    g = monster.Guid;
                }
                if (num1 > 20)
                {
                    Monster gclass35_4;
                    field.Monsters.TryRemove(g, out gclass35_4);
                    num1 = 0;
                    dis = int.MaxValue;
                }

                this.Patron.mMonster.ReleaseMutex();

                if (dis != int.MaxValue && dis < 9 && monster != null)
                {
                    ushort ushort_4 = 999;
                    ushort ushort_5 = 62;
                    bool flag2 = false;

                    if (field.Name.StartsWith("블랙오피온의굴8") && monster.X == (ushort)21 && monster.Y == (ushort)12 && this.Patron.Form.CheckMonster(monster.Icon) == false)
                    {
                        Monster gclass35_4;
                        field.Monsters.TryRemove(g, out gclass35_4);
                    }
                    else if (this.Patron.Form.isNearPosition((int)this.Patron.X, (int)this.Patron.Y, (int)monster.X, (int)monster.Y))
                    {
                        ushort_4 = this.Patron.X;
                        ushort_5 = this.Patron.Y;
                        flag2 = true;
                    }
                    else if (this.Patron.chooseMinDistancePostion(this.Patron, monster.X, monster.Y, out ushort_4, out ushort_5))
                    {
                        if (!this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)") && !this.Patron.TryGetStockS("텔리포트의깃털"))
                        {
                            this.Patron.Form._moveX = ushort_4;
                            this.Patron.Form._moveY = ushort_5;
                            this.Patron.Form._moveFlag = true;
                            Thread.Sleep(0x3e8);
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
                        if ((int)ushort_4 == (int)monster.X && (int)ushort_5 == (int)monster.Y + 1)
                            this.Patron.Turn((byte)0);
                        if ((int)ushort_4 == (int)monster.X - 1 && (int)ushort_5 == (int)monster.Y)
                            this.Patron.Turn((byte)1);
                        if ((int)ushort_4 == (int)monster.X && (int)ushort_5 == (int)monster.Y - 1)
                            this.Patron.Turn((byte)2);
                        if ((int)ushort_4 == (int)monster.X + 1 && (int)ushort_5 == (int)monster.Y)
                            this.Patron.Turn((byte)3);

                        if (tMonster != monster && this.Patron.CanUseSkill("센스몬스터"))
                        {
                            this.Patron.UseSkill("센스몬스터");
                            mmonster = monster;
                        }

                        if (!monster.Immortal)
                        {
                            Thread.Sleep(150);
                            this.Patron.UseSkill("포효");
                            this.Patron.UseSkill("바투");
                            this.Patron.UseSkill("완전방어");
                            this.Patron.UseSkill("피닉스모드");
                            //if (!monster.Amnesia)
                            //{
                            //    if (this.Patron.CanUseSkill("습격"))
                            //    {
                            //        this.Patron.UseSkill("습격");
                            //        monster.Amnesia = true;
                            //    }
                            //}
                            //else
                            //{

                            if (this.Patron.CanUseSkill("퓨리소윌루"))
                            {
                                this.Patron.UseSkill("퓨리소윌루");
                                monster.Amnesia = true;
                            }
                            else if (this.Patron.CanUseSkill("사방치기"))
                            {
                                this.Patron.UseSkill("사방치기");
                                monster.Amnesia = true;
                            }
                            else if (this.Patron.CanUseSkill("내려치기"))
                            {
                                this.Patron.UseSkill("내려치기");
                                monster.Amnesia = true;
                            }
                            else if (this.Patron.CanUseSkill("돌진"))
                            {
                                this.Patron.UseSkill("돌진");
                                monster.Amnesia = true;
                            }
                            //}
                        }
                        Thread.Sleep(100);
                        if (this.Patron.Form.chkShot.Checked)
                        {
                            if (this.Patron.CanUseSkill("크래셔"))
                            {
                                this.Patron.UseStockS("수상한버섯");
                                this.Patron.UseSkill("크래셔");
                                this.Patron.UseSpell("쿠로토", (Sprite)monster);
                                monster.Amnesia = true;
                            }
                            else if (this.Patron.CanUseSkill("데빌크래셔"))
                            {
                                this.Patron.UseStockS("수상한버섯");
                                this.Patron.UseSkill("데빌크래셔");
                                this.Patron.UseSpell("쿠로토", (Sprite)monster);
                                monster.Amnesia = true;
                            }
                            else if (this.Patron.CanUseSkill("매드소울"))
                            {
                                this.Patron.UseSkill("매드소울");
                                this.Patron.UseSpell("쿠로토", (Sprite)monster);
                                monster.Amnesia = true;
                            }
                            else if (this.Patron.CanUseSkill("암살격"))
                            {
                                this.Patron.UseSkill("암살격");
                                this.Patron.UseSpell("쿠로토", (Sprite)monster);
                                monster.Amnesia = true;
                            }
                        }
                    }
                }
                else
                {
                    int monsterCount = 0;
                    foreach (KeyValuePair<uint, Monster> pair in field.Monsters)
                    {
                        if ((int)Math.Sqrt(Math.Pow((double)((int)pair.Value.X - (int)this.Patron.X), 2.0) + Math.Pow((double)((int)pair.Value.Y - (int)this.Patron.Y), 2.0)) <= 8 /*&& keyValuePair.Value.Tint == (byte)1*/
                                                                                                                                                                                   /*&& this.Patron.Form.CheckMonster(pair.Value.Icon) == true*/)
                        {
                            if (this.Patron.Form.CheckMonster(pair.Value.Icon) == true)
                            {
                                ++monsterCount;
                            }
                            else
                            {
                                if (field.Name.Contains("레드오피온의굴29") == true) continue;
                                if (pair.Value.Tint == (byte)1)
                                {
                                    ++monsterCount;
                                }
                            }

                        }
                        else
                        {
                            Monster gclass35_4;
                            field.Monsters.TryRemove(pair.Value.Guid, out gclass35_4);
                        }
                    }

                    if (monsterCount > 0)
                    {
                        Thread.Sleep(3000);
                    }

                    else if (!this.Patron.Form.chk따라가기.Checked)
                    {
                        ushort dx;
                        ushort dy;
                        this.Patron.method_11(this.Patron, this.Patron.X, this.Patron.Y, out dx, out dy, 30);
                        if (!this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)") && !this.Patron.TryGetStockS("텔리포트의깃털"))
                        {
                            this.Patron.Form._moveX = (int)dx;
                            this.Patron.Form._moveY = (int)dy;
                            this.Patron.Form._moveFlag = true;
                        }
                        else
                        {

                            this.Patron.mTeleport.WaitOne();
                            this.Patron.MoveByTeleport(this.Patron, (int)dx, (int)dy);
                            this.Patron.mTeleport.ReleaseMutex();

                            Thread.Sleep(500);

                        }

                        Thread.Sleep(2000);
                    }
                }
                Thread.Sleep(550);
                if (this.Patron == null)
                    this.Abort();
            }
        }
    }
}