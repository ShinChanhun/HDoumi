namespace Doumi.Modules
{
    using Doumi;
    using Doumi.Net;
    using Doumi.Nexon.Net;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class ChatModule : Form
    {
        //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        //private ProxyPatron <Patron>k__BackingField;
        private IContainer components = null;
        private SplitContainer splChat;
        private TabControl tabChatPages;
        private TabPage tabFieldChat;
        private TextBox txtSpeakLog;
        private TabPage tabGuildChat;
        private TextBox txtGuildLog;
        private TabPage tabPartyChat;
        private TextBox txtPartyLog;
        private TextBox txtChatMessage;

        public ChatModule(ProxyPatron patron)
        {
            this.Patron = patron;
            this.InitializeComponent();
        }

        private void ChatModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Patron.OnGuildMessageReceived -= new Action<string>(this.patron_OnGuildMessageReceived);
            this.Patron.OnPartyMessageReceived -= new Action<string>(this.patron_OnPartyMessageReceived);
            this.Patron.OnSpeakMessageReceived -= new Action<string>(this.patron_OnSpeakMessageReceived);
            this.Patron.OnPrivyMessageReceived -= new Action<string>(this.patron_OnSpeakMessageReceived);
            this.ThreadSafeInvoke(() => this.Patron.Form._chatMoudleFlag = false);
        }

        private void ChatModule_Load(object sender, EventArgs e)
        {
            this.Text = $"Doumi Chat - {this.Patron.Name}";
            this.Patron.OnGuildMessageReceived += new Action<string>(this.patron_OnGuildMessageReceived);
            this.Patron.OnPartyMessageReceived += new Action<string>(this.patron_OnPartyMessageReceived);
            this.Patron.OnSpeakMessageReceived += new Action<string>(this.patron_OnSpeakMessageReceived);
            this.Patron.OnPrivyMessageReceived += new Action<string>(this.patron_OnSpeakMessageReceived);
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
            this.splChat = new SplitContainer();
            this.tabChatPages = new TabControl();
            this.tabFieldChat = new TabPage();
            this.txtSpeakLog = new TextBox();
            this.tabGuildChat = new TabPage();
            this.txtGuildLog = new TextBox();
            this.tabPartyChat = new TabPage();
            this.txtPartyLog = new TextBox();
            this.txtChatMessage = new TextBox();
            this.splChat.BeginInit();
            this.splChat.Panel1.SuspendLayout();
            this.splChat.Panel2.SuspendLayout();
            this.splChat.SuspendLayout();
            this.tabChatPages.SuspendLayout();
            this.tabFieldChat.SuspendLayout();
            this.tabGuildChat.SuspendLayout();
            this.tabPartyChat.SuspendLayout();
            base.SuspendLayout();
            this.splChat.Dock = DockStyle.Fill;
            this.splChat.Location = new Point(0, 0);
            this.splChat.Name = "splChat";
            this.splChat.Orientation = Orientation.Horizontal;
            this.splChat.Panel1.Controls.Add(this.tabChatPages);
            this.splChat.Panel2.Controls.Add(this.txtChatMessage);
            this.splChat.Panel2MinSize = 20;
            this.splChat.Size = new Size(0x13a, 0x1b1);
            this.splChat.SplitterDistance = 0x194;
            this.splChat.SplitterWidth = 3;
            this.splChat.TabIndex = 0;
            this.tabChatPages.Controls.Add(this.tabFieldChat);
            this.tabChatPages.Controls.Add(this.tabGuildChat);
            this.tabChatPages.Controls.Add(this.tabPartyChat);
            this.tabChatPages.Dock = DockStyle.Fill;
            this.tabChatPages.Location = new Point(0, 0);
            this.tabChatPages.Multiline = true;
            this.tabChatPages.Name = "tabChatPages";
            this.tabChatPages.SelectedIndex = 0;
            this.tabChatPages.Size = new Size(0x13a, 0x194);
            this.tabChatPages.TabIndex = 1;
            this.tabFieldChat.Controls.Add(this.txtSpeakLog);
            this.tabFieldChat.Location = new Point(4, 0x16);
            this.tabFieldChat.Name = "tabFieldChat";
            this.tabFieldChat.Padding = new Padding(3);
            this.tabFieldChat.Size = new Size(0x132, 0x17a);
            this.tabFieldChat.TabIndex = 0;
            this.tabFieldChat.Tag = "Field";
            this.tabFieldChat.Text = "Field";
            this.tabFieldChat.UseVisualStyleBackColor = true;
            this.txtSpeakLog.Dock = DockStyle.Fill;
            this.txtSpeakLog.Location = new Point(3, 3);
            this.txtSpeakLog.Multiline = true;
            this.txtSpeakLog.Name = "txtSpeakLog";
            this.txtSpeakLog.ScrollBars = ScrollBars.Vertical;
            this.txtSpeakLog.Size = new Size(300, 0x174);
            this.txtSpeakLog.TabIndex = 0;
            this.tabGuildChat.Controls.Add(this.txtGuildLog);
            this.tabGuildChat.Location = new Point(4, 0x16);
            this.tabGuildChat.Name = "tabGuildChat";
            this.tabGuildChat.Padding = new Padding(3);
            this.tabGuildChat.Size = new Size(0x132, 0x17a);
            this.tabGuildChat.TabIndex = 1;
            this.tabGuildChat.Tag = "Guild";
            this.tabGuildChat.Text = "Guild";
            this.tabGuildChat.UseVisualStyleBackColor = true;
            this.txtGuildLog.Dock = DockStyle.Fill;
            this.txtGuildLog.ForeColor = Color.FromArgb(0x73, 0xb6, 0xad);
            this.txtGuildLog.Location = new Point(3, 3);
            this.txtGuildLog.Multiline = true;
            this.txtGuildLog.Name = "txtGuildLog";
            this.txtGuildLog.ScrollBars = ScrollBars.Vertical;
            this.txtGuildLog.Size = new Size(300, 0x174);
            this.txtGuildLog.TabIndex = 1;
            this.tabPartyChat.Controls.Add(this.txtPartyLog);
            this.tabPartyChat.Location = new Point(4, 0x16);
            this.tabPartyChat.Name = "tabPartyChat";
            this.tabPartyChat.Padding = new Padding(3);
            this.tabPartyChat.Size = new Size(0x132, 0x17a);
            this.tabPartyChat.TabIndex = 2;
            this.tabPartyChat.Tag = "Party";
            this.tabPartyChat.Text = "Party";
            this.tabPartyChat.UseVisualStyleBackColor = true;
            this.txtPartyLog.Dock = DockStyle.Fill;
            this.txtPartyLog.ForeColor = Color.FromArgb(140, 150, 0x31);
            this.txtPartyLog.Location = new Point(3, 3);
            this.txtPartyLog.Multiline = true;
            this.txtPartyLog.Name = "txtPartyLog";
            this.txtPartyLog.ScrollBars = ScrollBars.Vertical;
            this.txtPartyLog.Size = new Size(300, 0x174);
            this.txtPartyLog.TabIndex = 1;
            this.txtChatMessage.AcceptsReturn = true;
            this.txtChatMessage.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.txtChatMessage.Location = new Point(7, 4);
            this.txtChatMessage.Multiline = true;
            this.txtChatMessage.Name = "txtChatMessage";
            this.txtChatMessage.Size = new Size(300, 0x13);
            this.txtChatMessage.TabIndex = 3;
            this.txtChatMessage.KeyUp += new KeyEventHandler(this.txtChatMessage_KeyUp);
            base.AutoScaleDimensions = new SizeF(7f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x13a, 0x1b1);
            base.ControlBox = false;
            base.Controls.Add(this.splChat);
            base.Name = "ChatModule";
            base.ShowIcon = false;
            this.Text = "ChatModule";
            base.TopMost = true;
            base.FormClosing += new FormClosingEventHandler(this.ChatModule_FormClosing);
            base.Load += new EventHandler(this.ChatModule_Load);
            this.splChat.Panel1.ResumeLayout(false);
            this.splChat.Panel2.ResumeLayout(false);
            this.splChat.Panel2.PerformLayout();
            this.splChat.EndInit();
            this.splChat.ResumeLayout(false);
            this.tabChatPages.ResumeLayout(false);
            this.tabFieldChat.ResumeLayout(false);
            this.tabFieldChat.PerformLayout();
            this.tabGuildChat.ResumeLayout(false);
            this.tabGuildChat.PerformLayout();
            this.tabPartyChat.ResumeLayout(false);
            this.tabPartyChat.PerformLayout();
            base.ResumeLayout(false);
        }

        private void patron_OnGuildMessageReceived(string text)
        {
            this.ThreadSafeInvoke(delegate {
                if (this.Patron.Form != null)
                {
                    if (this.txtGuildLog.Text.Length > 0)
                    {
                        this.txtGuildLog.AppendText(Environment.NewLine);
                    }
                    this.txtGuildLog.AppendText(text);
                }
            });
        }

        private void patron_OnPartyMessageReceived(string text)
        {
            this.ThreadSafeInvoke(delegate {
                if (this.Patron.Form != null)
                {
                    if (this.txtPartyLog.Text.Length > 0)
                    {
                        this.txtPartyLog.AppendText(Environment.NewLine);
                    }
                    this.txtPartyLog.AppendText(text);
                }
            });
        }

        private void patron_OnPrivyMessageReceived(string text)
        {
            this.ThreadSafeInvoke(delegate {
                if (this.Patron.Form != null)
                {
                    if (this.txtSpeakLog.Text.Length > 0)
                    {
                        this.txtSpeakLog.AppendText(Environment.NewLine);
                    }
                    this.txtSpeakLog.AppendText(text);
                }
            });
        }

        private void patron_OnSpeakMessageReceived(string text)
        {
            this.ThreadSafeInvoke(delegate {
                if (this.Patron.Form != null)
                {
                    if (this.txtSpeakLog.Text.Length > 0)
                    {
                        this.txtSpeakLog.AppendText(Environment.NewLine);
                    }
                    this.txtSpeakLog.AppendText(text);
                }
            });
        }

        private void txtChatMessage_KeyUp(object sender, KeyEventArgs e)
        {
            NexonClientPacket packet;
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            string tag = this.tabChatPages.SelectedTab.Tag as string;
            string str2 = this.txtChatMessage.Text.Trim();
            if (string.IsNullOrEmpty(str2))
            {
                goto Label_0137;
            }
            string str3 = tag;
            string str4 = str3;
            if (str3 != null)
            {
                switch (str4)
                {
                    case "Field":
                        packet = new NexonClientPacket(this.Patron, 14);
                        packet.WriteU1(0);
                        goto Label_0110;

                    case "Guild":
                        packet = new NexonClientPacket(this.Patron, 0x19);
                        packet.WriteC1("!");
                        goto Label_0110;

                    case "Party":
                        packet = new NexonClientPacket(this.Patron, 0x19);
                        packet.WriteC1("!!");
                        goto Label_0110;
                }
            }
            packet = new NexonClientPacket(this.Patron, 0x19);
            packet.WriteC1(tag);
        Label_0110:
            packet.WriteC1(str2);
            packet.WriteU1(0);
            this.Patron.Server.Send(packet);
        Label_0137:
            this.txtChatMessage.Clear();
        }

        public ProxyPatron Patron { get; set; }
    }
}

