using System;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 同步盘点单 : Form
    {
        public 同步盘点单()
        {
            InitializeComponent();
        }

        private void 同步盘点单_Load(object sender, EventArgs e)
        {

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                rfid2021Service.rfidService newService = new rfid2021Service.rfidService();
                DataSet _sendDs = new DataSet();

                DataTable _dt = _sendDs.Tables.Add("BODY");

                _dt.Columns.Add("date", typeof(string));
                _dt.Columns["date"].Caption = "创建日期开始";

                _dt.Columns.Add("dateEnd", typeof(string));
                _dt.Columns["dateEnd"].Caption = "创建日期结束";

                DataRow _dr = _dt.NewRow();
                _dr[0] = dateTimePicker1.Value.ToString("yyyyMMdd");
                _dr[1] = dateTimePicker2.Value.ToString("yyyyMMdd");

                _dt.Rows.Add(_dr);

                rfid2021Service.MessagePack pack = newService.sendMsg("DVE160", AppSetter.g_bxuserid, AppSetter.g_bxusername, AppSetter.g_bxjobid, _sendDs, out DataSet _outDs);

                if (pack.Result)
                {
                    txtDownload.Text = _outDs.Tables[0].Rows.Count.ToString();
                    dataGridView1.DataSource = _outDs.Tables[0].DefaultView;
                }
                else
                {
                    CommonFunction.Sys_MsgBox(pack.Message);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    TDB.db.Excute($"INSERT INTO ST_Order_E1DV60(" +
                    $"recCreator," +
                    $"recCreatorName," +
                    $"recCreatorJobId," +
                    $"recCreateTime," +
                    $"recRevisor," +
                    $"recRevisorName," +
                    $"recRevisorJobId," +
                    $"recReviseTime," +
                    $"archiveFlag," +
                    $"archiveTime," +
                    $"internalCode," +
                    $"checkId," +
                    $"status," +
                    $"checkDate," +
                    $"checkUser," +
                    $"checkRemark," +
                    $"confirmJobId," +
                    $"confirmDate," +
                    $"genUser," +
                    $"genDate) VALUES(" +
                    $"'{dataGridView1.SelectedRows[i].Cells[0].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[1].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[2].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[3].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[4].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[5].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[6].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[7].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[8].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[9].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[10].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[11].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[12].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[13].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[14].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[15].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[16].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[17].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[18].Value}'," +
                    $"'{dataGridView1.SelectedRows[i].Cells[19].Value}')");

                    DataSet checkDetail = GetData.Get_65(dataGridView1.SelectedRows[i].Cells["checkId"].Value.ToString());

                    for (int j = 0; j < checkDetail.Tables[0].Rows.Count; j++)
                    {
                        TDB.db.Excute($"INSERT INTO ST_Order_Detail_E1DV65(" +
                            $"[recCreator]," +
                            $"[recCreatorName]," +
                            $"[recCreatorJobId]," +
                            $"[recCreateTime]," +
                            $"[recRevisor]," +
                            $"[recRevisorName]," +
                            $"[recRevisorJobId]," +
                            $"[recReviseTime]," +
                            $"[archiveFlag]," +
                            $"[archiveTime]," +
                            $"[internalCode]," +
                            $"[treansactionId]," +
                            $"[invTransactionId]," +
                            $"[itemId]," +
                            $"[itemName]," +
                            $"[itemDesc]," +
                            $"[itemUom]," +
                            $"[invQty]," +
                            $"[invPrice]," +
                            $"[invTotPrice]," +
                            $"[checkUser]," +
                            $"[checkDate]," +
                            $"[checkQty]," +
                            $"[checkRemark]," +
                            $"[adjustQty]," +
                            $"[adjustType]," +
                            $"[adjustPrice]," +
                            $"[adjustTotPrice]," +
                            $"[invLogicCode]," +
                            $"[invLogicName]," +
                            $"[invPhysicCode]," +
                            $"[invPhysicName]," +
                            $"[invBin]," +
                            $"[itemType]," +
                            $"[masterCatalogId]," +
                            $"[subCatalogId]," +
                            $"[leafCatalogId]," +
                            $"[legacyItemCode]," +
                            $"[priceType]," +
                            $"[areaId]," +
                            $"[areaName]," +
                            $"[invBillTo]," +
                            $"[checkId]," +
                            $"[checkLineId]," +
                            $"[invResponserUserId]," +
                            $"[custodianJobId]," +
                            $"[productionLine]," +
                            $"[depositDate]," +
                            $"[remark]," +
                            $"[invProperty]," +
                            $"[depositType]) VALUES(" +
                            $"'{checkDetail.Tables[0].Rows[i][0]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][1]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][2]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][3]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][4]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][5]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][6]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][7]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][8]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][9]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][10]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][11]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][12]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][13]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][14]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][15]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][16]}'," +
                            $"{checkDetail.Tables[0].Rows[i][17]}," +
                            $"{checkDetail.Tables[0].Rows[i][18]}," +
                            $"{checkDetail.Tables[0].Rows[i][19]}," +
                            $"'{checkDetail.Tables[0].Rows[i][20]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][21]}'," +
                            $"{checkDetail.Tables[0].Rows[i][22]}," +
                            $"'{checkDetail.Tables[0].Rows[i][23]}'," +
                            $"{checkDetail.Tables[0].Rows[i][24]}," +
                            $"'{checkDetail.Tables[0].Rows[i][25]}'," +
                            $"{checkDetail.Tables[0].Rows[i][26]}," +
                            $"{checkDetail.Tables[0].Rows[i][27]}," +
                            $"'{checkDetail.Tables[0].Rows[i][28]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][29]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][30]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][31]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][32]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][33]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][34]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][35]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][36]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][37]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][38]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][39]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][40]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][41]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][42]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][43]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][44]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][45]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][46]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][47]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][48]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][49]}'," +
                            $"'{checkDetail.Tables[0].Rows[i][50]}')");
                    }

                }
            }
        }
    }
}
