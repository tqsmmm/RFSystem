using System;

namespace SapService
{
	/// <summary>
	/// SapOperator 的摘要说明。
	/// </summary>
	public class SapOperator
	{
		//private SapConnector
		private SAP.Connector.Destination Sap_Ds = new SAP.Connector.Destination();
		SAPJob sapJob = new SAPJob();
		public SapOperator(string SapUser,string Password)
		{
			Sap_Ds.AppServerHost = Global.g_SapConfig.AppServerHost;
			Sap_Ds.Client = Convert.ToInt16(Global.g_SapConfig.Client);
			Sap_Ds.Password = Password;
			Sap_Ds.Username = SapUser;
			Sap_Ds.Language = Global.g_SapConfig.Language;
			Sap_Ds.SystemNumber = Convert.ToInt16(Global.g_SapConfig.SystemNumber);
			sapJob.ConnectionString = Sap_Ds.ConnectionString;

		}

		public  SAPJob Functions
		{
			get
			{
				return sapJob;
			}
		}

		public MessagePack Open()
		{
			
			MessagePack pack = new MessagePack();
			try
			{
				if(!sapJob.Connection.IsOpen)
				{
					sapJob.Connection.Open();
				}
				pack.Code =0;
				return pack;
				
			}
			catch(Exception ex)
			{
				pack.Code =-1;
				pack.Message =ex.Message;
				AnSteelInterFace.log.WriteLog("SapOperator.Open",3,"E",ex.Message);
				return pack;
			}
		}

		public MessagePack Close()
		{
			
			MessagePack pack = new MessagePack();
			try
			{
				if(sapJob.Connection.IsOpen)
				{
					sapJob.Connection.Close();
				}
				
				pack.Code =0;
				return pack;
				
			}
			catch(Exception ex)
			{
				pack.Code =-1;
				pack.Message =ex.Message;
				AnSteelInterFace.log.WriteLog("SapOperator.Close",3,"E",ex.Message);
				return pack;
			}
		}

		
	}
}
