namespace Doumi.Modules
{
    using Doumi;
    using Doumi.Net;
    using Doumi.Nexon.Net;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class NetworkExplorerModule : Form
    {
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private ProxyPatron <Patron>k__BackingField;
        private IContainer components = null;
        private GroupBox grpClient;
        private CheckBox chkClientLog;
        private Button btnClientSend;
        private TextBox txtClientLog;
        private TextBox txtServerLog;
        private GroupBox grpServer;
        private CheckBox chkServerLog;
        private Button btnServerSend;
        private SplitContainer splitContainer;
        private Button btnClientLogClear;
        private Button btnServerLogClear;

        public NetworkExplorerModule(ProxyPatron patron)
        {
            this.Patron = patron;
            this.InitializeComponent();
        }

        private void btnClientLogClear_Click(object sender, EventArgs e)
        {
            this.txtClientLog.Text = "";
        }

        private void btnClientSend_Click(object sender, EventArgs e)
        {
            NexonClientPacket packet = null;
            string[] strArray = this.txtClientLog.Text.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strArray.Length; i++)
            {
                byte num2;
                if (!byte.TryParse(strArray[i], NumberStyles.HexNumber, (IFormatProvider) null, out num2))
                {
                    return;
                }
                if (i != 0)
                {
                    packet.WriteU1(num2);
                }
                else
                {
                    packet = new NexonClientPacket(this.Patron, num2);
                }
            }
            this.Patron.Server.Send(packet);
        }

        private void btnServerClear_Click(object sender, EventArgs e)
        {
            this.txtServerLog.Text = "";
        }

