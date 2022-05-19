using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

namespace SapService 
{
	/// <summary>
	/// Global ��ժҪ˵����
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public static DataBaseConfig g_Config;
		public static SapConfig g_SapConfig;
		public static string g_ConStr="";
		public static string g_Debug = "";
		


		public Global()
		{
			InitializeComponent();
			g_Config.datasource = System.Configuration.ConfigurationSettings.AppSettings.Get("datasource");
			g_Config.userid = System.Configuration.ConfigurationSettings.AppSettings.Get("userid");
			g_Config.password = System.Configuration.ConfigurationSettings.AppSettings.Get("password");
			g_Config.database = System.Configuration.ConfigurationSettings.AppSettings.Get("database");
			g_Debug = System.Configuration.ConfigurationSettings.AppSettings.Get("debug");  
			
			//Global.g_ConStr = "Provider=SQLOLEDB.1;Data Source=" + g_Config.datasource +";Initial Catalog=";

			Global.g_ConStr = "Provider=SQLOLEDB;Data Source=" + g_Config.datasource +";Initial Catalog=";
			Global.g_ConStr += g_Config.database+";User Id=";
			Global.g_ConStr += g_Config.userid +";";
			Global.g_ConStr += "Password=";
			Global.g_ConStr += g_Config.password +";";
			g_SapConfig.AppServerHost = System.Configuration.ConfigurationSettings.AppSettings.Get("AppServerHost");
			g_SapConfig.Client = System.Configuration.ConfigurationSettings.AppSettings.Get("client");
			g_SapConfig.Language = System.Configuration.ConfigurationSettings.AppSettings.Get("Language");
			g_SapConfig.SystemNumber = System.Configuration.ConfigurationSettings.AppSettings.Get("SystemNumber");

		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

