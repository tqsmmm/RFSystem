using System;
using System.IO;
using System.Threading; 
using System.Web.Services; 


namespace SapService
{
	/// <summary>
	/// Globe 的摘要说明。
	/// </summary>
	public class Log
	{
		protected StreamWriter m_LogWriter;
		public Log()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public void WriteLog(string sfunc,string strlog)
		{
			WriteLog(sfunc,4,"T", strlog);
		}

		public  void WriteLog(string sfunc,int ifatal,string stype,string strLog)
		{
			try
			{		
				//lock the file stream object
				Monitor.Enter(this);
				
				
				string strFilePath =  AnSteelInterFace.gLogPath+"\\";
				strFilePath += DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-"+ DateTime.Now.Day.ToString() + ".log";

				if(m_LogWriter == null)
				{
					m_LogWriter = new StreamWriter(strFilePath, true,System.Text.Encoding.Default);
				}

				string strToLog = string.Empty;
				String strTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
				for(int i = 0 ; i < stype.Length ; i++)
				{
					strToLog +=strTime 
						+ "(" + AppDomain.GetCurrentThreadId() + " "+AppDomain.GetCurrentThreadId().ToString("X")  + ")" 
						+ "[" + ifatal.ToString() + "] [" + stype[i].ToString() + "] " + strLog + "|" + sfunc +  " \r\n";
				}
				m_LogWriter.Write(strToLog);
				m_LogWriter.Flush();
				m_LogWriter.Close();
				m_LogWriter = null;
			}
			catch
			{

			}
			finally
			{
				Monitor.Exit(this);
			}
		}

	}
}
