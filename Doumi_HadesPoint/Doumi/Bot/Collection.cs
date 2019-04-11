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

    public class Collection
    {
        private bool _flag;
        //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        //private ProxyPatron <Patron>k__BackingField;
        private Thread _thread;

        public Collection(ProxyPatron patron)
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
            while ((this.Patron != null) && this._flag)
            {
                Stock stock;
                if (this.Patron.TryGetStockS("채집용설탕물", out stock))
                {
                    NexonClientPacket packet = new NexonClientPacket(this.Patron, 0x1c);
                    packet.WriteU1(stock.Slot);
                    this.Patron.Server.Send(packet);
                    Thread.Sleep(0x3e8);
                }
                else
                {
                    this.BuyBait(this.Patron);
                }
                if (this.Patron == null)
                {
                    this.Abort();
                }
                Thread.Sleep(0x3e8);
            }
        }

        public void BuyBait(ProxyPatron patron)
        {
            uint guid = 0;
            Field field = this.Patron.Field;
            foreach (KeyValuePair<uint, Mundane> pair in field.Mundanes)
            {
                if (pair.Value.Icon == 0x4038)
                {
                    guid = pair.Value.Guid;
                    break;
                }
            }
            if (guid == 0)
            {
                Thread.Sleep(0x3e8);
            }
            NexonClientPacket packet = new NexonClientPacket(patron, 0x43);
            packet.WriteU1(1);
            packet.WriteU4(guid);
            packet.WriteU1(0);
            patron.Server.Send(packet);
            Thread.Sleep(500);
            NexonClientPacket packet2 = new NexonClientPacket(patron, 0x39);
            packet2.WriteU1(1);
            packet2.WriteU4(guid);
            packet2.WriteU1(0);
            packet2.WriteU1(0x40);
            packet2.WriteU1(0);
            patron.Server.Send(packet2);
            Thread.Sleep(500);
            uint num2 = patron.TotalStockCount();
            for (uint i = 0; i < (0x3b - num2); i++)
            {
                NexonClientPacket packet3 = new NexonClientPacket(patron, 0x39);
                packet3.WriteU1(1);
                packet3.WriteU4(guid);
                packet3.WriteU1(0);
                packet3.WriteU1(0x4a);
                packet3.WriteC1("채집용설탕물");
                patron.Server.Send(packet3);
                Thread.Sleep(600);
            }
            patron.PanelClose();
        }

        public void collection(ProxyPatron patron)
        {
            Stock stock;
            if (patron.TryGetStockS("채집용설탕물", out stock))
            {
                NexonClientPacket packet = new NexonClientPacket(patron, 0x1c);
                packet.WriteU1(stock.Slot);
                patron.Server.Send(packet);
                Thread.Sleep(100);
                if (patron.TryGetStockS("채집망", out stock))
                {
                    if ((stock.CurrentDurability <= 900) && (stock.Slot != 1))
                    {
                        patron.MoveStock(stock.Slot, 1);
                        patron.UseSkill("아이템고치기");
                        Thread.Sleep(300);
                    }
                    NexonClientPacket packet2 = new NexonClientPacket(patron, 0x1c);
                    packet2.WriteU1(stock.Slot);
                    patron.Server.Send(packet2);
                    Thread.Sleep(300);
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

