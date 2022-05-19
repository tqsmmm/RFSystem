namespace RF_ControlLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ComboBox : UserControl
    {
        private System.Windows.Forms.ComboBox comboBoxUserControl;
        private IContainer components = null;

        public ComboBox()
        {
            this.InitializeComponent();
        }

        private void ComboBox_SizeChanged(object sender, EventArgs e)
        {
            base.Size = new Size(base.Size.Width, 20);
            this.comboBoxUserControl.Size = base.Size;
        }

        private void comboBoxUserControl_Enter(object sender, EventArgs e)
        {
            this.comboBoxUserControl.Tag = this.comboBoxUserControl.Text;
        }

        private void comboBoxUserControl_Leave(object sender, EventArgs e)
        {
            if (this.comboBoxUserControl.Items.Contains(this.comboBoxUserControl.Text))
            {
                this.comboBoxUserControl.Tag = ((Control)sender).Text;
            }
            else
            {
                ((Control)sender).Text = (string)this.comboBoxUserControl.Tag;
            }
        }

        private void comboBoxUserControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxUserControl.Tag = this.comboBoxUserControl.Text;
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
            this.comboBoxUserControl.Items.Add(item);
            this.comboBoxUserControl.Text = this.comboBoxUserControl.Items[0].ToString();
        }

        public int SelectIndex
        {
            get
            {
                return this.comboBoxUserControl.SelectedIndex;
            }
            set
            {
                this.comboBoxUserControl.SelectedIndex = value;
            }
        }

        public override string Text
        {
            get
            {
                return this.comboBoxUserControl.Text;
            }
            set
            {
                this.comboBoxUserControl.Text = value;
            }
        }
    }
}
