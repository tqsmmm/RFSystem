using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace RFSystem.ArriveStore.ExceptionCard
{
    public class 打印设备卡片 : Form
    {
        private CrystalReportViewer crystalReportViewerExceptionCard;

        public 打印设备卡片()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // 打印设备卡片
            // 
            ClientSize = new System.Drawing.Size(417, 518);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "打印设备卡片";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "打印设备卡片";
            Load += new System.EventHandler(打印设备卡片_Load);
            ResumeLayout(false);

        }

        private void 打印设备卡片_Load(object sender, EventArgs e)
        {
            ReportDocument document = new ReportDocument();
            document.Load(@"C:\Documents and Settings\yxm\My Documents\Visual Studio 2005\Projects\RFSystem\RFSystem\ArriveStore\ExceptionCard\库存设备备件卡片.rpt");
            TextObject obj2 = document.ReportDefinition.ReportObjects["TextFactory"] as TextObject;

            if (obj2 != null)
            {
                obj2.Text = "工厂1";
            }

            crystalReportViewerExceptionCard.ReportSource = document;
        }
    }
}
