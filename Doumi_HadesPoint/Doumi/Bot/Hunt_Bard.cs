namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Hunt_Bard
    {
        private bool _flag;
        //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        //private ProxyPatron <Patron>k__BackingField;
        private Thread _thread;


        public Hunt_Bard(ProxyPatron patron)
        {
            this.Patron = patron;
        }

        public void Abort()
        {
            this._flag = false;
            this._thread = null;
        }


        private void Auto()
        {
            //this.Patron.Form.tbTarget.Text = "브라운팜";
            this.Patron.Form.chk자동루팅.Checked = true;
            this.Patron.Form.chk자동보호.Checked = true;
            this.Patron.Form.chk저주.Checked = true;
            //this.Patron.Form.chk자동바르도.Checked = true;

            Thread.Sleep(0x3e8);
            uint key = 0;
            int num2 = 0;
            int num3 = 0;
            while ((this.Patron.Form != null) && this._flag)
            {
                int num5 = 0x7fffffff;
                bool flag = this.DuelNecklace();
                bool flag2 = false;
                uint guid = 0;
                if (((double)this.Patron.CurrentMP.Get()) > (((double)this.Patron.MaximumMP.Get()) * 0.1))
                {
                    Monster monster;
                    Monster monster2;
                    Field field = this.Patron.Field;
                    field.Monsters.TryGetValue(key, out monster);
                    if (monster == null)
                    {
                        foreach (KeyValuePair<uint, Monster> pair in field.Monsters)
                        {
                            double introduced61 = Math.Pow((double)(pair.Value.X - this.Patron.X), 2.0);
                            int num7 = (int)Math.Sqrt(introduced61 + Math.Pow((double)(pair.Value.Y - this.Patron.Y), 2.0));
                            if (this.FirstMonsters(pair.Value.Icon) && (num7 < 8))
                            {
                                if (!this.Patron.Form.CheckMonster(pair.Value.Icon))
                                {
                                    continue;
                                }
                                flag2 = true;
                            }
                            if (((this.FirstMonsters(pair.Value.Icon) && (pair.Value.Tint == 1)) && (num7 < num5)) && this.Patron.Form.isAttackable(pair.Value.X, pair.Value.Y))
                            {
                                if (!this.Patron.Form.CheckMonster(pair.Value.Icon))
                                {
                                    continue;
                                }
                                num5 = num7;
                                guid = pair.Key;
                            }
                        }
                        if (!flag2)
                        {
                            foreach (KeyValuePair<uint, Monster> pair2 in field.Monsters)
                            {
                                double dis = Math.Pow((double)(pair2.Value.X - this.Patron.X), 2.0);
                                int num8 = (int)Math.Sqrt(dis + Math.Pow((double)(pair2.Value.Y - this.Patron.Y), 2.0));
                                if (((!this.IgnoreMonsters(pair2.Value.Icon) && (pair2.Value.Tint == 1)) && (num8 < num5)) && this.Patron.Form.isAttackable(pair2.Value.X, pair2.Value.Y))
                                {
                                    if (!this.Patron.Form.CheckMonster(pair2.Value.Icon))
                                    {
                                        continue;
                                    }
                                    num5 = num8;
                                    guid = pair2.Key;
                                }
                                if (num5 == 1)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        num5 = (int)Math.Sqrt(Math.Pow((double)(monster.X - this.Patron.X), 2.0) + Math.Pow((double)(monster.Y - this.Patron.Y), 2.0));
                        guid = monster.Guid;
                    }
                    field.Monsters.TryGetValue(guid, out monster2);
                    if ((monster2 != null) && (key == monster2.Guid))
                    {
                        num2++;
                        key = monster2.Guid;
                    }
                    else if (monster2 != null)
                    {
                        num2 = 0;
                        key = monster2.Guid;
                    }
                    if (num2 > 20)
                    {
                        Monster monster3;
                        field.Monsters.TryRemove(key, out monster3);
                    }
                    if (num2 > 20)
                    {
                        num2 = 0;
                        num5 = 0x7fffffff;
                    }
                    if (((num5 != 0x7fffffff) && (num5 < 9)) && (monster2 != null))
                    {
                        ushort outX = 0x3e7;
                        ushort outY = 0x3e7;
                        bool flag15 = false;
                        if (flag)
                        {
                            if (this.LightMonster(monster2.Icon) && (this.Patron.CurrentOffenseAttribute.Get() != 5))
                            {
                                this.Patron.UseStockS("생명의목걸이");
                            }
                            if (this.DarkMonster(monster2.Icon) && (this.Patron.CurrentOffenseAttribute.Get() != 6))
                            {
                                this.Patron.UseStockS("암흑의목걸이");
                            }
                        }
                        if ((field.Name.StartsWith("블랙오피온의굴8") && (monster2.X == 0x15)) && (monster2.Y == 12) && !this.Patron.Form.CheckMonster(monster2.Icon))
                        {
                            Monster monster4;
                            field.Monsters.TryRemove(key, out monster4);
                        }
                        else if (this.Patron.Form.isNearPosition(this.Patron.X, this.Patron.Y, monster2.X, monster2.Y))
                        {
                            outX = this.Patron.X;
                            outY = this.Patron.Y;
                            flag15 = true;
                        }
                        else if (this.Patron.chooseMinDistancePostion(this.Patron, monster2.X, monster2.Y, out outX, out outY))
                        {
                            if (this.Patron.TryGetStockS("테슬러의깃털") || this.Patron.TryGetStockS("텔리포트의깃털") || this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)"))
                            {
                                this.Patron.mTeleport.WaitOne();
                                this.Patron.MoveByTeleport(this.Patron, outX, outY);
                                this.Patron.mTeleport.ReleaseMutex();
                                flag15 = true;
                            }
                            else
                            {
                                this.Patron.Form._moveX = outX;
                                this.Patron.Form._moveY = outY;
                                this.Patron.Form._moveFlag = true;
                                Thread.Sleep(0x3e8);
                            }
                        }
                        if (flag15)
                        {
                            this.Patron.mSpell.WaitOne();
                            if ((outX == monster2.X) && (outY == (monster2.Y + 1)))
                            {
                                this.Patron.Turn(0);
                            }
                            if ((outX == (monster2.X - 1)) && (outY == monster2.Y))
                            {
                                this.Patron.Turn(1);
                            }
                            if ((outX == monster2.X) && (outY == (monster2.Y - 1)))
                            {
                                this.Patron.Turn(2);
                            }
                            if ((outX == (monster2.X + 1)) && (outY == monster2.Y))
                            {
                                this.Patron.Turn(3);
                            }
                            this.Patron.UseSpell("베노미", monster2);
                            if (!monster2.Narcoli)
                            {
                                this.Patron.UseSpell("나르콜리", monster2);
                            }
                            this.Patron.mSpell.ReleaseMutex();
                            if (!monster2.Immortal)
                            {
                                Console.WriteLine(monster2.ToString());
                                Console.WriteLine(monster2.Icon);
                                this.Patron.UseSkill("연주공격");
                            }
                        }
                    }
                    else
                    {
                        int num13 = 0;
                        foreach (KeyValuePair<uint, Monster> pair3 in field.Monsters)
                        {
                            double introduced63 = Math.Pow((double)(pair3.Value.X - this.Patron.X), 2.0);
                            int num14 = (int)Math.Sqrt(introduced63 + Math.Pow((double)(pair3.Value.Y - this.Patron.Y), 2.0));
                            if (num14 <= 8 && !this.Patron.Form.CheckMonster(pair3.Value.Icon))
                            {
                                num13++;
                            }
                            else
                            {
                                Monster monster5;
                                field.Monsters.TryRemove(pair3.Value.Guid, out monster5);
                            }
                        }
                        if (num13 > 0)
                        {
                            num3 = 0;
                            Thread.Sleep(0xbb8);
                        }
                        else if (!this.Patron.Form.chk따라가기.Checked)
                        {
                            ushort num11;
                            ushort num12;
                            Thread.Sleep(300);
                            this.Patron.chooseFarPosition(this.Patron, this.Patron.X, this.Patron.Y, out num11, out num12, 30);
                            if (this.Patron.TryGetStockS("테슬러의깃털") || this.Patron.TryGetStockS("텔리포트의깃털")|| this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)"))
                            {
                                this.Patron.mTeleport.WaitOne();
                                this.Patron.MoveByTeleport(this.Patron, num11, num12);
                                this.Patron.mTeleport.ReleaseMutex();
                                num3++;
                            }
                            else
                            {
                                this.Patron.Form._moveX = num11;
                                this.Patron.Form._moveY = num12;
                                this.Patron.Form._moveFlag = true;
                            }
                            Thread.Sleep(2000);
                        }
                    }
                }
                Thread.Sleep(300);
                if (this.Patron == null)
                {
                    this.Abort();
                }
            }
        }

        public bool DarkMonster(ushort icon)
        {
            ushort[] numArray = new ushort[] { 0x4219, 0x421a, 0x421b, 0x421c, 0x422a, 0x422b, 0x43c2, 0x43c3 };
            foreach (ushort num2 in numArray)
            {
                if (num2 == icon)
                {
                    return true;
                }
            }
            return false;
        }

        public bool DuelNecklace() =>
            ((((this.Patron.CurrentOffenseAttribute.Get() == 5) && this.Patron.TryGetStockS("암흑의목걸이")) || ((this.Patron.CurrentOffenseAttribute.Get() == 6) && this.Patron.TryGetStockS("암흑의목걸이"))) || (this.Patron.TryGetStockS("암흑의목걸이") && this.Patron.TryGetStockS("생명의목걸이")));

        public bool FirstMonsters(ushort icon)
        {
            ushort[] numArray = new ushort[] { 0x422a, 0x422b };
            foreach (ushort num2 in numArray)
            {
                if (num2 == icon)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IgnoreMonsters(ushort icon)
        {
            ushort[] numArray = new ushort[] { 0x4229, 0x4228, 0x43c4, 0x43c5 };
            foreach (ushort num2 in numArray)
            {
                if (num2 == icon)
                {
                    return true;
                }
            }
            return false;
        }

        public bool LightMonster(ushort icon)
        {
            ushort[] numArray = new ushort[] { 0x421d, 0x41ec, 0x43c5, 0x43c4, 0x4228, 0x4229, 0x4097 };
            foreach (ushort num2 in numArray)
            {
                if (num2 == icon)
                {
                    return true;
                }
            }
            return false;
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

