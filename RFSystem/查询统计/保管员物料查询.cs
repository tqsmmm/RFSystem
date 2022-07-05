using System;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 保管员物料查询 : Form
    {
        public 保管员物料查询()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
            }
            catch (Exception Ex)
            {
                CommonFunction.Sys_MsgBox(Ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
            }
            catch
            {

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void 保管员物料查询_Load(object sender, EventArgs e)
        {
            DataTable dtPrinterList = DBOperate.GetPrinterList(txtPrinter.Text, "%");
            dataGridViewPrinterList.DataSource = dtPrinterList;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnPatchPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
