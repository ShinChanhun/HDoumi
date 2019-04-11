﻿namespace Doumi.Nexon.Net
{
    using System;
    using System.Runtime.CompilerServices;

    public abstract class NexonPatron<T> : NexonPatron where T: NexonPatron<T>
    {
        private Handler[] clientHandlers;
        private Handler[] serverHandlers;
        public byte Server04;
        public byte Server05;
        public byte Server07;
        public byte Server08;
        public byte Server0B;
        public byte Server33;
        public byte Server63;

        public NexonPatron(NexonSocket client, NexonSocket server) : base(client, server)
        {
            this.clientHandlers = new Handler[0x100];
            this.serverHandlers = new Handler[0x100];
        }

        public void ClientPacketReceived(NexonClientPacket packet)
        {
            packet.Decrypt();
            this.clientHandlers[packet.Code](this as T, packet);
        }

        private static void DefaultClientHandler(T patron, NexonPacket packet)
        {
            patron.Server.Send(packet);
        }

        private static void DefaultServerHandler(T patron, NexonPacket packet)
        {
            patron.Client.Send(packet);
        }

        public void HookClient(byte code, Handler handler)
        {
            this.clientHandlers[code] = handler ?? new Handler(NexonPatron<T>.DefaultClientHandler);
        }

        public void HookServer(byte code, Handler handler)
        {
            this.serverHandlers[code] = handler ?? new Handler(NexonPatron<T>.DefaultServerHandler);
        }

        public void Initialize()
        {
            for (int i = 0; i < 0x100; i++)
            {
                this.clientHandlers[i] = new Handler(NexonPatron<T>.DefaultClientHandler);
                this.serverHandlers[i] = new Handler(NexonPatron<T>.DefaultServerHandler);
            }
        }

        public void ServerPacketReceived(NexonServerPacket packet)
        {
            packet.Decrypt();
            if (packet.Code > 140)
            {
                if ((packet.Length == 12) && (packet.bufferR(11) == 0))
                {
                    this.Server05 = packet.Code;
                    packet.Code = 5;
                    this.serverHandlers[packet.Code](this as T, packet);
                    return;
                }
                if (((packet.Length > 0x4d) && (packet.bufferR(2) == 0)) && (packet.bufferR(4) == 0))
                {
                    this.Server33 = packet.Code;
                    packet.Code = 0x33;
                    this.serverHandlers[packet.Code](this as T, packet);
                    return;
                }
                if ((((packet.Length > 0x24) && (packet.bufferR(2) == 0)) && ((packet.bufferR(4) == 0) && (packet.bufferR(15) == 0xff))) && (packet.bufferR(0x10) == 0xff))
                {
                    this.Server33 = packet.Code;
                    packet.Code = 0x33;
                    this.serverHandlers[packet.Code](this as T, packet);
                    return;
                }
                if ((((packet.Length < 0x4d) && (packet.Length > 20)) && (packet.bufferR(2) == 0)) && (packet.bufferR(4) == 0))
                {
                    this.Server07 = packet.Code;
                    packet.Code = 7;
                    this.serverHandlers[packet.Code](this as T, packet);
                    return;
                }
                if ((((packet.Length < 11) && (packet.bufferR(2) < 4)) && ((packet.bufferR(3) == 0) && (packet.bufferR(5) == 0))) && (packet.bufferR(7) == 0))
                {
                    this.Server0B = packet.Code;
                    packet.Code = 11;
                    this.serverHandlers[packet.Code](this as T, packet);
                    return;
                }
                if (((packet.Length == 0x5c) || (packet.Length == 0x5d)) && (packet.bufferR(2) == 60))
                {
                    this.Server08 = packet.Code;
                    packet.Code = 8;
                    this.serverHandlers[packet.Code](this as T, packet);
                    return;
                }
                if (((packet.Length == 7) && (packet.bufferR(2) == 0)) && (packet.bufferR(4) == 0))
                {
                    this.Server04 = packet.Code;
                    packet.Code = 4;
                    this.serverHandlers[packet.Code](this as T, packet);
                    return;
                }
                if ((packet.Length == 11) && (packet.bufferR(2) == 0x10))
                {
                    this.Server08 = packet.Code;
                    packet.Code = 8;
                    this.serverHandlers[packet.Code](this as T, packet);
                    return;
                }
                if ((packet.Length == 0x13) && (packet.bufferR(2) == 5))
                {
                    this.Server08 = packet.Code;
                    packet.Code = 8;
                    this.serverHandlers[packet.Code](this as T, packet);
                    return;
                }
                if ((packet.Length == 11) && (packet.bufferR(2) == 0x11))
                {
                    this.Server08 = packet.Code;
                    packet.Code = 8;
                    this.serverHandlers[packet.Code](this as T, packet);
                    return;
                }
                if ((packet.Length == 0x13) && (packet.bufferR(2) == 4))
                {
                    this.Server08 = packet.Code;
                    packet.Code = 8;
                    this.serverHandlers[packet.Code](this as T, packet);
                    return;
                }
                if ((packet.Length == 0x25) && (packet.bufferR(2) == 0x20))
                {
                    this.Server08 = packet.Code;
                    packet.Code = 8;
                    this.serverHandlers[packet.Code](this as T, packet);
                    return;
                }
                if ((packet.Length == 0x35) && (packet.bufferR(2) == 0x24))
                {
                    this.Server08 = packet.Code;
                    packet.Code = 8;
                    this.serverHandlers[packet.Code](this as T, packet);
                    return;
                }
                if ((packet.Length == 0x23) && (packet.bufferR(2) == 8))
                {
                    this.Server08 = packet.Code;
                    packet.Code = 8;
                    this.serverHandlers[packet.Code](this as T, packet);
                    return;
                }
                if (packet.bufferR(2) == 6)
                {
                    this.Server63 = packet.Code;
                    packet.Code = 0x63;
                    this.serverHandlers[packet.Code](this as T, packet);
                    return;
                }
            }
            this.serverHandlers[packet.Code](this as T, packet);
        }

        public delegate void Handler(T patron, NexonPacket packet);
    }
}

