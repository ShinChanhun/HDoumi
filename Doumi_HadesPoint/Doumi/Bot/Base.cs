namespace Doumi.Bot
{
    using Doumi.Net;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Base
    {
        private bool _flag;
        //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        //private ProxyPatron <Patron>k__BackingField;
        private Thread _thread;

        public Base(ProxyPatron patron)
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

