namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Loot
    {
        private bool _flag;
        //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        //private ProxyPatron <Patron>k__BackingField;
        private Thread _thread;

        public Loot(ProxyPatron patron)
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
            string[] strArray = new string[] { 
                "보로보로의껍질", "보로보로냥의껍질", "빅보로", "블루피치", "블루메가", "레드", "그린", "[전사]마법시전-2", "[전사]마법시전-2", "[전사]STR+10", "[도가]CON+10", "[직자]WIS+10",
                "[법사]INT+10", "[도적]DEX+10", "빅토리아반", "금전", "향상된", "강화된", "루딘", "금전더미", "뉴트", "다이아", "블루", "챰릴리", "홀리", "여의주", "비밀", "안크",
                "블랙", "태양의돌", "대지의돌", "A구역", "B구역", "C구역", "D구역", "E구역", "F구역", "나겔링", "마도코어별", "마도코어달", "마도코어해", "스쿼시", "스플릿", "블라인드",
                "블로우", "펄비스트"
            };
            try
            {
                while ((this.Patron != null) && this._flag)
                {
                    Field field = this.Patron.Field;
                    if ((((this.Patron.Form != null) && this.Patron.Form.chk자동루팅.Checked) && (this.Patron.TotalStockCount() < 0x3b)) && ((this.Patron.MaxWeight.Get() - this.Patron.CurrentWeight.Get()) > 1))
                    {
                        foreach (KeyValuePair<uint, MapItem> pair in field.MapItems)
                        {
                            double introduced17 = Math.Pow((double) (pair.Value.X - this.Patron.X), 2.0);
                            int num = (int) Math.Sqrt(introduced17 + Math.Pow((double) (pair.Value.Y - this.Patron.Y), 2.0));
                            if (num > 2)
                            {
                                foreach (string str in strArray)
                                {
                                    if (pair.Value.Name.StartsWith(str))
                                    {
                                        this.Patron.mTeleport.WaitOne();
                                        this.Patron.MoveByTeleport(this.Patron, pair.Value.X, pair.Value.Y);
                                        this.Patron.mTeleport.ReleaseMutex();
                                        this.Patron.mInventory.WaitOne();
                                        byte slot = this.Patron.EmptySlot();
                                        this.Patron.mInventory.ReleaseMutex();
                                        this.Patron.GetStock(slot, pair.Value.X, pair.Value.Y);
                                        break;
                                    }
                                }
                            }
                            if ((num < 3) && !this.Patron.Form.isTrashItem(pair.Value.Name))
                            {
                                this.Patron.mInventory.WaitOne();
                                byte slot = this.Patron.EmptySlot();
                                this.Patron.mInventory.ReleaseMutex();
                                this.Patron.GetStock(slot, pair.Value.X, pair.Value.Y);
                            }
                        }
                    }
                    Thread.Sleep(250);
                    if (this.Patron == null)
                    {
                        this.Abort();
                    }
                }
            }
            catch
            {
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

