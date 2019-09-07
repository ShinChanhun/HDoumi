namespace Doumi.Bot
{
    using Doumi.Net;
    using Doumi.Types;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Collections.Generic;
    

    public class Temp
    {
        private bool _flag;
        private Thread _thread;
        FormPatron form;

        int count;

        public Temp(ProxyPatron patron)
        {
            this.Patron = patron;
        }

        public void Abort()
        {
            this._flag = false;
            this._thread = null;
        }

        string[] Books1 = {"내려치기", "사방치기", "퓨리소윌루", "대쉬" };
        string[] Books2 = { "마구찌르기", "슬래쉬", "저격", "백슬래쉬", "백스텝", "습격진" };
        string[] Books3 = { "메디테이션", "라세소환", "윌리아소환","일리안소환", "화이라소환"};
        string[] Books4 = {"사일런스", "카운터", "홀리쿠라네라", "리젠"};
        string[] Books5 = {"깃털날리기", "마구때리기", "양손공격", "지열참", "꼬리치기", "할퀴기", "쪼기", "매의위상", "윈드쉐이커" };
        
        private void Auto()
        {
            form = Patron.Form;

            while ((this.Patron != null))
            {
                Thread.Sleep(1000);
                STR();
                DEX();
                INT();
                WIS();
                CON();
            }
        }

        void STR()
        {
            if (form.chkSTR.Checked == true)
            {
                int length = Books1.Length;
                int ranNum = Patron.r.Next(0, length);
                string text;

                if (form.chkPoint.Checked == true)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        text = Books1[ranNum] + "(Lev" + i + ")기술서 맡아줘";
                        this.Patron.Chant(text);
                    }
                }
                else
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        text = Books1[ranNum] + "(Lev" + i + ")기술서 돌려줘";
                        this.Patron.Chant(text);
                    }
                }
            }
        }

        void DEX()
        {
            if (form.chkDEX.Checked == true)
            {
                int length = Books2.Length;
                int ranNum = Patron.r.Next(0, length);
                string text;

                if (form.chkPoint.Checked == true)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        if(ranNum != 3)
                            text = Books2[ranNum] + "(Lev" + i + ")기술서 맡아줘";
                        else
                            text = Books2[ranNum] + i + "기술서 맡아줘";

                        this.Patron.Chant(text);
                    }



                }
                else
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        text = Books2[ranNum] + "(Lev" + i + ")기술서 돌려줘";
                        this.Patron.Chant(text);

                    }


                }
            }
        }

        void INT()
        {
            if (form.chkINT.Checked == true)
            {
                int length = Books3.Length;
                int ranNum = Patron.r.Next(0, length);
                string text;

                if (form.chkPoint.Checked == true)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        Thread.Sleep(100);
                        if (ranNum == 0)
                        {
                            text = Books3[ranNum] + "(Lev" + i + ")마법서 맡아줘";

                        }
                        else
                        {
                            text = Books3[ranNum] + i + "마법서 맡아줘";
                        }
                        this.Patron.Chant(text);
                    }

                        Thread.Sleep(100);
                    this.Patron.Chant("그룹속성강화마법서 맡아줘");
                        Thread.Sleep(100);
                    this.Patron.Chant("나르콜룸마법서 맡아줘");

                }
                else
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        Thread.Sleep(100);
                        if (ranNum == 0)
                        {
                            text = Books3[ranNum] + "(Lev" + i + ")마법서 돌려줘";

                        }
                        else
                        {
                            text = Books3[ranNum] + i + "마법서 돌려줘";
                        }
                        this.Patron.Chant(text);

                    }

                        Thread.Sleep(100);
                    this.Patron.Chant("그룹속성강화마법서 돌려줘");
                        Thread.Sleep(100);
                    this.Patron.Chant("나르콜룸마법서 돌려줘");
                }
            }
        }

        void WIS()
        {
            if (form.chkWIS.Checked == true)
            {
                int length = Books4.Length;
                int ranNum = Patron.r.Next(0, length);
                string text;

                if (form.chkPoint.Checked == true)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        if (ranNum != 3)
                            text = Books4[ranNum] + "(Lev" + i + ")마법서 맡아줘";
                        else
                            text = Books4[ranNum] + i + "마법서 맡아줘";

                        this.Patron.Chant(text);

                    }
                }
                else
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        if (ranNum != 3)
                            text = Books4[ranNum] + "(Lev" + i + ")마법서 돌려줘";
                        else
                            text = Books4[ranNum] + i + "마법서 돌려줘";

                        this.Patron.Chant(text);
                    }
                }
            }
        }

        void CON()
        {
            if (form.chkCON.Checked == true)
            {
                int length = Books5.Length;
                int ranNum = Patron.r.Next(0, length);
                string text;

                if (form.chkPoint.Checked == true)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        text = Books5[ranNum] + "(Lev" + i + ")기술서 맡아줘";
                        this.Patron.Chant(text);
                    }
                }
                else
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        text = Books5[ranNum] + "(Lev" + i + ")기술서 돌려줘";
                        this.Patron.Chant(text);
                    }
                }
            }
        }

        public void Start()
        {
            count = 0;
            this._flag = true;
            this._thread = new Thread(new ThreadStart(this.Auto));
            this._thread.Start();
        }

        public ProxyPatron Patron { get; set; }
    }
}

