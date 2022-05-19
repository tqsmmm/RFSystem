using System;

namespace SapService
{
	/// <summary>
	/// OutPass 的摘要说明。
	/// </summary>
	public class OutPass
	{
		public OutPass()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		//提供原始的密码，计算出加密密码
		public string DbPass(string Password)
		{
			Password=RFdesOperator.getMd5Hash(Password);
			return Password;
		}

       //提供Sap用户，从数据库中获取Sap密码
		public int  SapPass(string SapUser,out string SapPass,out string ErrMsg)
		{
			SapPass ="";
			ErrMsg ="";
			TDB dtb = new TDB(Global.g_ConStr); 
			System.Data.DataTable dt = new System.Data.DataTable();
			if(0!=dtb.OpenDataSet("select * from RF_M_SapUser where SapUserID='"+SapUser+"'",out dt))
			{
				ErrMsg ="获取Sap密码出错";
				return -1;
			}
			if(dt.Rows.Count  <=0)
			{
				ErrMsg="Sap用户不存在";
				return -1;
			}
			RFdesOperator des = new RFdesOperator();
			des.InputString = dt.Rows[0]["SapPassWord"].ToString() ;
			des.DesDecrypt();
			//des.DecryptKey= 
			SapPass =des.OutString ;
			return 0;

		}
		
      //通过提供操作员用户名，来获取Sap的用户名和密码
		public int  DbUserGetSapPass(string DbUser,out string SapUser,out string SapPass,out string ErrMsg)
		{
			SapPass ="";
			SapUser="";
			ErrMsg ="";
			TDB dtb = new TDB(Global.g_ConStr); 
			System.Data.DataTable dt = new System.Data.DataTable();
			string param = TDBObject.ToDBVal(DbUser);
			if(0!=dtb.OpenProcedure("RF_User_GetSapUserInfo",param,out dt))
			{
				ErrMsg ="获取Sap用户信息失败";
				return -1;
			}
			if(dt.Rows.Count  <=0)
			{
				ErrMsg="Sap用户不存在";
				return -1;
			}
			RFdesOperator des = new RFdesOperator();
			des.InputString = dt.Rows[0]["SapPassWord"].ToString() ;
			des.DesDecrypt();
			SapPass =des.OutString ;
			//SapPass = dt.Rows[0]["SapPassWord"].ToString() ;
			SapUser = dt.Rows[0]["SapUserID"].ToString();
			return 0;

		}
	}
}
