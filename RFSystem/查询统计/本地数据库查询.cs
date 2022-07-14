using System;
using System.Collections;
using System.Data;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 本地数据库查询 : Form
    {
        public 本地数据库查询()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ArrayList alParams = new ArrayList();
                alParams.Add(comboBoxPlant.Text.Equals("无") ? string.Empty : comboBoxPlant.SelectedValue.ToString());
                alParams.Add(comboBoxSLocation.Text.Equals("无") ? string.Empty : comboBoxSLocation.SelectedValue.ToString());
                alParams.Add(textBoxBarcode.Text.Trim());
                alParams.Add(textBoxDes.Text.Trim());
                alParams.Add(textBoxBin.Text.Trim());
                alParams.Add(textBoxOrderNo.Text.Trim());
                alParams.Add(textBoxSubPlant.Text.Trim());
                alParams.Add(textBoxSupplier.Text.Trim());
                alParams.Add(textBoxStoreMan.Text.Trim());

                DataTable dtResult = ClsCommon.LocalStockGetList_New(alParams);

                if (CommonFunction.IfHasData(dtResult))
                {
                    dataGridViewStock.DataSource = dtResult;
                }
                else
                {
                    dataGridViewStock.DataSource = dtResult;
                    CommonFunction.Sys_MsgBox("没有检索到任何数据，请重新检索!");
                }

                dataGridViewStock_SelectionChanged(null, null);
            }
            catch
            {
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void dataGridViewStock_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewStock.Rows != null) && (dataGridViewStock.SelectedRows.Count != 0))
            {
                if (dataGridViewStock.SelectedRows[0].Cells["ColumnPrintCount"].Value != null)
                {
                    nudCopy.Value = 1;
                }

                btnPrint.Enabled = true;
                btnPatchPrint.Enabled = true;
            }
            else
            {
                nudCopy.Value = 0;

                btnPrint.Enabled = false;
                btnPatchPrint.Enabled = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrinterList.RowCount < 1)
            {
                CommonFunction.Sys_MsgBox("请指定打印机!");
            }
            else
            {
                TcpClient client = new TcpClient();

                string hostname = dataGridViewPrinterList.SelectedRows[0].Cells["columnPAddress"].Value.ToString();
                int port = int.Parse(dataGridViewPrinterList.SelectedRows[0].Cells["columnSocket"].Value.ToString());

                try
                {
                    client.Connect(hostname, port);

                    string s = string.Empty;
                    string f = dataGridViewStock.SelectedRows[0].Cells["ColumnSUPPLIER_NO"].Value.ToString();
                    string proName = dataGridViewStock.SelectedRows[0].Cells["ColumnPRODUCT_NAME"].Value.ToString();
                    string proNo = dataGridViewStock.SelectedRows[0].Cells["ColumnPRODUCT_NO"].Value.ToString();
                    string patch = dataGridViewStock.SelectedRows[0].Cells["ColumnPATCH_NO"].Value.ToString();
                    string deNo = dataGridViewStock.SelectedRows[0].Cells["pzh"].Value.ToString();
                    string ckDate = dataGridViewStock.SelectedRows[0].Cells["rkrq"].Value.ToString();
                    string manu = "";
                    string pC = dataGridViewStock.SelectedRows[0].Cells["ColumnBillNo"].Value.ToString();
                    string cert = "";
                    string supp = dataGridViewStock.SelectedRows[0].Cells["ColumnPName"].Value.ToString();
                    string loca = dataGridViewStock.SelectedRows[0].Cells["ColumnBIN"].Value.ToString();
                    string q = dataGridViewStock.SelectedRows[0].Cells["ColumnBct1"].Value.ToString();
                    string r = "";
                    string u = dataGridViewStock.SelectedRows[0].Cells["ColumnUNIT"].Value.ToString();
                    string w = dataGridViewStock.SelectedRows[0].Cells["ColumnWeight"].Value.ToString();
                    string p = dataGridViewStock.SelectedRows[0].Cells["ColumnVerpr"].Value.ToString();

                    string cop = nudCopy.Value.ToString();

                    string baoguanyuan = dataGridViewStock.SelectedRows[0].Cells["ColumnStoreManDetail"].Value.ToString();
                    string ywtm = dataGridViewStock.SelectedRows[0].Cells["ywtm"].Value.ToString();

                    s = ClsCommon.dealData(f, proName, proNo, patch, deNo, ckDate, manu, pC, cert, supp, loca, q, u, w, r, p, cop, ywtm, baoguanyuan, cmbLabelType.Text);
                    client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                    
                    client.GetStream().Flush();
                    client.Close();
                }
                catch (Exception Ex)
                {
                    CommonFunction.Sys_MsgBox(Ex.Message);
                }
            }
        }

        private void btnPatchPrint_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrinterList.RowCount < 1)
            {
                CommonFunction.Sys_MsgBox("请指定打印机!");
            }
            else
            {
                TcpClient client = new TcpClient();

                string hostname = dataGridViewPrinterList.SelectedRows[0].Cells["columnPAddress"].Value.ToString();
                int port = int.Parse(dataGridViewPrinterList.SelectedRows[0].Cells["columnSocket"].Value.ToString());

                try
                {
                    client.Connect(hostname, port);

                    for (int i = 0; i < dataGridViewStock.RowCount; i++)
                    {
                        string s = string.Empty;
                        string f = dataGridViewStock.Rows[i].Cells["ColumnSUPPLIER_NO"].Value.ToString();
                        string proName = dataGridViewStock.Rows[i].Cells["ColumnPRODUCT_NAME"].Value.ToString();
                        string proNo = dataGridViewStock.Rows[i].Cells["ColumnPRODUCT_NO"].Value.ToString();
                        string patch = dataGridViewStock.Rows[i].Cells["ColumnPATCH_NO"].Value.ToString();
                        string deNo = dataGridViewStock.Rows[i].Cells["pzh"].Value.ToString();//凭证号 string.Empty;
                        string ckDate = dataGridViewStock.Rows[i].Cells["rkrq"].Value.ToString();//入库日期 string.Empty;
                        string manu = "";
                        string pC = dataGridViewStock.Rows[i].Cells["ColumnBillNo"].Value.ToString();
                        string cert = "";
                        string supp = dataGridViewStock.Rows[i].Cells["ColumnPName"].Value.ToString();
                        string loca = dataGridViewStock.Rows[i].Cells["ColumnBIN"].Value.ToString();
                        string q = dataGridViewStock.Rows[i].Cells["ColumnBct1"].Value.ToString();
                        string r = "";
                        string u = dataGridViewStock.Rows[i].Cells["ColumnUNIT"].Value.ToString();
                        string w = dataGridViewStock.Rows[i].Cells["ColumnWeight"].Value.ToString();
                        string p = dataGridViewStock.Rows[i].Cells["ColumnVerpr"].Value.ToString();

                        string cop = nudCopy.Value.ToString();

                        string baoguanyuan = dataGridViewStock.Rows[i].Cells["ColumnStoreManDetail"].Value.ToString();
                        string ywtm = dataGridViewStock.Rows[i].Cells["ywtm"].Value.ToString();

                        s = ClsCommon.dealData(f, proName, proNo, patch, deNo, ckDate, manu, pC, cert, supp, loca, q, u, w, r, p, cop, ywtm, baoguanyuan, cmbLabelType.Text);
                        client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                        client.GetStream().Flush();
                    }

                    client.Close();
                }
                catch (Exception Ex)
                {
                    CommonFunction.Sys_MsgBox(Ex.Message);
                }
            }
        }

        private void 本地数据库查询_Load(object sender, EventArgs e)
        {
            DataTable dtPrinterList = DBOperate.GetPrinterList(txtPrinter.Text, "%");
            dataGridViewPrinterList.DataSource = dtPrinterList;

            //comboBoxPlant
            DataTable dtPlantList = DBOperate.GetPlantList(string.Empty, true);

            DataRow row = dtPlantList.NewRow();

            row["PlantID"] = 0;
            row["PlantDescription"] = "无";

            dtPlantList.Rows.InsertAt(row, 0);

            comboBoxPlant.DataSource = dtPlantList;
            comboBoxPlant.DisplayMember = "PlantDescription";
            comboBoxPlant.ValueMember = "PlantID";

            comboBoxPlant.SelectedIndex = 0;
        }

        private void comboBoxPlant_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dtStoreLocusList = DBOperate.GetStoreLocusList(string.Empty, string.Empty);

            comboBoxSLocation.Items.Clear();

            DataRow row = dtStoreLocusList.NewRow();

            row["PlantID"] = 0;
            row["PlantDescription"] = "无";

            dtStoreLocusList.Rows.InsertAt(row, 0);

            comboBoxSLocation.DataSource = dtStoreLocusList;
            comboBoxSLocation.DisplayMember = "StoreLocusDescription";
            comboBoxSLocation.ValueMember = "StoreLocusID";

            comboBoxSLocation.SelectedIndex = 0;
        }
    }
}
