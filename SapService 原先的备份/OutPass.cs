using System;

namespace SapService
{
	/// <summary>
	/// OutPass ��ժҪ˵����
	/// </summary>
	public class OutPass
	{
		public OutPass()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		//�ṩԭʼ�����룬�������������
		public string DbPass(string Password)
		{
			Password=RFdesOperator.getMd5Hash(Password);
			return Password;
		}

       //�ṩSap�û��������ݿ��л�ȡSap����
		public int  SapPass(string SapUser,out string SapPass,out string ErrMsg)
		{
			SapPass ="";
			ErrMsg ="";
			TDB dtb = new TDB(Global.g_ConStr); 
			System.Data.DataTable dt = new System.Data.DataTable();
			if(0!=dtb.OpenDataSet("select * from RF_M_SapUser where SapUserID='"+SapUser+"'",out dt))
			{
				ErrMsg ="��ȡSap�������";
				return -1;
			}
			if(dt.Rows.Count  <=0)
			{
				ErrMsg="Sap�û�������";
				return -1;
			}
			RFdesOperator des = new RFdesOperator();
			des.InputString = dt.Rows[0]["SapPassWord"].ToString() ;
			des.DesDecrypt();
			//des.DecryptKey= 
			SapPass =des.OutString ;
			return 0;

		}
		
      //ͨ���ṩ����Ա�û���������ȡSap���û���������
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
				ErrMsg ="��ȡSap�û���Ϣʧ��";
				return -1;
			}
			if(dt.Rows.Count  <=0)
			{
				ErrMsg="Sap�û�������";
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
