namespace Doumi
{
    using Doumi.Bot;
    using Doumi.Modules;
    using Doumi.Net;
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    using System.Xml;

    public class FormPatron : Form
    {
        public ChatModule chatModule;
        public NetworkExplorerModule networkExplorerModule;
        public AreaModule areaModule;
        public MacroModule macroModule;
        private MapMove _mapMove;
        private Curse _curse;
        public Hunt_Warrior _hunt_Warrior;
        public Hunt_Rogue _hunt_Rogue;
        public Hunt_Bard _hunt_Bard;
        public Hunt_Wizard _hunt_Wizard;
        public Hunt_Monk _hunt_Monk;
        private Alert _alert;
        private Loot _loot;
        private Protect _protect;
        private Divorce _divorce;
        private Fix _fix;
        private Despell _despell;
        private Collection _collection;
        private SuspiciousMushroom _suspiciousMushroom;
        private AutoGroup _autoGroup;
        private BuffControl _buffControl;
        private War _war;
        private AutoExpSell _autoExpSell;
        public MilessTresure _milessTresure;
        public bool _chatMoudleFlag;
        public bool _networkExplorerModuleFlag;
        public bool _areaMoudleFlag;
        public bool _macroMoudleFlag;
        private bool _formPatronFlag;
        private List<string> _trashList;
        private List<string> _enemyList;
        private List<string> _desiredItemList;
        private bool _EnemyCurse;
        private bool _EnemyNar;
        private bool _EnemyLibe;
        public int _HealHP;
        public int _GroupHealHP;
        private Random r;
        public int _moveX;
        public int _moveY;
        public bool _moveFlag;
        public int _moveSleep;
        public byte Transform;
        public bool TransformFlag;
        public bool SpeedFlag;
        public ushort Speed;
        public int _Speed;
        private Thread dowalk;

        public DateTime dateTime_0;
        public DateTime dateTime_1;
        public int int_6;
        public int int_7;

        //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        //private ProxyPatron <Patron>k__BackingField;
        private IContainer components = null;
        private ColumnHeader clmGroupArea;
        private ColumnHeader clmGroupName;
        private GroupBox groupBox1;
        private Label lbTarget;
        public CheckBox chk세토아가호;
        public CheckBox chk이아가호;
        public CheckBox chk모션제거;
        public CheckBox chk센서스핵;
        public CheckBox chk유저회피;
        private GroupBox groupBox4;
        public CheckBox chk그룹원위치추적;
        public CheckBox chk노룹따라가기;
        private TabPage tabPage1;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage2;
        private GroupBox groupBox3;
        public CheckBox chk디스펠;
        public CheckBox chk그룹힐;
        public CheckBox chkShot;
        public CheckBox chk코마;
        public CheckBox chk자동저주풀기;
        private TabPage tabPage6;
        private GroupBox groupBox2;
        public CheckBox chk디각;
        public CheckBox chk디데;
        public CheckBox chk라이트닝무브;
        public CheckBox chk자동보호;
        public CheckBox chk디프;
        public CheckBox chk포트;
        public CheckBox chk디바;
        public CheckBox chk디렌;
        public CheckBox chk하이드;
        public CheckBox chk쿠랄툼;
        public CheckBox chk디베;
        public CheckBox chk델리;
        public CheckBox chk일루;
        public CheckBox chk집중;
        public CheckBox chk디나;
        public CheckBox chk호르;
        public CheckBox chk디소;
        public CheckBox chk콜라;
        public CheckBox chk이모탈;
        public CheckBox chk리플;
        public CheckBox chk힐;
        public CheckBox chk자동루팅;
        public CheckBox chkTalk1;
        public CheckBox chk유저감지;
        public CheckBox chkStopHunt;
        public CheckBox chkBeep;
        public CheckBox chkAlert;
        public CheckBox chk은신감지;
        public TextBox tbTarget;
        public TextBox tbTalk1;
        public TrackBar tbHeal;
        public TabControl tabControl1;
        public TrackBar tbGroupHeal;
        public CheckBox chk연막무시;
        public CheckBox chk자동사냥;
        private GroupBox groupBox8;
        private CheckBox checkBox11;
        private CheckBox checkBox17;
        private CheckBox checkBox16;
        private CheckBox checkBox14;
        private GroupBox groupBox7;
        private GroupBox groupBox5;
        private CheckBox checkBox18;
        public CheckBox chk어설픈수리;
        private TabPage tabPage8;
        public CheckBox chk자동바르도;
        public CheckBox chk자동데프;
        public CheckBox chk프라;
        public CheckBox chk자동소루;
        public CheckBox chk나르;
        public CheckBox chk리베;
        private GroupBox groupBox10;
        private Label label2;
        public TrackBar trackBar4;
        public CheckBox chk무딜;
        private GroupBox groupBox9;
        public CheckBox chk저주;
        public CheckBox chk움;
        public CheckBox chkDeNarcoli;
        public CheckBox chkSA;
        public CheckBox chkTargetAll;
        public CheckBox chkTagetGroup;
        public CheckBox chkTagetGuild;
        public CheckBox chkDeSoruma;
        public CheckBox chkDeDefleca;
        public CheckBox chkDeBardo;
        public CheckBox chkHolyCure;
        public CheckBox chkDeRento;
        public CheckBox chkDePrava;
        public CheckBox chkDeVenomo;
        public CheckBox chkIllumena;
        public CheckBox chk자신;
        public CheckBox chk따라가기;
        public CheckBox chk변신;
        public CheckBox chk채집;
        public CheckBox chk자동베노미;
        public CheckBox chk버프;
        public CheckBox chkKolama;
        public CheckBox chkHorrma;
        public TextBox tbWarTarget;
        public CheckBox chk쟁;
        public CheckBox chk무길나르;
        public CheckBox chk무길데프;
        public CheckBox chkTarget데프;
        public CheckBox chkTarget나르;
        public CheckBox chkTarget리베;
        public CheckBox chk무길리베;
        public CheckBox chk적길데프;
        public CheckBox chk적길나르;
        public CheckBox chk적길리베;
        public CheckBox chk그룹전체힐;
        public CheckBox chk자동렌토;
        public CheckBox chk경팔체력;
        public CheckBox chk걸리적;
        public CheckBox chk자동부활;
        public CheckBox chk동전깔기;
        public CheckBox chk원격수리;
        public CheckBox chk시스템창;
        public CheckBox chk수벗;
        public CheckBox chk자그;
        public CheckBox chkSeo;
        public CheckBox chk기공콘푸;
        private GroupBox groupBox13;
        private GroupBox groupBox11;
        private TabPage tabPage3;
        public CheckBox chkDEX;
        public CheckBox chkWIS;
        public CheckBox chkINT;
        public CheckBox chkCON;
        public CheckBox chkSTR;
        public CheckBox chkPoint;
        public CheckBox chk밀신경팔체;
        public CheckBox chk밀신경팔마;
        public CheckBox chk경팔마력;
        private TabPage tabPage7;
        public CheckBox chk맵이동;
        public CheckBox check갬유;
        public CheckBox check블랙;
        public CheckBox check레드;
        public CheckBox check블루;
        private Label field층;
        public TextBox tb층;
        public CheckBox check브론;
        public string[] groupList;
        public CheckBox chk밀트1;
        public CheckBox chk밀트4;
        public CheckBox chk밀트3;
        public CheckBox chk밀트2;
        /*
            16701 3두
            16586 뉴트
            16590 2두
            16699 1두
         */
        int[] monsterArr = { 16699, 16586, 16590, 16701, /*베레스16593,*/ 16700, 16702 };

        public int FirstMonster(ushort icon)
        {
            int count = 0;
            if (Patron.Field.Name.Contains("오피온의굴29"))
            {
                foreach (ushort arrIcon in monsterArr)
                {
                    if (arrIcon == icon)
                        return count;

                    count++;
                }
                count = 100;
                return count;
            }
            else
            {
                count = 100;

                return count;
            }
        }

        public bool CheckMonster(ushort icon)
        {
            if (Patron.Field.Name.Contains("오피온의굴29"))
            {
                foreach (ushort arrIcon in monsterArr)
                {
                    if (arrIcon == icon)
                        return true;
                }

                return false;
            }
            else
                return true;
        }

        public FormPatron(ProxyPatron patron)
        {
            this.Patron = patron;
            if (this._despell != null)
            {
                this._despell.Abort();
                this._despell = null;
            }
            if (this._curse != null)
            {
                this._curse.Abort();
                this._curse = null;
            }
            if (this._loot != null)
            {
                this._loot.Abort();
                this._loot = null;
            }
            //if (this._hunt_Warrior != null)
            //{
            //    this._hunt_Warrior.Abort();
            //    this._hunt_Warrior = null;
            //}
            //if (this._hunt_Rogue != null)
            //{
            //    this._hunt_Rogue.Abort();
            //    this._hunt_Rogue = null;
            //}
            //if (this._hunt_Monk != null)
            //{
            //    this._hunt_Monk.Abort();
            //    this._hunt_Monk = null;
            //}
            if (this._protect != null)
            {
                this._protect.Abort();
                this._protect = null;
            }
            if (this._buffControl != null)
            {
                this._buffControl.Abort();
                this._buffControl = null;
            }
            //if (this._mapMove != null)
            //{
            //    this._mapMove.Abort();
            //    this._mapMove = null;
            //}
            this.InitializeComponent();


            this.dowalk = new Thread(new ThreadStart(this.ThreadDoWalk));
            this.dowalk.Start();
            this._chatMoudleFlag = false;
            this._networkExplorerModuleFlag = false;
            this._areaMoudleFlag = false;
            this._macroMoudleFlag = false;
            this._formPatronFlag = false;
            this._HealHP = this.tbHeal.Value;
            this._GroupHealHP = this.tbGroupHeal.Value;
            this.SpeedFlag = false;
            this.Speed = 100;
            List<string> list1 = new List<string> {
                "대지에",
                "바다에",
                "바람에",
                "화염에",
                "포장된",
                "슬롯",
                "블루피치",
                "파프리카",
                "루딘블레이드",
                "향상된",
                "리젠트",
                "강화된",
                "스부",
                "금전",
                "동전",
                "은전"
            };
            this._desiredItemList = list1;
            List<string> list2 = new List<string>();
            this._trashList = list2;
            this._enemyList = new List<string>();
            this.Patron.OnCommandReceived += new Action<string>(this.CommandProcessor);
            this.r = new Random((int)DateTime.Now.Ticks);
            this.Patron.CasterEffectReceived += new Action<uint, ushort>(this.Patron_CasterEffectReceived);
            this.Patron.TargetEffectReceived += new Action<uint, ushort>(this.Patron_TargetEffectReceived);
            this.Patron.ServerMessageReceived += new Action<string>(this.Patron_ServerMessageReceived);
            this.Patron.GroupMemberReceived += new Action<string, string, ushort, ushort>(this.Patron_GroupMemberReceived);
            this.Text = string.Format(this.Text, this.Patron.Name);
            this.Patron.SendMessage(3, "{=g모든 설정이 {=b초기화 {=g됩니다.");
            this.chkTagetGroup.Checked = true;
            this.chkTargetAll.Checked = false;

            //XmlDocument xmldoc = new XmlDocument();
            //xmldoc.Load("1.xml");
            //XmlElement root = xmldoc.DocumentElement;
            //XmlNodeList nodes = root.ChildNodes;

            //foreach (XmlNode node in nodes)
            //{
            //    switch (node.Name)
            //    {
            //        case "field":
            //            string name = node.InnerText;

            //            if(name == "brons")
            //            {
            //                check브론.Checked = true;
            //            }

            //            break;
            //        case "floor":
            //            tb층.Text = node.InnerText;
            //            break;
            //    }
            //}

            this.chk세토아가호.Checked = false;
            this.chk이아가호.Checked = true;
            //this.chk걸리적.Checked = true;
            //this.check레드.Checked = true;

            //this.chk맵이동.Checked = true;
            //if(this._mapMove == null)
            //{
            //    this._mapMove = new MapMove(this.Patron);
            //    this._mapMove.Start();
            //}
            //Program.Form.ThreadSafeInvoke(() => this.chk맵이동.Checked = true);

            //if (_loot == null)
            //{
            //    _loot = new Loot(this.Patron);
            //    _loot.Start();
            //}

            //if(_protect == null)
            //{
            //    _protect = new Protect(this.Patron);
            //    _protect.Start();
            //}

            //if(_buffControl == null)
            //{
            //    _buffControl = new BuffControl(this.Patron);
            //    _buffControl.Start();
            //}

            //Program.Form.ThreadSafeInvoke(() => this.chk자동루팅.Checked = true);
            //Program.Form.ThreadSafeInvoke(() => this.chk버프.Checked = true);
            //Program.Form.ThreadSafeInvoke(() => this.chk자동보호.Checked = true);

            int num = this.Patron.WhatisMyClass();

            this.tbTarget.Text = "huntw";
            var a = this.Patron.Name;
            switch (a)
            {
                case "huntw":
                    break;
                case "huntr":
                    break;
                case "스낵":
                    if (_despell == null)
                    {
                        _despell = new Despell(this.Patron);
                        _despell.Start();
                    }

                    Program.Form.ThreadSafeInvoke(() => this.chk디스펠.Checked = true);

                    this.chk그룹힐.Checked = false;
                    break;
                case "huntb"://직자
                    this.chkKolama.Checked = true;
                    this.chkHorrma.Checked = true;
                    this.chk코마.Checked = true;

                    if (_despell == null)
                    {
                        _despell = new Despell(this.Patron);
                        _despell.Start();
                    }

                    Program.Form.ThreadSafeInvoke(() => this.chk디스펠.Checked = true);
                    break;
                case "hunts"://법사
                    this.chk델리.Checked = true;
                    this.chkSA.Checked = true;

                    if (_curse == null)
                    {
                        _curse = new Curse(this.Patron);
                        _curse.Start();
                    }

                    Program.Form.ThreadSafeInvoke(() => this.chk저주.Checked = true);
                    Program.Form.ThreadSafeInvoke(() => this.chk자동데프.Checked = true);
                    Program.Form.ThreadSafeInvoke(() => this.chk나르.Checked = true);
                    break;
                case "humtm":
                    this.chk디베.Checked = false;
                    this.chk일루.Checked = false;
                    this.chk쿠랄툼.Checked = false;
                    this.chk라이트닝무브.Checked = false;
                    this.chk콜라.Checked = false;
                    this.chk리플.Checked = false;
                    break;
            }

            string path = "DesiredItemList.txt";

            string[] textValue = System.IO.File.ReadAllLines(path, System.Text.Encoding.Default);

            if (textValue.Length > 0)
            {
                for (int i = 0; i < textValue.Length; i++)
                {
                    list2.Add(textValue[i]);
                }
            }

            string path2 = "Group.txt";

            groupList = System.IO.File.ReadAllLines(path2, System.Text.Encoding.Default);

        }

        public void Mil()
        {
            int num = this.Patron.WhatisMyClass();

            this.tbTarget.Text = "huntw";
            var a = this.Patron.Name;
            switch (a)
            {
                case "huntw":
                    break;
                case "huntr":
                    break;
                case "huntb"://직자
                    this.chkKolama.Checked = true;
                    this.chkHorrma.Checked = true;

                    if (_despell == null)
                    {
                        _despell = new Despell(this.Patron);
                        _despell.Start();
                    }

                    Program.Form.ThreadSafeInvoke(() => this.chk디스펠.Checked = true);
                    break;
                case "hunts"://법사
                    this.chk델리.Checked = true;
                    this.chkSA.Checked = true;

                    if (_curse == null)
                    {
                        _curse = new Curse(this.Patron);
                        _curse.Start();
                    }

                    Program.Form.ThreadSafeInvoke(() => this.chk저주.Checked = true);
                    Program.Form.ThreadSafeInvoke(() => this.chk자동데프.Checked = true);
                    Program.Form.ThreadSafeInvoke(() => this.chk나르.Checked = true);
                    break;
                case "humtm":
                    this.chk디베.Checked = false;
                    this.chk일루.Checked = false;
                    this.chk쿠랄툼.Checked = false;
                    this.chk라이트닝무브.Checked = false;
                    this.chk콜라.Checked = false;
                    this.chk리플.Checked = false;
                    break;
                case "튼밀하나":
                    if (this._milessTresure == null)
                    {
                        this._milessTresure = new MilessTresure(this.Patron);
                        this._milessTresure.Start();
                    }
                    this.chk밀트1.Checked = true;
                    break;
                case "튼밀둘":
                    if (this._milessTresure == null)
                    {
                        this._milessTresure = new MilessTresure(this.Patron);
                        this._milessTresure.Start();
                    }
                    this.chk밀트2.Checked = true;
                    break;
                case "튼밀셋":
                    if (this._milessTresure == null)
                    {
                        this._milessTresure = new MilessTresure(this.Patron);
                        this._milessTresure.Start();
                    }
                    this.chk밀트3.Checked = true;
                    break;
                case "튼밀넷":
                    if (this._milessTresure == null)
                    {
                        this._milessTresure = new MilessTresure(this.Patron);
                        this._milessTresure.Start();
                    }
                    this.chk밀트3.Checked = true;
                    break;
            }

        }

        private void AddDespellList()
        {
            this.tbHeal.Value = 70;
            this.chkTargetAll.Checked = true;
            this.chkTargetAll.Checked = false;
            this.Patron.deSpellList.DeRento = this.chkDeRento.Checked;
            this.Patron.deSpellList.DeBardo = this.chkDeBardo.Checked;
            this.Patron.deSpellList.DeDefleca = this.chkDeDefleca.Checked;
            this.Patron.deSpellList.DePrava = this.chkDePrava.Checked;
            this.Patron.deSpellList.HolyCure = this.chkHolyCure.Checked;
            this.Patron.deSpellList.DeNarcoli = this.chkDeNarcoli.Checked;
            this.Patron.deSpellList.DeSoruma = this.chkDeSoruma.Checked;
            this.Patron.deSpellList.DeVenomo = this.chkDeVenomo.Checked;
            this.Patron.deSpellList.Illumena = this.chkIllumena.Checked;
        }

        private bool AttachSpell(CheckBox checkBox, string name)
        {
            Spell spell;
            if (!this.Patron.TryGetSpell(name, out spell))
            {
                Program.Form.ThreadSafeInvoke(delegate
                {
                    checkBox.Checked = false;
                    checkBox.Enabled = false;
                });
                return false;
            }
            if (this.InactiveSpell(checkBox))
            {
                Program.Form.ThreadSafeInvoke(delegate
                {
                    checkBox.Enabled = true;
                });
                return true;
            }
            Program.Form.ThreadSafeInvoke(delegate
            {
                checkBox.Checked = true;
                checkBox.Enabled = true;
            });
            return true;
        }


