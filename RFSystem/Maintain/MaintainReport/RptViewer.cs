using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace RFSystem.Maintain.MaintainReport
{


    public class RptViewer : Form
    {
        private IContainer components = null;
        private CrystalReportViewer crystalReportViewerMaintain;
        private ReportDocument rpt;

        /*
        public RptViewer(MaintainDataSet dataSet, ArrayList baseInfo)
        {
            this.InitializeComponent();
            this.rpt = new ReportDocument();
            this.rpt.Load(@"C:\Documents and Settings\yxm\My Documents\Visual Studio 2005\Projects\RFSystem\RFSystem\Maintain\MaintainReport\保养单.rpt");
            this.rpt.SetDataSource((DataSet)dataSet);
            this.GetMaintainInfo(baseInfo);
            this.crystalReportViewerMaintain.ReportSource = this.rpt;
        }
        */

        private void GetMaintainInfo(ArrayList baseInfo)
        {
            TextObject obj2 = (TextObject)this.rpt.ReportDefinition.ReportObjects["TextMaintainNo"];
            obj2.Text = baseInfo[0].ToString();
            TextObject obj3 = (TextObject)this.rpt.ReportDefinition.ReportObjects["TextMaintainDatetime"];
            obj3.Text = baseInfo[1].ToString();
            TextObject obj4 = (TextObject)this.rpt.ReportDefinition.ReportObjects["TextStoreman"];
            obj4.Text = baseInfo[2].ToString();
            TextObject obj5 = (TextObject)this.rpt.ReportDefinition.ReportObjects["TextAdmin"];
            obj5.Text = baseInfo[3].ToString();
        }

        private void InitializeComponent()
        {
            this.crystalReportViewerMaintain = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerMaintain
            // 
            this.crystalReportViewerMaintain.ActiveViewIndex = -1;
            this.crystalReportViewerMaintain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerMaintain.DisplayGroupTree = false;
            this.crystalReportViewerMaintain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerMaintain.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerMaintain.Name = "crystalReportViewerMaintain";
            this.crystalReportViewerMaintain.SelectionFormula = "";
            this.crystalReportViewerMaintain.Size = new System.Drawing.Size(892, 566);
            this.crystalReportViewerMaintain.TabIndex = 0;
            this.crystalReportViewerMaintain.ViewTimeSelectionFormula = "";
            // 
            // RptViewer
            // 
            this.ClientSize = new System.Drawing.Size(892, 566);
            this.Controls.Add(this.crystalReportViewerMaintain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RptViewer";
            this.Text = "报表查看器";
            this.ResumeLayout(false);

        }
    }
}
