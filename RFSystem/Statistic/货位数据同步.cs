using System.ComponentModel;
using System.Windows.Forms;

namespace RFSystem.Statistic
{
    public class 货位数据同步 : Form
    {
        public 货位数据同步()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // 货位数据同步
            // 
            this.ClientSize = new System.Drawing.Size(974, 618);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "货位数据同步";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "货位数据同步";
            this.ResumeLayout(false);

        }
    }
}