        private void chkAlert_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chkAlert.Checked)
            {
                this._alert = new Alert(this.Patron);
                this._alert.Start();
            }
            if ((this.Patron.Form != null) && !this.chkAlert.Checked)
            {
                this._alert.Abort();
                this._alert = null;
            }
        }

        private void chkDeBardo_CheckedChanged(object sender, EventArgs e)
        {
            this.Patron.deSpellList.DeBardo = this.chkDeBardo.Checked;
        }

        private void chkDeDefleca_CheckedChanged(object sender, EventArgs e)
        {
            this.Patron.deSpellList.DeDefleca = this.chkDeDefleca.Checked;
        }

        private void chkDeNarcoli_CheckedChanged(object sender, EventArgs e)
        {
            this.Patron.deSpellList.DeNarcoli = this.chkDeNarcoli.Checked;
        }

        private void chkDePrava_CheckedChanged(object sender, EventArgs e)
        {
            this.Patron.deSpellList.DePrava = this.chkDePrava.Checked;
        }

        private void chkDeRento_CheckedChanged(object sender, EventArgs e)
        {
            this.Patron.deSpellList.DeRento = this.chkDeRento.Checked;
        }

        private void chkDeSoruma_CheckedChanged(object sender, EventArgs e)
        {
            this.Patron.deSpellList.DeSoruma = this.chkDeSoruma.Checked;
        }

        private void chkDeVenomo_CheckedChanged(object sender, EventArgs e)
        {
            this.Patron.deSpellList.DeVenomo = this.chkDeVenomo.Checked;
        }

        private void chkHolyCure_CheckedChanged(object sender, EventArgs e)
        {
            this.Patron.deSpellList.HolyCure = this.chkHolyCure.Checked;
        }

        private void chkIllumena_CheckedChanged(object sender, EventArgs e)
        {
            this.Patron.deSpellList.Illumena = this.chkIllumena.Checked;
        }

        private void chk그룹원위치추적_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk그룹원위치추적.Checked)
            {
                this.Patron.GroupMemberPosUpdate_On();
            }
            else
            {
                this.Patron.GroupMemberPosUpdate_Off();
            }
        }

        private void chk디스펠_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk디스펠.Checked)
            {
                this.chk코마.Checked = true;
                this._despell = new Despell(this.Patron);
                this._despell.Start();
            }
            if ((this.Patron.Form != null) && !this.chk디스펠.Checked)
            {
                this.chk코마.Checked = false;
                this._despell.Abort();
                this._despell = null;
            }
        }

        private void chk버프_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk버프.Checked)
            {
                if (Patron.WhatisMyClass() == 2)
                {
                    this.chk호르.Checked = true;
                    this.chk콜라.Checked = true;
                }
                else if (Patron.WhatisMyClass() == 3)
                {
                    this.chkSA.Checked = true;
                }
                this._buffControl = new BuffControl(this.Patron);
                this._buffControl.Start();
            }
            if ((this.Patron.Form != null) && !this.chk버프.Checked)
            {
                if (Patron.WhatisMyClass() == 2)
                {
                    this.chk호르.Checked = false;
                    this.chk콜라.Checked = false;
                }
                else if (Patron.WhatisMyClass() == 3)
                {
                    this.chkSA.Checked = false;
                }
                this._buffControl.Abort();
                this._buffControl = null;
            }
        }

        private void chk어설픈수리_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk어설픈수리.Checked)
            {
                this._fix = new Fix(this.Patron);
                this._fix.Start();
            }
            if ((this.Patron.Form != null) && !this.chk어설픈수리.Checked)
            {
                this._fix.Abort();
                this._fix = null;
            }
        }

        private void chk자동루팅_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk자동루팅.Checked)
            {
                this._loot = new Loot(this.Patron);
                this._loot.Start();
            }
            if ((this.Patron.Form != null) && !this.chk자동루팅.Checked)
            {
                this._loot.Abort();
                this._loot = null;
            }
        }

        private void chk자동보호_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk자동보호.Checked)
            {
                this._protect = new Protect(this.Patron);
                this._protect.Start();
            }
            if ((this.Patron.Form != null) && !this.chk자동보호.Checked)
            {
                this._protect.Abort();
                this._protect = null;
            }
        }

        private void chk자동사냥_CheckedChanged(object sender, EventArgs e)
        {
            int num = this.Patron.WhatisMyClass();
            if ((this.Patron.Form != null) && this.chk자동사냥.Checked)
            {
                switch (num)
                {
                    case 0:
                        this._hunt_Warrior = new Hunt_Warrior(this.Patron);
                        this._hunt_Warrior.Start();
                        break;
                    case 1:
                        this._hunt_Rogue = new Hunt_Rogue(this.Patron);
                        this._hunt_Rogue.Start();
                        break;
                    case 2:
                        this._hunt_Bard = new Hunt_Bard(this.Patron);
                        this._hunt_Bard.Start();
                        break;

                    case 3:
                        this._hunt_Wizard = new Hunt_Wizard(this.Patron);
                        this._hunt_Wizard.Start();
                        break;
                    case 4:
                        this._hunt_Monk = new Hunt_Monk(this.Patron);
                        this._hunt_Monk.Start();
                        break;
                }
            }
            if ((this.Patron.Form != null) && !this.chk자동사냥.Checked)
            {
                switch (num)
                {
                    case 0:
                        this._hunt_Warrior.Abort();
                        this._hunt_Warrior = null;
                        break;
                    case 1:
                        this._hunt_Rogue.Abort();
                        this._hunt_Rogue = null;
                        break;
                    case 2:
                        this._hunt_Bard.Abort();
                        this._hunt_Bard = null;
                        break;
                    case 3:
                        this._hunt_Wizard.Abort();
                        this._hunt_Wizard = null;
                        break;
                    case 4:
                        this._hunt_Monk.Abort();
                        this._hunt_Monk = null;
                        break;
                }
            }
        }

        private void Auto자동이동()
        {

        }
        private void chk자동이동_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk맵이동.Checked)
            {
                this._mapMove = new MapMove(this.Patron);
                this._mapMove.Start();
            }
            if ((this.Patron.Form != null) && !this.chk맵이동.Checked)
            {
                this._mapMove.Abort();
                this._mapMove = null;
            }
        }

        private void chk밀경팔체_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk밀신경팔체.Checked)
            {
                this._autoExpSell = new AutoExpSell(this.Patron);
                this._autoExpSell.Start();
            }
            if ((this.Patron.Form != null) && !this.chk밀신경팔체.Checked)
            {
                this._autoExpSell.Abort();
                this._autoExpSell = null;
            }
        }

        private void chk밀경팔마_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk밀신경팔마.Checked)
            {
                this._autoExpSell = new AutoExpSell(this.Patron);
                this._autoExpSell.Start();
            }
            if ((this.Patron.Form != null) && !this.chk밀신경팔마.Checked)
            {
                this._autoExpSell.Abort();
                this._autoExpSell = null;
            }
        }

        private void chk쟁_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk쟁.Checked)
            {
                this._war = new War(this.Patron);
                this._war.Start();
            }
            if ((this.Patron.Form != null) && !this.chk쟁.Checked)
            {
                this._war.Abort();
                this._war = null;
            }
        }

        private void chk저주_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk저주.Checked)
            {
                Program.Form.ThreadSafeInvoke(() => this.chk나르.Checked = true);
                Program.Form.ThreadSafeInvoke(() => this.chk프라.Checked = true);


                this._curse = new Curse(this.Patron);
                this._curse.Start();
            }
            if ((this.Patron.Form != null) && !this.chk저주.Checked)
            {
                Program.Form.ThreadSafeInvoke(() => this.chk나르.Checked = false);
                Program.Form.ThreadSafeInvoke(() => this.chk프라.Checked = false);

                this._curse.Abort();
                this._curse = null;
            }
        }

        private void chk채집_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk채집.Checked)
            {
                this._collection = new Collection(this.Patron);
                this._collection.Start();
            }
            if ((this.Patron.Form != null) && !this.chk채집.Checked)
            {
                this._collection.Abort();
                this._collection = null;
            }
        }

        private void chk수벗_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk수벗.Checked)
            {
                this._suspiciousMushroom = new SuspiciousMushroom(this.Patron);
                this._suspiciousMushroom.Start();
            }
            if ((this.Patron.Form != null) && !this.chk수벗.Checked)
            {
                this._suspiciousMushroom.Abort();
                this._suspiciousMushroom = null;
            }
        }

        private void chk자그_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk자그.Checked)
            {
                this._autoGroup = new AutoGroup(this.Patron);
                this._autoGroup.Start();
            }
            if ((this.Patron.Form != null) && !this.chk자그.Checked)
            {
                this._autoGroup.Abort();
                this._autoGroup = null;
            }
        }

        private void chk밀트1_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk밀트1.Checked)
            {
                this._milessTresure = new MilessTresure(this.Patron);
                this._milessTresure.Start();
            }
            if ((this.Patron.Form != null) && !this.chk밀트1.Checked)
            {
                this._milessTresure.Abort();
                this._milessTresure = null;
            }
        }
        private void chk밀트2_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk밀트2.Checked)
            {
                this._milessTresure = new MilessTresure(this.Patron);
                this._milessTresure.Start();
            }
            if ((this.Patron.Form != null) && !this.chk밀트2.Checked)
            {
                this._milessTresure.Abort();
                this._milessTresure = null;
            }
        }

        private void chk밀트3_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk밀트3.Checked)
            {
                this._milessTresure = new MilessTresure(this.Patron);
                this._milessTresure.Start();
            }
            if ((this.Patron.Form != null) && !this.chk밀트3.Checked)
            {
                this._milessTresure.Abort();
                this._milessTresure = null;
            }
        }

        private void chk밀트4_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.Patron.Form != null) && this.chk밀트4.Checked)
            {
                this._milessTresure = new MilessTresure(this.Patron);
                this._milessTresure.Start();
            }
            if ((this.Patron.Form != null) && !this.chk밀트4.Checked)
            {
                this._milessTresure.Abort();
                this._milessTresure = null;
            }
        }

        private void CommandProcessor(string command)
        {
            char[] separator = new char[] { ' ' };
            string[] strArray = command.Split(separator);
            string s = strArray[0];
            switch (PrivateImplementationDetails.ComputeStringHash(s))
            {
                case 2700920886:
                    if (s == "ㅈㅅ")
                    {

                        if (!this.chk자동사냥.Checked)
                        {
                            Program.Form.ThreadSafeInvoke(() => this.chk자동사냥.Checked = true);
                        }
                        else if (this.chk자동사냥.Checked)
                        {
                            Program.Form.ThreadSafeInvoke(() => this.chk자동사냥.Checked = false);
                        }
                        return;
                    }
                    break;
                case 1143227461:
                    if (s == "ㅂㅂ")
                    {

                        if (!this.chk따라가기.Checked)
                        {
                            if (!this.chk그룹원위치추적.Checked)
                            {
                                Program.Form.ThreadSafeInvoke(() => this.chk그룹원위치추적.Checked = true);
                            }
                            this.Patron.Form.tbTarget.Text = "huntw";
                            this.Patron.SendMessage(3, "{=c따라가기 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk따라가기.Checked = true);
                        }
                        else if (this.chk따라가기.Checked)
                        {
                            this.Patron.Form.tbTarget.Text = "";
                            this.Patron.SendMessage(3, "{=c따라가기 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk따라가기.Checked = false);
                        }
                        return;
                    }
                    break;
                case 1360585719:
                    if (s == "ㅁㅁ")
                    {
                        if (!this.chk맵이동.Checked)
                        {
                            this.Patron.SendMessage(3, "{=맵이동 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk맵이동.Checked = true);
                        }
                        else if (this.chk맵이동.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c맵이동 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk맵이동.Checked = false);
                        }
                        return;
                    }
                    break;
                case 0x39b038c:
                    if (s == "적")
                    {
                        if (strArray.Length == 1)
                        {
                            if (this._enemyList.Count == 0)
                            {
                                this.Patron.SendMessage(8, "지정된 적이 없습니다.");
                            }
                            else
                            {
                                this.ShowEnemy();
                            }
                        }
                        else if (strArray.Length > 1)
                        {
                            string str4 = strArray[1];
                            if (str4 != "추가")
                            {
                                if (str4 != "제거")
                                {
                                    this.Patron.SendMessage(3, "{=b잘못된 옵션 입니다.");
                                    return;
                                }
                                if (this._enemyList.Count != 0)
                                {
                                    foreach (string str5 in this._trashList)
                                    {
                                        if (str5 == strArray[2])
                                        {
                                            this._enemyList.Remove(strArray[2]);
                                            this.ShowEnemy();
                                            break;
                                        }
                                    }
                                    this.Patron.SendMessage(3, "{=b잘못된 아이디 입니다.");
                                }
                                return;
                            }
                            this._enemyList.Add(strArray[2]);
                            this.ShowEnemy();
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0x156048dd:
                    if (s == "모션")
                    {
                        if (!this.chk모션제거.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c모션제거 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk모션제거.Checked = true);
                        }
                        else if (this.chk모션제거.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c모션제거 {=g사용을 {=w중지 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk모션제거.Checked = false);
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0x3142173b:
                    if (s == "ㅅㄹ")
                    {
                        if (!this.chk자동소루.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동소루 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk자동소루.Checked = true);
                        }
                        else if (this.chk자동소루.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동소루 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk자동소루.Checked = false);
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0x3b3e17c3:
                    if (s == "매크로")
                    {
                        if (!this._macroMoudleFlag && (this.macroModule == null))
                        {
                            this.Patron.SendMessage(3, "{=c매크로 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(delegate
                            {
                                MacroModule module = new MacroModule(this.Patron);
                                this.macroModule = module;
                                this.macroModule.Show();
                            });
                            this._macroMoudleFlag = true;
                        }
                        else if (!this._macroMoudleFlag && (this.macroModule != null))
                        {
                            this.Patron.SendMessage(3, "{=c매크로 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.macroModule.Show());
                            this._macroMoudleFlag = true;
                        }
                        else if (this._macroMoudleFlag && (this.macroModule != null))
                        {
                            this.Patron.SendMessage(3, "{=c매크로 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.macroModule.Hide());
                            this._macroMoudleFlag = false;
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0x3ef0ae16:
                    if (s == "ㄷㅈㅈ")
                    {
                        if (!this.chk자동저주풀기.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동저주풀기 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk자동저주풀기.Checked = true);
                        }
                        else if (this.chk자동저주풀기.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동저주풀기 {=g사용을 {=w중지 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk자동저주풀기.Checked = false);
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0x39244bfb:
                    if (s == "ㄼ")
                    {
                        if (!this.chk리베.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동리베 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk리베.Checked = true);
                        }
                        else if (this.chk리베.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동리베 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk리베.Checked = false);
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0x3a0cb08e:
                    if (s == "?")
                    {
                        this.Patron.SendMessage(8, "- 명령어 도움말 -  ");
                        return;
                    }
                    goto Label_18FF;

                case 0x3ff349a2:
                    if (s == "채팅")
                    {
                        if (!this._chatMoudleFlag && (this.chatModule == null))
                        {
                            this.Patron.SendMessage(3, "{=c채팅 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(delegate
                            {
                                ChatModule module = new ChatModule(this.Patron);
                                this.chatModule = module;
                                this.chatModule.Show();
                            });
                            this._chatMoudleFlag = true;
                        }
                        else if (!this._chatMoudleFlag && (this.chatModule != null))
                        {
                            this.Patron.SendMessage(3, "{=c채팅 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chatModule.Show());
                            this._chatMoudleFlag = true;
                        }
                        else if (this._chatMoudleFlag && (this.chatModule != null))
                        {
                            this.Patron.SendMessage(3, "{=c채팅 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chatModule.Hide());
                            this._chatMoudleFlag = false;
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0x426475d7:
                    if (s == "ㄱㄱ")
                    {
                        if (!this.chk따라가기.Checked)
                        {
                            if (!this.chk그룹원위치추적.Checked)
                            {
                                Program.Form.ThreadSafeInvoke(() => this.chk그룹원위치추적.Checked = true);
                            }
                            this.Patron.SendMessage(3, "{=따라가기 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk따라가기.Checked = true);
                        }
                        else if (this.chk따라가기.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c따라가기 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk따라가기.Checked = false);
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0x46fb2240:
                    if (s == "적리베")
                    {
                        if (!this._EnemyLibe)
                        {
                            this.Patron.SendMessage(3, "{=c적리베 {=g사용을 {=q시작 {=g합니다.");
                            this._EnemyLibe = true;
                        }
                        else if (this._EnemyLibe)
                        {
                            this.Patron.SendMessage(3, "{=c적리베 {=g사용을 {=w중지 {=g합니다.");
                            this._EnemyLibe = false;
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0x6b1df911:
                    if (s == "수리")
                    {
                        return;
                    }
                    goto Label_18FF;

                case 0x7cc98293:
                    if (s == "센서스")
                    {
                        if (!this.chk센서스핵.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c센서스핵 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk센서스핵.Checked = true);
                            this.Patron.Refresh();
                        }
                        else if (this.chk센서스핵.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c센서스핵 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk센서스핵.Checked = false);
                            this.Patron.Refresh();
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0x49c2150e:
                    if (s == "이동")
                    {
                        if (strArray.Length > 1)
                        {
                            char[] chArray2 = new char[] { ',' };
                            string[] strArray2 = strArray[1].Split(chArray2);
                            if (strArray2.Length != 2)
                            {
                                this.Patron.SendMessage(2, "{=b잘못된 좌표 설정입니다.");
                                return;
                            }
                            int x = Convert.ToInt32(strArray2[0]);
                            int y = Convert.ToInt32(strArray2[1]);
                            Field field = this.Patron.Field;
                            if (((((field != null) && !field.IsSolid(x, y)) && ((x > 0) && (y > 0))) && (x < field.Cols)) && (y < field.Rows))
                            {
                                if (this.Patron.TryGetStockS("텔리포트의깃털") || this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)"))
                                {
                                    this.Patron.mTeleport.WaitOne();
                                    this.Patron.MoveByTeleport(this.Patron, x, y);
                                    this.Patron.mTeleport.ReleaseMutex();
                                    object[] objArray1 = new object[] { "{=g좌표 {=e", x, "{=g, {=e", y, " {=g로 이동합니다." };
                                    this.Patron.SendMessage(3, string.Concat(objArray1));
                                    return;
                                }
                                this.Patron.SendMessage(2, "{=q텔리포트의깃털{=g을 찾을 수 없습니다.");
                            }
                            else
                            {
                                this.Patron.SendMessage(2, "{=b설정된 좌표로 이동할 수 없습니다.");
                            }
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0x4d57ae48:
                    if (s == "적저주")
                    {
                        if (!this._EnemyCurse)
                        {
                            this.Patron.SendMessage(3, "{=c적저주 {=g사용을 {=q시작 {=g합니다.");
                            this._EnemyCurse = true;
                        }
                        else if (this._EnemyLibe)
                        {
                            this.Patron.SendMessage(3, "{=c적저주 {=g사용을 {=w중지 {=g합니다.");
                            this._EnemyCurse = false;
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0x8ce215d2:
                    if (s == "설정")
                    {
                        if (!this._formPatronFlag)
                        {
                            this.Patron.SendMessage(3, "{=c설정 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => base.Show());
                            this._formPatronFlag = true;
                        }
                        else
                        {
                            this.Patron.SendMessage(3, "{=c설정 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => base.Hide());
                            this._formPatronFlag = false;
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0x976d8f98:
                    if (s == "적나르")
                    {
                        if (!this._EnemyNar)
                        {
                            this.Patron.SendMessage(3, "{=c적나르 {=g사용을 {=q시작 {=g합니다.");
                            this._EnemyNar = true;
                        }
                        else if (this._EnemyNar)
                        {
                            this.Patron.SendMessage(3, "{=c적나르 {=g사용을 {=w중지 {=g합니다.");
                            this._EnemyNar = false;
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0x9c5bd505:
                    if (s == "변신해제")
                    {
                        if (this.TransformFlag)
                        {
                            this.TransformFlag = false;
                            this.Patron.Refresh();
                            this.Patron.SendMessage(3, "{=c변신 {=i사용을 {=w중지 {=i합니다.");
                        }
                        else
                        {
                            this.Patron.SendMessage(3, "사용중이 아닙니다.");
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0xadfcdcad:
                    if (s == "ㅈㅈ")
                    {
                        this.UseSpell_Load();
                        if (!this.chk프라.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동저주 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk프라.Checked = true);
                        }
                        else if (this.chk프라.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동저주 {=g사용을 {=w중지 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk프라.Checked = false);
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0xb31907b2:
                    if (s == "스핵")
                    {
                        if (strArray.Length != 2)
                        {
                            this.Patron.SendMessage(3, "잘못된 옵션 입니다.");
                            return;
                        }
                        string str6 = strArray[1];
                        switch (PrivateImplementationDetails.ComputeStringHash(str6))
                        {
                            case 0x320ca3f6:
                                if (str6 == "7")
                                {
                                    this.Speed = 250;
                                    this.Patron.SendMessage(3, "{=g이동속도를 {=q" + this.Speed + "{=g로 지정 되었습니다.");
                                    return;
                                }
                                break;

                            case 0x330ca589:
                                if (str6 == "6")
                                {
                                    this.Speed = 220;
                                    this.Patron.SendMessage(3, "{=g이동속도를 {=q" + this.Speed + "{=g로 지정 되었습니다.");
                                    return;
                                }
                                break;

                            case 0x300ca0d0:
                                if (str6 == "5")
                                {
                                    this.Speed = 200;
                                    this.Patron.SendMessage(3, "{=g이동속도를 {=q" + this.Speed + "{=g로 지정 되었습니다.");
                                    return;
                                }
                                break;

                            case 0x310ca263:
                                if (str6 == "4")
                                {
                                    this.Speed = 180;
                                    this.Patron.SendMessage(3, "{=g이동속도를 {=q" + this.Speed + "{=g로 지정 되었습니다.");
                                    return;
                                }
                                break;

                            case 0x340ca71c:
                                if (str6 == "1")
                                {
                                    this.Speed = 120;
                                    this.Patron.SendMessage(3, "{=g이동속도를 {=q" + this.Speed + "{=g로 지정 되었습니다.");
                                    return;
                                }
                                break;

                            case 0x360caa42:
                                if (str6 == "3")
                                {
                                    this.Speed = 160;
                                    this.Patron.SendMessage(3, "{=g이동속도를 {=q" + this.Speed + "{=g로 지정 되었습니다.");
                                    return;
                                }
                                break;

                            case 0x370cabd5:
                                if (str6 == "2")
                                {
                                    this.Speed = 140;
                                    this.Patron.SendMessage(3, "{=g이동속도를 {=q" + this.Speed + "{=g로 지정 되었습니다.");
                                    return;
                                }
                                break;

                            case 0x60592c31:
                                if (str6 == "켜기")
                                {
                                    if (!this.SpeedFlag)
                                    {
                                        this.Patron.SendMessage(3, "{=c스핵 {=g사용을 {=q시작 {=g합니다.");
                                        this.SpeedFlag = true;
                                    }
                                    else
                                    {
                                        this.Patron.SendMessage(3, "이미 사용 중입니다.");
                                    }
                                    return;
                                }
                                break;

                            case 0xf2541b19:
                                if (str6 == "끄기")
                                {
                                    if (this.SpeedFlag)
                                    {
                                        this.Patron.SendMessage(3, "{=c스핵 {=g사용을 {=q중지 {=g합니다.");
                                        this.SpeedFlag = false;
                                    }
                                    else
                                    {
                                        this.Patron.SendMessage(3, "사용 중 이 아닙니다.");
                                    }
                                    return;
                                }
                                break;
                        }
                        this.Patron.SendMessage(3, "잘못된 옵션 입니다.");
                        return;
                    }
                    goto Label_18FF;

                case 0xa25efcc9:
                    if (s == "ㄷㅅ")
                    {
                        if (!this.chk디스펠.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동디스펠 {=g사용을 {=q시작 {=g합니다.");
                            this.UseSpell_Load();
                            this.AddDespellList();
                            Program.Form.ThreadSafeInvoke(() => this.chk디스펠.Checked = true);
                        }
                        else if (this.chk디스펠.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동디스펠 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk디스펠.Checked = false);
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0xa3fcccef:
                    if (s == "ㅈㅂ")
                    {
                        if (!this.chk자동보호.Checked)
                        {
                            this.UseSpell_Load();
                            this.Patron.SendMessage(3, "{=c자동보호 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk자동보호.Checked = true);
                        }
                        else if (this.chk자동보호.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동보호 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk자동보호.Checked = false);
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0xc42393cc:

                    if (s == "ㅁ")
                    {
                        if (!this._areaMoudleFlag && (this.areaModule == null))
                        {
                            this.Patron.SendMessage(3, "{=c맵 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(delegate
                            {
                                AreaModule module = new AreaModule(this.Patron);
                                this.areaModule = module;
                                this.areaModule.Show();
                            });
                            this._areaMoudleFlag = true;
                        }
                        else if (!this._areaMoudleFlag && (this.areaModule != null))
                        {
                            this.Patron.SendMessage(3, "{=c맵 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.areaModule.Show());
                            this._areaMoudleFlag = true;
                        }
                        else if (this._areaMoudleFlag && (this.areaModule != null))
                        {
                            this.Patron.SendMessage(3, "{=c맵 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.areaModule.Hide());
                            this._areaMoudleFlag = false;
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0xc82938e0:
                    if (s == "패킷")
                    {
                        if (!this._networkExplorerModuleFlag && (this.networkExplorerModule == null))
                        {
                            this.Patron.SendMessage(3, "{=c패킷보기 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(delegate
                            {
                                NetworkExplorerModule module = new NetworkExplorerModule(this.Patron);
                                this.networkExplorerModule = module;
                                this.networkExplorerModule.Show();
                            });
                            this._networkExplorerModuleFlag = true;
                        }
                        else if (!this._networkExplorerModuleFlag && (this.networkExplorerModule != null))
                        {
                            this.Patron.SendMessage(3, "{=c패킷보기 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.networkExplorerModule.Show());
                            this._networkExplorerModuleFlag = true;
                        }
                        else if (this._networkExplorerModuleFlag && (this.networkExplorerModule != null))
                        {
                            this.Patron.SendMessage(3, "{=c패킷보기 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.networkExplorerModule.Hide());
                            this._networkExplorerModuleFlag = false;
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0xb5c297ae:
                    if (s == "ㄴㄹ")
                    {
                        if (!this.chk나르.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동나르 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk나르.Checked = true);
                        }
                        else if (this.chk나르.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동나르 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk나르.Checked = false);
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0xbb1d8b2d:
                    if (s == "변신")
                    {
                        if (strArray.Length == 2)
                        {
                            if (!this.TransformFlag)
                            {
                                this.TransformFlag = true;
                            }
                            this.Transform = Convert.ToByte(strArray[1]);
                            this.Patron.Refresh();
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0xc8349737:
                    if (s == "자동줍기")
                    {
                        if (!this.chk자동저주풀기.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동줍기 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk자동저주풀기.Checked = true);
                        }
                        else if (this.chk프라.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동줍기 {=g사용을 {=w중지 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk자동저주풀기.Checked = false);
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0xe5f953d1:
                    if (s == "코마")
                    {
                        if (!this.chk코마.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동살리기 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk코마.Checked = true);
                        }
                        else if (this.chk코마.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c자동살리기 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chk코마.Checked = false);
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0xedad514a:
                    if (s == "안먹")
                    {
                        if (strArray.Length == 1)
                        {
                            if (this._trashList.Count == 0)
                            {
                                this.Patron.SendMessage(8, "지정된 아이템이 없습니다.");
                            }
                            else
                            {
                                this.ShowTrash();
                            }
                        }
                        else if (strArray.Length > 1)
                        {
                            string str2 = strArray[1];
                            if (str2 != "추가")
                            {
                                if (str2 == "제거")
                                {
                                    if (this._trashList.Count == 0)
                                    {
                                        return;
                                    }
                                    foreach (string str3 in this._trashList)
                                    {
                                        if (str3 == strArray[2])
                                        {
                                            this._trashList.Remove(strArray[2]);
                                            this.ShowTrash();
                                            break;
                                        }
                                    }
                                    break;
                                }
                                this.Patron.SendMessage(3, "{=b잘못된 옵션 입니다.");
                                return;
                            }
                            this._trashList.Add(strArray[2]);
                            this.ShowTrash();
                        }
                        return;
                    }
                    goto Label_18FF;

                case 0xfaba7565:
                    if (s == "알람")
                    {
                        if (!this.chkAlert.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c알람 {=g사용을 {=q시작 {=g합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chkAlert.Checked = true);
                        }
                        else if (this.chkAlert.Checked)
                        {
                            this.Patron.SendMessage(3, "{=c알람 {=i사용을 {=w중지 {=i합니다.");
                            Program.Form.ThreadSafeInvoke(() => this.chkAlert.Checked = false);
                        }
                        return;
                    }
                    goto Label_18FF;

                default:
                    goto Label_18FF;
            }
            this.Patron.SendMessage(3, "{=b잘못된 아이템 입니다.");
            return;
            Label_18FF:
            this.Patron.SendMessage(2, "{=b잘못 된 명령 입니다.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FormPatron_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Patron.OnCommandReceived -= new Action<string>(this.CommandProcessor);
            this.Patron.CasterEffectReceived -= new Action<uint, ushort>(this.Patron_CasterEffectReceived);
            this.Patron.TargetEffectReceived -= new Action<uint, ushort>(this.Patron_TargetEffectReceived);
            this.Patron.ServerMessageReceived -= new Action<string>(this.Patron_ServerMessageReceived);
            if (this.areaModule != null)
            {
                Program.Form.ThreadSafeInvoke(() => this.areaModule.Close());
                this.areaModule = null;
            }
            if (this.networkExplorerModule != null)
            {
                this.networkExplorerModule.Close();
                this.networkExplorerModule = null;
            }
            if (this.macroModule != null)
            {
                this.macroModule.Close();
                this.macroModule = null;
            }
            if (this.chatModule != null)
            {
                this.chatModule.Close();
                this.chatModule = null;
            }
        }

        private void FormPatron_Load(object sender, EventArgs e)
        {
            this.UseSpell_Load();
            this.AddDespellList();
        }

        private bool InactiveSpell(CheckBox spell)
        {
            string[] strArray = new string[] { "리베", "포트", "델리", "라이트닝무브", "집중", "하이드" };
            foreach (string str in strArray)
            {
                if (spell.Name.EndsWith(str))
                {
                    return true;
                }
            }
            return false;
        }

        private void InitializeComponent()
        {
            this.clmGroupArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmGroupName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbTarget = new System.Windows.Forms.Label();
            this.chk그룹원위치추적 = new System.Windows.Forms.CheckBox();
            this.chk따라가기 = new System.Windows.Forms.CheckBox();
            this.tbTarget = new System.Windows.Forms.TextBox();
            this.chk세토아가호 = new System.Windows.Forms.CheckBox();
            this.chk이아가호 = new System.Windows.Forms.CheckBox();
            this.chk모션제거 = new System.Windows.Forms.CheckBox();
            this.chk센서스핵 = new System.Windows.Forms.CheckBox();
            this.chk자동부활 = new System.Windows.Forms.CheckBox();
            this.chk유저회피 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkShot = new System.Windows.Forms.CheckBox();
            this.chk동전깔기 = new System.Windows.Forms.CheckBox();
            this.chk원격수리 = new System.Windows.Forms.CheckBox();
            this.chk시스템창 = new System.Windows.Forms.CheckBox();
            this.chk수벗 = new System.Windows.Forms.CheckBox();
            this.chk자그 = new System.Windows.Forms.CheckBox();
            this.chk걸리적 = new System.Windows.Forms.CheckBox();
            this.chk경팔마력 = new System.Windows.Forms.CheckBox();
            this.chk경팔체력 = new System.Windows.Forms.CheckBox();
            this.chk채집 = new System.Windows.Forms.CheckBox();
            this.chk어설픈수리 = new System.Windows.Forms.CheckBox();
            this.chk노룹따라가기 = new System.Windows.Forms.CheckBox();
            this.chk자동사냥 = new System.Windows.Forms.CheckBox();
            this.chk연막무시 = new System.Windows.Forms.CheckBox();
            this.chk자동루팅 = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tbWarTarget = new System.Windows.Forms.TextBox();
            this.chkTarget데프 = new System.Windows.Forms.CheckBox();
            this.chkTarget나르 = new System.Windows.Forms.CheckBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.chk쟁 = new System.Windows.Forms.CheckBox();
            this.chkTarget리베 = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.chk적길리베 = new System.Windows.Forms.CheckBox();
            this.chk무길리베 = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chk적길나르 = new System.Windows.Forms.CheckBox();
            this.chk무길나르 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chk적길데프 = new System.Windows.Forms.CheckBox();
            this.chk무길데프 = new System.Windows.Forms.CheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.chkAlert = new System.Windows.Forms.CheckBox();
            this.chkTalk1 = new System.Windows.Forms.CheckBox();
            this.tbTalk1 = new System.Windows.Forms.TextBox();
            this.chkBeep = new System.Windows.Forms.CheckBox();
            this.chkStopHunt = new System.Windows.Forms.CheckBox();
            this.chk은신감지 = new System.Windows.Forms.CheckBox();
            this.chk유저감지 = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.chk버프 = new System.Windows.Forms.CheckBox();
            this.chkKolama = new System.Windows.Forms.CheckBox();
            this.chkHorrma = new System.Windows.Forms.CheckBox();
            this.chkSA = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chk디스펠 = new System.Windows.Forms.CheckBox();
            this.chkTargetAll = new System.Windows.Forms.CheckBox();
            this.chk자신 = new System.Windows.Forms.CheckBox();
            this.chkTagetGroup = new System.Windows.Forms.CheckBox();
            this.tbGroupHeal = new System.Windows.Forms.TrackBar();
            this.chkDeNarcoli = new System.Windows.Forms.CheckBox();
            this.chkTagetGuild = new System.Windows.Forms.CheckBox();
            this.chk그룹전체힐 = new System.Windows.Forms.CheckBox();
            this.chk그룹힐 = new System.Windows.Forms.CheckBox();
            this.chkDeDefleca = new System.Windows.Forms.CheckBox();
            this.chkDeSoruma = new System.Windows.Forms.CheckBox();
            this.chk자동저주풀기 = new System.Windows.Forms.CheckBox();
            this.chk코마 = new System.Windows.Forms.CheckBox();
            this.chkIllumena = new System.Windows.Forms.CheckBox();
            this.chkDeBardo = new System.Windows.Forms.CheckBox();
            this.chkDeVenomo = new System.Windows.Forms.CheckBox();
            this.chkHolyCure = new System.Windows.Forms.CheckBox();
            this.chkDePrava = new System.Windows.Forms.CheckBox();
            this.chkDeRento = new System.Windows.Forms.CheckBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk변신 = new System.Windows.Forms.CheckBox();
            this.chk힐 = new System.Windows.Forms.CheckBox();
            this.tbHeal = new System.Windows.Forms.TrackBar();
            this.chk디각 = new System.Windows.Forms.CheckBox();
            this.chk디데 = new System.Windows.Forms.CheckBox();
            this.chk라이트닝무브 = new System.Windows.Forms.CheckBox();
            this.chk자동보호 = new System.Windows.Forms.CheckBox();
            this.chk디프 = new System.Windows.Forms.CheckBox();
            this.chk포트 = new System.Windows.Forms.CheckBox();
            this.chk디바 = new System.Windows.Forms.CheckBox();
            this.chk디렌 = new System.Windows.Forms.CheckBox();
            this.chk하이드 = new System.Windows.Forms.CheckBox();
            this.chk쿠랄툼 = new System.Windows.Forms.CheckBox();
            this.chk디베 = new System.Windows.Forms.CheckBox();
            this.chk델리 = new System.Windows.Forms.CheckBox();
            this.chk움 = new System.Windows.Forms.CheckBox();
            this.chk일루 = new System.Windows.Forms.CheckBox();
            this.chk집중 = new System.Windows.Forms.CheckBox();
            this.chk디나 = new System.Windows.Forms.CheckBox();
            this.chk호르 = new System.Windows.Forms.CheckBox();
            this.chk디소 = new System.Windows.Forms.CheckBox();
            this.chk콜라 = new System.Windows.Forms.CheckBox();
            this.chk이모탈 = new System.Windows.Forms.CheckBox();
            this.chk리플 = new System.Windows.Forms.CheckBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.chk자동렌토 = new System.Windows.Forms.CheckBox();
            this.chk무딜 = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.chk저주 = new System.Windows.Forms.CheckBox();
            this.chk프라 = new System.Windows.Forms.CheckBox();
            this.chk자동바르도 = new System.Windows.Forms.CheckBox();
            this.chk리베 = new System.Windows.Forms.CheckBox();
            this.chk자동데프 = new System.Windows.Forms.CheckBox();
            this.chk자동베노미 = new System.Windows.Forms.CheckBox();
            this.chk나르 = new System.Windows.Forms.CheckBox();
            this.chk자동소루 = new System.Windows.Forms.CheckBox();
            this.chkSeo = new System.Windows.Forms.CheckBox();
            this.chk기공콘푸 = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkDEX = new System.Windows.Forms.CheckBox();
            this.chkWIS = new System.Windows.Forms.CheckBox();
            this.chkINT = new System.Windows.Forms.CheckBox();
            this.chkCON = new System.Windows.Forms.CheckBox();
            this.chkSTR = new System.Windows.Forms.CheckBox();
            this.chkPoint = new System.Windows.Forms.CheckBox();
            this.chk밀신경팔체 = new System.Windows.Forms.CheckBox();
            this.chk밀신경팔마 = new System.Windows.Forms.CheckBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.chk밀트1 = new System.Windows.Forms.CheckBox();
            this.chk맵이동 = new System.Windows.Forms.CheckBox();
            this.check갬유 = new System.Windows.Forms.CheckBox();
            this.check블랙 = new System.Windows.Forms.CheckBox();
            this.check레드 = new System.Windows.Forms.CheckBox();
            this.check블루 = new System.Windows.Forms.CheckBox();
            this.field층 = new System.Windows.Forms.Label();
            this.tb층 = new System.Windows.Forms.TextBox();
            this.check브론 = new System.Windows.Forms.CheckBox();
            this.chk밀트2 = new System.Windows.Forms.CheckBox();
            this.chk밀트3 = new System.Windows.Forms.CheckBox();
            this.chk밀트4 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGroupHeal)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbHeal)).BeginInit();
            this.tabPage8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // clmGroupArea
            // 
            this.clmGroupArea.Text = "Area";
            this.clmGroupArea.Width = 300;
            // 
            // clmGroupName
            // 
            this.clmGroupName.Text = "Name";
            this.clmGroupName.Width = 120;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbTarget);
            this.groupBox1.Controls.Add(this.chk그룹원위치추적);
            this.groupBox1.Controls.Add(this.chk따라가기);
            this.groupBox1.Controls.Add(this.tbTarget);
            this.groupBox1.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(1, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(482, 51);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "그룹";
            // 
            // lbTarget
            // 
            this.lbTarget.AutoSize = true;
            this.lbTarget.Location = new System.Drawing.Point(293, 21);
            this.lbTarget.Name = "lbTarget";
            this.lbTarget.Size = new System.Drawing.Size(73, 14);
            this.lbTarget.TabIndex = 2;
            this.lbTarget.Text = "목표대상 :";
            // 
            // chk그룹원위치추적
            // 
            this.chk그룹원위치추적.AutoSize = true;
            this.chk그룹원위치추적.Location = new System.Drawing.Point(5, 21);
            this.chk그룹원위치추적.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk그룹원위치추적.Name = "chk그룹원위치추적";
            this.chk그룹원위치추적.Size = new System.Drawing.Size(132, 18);
            this.chk그룹원위치추적.TabIndex = 1;
            this.chk그룹원위치추적.Text = "그룹원 위치추적";
            this.chk그룹원위치추적.UseVisualStyleBackColor = true;
            this.chk그룹원위치추적.CheckedChanged += new System.EventHandler(this.chk그룹원위치추적_CheckedChanged);
            // 
            // chk따라가기
            // 
            this.chk따라가기.AutoSize = true;
            this.chk따라가기.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk따라가기.Location = new System.Drawing.Point(131, 20);
            this.chk따라가기.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk따라가기.Name = "chk따라가기";
            this.chk따라가기.Size = new System.Drawing.Size(132, 18);
            this.chk따라가기.TabIndex = 2;
            this.chk따라가기.Text = "그룹원 따라가기";
            this.chk따라가기.UseVisualStyleBackColor = true;
            // 
            // tbTarget
            // 
            this.tbTarget.Location = new System.Drawing.Point(363, 18);
            this.tbTarget.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTarget.Name = "tbTarget";
            this.tbTarget.Size = new System.Drawing.Size(106, 23);
            this.tbTarget.TabIndex = 153;
            // 
            // chk세토아가호
            // 
            this.chk세토아가호.AutoSize = true;
            this.chk세토아가호.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk세토아가호.Location = new System.Drawing.Point(5, 45);
            this.chk세토아가호.Margin = new System.Windows.Forms.Padding(1);
            this.chk세토아가호.Name = "chk세토아가호";
            this.chk세토아가호.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk세토아가호.Size = new System.Drawing.Size(99, 18);
            this.chk세토아가호.TabIndex = 110;
            this.chk세토아가호.Text = "세토아가호";
            this.chk세토아가호.UseVisualStyleBackColor = true;
            // 
            // chk이아가호
            // 
            this.chk이아가호.AutoSize = true;
            this.chk이아가호.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk이아가호.Location = new System.Drawing.Point(5, 24);
            this.chk이아가호.Margin = new System.Windows.Forms.Padding(1);
            this.chk이아가호.Name = "chk이아가호";
            this.chk이아가호.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk이아가호.Size = new System.Drawing.Size(85, 18);
            this.chk이아가호.TabIndex = 111;
            this.chk이아가호.Text = "이아가호";
            this.chk이아가호.UseVisualStyleBackColor = true;
            // 
            // chk모션제거
            // 
            this.chk모션제거.AutoSize = true;
            this.chk모션제거.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk모션제거.Location = new System.Drawing.Point(5, 65);
            this.chk모션제거.Margin = new System.Windows.Forms.Padding(1);
            this.chk모션제거.Name = "chk모션제거";
            this.chk모션제거.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk모션제거.Size = new System.Drawing.Size(85, 18);
            this.chk모션제거.TabIndex = 129;
            this.chk모션제거.Text = "모션제거";
            this.chk모션제거.UseVisualStyleBackColor = true;
            // 
            // chk센서스핵
            // 
            this.chk센서스핵.AutoSize = true;
            this.chk센서스핵.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk센서스핵.Location = new System.Drawing.Point(5, 86);
            this.chk센서스핵.Margin = new System.Windows.Forms.Padding(1);
            this.chk센서스핵.Name = "chk센서스핵";
            this.chk센서스핵.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk센서스핵.Size = new System.Drawing.Size(85, 18);
            this.chk센서스핵.TabIndex = 131;
            this.chk센서스핵.Text = "센서스핵";
            this.chk센서스핵.UseVisualStyleBackColor = true;
            // 
            // chk자동부활
            // 
            this.chk자동부활.AutoSize = true;
            this.chk자동부활.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk자동부활.Location = new System.Drawing.Point(5, 171);
            this.chk자동부활.Margin = new System.Windows.Forms.Padding(1);
            this.chk자동부활.Name = "chk자동부활";
            this.chk자동부활.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk자동부활.Size = new System.Drawing.Size(85, 18);
            this.chk자동부활.TabIndex = 126;
            this.chk자동부활.Text = "자동부활";
            this.chk자동부활.UseVisualStyleBackColor = true;
            // 
            // chk유저회피
            // 
            this.chk유저회피.AutoSize = true;
            this.chk유저회피.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk유저회피.Location = new System.Drawing.Point(5, 129);
            this.chk유저회피.Margin = new System.Windows.Forms.Padding(1);
            this.chk유저회피.Name = "chk유저회피";
            this.chk유저회피.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk유저회피.Size = new System.Drawing.Size(85, 18);
            this.chk유저회피.TabIndex = 124;
            this.chk유저회피.Text = "유저회피";
            this.chk유저회피.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkShot);
            this.groupBox4.Controls.Add(this.chk동전깔기);
            this.groupBox4.Controls.Add(this.chk원격수리);
            this.groupBox4.Controls.Add(this.chk시스템창);
            this.groupBox4.Controls.Add(this.chk수벗);
            this.groupBox4.Controls.Add(this.chk자그);
            this.groupBox4.Controls.Add(this.chk걸리적);
            this.groupBox4.Controls.Add(this.chk경팔마력);
            this.groupBox4.Controls.Add(this.chk경팔체력);
            this.groupBox4.Controls.Add(this.chk채집);
            this.groupBox4.Controls.Add(this.chk어설픈수리);
            this.groupBox4.Controls.Add(this.chk노룹따라가기);
            this.groupBox4.Controls.Add(this.chk자동사냥);
            this.groupBox4.Controls.Add(this.chk이아가호);
            this.groupBox4.Controls.Add(this.chk세토아가호);
            this.groupBox4.Controls.Add(this.chk모션제거);
            this.groupBox4.Controls.Add(this.chk유저회피);
            this.groupBox4.Controls.Add(this.chk연막무시);
            this.groupBox4.Controls.Add(this.chk센서스핵);
            this.groupBox4.Controls.Add(this.chk자동루팅);
            this.groupBox4.Controls.Add(this.chk자동부활);
            this.groupBox4.Location = new System.Drawing.Point(7, 8);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(459, 210);
            this.groupBox4.TabIndex = 135;
            this.groupBox4.TabStop = false;
            // 
            // chkShot
            // 
            this.chkShot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkShot.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkShot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShot.Location = new System.Drawing.Point(302, 45);
            this.chkShot.Margin = new System.Windows.Forms.Padding(1);
            this.chkShot.Name = "chkShot";
            this.chkShot.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkShot.Size = new System.Drawing.Size(105, 19);
            this.chkShot.TabIndex = 171;
            this.chkShot.Text = "샷사용";
            this.chkShot.UseVisualStyleBackColor = false;
            // 
            // chk동전깔기
            // 
            this.chk동전깔기.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk동전깔기.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk동전깔기.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk동전깔기.Location = new System.Drawing.Point(193, 108);
            this.chk동전깔기.Margin = new System.Windows.Forms.Padding(1);
            this.chk동전깔기.Name = "chk동전깔기";
            this.chk동전깔기.Size = new System.Drawing.Size(90, 19);
            this.chk동전깔기.TabIndex = 166;
            this.chk동전깔기.Text = "동전깔기";
            this.chk동전깔기.UseVisualStyleBackColor = false;
            // 
            // chk원격수리
            // 
            this.chk원격수리.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk원격수리.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk원격수리.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk원격수리.Location = new System.Drawing.Point(97, 65);
            this.chk원격수리.Margin = new System.Windows.Forms.Padding(1);
            this.chk원격수리.Name = "chk원격수리";
            this.chk원격수리.Size = new System.Drawing.Size(90, 19);
            this.chk원격수리.TabIndex = 162;
            this.chk원격수리.Text = "원격수리";
            this.chk원격수리.UseVisualStyleBackColor = false;
            // 
            // chk시스템창
            // 
            this.chk시스템창.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk시스템창.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk시스템창.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk시스템창.Location = new System.Drawing.Point(97, 45);
            this.chk시스템창.Margin = new System.Windows.Forms.Padding(1);
            this.chk시스템창.Name = "chk시스템창";
            this.chk시스템창.Size = new System.Drawing.Size(90, 19);
            this.chk시스템창.TabIndex = 163;
            this.chk시스템창.Text = "시스템창";
            this.chk시스템창.UseVisualStyleBackColor = false;
            // 
            // chk수벗
            // 
            this.chk수벗.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk수벗.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk수벗.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk수벗.Location = new System.Drawing.Point(97, 86);
            this.chk수벗.Margin = new System.Windows.Forms.Padding(1);
            this.chk수벗.Name = "chk수벗";
            this.chk수벗.Size = new System.Drawing.Size(90, 19);
            this.chk수벗.TabIndex = 163;
            this.chk수벗.Text = "수벗";
            this.chk수벗.UseVisualStyleBackColor = false;
            this.chk수벗.CheckedChanged += new System.EventHandler(this.chk수벗_CheckedChanged);
            // 
            // chk자그
            // 
            this.chk자그.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk자그.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk자그.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk자그.Location = new System.Drawing.Point(97, 108);
            this.chk자그.Margin = new System.Windows.Forms.Padding(1);
            this.chk자그.Name = "chk자그";
            this.chk자그.Size = new System.Drawing.Size(90, 19);
            this.chk자그.TabIndex = 163;
            this.chk자그.Text = "자그";
            this.chk자그.UseVisualStyleBackColor = false;
            this.chk자그.CheckedChanged += new System.EventHandler(this.chk자그_CheckedChanged);
            // 
            // chk걸리적
            // 
            this.chk걸리적.AutoSize = true;
            this.chk걸리적.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk걸리적.Location = new System.Drawing.Point(97, 24);
            this.chk걸리적.Margin = new System.Windows.Forms.Padding(1);
            this.chk걸리적.Name = "chk걸리적";
            this.chk걸리적.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk걸리적.Size = new System.Drawing.Size(71, 18);
            this.chk걸리적.TabIndex = 160;
            this.chk걸리적.Text = "걸리적";
            this.chk걸리적.UseVisualStyleBackColor = true;
            // 
            // chk경팔마력
            // 
            this.chk경팔마력.AutoSize = true;
            this.chk경팔마력.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk경팔마력.Location = new System.Drawing.Point(302, 95);
            this.chk경팔마력.Margin = new System.Windows.Forms.Padding(1);
            this.chk경팔마력.Name = "chk경팔마력";
            this.chk경팔마력.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk경팔마력.Size = new System.Drawing.Size(85, 18);
            this.chk경팔마력.TabIndex = 159;
            this.chk경팔마력.Text = "경팔마력";
            this.chk경팔마력.UseVisualStyleBackColor = true;
            // 
            // chk경팔체력
            // 
            this.chk경팔체력.AutoSize = true;
            this.chk경팔체력.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk경팔체력.Location = new System.Drawing.Point(302, 70);
            this.chk경팔체력.Margin = new System.Windows.Forms.Padding(1);
            this.chk경팔체력.Name = "chk경팔체력";
            this.chk경팔체력.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk경팔체력.Size = new System.Drawing.Size(85, 18);
            this.chk경팔체력.TabIndex = 158;
            this.chk경팔체력.Text = "경팔체력";
            this.chk경팔체력.UseVisualStyleBackColor = true;
            // 
            // chk채집
            // 
            this.chk채집.AutoSize = true;
            this.chk채집.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk채집.Location = new System.Drawing.Point(193, 65);
            this.chk채집.Margin = new System.Windows.Forms.Padding(1);
            this.chk채집.Name = "chk채집";
            this.chk채집.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk채집.Size = new System.Drawing.Size(57, 18);
            this.chk채집.TabIndex = 156;
            this.chk채집.Text = "채집";
            this.chk채집.UseVisualStyleBackColor = true;
            this.chk채집.CheckedChanged += new System.EventHandler(this.chk채집_CheckedChanged);
            // 
            // chk어설픈수리
            // 
            this.chk어설픈수리.AutoSize = true;
            this.chk어설픈수리.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk어설픈수리.Location = new System.Drawing.Point(193, 45);
            this.chk어설픈수리.Margin = new System.Windows.Forms.Padding(1);
            this.chk어설픈수리.Name = "chk어설픈수리";
            this.chk어설픈수리.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk어설픈수리.Size = new System.Drawing.Size(118, 18);
            this.chk어설픈수리.TabIndex = 155;
            this.chk어설픈수리.Text = "어설픈 고치기";
            this.chk어설픈수리.UseVisualStyleBackColor = true;
            this.chk어설픈수리.CheckedChanged += new System.EventHandler(this.chk어설픈수리_CheckedChanged);
            // 
            // chk노룹따라가기
            // 
            this.chk노룹따라가기.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk노룹따라가기.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk노룹따라가기.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk노룹따라가기.Location = new System.Drawing.Point(302, 24);
            this.chk노룹따라가기.Margin = new System.Windows.Forms.Padding(1);
            this.chk노룹따라가기.Name = "chk노룹따라가기";
            this.chk노룹따라가기.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk노룹따라가기.Size = new System.Drawing.Size(105, 19);
            this.chk노룹따라가기.TabIndex = 152;
            this.chk노룹따라가기.Text = "노룹따라가기";
            this.chk노룹따라가기.UseVisualStyleBackColor = false;
            // 
            // chk자동사냥
            // 
            this.chk자동사냥.AutoSize = true;
            this.chk자동사냥.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk자동사냥.Location = new System.Drawing.Point(193, 24);
            this.chk자동사냥.Margin = new System.Windows.Forms.Padding(1);
            this.chk자동사냥.Name = "chk자동사냥";
            this.chk자동사냥.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk자동사냥.Size = new System.Drawing.Size(85, 18);
            this.chk자동사냥.TabIndex = 133;
            this.chk자동사냥.Text = "자동사냥";
            this.chk자동사냥.UseVisualStyleBackColor = true;
            this.chk자동사냥.CheckedChanged += new System.EventHandler(this.chk자동사냥_CheckedChanged);
            // 
            // chk연막무시
            // 
            this.chk연막무시.AutoSize = true;
            this.chk연막무시.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk연막무시.Location = new System.Drawing.Point(5, 108);
            this.chk연막무시.Margin = new System.Windows.Forms.Padding(1);
            this.chk연막무시.Name = "chk연막무시";
            this.chk연막무시.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk연막무시.Size = new System.Drawing.Size(85, 18);
            this.chk연막무시.TabIndex = 131;
            this.chk연막무시.Text = "연막무시";
            this.chk연막무시.UseVisualStyleBackColor = true;
            // 
            // chk자동루팅
            // 
            this.chk자동루팅.AutoSize = true;
            this.chk자동루팅.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk자동루팅.Location = new System.Drawing.Point(193, 86);
            this.chk자동루팅.Margin = new System.Windows.Forms.Padding(1);
            this.chk자동루팅.Name = "chk자동루팅";
            this.chk자동루팅.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk자동루팅.Size = new System.Drawing.Size(85, 18);
            this.chk자동루팅.TabIndex = 126;
            this.chk자동루팅.Text = "자동줍기";
            this.chk자동루팅.UseVisualStyleBackColor = true;
            this.chk자동루팅.CheckedChanged += new System.EventHandler(this.chk자동루팅_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(1, 55);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(483, 266);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(475, 237);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "편의";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tbWarTarget);
            this.tabPage4.Controls.Add(this.chkTarget데프);
            this.tabPage4.Controls.Add(this.chkTarget나르);
            this.tabPage4.Controls.Add(this.checkBox18);
            this.tabPage4.Controls.Add(this.chk쟁);
            this.tabPage4.Controls.Add(this.chkTarget리베);
            this.tabPage4.Controls.Add(this.groupBox8);
            this.tabPage4.Controls.Add(this.groupBox7);
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Size = new System.Drawing.Size(475, 237);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "전쟁";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tbWarTarget
            // 
            this.tbWarTarget.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbWarTarget.Location = new System.Drawing.Point(321, 91);
            this.tbWarTarget.Margin = new System.Windows.Forms.Padding(0);
            this.tbWarTarget.Name = "tbWarTarget";
            this.tbWarTarget.Size = new System.Drawing.Size(114, 23);
            this.tbWarTarget.TabIndex = 2;
            // 
            // chkTarget데프
            // 
            this.chkTarget데프.AutoSize = true;
            this.chkTarget데프.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkTarget데프.Location = new System.Drawing.Point(321, 178);
            this.chkTarget데프.Margin = new System.Windows.Forms.Padding(0);
            this.chkTarget데프.Name = "chkTarget데프";
            this.chkTarget데프.Size = new System.Drawing.Size(90, 18);
            this.chkTarget데프.TabIndex = 0;
            this.chkTarget데프.Text = "타겟 데프";
            this.chkTarget데프.UseVisualStyleBackColor = true;
            // 
            // chkTarget나르
            // 
            this.chkTarget나르.AutoSize = true;
            this.chkTarget나르.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkTarget나르.Location = new System.Drawing.Point(321, 151);
            this.chkTarget나르.Margin = new System.Windows.Forms.Padding(0);
            this.chkTarget나르.Name = "chkTarget나르";
            this.chkTarget나르.Size = new System.Drawing.Size(90, 18);
            this.chkTarget나르.TabIndex = 0;
            this.chkTarget나르.Text = "타겟 나르";
            this.chkTarget나르.UseVisualStyleBackColor = true;
            // 
            // checkBox18
            // 
            this.checkBox18.AutoSize = true;
            this.checkBox18.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox18.Location = new System.Drawing.Point(321, 200);
            this.checkBox18.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(152, 18);
            this.checkBox18.TabIndex = 0;
            this.checkBox18.Text = "타겟 연공(3칸유지)";
            this.checkBox18.UseVisualStyleBackColor = true;
            // 
            // chk쟁
            // 
            this.chk쟁.AutoSize = true;
            this.chk쟁.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk쟁.Location = new System.Drawing.Point(11, 16);
            this.chk쟁.Margin = new System.Windows.Forms.Padding(0);
            this.chk쟁.Name = "chk쟁";
            this.chk쟁.Size = new System.Drawing.Size(141, 18);
            this.chk쟁.TabIndex = 0;
            this.chk쟁.Text = "사용하시려면체크";
            this.chk쟁.UseVisualStyleBackColor = true;
            this.chk쟁.CheckedChanged += new System.EventHandler(this.chk쟁_CheckedChanged);
            // 
            // chkTarget리베
            // 
            this.chkTarget리베.AutoSize = true;
            this.chkTarget리베.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkTarget리베.Location = new System.Drawing.Point(321, 125);
            this.chkTarget리베.Margin = new System.Windows.Forms.Padding(0);
            this.chkTarget리베.Name = "chkTarget리베";
            this.chkTarget리베.Size = new System.Drawing.Size(90, 18);
            this.chkTarget리베.TabIndex = 0;
            this.chkTarget리베.Text = "타겟 리베";
            this.chkTarget리베.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.checkBox11);
            this.groupBox8.Controls.Add(this.checkBox17);
            this.groupBox8.Controls.Add(this.checkBox16);
            this.groupBox8.Controls.Add(this.checkBox14);
            this.groupBox8.Controls.Add(this.chk적길리베);
            this.groupBox8.Controls.Add(this.chk무길리베);
            this.groupBox8.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox8.Location = new System.Drawing.Point(11, 136);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox8.Size = new System.Drawing.Size(239, 88);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "스킬 감지 시 리베";
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(10, 52);
            this.checkBox11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(57, 18);
            this.checkBox11.TabIndex = 0;
            this.checkBox11.Text = "적길";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox17
            // 
            this.checkBox17.AutoSize = true;
            this.checkBox17.Location = new System.Drawing.Point(147, 45);
            this.checkBox17.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(57, 18);
            this.checkBox17.TabIndex = 0;
            this.checkBox17.Text = "완방";
            this.checkBox17.UseVisualStyleBackColor = true;
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(147, 18);
            this.checkBox16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(57, 18);
            this.checkBox16.TabIndex = 0;
            this.checkBox16.Text = "호르";
            this.checkBox16.UseVisualStyleBackColor = true;
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(72, 52);
            this.checkBox14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(57, 18);
            this.checkBox14.TabIndex = 0;
            this.checkBox14.Text = "반탄";
            this.checkBox14.UseVisualStyleBackColor = true;
            // 
            // chk적길리베
            // 
            this.chk적길리베.AutoSize = true;
            this.chk적길리베.Location = new System.Drawing.Point(72, 25);
            this.chk적길리베.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk적길리베.Name = "chk적길리베";
            this.chk적길리베.Size = new System.Drawing.Size(71, 18);
            this.chk적길리베.TabIndex = 0;
            this.chk적길리베.Text = "이모탈";
            this.chk적길리베.UseVisualStyleBackColor = true;
            // 
            // chk무길리베
            // 
            this.chk무길리베.AutoSize = true;
            this.chk무길리베.Location = new System.Drawing.Point(10, 25);
            this.chk무길리베.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk무길리베.Name = "chk무길리베";
            this.chk무길리베.Size = new System.Drawing.Size(57, 18);
            this.chk무길리베.TabIndex = 0;
            this.chk무길리베.Text = "무길";
            this.chk무길리베.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chk적길나르);
            this.groupBox7.Controls.Add(this.chk무길나르);
            this.groupBox7.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox7.Location = new System.Drawing.Point(11, 80);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox7.Size = new System.Drawing.Size(142, 52);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "나르";
            // 
            // chk적길나르
            // 
            this.chk적길나르.AutoSize = true;
            this.chk적길나르.Location = new System.Drawing.Point(72, 25);
            this.chk적길나르.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk적길나르.Name = "chk적길나르";
            this.chk적길나르.Size = new System.Drawing.Size(57, 18);
            this.chk적길나르.TabIndex = 0;
            this.chk적길나르.Text = "적길";
            this.chk적길나르.UseVisualStyleBackColor = true;
            // 
            // chk무길나르
            // 
            this.chk무길나르.AutoSize = true;
            this.chk무길나르.Location = new System.Drawing.Point(10, 25);
            this.chk무길나르.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk무길나르.Name = "chk무길나르";
            this.chk무길나르.Size = new System.Drawing.Size(57, 18);
            this.chk무길나르.TabIndex = 0;
            this.chk무길나르.Text = "무길";
            this.chk무길나르.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chk적길데프);
            this.groupBox5.Controls.Add(this.chk무길데프);
            this.groupBox5.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox5.Location = new System.Drawing.Point(11, 35);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(142, 44);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "데프";
            // 
            // chk적길데프
            // 
            this.chk적길데프.AutoSize = true;
            this.chk적길데프.Location = new System.Drawing.Point(69, 18);
            this.chk적길데프.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk적길데프.Name = "chk적길데프";
            this.chk적길데프.Size = new System.Drawing.Size(57, 18);
            this.chk적길데프.TabIndex = 0;
            this.chk적길데프.Text = "적길";
            this.chk적길데프.UseVisualStyleBackColor = true;
            // 
            // chk무길데프
            // 
            this.chk무길데프.AutoSize = true;
            this.chk무길데프.Location = new System.Drawing.Point(7, 18);
            this.chk무길데프.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk무길데프.Name = "chk무길데프";
            this.chk무길데프.Size = new System.Drawing.Size(57, 18);
            this.chk무길데프.TabIndex = 0;
            this.chk무길데프.Text = "무길";
            this.chk무길데프.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox13);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage5.Size = new System.Drawing.Size(475, 237);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "알람";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.chkAlert);
            this.groupBox13.Controls.Add(this.chkTalk1);
            this.groupBox13.Controls.Add(this.tbTalk1);
            this.groupBox13.Controls.Add(this.chkBeep);
            this.groupBox13.Controls.Add(this.chkStopHunt);
            this.groupBox13.Controls.Add(this.chk은신감지);
            this.groupBox13.Controls.Add(this.chk유저감지);
            this.groupBox13.Location = new System.Drawing.Point(7, 8);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox13.Size = new System.Drawing.Size(458, 219);
            this.groupBox13.TabIndex = 168;
            this.groupBox13.TabStop = false;
            // 
            // chkAlert
            // 
            this.chkAlert.AutoSize = true;
            this.chkAlert.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkAlert.Location = new System.Drawing.Point(7, 0);
            this.chkAlert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAlert.Name = "chkAlert";
            this.chkAlert.Size = new System.Drawing.Size(57, 18);
            this.chkAlert.TabIndex = 131;
            this.chkAlert.Text = "알람";
            this.chkAlert.UseVisualStyleBackColor = true;
            this.chkAlert.CheckedChanged += new System.EventHandler(this.chkAlert_CheckedChanged);
            // 
            // chkTalk1
            // 
            this.chkTalk1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkTalk1.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkTalk1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkTalk1.Location = new System.Drawing.Point(7, 109);
            this.chkTalk1.Margin = new System.Windows.Forms.Padding(1);
            this.chkTalk1.Name = "chkTalk1";
            this.chkTalk1.Size = new System.Drawing.Size(80, 19);
            this.chkTalk1.TabIndex = 167;
            this.chkTalk1.Text = "불렸을때";
            this.chkTalk1.UseVisualStyleBackColor = false;
            // 
            // tbTalk1
            // 
            this.tbTalk1.Location = new System.Drawing.Point(94, 105);
            this.tbTalk1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTalk1.Name = "tbTalk1";
            this.tbTalk1.Size = new System.Drawing.Size(218, 25);
            this.tbTalk1.TabIndex = 164;
            // 
            // chkBeep
            // 
            this.chkBeep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkBeep.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkBeep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkBeep.Location = new System.Drawing.Point(7, 24);
            this.chkBeep.Margin = new System.Windows.Forms.Padding(1);
            this.chkBeep.Name = "chkBeep";
            this.chkBeep.Size = new System.Drawing.Size(67, 19);
            this.chkBeep.TabIndex = 163;
            this.chkBeep.Text = "비프음";
            this.chkBeep.UseVisualStyleBackColor = false;
            // 
            // chkStopHunt
            // 
            this.chkStopHunt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkStopHunt.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkStopHunt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkStopHunt.Location = new System.Drawing.Point(7, 45);
            this.chkStopHunt.Margin = new System.Windows.Forms.Padding(1);
            this.chkStopHunt.Name = "chkStopHunt";
            this.chkStopHunt.Size = new System.Drawing.Size(80, 19);
            this.chkStopHunt.TabIndex = 162;
            this.chkStopHunt.Text = "사냥중지";
            this.chkStopHunt.UseVisualStyleBackColor = false;
            // 
            // chk은신감지
            // 
            this.chk은신감지.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk은신감지.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk은신감지.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk은신감지.Location = new System.Drawing.Point(7, 88);
            this.chk은신감지.Margin = new System.Windows.Forms.Padding(1);
            this.chk은신감지.Name = "chk은신감지";
            this.chk은신감지.Size = new System.Drawing.Size(112, 19);
            this.chk은신감지.TabIndex = 161;
            this.chk은신감지.Text = "은신감지리콜";
            this.chk은신감지.UseVisualStyleBackColor = false;
            // 
            // chk유저감지
            // 
            this.chk유저감지.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk유저감지.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk유저감지.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk유저감지.Location = new System.Drawing.Point(7, 66);
            this.chk유저감지.Margin = new System.Windows.Forms.Padding(1);
            this.chk유저감지.Name = "chk유저감지";
            this.chk유저감지.Size = new System.Drawing.Size(127, 19);
            this.chk유저감지.TabIndex = 161;
            this.chk유저감지.Text = "유저발견리콜";
            this.chk유저감지.UseVisualStyleBackColor = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox11);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(475, 237);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "디스펠";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.chk버프);
            this.groupBox11.Controls.Add(this.chkKolama);
            this.groupBox11.Controls.Add(this.chkHorrma);
            this.groupBox11.Controls.Add(this.chkSA);
            this.groupBox11.Location = new System.Drawing.Point(226, 6);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox11.Size = new System.Drawing.Size(241, 220);
            this.groupBox11.TabIndex = 148;
            this.groupBox11.TabStop = false;
            // 
            // chk버프
            // 
            this.chk버프.AutoSize = true;
            this.chk버프.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk버프.Location = new System.Drawing.Point(7, 1);
            this.chk버프.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk버프.Name = "chk버프";
            this.chk버프.Size = new System.Drawing.Size(113, 18);
            this.chk버프.TabIndex = 1;
            this.chk버프.Text = "버프주기사용";
            this.chk버프.UseVisualStyleBackColor = true;
            this.chk버프.CheckedChanged += new System.EventHandler(this.chk버프_CheckedChanged);
            // 
            // chkKolama
            // 
            this.chkKolama.AutoSize = true;
            this.chkKolama.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkKolama.Location = new System.Drawing.Point(64, 25);
            this.chkKolama.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkKolama.Name = "chkKolama";
            this.chkKolama.Size = new System.Drawing.Size(57, 18);
            this.chkKolama.TabIndex = 146;
            this.chkKolama.Text = "콜라";
            this.chkKolama.UseVisualStyleBackColor = true;
            // 
            // chkHorrma
            // 
            this.chkHorrma.AutoSize = true;
            this.chkHorrma.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkHorrma.Location = new System.Drawing.Point(7, 25);
            this.chkHorrma.Margin = new System.Windows.Forms.Padding(1);
            this.chkHorrma.Name = "chkHorrma";
            this.chkHorrma.Size = new System.Drawing.Size(57, 18);
            this.chkHorrma.TabIndex = 145;
            this.chkHorrma.Text = "호르";
            this.chkHorrma.UseVisualStyleBackColor = true;
            // 
            // chkSA
            // 
            this.chkSA.AutoSize = true;
            this.chkSA.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkSA.Location = new System.Drawing.Point(7, 46);
            this.chkSA.Margin = new System.Windows.Forms.Padding(1);
            this.chkSA.Name = "chkSA";
            this.chkSA.Size = new System.Drawing.Size(57, 18);
            this.chkSA.TabIndex = 147;
            this.chkSA.Text = "속강";
            this.chkSA.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chk디스펠);
            this.groupBox3.Controls.Add(this.chkTargetAll);
            this.groupBox3.Controls.Add(this.chk자신);
            this.groupBox3.Controls.Add(this.chkTagetGroup);
            this.groupBox3.Controls.Add(this.tbGroupHeal);
            this.groupBox3.Controls.Add(this.chkDeNarcoli);
            this.groupBox3.Controls.Add(this.chkTagetGuild);
            this.groupBox3.Controls.Add(this.chk그룹전체힐);
            this.groupBox3.Controls.Add(this.chk그룹힐);
            this.groupBox3.Controls.Add(this.chkDeDefleca);
            this.groupBox3.Controls.Add(this.chkDeSoruma);
            this.groupBox3.Controls.Add(this.chk자동저주풀기);
            this.groupBox3.Controls.Add(this.chk코마);
            this.groupBox3.Controls.Add(this.chkIllumena);
            this.groupBox3.Controls.Add(this.chkDeBardo);
            this.groupBox3.Controls.Add(this.chkDeVenomo);
            this.groupBox3.Controls.Add(this.chkHolyCure);
            this.groupBox3.Controls.Add(this.chkDePrava);
            this.groupBox3.Controls.Add(this.chkDeRento);
            this.groupBox3.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(7, 8);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox3.Size = new System.Drawing.Size(216, 219);
            this.groupBox3.TabIndex = 136;
            this.groupBox3.TabStop = false;
            // 
            // chk디스펠
            // 
            this.chk디스펠.AutoSize = true;
            this.chk디스펠.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk디스펠.Location = new System.Drawing.Point(5, 0);
            this.chk디스펠.Margin = new System.Windows.Forms.Padding(1);
            this.chk디스펠.Name = "chk디스펠";
            this.chk디스펠.Size = new System.Drawing.Size(99, 18);
            this.chk디스펠.TabIndex = 1;
            this.chk디스펠.Text = "디스펠사용";
            this.chk디스펠.UseVisualStyleBackColor = true;
            this.chk디스펠.CheckedChanged += new System.EventHandler(this.chk디스펠_CheckedChanged);
            // 
            // chkTargetAll
            // 
            this.chkTargetAll.AutoSize = true;
            this.chkTargetAll.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkTargetAll.Location = new System.Drawing.Point(5, 24);
            this.chkTargetAll.Margin = new System.Windows.Forms.Padding(1);
            this.chkTargetAll.Name = "chkTargetAll";
            this.chkTargetAll.Size = new System.Drawing.Size(57, 18);
            this.chkTargetAll.TabIndex = 144;
            this.chkTargetAll.Text = "전체";
            this.chkTargetAll.UseVisualStyleBackColor = true;
            // 
            // chk자신
            // 
            this.chk자신.AutoSize = true;
            this.chk자신.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk자신.Location = new System.Drawing.Point(5, 88);
            this.chk자신.Margin = new System.Windows.Forms.Padding(1);
            this.chk자신.Name = "chk자신";
            this.chk자신.Size = new System.Drawing.Size(57, 18);
            this.chk자신.TabIndex = 142;
            this.chk자신.Text = "자신";
            this.chk자신.UseVisualStyleBackColor = true;
            // 
            // chkTagetGroup
            // 
            this.chkTagetGroup.AutoSize = true;
            this.chkTagetGroup.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkTagetGroup.Location = new System.Drawing.Point(5, 66);
            this.chkTagetGroup.Margin = new System.Windows.Forms.Padding(1);
            this.chkTagetGroup.Name = "chkTagetGroup";
            this.chkTagetGroup.Size = new System.Drawing.Size(57, 18);
            this.chkTagetGroup.TabIndex = 142;
            this.chkTagetGroup.Text = "그룹";
            this.chkTagetGroup.UseVisualStyleBackColor = true;
            // 
            // tbGroupHeal
            // 
            this.tbGroupHeal.AutoSize = false;
            this.tbGroupHeal.BackColor = System.Drawing.SystemColors.Control;
            this.tbGroupHeal.Location = new System.Drawing.Point(98, 151);
            this.tbGroupHeal.Margin = new System.Windows.Forms.Padding(1);
            this.tbGroupHeal.Maximum = 100;
            this.tbGroupHeal.Name = "tbGroupHeal";
            this.tbGroupHeal.Size = new System.Drawing.Size(91, 19);
            this.tbGroupHeal.TabIndex = 141;
            this.tbGroupHeal.TickFrequency = 10;
            this.tbGroupHeal.Value = 90;
            this.tbGroupHeal.Scroll += new System.EventHandler(this.tbGroupHeal_Scroll);
            // 
            // chkDeNarcoli
            // 
            this.chkDeNarcoli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkDeNarcoli.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkDeNarcoli.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkDeNarcoli.Location = new System.Drawing.Point(71, 130);
            this.chkDeNarcoli.Margin = new System.Windows.Forms.Padding(1);
            this.chkDeNarcoli.Name = "chkDeNarcoli";
            this.chkDeNarcoli.Size = new System.Drawing.Size(57, 19);
            this.chkDeNarcoli.TabIndex = 131;
            this.chkDeNarcoli.Text = "디나";
            this.chkDeNarcoli.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkDeNarcoli.UseVisualStyleBackColor = true;
            // 
            // chkTagetGuild
            // 
            this.chkTagetGuild.AutoSize = true;
            this.chkTagetGuild.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkTagetGuild.Location = new System.Drawing.Point(5, 45);
            this.chkTagetGuild.Margin = new System.Windows.Forms.Padding(1);
            this.chkTagetGuild.Name = "chkTagetGuild";
            this.chkTagetGuild.Size = new System.Drawing.Size(71, 18);
            this.chkTagetGuild.TabIndex = 143;
            this.chkTagetGuild.Text = "길드원";
            this.chkTagetGuild.UseVisualStyleBackColor = true;
            // 
            // chk그룹전체힐
            // 
            this.chk그룹전체힐.AutoSize = true;
            this.chk그룹전체힐.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk그룹전체힐.Location = new System.Drawing.Point(5, 172);
            this.chk그룹전체힐.Margin = new System.Windows.Forms.Padding(1);
            this.chk그룹전체힐.Name = "chk그룹전체힐";
            this.chk그룹전체힐.Size = new System.Drawing.Size(195, 18);
            this.chk그룹전체힐.TabIndex = 138;
            this.chk그룹전체힐.Text = "온니전체힐(홀리쿠라네라)";
            this.chk그룹전체힐.UseVisualStyleBackColor = true;
            // 
            // chk그룹힐
            // 
            this.chk그룹힐.AutoSize = true;
            this.chk그룹힐.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk그룹힐.Location = new System.Drawing.Point(5, 151);
            this.chk그룹힐.Margin = new System.Windows.Forms.Padding(1);
            this.chk그룹힐.Name = "chk그룹힐";
            this.chk그룹힐.Size = new System.Drawing.Size(71, 18);
            this.chk그룹힐.TabIndex = 138;
            this.chk그룹힐.Text = "그룹힐";
            this.chk그룹힐.UseVisualStyleBackColor = true;
            // 
            // chkDeDefleca
            // 
            this.chkDeDefleca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkDeDefleca.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkDeDefleca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkDeDefleca.Location = new System.Drawing.Point(71, 24);
            this.chkDeDefleca.Margin = new System.Windows.Forms.Padding(1);
            this.chkDeDefleca.Name = "chkDeDefleca";
            this.chkDeDefleca.Size = new System.Drawing.Size(57, 19);
            this.chkDeDefleca.TabIndex = 134;
            this.chkDeDefleca.Text = "디데";
            this.chkDeDefleca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkDeDefleca.UseVisualStyleBackColor = true;
            // 
            // chkDeSoruma
            // 
            this.chkDeSoruma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkDeSoruma.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkDeSoruma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkDeSoruma.Location = new System.Drawing.Point(71, 109);
            this.chkDeSoruma.Margin = new System.Windows.Forms.Padding(1);
            this.chkDeSoruma.Name = "chkDeSoruma";
            this.chkDeSoruma.Size = new System.Drawing.Size(57, 19);
            this.chkDeSoruma.TabIndex = 129;
            this.chkDeSoruma.Text = "디소";
            this.chkDeSoruma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkDeSoruma.UseVisualStyleBackColor = true;
            // 
            // chk자동저주풀기
            // 
            this.chk자동저주풀기.AutoSize = true;
            this.chk자동저주풀기.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk자동저주풀기.Location = new System.Drawing.Point(133, 66);
            this.chk자동저주풀기.Margin = new System.Windows.Forms.Padding(1);
            this.chk자동저주풀기.Name = "chk자동저주풀기";
            this.chk자동저주풀기.Size = new System.Drawing.Size(85, 18);
            this.chk자동저주풀기.TabIndex = 140;
            this.chk자동저주풀기.Text = "저주풀기";
            this.chk자동저주풀기.UseVisualStyleBackColor = true;
            // 
            // chk코마
            // 
            this.chk코마.AutoSize = true;
            this.chk코마.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk코마.Location = new System.Drawing.Point(71, 88);
            this.chk코마.Margin = new System.Windows.Forms.Padding(1);
            this.chk코마.Name = "chk코마";
            this.chk코마.Size = new System.Drawing.Size(99, 18);
            this.chk코마.TabIndex = 139;
            this.chk코마.Text = "코마살리기";
            this.chk코마.UseVisualStyleBackColor = true;
            // 
            // chkIllumena
            // 
            this.chkIllumena.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkIllumena.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkIllumena.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkIllumena.Location = new System.Drawing.Point(133, 45);
            this.chkIllumena.Margin = new System.Windows.Forms.Padding(1);
            this.chkIllumena.Name = "chkIllumena";
            this.chkIllumena.Size = new System.Drawing.Size(57, 19);
            this.chkIllumena.TabIndex = 135;
            this.chkIllumena.Text = "일루";
            this.chkIllumena.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkIllumena.UseVisualStyleBackColor = true;
            // 
            // chkDeBardo
            // 
            this.chkDeBardo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkDeBardo.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkDeBardo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkDeBardo.Location = new System.Drawing.Point(5, 130);
            this.chkDeBardo.Margin = new System.Windows.Forms.Padding(1);
            this.chkDeBardo.Name = "chkDeBardo";
            this.chkDeBardo.Size = new System.Drawing.Size(57, 19);
            this.chkDeBardo.TabIndex = 132;
            this.chkDeBardo.Text = "디바";
            this.chkDeBardo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkDeBardo.UseVisualStyleBackColor = true;
            // 
            // chkDeVenomo
            // 
            this.chkDeVenomo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkDeVenomo.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkDeVenomo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkDeVenomo.Location = new System.Drawing.Point(133, 24);
            this.chkDeVenomo.Margin = new System.Windows.Forms.Padding(1);
            this.chkDeVenomo.Name = "chkDeVenomo";
            this.chkDeVenomo.Size = new System.Drawing.Size(57, 19);
            this.chkDeVenomo.TabIndex = 133;
            this.chkDeVenomo.Text = "디베";
            this.chkDeVenomo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkDeVenomo.UseVisualStyleBackColor = true;
            // 
            // chkHolyCure
            // 
            this.chkHolyCure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkHolyCure.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkHolyCure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkHolyCure.Location = new System.Drawing.Point(71, 66);
            this.chkHolyCure.Margin = new System.Windows.Forms.Padding(1);
            this.chkHolyCure.Name = "chkHolyCure";
            this.chkHolyCure.Size = new System.Drawing.Size(57, 19);
            this.chkHolyCure.TabIndex = 137;
            this.chkHolyCure.Text = "디각";
            this.chkHolyCure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkHolyCure.UseVisualStyleBackColor = true;
            // 
            // chkDePrava
            // 
            this.chkDePrava.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkDePrava.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkDePrava.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkDePrava.Location = new System.Drawing.Point(71, 45);
            this.chkDePrava.Margin = new System.Windows.Forms.Padding(1);
            this.chkDePrava.Name = "chkDePrava";
            this.chkDePrava.Size = new System.Drawing.Size(57, 19);
            this.chkDePrava.TabIndex = 136;
            this.chkDePrava.Text = "디프";
            this.chkDePrava.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkDePrava.UseVisualStyleBackColor = true;
            // 
            // chkDeRento
            // 
            this.chkDeRento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkDeRento.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkDeRento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkDeRento.Location = new System.Drawing.Point(5, 109);
            this.chkDeRento.Margin = new System.Windows.Forms.Padding(1);
            this.chkDeRento.Name = "chkDeRento";
            this.chkDeRento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkDeRento.Size = new System.Drawing.Size(57, 19);
            this.chkDeRento.TabIndex = 130;
            this.chkDeRento.Text = "디렌";
            this.chkDeRento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkDeRento.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox2);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage6.Size = new System.Drawing.Size(475, 237);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "자보";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk변신);
            this.groupBox2.Controls.Add(this.chk힐);
            this.groupBox2.Controls.Add(this.tbHeal);
            this.groupBox2.Controls.Add(this.chk디각);
            this.groupBox2.Controls.Add(this.chk디데);
            this.groupBox2.Controls.Add(this.chk라이트닝무브);
            this.groupBox2.Controls.Add(this.chk자동보호);
            this.groupBox2.Controls.Add(this.chk디프);
            this.groupBox2.Controls.Add(this.chk포트);
            this.groupBox2.Controls.Add(this.chk디바);
            this.groupBox2.Controls.Add(this.chk디렌);
            this.groupBox2.Controls.Add(this.chk하이드);
            this.groupBox2.Controls.Add(this.chk쿠랄툼);
            this.groupBox2.Controls.Add(this.chk디베);
            this.groupBox2.Controls.Add(this.chk델리);
            this.groupBox2.Controls.Add(this.chk움);
            this.groupBox2.Controls.Add(this.chk일루);
            this.groupBox2.Controls.Add(this.chk집중);
            this.groupBox2.Controls.Add(this.chk디나);
            this.groupBox2.Controls.Add(this.chk호르);
            this.groupBox2.Controls.Add(this.chk디소);
            this.groupBox2.Controls.Add(this.chk콜라);
            this.groupBox2.Controls.Add(this.chk이모탈);
            this.groupBox2.Controls.Add(this.chk리플);
            this.groupBox2.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(7, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(458, 219);
            this.groupBox2.TabIndex = 136;
            this.groupBox2.TabStop = false;
            // 
            // chk변신
            // 
            this.chk변신.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk변신.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk변신.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk변신.Location = new System.Drawing.Point(141, 106);
            this.chk변신.Margin = new System.Windows.Forms.Padding(1);
            this.chk변신.Name = "chk변신";
            this.chk변신.Size = new System.Drawing.Size(69, 19);
            this.chk변신.TabIndex = 142;
            this.chk변신.Text = "변신";
            this.chk변신.UseVisualStyleBackColor = false;
            // 
            // chk힐
            // 
            this.chk힐.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk힐.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk힐.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk힐.Location = new System.Drawing.Point(274, 24);
            this.chk힐.Margin = new System.Windows.Forms.Padding(1);
            this.chk힐.Name = "chk힐";
            this.chk힐.Size = new System.Drawing.Size(34, 19);
            this.chk힐.TabIndex = 115;
            this.chk힐.Text = "힐";
            this.chk힐.UseVisualStyleBackColor = false;
            // 
            // tbHeal
            // 
            this.tbHeal.AutoSize = false;
            this.tbHeal.BackColor = System.Drawing.SystemColors.Control;
            this.tbHeal.Location = new System.Drawing.Point(311, 24);
            this.tbHeal.Margin = new System.Windows.Forms.Padding(1);
            this.tbHeal.Maximum = 100;
            this.tbHeal.Name = "tbHeal";
            this.tbHeal.Size = new System.Drawing.Size(91, 19);
            this.tbHeal.TabIndex = 117;
            this.tbHeal.TickFrequency = 10;
            this.tbHeal.Value = 90;
            this.tbHeal.Scroll += new System.EventHandler(this.tbHeal_Scroll);
            // 
            // chk디각
            // 
            this.chk디각.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk디각.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk디각.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk디각.Location = new System.Drawing.Point(203, 66);
            this.chk디각.Margin = new System.Windows.Forms.Padding(1);
            this.chk디각.Name = "chk디각";
            this.chk디각.Size = new System.Drawing.Size(69, 19);
            this.chk디각.TabIndex = 142;
            this.chk디각.Text = "디각";
            this.chk디각.UseVisualStyleBackColor = false;
            // 
            // chk디데
            // 
            this.chk디데.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk디데.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk디데.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk디데.Location = new System.Drawing.Point(203, 24);
            this.chk디데.Margin = new System.Windows.Forms.Padding(1);
            this.chk디데.Name = "chk디데";
            this.chk디데.Size = new System.Drawing.Size(69, 19);
            this.chk디데.TabIndex = 138;
            this.chk디데.Text = "디데";
            this.chk디데.UseVisualStyleBackColor = false;
            // 
            // chk라이트닝무브
            // 
            this.chk라이트닝무브.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk라이트닝무브.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk라이트닝무브.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk라이트닝무브.Location = new System.Drawing.Point(70, 85);
            this.chk라이트닝무브.Margin = new System.Windows.Forms.Padding(1);
            this.chk라이트닝무브.Name = "chk라이트닝무브";
            this.chk라이트닝무브.Size = new System.Drawing.Size(69, 19);
            this.chk라이트닝무브.TabIndex = 136;
            this.chk라이트닝무브.Text = "라이트닝무브";
            this.chk라이트닝무브.UseVisualStyleBackColor = false;
            // 
            // chk자동보호
            // 
            this.chk자동보호.AutoSize = true;
            this.chk자동보호.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk자동보호.Location = new System.Drawing.Point(5, 0);
            this.chk자동보호.Margin = new System.Windows.Forms.Padding(1);
            this.chk자동보호.Name = "chk자동보호";
            this.chk자동보호.Size = new System.Drawing.Size(85, 18);
            this.chk자동보호.TabIndex = 1;
            this.chk자동보호.Text = "자보사용";
            this.chk자동보호.UseVisualStyleBackColor = true;
            this.chk자동보호.CheckedChanged += new System.EventHandler(this.chk자동보호_CheckedChanged);
            // 
            // chk디프
            // 
            this.chk디프.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk디프.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk디프.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk디프.Location = new System.Drawing.Point(203, 45);
            this.chk디프.Margin = new System.Windows.Forms.Padding(1);
            this.chk디프.Name = "chk디프";
            this.chk디프.Size = new System.Drawing.Size(69, 19);
            this.chk디프.TabIndex = 139;
            this.chk디프.Text = "디프";
            this.chk디프.UseVisualStyleBackColor = false;
            // 
            // chk포트
            // 
            this.chk포트.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk포트.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk포트.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk포트.Location = new System.Drawing.Point(5, 24);
            this.chk포트.Margin = new System.Windows.Forms.Padding(1);
            this.chk포트.Name = "chk포트";
            this.chk포트.Size = new System.Drawing.Size(57, 19);
            this.chk포트.TabIndex = 120;
            this.chk포트.Text = "포트";
            this.chk포트.UseVisualStyleBackColor = false;
            // 
            // chk디바
            // 
            this.chk디바.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk디바.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk디바.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk디바.Location = new System.Drawing.Point(70, 149);
            this.chk디바.Margin = new System.Windows.Forms.Padding(1);
            this.chk디바.Name = "chk디바";
            this.chk디바.Size = new System.Drawing.Size(69, 19);
            this.chk디바.TabIndex = 140;
            this.chk디바.Text = "디바";
            this.chk디바.UseVisualStyleBackColor = false;
            // 
            // chk디렌
            // 
            this.chk디렌.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk디렌.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk디렌.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk디렌.Location = new System.Drawing.Point(70, 128);
            this.chk디렌.Margin = new System.Windows.Forms.Padding(1);
            this.chk디렌.Name = "chk디렌";
            this.chk디렌.Size = new System.Drawing.Size(69, 19);
            this.chk디렌.TabIndex = 141;
            this.chk디렌.Text = "디렌";
            this.chk디렌.UseVisualStyleBackColor = false;
            // 
            // chk하이드
            // 
            this.chk하이드.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk하이드.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk하이드.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk하이드.Location = new System.Drawing.Point(70, 42);
            this.chk하이드.Margin = new System.Windows.Forms.Padding(1);
            this.chk하이드.Name = "chk하이드";
            this.chk하이드.Size = new System.Drawing.Size(69, 19);
            this.chk하이드.TabIndex = 118;
            this.chk하이드.Text = "하이드";
            this.chk하이드.UseVisualStyleBackColor = false;
            // 
            // chk쿠랄툼
            // 
            this.chk쿠랄툼.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk쿠랄툼.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk쿠랄툼.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk쿠랄툼.Location = new System.Drawing.Point(70, 64);
            this.chk쿠랄툼.Margin = new System.Windows.Forms.Padding(1);
            this.chk쿠랄툼.Name = "chk쿠랄툼";
            this.chk쿠랄툼.Size = new System.Drawing.Size(69, 19);
            this.chk쿠랄툼.TabIndex = 134;
            this.chk쿠랄툼.Text = "쿠랄툼";
            this.chk쿠랄툼.UseVisualStyleBackColor = false;
            // 
            // chk디베
            // 
            this.chk디베.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk디베.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk디베.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk디베.Location = new System.Drawing.Point(141, 24);
            this.chk디베.Margin = new System.Windows.Forms.Padding(1);
            this.chk디베.Name = "chk디베";
            this.chk디베.Size = new System.Drawing.Size(69, 19);
            this.chk디베.TabIndex = 137;
            this.chk디베.Text = "디베";
            this.chk디베.UseVisualStyleBackColor = false;
            // 
            // chk델리
            // 
            this.chk델리.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk델리.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk델리.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk델리.Location = new System.Drawing.Point(5, 45);
            this.chk델리.Margin = new System.Windows.Forms.Padding(1);
            this.chk델리.Name = "chk델리";
            this.chk델리.Size = new System.Drawing.Size(57, 19);
            this.chk델리.TabIndex = 119;
            this.chk델리.Text = "델리";
            this.chk델리.UseVisualStyleBackColor = false;
            // 
            // chk움
            // 
            this.chk움.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk움.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk움.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk움.Location = new System.Drawing.Point(141, 128);
            this.chk움.Margin = new System.Windows.Forms.Padding(1);
            this.chk움.Name = "chk움";
            this.chk움.Size = new System.Drawing.Size(69, 19);
            this.chk움.TabIndex = 136;
            this.chk움.Text = "움";
            this.chk움.UseVisualStyleBackColor = false;
            // 
            // chk일루
            // 
            this.chk일루.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk일루.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk일루.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk일루.Location = new System.Drawing.Point(141, 45);
            this.chk일루.Margin = new System.Windows.Forms.Padding(1);
            this.chk일루.Name = "chk일루";
            this.chk일루.Size = new System.Drawing.Size(69, 19);
            this.chk일루.TabIndex = 136;
            this.chk일루.Text = "일루";
            this.chk일루.UseVisualStyleBackColor = false;
            // 
            // chk집중
            // 
            this.chk집중.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk집중.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk집중.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk집중.Location = new System.Drawing.Point(70, 24);
            this.chk집중.Margin = new System.Windows.Forms.Padding(1);
            this.chk집중.Name = "chk집중";
            this.chk집중.Size = new System.Drawing.Size(69, 19);
            this.chk집중.TabIndex = 121;
            this.chk집중.Text = "집중";
            this.chk집중.UseVisualStyleBackColor = false;
            // 
            // chk디나
            // 
            this.chk디나.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk디나.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk디나.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk디나.Location = new System.Drawing.Point(5, 151);
            this.chk디나.Margin = new System.Windows.Forms.Padding(1);
            this.chk디나.Name = "chk디나";
            this.chk디나.Size = new System.Drawing.Size(69, 19);
            this.chk디나.TabIndex = 135;
            this.chk디나.Text = "디나";
            this.chk디나.UseVisualStyleBackColor = false;
            // 
            // chk호르
            // 
            this.chk호르.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk호르.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk호르.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk호르.Location = new System.Drawing.Point(5, 109);
            this.chk호르.Margin = new System.Windows.Forms.Padding(1);
            this.chk호르.Name = "chk호르";
            this.chk호르.Size = new System.Drawing.Size(57, 19);
            this.chk호르.TabIndex = 113;
            this.chk호르.Text = "호르";
            this.chk호르.UseVisualStyleBackColor = false;
            // 
            // chk디소
            // 
            this.chk디소.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk디소.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk디소.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk디소.Location = new System.Drawing.Point(5, 130);
            this.chk디소.Margin = new System.Windows.Forms.Padding(1);
            this.chk디소.Name = "chk디소";
            this.chk디소.Size = new System.Drawing.Size(69, 19);
            this.chk디소.TabIndex = 134;
            this.chk디소.Text = "디소";
            this.chk디소.UseVisualStyleBackColor = false;
            // 
            // chk콜라
            // 
            this.chk콜라.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk콜라.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk콜라.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk콜라.Location = new System.Drawing.Point(70, 106);
            this.chk콜라.Margin = new System.Windows.Forms.Padding(1);
            this.chk콜라.Name = "chk콜라";
            this.chk콜라.Size = new System.Drawing.Size(69, 19);
            this.chk콜라.TabIndex = 114;
            this.chk콜라.Text = "콜라";
            this.chk콜라.UseVisualStyleBackColor = false;
            // 
            // chk이모탈
            // 
            this.chk이모탈.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk이모탈.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk이모탈.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk이모탈.Location = new System.Drawing.Point(5, 66);
            this.chk이모탈.Margin = new System.Windows.Forms.Padding(1);
            this.chk이모탈.Name = "chk이모탈";
            this.chk이모탈.Size = new System.Drawing.Size(69, 19);
            this.chk이모탈.TabIndex = 112;
            this.chk이모탈.Text = "이모탈";
            this.chk이모탈.UseVisualStyleBackColor = false;
            // 
            // chk리플
            // 
            this.chk리플.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk리플.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk리플.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk리플.Location = new System.Drawing.Point(5, 88);
            this.chk리플.Margin = new System.Windows.Forms.Padding(1);
            this.chk리플.Name = "chk리플";
            this.chk리플.Size = new System.Drawing.Size(57, 19);
            this.chk리플.TabIndex = 116;
            this.chk리플.Text = "리플";
            this.chk리플.UseVisualStyleBackColor = false;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.groupBox10);
            this.tabPage8.Controls.Add(this.groupBox9);
            this.tabPage8.Location = new System.Drawing.Point(4, 25);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage8.Size = new System.Drawing.Size(475, 237);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "저주";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label2);
            this.groupBox10.Controls.Add(this.trackBar4);
            this.groupBox10.Controls.Add(this.chk자동렌토);
            this.groupBox10.Controls.Add(this.chk무딜);
            this.groupBox10.Location = new System.Drawing.Point(182, 8);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox10.Size = new System.Drawing.Size(283, 219);
            this.groupBox10.TabIndex = 143;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "세부설정";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 147;
            this.label2.Text = "인식범위";
            // 
            // trackBar4
            // 
            this.trackBar4.AutoSize = false;
            this.trackBar4.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar4.LargeChange = 10;
            this.trackBar4.Location = new System.Drawing.Point(91, 44);
            this.trackBar4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(91, 19);
            this.trackBar4.TabIndex = 146;
            this.trackBar4.Value = 10;
            // 
            // chk자동렌토
            // 
            this.chk자동렌토.AutoSize = true;
            this.chk자동렌토.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk자동렌토.Location = new System.Drawing.Point(9, 82);
            this.chk자동렌토.Margin = new System.Windows.Forms.Padding(0);
            this.chk자동렌토.Name = "chk자동렌토";
            this.chk자동렌토.Size = new System.Drawing.Size(139, 18);
            this.chk자동렌토.TabIndex = 141;
            this.chk자동렌토.Text = "자동렌토(꼬장용)";
            this.chk자동렌토.UseVisualStyleBackColor = true;
            // 
            // chk무딜
            // 
            this.chk무딜.AutoSize = true;
            this.chk무딜.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk무딜.Location = new System.Drawing.Point(7, 25);
            this.chk무딜.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk무딜.Name = "chk무딜";
            this.chk무딜.Size = new System.Drawing.Size(57, 18);
            this.chk무딜.TabIndex = 136;
            this.chk무딜.Text = "무딜";
            this.chk무딜.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.chk저주);
            this.groupBox9.Controls.Add(this.chk프라);
            this.groupBox9.Controls.Add(this.chk자동바르도);
            this.groupBox9.Controls.Add(this.chk리베);
            this.groupBox9.Controls.Add(this.chk자동데프);
            this.groupBox9.Controls.Add(this.chk자동베노미);
            this.groupBox9.Controls.Add(this.chk나르);
            this.groupBox9.Controls.Add(this.chk자동소루);
            this.groupBox9.Controls.Add(this.chkSeo);
            this.groupBox9.Controls.Add(this.chk기공콘푸);
            this.groupBox9.Location = new System.Drawing.Point(7, 8);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox9.Size = new System.Drawing.Size(168, 219);
            this.groupBox9.TabIndex = 142;
            this.groupBox9.TabStop = false;
            // 
            // chk저주
            // 
            this.chk저주.AutoSize = true;
            this.chk저주.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk저주.Location = new System.Drawing.Point(7, 0);
            this.chk저주.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk저주.Name = "chk저주";
            this.chk저주.Size = new System.Drawing.Size(85, 18);
            this.chk저주.TabIndex = 142;
            this.chk저주.Text = "저주사용";
            this.chk저주.UseVisualStyleBackColor = true;
            this.chk저주.CheckedChanged += new System.EventHandler(this.chk저주_CheckedChanged);
            // 
            // chk프라
            // 
            this.chk프라.AutoSize = true;
            this.chk프라.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk프라.Location = new System.Drawing.Point(7, 26);
            this.chk프라.Margin = new System.Windows.Forms.Padding(0);
            this.chk프라.Name = "chk프라";
            this.chk프라.Size = new System.Drawing.Size(85, 18);
            this.chk프라.TabIndex = 136;
            this.chk프라.Text = "자동프라";
            this.chk프라.UseVisualStyleBackColor = true;
            // 
            // chk자동바르도
            // 
            this.chk자동바르도.AutoSize = true;
            this.chk자동바르도.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk자동바르도.Location = new System.Drawing.Point(7, 64);
            this.chk자동바르도.Margin = new System.Windows.Forms.Padding(0);
            this.chk자동바르도.Name = "chk자동바르도";
            this.chk자동바르도.Size = new System.Drawing.Size(85, 18);
            this.chk자동바르도.TabIndex = 141;
            this.chk자동바르도.Text = "자동발도";
            this.chk자동바르도.UseVisualStyleBackColor = true;
            // 
            // chk리베
            // 
            this.chk리베.AutoSize = true;
            this.chk리베.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk리베.Location = new System.Drawing.Point(7, 139);
            this.chk리베.Margin = new System.Windows.Forms.Padding(0);
            this.chk리베.Name = "chk리베";
            this.chk리베.Size = new System.Drawing.Size(85, 18);
            this.chk리베.TabIndex = 139;
            this.chk리베.Text = "자동리베";
            this.chk리베.UseVisualStyleBackColor = true;
            // 
            // chk자동데프
            // 
            this.chk자동데프.AutoSize = true;
            this.chk자동데프.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk자동데프.Location = new System.Drawing.Point(7, 45);
            this.chk자동데프.Margin = new System.Windows.Forms.Padding(0);
            this.chk자동데프.Name = "chk자동데프";
            this.chk자동데프.Size = new System.Drawing.Size(85, 18);
            this.chk자동데프.TabIndex = 140;
            this.chk자동데프.Text = "자동데프";
            this.chk자동데프.UseVisualStyleBackColor = true;
            // 
            // chk자동베노미
            // 
            this.chk자동베노미.AutoSize = true;
            this.chk자동베노미.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk자동베노미.Location = new System.Drawing.Point(7, 101);
            this.chk자동베노미.Margin = new System.Windows.Forms.Padding(0);
            this.chk자동베노미.Name = "chk자동베노미";
            this.chk자동베노미.Size = new System.Drawing.Size(99, 18);
            this.chk자동베노미.TabIndex = 137;
            this.chk자동베노미.Text = "자동베노미";
            this.chk자동베노미.UseVisualStyleBackColor = true;
            // 
            // chk나르
            // 
            this.chk나르.AutoSize = true;
            this.chk나르.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk나르.Location = new System.Drawing.Point(7, 82);
            this.chk나르.Margin = new System.Windows.Forms.Padding(0);
            this.chk나르.Name = "chk나르";
            this.chk나르.Size = new System.Drawing.Size(85, 18);
            this.chk나르.TabIndex = 137;
            this.chk나르.Text = "자동나르";
            this.chk나르.UseVisualStyleBackColor = true;
            // 
            // chk자동소루
            // 
            this.chk자동소루.AutoSize = true;
            this.chk자동소루.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk자동소루.Location = new System.Drawing.Point(7, 120);
            this.chk자동소루.Margin = new System.Windows.Forms.Padding(0);
            this.chk자동소루.Name = "chk자동소루";
            this.chk자동소루.Size = new System.Drawing.Size(85, 18);
            this.chk자동소루.TabIndex = 138;
            this.chk자동소루.Text = "자동소루";
            this.chk자동소루.UseVisualStyleBackColor = true;
            // 
            // chkSeo
            // 
            this.chkSeo.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkSeo.Location = new System.Drawing.Point(7, 158);
            this.chkSeo.Margin = new System.Windows.Forms.Padding(0);
            this.chkSeo.Name = "chkSeo";
            this.chkSeo.Size = new System.Drawing.Size(78, 19);
            this.chkSeo.TabIndex = 139;
            this.chkSeo.Text = "자동세오";
            this.chkSeo.UseVisualStyleBackColor = true;
            // 
            // chk기공콘푸
            // 
            this.chk기공콘푸.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk기공콘푸.Location = new System.Drawing.Point(7, 176);
            this.chk기공콘푸.Margin = new System.Windows.Forms.Padding(0);
            this.chk기공콘푸.Name = "chk기공콘푸";
            this.chk기공콘푸.Size = new System.Drawing.Size(78, 19);
            this.chk기공콘푸.TabIndex = 139;
            this.chk기공콘푸.Text = "기공콘푸";
            this.chk기공콘푸.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkDEX);
            this.tabPage3.Controls.Add(this.chkWIS);
            this.tabPage3.Controls.Add(this.chkINT);
            this.tabPage3.Controls.Add(this.chkCON);
            this.tabPage3.Controls.Add(this.chkSTR);
            this.tabPage3.Controls.Add(this.chkPoint);
            this.tabPage3.Controls.Add(this.chk밀신경팔체);
            this.tabPage3.Controls.Add(this.chk밀신경팔마);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(475, 237);
            this.tabPage3.TabIndex = 8;
            this.tabPage3.Text = "밀신";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkDEX
            // 
            this.chkDEX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkDEX.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkDEX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkDEX.Location = new System.Drawing.Point(27, 201);
            this.chkDEX.Margin = new System.Windows.Forms.Padding(1);
            this.chkDEX.Name = "chkDEX";
            this.chkDEX.Size = new System.Drawing.Size(79, 20);
            this.chkDEX.TabIndex = 1004;
            this.chkDEX.Text = "DEX";
            this.chkDEX.UseVisualStyleBackColor = false;
            // 
            // chkWIS
            // 
            this.chkWIS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkWIS.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkWIS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkWIS.Location = new System.Drawing.Point(27, 156);
            this.chkWIS.Margin = new System.Windows.Forms.Padding(1);
            this.chkWIS.Name = "chkWIS";
            this.chkWIS.Size = new System.Drawing.Size(79, 20);
            this.chkWIS.TabIndex = 1003;
            this.chkWIS.Text = "WIS";
            this.chkWIS.UseVisualStyleBackColor = false;
            // 
            // chkINT
            // 
            this.chkINT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkINT.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkINT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkINT.Location = new System.Drawing.Point(27, 179);
            this.chkINT.Margin = new System.Windows.Forms.Padding(1);
            this.chkINT.Name = "chkINT";
            this.chkINT.Size = new System.Drawing.Size(79, 20);
            this.chkINT.TabIndex = 1002;
            this.chkINT.Text = "INT";
            this.chkINT.UseVisualStyleBackColor = false;
            // 
            // chkCON
            // 
            this.chkCON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkCON.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkCON.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkCON.Location = new System.Drawing.Point(27, 134);
            this.chkCON.Margin = new System.Windows.Forms.Padding(1);
            this.chkCON.Name = "chkCON";
            this.chkCON.Size = new System.Drawing.Size(79, 20);
            this.chkCON.TabIndex = 1001;
            this.chkCON.Text = "CON";
            this.chkCON.UseVisualStyleBackColor = false;
            // 
            // chkSTR
            // 
            this.chkSTR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkSTR.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkSTR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkSTR.Location = new System.Drawing.Point(27, 111);
            this.chkSTR.Margin = new System.Windows.Forms.Padding(1);
            this.chkSTR.Name = "chkSTR";
            this.chkSTR.Size = new System.Drawing.Size(79, 20);
            this.chkSTR.TabIndex = 1000;
            this.chkSTR.Text = "STR";
            this.chkSTR.UseVisualStyleBackColor = false;
            // 
            // chkPoint
            // 
            this.chkPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkPoint.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkPoint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkPoint.Location = new System.Drawing.Point(6, 89);
            this.chkPoint.Margin = new System.Windows.Forms.Padding(1);
            this.chkPoint.Name = "chkPoint";
            this.chkPoint.Size = new System.Drawing.Size(79, 20);
            this.chkPoint.TabIndex = 999;
            this.chkPoint.Text = "포인트";
            this.chkPoint.UseVisualStyleBackColor = false;
            // 
            // chk밀신경팔체
            // 
            this.chk밀신경팔체.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk밀신경팔체.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk밀신경팔체.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk밀신경팔체.Location = new System.Drawing.Point(6, 5);
            this.chk밀신경팔체.Margin = new System.Windows.Forms.Padding(1);
            this.chk밀신경팔체.Name = "chk밀신경팔체";
            this.chk밀신경팔체.Size = new System.Drawing.Size(79, 20);
            this.chk밀신경팔체.TabIndex = 997;
            this.chk밀신경팔체.Text = "밀신경체";
            this.chk밀신경팔체.UseVisualStyleBackColor = false;
            this.chk밀신경팔체.CheckedChanged += new System.EventHandler(this.chk밀경팔체_CheckedChanged);
            // 
            // chk밀신경팔마
            // 
            this.chk밀신경팔마.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chk밀신경팔마.Font = new System.Drawing.Font("Dotum", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk밀신경팔마.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chk밀신경팔마.Location = new System.Drawing.Point(6, 26);
            this.chk밀신경팔마.Margin = new System.Windows.Forms.Padding(1);
            this.chk밀신경팔마.Name = "chk밀신경팔마";
            this.chk밀신경팔마.Size = new System.Drawing.Size(79, 20);
            this.chk밀신경팔마.TabIndex = 998;
            this.chk밀신경팔마.Text = "밀신경마";
            this.chk밀신경팔마.UseVisualStyleBackColor = false;
            this.chk밀신경팔마.CheckedChanged += new System.EventHandler(this.chk밀경팔마_CheckedChanged);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.chk밀트4);
            this.tabPage7.Controls.Add(this.chk밀트3);
            this.tabPage7.Controls.Add(this.chk밀트2);
            this.tabPage7.Controls.Add(this.chk밀트1);
            this.tabPage7.Controls.Add(this.chk맵이동);
            this.tabPage7.Controls.Add(this.check갬유);
            this.tabPage7.Controls.Add(this.check블랙);
            this.tabPage7.Controls.Add(this.check레드);
            this.tabPage7.Controls.Add(this.check블루);
            this.tabPage7.Controls.Add(this.field층);
            this.tabPage7.Controls.Add(this.tb층);
            this.tabPage7.Controls.Add(this.check브론);
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage7.Size = new System.Drawing.Size(475, 237);
            this.tabPage7.TabIndex = 9;
            this.tabPage7.Text = "자동이동";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // chk밀트1
            // 
            this.chk밀트1.AutoSize = true;
            this.chk밀트1.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk밀트1.Location = new System.Drawing.Point(165, 59);
            this.chk밀트1.Margin = new System.Windows.Forms.Padding(1);
            this.chk밀트1.Name = "chk밀트1";
            this.chk밀트1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk밀트1.Size = new System.Drawing.Size(65, 18);
            this.chk밀트1.TabIndex = 188;
            this.chk밀트1.Text = "밀트1";
            this.chk밀트1.UseVisualStyleBackColor = true;
            this.chk밀트1.CheckedChanged += new System.EventHandler(this.chk밀트1_CheckedChanged);
            // 
            // chk맵이동
            // 
            this.chk맵이동.AutoSize = true;
            this.chk맵이동.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk맵이동.Location = new System.Drawing.Point(21, 18);
            this.chk맵이동.Margin = new System.Windows.Forms.Padding(1);
            this.chk맵이동.Name = "chk맵이동";
            this.chk맵이동.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk맵이동.Size = new System.Drawing.Size(71, 18);
            this.chk맵이동.TabIndex = 187;
            this.chk맵이동.Text = "맵이동";
            this.chk맵이동.UseVisualStyleBackColor = true;
            this.chk맵이동.CheckedChanged += new System.EventHandler(this.chk자동이동_CheckedChanged);
            // 
            // check갬유
            // 
            this.check갬유.AutoSize = true;
            this.check갬유.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.check갬유.Location = new System.Drawing.Point(94, 59);
            this.check갬유.Margin = new System.Windows.Forms.Padding(1);
            this.check갬유.Name = "check갬유";
            this.check갬유.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.check갬유.Size = new System.Drawing.Size(57, 18);
            this.check갬유.TabIndex = 186;
            this.check갬유.Text = "갬유";
            this.check갬유.UseVisualStyleBackColor = true;
            // 
            // check블랙
            // 
            this.check블랙.AutoSize = true;
            this.check블랙.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.check블랙.Location = new System.Drawing.Point(21, 122);
            this.check블랙.Margin = new System.Windows.Forms.Padding(1);
            this.check블랙.Name = "check블랙";
            this.check블랙.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.check블랙.Size = new System.Drawing.Size(57, 18);
            this.check블랙.TabIndex = 185;
            this.check블랙.Text = "블랙";
            this.check블랙.UseVisualStyleBackColor = true;
            // 
            // check레드
            // 
            this.check레드.AutoSize = true;
            this.check레드.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.check레드.Location = new System.Drawing.Point(21, 101);
            this.check레드.Margin = new System.Windows.Forms.Padding(1);
            this.check레드.Name = "check레드";
            this.check레드.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.check레드.Size = new System.Drawing.Size(57, 18);
            this.check레드.TabIndex = 184;
            this.check레드.Text = "레드";
            this.check레드.UseVisualStyleBackColor = true;
            // 
            // check블루
            // 
            this.check블루.AutoSize = true;
            this.check블루.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.check블루.Location = new System.Drawing.Point(21, 80);
            this.check블루.Margin = new System.Windows.Forms.Padding(1);
            this.check블루.Name = "check블루";
            this.check블루.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.check블루.Size = new System.Drawing.Size(57, 18);
            this.check블루.TabIndex = 183;
            this.check블루.Text = "블루";
            this.check블루.UseVisualStyleBackColor = true;
            // 
            // field층
            // 
            this.field층.AutoSize = true;
            this.field층.Location = new System.Drawing.Point(91, 19);
            this.field층.Name = "field층";
            this.field층.Size = new System.Drawing.Size(32, 15);
            this.field층.TabIndex = 182;
            this.field층.Text = "층 :";
            // 
            // tb층
            // 
            this.tb층.Location = new System.Drawing.Point(127, 12);
            this.tb층.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb층.Name = "tb층";
            this.tb층.Size = new System.Drawing.Size(49, 25);
            this.tb층.TabIndex = 181;
            // 
            // check브론
            // 
            this.check브론.AutoSize = true;
            this.check브론.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.check브론.Location = new System.Drawing.Point(21, 59);
            this.check브론.Margin = new System.Windows.Forms.Padding(1);
            this.check브론.Name = "check브론";
            this.check브론.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.check브론.Size = new System.Drawing.Size(57, 18);
            this.check브론.TabIndex = 180;
            this.check브론.Text = "브론";
            this.check브론.UseVisualStyleBackColor = true;
            // 
            // chk밀트2
            // 
            this.chk밀트2.AutoSize = true;
            this.chk밀트2.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk밀트2.Location = new System.Drawing.Point(165, 79);
            this.chk밀트2.Margin = new System.Windows.Forms.Padding(1);
            this.chk밀트2.Name = "chk밀트2";
            this.chk밀트2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk밀트2.Size = new System.Drawing.Size(65, 18);
            this.chk밀트2.TabIndex = 189;
            this.chk밀트2.Text = "밀트2";
            this.chk밀트2.UseVisualStyleBackColor = true;
            this.chk밀트2.CheckedChanged += new System.EventHandler(this.chk밀트2_CheckedChanged);
            // 
            // chk밀트3
            // 
            this.chk밀트3.AutoSize = true;
            this.chk밀트3.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk밀트3.Location = new System.Drawing.Point(165, 101);
            this.chk밀트3.Margin = new System.Windows.Forms.Padding(1);
            this.chk밀트3.Name = "chk밀트3";
            this.chk밀트3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk밀트3.Size = new System.Drawing.Size(65, 18);
            this.chk밀트3.TabIndex = 190;
            this.chk밀트3.Text = "밀트3";
            this.chk밀트3.UseVisualStyleBackColor = true;
            this.chk밀트3.CheckedChanged += new System.EventHandler(this.chk밀트3_CheckedChanged);
            // 
            // chk밀트4
            // 
            this.chk밀트4.AutoSize = true;
            this.chk밀트4.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk밀트4.Location = new System.Drawing.Point(165, 122);
            this.chk밀트4.Margin = new System.Windows.Forms.Padding(1);
            this.chk밀트4.Name = "chk밀트4";
            this.chk밀트4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk밀트4.Size = new System.Drawing.Size(65, 18);
            this.chk밀트4.TabIndex = 191;
            this.chk밀트4.Text = "밀트4";
            this.chk밀트4.UseVisualStyleBackColor = true;
            this.chk밀트4.CheckedChanged += new System.EventHandler(this.chk밀트4_CheckedChanged);
            // 
            // FormPatron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(485, 326);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(3, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPatron";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doumi - {0}";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPatron_FormClosing);
            this.Load += new System.EventHandler(this.FormPatron_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGroupHeal)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbHeal)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.ResumeLayout(false);

        }

        public bool isAttachCoord(int x, int y, out List<int[]> attachlist, int range = 1)
        {
            List<int[]> list = new List<int[]>();
            for (int i = 0 - range; i <= range; i++)
            {
                int num2 = 0 - range;
                while (i <= range)
                {
                    if ((!this.Patron.Field.IsSolid(x + i, y + num2) && !this.Patron.Field.IsMonster(x + i, y + num2)) && !this.Patron.Field.IsAisling(x + i, y + num2))
                    {
                        int[] item = new int[] { x, y };
                        list.Add(item);
                    }
                    i++;
                }
            }
            if (list.Count > 0)
            {
                attachlist = list;
                return true;
            }
            attachlist = list;
            return false;
        }

        public bool isAttackable(int x, int y)
        {
            try
            {
                if ((((this.Patron.Field.IsSolid(x + 1, y) || this.Patron.Field.IsMonster(x + 1, y)) || this.Patron.Field.IsAisling(x + 1, y)) && ((this.Patron.Field.IsSolid(x - 1, y) || this.Patron.Field.IsMonster(x - 1, y)) || this.Patron.Field.IsAisling(x - 1, y))) && (((this.Patron.Field.IsSolid(x, y + 1) || this.Patron.Field.IsMonster(x, y + 1)) || this.Patron.Field.IsAisling(x, y + 1)) && ((this.Patron.Field.IsSolid(x, y - 1) || this.Patron.Field.IsMonster(x, y - 1)) || this.Patron.Field.IsAisling(x, y - 1))))
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool isBackPosition(int x1, int y1, int x2, int y2, int face)
        {
            int num = 0;
            int num2 = 0;
            switch (face)
            {
                case 0:
                    num = x2;
                    num2 = y2 + 1;
                    break;

                case 1:
                    num = x2 - 1;
                    num2 = y2;
                    break;

                case 2:
                    num = x2;
                    num2 = y2 - 1;
                    break;

                case 3:
                    num = x2 + 1;
                    num2 = y2;
                    break;
            }
            if ((x1 != num) || (y1 != num2))
            {
                return false;
            }
            return true;
        }

        public bool isDesiredItem(string name)
        {
            foreach (string str in this._desiredItemList)
            {
                if (name.StartsWith(str))
                {
                    return true;
                }
            }
            return false;
        }

        private bool isEnemy(string name)
        {
            foreach (string str in this._enemyList)
            {
                if (name.Equals(str))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isNearPosition(int x1, int y1, int x2, int y2)
        {
            if (((x1 != x2) || ((y1 != (y2 + 1)) && (y1 != (y2 - 1)))) && ((y1 != y2) || ((x1 != (x2 + 1)) && (x1 != (x2 - 1)))))
            {
                return false;
            }
            return true;
        }

        public bool isSafeZone(int x, int y) =>
            (((!this.Patron.Field.IsMonster(x, y) && !this.Patron.Field.IsMonster(x + 1, y)) && ((!this.Patron.Field.IsMonster(x - 1, y) && !this.Patron.Field.IsMonster(x, y + 1)) && !this.Patron.Field.IsMonster(x, y - 1))) || true);

        public bool isTrashItem(string name)
        {
            foreach (string str in this._trashList)
            {
                if (name.StartsWith(str))
                {
                    return true;
                }
            }
            return false;
        }

        public bool NextMap(int cntM)
        {
            Field field = this.Patron.Field;
            string str = null;
            this.Patron.mTeleport.WaitOne();
            switch (cntM)
            {
                case 0:
                    str = "북로톤F구역-2";
                    if (field.Name.EndsWith("북로톤F구역-3"))
                    {
                        this.Patron.MoveByTeleport(this.Patron, 1, 0x10);
                        this.Patron.Walk(3, 0);
                    }
                    break;

                case 1:
                    str = "북로톤F구역-3";
                    if (field.Name.EndsWith("북로톤F구역-2"))
                    {
                        this.Patron.MoveByTeleport(this.Patron, 0x30, 0x1f);
                        this.Patron.Walk(1, 0);
                    }
                    break;
            }
            this.Patron.mTeleport.ReleaseMutex();
            return this.Patron.Field.Name.EndsWith(str);
        }

        private void Patron_CasterEffectReceived(uint guid, ushort effect)
        {
            Aisling aisling;
            Field field = this.Patron.Field;
            if ((((((effect == 0x30) || (effect == 0x41)) || ((effect == 0x120) || (effect == 0x121))) || (((effect == 290) || (effect == 0x12b)) || (effect == 360))) || (effect == 0x12f)) && field.Aislings.TryGetValue(guid, out aisling))
            {
                aisling.HPBar = 0;
            }
        }

        private void Patron_GroupMemberReceived(string name, string area, ushort x, ushort y)
        {
            Field field = this.Patron.Field;
            if (!field.Loaded)
            {
                this.Patron.Refresh();
            }
            else
            {
                Buff buff = new Buff(name)
                {
                    Name = name,
                    X = x,
                    Y = y,
                    Area = area
                };
                this.Patron.mBuffControl.WaitOne();
                this.Patron.BuffNote.AddOrUpdate(name, buff, (key, value) => value.CopyForm(buff));
                this.Patron.mBuffControl.ReleaseMutex();
                if ((((this.Patron.Form != null) && this.chk따라가기.Checked) && (this.tbTarget != null)) && (this.tbTarget.Text == name))
                {
                    if (area == this.Patron.Field.Name)
                    {
                        int num3 = (int)Math.Sqrt(Math.Pow((double)(x - this.Patron.X), 2.0) + Math.Pow((double)(y - this.Patron.Y), 2.0));
                        if ((!this.chk자동사냥.Checked || (num3 > 5)) && (num3 > 2))
                        {
                            ushort num;
                            ushort num2;
                            this.Patron.chooseNearPosition(this.Patron, x, y, -2, 2, out num, out num2);
                            if ((area == field.Name) && ((area == this.Patron.Field.Name) && (this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)") || this.Patron.TryGetStockS("텔리포트의깃털"))))
                            {
                                this.Patron.mTeleport.WaitOne();
                                this.Patron.MoveByTeleport(this.Patron, num, num2);
                                this.Patron.mTeleport.ReleaseMutex();
                            }
                        }
                    }
                    else
                    {
                        this.Patron.mTeleport.WaitOne();
                        Thread.Sleep(500);
                        if (field.Name.Contains("47") && area.StartsWith("48"))
                        {
                            this.Patron.MoveByTeleport(this.Patron, 2, 15);
                            Thread.Sleep(100);
                            this.Patron.Walk(3, 0);
                        }
                        else if (field.Name.Contains("48") && (area.StartsWith("49") || (area.StartsWith("50"))))
                        {
                            this.Patron.MoveByTeleport(this.Patron, 2, 19);
                            Thread.Sleep(100);
                            this.Patron.Walk(0, 0);
                        }
                        else if (field.Name.Contains("49") && (area.StartsWith("50")))
                        {
                            this.Patron.MoveByTeleport(this.Patron, 36, 3);
                            Thread.Sleep(100);
                            this.Patron.Walk(0, 0);
                        }
                        //if (field.Name.StartsWith("루프의캠프") && area.StartsWith("북로톤A구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 7, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("루프의캠프") && area.StartsWith("북로톤B구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 7, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("루프의캠프") && area.StartsWith("북로톤C구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 7, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("루프의캠프") && area.StartsWith("북로톤D구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 7, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("루프의캠프") && area.StartsWith("북로톤E구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 7, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("루프의캠프") && area.StartsWith("북로톤F구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 7, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("루프의캠프") && area.StartsWith("북로톤E구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 7, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤A구역") && area.StartsWith("북로톤B구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x10, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤A구역") && area.StartsWith("북로톤C구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x10, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤A구역") && area.StartsWith("북로톤E구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x10, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤A구역") && area.StartsWith("북로톤F구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x10, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤A구역") && area.StartsWith("북로톤D구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x10, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤A구역") && area.StartsWith("북로톤E구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x10, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤B구역") && area.StartsWith("북로톤C구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x18, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤B구역") && area.StartsWith("북로톤E구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x18, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤B구역") && area.StartsWith("북로톤F구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x18, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤C구역") && area.StartsWith("북로톤D구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 20, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤C구역") && area.StartsWith("북로톤E구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 20, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤C구역") && area.StartsWith("북로톤F구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 20, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역") && area.StartsWith("북로톤E구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1b, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역") && area.StartsWith("북로톤F구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1b, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역") && area.StartsWith("북로톤F구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 20, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤B구역") && area.StartsWith("북로톤D구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x18, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역") && area.StartsWith("북로톤D구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1c, 0x3a);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역") && area.StartsWith("북로톤C구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1c, 0x3a);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역") && area.StartsWith("북로톤B구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1c, 0x3a);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역") && area.StartsWith("북로톤A구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1c, 0x3a);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역") && area.StartsWith("루프의캠프"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1c, 0x3a);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역") && area.StartsWith("북로톤C구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x19, 0x35);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역") && area.StartsWith("북로톤B구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x19, 0x35);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역") && area.StartsWith("북로톤A구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x19, 0x35);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역") && area.StartsWith("루프의캠프"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x19, 0x35);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤C구역") && area.StartsWith("북로톤B구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x16, 0x35);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤C구역") && area.StartsWith("북로톤A구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x16, 0x35);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤C구역") && area.StartsWith("루프의캠프"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x16, 0x35);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤B구역") && area.StartsWith("북로톤A구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1c, 0x3a);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤B구역") && area.StartsWith("루프의캠프"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1c, 0x3a);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤A구역") && area.StartsWith("루프의캠프"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1d, 0x30);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤F구역") && area.StartsWith("북로톤E구역"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1f, 0x3f);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.EndsWith("북로톤B구역-3") && area.EndsWith("북로톤B구역-2"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x11);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("북로톤B구역-3") && area.EndsWith("북로톤B구역-1"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x11);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("북로톤B구역-2") && area.EndsWith("북로톤B구역-1"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x13);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("북로톤B구역-2") && area.EndsWith("북로톤B구역-3"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x12);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("북로톤B구역-1") && area.EndsWith("북로톤B구역-2"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x20);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("북로톤B구역-1") && area.EndsWith("북로톤B구역-3"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x20);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤C구역-1") && area.StartsWith("북로톤C구역-2"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x13);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤C구역-1") && area.StartsWith("북로톤C구역-3"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x13);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤C구역-2") && area.StartsWith("북로톤C구역-3"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x1c);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤C구역-2") && area.StartsWith("북로톤C구역-1"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x11);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤C구역-3") && area.StartsWith("북로톤C구역-2"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x15);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤C구역-3") && area.StartsWith("북로톤C구역-1"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x15);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-1") && area.StartsWith("북로톤D구역-2"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x1c);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-1") && area.StartsWith("북로톤D구역-3"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x1c);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-1") && area.StartsWith("북로톤D구역-4"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x1c);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-1") && area.StartsWith("북로톤D구역-5"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x1c);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-2") && area.StartsWith("북로톤D구역-1"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x15);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-2") && area.StartsWith("북로톤D구역-3"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x35, 0x1b);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-2") && area.StartsWith("북로톤D구역-4"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x35, 0x1b);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-2") && area.StartsWith("북로톤D구역-5"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x35, 0x1b);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-3") && area.StartsWith("북로톤D구역-1"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x16);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-3") && area.StartsWith("북로톤D구역-2"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x16);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-3") && area.StartsWith("북로톤D구역-4"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x35, 0x11);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-3") && area.StartsWith("북로톤D구역-5"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x35, 0x11);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-4") && area.StartsWith("북로톤D구역-5"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x35, 0x22);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-4") && area.StartsWith("북로톤D구역-3"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x1c);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-4") && area.StartsWith("북로톤D구역-2"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x1c);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-4") && area.StartsWith("북로톤D구역-1"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x1c);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-5") && area.StartsWith("북로톤D구역-1"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x15);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-5") && area.StartsWith("북로톤D구역-2"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x15);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-5") && area.StartsWith("북로톤D구역-3"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x15);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤D구역-5") && area.StartsWith("북로톤D구역-4"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x15);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-1") && area.StartsWith("북로톤E구역-2"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x13);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-1") && area.StartsWith("북로톤E구역-3"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x13);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-1") && area.StartsWith("북로톤E구역-4"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x13);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-1") && area.StartsWith("북로톤E구역-5"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x13);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-2") && area.StartsWith("북로톤E구역-1"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 20);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-2") && area.StartsWith("북로톤E구역-3"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x3a, 0x1b);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-2") && area.StartsWith("북로톤E구역-4"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x3a, 0x1b);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-2") && area.StartsWith("북로톤E구역-5"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x3a, 0x1b);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-3") && area.StartsWith("북로톤E구역-1"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 14);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-3") && area.StartsWith("북로톤E구역-2"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 14);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-3") && area.StartsWith("북로톤E구역-4"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x3a, 0x12);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-3") && area.StartsWith("북로톤E구역-5"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x3a, 0x12);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-4") && area.StartsWith("북로톤E구역-1"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x12);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-4") && area.StartsWith("북로톤E구역-2"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x12);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-4") && area.StartsWith("북로톤E구역-3"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x12);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-4") && area.StartsWith("북로톤E구역-5"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x3a, 0x1d);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-5") && area.StartsWith("북로톤E구역-4"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x1b);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-5") && area.StartsWith("북로톤E구역-3"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x1b);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-5") && area.StartsWith("북로톤E구역-2"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x1b);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-5") && area.StartsWith("북로톤E구역-1"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x1b);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-4") && area.StartsWith("북로톤E구역-3"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x12);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-3") && area.StartsWith("북로톤E구역-2"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 14);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤E구역-2") && area.StartsWith("북로톤E구역-1"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 20);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤F구역-3") && area.StartsWith("북로톤F구역-2"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x10);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.StartsWith("북로톤F구역-2") && area.StartsWith("북로톤F구역-3"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x30, 0x1f);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("오피온의굴27") && area.EndsWith("오피온의굴28"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 5, 0x30);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.EndsWith("오피온의굴28") && area.EndsWith("오피온의굴29"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 1, 0x3d);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("오피온의굴29") && area.EndsWith("오피온의굴28"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x44, 0x11);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("오피온의굴28") && area.EndsWith("오피온의굴27"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x21, 1);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르93") && area.EndsWith("엔도르94"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 15, 2);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르93") && area.EndsWith("엔도르98"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 15, 2);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르94") && area.EndsWith("엔도르98"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 2, 6);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르94") && area.EndsWith("엔도르97"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 2, 6);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르98") && area.EndsWith("엔도르97"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x13, 0x1d);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르98") && area.EndsWith("엔도르93"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x13, 0x1d);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르97") && area.EndsWith("엔도르93"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x25, 0x13);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르97") && area.EndsWith("엔도르94"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x25, 0x13);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르120") && area.EndsWith("엔도르121"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x16, 2);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르120") && area.EndsWith("엔도르128"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x16, 2);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르121") && area.EndsWith("엔도르128"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 2, 7);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르121") && area.EndsWith("엔도르120"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x11, 0x1c);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르128") && area.EndsWith("엔도르121"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1d, 0x10);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르104") && area.EndsWith("엔도르99"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1d, 11);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르104") && area.EndsWith("엔도르109"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 2, 15);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르99") && area.EndsWith("엔도르104"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 2, 15);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르99") && area.EndsWith("엔도르109"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 2, 15);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르109") && area.EndsWith("엔도르104"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1d, 0x10);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르109") && area.EndsWith("엔도르99"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1d, 0x10);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르123") && area.EndsWith("엔도르124"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x17, 2);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르123") && area.EndsWith("엔도르132"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 2, 0x17);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르123") && area.EndsWith("엔도르133"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x17, 2);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르132") && area.EndsWith("엔도르124"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1c, 15);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르132") && area.EndsWith("엔도르123"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1c, 15);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르132") && area.EndsWith("엔도르133"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1c, 15);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르124") && area.EndsWith("엔도르123"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x10, 0x1d);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르124") && area.EndsWith("엔도르132"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x10, 0x1d);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르124") && area.EndsWith("엔도르133"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 2, 0x16);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르133") && area.EndsWith("엔도르124"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1d, 15);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르133") && area.EndsWith("엔도르123"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1d, 15);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르133") && area.EndsWith("엔도르132"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1d, 15);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르110") && area.EndsWith("엔도르111"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x16, 2);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르110") && area.EndsWith("엔도르117"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x16, 2);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르110") && area.EndsWith("엔도르125"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x16, 2);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르111") && area.EndsWith("엔도르110"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x11, 0x1c);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르111") && area.EndsWith("엔도르117"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 2, 7);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르111") && area.EndsWith("엔도르125"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 2, 7);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르117") && area.EndsWith("엔도르111"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1d, 0x10);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르117") && area.EndsWith("엔도르110"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1d, 0x10);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르117") && area.EndsWith("엔도르125"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 2, 0x17);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르125") && area.EndsWith("엔도르117"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1d, 9);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르125") && area.EndsWith("엔도르111"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1d, 9);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르125") && area.EndsWith("엔도르110"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x1d, 9);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르142") && area.EndsWith("엔도르141"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x12, 0x1d);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르141") && area.EndsWith("엔도르142"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x16, 2);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르131") && area.EndsWith("엔도르138"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 2, 7);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르131") && area.EndsWith("엔도르139"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 2, 7);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르131") && area.EndsWith("엔도르147"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 2, 7);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르138") && area.EndsWith("엔도르131"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x25, 20);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르138") && area.EndsWith("엔도르139"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 14, 2);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르138") && area.EndsWith("엔도르147"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 14, 2);
                        //    this.Patron.Walk(0, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르139") && area.EndsWith("엔도르131"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 15, 0x1d);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르139") && area.EndsWith("엔도르138"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 15, 0x1d);
                        //    this.Patron.Walk(2, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르139") && area.EndsWith("엔도르147"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 2, 0x16);
                        //    this.Patron.Walk(3, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르147") && area.EndsWith("엔도르139"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x25, 0x12);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르147") && area.EndsWith("엔도르138"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x25, 0x12);
                        //    this.Patron.Walk(1, 0);
                        //}
                        //if (field.Name.EndsWith("엔도르147") && area.EndsWith("엔도르131"))
                        //{
                        //    this.Patron.MoveByTeleport(this.Patron, 0x25, 0x12);
                        //    this.Patron.Walk(1, 0);
                        //}
                        this.Patron.mTeleport.ReleaseMutex();
                    }
                }
            }
        }

        private void Patron_ServerMessageReceived(string text)
        {
            SenseMonster monster = new SenseMonster(text);
            if (monster.IsValid)
            {
                string offense = monster.Offense;
                string defense = monster.Defense;
                if (defense != null)
                {
                    string s = defense;
                    switch (PrivateImplementationDetails.ComputeStringHash(s))
                    {
                        case 0x385159fb:
                            if (s == "물")
                            {
                                this.Patron.UseStock("대지", "목걸이");
                                break;
                            }
                            break;

                        case 0x7d737d56:
                            if (s == "암흑")
                            {
                                this.Patron.UseStock("생명", "목걸이");
                                break;
                            }
                            break;

                        case 0x18683b1:
                            if (s == "번개")
                            {
                                if (!this.Patron.UseStock("강철", "목걸이"))
                                {
                                    this.Patron.UseStock("화염", "목걸이");
                                }
                                break;
                            }
                            break;

                        case 0xc658bb7:
                            if (s == "금")
                            {
                                this.Patron.UseStock("바다", "목걸이");
                                break;
                            }
                            break;

                        case 0x8414880a:
                            if (s == "신성")
                            {
                                this.Patron.UseStock("암흑", "목걸이");
                                break;
                            }
                            break;

                        case 0x8c46d937:
                            if (s == "불")
                            {
                                this.Patron.UseStock("바다", "목걸이");
                                break;
                            }
                            break;

                        case 0xab520f04:
                            if (s == "목")
                            {
                                if (!this.Patron.UseStock("강철", "목걸이"))
                                {
                                    this.Patron.UseStock("화염", "목걸이");
                                }
                                break;
                            }
                            break;

                        case 0xbf53c180:
                            if (s == "땅")
                            {
                                if (!this.Patron.UseStock("숲", "목걸이"))
                                {
                                    this.Patron.UseStock("바람", "목걸이");
                                }
                                break;
                            }
                            break;
                    }
                }
                if (offense != null)
                {
                    string s = offense;
                    switch (PrivateImplementationDetails.ComputeStringHash(s))
                    {
                        case 0x385159fb:
                            if (s == "물")
                            {
                                this.Patron.UseStock("바다", "벨트");
                                break;
                            }
                            break;

                        case 0x7d737d56:
                            if (s == "암흑")
                            {
                                this.Patron.UseStock("암흑", "벨트");
                                break;
                            }
                            break;

                        case 0x18683b1:
                            if (s == "번개")
                            {
                                this.Patron.UseStock("바람", "벨트");
                                break;
                            }
                            break;

                        case 0xc658bb7:
                            if (s == "금")
                            {
                                this.Patron.UseStock("바다", "벨트");
                                break;
                            }
                            break;

                        case 0x8414880a:
                            if (s == "신성")
                            {
                                this.Patron.UseStock("생명", "벨트");
                                break;
                            }
                            break;

                        case 0x8c46d937:
                            if (s == "불")
                            {
                                this.Patron.UseStock("화염", "벨트");
                                break;
                            }
                            break;

                        case 0xab520f04:
                            if (s == "목")
                            {
                                this.Patron.UseStock("바람", "벨트");
                                break;
                            }
                            break;

                        case 0xbf53c180:
                            if (s == "땅")
                            {
                                this.Patron.UseStock("대지", "벨트");
                                break;
                            }
                            break;
                    }
                }
                this.Patron.SendMessage(2, $"{monster.Name}: Offense: {offense}, Defense: {defense}");
            }
        }

        private void Patron_TargetEffectReceived(uint guid, ushort effect)
        {
            Aisling aisling;
            Monster monster;
            if ((this.Patron.Field != null) && this.Patron.Field.Monsters.TryGetValue(guid, out monster))
            {
                switch (effect)
                {
                    case 0xe8:
                        monster.Liberato = false;
                        monster.Immortal = false;
                        break;

                    case 0xf5:
                        monster.Liberato = true;
                        break;

                    case 6:
                        monster.Liberato = true;
                        monster.Immortal = true;
                        break;

                    case 0x42:
                        monster.Liberato = true;
                        break;

                    case 0xf7:
                        monster.Venomi = true;
                        break;

                    case 0x17f:
                        monster.Seo = true;
                        break;

                    case 0x184:
                        monster.Narcoli = true;
                        break;

                    case 0x185:
                        monster.Soruma = true;
                        break;

                    case 268:
                        monster.Confusio = true;
                        break;
                }
            }
            if ((this.Patron.Field != null) && this.Patron.Field.Aislings.TryGetValue(guid, out aisling))
            {
                if (this.chk그룹힐.Checked && ((((effect == 0x35) || (effect == 50)) || ((effect == 70) || (effect == 0xa2))) || (effect == 0x48)))
                {
                    this.Patron.UseSpell("홀리쿠라네라", (Sprite)null);
                }
                if ((((effect == 390) && this.Patron.Form.chk코마.Checked) && !this.Patron.isState()) && ((this.Patron.Form.chkTargetAll.Checked || (this.Patron.Form.chkTagetGuild.Checked && (aisling.NameTint == 3))) || (this.Patron.Form.chkTagetGroup.Checked && (aisling.NameTint == 5))))
                {
                    ushort x;
                    ushort y;
                    if ((((this.Patron.X == aisling.X) && (this.Patron.Y == (aisling.Y + 1))) || ((this.Patron.X == aisling.X) && (this.Patron.Y == (aisling.Y - 1)))) || (((this.Patron.X == (aisling.X + 1)) && (this.Patron.Y == aisling.Y)) || (((this.Patron.X - 1) == aisling.X) && (this.Patron.Y == aisling.Y))))
                    {
                        x = this.Patron.X;
                        y = this.Patron.Y;
                    }
                    else
                    {
                        if (!this.Patron.Form.isAttackable(aisling.X, aisling.Y))
                        {
                            return;
                        }
                        if (this.Patron.chooseClosePosition(this.Patron, aisling.X, aisling.Y, out x, out y, -1) && (this.Patron.TryGetStockS("텔리포트의깃털") || this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)")))
                        {
                            this.Patron.mTeleport.WaitOne();
                            this.Patron.MoveByTeleport(this.Patron, x, y);
                            this.Patron.mTeleport.ReleaseMutex();
                        }
                    }
                    if ((y == (aisling.Y + 1)) && (x == aisling.X))
                    {
                        this.Patron.Turn(0);
                    }
                    if ((x == (aisling.X - 1)) && (y == aisling.Y))
                    {
                        this.Patron.Turn(1);
                    }
                    if ((y == (aisling.Y - 1)) && (x == aisling.X))
                    {
                        this.Patron.Turn(2);
                    }
                    if ((x == (aisling.X + 1)) && (y == aisling.Y))
                    {
                        this.Patron.Turn(3);
                    }
                    if (!this.Patron.UseSpell("코마디아", (Sprite)null) || (this.Patron.CurrentMP.Get() < 520))
                    {
                        this.Patron.UseStockS("코마디움");
                    }
                    else
                    {
                        this.Patron.UseSpell("홀리쿠라노", aisling);
                    }
                }
                switch (effect)
                {
                    case 0x68:
                        aisling.Dark = true;
                        break;

                    case 0xc0:
                        aisling.Dark = false;
                        break;

                    case 0xc4:
                        aisling.Venom = true;
                        break;

                    case 5:
                        aisling.Coma = false;
                        break;

                    case 6:
                        aisling.Immortal = true;
                        break;

                    case 0xe8:
                        {
                            Buff buff;
                            aisling.Narcoli = false;
                            aisling.Soruma = false;
                            aisling.StrengthenAttribute = false;
                            aisling.Horrama = false;
                            aisling.Kolama = false;
                            aisling.Immortal = false;
                            aisling.Venom = false;
                            aisling.Illumena = false;
                            this.Patron.BuffNote.TryRemove(aisling.Name, out buff);
                            break;
                        }

                    case 0xe9:
                        aisling.Depreco = false;
                        break;

                    case 0xf3:
                        aisling.Depreco = true;
                        break;

                    case 0xf4:
                        aisling.Kolama = true;
                        if (aisling.NameTint == 5)
                        {
                            Buff buff = new Buff(aisling.Name)
                            {
                                Kolama = DateTime.Now
                            };
                            this.Patron.mBuffControl.WaitOne();
                            this.Patron.BuffNote.AddOrUpdate(aisling.Name, buff, (key, value) => value.Kolama_Set(buff.Kolama));
                            this.Patron.mBuffControl.ReleaseMutex();
                        }
                        break;

                    case 0xf5:
                        aisling.Horrama = true;
                        if (aisling.NameTint == 5)
                        {
                            Buff buff1 = new Buff(aisling.Name)
                            {
                                Horrama = DateTime.Now
                            };
                            this.Patron.mBuffControl.WaitOne();
                            this.Patron.BuffNote.AddOrUpdate(aisling.Name, buff1, (key, value) => value.Horrama_Set(buff1.Horrama));
                            this.Patron.mBuffControl.ReleaseMutex();
                        }
                        break;

                    case 0xf7:
                        aisling.Venom = true;
                        break;

                    case 0xfd:
                        aisling.Pravo = false;
                        break;

                    case 0xfe:
                        aisling.Bardo = false;
                        break;

                    case 0x100:
                        aisling.Rento = false;
                        break;

                    case 0x101:
                        aisling.Pravo = true;
                        break;

                    case 0x102:
                        aisling.Bardo = true;
                        break;

                    case 0x103:
                        aisling.Rento = true;
                        break;

                    case 0x107:
                        if (aisling.NameTint == 5)
                        {
                            Buff buff2 = new Buff(aisling.Name)
                            {
                                StrengthenAttribute = DateTime.Now
                            };
                            this.Patron.mBuffControl.WaitOne();
                            this.Patron.BuffNote.AddOrUpdate(aisling.Name, buff2, (key, value) => value.StrengthenAttribute_Set(buff2.StrengthenAttribute));
                            this.Patron.mBuffControl.ReleaseMutex();
                        }
                        break;

                    case 0x117:
                        aisling.Venom = false;
                        break;

                    case 280:
                        aisling.Narcoli = false;
                        break;

                    case 0x119:
                        aisling.Illumena = false;
                        break;

                    case 0x11a:
                        aisling.Soruma = false;
                        break;

                    case 0x184:
                        aisling.Narcoli = true;
                        break;

                    case 0x185:
                        aisling.Soruma = true;
                        break;

                    case 390:
                        aisling.Coma = true;
                        break;

                    case 0x187:
                        aisling.Illumena = true;
                        break;
                }
            }
        }

        private void ShowEnemy()
        {
            if (this._enemyList.Count > 0)
            {
                string text = null;
                for (int i = 0; i < this._enemyList.Count; i++)
                {
                    text = text + this._enemyList[i];
                    if (this._enemyList.Count > (i + 1))
                    {
                        text = text + ", ";
                    }
                }
                this.Patron.SendMessage(8, text);
            }
        }

        private void ShowTrash()
        {
            if (this._trashList.Count > 0)
            {
                string text = null;
                for (int i = 0; i < this._trashList.Count; i++)
                {
                    text = text + this._trashList[i];
                    if (this._trashList.Count > (i + 1))
                    {
                        text = text + ", ";
                    }
                }
                this.Patron.SendMessage(8, text);
            }
        }

        private void tbGroupHeal_Scroll(object sender, EventArgs e)
        {
            this._GroupHealHP = this.tbGroupHeal.Value;
        }

        private void tbHeal_Scroll(object sender, EventArgs e)
        {
            this._HealHP = this.tbHeal.Value;
        }

        private void ThreadDoWalk()
        {
            while (this.Patron != null)
            {
                if (this._moveFlag)
                {
                    if ((this.Patron.X == this._moveX) && (this.Patron.Y == this._moveY))
                    {
                        this._moveFlag = false;
                        this._moveSleep = 250;
                    }
                    this.Patron.MoveToDestination(this._moveX, this._moveY, 1, this._moveSleep);
                }
                Thread.Sleep(350);
            }
        }

        private void UseSpell_Load()
        {
            this.AttachSpell(this.chkDeRento, "디렌토");
            this.AttachSpell(this.chkDeBardo, "디바르도");
            this.AttachSpell(this.chkDeDefleca, "디데프레카");
            this.AttachSpell(this.chkDePrava, "디프라바");
            this.AttachSpell(this.chkHolyCure, "홀리큐어");
            this.AttachSpell(this.chkDeSoruma, "디소루마");
            this.AttachSpell(this.chkDeNarcoli, "디나르콜리");
            this.AttachSpell(this.chkDeVenomo, "디베노모");
            this.AttachSpell(this.chkIllumena, "일루메나");
            this.AttachSpell(this.chk디렌, "디렌토");
            this.AttachSpell(this.chk디바, "디바르도");
            this.AttachSpell(this.chk디데, "디데프레카");
            this.AttachSpell(this.chk디프, "디프라바");
            this.AttachSpell(this.chk디각, "홀리큐어");
            this.AttachSpell(this.chk디소, "디소루마");
            this.AttachSpell(this.chk디나, "디나르콜리");
            this.AttachSpell(this.chk디베, "디베노모");
            this.AttachSpell(this.chk일루, "일루메나");
            if (!this.AttachSpell(this.chk호르, "호르라마"))
            {
                this.AttachSpell(this.chk호르, "자기보호");
            }
            if (!this.AttachSpell(this.chk콜라, "콜라마"))
            {
                this.AttachSpell(this.chk콜라, "철포삼");
            }
            if (!this.AttachSpell(this.chk이모탈, "이모탈"))
            {
                this.AttachSpell(this.chk이모탈, "금강불괴");
            }
            if (!this.AttachSpell(this.chk리플, "리플렉토"))
            {
                this.AttachSpell(this.chk리플, "반탄신공");
            }
            this.AttachSpell(this.chk집중, "집중");
            this.AttachSpell(this.chk하이드, "하이드");
            if (!this.AttachSpell(this.chk라이트닝무브, "라이트닝무브"))
            {
                this.AttachSpell(this.chk라이트닝무브, "미종보법");
            }
            if (!this.AttachSpell(this.chk힐, "홀리쿠라노") && !this.AttachSpell(this.chk힐, "엑스쿠라노"))
            {
                this.AttachSpell(this.chk힐, "쿠라노");
            }
            if (!this.AttachSpell(this.chk그룹힐, "홀리쿠라노") && !this.AttachSpell(this.chk그룹힐, "엑스쿠라노"))
            {
                this.AttachSpell(this.chk그룹힐, "쿠라노");
            }
            this.AttachSpell(this.chk리베, "리베라토");
        }

        public ProxyPatron Patron { get; private set; }

        internal sealed class PrivateImplementationDetails
        {
            internal static uint ComputeStringHash(string s)
            {
                uint num = new uint();
                if (s != null)
                {
                    num = 0x811c9dc5;
                    for (int i = 0; i < s.Length; i++)
                    {
                        num = (s[i] ^ num) * 0x1000193;
                    }
                }
                return num;
            }
        }
    }
}

