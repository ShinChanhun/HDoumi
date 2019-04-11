namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class War
    {
        private bool _flag;
        //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        //private ProxyPatron <Patron>k__BackingField;
        private Thread _thread;

        public War(ProxyPatron patron)
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
                Thread.Sleep(0x3e8);
                Field field = this.Patron.Field;
                if ((this.Patron.Form != null) && (field != null))
                {
                    foreach (KeyValuePair<uint, Aisling> pair in field.Aislings)
                    {
                        double introduced17 = Math.Pow((double) (pair.Value.X - this.Patron.X), 2.0);
                        int num = (int) Math.Sqrt(introduced17 + Math.Pow((double) (pair.Value.Y - this.Patron.Y), 2.0));
                        if (this.Patron.isState() && !this.Patron.protectList.is이모탈)
                        {
                            break;
                        }
                        if (((this.Patron.Form.chk무길데프.Checked && (pair.Value.NameTint == 0)) && (num < 8)) && !this.Patron.isState())
                        {
                            this.Patron.UseSpell("데프레코", pair.Value);
                        }
                        if (((this.Patron.Form.chk적길데프.Checked && (pair.Value.NameTint == 6)) && (num < 8)) && !this.Patron.isState())
                        {
                            this.Patron.UseSpell("바르도", pair.Value);
                        }
                        if (((this.Patron.Form.chk무길나르.Checked && (pair.Value.NameTint == 0)) && ((pair.Value.Tint == 1) && (num < 8))) && !this.Patron.isState())
                        {
                            this.Patron.UseSpell("나르콜리", pair.Value);
                        }
                        if (((this.Patron.Form.chk적길나르.Checked && (pair.Value.NameTint == 6)) && (num < 8)) && !this.Patron.isState())
                        {
                            this.Patron.UseSpell("나르콜리", pair.Value);
                        }
                        if (((this.Patron.Form.chk무길리베.Checked && (pair.Value.NameTint == 0)) && (pair.Value.Immortal && (num < 8))) && !this.Patron.isState())
                        {
                            this.Patron.UseSpell("리베라토", pair.Value);
                        }
                        if (((this.Patron.Form.chk적길리베.Checked && (pair.Value.NameTint == 6)) && (pair.Value.Immortal && (num < 8))) && !this.Patron.isState())
                        {
                            this.Patron.UseSpell("리베라토", pair.Value);
                        }
                        if (((this.Patron.Form.chkTarget리베.Checked && (this.Patron.Form.tbWarTarget.Text != null)) && ((pair.Value.Name == this.Patron.Form.tbWarTarget.Text) && (num < 8))) && !this.Patron.isState())
                        {
                            this.Patron.UseSpell("리베라토", pair.Value);
                        }
                        if (((this.Patron.Form.chkTarget나르.Checked && (this.Patron.Form.tbWarTarget.Text != null)) && ((pair.Value.Name == this.Patron.Form.tbWarTarget.Text) && (num < 8))) && !this.Patron.isState())
                        {
                            this.Patron.UseSpell("나르콜리", pair.Value);
                        }
                        if (((this.Patron.Form.chkTarget데프.Checked && (this.Patron.Form.tbWarTarget.Text != null)) && ((pair.Value.Name == this.Patron.Form.tbWarTarget.Text) && (num < 8))) && !this.Patron.isState())
                        {
                            this.Patron.UseSpell("데프레코", pair.Value);
                        }
                    }
                }
                Thread.Sleep(350);
                if (this.Patron == null)
                {
                    this.Abort();
                }
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

