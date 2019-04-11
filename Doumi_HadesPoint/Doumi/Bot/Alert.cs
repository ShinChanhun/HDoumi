namespace Doumi.Bot
{
    using Doumi;
    using Doumi.Net;
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Alert
    {
        private bool _flag;
        //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        //private ProxyPatron <Patron>k__BackingField;
        private Thread _thread;

        public Alert(ProxyPatron patron)
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
                bool flag = false;
                Field field = this.Patron.Field;
                if (((this.Patron.Form != null) && (field != null)) && this.Patron.Form.chkAlert.Checked)
                {
                    foreach (KeyValuePair<uint, Aisling> pair in field.Aislings)
                    {
                        if ((pair.Value.Guid != this.Patron.Guid) && (pair.Value.Name == ""))
                        {
                            this.Patron.SpeakH("{=b<< Warning >> {=g주변에 은신중인 케릭터가 있습니다. {=o" + DateTime.Now.ToString("[H:mm:ss]"), 0);
                            this.Patron.SendMessage(3, "{=b<< Warning >> {=g주변에 은신중인 케릭터가 있습니다.");
                            if (this.Patron.Form.chk은신감지.Checked && !field.Name.EndsWith("여관"))
                            {
                                this.Patron.UseStockE("리콜");
                            }
                            flag = true;
                        }
                        if (((pair.Value.Guid != this.Patron.Guid) && (pair.Value.NameTint != 5)) && (pair.Value.Name != ""))
                        {
                            this.Patron.SpeakH("{=b<< Warning >> {=g주변에 그룹원이 아닌 케릭터가 있습니다. {=o<" + pair.Value.Name + "> {=g " + DateTime.Now.ToString("yyyy/MM/dd H:mm:ss"), 0);
                            this.Patron.SendMessage(3, "{=b<< Warning >> {=g주변에 그룹원이 아닌 케릭터가 있습니다. {=o<" + pair.Value.Name + ">");
                            if (this.Patron.Form.chk유저감지.Checked && !field.Name.EndsWith("여관"))
                            {
                                this.Patron.UseStockE("리콜");
                            }
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        if (this.Patron.Form.chkBeep.Checked)
                        {
                            Program.Beep(500, 250);
                        }
                        if ((this.Patron.Form != null) && this.Patron.Form.chkStopHunt.Checked)
                        {
                            Program.Form.ThreadSafeInvoke(delegate {
                                this.Patron.Form.chk자동사냥.Checked = false;
                                this.Patron.Form.chk저주.Checked = false;
                                this.Patron.Form.chk이아가호.Checked = false;
                                this.Patron.Form.chk세토아가호.Checked = false;
                                this.Patron.Form.chk맵이동.Checked = false;
                                this.Patron.Form.chk따라가기.Checked = false;
                                this.Patron.Form.chk코마.Checked = false;
                                this.Patron.Form.chk디스펠.Checked = false;
                            });
                        }
                    }
                }
                if (this.Patron == null)
                {
                    this.Abort();
                }
                Thread.Sleep(200);
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

