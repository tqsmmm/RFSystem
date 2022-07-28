using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 查询物料 : Form
    {
        public DataSet Ds;

        public 查询物料()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string strSql = $"SELECT '' AS BARCODE, " +
                    $"invBillTo AS FACT_NO, " +
                    $"itemId AS PRODUCT_NO, " +
                    $"batchId AS PATCH_NO, " +
                    $"itemName AS PRODUCT_NAME, " +
                    $"itemUom AS UNIT, " +
                    $"invBin AS BIN, " +
                    $"invQty AS BIN_NUM, " +
                    $"invQty AS PLAN_NUM," +
                    $"0 AS MAINTAINNUM, " +
                    $"prodLineDeptId AS SUPPLIER_NO, " +
                    $"unitWeight AS Weight " +
                    $"FROM bx_transaction WHERE 1 = 1 ";

            if (!txtBoxBin.Text.Trim().Equals(string.Empty))
            {
                strSql = $"{strSql} AND transactionId = '{txtBoxBin.Text}' ";
            }

            if (!txtTransactionId.Text.Trim().Equals(string.Empty))
            {
                strSql = $"{strSql} AND BoxBin = '{txtTransactionId.Text}' ";
            }

            if (!textBoxSTOREMAN.Text.Trim().Equals(string.Empty))
            {
                strSql = $"{strSql} AND STOREMAN = '{textBoxSTOREMAN.Text}' ";
            }

            if (TDB.db.OpenDataSet(strSql, out Ds) == 0)
            {
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    dataGridViewSapStockInfo.DataSource = Ds.Tables[0];

                    
                }
            }
            else
            {

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
