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
            InitializeComponent();
            objToExcel = new ToExcel();
            Text = "生成Excel";
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

            if ((m_Ds == null) || (m_Ds.Tables.Count < 1))
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

                    objToExcel.TableName = m_TableName;
                    objToExcel.FileName = dialog.FileName;
                    objToExcel.DataSource = m_Ds;
                    objToExcel.IsShowDoing = m_IsShowDoing;

                    try
                    {
                        objToExcel.Do();
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
                DataRow row = objToExcel.MappingTable.NewRow();
                row["SourceColumn"] = enumerator.Key.ToString();
                row["MappingName"] = enumerator.Value.ToString();
                objToExcel.MappingTable.Rows.Add(row);
            }
        }

        public void SetMapping(DataGrid grid)
        {
            for (int i = 0; i < grid.TableStyles[0].GridColumnStyles.Count; i++)
            {
                DataRow row = objToExcel.MappingTable.NewRow();
                row["SourceColumn"] = grid.TableStyles[0].GridColumnStyles[i].MappingName;
                row["MappingName"] = grid.TableStyles[0].GridColumnStyles[i].HeaderText;
                objToExcel.MappingTable.Rows.Add(row);
            }
        }

        public bool IsShowDoing
        {
            get
            {
                return m_IsShowDoing;
            }
            set
            {
                m_IsShowDoing = value;
            }
        }

        public DataTable MappingTable
        {
            get
            {
                return objToExcel.MappingTable;
            }
            set
            {
                objToExcel.MappingTable = value;
            }
        }

        public DataSet Source
        {
            get
            {
                return m_Ds;
            }
            set
            {
                m_Ds = value;
            }
        }

        public string TableName
        {
            get
            {
                return m_TableName;
            }
            set
            {
                m_TableName = value;
            }
        }
    }
}
