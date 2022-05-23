using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RF_ControlLibrary
{
    public class ComboBox : UserControl
    {
        private System.Windows.Forms.ComboBox comboBoxUserControl;
        private IContainer components = null;

        public ComboBox()
        {
            InitializeComponent();
        }

        private void ComboBox_SizeChanged(object sender, EventArgs e)
        {
            Size = new Size(Size.Width, 20);
            comboBoxUserControl.Size = Size;
        }

        private void comboBoxUserControl_Enter(object sender, EventArgs e)
        {
            comboBoxUserControl.Tag = comboBoxUserControl.Text;
        }

        private void comboBoxUserControl_Leave(object sender, EventArgs e)
        {
            if (comboBoxUserControl.Items.Contains(comboBoxUserControl.Text))
            {
                comboBoxUserControl.Tag = ((Control)sender).Text;
            }
            else
            {
                ((Control)sender).Text = (string)comboBoxUserControl.Tag;
            }
        }

        private void comboBoxUserControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxUserControl.Tag = comboBoxUserControl.Text;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxUserControl = new System.Windows.Forms.ComboBox();
            base.SuspendLayout();
            //this.comboBoxUserControl.set_FormattingEnabled(true);
            this.comboBoxUserControl.Location = new Point(0, 0);
            this.comboBoxUserControl.Name = "comboBoxUserControl";
            this.comboBoxUserControl.Size = new Size(0x79, 20);
            this.comboBoxUserControl.TabIndex = 0;
            this.comboBoxUserControl.SelectedIndexChanged += new EventHandler(this.comboBoxUserControl_SelectedIndexChanged);
            this.comboBoxUserControl.Leave += new EventHandler(this.comboBoxUserControl_Leave);
            this.comboBoxUserControl.Enter += new EventHandler(this.comboBoxUserControl_Enter);
            //base.set_AutoScaleDimensions(new SizeF(6f, 12f));
            //base.set_AutoScaleMode(1);
            this.SetAutoScrollMargin(6, 12);
            base.Controls.Add(this.comboBoxUserControl);
            base.Name = "ComboBox";
            base.Size = new Size(0x79, 20);
            base.SizeChanged += new EventHandler(this.ComboBox_SizeChanged);
            base.ResumeLayout(false);
        }

        public void ItemsAdd(string item)
        {
            comboBoxUserControl.Items.Add(item);
            comboBoxUserControl.Text = comboBoxUserControl.Items[0].ToString();
        }

        public int SelectIndex
        {
            get
            {
                return comboBoxUserControl.SelectedIndex;
            }
            set
            {
                comboBoxUserControl.SelectedIndex = value;
            }
        }

        public override string Text
        {
            get
            {
                return comboBoxUserControl.Text;
            }
            set
            {
                comboBoxUserControl.Text = value;
            }
        }
    }
}
