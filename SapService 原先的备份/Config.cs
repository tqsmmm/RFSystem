using System;

namespace SapService
{
	/// <summary>
	/// Config 的摘要说明。
	/// </summary>
	public struct DataBaseConfig
	{
		public  string datasource;
		public  string userid;
		public  string password;
		public  string port;
		public string database;
	}

	public struct SapConfig
	{
		public  string AppServerHost;
		public  string Client;
		public  string Language;
		public  string SystemNumber;
		
	}

}
