namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Nexon.Net;
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Fix
    {
        private bool _flag;
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private ProxyPatron <Patron>k__BackingField;
        private Thread _thread;

        public Fix(ProxyPatron patron)
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
            Thread.Sleep(0x3e8);
            while ((this.Patron.Form != null) && this._flag)
            {
                Stock stock;
                if (this.Patron.Form.chk어설픈수리.Checked && this.Patron.TryGetStockS("어설픈", out stock))
                {
                    if (stock.Slot != 1)
                    {
                        this.Patron.MoveStock(stock.Slot, 1);
                    }
                    uint guid = 0;
                    foreach (KeyValuePair<uint, Mundane> pair in this.Patron.Field.Mundanes)
                    {
                        if (pair.Value.Icon == 0x401e)
                        {
                            guid = pair.Value.Guid;
                            break;
                        }
                    }
                    if (guid == 0)
                    {
                        Thread.Sleep(0x3e8);
                    }
                    else
                    {
                        NexonClientPacket packet = new NexonClientPacket(this.Patron, 0x43);
                        packet.WriteU1(1);
                        packet.WriteU4(guid);
                        packet.WriteU1(0);
                        this.Patron.Server.Send(packet);
                        Thread.Sleep(100);
                        packet = new NexonClientPacket(this.Patron, 0x39);
                        packet.WriteU1(1);
                        packet.WriteU4(guid);
                        packet.WriteU1(10);
                        packet.WriteU1(0x7b);
                        packet.WriteU1(0);
                        this.Patron.Server.Send(packet);
                        Thread.Sleep(100);
                        for (int i = 0; i < 6; i++)
                        {
                            packet = new NexonClientPacket(this.Patron, 0x3a);
                            packet.WriteU1(1);
                            packet.WriteU4(guid);
                            packet.WriteU4(2);
                            packet.WriteU1(0);
                            packet.WriteU1(0);
                            this.Patron.Server.Send(packet);
                            Thread.Sleep(100);
                        }
                    }
                }
                Thread.Sleep(300);
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

