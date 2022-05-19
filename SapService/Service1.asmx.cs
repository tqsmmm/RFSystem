using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace SapService
{
	/// <summary>
	/// Service1 ��ժҪ˵����
	/// </summary>
	/// 

	
	public class AnSteelInterFace : System.Web.Services.WebService
	{
		public static string gLogPath ;
		public Authentication header;
		public static Log log = new Log();
		
		public AnSteelInterFace()
		{
			//CODEGEN: �õ����� ASP.NET Web ����������������
			InitializeComponent();
			
			gLogPath = Server.MapPath("./Log");
		}
		#region �����������ɵĴ���
		
		//Web ����������������
		private IContainer components = null;
				
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		// WEB ����ʾ��
		// HelloWorld() ʾ�����񷵻��ַ��� Hello World
		// ��Ҫ���ɣ���ȡ��ע�������У�Ȼ�󱣴沢������Ŀ
		// ��Ҫ���Դ� Web �����밴 F5 ��

		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public string HelloWorld()
		{
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				return poErrMsg;
			}
			
			return "Hello World";
		}
        [WebMethod]
        public MessagePack queryYwtmByDdWl(string order_no, string product_no, out DataSet ds)
        {
            MessagePack pak = new MessagePack();
            ds = new DataSet();



            clsKCGL cls = new clsKCGL();
            string ErrMsg = "";

            if (0 != cls.queryYwtmByDdWl(order_no, product_no, out ErrMsg, out ds))
            {
                pak.Message = ErrMsg;
                pak.Code = -1;
                return pak;
            }
            pak.Code = 0;
            return pak;

        }


		/// <summary>
		/// ����У���û��ĵ�½���Լ���ȡ�û���Ȩ��
		/// </summary>
		/// <param name="User">�û�ID</param>
		/// <param name="PassWord">�û�����</param>
		/// <param name="PrivateStr">�����û���Ȩ����01111�����û���Ӧ��ģ������Ȩ��</param>
		/// <param name="DbConnStr">����ɹ������ݿ������ַ������ظ��ͻ��ˣ��Է����û�ֱ��ʹ�����ݿ⣬��߲�ѯ�ٶ�</param>
		/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack Login(string User,string PassWord ,out privilidge PrivateStr,out string DbConnStr)
		{
			MessagePack pak= new MessagePack();
			//string PrivateStr, DbConnStr;
			PrivateStr = new privilidge();
			DbConnStr ="";
			
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
				
			}
			
			
			Business bus = new  Business();
			string ErrMsg ="";


            if (0 != bus.Login(User, PassWord, out PrivateStr, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
			DbConnStr = Global.g_ConStr;
			pak.Code =0;
			return pak;
		}

/// <summary>
/// ��ȡ��־�ļ��б�
/// </summary>
/// <param name="poDs">������־�ļ���Ϣ</param>
/// <returns>���سɹ�ʧ����Ϣ��code=0����ɹ�,��������ʧ�ܣ���ʧ�ܵ�����£�message��Ч</returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack SeeLog(out System.Data.DataSet poDs)
		{
			MessagePack pak= new MessagePack();
			poDs= new DataSet();
			
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
				
			}
			string[] files =System.IO.Directory.GetFiles(gLogPath);
			
			System.Data.DataTable dt = new DataTable();
			dt.TableName ="tLog";
			dt.Columns.Add(new DataColumn("fileName"));
			dt.Columns.Add(new DataColumn("Time")); 
			for(int i=0;i< files.Length;i++)
			{
				System.Data.DataRow dr = dt.NewRow();
				dr["Time"] = System.IO.Path.GetFileName(files[i]).Substring(0,System.IO.Path.GetFileName(files[i]).IndexOf("."));
				dr["fileName"] = System.IO.Path.GetFileName(files[i]);
				dt.Rows.Add(dr);
			}
			poDs.Tables.Add(dt);
			pak.Code =0;
			return pak;
			
			
		}



		/// <summary>
		/// ɾ����־�ļ�
		/// </summary>
		/// <param name="fileName">Ҫɾ������־�ļ���</param>
		/// <returns>���سɹ�ʧ����Ϣ��code=0����ɹ�,��������ʧ�ܣ���ʧ�ܵ�����£�message��Ч</returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack DelLog(string fileName)
		{
			MessagePack pak= new MessagePack();
			
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
				
			}
			string fileDel = System.IO.Path.Combine(gLogPath,fileName); 
			System.IO.File.Delete(fileDel);
			pak.Code =0;
			return pak;
			
			
		}





		#region comm
		/// <summary>
		/// ������ȡ��˾�Ϳ��ص�
		/// </summary>
		/// <param name="poDs">���ص㹫˾��Ϣ</param>
		/// <returns>���سɹ�ʧ����Ϣ��code=0����ɹ�,��������ʧ�ܣ���ʧ�ܵ�����£�message��Ч</returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetPlantNSL(out System.Data.DataSet poDs)
		{
			MessagePack pak= new MessagePack();
			 poDs= new DataSet();
			string ErrMsg ="";
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
				
			}
			Business bus = new  Business();
			if(0!=bus.GetPlantNSL(out poDs,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}


	   /// <summary>
	   /// ������ȡ��ӡ���б�
	   /// </summary>
	   /// <param name="poDs">��ӡ���б���Ϣ</param>
	   /// <returns>���سɹ�ʧ����Ϣ��code=0����ɹ�,��������ʧ�ܣ���ʧ�ܵ�����£�message��Ч</returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetPrintList(out System.Data.DataSet poDs)
		{
			MessagePack pak= new MessagePack();
			 poDs= new DataSet();
			string ErrMsg ="";
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return  pak;
				
			}
			Business bus = new  Business();
			if(0!=bus.GetPrintList(out poDs,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}


		#endregion

	
		#region �����ģ��
		/// <summary>
		/// ͨ������Sap�����ţ�����ȡ�ö����Ŷ�Ӧ����Ϣ
		/// </summary>
		/// <param name="PoID">Sap������</param>
		/// <param name="PoType"></param>
		/// <param name="poDs">Sap�ö����Ŷ�Ӧ����Ϣ</param>
		/// <returns>������Ϣ����ȷ�����㣬����Ϊ���㣬������������Ϣ</returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetPoInfo(string PoID,string PoType,bool NeedDetail,out  System.Data.DataSet poDs)
		{
			MessagePack pak= new MessagePack();
			 poDs= new DataSet();
			
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			Business bus = new  Business();
			string ErrMsg ="";

			if(0!=bus.GetPoInfo(header.Username,PoID,PoType,NeedDetail,out poDs ,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}


		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetPoInfoYS(string PoID,string PoType,bool NeedDetail,out  System.Data.DataSet poDs)
		{
			MessagePack pak= new MessagePack();
			poDs= new DataSet();
			
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			Business bus = new  Business();
			string ErrMsg ="";

			if(0!=bus.GetPoInfoYS(header.Username,PoID,PoType,NeedDetail,out poDs ,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}



		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetDGInfo(string PoID,string PoType,bool NeedDetail,out  System.Data.DataSet poDs)
		{
			MessagePack pak= new MessagePack();
			poDs= new DataSet();
			
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return  pak;
				
			}
			Business bus = new  Business();
			string ErrMsg ="";

			if(0!=bus.GetDGInfo(header.Username,PoID,PoType,NeedDetail,out poDs ,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}

		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetSCLLInfo(string PoID,string piType,bool NeedDetail,out System.Data.DataSet poDs)
		{
			MessagePack pak= new MessagePack();
			poDs= new DataSet();
			
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
				
			}
			Business bus = new  Business();
			string ErrMsg ="";

			if(0!=bus.GetSCLLInfo(header.Username,PoID,piType,NeedDetail,out poDs ,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}


		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetPoInfo1(string PoID,string PoType,bool NeedDetail,out  byte[] Stream)
		{
			MessagePack pak= new MessagePack();
			System.Data.DataSet poDs= new DataSet();
			Stream =new byte[0]; 
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
				
			}
			Business bus = new  Business();
			string ErrMsg ="";

			if(0!=bus.GetPoInfo(header.Username,PoID,PoType,NeedDetail,out poDs ,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			Stream=AnComm.Utility.addDataSet(poDs);
			pak.Code =0;
			return pak;
		}


/// <summary>
/// �����ύSap�ĵ�����Ϣ
/// </summary>
/// <param name="PoID"></param>
/// <param name="PoType"></param>
/// <param name="Ds"></param>
/// <param name="DocumentID"></param>
/// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack UpdPoInfo(string PoID, string PoType, System.Data.DataSet Ds,string in_ywtm, out string out_ywtm, out string DocumentID, out string DocDate)
        {     
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            DocDate = "";
            DocumentID = "";
            string ywtm = in_ywtm;
            out_ywtm = ywtm;

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();

            if (0 != bus.UpdPoInfo(header.Username, PoID, PoType, Ds,ref ywtm, out DocumentID, out DocDate, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            out_ywtm = ywtm;
            pak.Code = 0;
            return pak;
        }

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack UpdReceiveInfo(string PoID, string PiType, System.Data.DataSet Ds, out string DocumentID, out string DocDate, string ywtm)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            DocDate = "";
            DocumentID = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            if (0 != bus.UpdReceiveInfo(header.Username, PoID, PiType, Ds, out DocumentID, out DocDate, out ErrMsg, ywtm))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

		


		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack InBound(string piType,ref System.Data.DataSet piDs)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
				
			}
			Business bus = new  Business();
			if(0!=bus.InBound(header.Username,piType,ref piDs,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}



        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack UpdSCLLInfo(string PoID, string PiType, System.Data.DataSet Ds, out string DocumentID, out string DocDate, string ywtm)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            DocumentID = "";
            DocDate = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            if (0 != bus.UpdSCLLInfo(header.Username, PoID, PiType, Ds, out DocumentID, out DocDate, out ErrMsg, ywtm))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

		/// <summary>
		/// ��ȡ����Ԥ������Ϣ
		/// </summary>
		/// <param name="PoID"></param>
		/// <param name="piType"></param>
		/// <param name="NeedDetail"></param>
		/// <param name="poDs"></param>
		/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetBFInfo(string PoID,string piType,bool NeedDetail,out System.Data.DataSet poDs)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			poDs = new DataSet();
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
				
			}
			Business bus = new  Business();
			if(0!=bus.GetBFInfo(header.Username,PoID,piType,NeedDetail, out poDs,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack UpdBF(string ywtm, string DesUser, string PoID, string PiType, System.Data.DataSet Ds, out string DocumentID, out string DocDate)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            DocDate = "";
            DocumentID = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            if (0 != bus.UpdBF(ywtm, header.Username, DesUser, PoID, PiType, Ds, out DocumentID, out DocDate, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack UpdBFCK(string Plant, System.Data.DataSet Ds, out string DocumentID, out string DocDate, string ywtm)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            DocumentID = "";
            DocDate = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            if (0 != bus.UpdBFCK(header.Username, Plant, Ds, out DocumentID, out DocDate, out ErrMsg, ywtm))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetYSTHInfo(string PoID,string piType,bool NeedDetail,out System.Data.DataSet poDs)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			poDs= new DataSet();
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
				
			}
			Business bus = new  Business();
			if(0!=bus.GetYSTHInfo(header.Username,PoID,piType,NeedDetail, out poDs,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}

		/// <summary>
		/// �ύ�����˻�
		/// </summary>
		/// <param name="PoID"></param>
		/// <param name="PiType"></param>
		/// <param name="Ds"></param>
		/// <param name="DocumentID"></param>
		/// <param name="DocDate"></param>
		/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack  UpdYSTHInfo(string PoID,string PiType,System.Data.DataSet Ds,out string DocumentID,out string DocDate)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			DocDate="";
			DocumentID="";
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
				
			}
			Business bus = new  Business();
			if(0!=bus.UpdYSTHInfo(header.Username,PoID,PiType, Ds,out DocumentID,out DocDate,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}

		#endregion

		#region ��ӡģ��
		/// <summary>
		/// ������ȡ�ջ񵥵���Ϣ��Ȼ��ɨ��ǹ�˴�ӡ����
		/// </summary>
		/// <param name="RPo"></param>
		/// <param name="Plant"></param>
		/// <param name="poDs"></param>
		/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack  GetReceiveInfo(string RPo,string Plant,out System.Data.DataSet poDs)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			poDs = new DataSet();
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
				
			}
			Business bus = new  Business();
			if(0!=bus.GetReceiveInfo(header.Username,RPo,Plant,out poDs,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}
		#endregion


		#region �̵�ģ��
		
		
		
		
		/// <summary>
		/// �����жϸ��û������Ƿ���Ҫ �̵�
		/// </summary>
		/// <param name="STOrderInfo">��Ҫ�̵���̵㵥���б�</param>
		/// <returns>���سɹ�ʧ����Ϣ��code=0����ɹ�,��������ʧ�ܣ���ʧ�ܵ�����£�message��Ч</returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetOperatorSTNumber(out System.Data.DataSet STOrderInfo)
		{
			MessagePack pak= new MessagePack();
			STOrderInfo = new DataSet();
			string ErrMsg ="";
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
				
			}
			STOrderInfo = new DataSet();
			Business bus = new Business();
			if(0!=bus.GetOperatorSTNumber(header.Username,out STOrderInfo,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message =ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}


/// <summary>
/// ��ȡ���ϵ����ƣ�����Ա�û�����λ����Ϣ
/// </summary>
/// <param name="STNumber"></param>
/// <param name="Plant"></param>
/// <param name="STLocation"></param>
/// <param name="Bin"></param>
/// <param name="Material"></param>
/// <param name="Charg"></param>
/// <param name="ArtName"></param>
/// <param name="Unit"></param>
/// <param name="Operator"></param>
/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GeMaterialInfo(string STNumber,string Plant,string STLocation,string Bin,string Material,string Charg,out string ArtName,out string Unit,out string Operator)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			ArtName="";
			Operator="";
			Unit ="";
			
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			Business bus = new Business();
			pak.Code =bus.GeMaterialInfo(header.Username,STNumber,Plant,STLocation,Bin,Material,Charg,out ArtName,out Unit,out Operator,out ErrMsg);
			pak.Message = ErrMsg;
			return pak;
			
		}

/// <summary>
/// ��������ĳһ���û���Ӧ��ĳһ���̵�Ŀ����Ϣ
/// </summary>
/// <param name="STNumber"></param>
/// <param name="Stream"></param>
/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack DLOpSTInfo(string STNumber,out byte[] Stream)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			Stream = null;
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			Business bus = new Business();
			if(0!=bus.DLOpSTInfo(header.Username,STNumber,out Stream,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message =ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}

		/// <summary>
		/// �����ύ�̵�����
		/// </summary>
		/// <param name="STNumber"></param>
		/// <param name="piDs"></param>
		/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack InsertBatchMCount(string STNumber,System.Data.DataSet piDs)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			Business bus = new Business();
			if(0!=bus.InsertBatchMCount(header.Username,STNumber,piDs,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message=ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}

/// <summary>
/// ��ʵʱ�̵������£��鿴���̵������
/// </summary>
/// <param name="User"></param>
/// <param name="STNumber"></param>
/// <param name="Ds"></param>
/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GeDoSTJobInfo(string User,string STNumber,out System.Data.DataSet Ds)
		{
			MessagePack pak= new MessagePack();
			Ds = new DataSet();
			string ErrMsg ="";
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			Business bus = new  Business();
			if(0!=bus.GeDoSTJobInfo(header.Username,STNumber,out Ds,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}

/// <summary>
/// ���������̵�ԭʼ���ݵ�����Ŀ
/// </summary>
/// <param name="User"></param>
/// <param name="STNumber"></param>
/// <param name="ItemNo"></param>
/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack UpdateItemStaus(string User,string STNumber,string ItemNo)
		{
			MessagePack pak= new MessagePack();
			
			string ErrMsg ="";
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			Business bus = new  Business();
			if(0!=bus.UpdateItemStaus(header.Username,STNumber,ItemNo,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}

/// <summary>
/// ���̵�����¼�뵽ϵͳ��
/// </summary>
/// <param name="STNumber"></param>
/// <param name="Plant"></param>
/// <param name="STLocation"></param>
/// <param name="Bin"></param>
/// <param name="Material"></param>
/// <param name="Charg"></param>
/// <param name="Operator"></param>
/// <param name="STCount"></param>
/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack InSertMaterialCount(string STNumber,string Plant,string STLocation,string Bin,string Material,string Charg,System.Decimal STCount)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			Business bus = new Business();
			pak.Code =bus.InSertMaterialCount( header.Username,STNumber, Plant, STLocation, Bin, Material, Charg,STCount,out ErrMsg);
			pak.Message = ErrMsg;
			return pak;
			
		}

/// <summary>
/// ��ȡ�ñ���Ա�������̵����񣬲����Ѿ����̵���Ϣ��������������ֶα�ʾ
/// </summary>
/// <param name="STNumber"></param>
/// <param name="Ds"></param>
/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetNeedSTInfo(string STNumber,out System.Data.DataSet Ds)
		{
			MessagePack pak= new MessagePack();
			Ds = new DataSet();
			string ErrMsg ="";
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			Business bus = new  Business();
			if(0!=bus.GetNeedSTInfo(header.Username,STNumber,out Ds,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;

		}

		#region �̵��̨	
		/// <summary>
		/// �����̵�����Ϣ
		/// </summary>
		/// <param name="STNumer"></param>
		/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack DownLoadSTInfo(string STNumber)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
				
			}
			if(LockactiveSync(STNumber,out ErrMsg)!= true)
			{
				pak.Code =-1;
				pak.Message =ErrMsg;
				return pak;
			}
			try
			{
				Business bus = new Business();
				if(0!=bus.DownLoadSTInfo(header.Username,STNumber,out ErrMsg))
				{
					pak.Code = -1;
					pak.Message =ErrMsg;
					return pak;
				}
				
				pak.Code =0;
				return pak;
			}
			finally
			{
				unLockativeSync(STNumber);
			}
		}

		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack UpLoadSTInfo(string STNumber)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
				
			}
			if(LockactiveSync(STNumber,out ErrMsg)!= true)
			{
				pak.Code =-1;
				pak.Message =ErrMsg;
				return pak;
			}
			try
			{
				Business bus = new Business();
				if(0!=bus.UpLoadSTInfo(header.Username,STNumber,out ErrMsg))
				{
					pak.Code = -1;
					pak.Message =ErrMsg;
					return pak;
				}
				
				pak.Code =0;
				return pak;
			}
			finally
			{
				unLockativeSync(STNumber);
			}
		}


		bool LockactiveSync(string piSerial,out string poErrMsg)
		{
			poErrMsg ="";
			Application.Lock();
			string [] lockList = Application.AllKeys;
			for(int i = 0; i < lockList.Length ;i++)
			{
				if(lockList[i] ==piSerial)
				{
					poErrMsg = Application[piSerial].ToString()+"��IP���ڴ����У��㲻�ܽ����������ش���"; 
					return false;
				}
			}
			Application.Add(piSerial,HttpContext.Current.Request.UserHostAddress);  
			Application.UnLock();
			return true;
		}

		void  unLockativeSync(string piSerial)
		{
			try
			{
				Application.Remove( piSerial); 
			}
			catch
			{}
		}

		#endregion
		#endregion

		#region �ƿ�ģ��
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GoodsMoveGetInfo(ref System.Data.DataSet refDs)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			Business bus = new  Business();
			if(0!=bus.GoodsMoveGetInfo(header.Username,ref refDs,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}



		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetGoodsMoveInfo(string Matnr,string Charg,string Werks,string Lgort ,string opType/*��������*/,bool NeedDetail,ref System.Data.DataSet refDs)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
			    
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			
			Business bus = new  Business();
			if(0!=bus.GetYKInfo(header.Username,Matnr,Charg,Werks,Lgort,opType,NeedDetail,out refDs,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}



		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetGoodsMoveInfo1(DataSet ds ,string opType/*��������*/,bool NeedDetail,ref System.Data.DataSet refDs)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			
			Business bus = new  Business();
			if(0!=bus.GetYKInfo(header.Username,ds,opType,NeedDetail,out refDs,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}

/// <summary>
/// ��ȡ����������Ϣ
/// </summary>
/// <param name="ds"></param>
/// <param name="opType"></param>
/// <param name="NeedDetail"></param>
/// <param name="refDs"></param>
/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetBFCKInfo(DataSet ds ,string opType/*��������*/,bool NeedDetail,ref System.Data.DataSet refDs)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			
			Business bus = new  Business();
			if(0!=bus.GetBFCKInfo(header.Username,ds,opType,NeedDetail,out refDs,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}



        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack UpdYKInfo(string PoType, System.Data.DataSet Ds, string ywtm)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();

            if (0 != bus.UpYKInfo(header.Username, PoType, Ds, out ErrMsg, ywtm))
            {
                pak.Code = -1;


                ////				string aa="";
                ////								DataTable dt=Ds.Tables["Detail"];
                ////				foreach(DataRow dr in dt.Rows)
                ////				{
                ////					aa+=dr["Matnr"].ToString()+dr["Charg"].ToString()+dr["Werks"].ToString()+dr["Lgort"].ToString()+"             1: "+dr["Bct50"].ToString()+"     "+dr["Bct51"].ToString()+"   * 2:"+dr["Bct60"].ToString()+"     "+dr["Bct61"].ToString()+"   * 3:"+dr["Bct70"].ToString()+"     "+dr["Bct71"].ToString()+"   ����Ա:"+dr["Bct10"].ToString()+"\r\n";
                ////				}


                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }



		#endregion

		#region ��ѯģ��


		/// <summary>
		/// ��λ��ѯ
		/// </summary>
		/// <param name="BaoGuanYuan"></param>
		/// <param name="HuoWei"></param>
		/// <param name="Lgort"></param>
		/// <param name="Werks"></param>
		/// <param name="cxDs"></param>
		/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetHWCXInfo(string BaoGuanYuan/*����Ա*/,string HuoWei/*��λ*/,string Lgort/*���ص�*/,string Werks/*����*/,out System.Data.DataSet cxDs)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			cxDs=new DataSet();
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
			    
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			
			Business bus = new  Business();
			if(0!=bus.GetHWCXInfo(header.Username,BaoGuanYuan,HuoWei,Lgort,Werks,out cxDs,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}



		/// <summary>
		/// ���β�ѯ
		/// </summary>
		/// <param name="Werks"></param>
		/// <param name="Charg"></param>
		/// <param name="Matnr"></param>
		/// <param name="pccxDs"></param>
		/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetHWPCCXInfo(string BaoGuanyuan,string Werks/*����*/,string Charg/*����*/,string  Matnr/*����*/, out System.Data.DataSet pccxDs)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			pccxDs=new DataSet();
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
			    
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			
			Business bus = new  Business();
			if(0!=bus.GetHWPCCXInfo(header.Username,BaoGuanyuan,Werks,Charg,Matnr,out pccxDs,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}

		/// <summary>
		/// ��ȡ����ƾ֤��Ϣ
		/// </summary>
		/// <param name="Audate"></param>
		/// <param name="DocumentID"></param>
		/// <param name="Ds"></param>
		/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetWLPZInfo(string BaoGuanyuan,string Audate,string DocumentID,out System.Data.DataSet Ds)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			 Ds=new DataSet();
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
			    
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			
			Business bus = new  Business();
			if(0!=bus.GetWLPZInfo(header.Username,BaoGuanyuan,Audate,DocumentID,out Ds,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}
/// <summary>
/// ��ȡ����Ա���ܻ�Ʒ
/// </summary>
/// <param name="BGY"></param>
/// <param name="Ds"></param>
/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetBGYInfo(string BGY,out System.Data.DataSet Ds)
		{
			MessagePack pak= new MessagePack();
			string ErrMsg ="";
			Ds=new DataSet();
			if (!header.ValidUser(header.Username,header.Password)) 
			{ 
				string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";	
			    
				pak.Message = poErrMsg;
				pak.Code =-1;
				return pak;
			}
			
			Business bus = new  Business();
			if(0!=bus.GetBGYInfo(header.Username,BGY,out Ds,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}



		#endregion

		#region ����ģ��

		/// <summary>
		/// ���ݱ���Ա��ȡ��ǰ�ɽ��б����ı�������
		/// </summary>
		/// <param name="storeMan">����Ա</param>
		/// <param name="dsMaintainList">��������Ϣ</param>
		/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetMaintainNum(string storeMan,out System.Data.DataSet dsMaintainList)
		{
			string ErrMsg;
			MessagePack pak= new MessagePack();

			DataTable dtGoodsInfo = new DataTable();
			Business bus = new  Business();
			if(0!=bus.GetMaintainNum(storeMan,out dsMaintainList,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}

		/// <summary>
		/// ��ȡ������Ϣ
		/// </summary>
		/// <param name="maintainNo"></param>
		/// <param name="dsGoodsList"></param>
		/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack GetGoodsInfo(string maintainNo,
			out System.Data.DataSet dsGoodsList)
		{
			string ErrMsg;
			MessagePack pak= new MessagePack();

			DataTable dtGoodsInfo = new DataTable();
			Business bus = new  Business();
			if(0!=bus.GetGoodsInfo(maintainNo,out dsGoodsList,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}

		/// <summary>
		/// �ύ�±����Ļ�������
		/// </summary>
		/// <param name="maintainNum"></param>
		/// <param name="maintainNo"></param>
		/// <param name="barcode"></param>
		/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public MessagePack UpdateMaintainNum(string maintainNum,
			string maintainNo,
			string barcode,string bin)
		{
			string ErrMsg;
			MessagePack pak= new MessagePack();

			Business bus = new  Business();
			if(0!=bus.UpdateMaintainNum(maintainNum,maintainNo,barcode,bin,out ErrMsg))
			{
				pak.Code =-1;
				pak.Message = ErrMsg;
				return pak;
			}
			pak.Code =0;
			return pak;
		}

		/// <summary>
		/// ��������������
		/// </summary>
		/// <param name="maintainNum"></param>
		/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public int MaintainModEnd(string maintainNum)
		{
			string ErrMsg;
			int updateCount = 0;
			Business bus = new  Business();
			updateCount = bus.MaintainModEnd(maintainNum,out ErrMsg);
			if(0!=updateCount)
			{
				return 1;
			}
			return 0;
		}

		/// <summary>
		/// ��鱣����
		/// </summary>
		/// <param name="maintainNum"></param>
		/// <returns></returns>
		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("header")]
		public bool MaintainCompleteCheck(string maintainNum, out string ErrMsg)
		{
			Business bus = new  Business();
			bool ifUnComplete = bus.MaintainCompleteCheck(maintainNum,out ErrMsg);
			return ifUnComplete;
		}

		#endregion

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack getPZH(string ywtm, enumOpType enumopType, out string pzh, out string pznd)
        {
            MessagePack pak = new MessagePack();
            pzh = "";
            pznd = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            clsKCGL cls = new clsKCGL();
            string ErrMsg = "";

            if (0 != cls.getPzh(ywtm, enumopType, out pzh, out pznd, out ErrMsg))
            {
                pak.Message = ErrMsg;
                pak.Code = -1;
                return pak;
            }
            pak.Code = 0;
            return pak;

        }


        #region ��������2015-08

        /// <summary>
        /// ��ѯ�ɹ��ջ���Ϣ
        /// </summary>
        /// <param name="ywtm">һά����</param>
        /// <param name="ds">Sap</param>
        /// <returns>������Ϣ����ȷ�����㣬����Ϊ���㣬������������Ϣ</returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack queryYwtm(string ywtm, enumOpType enumopType, out DataSet ds)
        {
            MessagePack pak = new MessagePack();
            ds = new DataSet();

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            clsKCGL cls = new clsKCGL();
            string ErrMsg = "";

            if (0 != cls.queryYwtm(ywtm, enumopType, out ErrMsg, out ds))
            {
                pak.Message = ErrMsg;
                pak.Code = -1;
                return pak;
            }
            pak.Code = 0;
            return pak;

        }

        /// <summary>
        /// ��ѯ������Ϣ
        /// </summary>
        /// <param name="ywtm"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack queryDd(string ywtm, string pch, enumOpType enumoptype, out DataSet ds)
        {
            MessagePack pak = new MessagePack();
            ds = new DataSet();

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            clsKCGL cls = new clsKCGL();
            string ErrMsg = "";

            if (0 != cls.queryDd(ywtm, pch, enumoptype, out ErrMsg, out ds))
            {
                pak.Message = ErrMsg;
                pak.Code = -1;
                return pak;
            }
            pak.Code = 0;
            return pak;

        }

        /// <summary>
        /// ��ѯһά�����ԭ�ȵ���������Ķ��չ�ϵ������һά���롢�������뼰������Ϣ
        /// </summary>
        /// <param name="ywtm"></param>
        /// <param name="enumoptype"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack queryYwtm_Wltm(string ywtm, enumOpType enumoptype, out DataSet ds)
        {
            MessagePack pak = new MessagePack();
            ds = new DataSet();

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            clsKCGL cls = new clsKCGL();
            string ErrMsg = "";

            if (0 != cls.queryYwtm_Wltm(ywtm, enumoptype, out ErrMsg, out ds))
            {
                pak.Message = ErrMsg;
                pak.Code = -1;
                return pak;
            }
            pak.Code = 0;
            return pak;

        }


        /// <summary>
        /// ��λ��ѯ--���ؿ��ѯ
        /// </summary>
        /// <param name="BaoGuanYuan"></param>
        /// <param name="HuoWei"></param>
        /// <param name="Lgort"></param>
        /// <param name="Werks"></param>
        /// <param name="cxDs"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GetHWCXInfo_RF(string BaoGuanYuan/*����Ա*/, string HuoWei/*��λ*/, string Lgort/*���ص�*/, string Werks/*����*/, out System.Data.DataSet cxDs)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            cxDs = new DataSet();
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";

                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }

            clsKCGL cls = new clsKCGL();
            if (0 != cls.GetHWCXInfo_RF(header.Username, BaoGuanYuan, HuoWei, Lgort, Werks, out cxDs, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public clsYwtm getYwtm(string ywtm)
        {
            return new clsYwtm(ywtm);
        }

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack queryYwtms(string wltms, out DataSet ds)
        {
            MessagePack pak = new MessagePack();
            ds = new DataSet();

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            clsKCGL cls = new clsKCGL();
            string ErrMsg = "";

            if (0 != cls.queryYwtms(wltms, out ErrMsg, out ds))
            {
                pak.Message = ErrMsg;
                pak.Code = -1;
                return pak;
            }
            pak.Code = 0;
            return pak;

        }
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack queryYwtms_s(string pzh, string pznd, out DataSet ds)
        {
            MessagePack pak = new MessagePack();
            ds = new DataSet();

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "��û��Ȩ�޷��ʸ�ģ��";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            clsKCGL cls = new clsKCGL();
            string ErrMsg = "";

            if (0 != cls.queryYwtms_s(pzh, pznd, out ErrMsg, out ds))
            {
                pak.Message = ErrMsg;
                pak.Code = -1;
                return pak;
            }
            pak.Code = 0;
            return pak;

        }

        #endregion
    }
}
