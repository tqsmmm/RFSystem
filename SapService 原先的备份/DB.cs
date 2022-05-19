using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace SapService
{
	/// <summary>
	/// TDB ��ժҪ˵����
	/// </summary>
	public class TDB
	{
		protected  OleDbConnection conn ;
		protected  string connectionstring;
		public TDB(string name,string password,string catalog,string serverip)
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			connectionstring = "Provider=SQLOLEDB.1;User ID="+name+";Password="+password+";Initial Catalog="+catalog+";Data Source="+serverip+";Persist Security Info=False;Auto Translate=True;Packet Size=4096;";
			
		}
		public TDB(string ConnStr)
		{
			connectionstring= ConnStr;
		}


		/// <summary>
		/// ������ݿ����,��������ӶϿ�,ϵͳ�Զ���������.
		/// </summary>
		/// <param name="e">�����Ĵ���,�����жϴ�������</param>
//		private  void CheckException(OleDbException e)
//		{
//			//new TLogError(e).SaveExceptionInfo();
//			//if (TLogError.GetDBErrorType(e) == TLogError.CONNECTIONFAIL)
//			//{
//				try
//				{
//					conn.Close();
//
//				}
//				catch(Exception e1)
//				{
//					//new TLogError(e1).SaveExceptionInfo();
//				}
//
//				try
//				{
//					conn.Open();
//				}
//				catch(Exception e2)
//				{
//					//new TLogError(e2).SaveExceptionInfo();
//				}
//			//}
//		}

		/// <summary>
		/// ִ��SQL��ѯ
		/// </summary>
		/// <param name="SQL">Ҫִ�е�SQL���</param>
		/// <param name="ds">�õ�������,����Ϊ��</param>
		/// <returns>0��ʾִ�гɹ�,������ʾ��������</returns>
		public  int OpenDataSet(string SQL, out DataTable dt)
		{
			dt = new DataTable();
			
			if (conn == null)
			{
				conn = new OleDbConnection(connectionstring);
			}

			try
			{
				//System.Threading.Monitor.Enter(m_lock);
				try
				{conn.Open();
					OleDbCommand SelectCMD = new OleDbCommand(SQL, conn);
					SelectCMD.CommandTimeout = 30;

					OleDbDataAdapter da = new OleDbDataAdapter();
					da.SelectCommand = SelectCMD;

					da.Fill(dt);
					return 0;
				}
				catch(OleDbException e)
				{
					AnSteelInterFace.log.WriteLog("OpenDataSet",4,"E",SQL +","+e.Message);
					return -1;
				}
			}
			finally
			{
				if(conn !=null)
				{
					conn.Close();
				}
				//System.Threading.Monitor.Exit(m_lock);
			}
		}

		/// <summary>
		/// ִ��SQL��ѯ
		/// </summary>
		/// <param name="SQL">Ҫִ�е�SQL���</param>
		/// <param name="ds">�õ�������,����Ϊ��</param>
		/// <returns>0��ʾִ�гɹ�,������ʾ��������</returns>
		public int OpenDataSet(string SQL, out DataSet ds)
		{
			ds = new DataSet();

			if (conn == null)
			{
				conn = new OleDbConnection(connectionstring);
			}

			try
			{
				conn.Open();
				try
				{
					OleDbCommand SelectCMD = new OleDbCommand(SQL, conn);
					SelectCMD.CommandTimeout = 30;

					OleDbDataAdapter da = new OleDbDataAdapter();
					da.SelectCommand = SelectCMD;

					da.Fill(ds);
					return 0;
				}
				catch (OleDbException e)
				{
					AnSteelInterFace.log.WriteLog("OpenDataSet",4,"E",SQL +","+e.Message);
					return -1;
				}
			}
			finally
			{
				if(conn !=null)
				{
					conn.Close();
				}
			}
		}

		private object m_lock = new object();
		/// <summary>
		/// ִ��SQL
		/// </summary>
		/// <param name="SQL">Ҫִ�е�SQL���</param>
		/// <param name="ds">�õ�������,����Ϊ��</param>
		/// <returns>0��ʾִ�гɹ�,������ʾ��������</returns>
		public  int ExecSQL(string SQL)
		{
			int ret = 0;
			if (conn == null)
			{
				conn = new OleDbConnection(connectionstring);
			}
			
			try
			{
				
				try
				{
					conn.Open();
					OleDbCommand CMD = new OleDbCommand(SQL, conn);
					CMD.CommandTimeout = 30;
					if (CMD.Connection.State.ToString().Equals("Closed") )
						CMD.Connection.Open();	
	
					ret = CMD.ExecuteNonQuery();

					return ret;

				}
				catch(OleDbException e)
				{
					AnSteelInterFace.log.WriteLog("ExecSQL",4,"E",SQL +","+e.Message);
					return -1;
				}
			}
			finally
			{
				//System.Threading.Monitor.Exit(m_lock);
				if(conn!=null)
				{
					conn.Close();
				}
			}
		}

		/// <summary>
		/// ִ�д洢����
		/// </summary>
		/// <param name="proc">Ҫִ�еĴ洢��������</param>
		/// <param name="param">�洢���̲���</param>
		/// <returns>�洢���̵ķ���ֵ���ߴ������</returns>
		public  int ExecProcedure(string proc, string param)
		{
			string SQL = proc + " " + param;
			return ExecSQL(SQL);
		}

		public int OpenProcedure(string proc, string param, out DataTable dt)
		{
			string SQL = proc + " " + param;
			return OpenDataSet(SQL, out dt);
		}

		public int OpenProcedure(string proc, string param, out DataSet ds)
		{
			string SQL = proc + " " + param;
			return OpenDataSet(SQL, out ds);
		}

		public int ExcuteInsertCommand(System.Collections.ArrayList arrList)
		{
			if (conn == null)
			{
				conn = new OleDbConnection(connectionstring);
			}
			System.Data.OleDb.OleDbTransaction trans = null;
			try
			{
				//System.Threading.Monitor.Enter(m_lock);
				try
				{

					OleDbDataAdapter da = new OleDbDataAdapter();
					if (conn.State == ConnectionState.Closed)
					{
						conn.Open();
					}
					trans= conn.BeginTransaction();
					for (int i = 0; i < arrList.Count; i++)
					{
						da.InsertCommand = (System.Data.OleDb.OleDbCommand)((System.Collections.DictionaryEntry)(arrList[i])).Key;
						da.InsertCommand.Connection = conn;
						da.InsertCommand.Transaction = trans;
						if (((System.Collections.DictionaryEntry)(arrList[i])).Value == null)
						{
							da.InsertCommand.ExecuteNonQuery();
							
						}
						else
						{
							da.Update((System.Data.DataTable)((System.Collections.DictionaryEntry)(arrList[i])).Value);
						}
					}
					trans.Commit();
					return 0;
				}
				catch (OleDbException e)
				{
					if(trans !=null)
						trans.Rollback();
					
				AnSteelInterFace.log.WriteLog("ExecSQL",4,"E","" +","+e.Message);
					return -1;//TLogError.GetDBErrorType(e);
				}
			}
			finally
			{
				if (conn != null)
					conn.Close();
				//System.Threading.Monitor.Exit(m_lock);
			}
		}
	}
}
