namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class BuffControl
    {
        private bool _flag;
        //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        //private ProxyPatron <Patron>k__BackingField;
        private Thread _thread;

        public BuffControl(ProxyPatron patron)
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
            TimeSpan span = new TimeSpan(0, 3, 1);
            TimeSpan span2 = new TimeSpan(0, 3, 1);
            TimeSpan span3 = new TimeSpan(0, 0, 0x29);
            Field field = this.Patron.Field;
            while ((this.Patron != null) && this._flag)
            {
                try
                {
                    if ((this.Patron.BuffNote != null) && !this.Patron.isState())
                    {
                        foreach (KeyValuePair<string, Buff> pair in this.Patron.BuffNote)
                        {
                            if (pair.Value.Guid == 0)
                            {
                                foreach (KeyValuePair<uint, Aisling> pair2 in field.Aislings)
                                {
                                    if ((pair.Value.Name == pair2.Value.Name) && (pair2.Value.NameTint == 5))
                                    {
                                        pair.Value.Guid = pair2.Value.Guid;
                                        break;
                                    }
                                    if (pair2.Value.NameTint != 5)
                                    {
                                        Buff buff;
                                        this.Patron.BuffNote.TryRemove(pair2.Value.Name, out buff);
                                        break;
                                    }
                                }
                            }
                            else if ((this.Patron.CurrentMP.Get() > 0xbb8) && !this.IgnoreUser(pair.Value.Name))
                            {
                                if (this.Patron.isState() || (this.Patron.Form.chk이모탈.Checked && !this.Patron.protectList.is이모탈))
                                {
                                    goto Label_0423;
                                }
                                double introduced21 = Math.Pow((double) (pair.Value.X - this.Patron.X), 2.0);
                                int num = (int) Math.Sqrt(introduced21 + Math.Pow((double) (pair.Value.Y - this.Patron.Y), 2.0));
                                if (((this.Patron.Form.chkHorrma.Checked && (num < 8)) && (this.Patron.Name != pair.Value.Name)) && (span < (DateTime.Now - pair.Value.Horrama)))
                                {
                                    this.Patron.UseSpell("호르라마", pair.Value.Guid, pair.Value.X, pair.Value.Y);
                                }
                                if (((this.Patron.Form.chkKolama.Checked && (num < 8)) && (this.Patron.Name != pair.Value.Name)) && (span2 < (DateTime.Now - pair.Value.Kolama)))
                                {
                                    this.Patron.UseSpell("콜라마", pair.Value.Guid, pair.Value.X, pair.Value.Y);
                                }
                                if (((this.Patron.Form.chkSA.Checked && (num < 8)) && (this.Patron.Name != pair.Value.Name)) && (span3 < (DateTime.Now - pair.Value.StrengthenAttribute)))
                                {
                                    this.Patron.UseSpell("속성강화", pair.Value.Guid, pair.Value.X, pair.Value.Y);
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            Label_0423:
                if (this.Patron == null)
                {
                    this.Abort();
                }
                Thread.Sleep(500);
            }
        }

        public bool IgnoreUser(string name)
        {
            string[] strArray = new string[] { "모모", "야다", "마이", "타락한꼬마", "다시", "파디아", "사카라", "하쿠아", "서시" };
            foreach (string str in strArray)
            {
                if (str == name)
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

