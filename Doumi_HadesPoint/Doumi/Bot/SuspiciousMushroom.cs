namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Nexon.Net;
    using Doumi.Types;
    using System.Threading;

    public class SuspiciousMushroom
    {
        private bool _flag;
        private Thread _thread;
        public SuspiciousMushroom(ProxyPatron patron)
        {
            this.Patron = patron;

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
            uint npc_SeonJin = 0x25ea;
            uint npc_Seo = 0x25e6;
            uint npc_Can = 0x25e9;

            while ((this.Patron != null) && this._flag)
            {
                Field field = this.Patron.Field;
                Thread.Sleep(1000);
                NexonClientPacket packet1 = new NexonClientPacket(this.Patron, 0x55);
                packet1.WriteU1(1);
                packet1.WriteU1(0x0e);
                packet1.WriteU1(0x01);
                packet1.WriteU1(0x0e);
                packet1.WriteU1(0xbc);
                packet1.WriteU1(0xf6);
                packet1.WriteU1(0xbb);
                packet1.WriteU1(0xf3);
                packet1.WriteU1(0xc7);
                packet1.WriteU1(0xd1);
                packet1.WriteU1(0xb9);
                packet1.WriteU1(0xf6);
                packet1.WriteU1(0xbc);
                packet1.WriteU1(0xb8);
                packet1.WriteU1(0xc1);
                packet1.WriteU1(0xa6);
                packet1.WriteU1(0xc1);
                packet1.WriteU1(0xb6);
                packet1.WriteU1(0);
                packet1.WriteU1(0);
                this.Patron.Server.Send(packet1);
                Thread.Sleep(100);


            }
            if (this.Patron == null)
            {
                this.Abort();
            }
        }

        public ProxyPatron Patron { get; set; }
    }

}