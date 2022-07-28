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
            }
            catch
            {
            }
            finally
            {
                Cursor.Current = Cursors.Default;
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
                    for (int i = 0; i < dataGridViewStock.SelectedRows.Count; i++)
                    {
                        client.Connect(hostname, port);

                        string s = string.Empty;

                        string manu = string.Empty;
                        string cert = string.Empty;

                        if (dataGridViewStock.SelectedRows[i].Cells["deliveryLineId"].Value.ToString().Trim().Length != 0)
                        {
                            DataSet ds17 = GetData.Get_17(dataGridViewStock.SelectedRows[i].Cells["deliveryLineId"].Value.ToString());

                            if (ds17 != null && ds17.Tables[0].Rows.Count > 0)
                            {
                                manu = ds17.Tables[0].Rows[0]["instructions"].ToString();//说明书
                                cert = ds17.Tables[0].Rows[0]["qualifiedCertificate"].ToString();//合格证
                            }
                        }

                        string f = dataGridViewStock.SelectedRows[i].Cells["prodLineDeptName"].Value.ToString();//产线部门
                        string proName = dataGridViewStock.SelectedRows[i].Cells["itemDesc"].Value.ToString();//物料描述
                        string proNo = dataGridViewStock.SelectedRows[i].Cells["itemId"].Value.ToString();//物料号
                        string patch = dataGridViewStock.SelectedRows[i].Cells["itemName"].Value.ToString();//物料名称
                        string deNo = dataGridViewStock.SelectedRows[i].Cells["transactionId"].Value.ToString();//凭证号
                        string ckDate = dataGridViewStock.SelectedRows[i].Cells["depositDate"].Value.ToString();//入库日期

                        string pC = dataGridViewStock.SelectedRows[i].Cells["deliveryLineId"].Value.ToString();//送货单号

                        string baoguanyuan = dataGridViewStock.SelectedRows[i].Cells["custodianJobId"].Value.ToString();//保管员岗位号
                        string supp = dataGridViewStock.SelectedRows[i].Cells["supplierName"].Value.ToString();//供货单位名称
                        string loca = dataGridViewStock.SelectedRows[i].Cells["invBin"].Value.ToString();//储位
                        string q = dataGridViewStock.SelectedRows[i].Cells["invQty"].Value.ToString();//储位数量
                        string u = dataGridViewStock.SelectedRows[i].Cells["itemUom"].Value.ToString();//单位
                        string w = dataGridViewStock.SelectedRows[i].Cells["unitWeight"].Value.ToString();//单重
                        string r = dataGridViewStock.SelectedRows[i].Cells["batchId"].Value.ToString();//批次号
                        string p = dataGridViewStock.SelectedRows[i].Cells["invPrice"].Value.ToString();//单价
                        string cop = nudCopy.Value.ToString();

                        string ywtm = deNo + "-" + proNo;

                        s = ClsCommon.dealData(f, proName, proNo, patch, deNo, ckDate, manu, pC, cert, supp, loca, q, u, w, r, p, cop, ywtm, baoguanyuan, cmbLabelType.Text);
                        client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                        client.GetStream().Flush();

                        client.Close();
                    }
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
                    for (int i = 0; i < dataGridViewStock.RowCount; i++)
                    {
                        client.Connect(hostname, port);

                        string s = string.Empty;

                        string manu = string.Empty;
                        string cert = string.Empty;

                        if (dataGridViewStock.Rows[i].Cells["deliveryLineId"].Value.ToString().Trim().Length != 0)
                        {
                            DataSet ds17 = GetData.Get_17(dataGridViewStock.Rows[i].Cells["deliveryLineId"].Value.ToString());

                            if (ds17 != null && ds17.Tables[0].Rows.Count > 0)
                            {
                                manu = ds17.Tables[0].Rows[0]["instructions"].ToString();//说明书
                                cert = ds17.Tables[0].Rows[0]["qualifiedCertificate"].ToString();//合格证
                            }
                        }

                        string f = dataGridViewStock.Rows[i].Cells["prodLineDeptName"].Value.ToString();//产线部门
                        string proName = dataGridViewStock.Rows[i].Cells["itemDesc"].Value.ToString();//物料描述
                        string proNo = dataGridViewStock.Rows[i].Cells["itemId"].Value.ToString();//物料号
                        string patch = dataGridViewStock.Rows[i].Cells["itemName"].Value.ToString();//物料名称
                        string deNo = dataGridViewStock.Rows[i].Cells["transactionId"].Value.ToString();//凭证号
                        string ckDate = dataGridViewStock.Rows[i].Cells["depositDate"].Value.ToString();//入库日期

                        string pC = dataGridViewStock.Rows[i].Cells["deliveryLineId"].Value.ToString();//送货单号

                        string baoguanyuan = dataGridViewStock.Rows[i].Cells["custodianJobId"].Value.ToString();//保管员岗位号
                        string supp = dataGridViewStock.Rows[i].Cells["supplierName"].Value.ToString();//供货单位名称
                        string loca = dataGridViewStock.Rows[i].Cells["invBin"].Value.ToString();//储位
                        string q = dataGridViewStock.Rows[i].Cells["invQty"].Value.ToString();//储位数量
                        string u = dataGridViewStock.Rows[i].Cells["itemUom"].Value.ToString();//单位
                        string w = dataGridViewStock.Rows[i].Cells["unitWeight"].Value.ToString();//单重
                        string r = dataGridViewStock.Rows[i].Cells["batchId"].Value.ToString();//批次号
                        string p = dataGridViewStock.Rows[i].Cells["invPrice"].Value.ToString();//单价
                        string cop = nudCopy.Value.ToString();

                        string ywtm = deNo + "-" + proNo;

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
            dataGridViewStock.AutoGenerateColumns = false;

            txtPrinter_TextChanged(null, e);

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

            comboBoxSLocation.Items.Add("无");

            comboBoxSLocation.SelectedIndex = 0;
        }

        private void comboBoxPlant_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBoxSLocation.DataSource = null;

            comboBoxSLocation.Items.Clear();

            DataTable dtStoreLocusList = DBOperate.GetStoreLocusList(string.Empty, comboBoxPlant.SelectedValue.ToString());

            DataRow row = dtStoreLocusList.NewRow();

            row["StoreLocusID"] = 0;
            row["StoreLocusDescription"] = "无";

            dtStoreLocusList.Rows.InsertAt(row, 0);

            comboBoxSLocation.DataSource = dtStoreLocusList;
            comboBoxSLocation.DisplayMember = "StoreLocusDescription";
            comboBoxSLocation.ValueMember = "StoreLocusID";

            comboBoxSLocation.SelectedIndex = 0;
        }

        private void txtPrinter_TextChanged(object sender, EventArgs e)
        {
            DataTable dtPrinterList = DBOperate.GetPrinterList(txtPrinter.Text, "%");
            dataGridViewPrinterList.DataSource = dtPrinterList;
        }

        private void comboBoxPlant_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
