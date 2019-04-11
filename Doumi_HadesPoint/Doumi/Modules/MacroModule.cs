namespace Doumi.Modules
{
    using Doumi;
    using Doumi.Net;
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class MacroModule : Form
    {
        private Thread thread;
        private int[] skills;
        private int[] spells;
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private ProxyPatron <Patron>k__BackingField;
        private IContainer components = null;
        private ContextMenuStrip cmsSpell;
        private ToolStripMenuItem tmiInspectSpell;
        private ImageList imlSpells;
        private ContextMenuStrip cmsSkill;
        private ToolStripMenuItem tmiInspectSkill;
        private ImageList imlSkills;
        private ColumnHeader clmGroupName;
        private ColumnHeader clmGroupArea;
        private Button btnMacro;
        private SplitContainer splMacro;
        public ListView lstSkills;
        public ListView lstSpells;
        private Panel pnlMacro;

        public MacroModule(ProxyPatron patron)
        {
            this.Patron = patron;
            this.InitializeComponent();
        }

        private void btnMacro_Click(object sender, EventArgs e)
        {
            if ((this.thread != null) && this.thread.IsAlive)
            {
                this.thread.Abort();
                this.thread.Join();
                this.thread = null;
                this.lstSkills.Enabled = true;
                this.lstSpells.Enabled = true;
                this.btnMacro.Text = "Start";
            }
            else
            {
                this.skills = new int[this.lstSkills.SelectedIndices.Count];
                this.lstSkills.SelectedIndices.CopyTo(this.skills, 0);
                this.spells = new int[this.lstSpells.SelectedIndices.Count];
                this.lstSpells.SelectedIndices.CopyTo(this.spells, 0);
                this.lstSkills.Enabled = false;
                this.lstSpells.Enabled = false;
                this.btnMacro.Text = "Stop";
                this.thread = new Thread(new ThreadStart(this.RunMacro));
                this.thread.Start();
            }
        }

        private void cmsSkill_Opening(object sender, CancelEventArgs e)
        {
            this.tmiInspectSkill.Enabled = this.lstSkills.SelectedIndices.Count > 0;
        }

        private void cmsSpell_Opening(object sender, CancelEventArgs e)
        {
            this.tmiInspectSpell.Enabled = this.lstSpells.SelectedIndices.Count > 0;
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
            this.components = new Container();
            ListViewGroup group = new ListViewGroup("1st Class Skills", HorizontalAlignment.Left);
            ListViewGroup group2 = new ListViewGroup("2nd Class Skills", HorizontalAlignment.Left);
            ListViewGroup group3 = new ListViewGroup("General Skills", HorizontalAlignment.Left);
            ListViewGroup group4 = new ListViewGroup("1st Class Spells", HorizontalAlignment.Left);
            ListViewGroup group5 = new ListViewGroup("2nd Class Spells", HorizontalAlignment.Left);
            ListViewGroup group6 = new ListViewGroup("General Spells", HorizontalAlignment.Left);
            this.cmsSpell = new ContextMenuStrip(this.components);
            this.tmiInspectSpell = new ToolStripMenuItem();
            this.imlSpells = new ImageList(this.components);
            this.cmsSkill = new ContextMenuStrip(this.components);
            this.tmiInspectSkill = new ToolStripMenuItem();
            this.imlSkills = new ImageList(this.components);
            this.clmGroupName = new ColumnHeader();
            this.clmGroupArea = new ColumnHeader();
            this.btnMacro = new Button();
            this.splMacro = new SplitContainer();
            this.lstSkills = new ListView();
            this.lstSpells = new ListView();
            this.pnlMacro = new Panel();
            this.cmsSpell.SuspendLayout();
            this.cmsSkill.SuspendLayout();
            this.splMacro.BeginInit();
            this.splMacro.Panel1.SuspendLayout();
            this.splMacro.Panel2.SuspendLayout();
            this.splMacro.SuspendLayout();
            this.pnlMacro.SuspendLayout();
            base.SuspendLayout();
            this.cmsSpell.AllowDrop = true;
            ToolStripItem[] toolStripItems = new ToolStripItem[] { this.tmiInspectSpell };
            this.cmsSpell.Items.AddRange(toolStripItems);
            this.cmsSpell.Name = "cmsSpell";
            this.cmsSpell.Size = new Size(0x7a, 0x1a);
            this.cmsSpell.Opening += new CancelEventHandler(this.cmsSpell_Opening);
            this.tmiInspectSpell.Name = "tmiInspectSpell";
            this.tmiInspectSpell.Size = new Size(0x79, 0x16);
            this.tmiInspectSpell.Text = "Inspect...";
            this.tmiInspectSpell.Click += new EventHandler(this.tmiInspectSpell_Click);
            this.imlSpells.ColorDepth = ColorDepth.Depth24Bit;
            this.imlSpells.ImageSize = new Size(0x1f, 0x1f);
            this.imlSpells.TransparentColor = Color.Transparent;
            this.cmsSkill.AllowDrop = true;
            ToolStripItem[] itemArray2 = new ToolStripItem[] { this.tmiInspectSkill };
            this.cmsSkill.Items.AddRange(itemArray2);
            this.cmsSkill.Name = "cmsSkill";
            this.cmsSkill.Size = new Size(0x7a, 0x1a);
            this.cmsSkill.Opening += new CancelEventHandler(this.cmsSkill_Opening);
            this.tmiInspectSkill.Name = "tmiInspectSkill";
            this.tmiInspectSkill.Size = new Size(0x79, 0x16);
            this.tmiInspectSkill.Text = "Inspect...";
            this.tmiInspectSkill.Click += new EventHandler(this.tmiInspectSkill_Click);
            this.imlSkills.ColorDepth = ColorDepth.Depth24Bit;
            this.imlSkills.ImageSize = new Size(0x1f, 0x1f);
            this.imlSkills.TransparentColor = Color.Transparent;
            this.clmGroupName.Text = "Name";
            this.clmGroupName.Width = 120;
            this.clmGroupArea.Text = "Area";
            this.clmGroupArea.Width = 300;
            this.btnMacro.Dock = DockStyle.Bottom;
            this.btnMacro.Location = new Point(0, 0x197);
            this.btnMacro.Name = "btnMacro";
            this.btnMacro.Size = new Size(0x1d2, 0x22);
            this.btnMacro.TabIndex = 10;
            this.btnMacro.Text = "Start";
            this.btnMacro.UseVisualStyleBackColor = true;
            this.btnMacro.Click += new EventHandler(this.btnMacro_Click);
            this.splMacro.Dock = DockStyle.Fill;
            this.splMacro.Location = new Point(0, 0);
            this.splMacro.Name = "splMacro";
            this.splMacro.Orientation = Orientation.Horizontal;
            this.splMacro.Panel1.Controls.Add(this.lstSkills);
            this.splMacro.Panel2.Controls.Add(this.lstSpells);
            this.splMacro.Size = new Size(0x1d2, 0x194);
            this.splMacro.SplitterDistance = 200;
            this.splMacro.TabIndex = 9;
            this.lstSkills.AllowDrop = true;
            this.lstSkills.ContextMenuStrip = this.cmsSkill;
            this.lstSkills.Dock = DockStyle.Fill;
            this.lstSkills.FullRowSelect = true;
            this.lstSkills.GridLines = true;
            group.Header = "1st Class Skills";
            group.Name = "lvg1stClassSkills";
            group2.Header = "2nd Class Skills";
            group2.Name = "lvg2ndClassSkills";
            group3.Header = "General Skills";
            group3.Name = "lvgGeneralSkills";
            ListViewGroup[] groups = new ListViewGroup[] { group, group2, group3 };
            this.lstSkills.Groups.AddRange(groups);
            this.lstSkills.HideSelection = false;
            this.lstSkills.LargeImageList = this.imlSkills;
            this.lstSkills.Location = new Point(0, 0);
            this.lstSkills.Name = "lstSkills";
            this.lstSkills.Size = new Size(0x1d2, 200);
            this.lstSkills.TabIndex = 0;
            this.lstSkills.TileSize = new Size(0x25, 0x25);
            this.lstSkills.UseCompatibleStateImageBehavior = false;
            this.lstSkills.View = View.Tile;
            this.lstSkills.ItemDrag += new ItemDragEventHandler(this.lstSkills_ItemDrag);
            this.lstSkills.DragDrop += new DragEventHandler(this.lstSkills_DragDrop);
            this.lstSkills.DragEnter += new DragEventHandler(this.lstSkills_DragEnter);
            this.lstSpells.AllowDrop = true;
            this.lstSpells.ContextMenuStrip = this.cmsSpell;
            this.lstSpells.Dock = DockStyle.Fill;
            this.lstSpells.FullRowSelect = true;
            this.lstSpells.GridLines = true;
            group4.Header = "1st Class Spells";
            group4.Name = "lvg1stClassSpells";
            group5.Header = "2nd Class Spells";
            group5.Name = "lvg2ndClassSpells";
            group6.Header = "General Spells";
            group6.Name = "lvgGeneralSpells";
            ListViewGroup[] groupArray2 = new ListViewGroup[] { group4, group5, group6 };
            this.lstSpells.Groups.AddRange(groupArray2);
            this.lstSpells.HideSelection = false;
            this.lstSpells.LargeImageList = this.imlSpells;
            this.lstSpells.Location = new Point(0, 0);
            this.lstSpells.Name = "lstSpells";
            this.lstSpells.Size = new Size(0x1d2, 200);
            this.lstSpells.TabIndex = 1;
            this.lstSpells.TileSize = new Size(0x25, 0x25);
            this.lstSpells.UseCompatibleStateImageBehavior = false;
            this.lstSpells.View = View.Tile;
            this.lstSpells.ItemDrag += new ItemDragEventHandler(this.lstSpells_ItemDrag);
            this.lstSpells.DragDrop += new DragEventHandler(this.lstSpells_DragDrop);
            this.lstSpells.DragEnter += new DragEventHandler(this.lstSpells_DragEnter);
            this.pnlMacro.Controls.Add(this.splMacro);
            this.pnlMacro.Dock = DockStyle.Top;
            this.pnlMacro.Location = new Point(0, 0);
            this.pnlMacro.Name = "pnlMacro";
            this.pnlMacro.Size = new Size(0x1d2, 0x194);
            this.pnlMacro.TabIndex = 1;
            base.AutoScaleDimensions = new SizeF(7f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1d2, 0x1b9);
            base.ControlBox = false;
            base.Controls.Add(this.pnlMacro);
            base.Controls.Add(this.btnMacro);
            base.Name = "MacroModule";
            base.ShowIcon = false;
            this.Text = "MacroModule";
            base.TopMost = true;
            base.FormClosing += new FormClosingEventHandler(this.MacroModule_FormClosing);
            base.Load += new EventHandler(this.MacroModule_Load);
            this.cmsSpell.ResumeLayout(false);
            this.cmsSkill.ResumeLayout(false);
            this.splMacro.Panel1.ResumeLayout(false);
            this.splMacro.Panel2.ResumeLayout(false);
            this.splMacro.EndInit();
            this.splMacro.ResumeLayout(false);
            this.pnlMacro.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void lstSkills_DragDrop(object sender, DragEventArgs e)
        {
            Point point = this.lstSkills.PointToClient(new Point(e.X, e.Y));
            ListViewItem data = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
            ListViewItem itemAt = this.lstSkills.GetItemAt(point.X, point.Y);
            if ((data != null) && (itemAt != null))
            {
                this.Patron.MoveSkill((byte) (data.Index + 1), (byte) (itemAt.Index + 1));
            }
        }

        private void lstSkills_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void lstSkills_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.lstSkills.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void lstSpells_DragDrop(object sender, DragEventArgs e)
        {
            Point point = this.lstSpells.PointToClient(new Point(e.X, e.Y));
            ListViewItem data = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
            ListViewItem itemAt = this.lstSpells.GetItemAt(point.X, point.Y);
            if ((data != null) && (itemAt != null))
            {
                this.Patron.MoveSpell((byte) (data.Index + 1), (byte) (itemAt.Index + 1));
            }
        }

        private void lstSpells_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void lstSpells_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.lstSpells.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void MacroModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.thread != null)
            {
                this.thread.Abort();
                this.thread = null;
            }
            this.ThreadSafeInvoke(() => this.Patron.Form._macroMoudleFlag = false);
        }

        private void MacroModule_Load(object sender, EventArgs e)
        {
            this.Text = $"Doumi Macro - {this.Patron.Name}";
            this.imlSkills.Images.AddRange(Program.SkillIcons);
            this.imlSpells.Images.AddRange(Program.SpellIcons);
            for (int i = 1; i < 0x25; i++)
            {
                this.lstSkills.Items.Add(new ListViewItem("", (this.Patron.Skillbook[i] != null) ? this.Patron.Skillbook[i].Icon : -1, this.lstSkills.Groups[0]));
            }
            for (int j = 0x25; j < 0x49; j++)
            {
                this.lstSkills.Items.Add(new ListViewItem("", (this.Patron.Skillbook[j] != null) ? this.Patron.Skillbook[j].Icon : -1, this.lstSkills.Groups[1]));
            }
            for (int k = 0x49; k < 0x5b; k++)
            {
                this.lstSkills.Items.Add(new ListViewItem("", (this.Patron.Skillbook[k] != null) ? this.Patron.Skillbook[k].Icon : -1, this.lstSkills.Groups[2]));
            }
            for (int m = 1; m < 0x25; m++)
            {
                this.lstSpells.Items.Add(new ListViewItem("", (this.Patron.Spellbook[m] != null) ? this.Patron.Spellbook[m].Icon : -1, this.lstSpells.Groups[0]));
            }
            for (int n = 0x25; n < 0x49; n++)
            {
                this.lstSpells.Items.Add(new ListViewItem("", (this.Patron.Spellbook[n] != null) ? this.Patron.Spellbook[n].Icon : -1, this.lstSpells.Groups[1]));
            }
            for (int num6 = 0x49; num6 < 0x5b; num6++)
            {
                this.lstSpells.Items.Add(new ListViewItem("", (this.Patron.Spellbook[num6] != null) ? this.Patron.Spellbook[num6].Icon : -1, this.lstSpells.Groups[2]));
            }
        }

        private void RunMacro()
        {
            Monster target = null;
            Field field = this.Patron.Field;
            if (this.Patron.Field.Monsters.Count != 0)
            {
                using (IEnumerator<KeyValuePair<uint, Monster>> enumerator = field.Monsters.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        KeyValuePair<uint, Monster> current = enumerator.Current;
                        target = current.Value;
                    }
                }
            }
            while (true)
            {
                if (this.skills.Length != 0)
                {
                    foreach (int num2 in this.skills)
                    {
                        Skill skill = this.Patron.Skillbook[num2 + 1];
                        if (skill != null)
                        {
                            this.Patron.UseSkill(skill);
                        }
                    }
                }
                if (this.spells.Length != 0)
                {
                    foreach (int num4 in this.spells)
                    {
                        Spell spell = this.Patron.Spellbook[num4 + 1];
                        if (spell != null)
                        {
                            switch (spell.Type)
                            {
                                case 1:
                                    this.Patron.UseSpell(spell, "ohey");
                                    break;

                                case 2:
                                    this.Patron.UseSpell(spell, target);
                                    break;

                                case 5:
                                    this.Patron.UseSpell(spell, (Sprite) null);
                                    break;
                            }
                        }
                    }
                }
                Thread.Sleep(300);
            }
        }

        private void tmiInspectSkill_Click(object sender, EventArgs e)
        {
            foreach (int num in this.lstSkills.SelectedIndices)
            {
                new FormInspector(this.Patron.Skillbook[num + 1]).Show();
            }
        }

        private void tmiInspectSpell_Click(object sender, EventArgs e)
        {
            foreach (int num in this.lstSpells.SelectedIndices)
            {
                new FormInspector(this.Patron.Spellbook[num + 1]).Show();
            }
        }

        public ProxyPatron Patron { get; set; }
    }
}

