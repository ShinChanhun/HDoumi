﻿namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Nexon.Net;
    using Doumi.Types;
    using System.Threading;

    public class MilessTresure
    {
        private bool _flag;
        private Thread _threadMove;
        private Thread _threadClick;
        private FormPatron _form;

        private int _moveCount;
        private int _mapCount;
        private bool _mapFlag_1;
        private bool _mapFlag_2;
        private bool _treasureFlag;

        public int[,] m131 = { { 5, 15 }, { 5, 27 }, { 14, 28 }, { 7, 44 }, { 20, 42 }, { 29, 34 }, { 38, 40 }, { 42, 28 }, { 42, 14 }, { 41, 3 }, { 28, 20 }, { 19, 11 }, { 12, 4 }, { 11, 2 } };
        public int[,] m141 = { { 10, 4 }, { 20, 4 }, { 30, 4 }, { 34, 14 }, { 46, 14 }, { 34, 34 }, { 44, 34 }, { 42, 45 }, { 22, 45 }, { 11, 45 }, { 15, 34 }, { 3, 34 }, { 3, 24 }, { 3, 14 }, { 15, 15 }, { 15, 15 } };
        public int[,] m151 = { { 8, 8 }, { 4, 18 }, { 8, 29 }, { 17, 25 }, { 17, 17 }, { 16, 8 }, { 27, 8 }, { 24, 21 }, { 25, 33 }, { 8, 44 }, { 21, 44 }, { 33, 39 }, { 44, 38 }, { 42, 27 }, { 42, 16 }, { 43, 5 } };
        public int[,] m161 = { { 3, 41 }, { 10, 41 }, { 25, 41 }, { 40, 41 }, { 40, 25 }, { 25, 25 }, { 10, 25 }, { 10, 12 }, { 22, 12 }, { 34, 12 }, { 43, 7 }, { 10, 4 }, { 22, 4 }, { 34, 4 }, { 43, 7 } };

        public int[,] m132 = { { 6, 23 }, { 8, 31 }, { 6, 44 }, { 15, 39 }, { 26, 42 }, { 16, 28 }, { 19, 21 }, { 29, 22 }, { 36, 32 }, { 41, 40 }, { 42, 29 }, { 40, 21 }, { 33, 11 }, { 44, 8 }, { 35, 4 }, { 25, 8 }, { 16, 5 }, { 36, 26 }, { 14, 41 }, { 7, 9 }, { 33, 11 }, { 24, 31 }, { 13, 47 } };
        public int[,] m142 = { { 43, 7 }, { 34, 6 }, { 32, 15 }, { 22, 17 }, { 14, 17 }, { 22, 5 }, { 14, 5 }, { 10, 6 }, { 13, 24 }, { 21, 26 }, { 28, 28 }, { 39, 32 }, { 43, 43 }, { 28, 42 }, { 15, 43 }, { 3, 42 }, { 6, 29 }, { 12, 28 } };
        public int[,] m152 = { { 41, 6 }, { 41, 13 }, { 41, 19 }, { 41, 26 }, { 40, 33 }, { 41, 42 }, { 28, 19 }, { 18, 19 }, { 26, 7 }, { 18, 8 }, { 20, 31 }, { 26, 34 }, { 24, 42 }, { 16, 42 }, { 16, 33 }, { 6, 42 }, { 6, 34 }, { 6, 26 }, { 6, 20 }, { 6, 12 }, { 6, 5 } };
        public int[,] m153 = { { 17, 3 }, { 20, 9 }, { 24, 13 }, { 27, 19 }, { 27, 25 }, { 31, 31 }, { 38, 32 }, { 44, 31 }, { 40, 23 }, { 42, 16 }, { 41, 10 }, { 41, 3 }, { 44, 43 }, { 34, 42 }, { 25, 41 }, { 17, 41 }, { 10, 40 }, { 4, 41 }, { 21, 30 }, { 12, 29 }, { 8, 29 }, { 6, 23 }, { 5, 16 } };
        public int[,] m162 = { { 38, 45 }, { 31, 45 }, { 24, 45 }, { 16, 45 }, { 10, 45 }, { 3, 43 }, { 3, 34 }, { 16, 32 }, { 3, 25 }, { 3, 15 }, { 15, 14 }, { 3, 4 }, { 12, 3 }, { 20, 3 }, { 28, 3 }, { 36, 3 }, { 44, 3 }, { 46, 9 }, { 34, 15 }, { 45, 17 }, { 45, 24 }, { 45, 30 }, { 33, 33 }, { 45, 37 }, { 43, 44 } };

        public int[,] m143 = { { 5, 42 }, { 7, 34 }, { 10, 27 }, { 14, 21 }, { 13, 11 }, { 5, 6 }, { 13, 4 }, { 19, 5 }, { 19, 18 }, { 26, 19 }, { 33, 18 }, { 32, 8 }, { 39, 4 }, { 29, 21 }, { 27, 29 }, { 25, 36 }, { 17, 35 }, { 16, 43 }, { 28, 44 }, { 33, 39 }, { 33, 29 }, { 41, 27 }, { 40, 38 }, { 43, 42 }, { 45, 34 } };
        public int[,] m154 = { { 7, 23 }, { 6, 31 }, { 10, 35 }, { 6, 42 }, { 14, 42 }, { 21, 43 }, { 28, 42 }, { 28, 33 }, { 24, 25 }, { 32, 24 }, { 35, 29 }, { 40, 32 }, { 40, 40 }, { 44, 43 }, { 44, 32 }, { 43, 22 }, { 43, 7 }, { 34, 8 }, { 24, 8 }, { 11, 7 }, { 4, 9 } };
        public int[,] m163 = { { 42, 33 }, { 43, 25 }, { 43, 16 }, { 42, 6 }, { 32, 5 }, { 34, 13 }, { 32, 20 }, { 25, 16 }, { 19, 16 }, { 19, 6 }, { 10, 5 }, { 13, 15 }, { 12, 24 }, { 9, 31 }, { 4, 41 }, { 13, 42 }, { 15, 32 }, { 23, 33 }, { 30, 31 }, { 31, 42 }, { 38, 33 } };
        public int[,] m164 = { { 41, 4 }, { 33, 8 }, { 32, 18 }, { 23, 18 }, { 12, 12 }, { 19, 6 }, { 8, 6 }, { 12, 16 }, { 11, 26 }, { 7, 32 }, { 5, 40 }, { 13, 27 }, { 21, 25 }, { 27, 27 }, { 27, 35 }, { 28, 42 }, { 16, 42 }, { 16, 34 }, { 24, 33 }, { 36, 28 }, { 43, 43 }, { 44, 34 }, { 38, 27 }, { 35, 18 }, { 34, 8 } };


        public string[] mName = { "13-1", "14-1", "15-1", "16-1" };

        public MilessTresure(ProxyPatron patron)
        {
            this.Patron = patron;
            this._form = patron.Form;

        }

        public void Start()
        {
            this._flag = true;
            this._threadMove = new Thread(new ThreadStart(this.AutoMove));
            this._threadMove.Start();
            this._threadClick = new Thread(new ThreadStart(this.AutoClick));
            this._threadClick.Start();
            _moveCount = 0;
            _mapCount = 0;
            _mapFlag_1 = false;
            _mapFlag_2 = false;
            _treasureFlag = false;
        }

        public void Abort()
        {
            this._flag = false;
            this._threadMove = null;
            this._threadClick = null;
        }

        public void AutoClick()
        {
            while ((this.Patron != null) && this._flag)
            {
                Thread.Sleep(2000);


                if (Patron.Field.Name.Contains("밀레스잡화상점B"))
                    continue;

                Patron.Refresh();

            }
            if (this.Patron == null)
            {
                this.Abort();
            }
        }

        public void AutoMove()
        { 
            if (Patron.TryGetStockS("이아의구원") == false)
            {
                Patron.UseStockS("밀레스리콜");

                return;
            }

            while ((this.Patron != null) && this._flag)
            {
                Thread.Sleep(400);

                //Patron.Refresh();

                Revive();

                var field = Patron.Field;



                if (field.Mundanes.Count > 0 && field.Name.StartsWith("지하"))
                {

                    foreach (var m in field.Mundanes)
                    {
                        if (m.Value.Name.EndsWith("1") || m.Value.Name.EndsWith("2"))
                        {
                            _treasureFlag = true;
                            NexonClientPacket packet = new NexonClientPacket(this.Patron, 0x43);
                            packet.WriteU1(1);
                            packet.WriteU4(m.Value.Guid);
                            packet.WriteU1(0);
                            this.Patron.Server.Send(packet);

                            Thread.Sleep(1000);
                        }
                        else
                        {
                            _treasureFlag = false;
                        }
                    }
                }
                else
                {
                    _treasureFlag = false;

                }
                if (field.Mundanes.Count == 0)
                {
                }
                //Patron.Refresh();
                MoveControl();
            }
            if (this.Patron == null)
            {
                this.Abort();
            }
        }

        void MoveControl()
        {
            if (_treasureFlag == true) return;


            if (Patron.Field.Name.Contains("대기실") == true) return;

            if (Patron.Field.Name.Contains("지하묘지") == false) return;

            Patron.mTeleport.WaitOne();

            if (Patron.Name == "지존하나")
                Mil_1();

            if (Patron.Name == "지존둘")
                Mil_2();

            if (Patron.Name == "지존셋")
                Mil_3();

            if (Patron.TryGetStockS("쿠라눔")) Patron.UseStockS("쿠라눔");
            if (Patron.TryGetStockS("쿠룸")) Patron.UseStockS("쿠룸");
            if (Patron.TryGetStockS("마라디움")) Patron.UseStockS("마라디움");

            Patron.mTeleport.ReleaseMutex();

            //Patron.Refresh();
        }

        public void Mil_1()
        {
            //if (Patron.Form.chk밀트1.Checked == false) return;

            int rx = Patron.r.Next(0, 2);
            int ry = Patron.r.Next(0, 2);

            int mlength = 0;

            if (Patron.Field.Name.Contains("13-1")) _mapCount = 0;
            else if (Patron.Field.Name.Contains("14-1")) _mapCount = 1;
            else if (Patron.Field.Name.Contains("15-1")) _mapCount = 2;
            else if (Patron.Field.Name.Contains("16-1")) _mapCount = 3;

            if (_mapFlag_1)
            {
                if (Patron.Field.Name.Contains("13-1"))
                {
                    _mapFlag_1 = false;
                }
                else if (Patron.Field.Name.Contains("14-1"))
                {
                    Patron.MoveByTeleport(Patron, 44, 1);
                    Patron.Walk(0, 1);
                }
                else if (Patron.Field.Name.Contains("15-1"))
                {
                    Patron.MoveByTeleport(Patron, 1, 6);
                    Patron.Walk(3, 1);
                }
                else if (Patron.Field.Name.Contains("16-1"))
                {
                    Patron.MoveByTeleport(Patron, 8, 1);
                    Patron.Walk(0, 1);
                }


                return;
            }

            mlength = GetMapLength(_mapCount);
            Patron.MoveByTeleport(Patron, GetMapPoint(_mapCount, _moveCount)[0] + rx, GetMapPoint(_mapCount, _moveCount)[1] + ry);

            if (_moveCount >= mlength)
            {
                if (Patron.Field.Name.Contains("13") == true)
                {
                    Patron.MoveByTeleport(Patron, 11, 2);
                    Patron.Walk(0, 1);
                    _moveCount = 0;
                    Thread.Sleep(300);
                }
                else if (Patron.Field.Name.Contains("14") == true)
                {
                    Patron.MoveByTeleport(Patron, 19, 10);
                    Patron.Walk(0, 1);
                    _moveCount = 0;
                    Thread.Sleep(300);
                }
                else if (Patron.Field.Name.Contains("15") == true)
                {
                    Patron.MoveByTeleport(Patron, 45, 33);
                    Patron.Walk(0, 1);

                    _moveCount = 0;
                    Thread.Sleep(300);
                }
                else if (Patron.Field.Name.Contains("16") == true)
                {
                    Patron.MoveByTeleport(Patron, 8, 1);
                    Patron.Walk(0, 1);

                    _moveCount = 0;

                    _mapFlag_1 = true;
                    Thread.Sleep(300);
                }
            }
            else
            {
                int x = GetMapPoint(_mapCount, _moveCount)[0];
                int y = GetMapPoint(_mapCount, _moveCount)[1];
                if (this.Patron.X >= x && this.Patron.X <= x + 2 &&
                    this.Patron.Y >= y && this.Patron.Y <= y + 2)
                    _moveCount++;
            }
        }

        public void Mil_2()
        {
            //if (Patron.Form.chk밀트2.Checked == false) return;

            if (Patron.Field.Name.Contains("13-1") == true || Patron.Field.Name.Contains("12-1") == true) return;

            int rx = Patron.r.Next(0, 2);
            int ry = Patron.r.Next(0, 2);

            int mlength = 0;

            if (Patron.Field.Name.Contains("13-2")) _mapCount = 0;
            else if (Patron.Field.Name.Contains("14-2")) _mapCount = 1;
            else if (Patron.Field.Name.Contains("15-2")) _mapCount = 2;
            else if (Patron.Field.Name.Contains("15-3")) _mapCount = 3;
            else if (Patron.Field.Name.Contains("16-2")) _mapCount = 4;

            if (_mapFlag_1)
            {
                if (Patron.Field.Name.Contains("13-2"))
                {
                    _mapFlag_1 = false;
                    Thread.Sleep(300);
                }
                else if (Patron.Field.Name.Contains("14-2"))
                {
                    Patron.MoveByTeleport(Patron, 44, 23);
                    Patron.Walk(0, 1);
                    Thread.Sleep(300);
                }
                else if (Patron.Field.Name.Contains("15-3"))
                {
                    Patron.MoveByTeleport(Patron, 27, 29);
                    Thread.Sleep(200);

                    Patron.MoveByTeleport(Patron, 20, 7);
                    Thread.Sleep(200);

                    Patron.MoveByTeleport(Patron, 14, 1);
                    Patron.Walk(0, 1);
                    Thread.Sleep(300);

                }
                else if (Patron.Field.Name.Contains("16-2"))
                {
                    Patron.MoveByTeleport(Patron, 38, 42);
                    Patron.Walk(0, 1);
                    Thread.Sleep(300);
                }

                return;
            }

            mlength = GetMapLength(_mapCount);
            Patron.MoveByTeleport(Patron, GetMapPoint(_mapCount, _moveCount)[0] + rx, GetMapPoint(_mapCount, _moveCount)[1] + ry);

            if (_moveCount >= mlength)
            {
                if (Patron.Field.Name.Contains("13-2") == true)
                {
                    Thread.Sleep(300);

                    int r = Patron.r.Next(0, 3);

                    switch (r)
                    {
                        case 0:
                            Patron.MoveByTeleport(Patron, 6, 41);
                            Patron.Walk(0, 0);
                            _moveCount = 0;
                            break;
                        case 1:
                            Patron.MoveByTeleport(Patron, 5, 40);
                            Patron.Walk(1, 0);
                            _moveCount = 0;
                            break;
                        case 2:
                            Patron.MoveByTeleport(Patron, 7, 40);
                            Patron.Walk(3, 0);
                            _moveCount = 0;
                            break;
                    }
                }
                else if (Patron.Field.Name.Contains("14-2") == true)
                {
                    if (_mapFlag_2 == false)
                    {
                        Patron.MoveByTeleport(Patron, 5, 28);
                        Patron.Walk(3, 1);
                        _moveCount = 0;
                    }
                    else
                    {
                        Patron.MoveByTeleport(Patron, 28, 13);
                        Patron.Walk(3, 1);
                    }
                }
                else if (Patron.Field.Name.Contains("15-2") == true)
                {
                    Patron.MoveByTeleport(Patron, 35, 1);
                    Patron.Walk(0, 1);
                    _mapFlag_2 = true;
                    _moveCount = 0;
                }
                else if (Patron.Field.Name.Contains("15-3") == true)
                {
                    int rx1 = Patron.r.Next(0, 2);
                    int ry1 = Patron.r.Next(0, 2);
                    Patron.MoveByTeleport(Patron, 15 + rx1, 25 + ry1);

                    Thread.Sleep(1000);

                    if (Patron.X >= 15 && Patron.X <= 15 + rx1 &&
                        Patron.Y >= 25 & Patron.Y <= 25 + ry1)
                    {
                        Patron.MoveByTeleport(Patron, 15, 22);
                        Patron.Walk(0, 1);

                        _moveCount = 0;
                    }

                }
                else if (Patron.Field.Name.Contains("16-2") == true)
                {
                    Patron.MoveByTeleport(Patron, 38, 42);
                    Patron.Walk(0, 1);

                    _moveCount = 0;

                    _mapFlag_1 = true;
                    _mapFlag_2 = false;
                }
            }
            else
            {
                int x = GetMapPoint(_mapCount, _moveCount)[0];
                int y = GetMapPoint(_mapCount, _moveCount)[1];
                if (this.Patron.X >= x && this.Patron.X <= x + 2 &&
                    this.Patron.Y >= y && this.Patron.Y <= y + 2)
                    _moveCount++;
            }
        }

        public void Mil_3()
        {
            //if (Patron.Form.chk밀트2.Checked == false) return;

            if (Patron.Field.Name.Contains("13-1") == true || Patron.Field.Name.Contains("12-1") == true || Patron.Field.Name.Contains("12-2") == true) return;

            int rx = Patron.r.Next(0, 2);
            int ry = Patron.r.Next(0, 2);

            int mlength = 0;

            if (Patron.Field.Name.Contains("14-3")) _mapCount = 0;
            else if (Patron.Field.Name.Contains("15-4")) _mapCount = 1;
            else if (Patron.Field.Name.Contains("16-3")) _mapCount = 2;
            else if (Patron.Field.Name.Contains("16-4")) _mapCount = 3;

            if (_mapFlag_1)
            {
                if (Patron.Field.Name.Contains("14-3"))
                {
                    _mapFlag_1 = false;
                    Thread.Sleep(300);
                }
                else if (Patron.Field.Name.Contains("15-4"))
                {
                    Patron.MoveByTeleport(Patron, 27, 7);
                    Thread.Sleep(300);
                    Patron.MoveByTeleport(Patron, 24, 30);
                    Thread.Sleep(300);
                    Patron.MoveByTeleport(Patron, 8, 19);
                    Thread.Sleep(300);
                    Patron.Walk(0, 1);
                    Thread.Sleep(300);

                }
                else if (Patron.Field.Name.Contains("16-4"))
                {
                    Patron.MoveByTeleport(Patron, 32, 1);
                    Patron.Walk(0, 1);
                    Thread.Sleep(300);

                }

                return;
            }

            mlength = GetMapLength(_mapCount);
            Patron.MoveByTeleport(Patron, GetMapPoint(_mapCount, _moveCount)[0] + rx, GetMapPoint(_mapCount, _moveCount)[1] + ry);

            if (Patron.Field.Name.Contains("15-4") == true && _mapFlag_2 == true)
            {
                int rx2 = Patron.r.Next(0, 2);
                int ry2 = Patron.r.Next(0, 2);

                Patron.MoveByTeleport(Patron, 43 + rx2, 43 + ry2);
                Thread.Sleep(2000);


                int r = Patron.r.Next(0, 3);

                if (Patron.X >= 43 && Patron.X <= 43 + rx2 &&
                    Patron.Y >= 43 && Patron.Y <= 43 + ry2)
                {
                    switch (2)
                    {
                        case 0:
                            Patron.MoveByTeleport(Patron, 37, 39);
                            Thread.Sleep(100);
                            Patron.Walk(1, 0);
                            break;
                        case 1:
                            Patron.MoveByTeleport(Patron, 38, 40);
                            Thread.Sleep(100);
                            Patron.Walk(0, 0);
                            break;
                        case 2:
                            Patron.MoveByTeleport(Patron, 39, 39);
                            Thread.Sleep(100);
                            Patron.Walk(3, 0);
                            break;

                    }
                    _moveCount = 0;
                }

            }

            else if (_moveCount >= mlength)
            {
                if (Patron.Field.Name.Contains("14-3") == true)
                {
                    Patron.MoveByTeleport(Patron, 45, 26);
                    Patron.Walk(0, 1);
                    _moveCount = 0;
                }
                else if (Patron.Field.Name.Contains("15-4") == true)
                {
                    if (_mapFlag_2 == false)
                    {
                        Patron.MoveByTeleport(Patron, 3, 2);
                        Patron.Walk(3, 1);
                        _moveCount = 0;
                    }
                    else
                    {
                        Patron.MoveByTeleport(Patron, 37, 43);
                        Thread.Sleep(100);
                        Patron.MoveByTeleport(Patron, 37, 39);
                        Thread.Sleep(100);
                        Patron.Walk(1, 1);
                        _moveCount = 0;

                    }
                }
                else if (Patron.Field.Name.Contains("16-3") == true)
                {
                    Patron.MoveByTeleport(Patron, 39, 42);
                    Patron.Walk(3, 1);
                    _mapFlag_2 = true;
                    _moveCount = GetMapLength(2);
                }
                else if (Patron.Field.Name.Contains("16-4") == true)
                {
                    Patron.MoveByTeleport(Patron, 32, 1);
                    Patron.Walk(0, 1);

                    _moveCount = 0;

                    _mapFlag_1 = true;
                    _mapFlag_2 = false;
                }
            }
            else
            {
                int x = GetMapPoint(_mapCount, _moveCount)[0];
                int y = GetMapPoint(_mapCount, _moveCount)[1];
                if (this.Patron.X >= x && this.Patron.X <= x + 2 &&
                    this.Patron.Y >= y && this.Patron.Y <= y + 2)
                    _moveCount++;
            }
        }

        public int GetMapLength(int mapCount)
        {
            int mLength = 0;
            if (_form.chk밀트1.Checked == true)
            {
                if (mapCount == 0)
                    mLength = m131.Length / 2 - 1;
                else if (mapCount == 1)
                    mLength = m141.Length / 2 - 1;
                else if (mapCount == 2)
                    mLength = m151.Length / 2 - 1;
                else if (mapCount == 3)
                    mLength = m161.Length / 2 - 1;
            }
            else if (_form.chk밀트2.Checked == true)
            {
                if (mapCount == 0)
                    mLength = m132.Length / 2 - 1;
                else if (mapCount == 1)
                    mLength = m142.Length / 2 - 1;
                else if (mapCount == 2)
                    mLength = m152.Length / 2 - 1;
                else if (mapCount == 3)
                    mLength = m153.Length / 2 - 1;
                else if (mapCount == 4)
                    mLength = m162.Length / 2 - 1;
            }
            else if (_form.chk밀트3.Checked == true)
            {
                if (mapCount == 0)
                    mLength = m143.Length / 2 - 1;
                else if (mapCount == 1)
                    mLength = m154.Length / 2 - 1;
                else if (mapCount == 2)
                    mLength = m163.Length / 2 - 1;
                else if (mapCount == 3)
                    mLength = m164.Length / 2 - 1;
            }

            return mLength;
        }

        public int[] GetMapPoint(int mapCount, int moveCount)
        {
            int[] t = new int[2];

            if (_form.chk밀트1.Checked == true)
            {
                if (mapCount == 0)
                {
                    if (moveCount > m131.Length / 2 - 1) moveCount = m131.Length / 2 - 1;
                    t[0] = m131[moveCount, 0];
                    t[1] = m131[moveCount, 1];
                }
                else if (mapCount == 1)
                {
                    t[0] = m141[moveCount, 0];
                    t[1] = m141[moveCount, 1];
                }
                else if (mapCount == 2)
                {
                    t[0] = m151[moveCount, 0];
                    t[1] = m151[moveCount, 1];
                }
                else if (mapCount == 3)
                {
                    t[0] = m161[moveCount, 0];
                    t[1] = m161[moveCount, 1];
                }
            }
            else if (_form.chk밀트2.Checked == true)
            {
                if (mapCount == 0)
                {
                    t[0] = m132[moveCount, 0];
                    t[1] = m132[moveCount, 1];
                }
                else if (mapCount == 1)
                {
                    t[0] = m142[moveCount, 0];
                    t[1] = m142[moveCount, 1];
                }
                else if (mapCount == 2)
                {
                    t[0] = m152[moveCount, 0];
                    t[1] = m152[moveCount, 1];
                }
                else if (mapCount == 3)
                {
                    t[0] = m153[moveCount, 0];
                    t[1] = m153[moveCount, 1];
                }
                else if (mapCount == 4)
                {
                    t[0] = m162[moveCount, 0];
                    t[1] = m162[moveCount, 1];
                }
            }
            else if (_form.chk밀트3.Checked == true)
            {
                if (mapCount == 0)
                {
                    t[0] = m143[moveCount, 0];
                    t[1] = m143[moveCount, 1];
                }
                else if (mapCount == 1)
                {
                    t[0] = m154[moveCount, 0];
                    t[1] = m154[moveCount, 1];
                }
                else if (mapCount == 2)
                {
                    t[0] = m163[moveCount, 0];
                    t[1] = m163[moveCount, 1];
                }
                else if (mapCount == 3)
                {
                    t[0] = m164[moveCount, 0];
                    t[1] = m164[moveCount, 1];
                }
            }


            return t;
        }

        public void Revive()
        {


            if (this.Patron.Field.Name.Contains("빛의신전"))
            {
                uint guid = 0;
                foreach (var pair in Patron.Field.Mundanes)
                {
                    if (pair.Value.Name == "빛의여신")
                    {
                        guid = pair.Value.Guid;
                        break;
                    }
                }


                //d2->d3
                NexonClientPacket packet = new NexonClientPacket(this.Patron, 0x43);
                packet.WriteU1(1);
                packet.WriteU4(guid);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);
                Thread.Sleep(500);
                for (byte i = 1; i < 4; i = (byte)(i + 1))
                {
                    packet = new NexonClientPacket(this.Patron, 0x3a);
                    packet.WriteU1(1);
                    packet.WriteU4(guid);
                    packet.WriteU2(0x0109);
                    packet.WriteU2(i);
                    packet.WriteU2(0);
                    this.Patron.Server.Send(packet);
                    Thread.Sleep(100);
                }

                packet = new NexonClientPacket(this.Patron, 0x3a);
                packet.WriteU1(1);
                packet.WriteU4(guid);
                packet.WriteU2(0x0109);
                packet.WriteU2(5);
                packet.WriteU1(1);
                packet.WriteU1(1);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);
                Thread.Sleep(100);
            }
            else if (this.Patron.Field.Name.Contains("뮤레칸의방"))
            {
                uint guid = 0;
                foreach (var pair2 in Patron.Field.Mundanes)
                {
                    if (pair2.Value.Name == "뮤레칸")
                    {
                        guid = pair2.Value.Guid;
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
                    Thread.Sleep(500);
                    for (byte i = 1; i < 6; i = (byte)(i + 1))
                    {
                        packet = new NexonClientPacket(this.Patron, 0x3a);
                        packet.WriteU1(1);
                        packet.WriteU4(guid);
                        packet.WriteU2(0);
                        packet.WriteU2(2);
                        packet.WriteU2(0);
                        this.Patron.Server.Send(packet);
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(300);
                }
            }

            if (Patron.TryGetStockS("9[TEST]테슬러의깃털(1일)") == false)
            {
                Thread.Sleep(3000);

                if (Patron.TryGetStockS("시장리콜") == true && 
                    (Patron.Field.Name.StartsWith("시장은행") == false &&
                    Patron.Field.Name.StartsWith("시장2") == false))
                {
                    Patron.UseStockS("시장리콜");
                }

                if (Patron.Field.Name.StartsWith("시장2"))
                {
                    uint guid = 0;

                    foreach (var pair2 in Patron.Field.Mundanes)
                    {
                        if (pair2.Value.Name == "백원만")
                        {
                            guid = pair2.Value.Guid;
                            break;
                        }


                    }
                    Patron.SpeakSkill("이동");
                    Thread.Sleep(500);

                    NexonClientPacket packet = new NexonClientPacket(this.Patron, 0x3a);
                    packet.WriteU1(1);
                    packet.WriteU4(guid);
                    packet.WriteU1(0);
                    packet.WriteU1(0);
                    packet.WriteU1(0);
                    packet.WriteU1(2);
                    packet.WriteU1(1);
                    packet.WriteU1(3);
                    packet.WriteU1(0);
                    this.Patron.Server.Send(packet);
                    Thread.Sleep(500);


                    NexonClientPacket packet1 = new NexonClientPacket(this.Patron, 0x3a);
                    packet1.WriteU1(1);
                    packet1.WriteU4(guid);
                    packet1.WriteU1(0);
                    packet1.WriteU1(0);
                    packet1.WriteU1(0);
                    packet1.WriteU1(2);
                    packet1.WriteU1(0);
                    this.Patron.Server.Send(packet1);
                    Thread.Sleep(500);
                }
                else if (Patron.Field.Name.StartsWith("시장은행"))
                {
                    if (this.Patron.TryGetStockS("9[TEST]테슬러의깃털(1일)") == false)
                    {
                        this.Patron.SpeakSkill("주세요");

                        Thread.Sleep(500);

                        NexonClientPacket packet = new NexonClientPacket(this.Patron, 0x3a);
                        packet.WriteU1(1);
                        packet.WriteU4(Patron.EXPNpc);
                        packet.WriteU1(0);
                        packet.WriteU1(0);
                        packet.WriteU1(0);
                        packet.WriteU1(2);
                        packet.WriteU1(1);
                        packet.WriteU1(2);
                        packet.WriteU1(0);
                        this.Patron.Server.Send(packet);

                        this.Patron.PanelClose();
                        
                        Thread.Sleep(500);
                    }


                }
            }
            if (Patron.TryGetStockS("9[TEST]테슬러의깃털(1일)") == false)
            {
                return;
            }

            if (Patron.Field.Name.Contains("지하묘지") == false &&
            Patron.Field.Name.Contains("밀레스마을") == false &&
            Patron.TryGetStockS("밀레스리콜") == true)
            {
                Patron.UseStockS("밀레스리콜");
            }
            else if (Patron.Field.Name.Contains("밀레스마을"))
            {


                if (Patron.TryGetStockS("밀레스리콜") == false)
                {
                    Patron.mTeleport.WaitOne();

                    Patron.MoveByTeleport(this.Patron, 32, 76);

                    Patron.Walk(3, 0);

                    Patron.mTeleport.ReleaseMutex();
                }
                else
                {
                    Patron.mTeleport.WaitOne();

                    Patron.MoveByTeleport(this.Patron, 50, 10);
                    Patron.Walk(1, 0);
                    Patron.Walk(1, 0);

                    Patron.mTeleport.ReleaseMutex();
                }
            }
            else if (Patron.Field.Name.Contains("밀레스잡화상점B"))
            {
                Thread.Sleep(2000);

                uint guid = 0;
                foreach (var pair2 in Patron.Field.Mundanes)
                {
                    if (pair2.Value.Name == "죠지")
                    {
                        guid = pair2.Value.Guid;
                        break;
                    }
                }

                if (Patron.TryGetStockS("밀레스리콜") == false)
                {


                    NexonClientPacket packet = new NexonClientPacket(this.Patron, 0x43);
                    packet.WriteU1(1);
                    packet.WriteU4(guid);
                    packet.WriteU1(0);
                    this.Patron.Server.Send(packet);
                    Thread.Sleep(500);

                    packet = new NexonClientPacket(this.Patron, 0x39);
                    packet.WriteU1(1);
                    packet.WriteU4(guid);
                    packet.WriteU1(0);
                    packet.WriteU1(0x40);
                    packet.WriteU1(0);
                    this.Patron.Server.Send(packet);
                    Thread.Sleep(500);

                    packet = new NexonClientPacket(this.Patron, 0x39);
                    packet.WriteU1(1);
                    packet.WriteU4(guid);
                    packet.WriteU1(0);
                    packet.WriteU1(0x4a);
                    packet.WriteU1(0x0a);
                    packet.WriteU1(0xb9);
                    packet.WriteU1(0xd0);
                    packet.WriteU1(0xb7);
                    packet.WriteU1(0xb9);
                    packet.WriteU1(0xbd);
                    packet.WriteU1(0xba);
                    packet.WriteU1(0xb8);
                    packet.WriteU1(0xae);
                    packet.WriteU1(0xc4);
                    packet.WriteU1(0xdd);
                    packet.WriteU1(0);
                    this.Patron.Server.Send(packet);

                    packet = new NexonClientPacket(this.Patron, 0x39);
                    packet.WriteU1(1);
                    packet.WriteU4(guid);
                    packet.WriteU1(0);
                    packet.WriteU1(0x4c);
                    packet.WriteU1(0x0a);
                    packet.WriteU1(0xb9);
                    packet.WriteU1(0xd0);
                    packet.WriteU1(0xb7);
                    packet.WriteU1(0xb9);
                    packet.WriteU1(0xbd);
                    packet.WriteU1(0xba);
                    packet.WriteU1(0xb8);
                    packet.WriteU1(0xae);
                    packet.WriteU1(0xc4);
                    packet.WriteU1(0xdd);
                    packet.WriteU1(0x02);
                    packet.WriteU1(0x39);
                    packet.WriteU1(0x39);
                    packet.WriteU1(0);


                    this.Patron.Server.Send(packet);


                    Patron.PanelClose();
                    Thread.Sleep(500);

                }

            }
            else if (Patron.Field.Name.Contains("지하묘지대기실"))
            {

                int rx = Patron.r.Next(0, 4);
                int ry = Patron.r.Next(0, 4);
                if (Patron.X < 5 || Patron.X > 9 || Patron.Y < 1 || Patron.Y > 5)
                {
                    Patron.mTeleport.WaitOne();
                    Patron.MoveByTeleport(this.Patron, 5 + rx, 1 + ry);
                    Patron.mTeleport.ReleaseMutex();
                }

                uint guid = 0;
                foreach (var pair2 in Patron.Field.Mundanes)
                {
                    if (pair2.Value.Name == "지하묘지도우미")
                    {
                        guid = pair2.Value.Guid;
                        break;
                    }
                }

                NexonClientPacket packet = new NexonClientPacket(this.Patron, 0x43);
                packet.WriteU1(1);
                packet.WriteU4(guid);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);

                Thread.Sleep(100);

                packet = new NexonClientPacket(this.Patron, 0x3a);
                packet.WriteU1(1);
                packet.WriteU4(guid);
                packet.WriteU1(1);
                packet.WriteU1(11);
                //packet.WriteU1(0xd5);
                packet.WriteU1(0);
                packet.WriteU1(0x0c);
                packet.WriteU1(1);
                packet.WriteU1(1);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);

                Thread.Sleep(100);

                packet = new NexonClientPacket(this.Patron, 0x3a);
                packet.WriteU1(1);
                packet.WriteU4(guid);
                packet.WriteU1(1);
                packet.WriteU1(11);
                packet.WriteU1(0);
                packet.WriteU1(0x15);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);

                Thread.Sleep(100);
                packet = new NexonClientPacket(this.Patron, 0x3a);
                packet.WriteU1(1);
                packet.WriteU4(guid);
                packet.WriteU1(1);
                packet.WriteU1(11);
                packet.WriteU1(0);
                packet.WriteU1(0x1b);
                packet.WriteU1(1);
                packet.WriteU1(4);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);

                Thread.Sleep(100);

                packet = new NexonClientPacket(this.Patron, 0x3a);
                packet.WriteU1(1);
                packet.WriteU4(guid);
                packet.WriteU1(1);
                packet.WriteU1(11);
                packet.WriteU1(0);
                packet.WriteU1(0x2c);
                packet.WriteU1(0);
                this.Patron.Server.Send(packet);


                Thread.Sleep(100);
            }

            if (Patron.Form != null && (Patron.Form.chk밀트2.Checked == true || Patron.Form.chk밀트3.Checked) && Patron.Field.Name.Contains("13-1"))
            {
                Patron.mTeleport.WaitOne();

                Patron.MoveByTeleport(this.Patron, 23, 27);
                Patron.Walk(0, 0);

                Patron.mTeleport.ReleaseMutex();
            }
            else if (Patron.Form != null && (Patron.Form.chk밀트2.Checked == true || Patron.Form.chk밀트3.Checked) && Patron.Field.Name.Contains("12-1"))
            {
                Patron.mTeleport.WaitOne();

                Patron.MoveByTeleport(this.Patron, 17, 2);
                Patron.Walk(2, 0);

                Patron.mTeleport.ReleaseMutex();
            }
            else if (Patron.Form != null && Patron.Form.chk밀트3.Checked == true && Patron.Field.Name.Contains("13-2"))
            {
                Patron.mTeleport.WaitOne();

                Patron.MoveByTeleport(this.Patron, 22, 42);
                Patron.Walk(3, 0);

                Patron.mTeleport.ReleaseMutex();
            }
        }

        public ProxyPatron Patron { get; set; }

    }
}