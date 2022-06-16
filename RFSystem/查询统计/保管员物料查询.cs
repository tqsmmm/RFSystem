using RFSystem.rfid2021Service;
using System;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 保管员物料查询 : Form
    {
        private DataSet m_Ds;
        private DataView m_Dv;

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

                if ((m_Ds != null) && (dataGridView1.DataSource != null))
                {
                    string str = "";

                    if (txtBatch.Text.Trim() != "")
                    {
                        str = str + "Charg='" + txtBatch.Text.Trim() + "' and ";
                    }

                    if (txtMaterial.Text.Trim() != "")
                    {
                        str = str + "Matnr='" + txtMaterial.Text.Trim() + "' and ";
                    }

                    if (txtPlant.Text.Trim() != "")
                    {
                        str = str + "Werks='" + txtPlant.Text.Trim() + "' and ";
                    }

                    if (txtSubPlant.Text.Trim() != "")
                    {
                        str = str + "Bct20='" + txtSubPlant.Text.Trim() + "' and ";
                    }

                    if (str != "")
                    {
                        str = str.Substring(0, str.Length - 4);
                    }

                    m_Dv.RowFilter = str;
                }
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
