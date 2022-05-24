using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace DsToExcel
{
    public class ToExcel
    {
        private DataSet m_Ds;
        private string m_FileName;
        private bool m_IsShowDoing;
        private DataTable m_MappingTable = new DataTable();
        private string m_TableName;
        private Thread m_Thread;

        public ToExcel()
        {
            m_MappingTable.Columns.Add("SourceColumn", typeof(string));
            m_MappingTable.Columns.Add("MappingName", typeof(string));
        }

        public void Do()
        {
            if (m_Thread == null)
            {
                m_Thread = new Thread(new ThreadStart(ExportDataToExcel));
            }

            if (m_Thread.IsAlive)
            {
                throw new Exception("正在生成Excel文件，请稍候再试");
            }

            m_Thread = new Thread(new ThreadStart(ExportDataToExcel));

            try
            {
                m_Thread.Start();
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
                ExportDataToExcelALL();
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

        }

        public DataSet DataSource
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

        public string FileName
        {
            get
            {
                return m_FileName;
            }
            set
            {
                m_FileName = value;
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
                return m_MappingTable;
            }
            set
            {
                m_MappingTable = value;
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
