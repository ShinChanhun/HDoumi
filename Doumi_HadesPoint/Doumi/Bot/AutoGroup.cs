namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Nexon.Net;
    using Doumi.Types;
    using System.Threading;

    public class AutoGroup
    {
        private bool _flag;
        private Thread _thread;
        public AutoGroup(ProxyPatron patron)
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

            while ((this.Patron != null) && this._flag)
            {
                Thread.Sleep(3000);
                foreach(var pair in this.Patron.Field.Aislings)
                {
                    string name = pair.Value.Name;

                    if (name == Patron.Name) continue;

                    bool result = false;
                    uint guid = pair.Value.Guid;

                    if (this.Patron.Form == null) continue;
                    if (this.Patron.Form.groupList == null) continue;

                    foreach (var nameValue in this.Patron.Form.groupList)
                    {
                        if (name == Patron.Name) continue;

                        if (name == nameValue)
                        {
                            result = true;
                            break;
                        }    
                    }

                    if(result == true)
                    {
                        if(pair.Value.NameTint != 5)
                        {
                            Thread.Sleep(500);
                            NexonClientPacket packet1 = new NexonClientPacket(this.Patron, 0x2e);
                            packet1.WriteU1(02);
                            packet1.WriteC1(name);
                            packet1.WriteU1(0);
                            packet1.WriteU1(0);
                            this.Patron.Server.Send(packet1);
                            Thread.Sleep(100);
                        }
                    }
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