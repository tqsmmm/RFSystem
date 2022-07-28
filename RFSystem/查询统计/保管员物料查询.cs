using System;
using System.Collections;
using System.Data;
using System.Net.Sockets;
using System.Text;
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

                ArrayList alParams = new ArrayList();
                alParams.Add(string.Empty);
                alParams.Add(string.Empty);
                alParams.Add(string.Empty);
                alParams.Add(string.Empty);
                alParams.Add(string.Empty);
                alParams.Add(string.Empty);
                alParams.Add(string.Empty);
                alParams.Add(string.Empty);
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

                ArrayList alParams = new ArrayList();
                alParams.Add(string.Empty);
                alParams.Add(string.Empty);
                alParams.Add(txtMaterial.Text);
                alParams.Add(string.Empty);
                alParams.Add(string.Empty);
                alParams.Add(string.Empty);
                alParams.Add(txtSubPlant.Text);
                alParams.Add(txtPlant.Text);
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
            catch (Exception Ex)
            {
                CommonFunction.Sys_MsgBox(Ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void 保管员物料查询_Load(object sender, EventArgs e)
        {
            txtPrinter_TextChanged(null, e);

            textBoxStoreMan.Text = AppSetter.User_Info.JobID;
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

        private void txtPrinter_TextChanged(object sender, EventArgs e)
        {
            DataTable dtPrinterList = DBOperate.GetPrinterList(txtPrinter.Text, "%");
            dataGridViewPrinterList.DataSource = dtPrinterList;
        }
    }
}
