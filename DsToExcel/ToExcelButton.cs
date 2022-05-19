using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DsToExcel
{
    public class ToExcelButton : Button
    {
        private DataSet m_Ds;
        private bool m_IsShowDoing;
        private string m_TableName;
        private ToExcel objToExcel;

        public ToExcelButton()
        {
            this.InitializeComponent();
            this.objToExcel = new ToExcel();
            this.Text = "生成Excel";
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {

        }

        protected override void OnClick(EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if ((this.m_Ds == null) || (this.m_Ds.Tables.Count < 1))
            {
                MessageBox.Show("请选择数据源", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                dialog.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (!File.Exists(dialog.FileName))
                    {
                        File.Create(dialog.FileName).Close();
                    }

                    this.objToExcel.TableName = this.m_TableName;
                    this.objToExcel.FileName = dialog.FileName;
                    this.objToExcel.DataSource = this.m_Ds;
                    this.objToExcel.IsShowDoing = this.m_IsShowDoing;

                    try
                    {
                        this.objToExcel.Do();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }

                base.OnClick(e);
            }
        }

        public void SetMapping(Hashtable hs)
        {
            IDictionaryEnumerator enumerator = hs.GetEnumerator();

            while (enumerator.MoveNext())
            {
                DataRow row = this.objToExcel.MappingTable.NewRow();
                row["SourceColumn"] = enumerator.Key.ToString();
                row["MappingName"] = enumerator.Value.ToString();
                this.objToExcel.MappingTable.Rows.Add(row);
            }
        }

        public void SetMapping(DataGrid grid)
        {
            for (int i = 0; i < grid.TableStyles[0].GridColumnStyles.Count; i++)
            {
                DataRow row = this.objToExcel.MappingTable.NewRow();
                row["SourceColumn"] = grid.TableStyles[0].GridColumnStyles[i].MappingName;
                row["MappingName"] = grid.TableStyles[0].GridColumnStyles[i].HeaderText;
                this.objToExcel.MappingTable.Rows.Add(row);
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

        public DataTable MappingTable
        {
            get
            {
                return this.objToExcel.MappingTable;
            }
            set
            {
                this.objToExcel.MappingTable = value;
            }
        }

        public DataSet Source
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
