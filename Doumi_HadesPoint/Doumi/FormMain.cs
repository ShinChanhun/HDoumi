namespace Doumi
{
    using Doumi.Net;
    using Doumi.Properties;
    using Microsoft.CSharp.RuntimeBinder;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class FormMain : Form
    {
        private Point mCurrentPosition = new Point(0, 0);
        public static ProxyServer[] Servers = new ProxyServer[3];
        private IContainer components = null;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
        private BackgroundWorker bgwMetafile;
        private Panel Btn_Min;
        private Panel Btn_Close;
        private Panel pnlMain;

        public FormMain()
        {
            this.InitializeComponent();
        }

        private void bgwMetafile_DoWork(object sender, DoWorkEventArgs e)
        {
            FileInfo[] files = new DirectoryInfo("C:/Nexon/LodTest/metafile/").GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                Metafile.CacheFile(files[i]);
                this.bgwMetafile.ReportProgress((i * 100) / files.Length, new { 
                    Count = files.Length,
                    Index = i + 1,
                    Value = files[i]
                });
            }
        }

        private void bgwMetafile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            object userState = e.UserState;
            if (o__8.p__5 == null)
            {
                o__8.p__5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(FormMain)));
            }
            if (o__8.p__4 == null)
            {
                CSharpArgumentInfo[] argumentInfo = new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.IsStaticType | CSharpArgumentInfoFlags.UseCompileTimeType, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant | CSharpArgumentInfoFlags.UseCompileTimeType, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) };
                o__8.p__4 = CallSite<Func<CallSite, System.Type, string, object, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Format", null, typeof(FormMain), argumentInfo));
            }
            if (o__8.p__1 == null)
            {
                CSharpArgumentInfo[] argumentInfo = new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) };
                o__8.p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Name", typeof(FormMain), argumentInfo));
            }
            if (o__8.p__0 == null)
            {
                CSharpArgumentInfo[] argumentInfo = new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) };
                o__8.p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Value", typeof(FormMain), argumentInfo));
            }
            if (o__8.p__2 == null)
            {
                CSharpArgumentInfo[] argumentInfo = new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) };
                o__8.p__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Index", typeof(FormMain), argumentInfo));
            }
            if (o__8.p__3 == null)
            {
                CSharpArgumentInfo[] argumentInfo = new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) };
                o__8.p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Count", typeof(FormMain), argumentInfo));
            }
            this.lblStatus.Text = o__8.p__5.Target(o__8.p__5, o__8.p__4.Target(o__8.p__4, typeof(string), "Caching Metafile {1} of {2}: '{0}' ...", o__8.p__1.Target(o__8.p__1, o__8.p__0.Target(o__8.p__0, userState)), o__8.p__2.Target(o__8.p__2, userState), o__8.p__3.Target(o__8.p__3, userState)));
        }

        private void bgwMetafile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lblStatus.Text = "Ready";
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.bgwMetafile.Dispose();
            Application.Exit();
        }

        private void Btn_Min_MouseClick(object sender, MouseEventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        public void DequeuePatron(ProxyPatron patron)
        {
            if (patron.Form != null)
            {
                this.ThreadSafeInvoke(delegate {
                    if (patron.Form.areaModule != null)
                    {
                        patron.Form.areaModule.Close();
                        patron.Form.areaModule = null;
                    }
                    if (patron.Form.networkExplorerModule != null)
                    {
                        patron.Form.networkExplorerModule.Close();
                        patron.Form.networkExplorerModule = null;
                    }
                    if (patron.Form.macroModule != null)
                    {
                        patron.Form.macroModule.Close();
                        patron.Form.macroModule = null;
                    }
                    if (patron.Form.chatModule != null)
                    {
                        patron.Form.chatModule.Close();
                        patron.Form.chatModule = null;
                    }
                    patron.Form.Close();
                    patron.Form = null;
                });
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

        public void EnqueuePatron(ProxyPatron patron)
        {
            this.ThreadSafeInvoke(delegate {
                if (patron.Form == null)
                {
                    patron.Form = new FormPatron(patron);
                    patron.Form.Hide();
                }
            });
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.bgwMetafile.Dispose();
            Application.ExitThread();
            Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.bgwMetafile.RunWorkerAsync();
        }

        private void Function_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mCurrentPosition = new Point(-e.X, -e.Y);
            }
        }

        private void Function_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                base.Location = new Point(base.Location.X + (this.mCurrentPosition.X + e.X), base.Location.Y + (this.mCurrentPosition.Y + e.Y));
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FormMain));
            this.statusStrip = new StatusStrip();
            this.lblStatus = new ToolStripStatusLabel();
            this.bgwMetafile = new BackgroundWorker();
            this.Btn_Min = new Panel();
            this.Btn_Close = new Panel();
            this.pnlMain = new Panel();
            this.statusStrip.SuspendLayout();
            base.SuspendLayout();
            ToolStripItem[] toolStripItems = new ToolStripItem[] { this.lblStatus };
            this.statusStrip.Items.AddRange(toolStripItems);
            this.statusStrip.Location = new Point(0, 0x6a);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(0xaf, 0x16);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "statusStrip1";
            this.lblStatus.BackColor = SystemColors.Control;
            this.lblStatus.Font = new Font("돋움", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x81);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(40, 0x11);
            this.lblStatus.Text = "Ready";
            this.bgwMetafile.WorkerReportsProgress = true;
            this.bgwMetafile.DoWork += new DoWorkEventHandler(this.bgwMetafile_DoWork);
            this.bgwMetafile.ProgressChanged += new ProgressChangedEventHandler(this.bgwMetafile_ProgressChanged);
            this.bgwMetafile.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgwMetafile_RunWorkerCompleted);
            this.Btn_Min.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.Btn_Min.BackgroundImage = Resources.Min;
            this.Btn_Min.BackgroundImageLayout = ImageLayout.Zoom;
            this.Btn_Min.BorderStyle = BorderStyle.Fixed3D;
            this.Btn_Min.Cursor = Cursors.Hand;
            this.Btn_Min.Location = new Point(0, 0x4e);
            this.Btn_Min.Name = "Btn_Min";
            this.Btn_Min.Size = new Size(0x18, 0x18);
            this.Btn_Min.TabIndex = 13;
            this.Btn_Min.MouseClick += new MouseEventHandler(this.Btn_Min_MouseClick);
            this.Btn_Close.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.Btn_Close.BackgroundImage = Resources.Close;
            this.Btn_Close.BackgroundImageLayout = ImageLayout.Zoom;
            this.Btn_Close.BorderStyle = BorderStyle.Fixed3D;
            this.Btn_Close.Cursor = Cursors.Hand;
            this.Btn_Close.Location = new Point(30, 0x4e);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new Size(0x18, 0x18);
            this.Btn_Close.TabIndex = 14;
            this.Btn_Close.Click += new EventHandler(this.Btn_Close_Click);
            this.pnlMain.BackgroundImage = Resources.MainBack;
            this.pnlMain.BackgroundImageLayout = ImageLayout.Stretch;
            this.pnlMain.Cursor = Cursors.Hand;
            this.pnlMain.Location = new Point(0x44, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new Size(100, 100);
            this.pnlMain.TabIndex = 12;
            this.pnlMain.MouseDown += new MouseEventHandler(this.Function_MouseDown);
            this.pnlMain.MouseMove += new MouseEventHandler(this.Function_MouseMove);
            base.AutoScaleDimensions = new SizeF(7f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Black;
            this.BackgroundImageLayout = ImageLayout.None;
            base.CausesValidation = false;
            base.ClientSize = new Size(0xaf, 0x80);
            base.Controls.Add(this.Btn_Min);
            base.Controls.Add(this.Btn_Close);
            base.Controls.Add(this.pnlMain);
            base.Controls.Add(this.statusStrip);
            this.Cursor = Cursors.Default;
            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormMain";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Doumi";
            base.TransparencyKey = Color.Black;
            base.FormClosing += new FormClosingEventHandler(this.FormMain_FormClosing);
            base.Load += new EventHandler(this.FormMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        [CompilerGenerated]
        private static class o__8
        {
            public static CallSite<Func<CallSite, object, object>> p__0;
            public static CallSite<Func<CallSite, object, object>> p__1;
            public static CallSite<Func<CallSite, object, object>> p__2;
            public static CallSite<Func<CallSite, object, object>> p__3;
            public static CallSite<Func<CallSite, System.Type, string, object, object, object, object>> p__4;
            public static CallSite<Func<CallSite, object, string>> p__5;
        }
    }
}

