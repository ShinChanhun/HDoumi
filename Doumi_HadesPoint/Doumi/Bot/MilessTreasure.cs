namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Nexon.Net;
    using Doumi.Types;
    using System.Threading;

    public class MilessTresure
    {
        private bool _flag;
        private Thread _thread;
        private FormPatron _form;
        
        private int checkPointLength;

        public MilessTresure(ProxyPatron patron)
        {
            this.Patron = patron;
            this._form = patron.Form;

        }
        public void Start()
        {
            this._flag = true;
            this._thread = new Thread(new ThreadStart(this.Auto));
            this._thread.Start();
        }

        public void Abort()
        {
            this._flag = false;
            this._thread = null;
        }

        public void Auto()
        {
            var field = Patron.Field;

            while ((this.Patron != null) && this._flag)
            {
                Thread.Sleep(5000);

                var a = field.Monsters;
                foreach(var m in field.Monste)
                {
                    //if(m.Value.)
                }
            }
            if (this.Patron == null)
            {
                this.Abort();
            }
        }

        public ProxyPatron Patron { get; set; }
        
    }
}