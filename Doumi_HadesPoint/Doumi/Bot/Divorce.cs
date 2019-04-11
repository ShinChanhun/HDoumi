namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Nexon.Net;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Divorce
    {
        private bool _flag;
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private ProxyPatron <Patron>k__BackingField;
        private Thread _thread;

        public Divorce(ProxyPatron patron)
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
            uint num = 0x290e;
            uint num2 = 0;
            while ((this.Patron.Form != null) && this._flag)
            {
                num2++;
                this.Patron.Speak("이혼하고 싶습니다." + num2);
                Thread.Sleep(100);
                NexonClientPacket packet = new NexonClientPacket(this.Patron, 0x3a);
                packet.WriteU1(1);
                packet.WriteU4(num);
                packet.WriteU1(1);
                packet.WriteU1(0x33);
                packet.WriteU1(0);
                packet.WriteU1(5);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);
                Thread.Sleep(100);
                packet = new NexonClientPacket(this.Patron, 0x3a);
                packet.WriteU1(1);
                packet.WriteU4(num);
                packet.WriteU1(1);
                packet.WriteU1(0x33);
                packet.WriteU1(0);
                packet.WriteU1(6);
                packet.WriteU1(1);
                packet.WriteU1(1);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);
                Thread.Sleep(100);
                packet = new NexonClientPacket(this.Patron, 0x3a);
                packet.WriteU1(1);
                packet.WriteU4(num);
                packet.WriteU1(1);
                packet.WriteU1(0x33);
                packet.WriteU1(0);
                packet.WriteU1(13);
                packet.WriteU1(0);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);
                Thread.Sleep(100);
                packet = new NexonClientPacket(this.Patron, 0x3a);
                packet.WriteU1(1);
                packet.WriteU4(num);
                packet.WriteU1(1);
                packet.WriteU1(0x33);
                packet.WriteU1(0);
                packet.WriteU1(14);
                packet.WriteU1(2);
                packet.WriteU1(0);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);
                Thread.Sleep(100);
                packet = new NexonClientPacket(this.Patron, 0x3a);
                packet.WriteU1(1);
                packet.WriteU4(num);
                packet.WriteU1(1);
                packet.WriteU1(0x33);
                packet.WriteU1(0);
                packet.WriteU1(0x16);
                packet.WriteU1(1);
                packet.WriteU1(1);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);
                Thread.Sleep(100);
                packet = new NexonClientPacket(this.Patron, 0x3a);
                packet.WriteU1(1);
                packet.WriteU4(num);
                packet.WriteU1(1);
                packet.WriteU1(0x33);
                packet.WriteU1(0);
                packet.WriteU1(0x1d);
                packet.WriteU1(0);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);
                Thread.Sleep(100);
                packet = new NexonClientPacket(this.Patron, 0x3a);
                packet.WriteU1(1);
                packet.WriteU4(num);
                packet.WriteU1(1);
                packet.WriteU1(0x33);
                packet.WriteU1(0);
                packet.WriteU1(30);
                packet.WriteU1(1);
                packet.WriteU1(1);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);
                Thread.Sleep(100);
                packet = new NexonClientPacket(this.Patron, 0x3a);
                packet.WriteU1(1);
                packet.WriteU4(num);
                packet.WriteU1(1);
                packet.WriteU1(0x33);
                packet.WriteU1(0);
                packet.WriteU1(0x22);
                packet.WriteU1(0);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);
                Thread.Sleep(100);
                packet = new NexonClientPacket(this.Patron, 0x3a);
                packet.WriteU1(1);
                packet.WriteU4(num);
                packet.WriteU1(1);
                packet.WriteU1(0x33);
                packet.WriteU1(0);
                packet.WriteU1(0x27);
                packet.WriteU1(0);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);
                Thread.Sleep(100);
                packet = new NexonClientPacket(this.Patron, 0x3a);
                packet.WriteU1(1);
                packet.WriteU4(num);
                packet.WriteU1(1);
                packet.WriteU1(0x33);
                packet.WriteU1(0);
                packet.WriteU1(40);
                packet.WriteU1(0);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);
                Thread.Sleep(100);
                if (this.Patron.TotalEXP < 0x16e360)
                {
                    Console.WriteLine("경팔끝");
                    this.Abort();
                }
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

