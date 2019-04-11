namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Types;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Protect
    {
        private bool _flag;
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private ProxyPatron <Patron>k__BackingField;
        private Thread _thread;

        public Protect(ProxyPatron patron)
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
                while ((this.Patron.Form != null) && this._flag)
                {
                    Thread.Sleep(0xbb8);
                    while (this.Patron.Form != null)
                    {
                        Stock stock;
                        Stock stock2;
                        this.Patron.mBuff.WaitOne();
                        ProtectList protectList = this.Patron.protectList;
                        this.Patron.mBuff.ReleaseMutex();
                        if (((this.Patron.Form.chk세토아가호.Checked && !protectList.is세토아가호) && !this.Patron.isState()) && this.Patron.TryGetStockS("[TEST]세토아의가호(Lev2)", out stock))
                        {
                            this.Patron.UseStock(stock);
                        }
                        if (((this.Patron.Form.chk이아가호.Checked && !protectList.is이아가호) && !this.Patron.isState()) && this.Patron.TryGetStockS("[TEST]이아의가호(Lev2)", out stock2))
                        {
                            this.Patron.UseStock(stock2);
                        }
                        if ((this.Patron.protectList != null) && this.Patron.Form.chk자동보호.Checked)
                        {
                            Field field = this.Patron.Field;
                            if (((this.Patron.Form.chk디소.Checked && protectList.is디소루마) && (((double) this.Patron.CurrentMP.Get()) > 1000.0)) && !protectList.is코마)
                            {
                                this.Patron.UseSpell("디소루마", (Sprite) null);
                            }
                            if (((this.Patron.Form.chk디나.Checked && protectList.is디나르콜리) && (((double) this.Patron.CurrentMP.Get()) > 1000.0)) && !protectList.is코마)
                            {
                                this.Patron.UseSpell("디나르콜리", (Sprite) null);
                            }
                            if (((this.Patron.Form.chk디베.Checked && protectList.is디베노모) && (((double) this.Patron.CurrentMP.Get()) > 1000.0)) && !this.Patron.isState())
                            {
                                this.Patron.UseSpell("디베노모", (Sprite) null);
                            }
                            if (((this.Patron.Form.chk일루.Checked && protectList.is일루메나) && (((double) this.Patron.CurrentMP.Get()) > 1000.0)) && !this.Patron.isState())
                            {
                                this.Patron.UseSpell("일루메나", (Sprite) null);
                            }
                            if ((((this.Patron.Form.chk이모탈.Checked && !protectList.is이모탈) && (((double) this.Patron.CurrentMP.Get()) > 1000.0)) && !this.Patron.isState()) && !this.Patron.UseSpell("이모탈", (Sprite) null))
                            {
                                this.Patron.UseSpell("금강불괴", (Sprite) null);
                            }
                            if ((((this.Patron.Form.chk리플.Checked && (((double) this.Patron.CurrentMP.Get()) > 10000.0)) && !protectList.is리플렉토) && !this.Patron.isState()) && !this.Patron.UseSpell("리플렉토", (Sprite) null))
                            {
                                this.Patron.UseSpell("반탄신공", (Sprite) null);
                            }
                            if ((((this.Patron.Form.chk호르.Checked && !protectList.is호르라마) && (((double) this.Patron.CurrentMP.Get()) > 1000.0)) && !this.Patron.isState()) && !this.Patron.UseSpell("호르라마", (Sprite) null))
                            {
                                this.Patron.UseSpell("자기보호", (Sprite) null);
                            }
                            if ((((this.Patron.Form.chk콜라.Checked && !protectList.is콜라마) && (((double) this.Patron.CurrentMP.Get()) > 1000.0)) && !this.Patron.isState()) && !this.Patron.UseSpell("콜라마", (Sprite) null))
                            {
                                this.Patron.UseSpell("철포삼", (Sprite) null);
                            }
                            if (((this.Patron.Form.chk디렌.Checked && protectList.is렌토) && (((double) this.Patron.CurrentMP.Get()) > 1000.0)) && !this.Patron.isState())
                            {
                                this.Patron.UseSpell("디렌토", (Sprite) null);
                            }
                            if (((this.Patron.Form.chk디바.Checked && protectList.is바르도) && (((double) this.Patron.CurrentMP.Get()) > 1000.0)) && !this.Patron.isState())
                            {
                                this.Patron.UseSpell("디바르도", (Sprite) null);
                            }
                            if (((this.Patron.Form.chk디데.Checked && protectList.is데프레코) && (((double) this.Patron.CurrentMP.Get()) > 1000.0)) && !this.Patron.isState())
                            {
                                this.Patron.UseSpell("디데프레카", (Sprite) null);
                            }
                            if (((this.Patron.Form.chk디프.Checked && protectList.is프라보) && (((double) this.Patron.CurrentMP.Get()) > 1000.0)) && !this.Patron.isState())
                            {
                                this.Patron.UseSpell("디프라바", (Sprite) null);
                            }
                            if (((this.Patron.Form.chk디각.Checked && protectList.is어둠의각인) && (((double) this.Patron.CurrentMP.Get()) > 1000.0)) && !this.Patron.isState())
                            {
                                this.Patron.UseSpell("홀리큐어", (Sprite) null);
                            }
                            if (((this.Patron.Form.chk쿠랄툼.Checked && !protectList.is쿠랄툼) && (((double) this.Patron.CurrentMP.Get()) > 10000.0)) && !this.Patron.isState())
                            {
                                this.Patron.UseSpell("쿠랄툼", (Sprite) null);
                            }
                            if (((this.Patron.Form.chk포트.Checked && !protectList.is포트리스) && (((double) this.Patron.CurrentMP.Get()) > 1000.0)) && !this.Patron.isState())
                            {
                                this.Patron.UseSpell("포트리스", (Sprite) null);
                            }
                            if (((this.Patron.Form.chk델리.Checked && !protectList.is델리스펠라스) && (((double) this.Patron.CurrentMP.Get()) > 1000.0)) && !this.Patron.isState())
                            {
                                this.Patron.UseSpell("델리스펠라스", (Sprite) null);
                            }
                            if (((this.Patron.Form.chk움.Checked && !protectList.is영혼약화) && (((double) this.Patron.CurrentMP.Get()) > 1000.0)) && !this.Patron.isState())
                            {
                                this.Patron.UseSpell("슈페이아움", (Sprite) null);
                            }
                            if (((this.Patron.Form.chk힐.Checked && (((((double) this.Patron.CurrentHP.Get()) / ((double) this.Patron.MaximumHP.Get())) * 100.0) < this.Patron.Form._HealHP)) && (((double) this.Patron.CurrentMP.Get()) > 2000.0)) && !this.Patron.isState())
                            {
                                if (this.Patron.MaximumMP.Get() < 0x4e20)
                                {
                                    this.Patron.UseSpell("쿠라노", (Sprite) null);
                                }
                                else if (!this.Patron.UseSpell("홀리쿠라노", (Sprite) null))
                                {
                                    if (!this.Patron.UseSpell("엑스쿠라노", (Sprite)null))
                                        this.Patron.UseSpell("쿠로", (Sprite)null);                                
                                    else
                                        this.Patron.UseSpell("엑스쿠라노", (Sprite) null);
                                }
                            }
                            if (((this.Patron.Form.chk하이드.Checked && !protectList.is하이드) && (this.Patron.CurrentMP.Get() > 800)) && !this.Patron.isState())
                            {
                                this.Patron.UseSpell("하이드", (Sprite) null);
                            }
                            if ((((this.Patron.Form.chk라이트닝무브.Checked && !protectList.is라이트닝무브) && (((double) this.Patron.CurrentMP.Get()) > (((double) this.Patron.MaximumMP.Get()) * 0.5))) && !this.Patron.isState()) && !this.Patron.UseSpell("라이트닝무브", (Sprite) null))
                            {
                                this.Patron.UseSpell("미종보법", (Sprite) null);
                            }
                            if (((this.Patron.Form.chk집중.Checked && !protectList.is집중) && (this.Patron.CurrentMP.Get() > 800)) && !this.Patron.isState())
                            {
                                this.Patron.UseSpell("집중", (Sprite) null);
                            }
                            if (((this.Patron.Form.chk변신.Checked && !protectList.is변신) && (this.Patron.CurrentMP.Get() > 800)) && !this.Patron.isState())
                            {
                                this.Patron.UseSpell("늑대", (Sprite) null);
                                this.Patron.UseSpell("독수리", (Sprite) null);
                                this.Patron.UseSpell("엘리게이터", (Sprite) null);
                            }
                            if (this.Patron.protectList.is코마 == true)
                            {
                                this.Patron.SpeakParty("코마 "+ this.Patron.X + " " + this.Patron.Y + " " + this.Patron.Name);
                            }
                        }
                        Thread.Sleep(250);
                        if (this.Patron == null)
                        {
                            this.Abort();
                        }
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

