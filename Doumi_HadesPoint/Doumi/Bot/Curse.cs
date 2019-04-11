namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Curse
    {
        private bool _flag;
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private ProxyPatron <Patron>k__BackingField;
        private Thread _thread;

        public Curse(ProxyPatron patron)
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
            while ((this.Patron != null) && this._flag)
            {
                Field field = this.Patron.Field;
                bool flag = false;
                if (((field != null) && (this.Patron.CurrentMP.Get() > 0x3e8)) && !this.Patron.isState())
                {
                    foreach (KeyValuePair<uint, Monster> pair in field.Monsters)
                    {
                        double introduced32 = Math.Pow((double) (pair.Value.X - this.Patron.X), 2.0);
                        int num = (int) Math.Sqrt(introduced32 + Math.Pow((double) (pair.Value.Y - this.Patron.Y), 2.0));
                        if (this.Patron.isState() || (this.Patron.Form.chk이모탈.Checked && !this.Patron.protectList.is이모탈))
                        {
                            break;
                        }
                        if ((this.FirstMonsters(pair.Value.Icon) && (pair.Value.Tint == 0)) && (num <= 9))
                        {
                            flag = true;
                        }
                        if (((this.FirstMonsters(pair.Value.Icon) && (pair.Value.Tint == 0)) && (num <= 9)) && !this.Patron.isState())
                        {
                            if (((this.Patron.Form.chk프라.Checked && (pair.Value.Icon != 0x4356)) && (pair.Value.Icon != 0x4357)) && (pair.Value.Icon != 0x439f))
                            {
                                this.Patron.mSpell.WaitOne();
                                if (!this.Patron.UseSpell("프라베라", pair.Value))
                                {
                                    this.Patron.UseSpell("프라보", pair.Value);
                                }
                                this.Patron.mSpell.ReleaseMutex();
                            }
                            if (((this.Patron.Form.chk자동데프.Checked && (pair.Value.Icon != 0x4357)) && (pair.Value.Icon != 0x439f)) && !this.Patron.UseSpell("데프레타", pair.Value))
                            {
                                this.Patron.UseSpell("데프레코", pair.Value);
                            }
                            if (((this.Patron.Form.chk자동바르도.Checked && (pair.Value.Icon != 0x4356)) && (pair.Value.Icon != 0x4357)) && (pair.Value.Icon != 0x439f))
                            {
                                this.Patron.UseSpell("바르도", pair.Value);
                            }
                        }
                    }
                    if (!flag)
                    {
                        foreach (KeyValuePair<uint, Monster> pair2 in field.Monsters)
                        {
                            if (this.Patron.isState() || (this.Patron.Form.chk이모탈.Checked && !this.Patron.protectList.is이모탈))
                            {
                                break;
                            }
                            double introduced33 = Math.Pow((double) (pair2.Value.X - this.Patron.X), 2.0);
                            int num2 = (int) Math.Sqrt(introduced33 + Math.Pow((double) (pair2.Value.Y - this.Patron.Y), 2.0));
                            if (((pair2.Value.Tint == 0) && (num2 <= 8)) && !this.Patron.isState())
                            {
                                if (((this.Patron.Form.chk프라.Checked && (pair2.Value.Icon != 0x4356)) && (pair2.Value.Icon != 0x4357)) && (pair2.Value.Icon != 0x439f))
                                {
                                    this.Patron.mSpell.WaitOne();
                                    if (!this.Patron.UseSpell("프라베라", pair2.Value))
                                    {
                                        this.Patron.UseSpell("프라보", pair2.Value);
                                    }
                                    this.Patron.mSpell.ReleaseMutex();
                                }
                                if (((this.Patron.Form.chk자동데프.Checked && (pair2.Value.Icon != 0x4357)) && (pair2.Value.Icon != 0x439f)) && !this.Patron.UseSpell("데프레타", pair2.Value))
                                {
                                    this.Patron.UseSpell("데프레코", pair2.Value);
                                }
                                if (((this.Patron.Form.chk자동바르도.Checked && (pair2.Value.Icon != 0x4356)) && (pair2.Value.Icon != 0x4357)) && (pair2.Value.Icon != 0x439f))
                                {
                                    this.Patron.UseSpell("바르도", pair2.Value);
                                }
                            }
                            if ((this.Patron.Form.chk자동렌토.Checked && (num2 <= 9)) && (pair2.Value.Tint == 0))
                            {
                                this.Patron.UseSpell("렌토", pair2.Value);
                            }
                            if ((this.Patron.Form.chkSeo.Checked && (num2 <= 9)) && (pair2.Value.Tint == 0) && !pair2.Value.Seo)
                            {
                                this.Patron.UseSpell("세오의손길", pair2.Value);
                            }
                            if (((this.Patron.Form.chk리베.Checked && pair2.Value.Liberato) && (num2 <= 9)) && !this.Patron.isState())
                            {
                                this.Patron.UseSpell("리베라토", pair2.Value);
                            }
                            if (((((this.Patron.Form.chk나르.Checked && (pair2.Value.Tint == 1)) && ((pair2.Value.Icon != 0x40ca) && (pair2.Value.Icon != 0x413d))) && (((pair2.Value.Icon != 0x40ce) && (pair2.Value.Icon != 0x413b)) && ((pair2.Value.Icon != 0x4297) && (pair2.Value.Icon != 0x4357)))) && ((((pair2.Value.Icon != 0x418d) && (pair2.Value.Icon != 0x418e)) && ((pair2.Value.Icon != 0x418f) && (pair2.Value.Icon != 0x4190))) && ((pair2.Value.Icon != 0x4191) && (num2 <= 7)))) && !pair2.Value.Narcoli)
                            {
                                this.Patron.UseSpell("나르콜리", pair2.Value);
                            }
                            if ((this.Patron.Form.chk자동베노미.Checked && (pair2.Value.Tint == 1)) && (num2 <= 9))
                            {
                                this.Patron.UseSpell("베노미", pair2.Value);
                            }
                            if ((this.Patron.Form.chk자동소루.Checked && ((((pair2.Value.Icon == 0x40ca) || (pair2.Value.Icon == 0x413d)) || ((pair2.Value.Icon == 0x40ce) || (pair2.Value.Icon == 0x413b))) || ((((pair2.Value.Icon == 0x418d) || (pair2.Value.Icon == 0x418e)) || ((pair2.Value.Icon == 0x418f) || (pair2.Value.Icon == 0x4190))) || ((pair2.Value.Icon == 0x4191) || (pair2.Value.Icon == 0x4297))))) && ((num2 <= 9) && !pair2.Value.Soruma))
                            {
                                this.Patron.UseSpell("소루마", pair2.Value);
                            }
                            if ((this.Patron.Form.chk자동렌토.Checked && (num2 <= 9)) && (pair2.Value.Tint == 0))
                            {
                                this.Patron.UseSpell("렌토", pair2.Value);
                            }
                            if ((this.Patron.Form.chk기공콘푸.Checked && (num2 <= 9)) && pair2.Value.Confusio == true)
                            {
                                this.Patron.UseSpell("콘푸지오", pair2.Value);
                                this.Patron.UseSpell("콘푸지오", pair2.Value);
                                this.Patron.UseSpell("콘푸지오", pair2.Value);
                                pair2.Value.Confusio = false;
                            }
                        }
                    }
                }
                Thread.Sleep(250);
                if (this.Patron == null)
                {
                    this.Abort();
                }
            }
        }

        public bool FirstMonsters(ushort icon)
        {
            ushort[] numArray = new ushort[] { 0x422a, 0x422b, 0x421d, 0x4337 };
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
            ushort[] numArray = new ushort[] { 0x4229, 0x4228, 0x421d, 0x43c4, 0x43c5 };
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

