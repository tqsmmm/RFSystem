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
    /// Service1 的摘要说明。
    /// </summary>
    /// 


    public class AnSteelInterFace : System.Web.Services.WebService
    {
        public static string gLogPath;
        public Authentication header;
        public static Log log = new Log();

        public AnSteelInterFace()
        {
            //CODEGEN: 该调用是 ASP.NET Web 服务设计器所必需的
            InitializeComponent();

            gLogPath = Server.MapPath("./Log");
        }
        #region 组件设计器生成的代码

        //Web 服务设计器所必需的
        private IContainer components = null;

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        // WEB 服务示例
        // HelloWorld() 示例服务返回字符串 Hello World
        // 若要生成，请取消注释下列行，然后保存并生成项目
        // 若要测试此 Web 服务，请按 F5 键

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public string HelloWorld()
        {
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                return poErrMsg;
            }

            return "Hello World";
        }


        /// <summary>
        /// 用来校验用户的登陆，以及获取用户的权限
        /// </summary>
        /// <param name="User">用户ID</param>
        /// <param name="PassWord">用户密码</param>
        /// <param name="PrivateStr">返回用户的权限用01111代表用户对应的模块有无权限</param>
        /// <param name="DbConnStr">如果成功把数据库连接字符串返回给客户端，以方便用户直接使用数据库，提高查询速度</param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack Login(string User, string PassWord, out privilidge PrivateStr, out string DbConnStr)
        {
            MessagePack pak = new MessagePack();
            //string PrivateStr, DbConnStr;
            PrivateStr = new privilidge();
            DbConnStr = "";

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }


            Business bus = new Business();
            string ErrMsg = "";


            if (0 != bus.Login(User, PassWord, out PrivateStr, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            DbConnStr = Global.g_ConStr;
            pak.Code = 0;
            return pak;
        }

        /// <summary>
        /// 获取日志文件列表
        /// </summary>
        /// <param name="poDs">返回日志文件信息</param>
        /// <returns>返回成功失败信息，code=0代表成功,其他代表失败，在失败的情况下，message有效</returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack SeeLog(out System.Data.DataSet poDs)
        {
            MessagePack pak = new MessagePack();
            poDs = new DataSet();

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            string[] files = System.IO.Directory.GetFiles(gLogPath);

            System.Data.DataTable dt = new DataTable();
            dt.TableName = "tLog";
            dt.Columns.Add(new DataColumn("fileName"));
            dt.Columns.Add(new DataColumn("Time"));
            for (int i = 0; i < files.Length; i++)
            {
                System.Data.DataRow dr = dt.NewRow();
                dr["Time"] = System.IO.Path.GetFileName(files[i]).Substring(0, System.IO.Path.GetFileName(files[i]).IndexOf("."));
                dr["fileName"] = System.IO.Path.GetFileName(files[i]);
                dt.Rows.Add(dr);
            }
            poDs.Tables.Add(dt);
            pak.Code = 0;
            return pak;


        }



        /// <summary>
        /// 删除日志文件
        /// </summary>
        /// <param name="fileName">要删除的日志文件名</param>
        /// <returns>返回成功失败信息，code=0代表成功,其他代表失败，在失败的情况下，message有效</returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack DelLog(string fileName)
        {
            MessagePack pak = new MessagePack();

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            string fileDel = System.IO.Path.Combine(gLogPath, fileName);
            System.IO.File.Delete(fileDel);
            pak.Code = 0;
            return pak;


        }





        #region comm
        /// <summary>
        /// 用来获取公司和库存地点
        /// </summary>
        /// <param name="poDs">库存地点公司信息</param>
        /// <returns>返回成功失败信息，code=0代表成功,其他代表失败，在失败的情况下，message有效</returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GetPlantNSL(out System.Data.DataSet poDs)
        {
            MessagePack pak = new MessagePack();
            poDs = new DataSet();
            string ErrMsg = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            if (0 != bus.GetPlantNSL(out poDs, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }


        /// <summary>
        /// 用来获取打印机列表
        /// </summary>
        /// <param name="poDs">打印机列表信息</param>
        /// <returns>返回成功失败信息，code=0代表成功,其他代表失败，在失败的情况下，message有效</returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GetPrintList(out System.Data.DataSet poDs)
        {
            MessagePack pak = new MessagePack();
            poDs = new DataSet();
            string ErrMsg = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            if (0 != bus.GetPrintList(out poDs, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }


        #endregion


        #region 出入库模块
        /// <summary>
        /// 通过输入Sap订单号，来获取该订单号对应的信息
        /// </summary>
        /// <param name="PoID">Sap订单号</param>
        /// <param name="PoType"></param>
        /// <param name="poDs">Sap该订单号对应的信息</param>
        /// <returns>返回信息，正确返回零，错误为非零，并带出错误信息</returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GetPoInfo(string PoID, string PoType, bool NeedDetail, out  System.Data.DataSet poDs)
        {
            MessagePack pak = new MessagePack();
            poDs = new DataSet();

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            Business bus = new Business();
            string ErrMsg = "";

            if (0 != bus.GetPoInfo(header.Username, PoID, PoType, NeedDetail, out poDs, out ErrMsg))
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
        public MessagePack GetPoInfoYS(string PoID, string PoType, bool NeedDetail, out  System.Data.DataSet poDs)
        {
            MessagePack pak = new MessagePack();
            poDs = new DataSet();

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            Business bus = new Business();
            string ErrMsg = "";

            if (0 != bus.GetPoInfoYS(header.Username, PoID, PoType, NeedDetail, out poDs, out ErrMsg))
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
        public MessagePack GetDGInfo(string PoID, string PoType, bool NeedDetail, out  System.Data.DataSet poDs)
        {
            MessagePack pak = new MessagePack();
            poDs = new DataSet();

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            string ErrMsg = "";

            if (0 != bus.GetDGInfo(header.Username, PoID, PoType, NeedDetail, out poDs, out ErrMsg))
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
        public MessagePack GetSCLLInfo(string PoID, string piType, bool NeedDetail, out System.Data.DataSet poDs)
        {
            MessagePack pak = new MessagePack();
            poDs = new DataSet();

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            string ErrMsg = "";

            if (0 != bus.GetSCLLInfo(header.Username, PoID, piType, NeedDetail, out poDs, out ErrMsg))
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
        public MessagePack GetPoInfo1(string PoID, string PoType, bool NeedDetail, out  byte[] Stream)
        {
            MessagePack pak = new MessagePack();
            System.Data.DataSet poDs = new DataSet();
            Stream = new byte[0];
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            string ErrMsg = "";

            if (0 != bus.GetPoInfo(header.Username, PoID, PoType, NeedDetail, out poDs, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            Stream = AnComm.Utility.addDataSet(poDs);
            pak.Code = 0;
            return pak;
        }


        /// <summary>
        /// 用来提交Sap的单据信息
        /// </summary>
        /// <param name="PoID"></param>
        /// <param name="PoType"></param>
        /// <param name="Ds"></param>
        /// <param name="DocumentID"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack UpdPoInfo(string PoID, string PoType, System.Data.DataSet Ds, out string DocumentID, out string DocDate)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            DocDate = "";
            DocumentID = "";

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();

            if (0 != bus.UpdPoInfo(header.Username, PoID, PoType, Ds, out DocumentID, out DocDate, out ErrMsg))
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
        public MessagePack UpdReceiveInfo(string PoID, string PiType, System.Data.DataSet Ds, out string DocumentID, out string DocDate)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            DocDate = "";
            DocumentID = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            if (0 != bus.UpdReceiveInfo(header.Username, PoID, PiType, Ds, out DocumentID, out DocDate, out ErrMsg))
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
        public MessagePack InBound(string piType, ref System.Data.DataSet piDs)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            if (0 != bus.InBound(header.Username, piType, ref piDs, out ErrMsg))
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
        public MessagePack UpdSCLLInfo(string PoID, string PiType, System.Data.DataSet Ds, out string DocumentID, out string DocDate)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            DocumentID = "";
            DocDate = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            if (0 != bus.UpdSCLLInfo(header.Username, PoID, PiType, Ds, out DocumentID, out DocDate, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

        /// <summary>
        /// 获取报废预留单信息
        /// </summary>
        /// <param name="PoID"></param>
        /// <param name="piType"></param>
        /// <param name="NeedDetail"></param>
        /// <param name="poDs"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GetBFInfo(string PoID, string piType, bool NeedDetail, out System.Data.DataSet poDs)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            poDs = new DataSet();
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            if (0 != bus.GetBFInfo(header.Username, PoID, piType, NeedDetail, out poDs, out ErrMsg))
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
        public MessagePack UpdBF(string DesUser, string PoID, string PiType, System.Data.DataSet Ds, out string DocumentID, out string DocDate)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            DocDate = "";
            DocumentID = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            if (0 != bus.UpdBF(header.Username, DesUser, PoID, PiType, Ds, out DocumentID, out DocDate, out ErrMsg))
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
        public MessagePack UpdBFCK(string Plant, System.Data.DataSet Ds, out string DocumentID, out string DocDate)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            DocumentID = "";
            DocDate = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            if (0 != bus.UpdBFCK(header.Username, Plant, Ds, out DocumentID, out DocDate, out ErrMsg))
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
        public MessagePack GetYSTHInfo(string PoID, string piType, bool NeedDetail, out System.Data.DataSet poDs)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            poDs = new DataSet();
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            if (0 != bus.GetYSTHInfo(header.Username, PoID, piType, NeedDetail, out poDs, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

        /// <summary>
        /// 提交验收退货
        /// </summary>
        /// <param name="PoID"></param>
        /// <param name="PiType"></param>
        /// <param name="Ds"></param>
        /// <param name="DocumentID"></param>
        /// <param name="DocDate"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack UpdYSTHInfo(string PoID, string PiType, System.Data.DataSet Ds, out string DocumentID, out string DocDate)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            DocDate = "";
            DocumentID = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            if (0 != bus.UpdYSTHInfo(header.Username, PoID, PiType, Ds, out DocumentID, out DocDate, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

        #endregion

        #region 打印模块
        /// <summary>
        /// 用来获取收获单的信息，然后到扫描枪端打印条码
        /// </summary>
        /// <param name="RPo"></param>
        /// <param name="Plant"></param>
        /// <param name="poDs"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GetReceiveInfo(string RPo, string Plant, out System.Data.DataSet poDs)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            poDs = new DataSet();
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();
            if (0 != bus.GetReceiveInfo(header.Username, RPo, Plant, out poDs, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }
        #endregion


        #region 盘点模块




        /// <summary>
        /// 用来判断该用户本次是否需要 盘点
        /// </summary>
        /// <param name="STOrderInfo">需要盘点的盘点单号列表</param>
        /// <returns>返回成功失败信息，code=0代表成功,其他代表失败，在失败的情况下，message有效</returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GetOperatorSTNumber(out System.Data.DataSet STOrderInfo)
        {
            MessagePack pak = new MessagePack();
            STOrderInfo = new DataSet();
            string ErrMsg = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            STOrderInfo = new DataSet();
            Business bus = new Business();
            if (0 != bus.GetOperatorSTNumber(header.Username, out STOrderInfo, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }


        /// <summary>
        /// 获取物料的名称，操作员用户，单位等信息
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
        public MessagePack GeMaterialInfo(string STNumber, string Plant, string STLocation, string Bin, string Material, string Charg, out string ArtName, out string Unit, out string Operator)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            ArtName = "";
            Operator = "";
            Unit = "";

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            Business bus = new Business();
            pak.Code = bus.GeMaterialInfo(header.Username, STNumber, Plant, STLocation, Bin, Material, Charg, out ArtName, out Unit, out Operator, out ErrMsg);
            pak.Message = ErrMsg;
            return pak;

        }

        /// <summary>
        /// 批量下载某一个用户对应的某一次盘点的库存信息
        /// </summary>
        /// <param name="STNumber"></param>
        /// <param name="Stream"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack DLOpSTInfo(string STNumber, out byte[] Stream)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            Stream = null;
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            Business bus = new Business();
            if (0 != bus.DLOpSTInfo(header.Username, STNumber, out Stream, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

        /// <summary>
        /// 批量提交盘点数据
        /// </summary>
        /// <param name="STNumber"></param>
        /// <param name="piDs"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack InsertBatchMCount(string STNumber, System.Data.DataSet piDs)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            Business bus = new Business();
            if (0 != bus.InsertBatchMCount(header.Username, STNumber, piDs, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

        /// <summary>
        /// 在实时盘点的情况下，查看已盘点的数据
        /// </summary>
        /// <param name="User"></param>
        /// <param name="STNumber"></param>
        /// <param name="Ds"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GeDoSTJobInfo(string User, string STNumber, out System.Data.DataSet Ds)
        {
            MessagePack pak = new MessagePack();
            Ds = new DataSet();
            string ErrMsg = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            Business bus = new Business();
            if (0 != bus.GeDoSTJobInfo(header.Username, STNumber, out Ds, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

        /// <summary>
        /// 用来作废盘点原始数据的行项目
        /// </summary>
        /// <param name="User"></param>
        /// <param name="STNumber"></param>
        /// <param name="ItemNo"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack UpdateItemStaus(string User, string STNumber, string ItemNo)
        {
            MessagePack pak = new MessagePack();

            string ErrMsg = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            Business bus = new Business();
            if (0 != bus.UpdateItemStaus(header.Username, STNumber, ItemNo, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

        /// <summary>
        /// 把盘点数据录入到系统中
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
        public MessagePack InSertMaterialCount(string STNumber, string Plant, string STLocation, string Bin, string Material, string Charg, System.Decimal STCount)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            Business bus = new Business();
            pak.Code = bus.InSertMaterialCount(header.Username, STNumber, Plant, STLocation, Bin, Material, Charg, STCount, out ErrMsg);
            pak.Message = ErrMsg;
            return pak;

        }

        /// <summary>
        /// 获取该保管员的所有盘点任务，并把已经有盘点信息的数据用另外的字段表示
        /// </summary>
        /// <param name="STNumber"></param>
        /// <param name="Ds"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GetNeedSTInfo(string STNumber, out System.Data.DataSet Ds)
        {
            MessagePack pak = new MessagePack();
            Ds = new DataSet();
            string ErrMsg = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            Business bus = new Business();
            if (0 != bus.GetNeedSTInfo(header.Username, STNumber, out Ds, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;

        }

        #region 盘点后台
        /// <summary>
        /// 下载盘点库存信息
        /// </summary>
        /// <param name="STNumer"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack DownLoadSTInfo(string STNumber)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            if (LockactiveSync(STNumber, out ErrMsg) != true)
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            try
            {
                Business bus = new Business();
                if (0 != bus.DownLoadSTInfo(header.Username, STNumber, out ErrMsg))
                {
                    pak.Code = -1;
                    pak.Message = ErrMsg;
                    return pak;
                }

                pak.Code = 0;
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
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            if (LockactiveSync(STNumber, out ErrMsg) != true)
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            try
            {
                Business bus = new Business();
                if (0 != bus.UpLoadSTInfo(header.Username, STNumber, out ErrMsg))
                {
                    pak.Code = -1;
                    pak.Message = ErrMsg;
                    return pak;
                }

                pak.Code = 0;
                return pak;
            }
            finally
            {
                unLockativeSync(STNumber);
            }
        }


        bool LockactiveSync(string piSerial, out string poErrMsg)
        {
            poErrMsg = "";
            Application.Lock();
            string[] lockList = Application.AllKeys;
            for (int i = 0; i < lockList.Length; i++)
            {
                if (lockList[i] == piSerial)
                {
                    poErrMsg = Application[piSerial].ToString() + "该IP正在处理中，你不能进行数据下载处理";
                    return false;
                }
            }
            Application.Add(piSerial, HttpContext.Current.Request.UserHostAddress);
            Application.UnLock();
            return true;
        }

        void unLockativeSync(string piSerial)
        {
            try
            {
                Application.Remove(piSerial);
            }
            catch
            { }
        }

        #endregion
        #endregion

        #region 移库模块
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GoodsMoveGetInfo(ref System.Data.DataSet refDs)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }
            Business bus = new Business();
            if (0 != bus.GoodsMoveGetInfo(header.Username, ref refDs, out ErrMsg))
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
        public MessagePack GetGoodsMoveInfo(string Matnr, string Charg, string Werks, string Lgort, string opType/*操作类型*/, bool NeedDetail, ref System.Data.DataSet refDs)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";

                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }

            Business bus = new Business();
            if (0 != bus.GetYKInfo(header.Username, Matnr, Charg, Werks, Lgort, opType, NeedDetail, out refDs, out ErrMsg))
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
        public MessagePack GetGoodsMoveInfo1(DataSet ds, string opType/*操作类型*/, bool NeedDetail, ref System.Data.DataSet refDs)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }

            Business bus = new Business();
            if (0 != bus.GetYKInfo(header.Username, ds, opType, NeedDetail, out refDs, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

        /// <summary>
        /// 获取报废物料信息
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="opType"></param>
        /// <param name="NeedDetail"></param>
        /// <param name="refDs"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GetBFCKInfo(DataSet ds, string opType/*操作类型*/, bool NeedDetail, ref System.Data.DataSet refDs)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }

            Business bus = new Business();
            if (0 != bus.GetBFCKInfo(header.Username, ds, opType, NeedDetail, out refDs, out ErrMsg))
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
        public MessagePack UpdYKInfo(string PoType, System.Data.DataSet Ds)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";

            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";
                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;

            }
            Business bus = new Business();

            if (0 != bus.UpYKInfo(header.Username, PoType, Ds, out ErrMsg))
            {
                pak.Code = -1;


                ////				string aa="";
                ////								DataTable dt=Ds.Tables["Detail"];
                ////				foreach(DataRow dr in dt.Rows)
                ////				{
                ////					aa+=dr["Matnr"].ToString()+dr["Charg"].ToString()+dr["Werks"].ToString()+dr["Lgort"].ToString()+"             1: "+dr["Bct50"].ToString()+"     "+dr["Bct51"].ToString()+"   * 2:"+dr["Bct60"].ToString()+"     "+dr["Bct61"].ToString()+"   * 3:"+dr["Bct70"].ToString()+"     "+dr["Bct71"].ToString()+"   保管员:"+dr["Bct10"].ToString()+"\r\n";
                ////				}


                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }



        #endregion

        #region 查询模块


        /// <summary>
        /// 货位查询
        /// </summary>
        /// <param name="BaoGuanYuan"></param>
        /// <param name="HuoWei"></param>
        /// <param name="Lgort"></param>
        /// <param name="Werks"></param>
        /// <param name="cxDs"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GetHWCXInfo(string BaoGuanYuan/*保管员*/, string HuoWei/*货位*/, string Lgort/*库存地点*/, string Werks/*工厂*/, out System.Data.DataSet cxDs)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            cxDs = new DataSet();
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";

                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }

            Business bus = new Business();
            if (0 != bus.GetHWCXInfo(header.Username, BaoGuanYuan, HuoWei, Lgort, Werks, out cxDs, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }



        /// <summary>
        /// 批次查询
        /// </summary>
        /// <param name="Werks"></param>
        /// <param name="Charg"></param>
        /// <param name="Matnr"></param>
        /// <param name="pccxDs"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GetHWPCCXInfo(string BaoGuanyuan, string Werks/*工厂*/, string Charg/*批次*/, string Matnr/*物料*/, out System.Data.DataSet pccxDs)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            pccxDs = new DataSet();
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";

                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }

            Business bus = new Business();
            if (0 != bus.GetHWPCCXInfo(header.Username, BaoGuanyuan, Werks, Charg, Matnr, out pccxDs, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

        /// <summary>
        /// 获取物料凭证信息
        /// </summary>
        /// <param name="Audate"></param>
        /// <param name="DocumentID"></param>
        /// <param name="Ds"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GetWLPZInfo(string BaoGuanyuan, string Audate, string DocumentID, out System.Data.DataSet Ds)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            Ds = new DataSet();
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";

                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }

            Business bus = new Business();
            if (0 != bus.GetWLPZInfo(header.Username, BaoGuanyuan, Audate, DocumentID, out Ds, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }
        /// <summary>
        /// 获取保管员保管货品
        /// </summary>
        /// <param name="BGY"></param>
        /// <param name="Ds"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GetBGYInfo(string BGY, out System.Data.DataSet Ds)
        {
            MessagePack pak = new MessagePack();
            string ErrMsg = "";
            Ds = new DataSet();
            if (!header.ValidUser(header.Username, header.Password))
            {
                string poErrMsg = "你没有权限访问该模块";

                pak.Message = poErrMsg;
                pak.Code = -1;
                return pak;
            }

            Business bus = new Business();
            if (0 != bus.GetBGYInfo(header.Username, BGY, out Ds, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }



        #endregion

        #region 保养模块

        /// <summary>
        /// 根据保养员获取当前可进行保养的保养单号
        /// </summary>
        /// <param name="storeMan">保养员</param>
        /// <param name="dsMaintainList">保养单信息</param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack GetMaintainNum(string storeMan, out System.Data.DataSet dsMaintainList)
        {
            string ErrMsg;
            MessagePack pak = new MessagePack();

            DataTable dtGoodsInfo = new DataTable();
            Business bus = new Business();
            if (0 != bus.GetMaintainNum(storeMan, out dsMaintainList, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

        /// <summary>
        /// 获取货物信息
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
            MessagePack pak = new MessagePack();

            DataTable dtGoodsInfo = new DataTable();
            Business bus = new Business();
            if (0 != bus.GetGoodsInfo(maintainNo, out dsGoodsList, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

        /// <summary>
        /// 提交新保养的货物数量
        /// </summary>
        /// <param name="maintainNum"></param>
        /// <param name="maintainNo"></param>
        /// <param name="barcode"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public MessagePack UpdateMaintainNum(string maintainNum,
            string maintainNo,
            string barcode, string bin)
        {
            string ErrMsg;
            MessagePack pak = new MessagePack();

            Business bus = new Business();
            if (0 != bus.UpdateMaintainNum(maintainNum, maintainNo, barcode, bin, out ErrMsg))
            {
                pak.Code = -1;
                pak.Message = ErrMsg;
                return pak;
            }
            pak.Code = 0;
            return pak;
        }

        /// <summary>
        /// 结束保养单保养
        /// </summary>
        /// <param name="maintainNum"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public int MaintainModEnd(string maintainNum)
        {
            string ErrMsg;
            int updateCount = 0;
            Business bus = new Business();
            updateCount = bus.MaintainModEnd(maintainNum, out ErrMsg);
            if (0 != updateCount)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 检查保养单
        /// </summary>
        /// <param name="maintainNum"></param>
        /// <returns></returns>
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("header")]
        public bool MaintainCompleteCheck(string maintainNum, out string ErrMsg)
        {
            Business bus = new Business();
            bool ifUnComplete = bus.MaintainCompleteCheck(maintainNum, out ErrMsg);
            return ifUnComplete;
        }

        #endregion
    }
}