        private void btnServerSend_Click(object sender, EventArgs e)
        {
            NexonServerPacket packet = null;
            string[] strArray = this.txtServerLog.Text.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strArray.Length; i++)
            {
                byte num2;
                if (!byte.TryParse(strArray[i], NumberStyles.HexNumber, (IFormatProvider) null, out num2))
                {
                    return;
                }
                if (i != 0)
                {
                    packet.WriteU1(num2);
                }
                else
                {
                    packet = new NexonServerPacket(this.Patron, num2);
                }
            }
            this.Patron.Client.Send(packet);
        }

        private void chkLogClient_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkClientLog.Checked)
            {
                this.Patron.Server.OnDataSending += new Action<NexonPacket>(this.Server_OnDataSending);
            }
            else
            {
                this.Patron.Server.OnDataSending -= new Action<NexonPacket>(this.Server_OnDataSending);
            }
        }

        private void chkLogServer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkServerLog.Checked)
            {
                this.Patron.Client.OnDataSending += new Action<NexonPacket>(this.Client_OnDataSending);
            }
            else
            {
                this.Patron.Client.OnDataSending -= new Action<NexonPacket>(this.Client_OnDataSending);
            }
        }

        private void Client_OnDataSending(NexonPacket packet)
        {
            this.ThreadSafeInvoke(delegate {
                if (this.txtServerLog.Text.Length > 0)
                {
                    this.txtServerLog.AppendText(Environment.NewLine);
                }
                this.txtServerLog.AppendText(packet.ToString());
            });
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
            this.grpClient = new GroupBox();
            this.btnClientLogClear = new Button();
            this.chkClientLog = new CheckBox();
            this.btnClientSend = new Button();
            this.txtClientLog = new TextBox();
            this.txtServerLog = new TextBox();
            this.grpServer = new GroupBox();
            this.btnServerLogClear = new Button();
            this.chkServerLog = new CheckBox();
            this.btnServerSend = new Button();
            this.splitContainer = new SplitContainer();
            this.grpClient.SuspendLayout();
            this.grpServer.SuspendLayout();
            this.splitContainer.BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            base.SuspendLayout();
            this.grpClient.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.grpClient.Controls.Add(this.btnClientLogClear);
            this.grpClient.Controls.Add(this.chkClientLog);
            this.grpClient.Controls.Add(this.btnClientSend);
            this.grpClient.Controls.Add(this.txtClientLog);
            this.grpClient.Location = new Point(3, 3);
            this.grpClient.Name = "grpClient";
            this.grpClient.Size = new Size(0x1b2, 0xca);
            this.grpClient.TabIndex = 1;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Client";
            this.btnClientLogClear.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnClientLogClear.Location = new Point(0x110, 0xad);
            this.btnClientLogClear.Name = "btnClientLogClear";
            this.btnClientLogClear.Size = new Size(0x4b, 0x17);
            this.btnClientLogClear.TabIndex = 3;
            this.btnClientLogClear.Text = "Clear";
            this.btnClientLogClear.UseVisualStyleBackColor = true;
            this.btnClientLogClear.Click += new EventHandler(this.btnClientLogClear_Click);
            this.chkClientLog.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.chkClientLog.AutoSize = true;
            this.chkClientLog.Location = new Point(6, 0xb1);
            this.chkClientLog.Name = "chkClientLog";
            this.chkClientLog.Size = new Size(0x77, 0x10);
            this.chkClientLog.TabIndex = 1;
            this.chkClientLog.Text = "Logging Enabled";
            this.chkClientLog.UseVisualStyleBackColor = true;
            this.chkClientLog.CheckedChanged += new EventHandler(this.chkLogClient_CheckedChanged);
            this.btnClientSend.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnClientSend.Location = new Point(0x161, 0xad);
            this.btnClientSend.Name = "btnClientSend";
            this.btnClientSend.Size = new Size(0x4b, 0x17);
            this.btnClientSend.TabIndex = 2;
            this.btnClientSend.Text = "Send";
            this.btnClientSend.UseVisualStyleBackColor = true;
            this.btnClientSend.Click += new EventHandler(this.btnClientSend_Click);
            this.txtClientLog.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.txtClientLog.Location = new Point(6, 0x13);
            this.txtClientLog.Multiline = true;
            this.txtClientLog.Name = "txtClientLog";
            this.txtClientLog.ScrollBars = ScrollBars.Vertical;
            this.txtClientLog.Size = new Size(0x1a6, 0x94);
            this.txtClientLog.TabIndex = 0;
            this.txtServerLog.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.txtServerLog.Location = new Point(6, 0x13);
            this.txtServerLog.Multiline = true;
            this.txtServerLog.Name = "txtServerLog";
            this.txtServerLog.ScrollBars = ScrollBars.Vertical;
            this.txtServerLog.Size = new Size(0x1a6, 0x90);
            this.txtServerLog.TabIndex = 0;
            this.grpServer.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.grpServer.Controls.Add(this.btnServerLogClear);
            this.grpServer.Controls.Add(this.chkServerLog);
            this.grpServer.Controls.Add(this.btnServerSend);
            this.grpServer.Controls.Add(this.txtServerLog);
            this.grpServer.Location = new Point(3, 3);
            this.grpServer.Name = "grpServer";
            this.grpServer.Size = new Size(0x1b2, 0xc6);
            this.grpServer.TabIndex = 2;
            this.grpServer.TabStop = false;
            this.grpServer.Text = "Server";
            this.btnServerLogClear.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnServerLogClear.Location = new Point(0x110, 0xa9);
            this.btnServerLogClear.Name = "btnServerLogClear";
            this.btnServerLogClear.Size = new Size(0x4b, 0x17);
            this.btnServerLogClear.TabIndex = 4;
            this.btnServerLogClear.Text = "Clear";
            this.btnServerLogClear.UseVisualStyleBackColor = true;
            this.btnServerLogClear.Click += new EventHandler(this.btnServerClear_Click);
            this.chkServerLog.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.chkServerLog.AutoSize = true;
            this.chkServerLog.Location = new Point(6, 0xad);
            this.chkServerLog.Name = "chkServerLog";
            this.chkServerLog.Size = new Size(0x77, 0x10);
            this.chkServerLog.TabIndex = 1;
            this.chkServerLog.Text = "Logging Enabled";
            this.chkServerLog.UseVisualStyleBackColor = true;
            this.chkServerLog.CheckedChanged += new EventHandler(this.chkLogServer_CheckedChanged);
            this.btnServerSend.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnServerSend.Location = new Point(0x161, 0xa9);
            this.btnServerSend.Name = "btnServerSend";
            this.btnServerSend.Size = new Size(0x4b, 0x17);
            this.btnServerSend.TabIndex = 2;
            this.btnServerSend.Text = "Send";
            this.btnServerSend.UseVisualStyleBackColor = true;
            this.btnServerSend.Click += new EventHandler(this.btnServerSend_Click);
            this.splitContainer.Dock = DockStyle.Fill;
            this.splitContainer.Location = new Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Orientation.Horizontal;
            this.splitContainer.Panel1.Controls.Add(this.grpClient);
            this.splitContainer.Panel2.Controls.Add(this.grpServer);
            this.splitContainer.Size = new Size(440, 0x1a0);
            this.splitContainer.SplitterDistance = 0xd0;
            this.splitContainer.TabIndex = 5;
            base.AutoScaleDimensions = new SizeF(7f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(440, 0x1a0);
            base.ControlBox = false;
            base.Controls.Add(this.splitContainer);
            base.Name = "NetworkExplorerModule";
            base.ShowIcon = false;
            this.Text = "NetworkExplorer";
            base.TopMost = true;
            base.FormClosing += new FormClosingEventHandler(this.NetworkExplorerModule_FormClosing);
            base.Load += new EventHandler(this.NetworkExplorerModule_Load);
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            this.grpServer.ResumeLayout(false);
            this.grpServer.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.EndInit();
            this.splitContainer.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void NetworkExplorerModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ThreadSafeInvoke(() => this.Patron.Form._networkExplorerModuleFlag = false);
        }

        private void NetworkExplorerModule_Load(object sender, EventArgs e)
        {
            this.Text = $"Doumi NetworkExplorer - {this.Patron.Name}";
        }

        private void Server_OnDataSending(NexonPacket packet)
        {
            this.ThreadSafeInvoke(delegate {
                if (this.txtClientLog.Text.Length > 0)
                {
                    this.txtClientLog.AppendText(Environment.NewLine);
                }
                this.txtClientLog.AppendText(packet.ToString());
            });
        }

        public ProxyPatron Patron { get; set; }
    }
}

