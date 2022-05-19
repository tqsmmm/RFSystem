namespace DsToExcel
{
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    public class ToExcel
    {
        private DataSet m_Ds;
        private string m_FileName;
        private bool m_IsShowDoing;
        private System.Data.DataTable m_MappingTable = new System.Data.DataTable();
        private string m_TableName;
        private Thread m_Thread;

        public ToExcel()
        {
            this.m_MappingTable.Columns.Add("SourceColumn", typeof(string));
            this.m_MappingTable.Columns.Add("MappingName", typeof(string));
        }

        public void Do()
        {
            if (this.m_Thread == null)
            {
                this.m_Thread = new Thread(new ThreadStart(this.ExportDataToExcel));
            }
            if (this.m_Thread.IsAlive)
            {
                throw new Exception("正在生成Excel文件，请稍候再试");
            }
            this.m_Thread = new Thread(new ThreadStart(this.ExportDataToExcel));
            try
            {
                this.m_Thread.Start();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void ExportDataToExcel()
        {
            try
            {
                this.ExportDataToExcelALL();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "OK", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void ExportDataToExcelALL()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application o = new ApplicationClass();
                Workbook workbook = o.Workbooks.Add(3);
                Worksheet worksheet = null;
                o.DisplayAlerts = false;
                Workbooks workbooks = o.Workbooks;
                workbook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
                worksheet = (Worksheet)workbook.Sheets[1];
                if ((this.m_TableName != null) || (this.m_TableName != ""))
                {
                    worksheet = (Worksheet)workbook.Sheets[1];
                    char[] chArray = new char[2];
                    string str = "";
                    for (int i = 0; i < this.m_Ds.Tables[this.m_TableName].Columns.Count; i++)
                    {
                        if (i < 0x1a)
                        {
                            chArray[0] = Convert.ToChar((int)(0x41 + i));
                        }
                        else
                        {
                            chArray[0] = 'A';
                            chArray[1] = Convert.ToChar((int)((0x41 + i) - 0x1a));
                        }
                        str = chArray[0].ToString();
                        if (chArray[1] != '\0')
                        {
                            str = str + Convert.ToString(chArray[1]);
                        }
                        worksheet.get_Range(Convert.ToString(str) + Convert.ToString(1), Convert.ToString(str) + Convert.ToString(1)).set_Item(1, 1, this.GetColumnName(this.m_Ds.Tables[this.m_TableName].Columns[i].ColumnName.ToString()));
                    }
                    object[,] objArray = new object[this.m_Ds.Tables[this.m_TableName].Rows.Count, this.m_Ds.Tables[this.m_TableName].Columns.Count];
                    for (int j = 0; j < this.m_Ds.Tables[this.m_TableName].Rows.Count; j++)
                    {
                        for (int k = 0; k < this.m_Ds.Tables[this.m_TableName].Columns.Count; k++)
                        {
                            objArray[j, k] = this.m_Ds.Tables[this.m_TableName].Rows[j][k].ToString();
                        }
                    }
                    string str2 = chArray[0].ToString();
                    if (chArray[1] != '\0')
                    {
                        str2 = str2 + Convert.ToString(chArray[1]);
                    }
                    worksheet.get_Range("A2", str2 + Convert.ToString((int)(this.m_Ds.Tables[this.m_TableName].Rows.Count + 1))).Value2 = objArray;
                }
                else
                {
                    for (int m = 1; m < this.m_Ds.Tables.Count; m++)
                    {
                        worksheet = (Worksheet)workbook.Sheets[m];
                        for (int n = 0; n < this.m_Ds.Tables[m - 1].Rows.Count; n++)
                        {
                            for (int num6 = 0; num6 < this.m_Ds.Tables[m - 1].Columns.Count; num6++)
                            {
                                if (this.m_Ds.Tables[m - 1].Rows[n].IsNull(num6))
                                {
                                    worksheet.get_Range(Convert.ToString(Convert.ToChar((int)(0x41 + num6))) + Convert.ToString((int)(n + 2)), Convert.ToString(Convert.ToChar((int)(0x41 + num6))) + Convert.ToString((int)(n + 2))).set_Item(1, 1, "");
                                }
                                else
                                {
                                    worksheet.get_Range(Convert.ToString(Convert.ToChar((int)(0x41 + num6))) + Convert.ToString((int)(n + 2)), Convert.ToString(Convert.ToChar((int)(0x41 + num6))) + Convert.ToString((int)(n + 2))).set_Item(1, 1, "'" + this.m_Ds.Tables[m - 1].Rows[n][num6].ToString());
                                }
                            }
                        }
                    }
                }
                workbook.Close(true, this.m_FileName, Type.Missing);
                if (worksheet != null)
                {
                    Marshal.ReleaseComObject(worksheet);
                }
                worksheet = null;
                if (workbook != null)
                {
                    Marshal.ReleaseComObject(workbook);
                }
                workbook = null;
                if (workbooks != null)
                {
                    Marshal.ReleaseComObject(workbooks);
                }
                workbooks = null;
                o.Visible = false;
                if (o != null)
                {
                    o.Workbooks.Close();
                    o.Quit();
                    Marshal.ReleaseComObject(o);
                    o = null;
                }
                o = null;
                MessageBox.Show("生成成功", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private string GetColumnName(string sourceColunmName)
        {
            foreach (DataRow row in this.m_MappingTable.Rows)
            {
                if (row["SourceColumn"].ToString().Trim().ToUpper() == sourceColunmName.Trim().ToUpper())
                {
                    return row["MappingName"].ToString();
                }
            }
            return sourceColunmName;
        }

        public DataSet DataSource
        {
            get
            {
                return this.m_Ds;
            }
            set
            {
                this.m_Ds = value;
            }
        }

        public string FileName
        {
            get
            {
                return this.m_FileName;
            }
            set
            {
                this.m_FileName = value;
            }
        }

        public bool IsShowDoing
        {
            get
            {
                return this.m_IsShowDoing;
            }
            set
            {
                this.m_IsShowDoing = value;
            }
        }

        public System.Data.DataTable MappingTable
        {
            get
            {
                return this.m_MappingTable;
            }
            set
            {
                this.m_MappingTable = value;
            }
        }

        public string TableName
        {
            get
            {
                return this.m_TableName;
            }
            set
            {
                this.m_TableName = value;
            }
        }
    }
}
