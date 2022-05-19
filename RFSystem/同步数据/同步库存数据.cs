using BL;
using RFSystem.CommonClass;
using System;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 同步库存数据 : Form
    {
        DataTable mDt = null;
        int rC = 0;
        int recC = 0;

        public 同步库存数据()
        {
            InitializeComponent();
            dgInit();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (textBoxStoreMan.Text.Trim() == "")
            {
                MessageBox.Show("请输入正确管理员码");
                return;
            }

            DBOperate.clearE1DV11(textBoxStoreMan.Text.Trim());

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                rfid2021Service.rfidService newService = new rfid2021Service.rfidService();
                DataSet _sendDs = new DataSet();

                DataTable _dt = _sendDs.Tables.Add("BODY");

                _dt.Columns.Add("custodianJobId", typeof(string));
                _dt.Columns["custodianJobId"].Caption = "保管员岗位号";

                DataRow _dr = _dt.NewRow();
                _dr[0] = textBoxStoreMan.Text.Trim();

                _dt.Rows.Add(_dr);

                DataSet _outDs;
                rfid2021Service.MessagePack pack = newService.sendMsg("DVE111", ConstDefine.g_bxuserid, ConstDefine.g_bxusername, ConstDefine.g_bxjobid, _sendDs, out _outDs);

                if (pack.Result)
                {
                    rC = Convert.ToInt32(_outDs.Tables[0].Rows[0]["totalNumber"]);
                    label2.Text = "查询到 " + _outDs.Tables[0].Rows[0]["totalNumber"].ToString() + " 条数据，程序将自动刷新收到的数据，将稍等......";
                    timer1.Enabled = true;
                }
                else
                {
                    MessageBox.Show(pack.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mDt = DBOperate.getE1DV11(textBoxStoreMan.Text.Trim());

            if (mDt != null)
            {
                dataGridViewSapStockInfo.DataSource = mDt;
                label3.Text = "接收到 "+mDt.Rows.Count.ToString()+" 条数据";
                recC = mDt.Rows.Count;

                if (rC == recC)
                {
                    btnUpdate.Enabled = true;

                    timer1.Enabled = false;
                }
            }
            else 
            {
                label3.Text = "接收到 0 条数据";
            }
        }

        private void dgInit()
        {
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "送货单行号", DataPropertyName = "deliveryLineId" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "收货单号", DataPropertyName = "receiveId" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "物料代码", DataPropertyName = "itemId" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "物料名称", DataPropertyName = "itemName" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "物料短描述", DataPropertyName = "itemDesc" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "计量单位", DataPropertyName = "itemUom" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "逻辑库区", DataPropertyName = "invLogicCode" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "库存账套", DataPropertyName = "invBillTo" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "送货合格数量", DataPropertyName = "invQualifiedQty" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "库存预约量", DataPropertyName = "invOrQty" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "库存数量", DataPropertyName = "invQty" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "物理库区", DataPropertyName = "invPhysicCode" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "库存责任人", DataPropertyName = "invResponserUserId" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "责任人部门", DataPropertyName = "invResponserDeptId" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "收货日期", DataPropertyName = "accountTime" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "收货人", DataPropertyName = "accountUserId" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "订单行号", DataPropertyName = "orderLineId" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "保管员", DataPropertyName = "custodianJobId" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "验收员", DataPropertyName = "inspectorJobId" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "库存明细交易号", DataPropertyName = "transactionId" });
            dataGridViewSapStockInfo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "库存主表交易号", DataPropertyName = "invTransactionId" });
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (rC < 0 || rC != recC)
            {
                MessageBox.Show("没有接收到数据，或记录数为0");
                return;
            }

            DBOperate.clearbx_transaction(textBoxStoreMan.Text.Trim());

            int updateCount = DBOperate.updateTransaction(textBoxStoreMan.Text.Trim());

            if (updateCount > -1)
            {
                MessageBox.Show("同步成功，同步 " + updateCount + "条数据");
            }
            else
            {
                MessageBox.Show("同步失败");
            }
        }
    }
}
