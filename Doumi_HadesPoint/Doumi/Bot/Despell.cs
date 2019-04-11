namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Despell
    {
        private bool _flag;
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private ProxyPatron <Patron>k__BackingField;
        private Thread _thread;

        public Despell(ProxyPatron patron)
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
            try
            {
                Thread.Sleep(0x3e8);
                while ((this.Patron != null) && this._flag)
                {
                    Field field = this.Patron.Field;
                    if (field != null)
                    {
                        this.Patron.mAisling.WaitOne();
                        foreach (KeyValuePair<uint, Aisling> pair in field.Aislings)
                        {
                            double introduced42 = Math.Pow((double) (pair.Value.X - this.Patron.X), 2.0);
                            int num = (int) Math.Sqrt(introduced42 + Math.Pow((double) (pair.Value.Y - this.Patron.Y), 2.0));
                            if (((this.Patron.Form.chk코마.Checked && pair.Value.Coma) && !this.Patron.isState()) && ((this.Patron.Form.chkTargetAll.Checked || (this.Patron.Form.chkTagetGuild.Checked && (pair.Value.NameTint == 3))) || (this.Patron.Form.chkTagetGroup.Checked && (pair.Value.NameTint == 5))))
                            {
                                ushort x;
                                ushort y;
                                if ((((this.Patron.X == pair.Value.X) && (this.Patron.Y == (pair.Value.Y + 1))) || ((this.Patron.X == pair.Value.X) && (this.Patron.Y == (pair.Value.Y - 1)))) || (((this.Patron.X == (pair.Value.X + 1)) && (this.Patron.Y == pair.Value.Y)) || (((this.Patron.X - 1) == pair.Value.X) && (this.Patron.Y == pair.Value.Y))))
                                {
                                    x = this.Patron.X;
                                    y = this.Patron.Y;
                                }
                                else
                                {
                                    if (!this.Patron.Form.isAttackable(pair.Value.X, pair.Value.Y))
                                    {
                                        break;
                                    }
                                    if (this.Patron.chooseClosePosition(this.Patron, pair.Value.X, pair.Value.Y, out x, out y, -1) && (this.Patron.TryGetStockS("텔리포트의깃털") || this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)")))
                                    {
                                        this.Patron.mTeleport.WaitOne();
                                        this.Patron.MoveByTeleport(this.Patron, x, y);
                                        this.Patron.mTeleport.ReleaseMutex();
                                    }
                                }
                                if ((y == (pair.Value.Y + 1)) && (x == pair.Value.X))
                                {
                                    this.Patron.Turn(0);
                                }
                                if ((x == (pair.Value.X - 1)) && (y == pair.Value.Y))
                                {
                                    this.Patron.Turn(1);
                                }
                                if ((y == (pair.Value.Y - 1)) && (x == pair.Value.X))
                                {
                                    this.Patron.Turn(2);
                                }
                                if ((x == (pair.Value.X + 1)) && (y == pair.Value.Y))
                                {
                                    this.Patron.Turn(3);
                                }
                                if (!this.Patron.UseSpell("코마디아", (Sprite) null) || (this.Patron.CurrentMP.Get() < 520))
                                {
                                    this.Patron.UseStockS("코마디움");
                                }
                                else
                                {
                                    this.Patron.UseSpell("홀리쿠라노", pair.Value);
                                }
                            }
                            if (((this.Patron.Form.chk자동저주풀기.Checked && (num < 8)) && ((pair.Value.Tint == 1) && !this.Patron.isState())) && ((this.Patron.Form.chkTargetAll.Checked || (this.Patron.Form.chkTagetGuild.Checked && (pair.Value.NameTint == 3))) || (this.Patron.Form.chkTagetGroup.Checked && (pair.Value.NameTint == 5))))
                            {
                                if (!this.Patron.UseSpell("홀리큐레스", pair.Value))
                                {
                                    this.Patron.UseSpell("홀리큐어", pair.Value);
                                }
                                if (!this.Patron.UseSpell("디프라베라", pair.Value))
                                {
                                    this.Patron.UseSpell("디프라바", pair.Value);
                                }
                            }
                            if (this.Patron.Form.chk디스펠.Checked && ((this.Patron.Form.chkTagetGroup.Checked || this.Patron.Form.chkTagetGuild.Checked) || this.Patron.Form.chkTargetAll.Checked))
                            {
                                if ((((pair.Value.Soruma && this.Patron.deSpellList.DeSoruma) && (num < 8)) && ((this.Patron.Guid == pair.Value.Guid) || ((this.Patron.Form.chkTargetAll.Checked || (this.Patron.Form.chkTagetGuild.Checked && (pair.Value.NameTint == 3))) || (this.Patron.Form.chkTagetGroup.Checked && (pair.Value.NameTint == 5))))) && !this.Patron.UseSpell("디소루메라", pair.Value))
                                {
                                    this.Patron.UseSpell("디소루마", pair.Value);
                                }
                                if ((((pair.Value.Narcoli && this.Patron.deSpellList.DeNarcoli) && (num < 8)) && ((this.Patron.Guid == pair.Value.Guid) || ((this.Patron.Form.chkTargetAll.Checked || (this.Patron.Form.chkTagetGuild.Checked && (pair.Value.NameTint == 3))) || (this.Patron.Form.chkTagetGroup.Checked && (pair.Value.NameTint == 5))))) && !this.Patron.UseSpell("디나르콜룸", pair.Value))
                                {
                                    this.Patron.UseSpell("디나르콜리", pair.Value);
                                }
                                if (((((this.Patron.Form != null) && this.Patron.Form.chk그룹전체힐.Checked) && ((num < 8) && (pair.Value.HPBar < this.Patron.Form._GroupHealHP))) && (!pair.Value.Coma && !this.Patron.isState())) && (((this.Patron.Form.chkTargetAll.Checked || (this.Patron.Form.chkTagetGuild.Checked && (pair.Value.NameTint == 3))) || (this.Patron.Form.chkTagetGroup.Checked && (pair.Value.NameTint == 5))) || (this.Patron.Guid == pair.Value.Guid)))
                                {
                                    this.Patron.UseSpell("홀리쿠라네라", pair.Value);
                                }
                                if((this.Patron.Form != null) && (num < 8) && pair.Value.HPBar < 70 && (!pair.Value.Coma && !this.Patron.isState()))
                                {
                                    this.Patron.UseSpell("쿠로", pair.Value);
                                }
                                if (((((((this.Patron.Form != null) && this.Patron.Form.chk그룹힐.Checked) && ((num < 8) && (pair.Value.HPBar < this.Patron.Form._GroupHealHP))) && (!pair.Value.Coma && !this.Patron.isState())) && (((this.Patron.Form.chkTargetAll.Checked || (this.Patron.Form.chkTagetGuild.Checked && (pair.Value.NameTint == 3))) || (this.Patron.Form.chkTagetGroup.Checked && (pair.Value.NameTint == 5))) || (this.Patron.Guid == pair.Value.Guid))) && !this.Patron.UseSpell("홀리쿠라노", pair.Value)) && !this.Patron.UseSpell("엑스쿠라노", pair.Value))
                                {
                                    this.Patron.UseSpell("쿠라노", pair.Value);
                                }
                                if (((((((this.Patron.Form != null) && ((num < 8) && (pair.Value.HPBar < this.Patron.Form._GroupHealHP))) && (!pair.Value.Coma && !this.Patron.isState())) && (((this.Patron.Form.chkTargetAll.Checked || (this.Patron.Form.chkTagetGuild.Checked && (pair.Value.NameTint == 3))) || (this.Patron.Form.chkTagetGroup.Checked && (pair.Value.NameTint == 5))) || (this.Patron.Guid == pair.Value.Guid))))))
                                {
                                    this.Patron.UseSpell("쿠라노", pair.Value);
                                }
                                if ((((pair.Value.Illumena && this.Patron.deSpellList.Illumena) && ((num < 8) && !this.Patron.isState())) && ((this.Patron.Guid == pair.Value.Guid) || ((this.Patron.Form.chkTargetAll.Checked || (this.Patron.Form.chkTagetGuild.Checked && (pair.Value.NameTint == 3))) || (this.Patron.Form.chkTagetGroup.Checked && (pair.Value.NameTint == 5))))) && !this.Patron.UseSpell("디일루메룸", pair.Value))
                                {
                                    this.Patron.UseSpell("일루메나", pair.Value);
                                }
                                if ((((pair.Value.Venom && this.Patron.deSpellList.DeVenomo) && ((num < 8) && !this.Patron.isState())) && ((this.Patron.Guid == pair.Value.Guid) || ((this.Patron.Form.chkTargetAll.Checked || (this.Patron.Form.chkTagetGuild.Checked && (pair.Value.NameTint == 3))) || (this.Patron.Form.chkTagetGroup.Checked && (pair.Value.NameTint == 5))))) && !this.Patron.UseSpell("디베노메라", pair.Value))
                                {
                                    this.Patron.UseSpell("디베노모", pair.Value);
                                }
                                if ((((pair.Value.Dark && this.Patron.deSpellList.HolyCure) && ((num < 8) && !this.Patron.isState())) && ((this.Patron.Guid == pair.Value.Guid) || ((this.Patron.Form.chkTargetAll.Checked || (this.Patron.Form.chkTagetGuild.Checked && (pair.Value.NameTint == 3))) || (this.Patron.Form.chkTagetGroup.Checked && (pair.Value.NameTint == 5))))) && !this.Patron.UseSpell("홀리큐레스", pair.Value))
                                {
                                    this.Patron.UseSpell("홀리큐어", pair.Value);
                                }
                                if ((((pair.Value.Pravo && this.Patron.deSpellList.DePrava) && ((num < 8) && !this.Patron.isState())) && ((this.Patron.Guid == pair.Value.Guid) || ((this.Patron.Form.chkTargetAll.Checked || (this.Patron.Form.chkTagetGuild.Checked && (pair.Value.NameTint == 3))) || (this.Patron.Form.chkTagetGroup.Checked && (pair.Value.NameTint == 5))))) && !this.Patron.UseSpell("디프라베라", pair.Value))
                                {
                                    this.Patron.UseSpell("디프라바", pair.Value);
                                }
                                if ((((pair.Value.Depreco && this.Patron.deSpellList.DeDefleca) && ((num < 8) && !this.Patron.isState())) && ((this.Patron.Guid == pair.Value.Guid) || ((this.Patron.Form.chkTargetAll.Checked || (this.Patron.Form.chkTagetGuild.Checked && (pair.Value.NameTint == 3))) || (this.Patron.Form.chkTagetGroup.Checked && (pair.Value.NameTint == 5))))) && !this.Patron.UseSpell("디데프레타", pair.Value))
                                {
                                    this.Patron.UseSpell("디데프레카", pair.Value);
                                }
                                if (((pair.Value.Bardo && this.Patron.deSpellList.DeBardo) && ((num < 8) && !this.Patron.isState())) && ((this.Patron.Guid == pair.Value.Guid) || ((this.Patron.Form.chkTargetAll.Checked || (this.Patron.Form.chkTagetGuild.Checked && (pair.Value.NameTint == 3))) || (this.Patron.Form.chkTagetGroup.Checked && (pair.Value.NameTint == 5)))))
                                {
                                    this.Patron.UseSpell("디바르도", pair.Value);
                                }
                                if (((pair.Value.Rento && this.Patron.deSpellList.DeRento) && ((num < 8) && !this.Patron.isState())) && ((this.Patron.Guid == pair.Value.Guid) || ((this.Patron.Form.chkTargetAll.Checked || (this.Patron.Form.chkTagetGuild.Checked && (pair.Value.NameTint == 3))) || (this.Patron.Form.chkTagetGroup.Checked && (pair.Value.NameTint == 5)))))
                                {
                                    this.Patron.UseSpell("디렌토", pair.Value);
                                }
                            }
                        }
                        this.Patron.mAisling.ReleaseMutex();
                    }
                    Thread.Sleep(250);
                    if (this.Patron == null)
                    {
                        this.Abort();
                    }
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

