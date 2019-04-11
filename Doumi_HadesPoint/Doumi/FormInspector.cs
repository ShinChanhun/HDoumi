namespace Doumi
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormInspector : Form
    {
        private object item;
        private IContainer components = null;
        private PropertyGrid propertyGrid1;

        public FormInspector(object item)
        {
            this.InitializeComponent();
            this.item = item;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FormInspector_Load(object sender, EventArgs e)
        {
            this.propertyGrid1.SelectedObject = this.item;
        }

        private void InitializeComponent()
        {
            this.propertyGrid1 = new PropertyGrid();
            base.SuspendLayout();
            this.propertyGrid1.Dock = DockStyle.Fill;
            this.propertyGrid1.Location = new Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new Size(0x11c, 0x105);
            this.propertyGrid1.TabIndex = 1;
            base.AutoScaleDimensions = new SizeF(7f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x11c, 0x105);
            base.Controls.Add(this.propertyGrid1);
            base.Name = "FormInspector";
            this.Text = "Doumi - Inspector";
            base.Load += new EventHandler(this.FormInspector_Load);
            base.ResumeLayout(false);
        }
    }
}

