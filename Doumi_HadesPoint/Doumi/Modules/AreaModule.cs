namespace Doumi.Modules
{
    using Doumi;
    using Doumi.Net;
    using Doumi.Properties;
    using Doumi.Types;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class AreaModule : Form
    {
        //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        //private ProxyPatron <Patron>k__BackingField;
        private int xMouse;
        private int yMouse;
        private float tileSize;
        private float unitSize;
        private Bitmap areaImage;
        private static readonly SolidBrush SelfBrush = new SolidBrush(Color.FromArgb(-6343));
        private static readonly SolidBrush AislingBrush = new SolidBrush(Color.FromArgb(-8673545));
        private static readonly SolidBrush MonsterBrush = new SolidBrush(Color.FromArgb(-3276784));
        private static readonly SolidBrush MundaneBrush = new SolidBrush(Color.FromArgb(-16711936));
        private IContainer components = null;

        public AreaModule(ProxyPatron patron)
        {
            this.Patron = patron;
            this.InitializeComponent();
        }

        private void AreaModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Patron.FieldChanged -= new Action(this.Patron_FieldChanged);
            this.Patron.PositionChanged -= new Action(this.Patron_PositionChanged);
            this.ThreadSafeInvoke(() => this.Patron.Form._areaMoudleFlag = false);
        }

        private void AreaModule_Load(object sender, EventArgs e)
        {
            this.Patron.FieldChanged += new Action(this.Patron_FieldChanged);
            this.Patron.PositionChanged += new Action(this.Patron_PositionChanged);
            this.Patron_FieldChanged();
            base.Invalidate();
        }

        private void AreaModule_MouseClick(object sender, MouseEventArgs e)
        {
            Field field = this.Patron.Field;
            if ((((field != null) && field.Loaded) && (this.xMouse < field.Cols)) && (this.yMouse < field.Rows))
            {
                if (((this.Patron.Form.areaModule != null) && !this.Patron.Field.Name.StartsWith("직업")) && ((this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)") || this.Patron.TryGetStockS("[TEST]테슬러의깃털(1일)") || this.Patron.TryGetStockS("텔리포트의깃털"))))
                {
                    this.Patron.mTeleport.WaitOne();
                    this.Patron.MoveByTeleport(this.Patron, this.xMouse, this.yMouse);
                    this.Patron.mTeleport.ReleaseMutex();
                }
                else
                {
                    this.Patron.Form._moveFlag = true;
                    this.Patron.Form._moveX = this.xMouse;
                    this.Patron.Form._moveY = this.yMouse;
                }
            }
        }

        private void AreaModule_MouseMove(object sender, MouseEventArgs e)
        {
            this.xMouse = (int) (((float) e.X) / this.tileSize);
            this.yMouse = (int) (((float) e.Y) / this.tileSize);
            base.Invalidate();
        }

        private void AreaModule_Paint(object sender, PaintEventArgs e)
        {
            Field field = this.Patron.Field;
            if (this.Patron != null)
            {
                if ((field == null) || !field.Loaded)
                {
                    e.Graphics.DrawString("Map file could not be loaded, press (F5) to try again.", this.Font, Brushes.Black, (float) 0f, (float) 0f);
                    this.Patron.Refresh();
                }
                else if (this.areaImage != null)
                {
                    try
                    {
                        e.Graphics.DrawImage(this.areaImage, 0, 0);
                    }
                    catch
                    {
                        this.Patron.Refresh();
                    }
                    this.Patron.mGroupMember.WaitOne();
                    if (this.Patron.GroupMembers != null)
                    {
                        foreach (GroupMember member in this.Patron.GroupMembers)
                        {
                            if (member.Area.Equals(field.Name))
                            {
                                e.Graphics.FillRectangle(AislingBrush, this.tileSize * member.X, this.tileSize * member.Y, this.tileSize, this.tileSize);
                            }
                        }
                    }
                    this.Patron.mGroupMember.ReleaseMutex();
                    e.Graphics.FillRectangle(SelfBrush, this.tileSize * this.Patron.X, this.tileSize * this.Patron.Y, this.tileSize, this.tileSize);
                    if (((this.xMouse >= 0) && (this.xMouse < this.Patron.Field.Cols)) && ((this.yMouse >= 0) && (this.yMouse < this.Patron.Field.Rows)))
                    {
                        e.Graphics.FillRectangle(Brushes.Orange, this.tileSize * this.xMouse, this.tileSize * this.yMouse, this.tileSize, this.tileSize);
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(7f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(390, 390);
            base.ControlBox = false;
            this.DoubleBuffered = true;
            base.Name = "AreaModule";
            this.Text = "AreaDodule";
            base.TopMost = true;
            base.FormClosing += new FormClosingEventHandler(this.AreaModule_FormClosing);
            base.Load += new EventHandler(this.AreaModule_Load);
            base.Paint += new PaintEventHandler(this.AreaModule_Paint);
            base.MouseClick += new MouseEventHandler(this.AreaModule_MouseClick);
            base.MouseMove += new MouseEventHandler(this.AreaModule_MouseMove);
            base.ResumeLayout(false);
        }

        private void Patron_FieldChanged()
        {
            Field field = this.Patron.Field;
            if ((field != null) && field.Loaded)
            {
                float num = ((float) base.ClientSize.Width) / ((float) (this.Patron.Field.Cols * 4));
                float num2 = ((float) base.ClientSize.Height) / ((float) (this.Patron.Field.Rows * 4));
                this.unitSize = Math.Min(num, num2);
                this.tileSize = this.unitSize * 4f;
                Bitmap image = new Bitmap(base.ClientSize.Width, base.ClientSize.Height);
                this.areaImage = image;
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.Clear(Color.Black);
                    if (!field.Loaded)
                    {
                        graphics.DrawString("Unable to load mapfile. Press (F5) to try again.", this.Font, Brushes.White, (float) 0f, (float) 0f);
                        this.Patron.Refresh();
                    }
                    else
                    {
                        using (TextureBrush brush = new TextureBrush(Resources.walltexture))
                        {
                            for (int i = 0; i < this.Patron.Field.Rows; i++)
                            {
                                float y = i * this.tileSize;
                                float num5 = y + this.tileSize;
                                for (int j = 0; j < this.Patron.Field.Cols; j++)
                                {
                                    float x = j * this.tileSize;
                                    float num8 = x + this.tileSize;
                                    if (this.Patron.Field.IsSolid(j, i))
                                    {
                                        float num9 = j;
                                        float num10 = i;
                                        graphics.FillRectangle(brush, x, y, this.tileSize, this.tileSize);
                                        if (!this.Patron.Field.IsSolid(j, i - 1))
                                        {
                                            graphics.DrawLine(Pens.White, x, y, num8, y);
                                        }
                                        if (!this.Patron.Field.IsSolid(j + 1, i))
                                        {
                                            graphics.DrawLine(Pens.White, num8, y, num8, num5);
                                        }
                                        if (!this.Patron.Field.IsSolid(j, i + 1))
                                        {
                                            graphics.DrawLine(Pens.White, x, num5, num8, num5);
                                        }
                                        if (!this.Patron.Field.IsSolid(j - 1, i))
                                        {
                                            graphics.DrawLine(Pens.White, x, y, x, num5);
                                        }
                                    }
                                }
                            }
                        }
                        this.ThreadSafeInvoke(delegate {
                            this.Text = $"Area - {this.Patron.Name} [{this.Patron.Field.Name}]";
                            base.Invalidate();
                        });
                    }
                }
            }
        }

        private void Patron_PositionChanged()
        {
            base.Invalidate();
        }

        public ProxyPatron Patron { get; set; }
    }
}

