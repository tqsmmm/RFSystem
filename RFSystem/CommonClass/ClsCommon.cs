using System;
using System.Collections;
using System.Data;
using RFSystem.AnSteel;

namespace RFSystem
{
    public class ClsCommon
    {
        private static string m_ConnStr;
        private static TDB m_db;

        public static string ConnStr
        {
            get
            {
                return m_ConnStr;
            }
            set
            {
                m_ConnStr = value;
            }
        }

        private static TDB db
        {
            get
            {
                if (m_db == null)
                {
                    m_db = new TDB(m_ConnStr);
                }

                return m_db;
            }
            set
            {

            }
        }

        #region 保养货物、查询保养单

        public static DataTable MaintainGetList_New(ArrayList arriveList)
        {
            string param = "";

            foreach (object obj2 in arriveList)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);
            db.OpenProcedure("RF_Maintain_GetList_New", param, out DataTable dt);

            return dt;
        }

        //转移至历史库
        public static int MaintainItemToHis(DateTime dTime1, DateTime dTime2, string czr)
        {
            try
            {
                db.BeginTrans();

                string param = TDBObject.ToDBVal(dTime1.ToString("yyyy-MM-dd")) + ","
                    + TDBObject.ToDBVal(dTime2.ToString("yyyy-MM-dd 23:59:59")) + ","
                    + TDBObject.ToDBVal(czr);
                db.ExecProcedure("RF_Maintain_ToHis", param);
                db.Commit();

                return 0;
            }
            catch
            {
                db.RollBack();

                return -1;
            }
        }
        #endregion

        //本地数据库查询
        public static DataTable LocalStockGetList_New(ArrayList alParams)
        {
            string param = "";

            foreach (object obj2 in alParams)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);
            //db.OpenProcedure("RF_LocalStock_GetList", param, out dt);
            db.OpenProcedure("RF_LocalStock_GetList_New", param, out DataTable dt);

            return dt;
        }

        public static DataTable LocalStockGetList(ArrayList alParams)
        {
            string param = "";

            foreach (object obj2 in alParams)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);
            //db.OpenProcedure("RF_LocalStock_GetList", param, out dt);
            db.OpenProcedure("rfid2021.dbo.RF_LocalStock_GetList", param, out DataTable dt);

            return dt;
        }

        //工作日志统计
        public static DataSet StatisticInfo_New(string storeMan, string operatorDateFrom, string operatorDateTo)
        {
            string param = TDBObject.ToDBVal(storeMan) + "," + TDBObject.ToDBVal(operatorDateFrom) + "," + TDBObject.ToDBVal(operatorDateTo);
            db.OpenProcedure("RF_Statistic_GetList_New", param, out DataSet ds);

            return ds;
        }

        #region 盘点清单列表
        //查询
        public static int GetSTItem_New(DateTime dTime1, DateTime dTime2, out DataTable dt, out string ErrMsg)
        {
            ErrMsg = "";
            dt = new DataTable();

            if (0 != db.OpenDataSet("SELECT * FROM STOrder WHERE STStatus <> -1 "
                + " AND CONVERT(VARCHAR(10), STCreateDate, 120) >= '" + dTime1.ToString("yyyy-MM-dd") + "' "
                + " AND CONVERT(VARCHAR(10), STCreateDate, 120) <= '" + dTime2.ToString("yyyy-MM-dd") + "' "
                + " ORDER BY STSerial", out dt))
            {
                ErrMsg = "获取盘点列表失败";
                return -1;
            }

            return 0;
        }

        //转移至历史库
        public static int STItemToHis(DateTime dTime1, DateTime dTime2, string czr)
        {
            try
            {
                db.BeginTrans();

                string param = TDBObject.ToDBVal(dTime1.ToString("yyyy-MM-dd")) + ","
                    + TDBObject.ToDBVal(dTime2.ToString("yyyy-MM-dd 23:59:59")) + ","
                    + TDBObject.ToDBVal(czr);

                db.ExecProcedure("STItem_ToHis", param);
                db.Commit();

                return 0;
            }
            catch
            {
                db.RollBack();

                return -1;
            }
        }


        //转移至历史库-单条
        public static int STItemToHis_s(string STSerial, string czr)
        {
            try
            {
                db.BeginTrans();
                db.ExecSQL("insert into STOrderdetail_His(OperatorUser,STSerial,czr,czrq) select OperatorUser,STSerial,'" + czr + "',czrq=getdate() from STOrderdetail where stserial = '" + STSerial + "'");
                db.ExecSQL("insert into STOrder_His(STSerial,STType,STCreateDate,STStatus,STDesc,STCreateUser,Plant,DocumentID,czr,czrq) select STSerial,STType,STCreateDate,STStatus,STDesc,STCreateUser,Plant,DocumentID,'" + czr + "',czrq=getdate() from STOrder where STStatus<>-1 and STSerial = '" + STSerial + "'");
                db.ExecSQL("delete from STOrderDetail where stserial = '" + STSerial + "'");
                db.ExecSQL("delete from STOrder where STStatus<>-1 and STSerial = '" + STSerial + "'");
                db.Commit();

                return 0;
            }
            catch
            {
                db.RollBack();

                return -1;
            }
        }
        #endregion

        public static string dealData(string f, string proName, string proNo, string Patch, string deNo, string ckDate, string manu, string pC, string cert, string supp, string loca, string q, string u, string w, string r, string p, string cop, string ywtm, string baoguanyuan,string RFID)
        {
            string str = "";

            string str2 = f;//产线部门
            string str3 = proName;//物料描述
            string str4 = proNo;//物料号
            string str5 = Patch;//物料名称
            string str7 = deNo;//凭证号
            string str8 = ckDate;//入库日期
            string str9 = manu;//说明书
            string str10 = pC;//送货单号
            string str11 = cert;//合格证
            string str12 = baoguanyuan;//保管员岗位号
            string str13 = supp;//供货单位名称
            string str14 = loca;//储位
            string str15 = q;//储位数量
            string str16 = u;//单位
            string str17 = w;//单重
            string str18 = r;//批次号
            string str19 = p;//单价
            string str20 = cop;

            if (str2.IndexOf("鞍钢股份有限公司") != -1)
            {
                str2 = str2.Substring(("鞍钢股份有限公司").Length);
            }

            if (str3.Length > 35)
            {
                str3 = str3.Substring(0, 35);
            }

            str = str + "@NORMAL\r\n" + "@PAPER;WIDTH 50;LENGTH 99;SPEED IPS 2;INTENSITY 0;LANDSCAPE\r\n" + 
                "@CREATE;ANSTEELLAB\r\n" + "SCALE;DOT;300;300\r\n" + "LOGO\r\n" + "43;380;ANGANG;DISK\r\n" + "STOP\r\n" + "BOX\r\n" + "12;20;22;1100;1740\r\n" + "STOP\r\n" + "HORZ\r\n" + "5;136;22;1740\r\n" + "5;232;22;1740\r\n" + "5;424;22;1740\r\n" + "5;528;22;1740\r\n" + "5;616;22;1740\r\n" + "5;712;22;1740\r\n" + "5;808;22;1740\r\n" + "5;904;22;1740\r\n" + "5;1000;22;1740\r\n" + "5;1096;22;1740\r\n" + "STOP\r\n" + "VERT\r\n" + "5;290;136;1100\r\n" + "5;550;136;232\r\n" + "5;850;424;808\r\n" + "5;710;904;1100\r\n" + "5;750;136;232\r\n" + "5;1100;424;808\r\n" + "5;900;904;1100\r\n" + "5;1150;904;1100\r\n" + "5;1350;904;1100\r\n" + 
                "STOP\r\n" + 
                "FONT;FACE 92250;BOLD ON;SLANT OFF;SYMSET 0\r\n" + "TWOBYTE\r\n";

            //条码
            string _s_tm = ywtm;

            if (ywtm == "")
            {
                //原先的物料条码
                if (string.IsNullOrEmpty(str5))
                    _s_tm = str4;
                else
                    _s_tm = str5 + str4;
            }

            str = str + "POINT;285;300;12;10;'" + _s_tm + "'\r\n";

            str = str + 
                "STOP\r\n" + 
                "FONT;FACE 92250;BOLD ON;SLANT OFF;SYMSET 0\r\n" + "TWOBYTE\r\n" + 
                "POINT;110;500;18;18;'鞍钢股份设备资材采购中心'\r\n" + 
                "POINT;205;55;10;8;'产线部门'\r\n" +
                "POINT;205;300;10;8;'" + str2 + "'\r\n" +
                "POINT;205;570;10;8;'物料描述'\r\n" + 
                "POINT;205;760;10;8;'" + str3 + "'\r\n" + 
                "POINT;345;55;10;8;'设备代码'\r\n" + 
                "POINT;500;55;10;8;'凭证号'\r\n" +
                "POINT;500;300;10;8;'" + str7 + "'\r\n" +
                "POINT;500;870;10;8;'物料号'\r\n" +
                "POINT;500;1120;16;14;'" + str4 + "'\r\n" +
                "POINT;595;55;10;8;'物料名称'\r\n" +
                "POINT;595;300;10;8;'" + str5 + "'\r\n" +
                "POINT;595;870;10;8;'入库日期'\r\n" +
                "POINT;595;1120;10;8;'" + str8 + "'\r\n" +
                "POINT;685;55;10;8;'说明书'\r\n" +
                "POINT;685;300;10;8;'" + str9 + "'\r\n" +
                "POINT;685;870;10;8;'送货单号'\r\n" +
                "POINT;685;1120;10;8;'" + str10 + "'\r\n" +
                "POINT;780;55;10;8;'合格证'\r\n" +
                "POINT;780;300;10;8;'" + str11 + "'\r\n" +
                "POINT;780;870;10;8;'保管员岗位号'\r\n" +
                "POINT;780;1120;10;8;'" + str12 + "'\r\n" +
                "POINT;880;55;10;8;'供货单位名称'\r\n" + 
                "POINT;880;300;10;8;'" + str13 + "'\r\n" + 
                "POINT;970;55;10;8;'储  位'\r\n" +
                "POINT;970;300;10;8;'" + str14 + "'\r\n" +
                "POINT;970;730;10;8;'储位数量'\r\n" +
                "POINT;970;920;10;8;'" + str15 + "'\r\n" +
                "POINT;970;1170;10;8;'批次号'\r\n" +
                "POINT;970;1370;10;8;'" + str18 + "'\r\n" +
                "POINT;1070;55;10;8;'单  位'\r\n" + 
                "POINT;1070;300;10;8;'" + str16 + "'\r\n" +
                "POINT;1070;730;10;8;'单  重'\r\n" +
                "POINT;1070;920;10;8;'" + str17 + "'\r\n" +
                "POINT;1070;1170;10;8;'单　价'\r\n" +
                "POINT;1070;1370;10;8;'" + str19 + "'\r\n" +
                "STOP\r\n" + "BARCODE\r\n" + "C128C;H4.55;DARK;265;300\r\n";

            str = str + "*" + _s_tm + "*\r\n";

            str = str + "PDF;S\r\n" + "STOP\r\n";

            if (RFID.Equals("RFID标签"))
            {
                string old = _s_tm;
                string str22 = (Data_Hex(old) + "000000000000000000000000000000000000").Substring(0, 0x44);
                str = str + "RFWTAG;272;USR\r\n" + "128;H;*" + str22.Substring(0, 0x20) + "*\r\n" + "128;H;*" + str22.Substring(0x20, 0x20) + "*\r\n" + "16;H;*" + str22.Substring(0x40, 4) + "*\r\n" + "STOP\r\n";
            }

            return str + "END\r\n" + "@EXECUTE;ANSTEELLAB;" + str20 + "\r\n" + "@NORMAL\r\n";
        }

        public static string Data_Hex(string old)
        {
            string str;

            try
            {
                int num = 0;
                string str2 = "";

                foreach (char ch in old)
                {
                    num = ch;
                    string str3 = string.Format("{0:x2}", Convert.ToUInt32(num.ToString()));
                    str2 += str3;
                }

                str = str2;
            }
            catch
            {
                //MessageBox.Show("Failed to convert!!! Please check your input format!" + exception.Message);
                str = "Failed to convert";
            }

            return str;
        }

        //public string getBarCode(string ywtm,string pch,ref string srtn)
        //{
        //    //条码查询
        //    DataSet ds = new DataSet();
        //    ClsCommon clscommon = new ClsCommon();
        //    AnSteel.MessagePack mspak = new MessagePack();
        //    //输入条码长度为32位时按一维条码查询，为28位时按原来的物料条码查询
        //    mspak = clscommon.queryYwtm_Wltm(ywtm, AnSteel.enumOpType.批次查询, out ds);    //这处需要改调用的方法
        //    if (mspak.Code != 0)
        //    {
        //        srtn = mspak.Message;
        //        return "";
        //    }
        //    if (ds.Tables[0] == null || ds.Tables[0].Rows.Count <= 0)
        //    {
        //        srtn = "此条码不存在。";
        //        return "";
        //    }

        //    return ds.Tables[0].Rows[0]["product_barcode"].ToString();//一维条码的值，不是原来的物料条码了
        //}

        /// <summary>
        /// 查询一维条码与原先的物料条码对照关系
        /// </summary>
        /// <param name="ywtm"></param>
        /// <returns>0成功；非0失败</returns>
        public MessagePack queryYwtm(string ywtm, enumOpType enumopType, out DataSet ds)
        {
            //验收入库
            //代管入库

            MessagePack mspak = Utility.getSerive().queryYwtm(ywtm, enumopType, out ds);
            return mspak;

        }

        public bool tmlimit_cgsh(string ywtm, ref string err)
        {
            err = "";

            MessagePack mspak = queryYwtm(ywtm, enumOpType.采购收货, out DataSet ds);

            if (mspak.Code != 0)
            {
                err = mspak.Message;
                return false;
            }

            if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                err = "此条码已存在，不能再收货";
                return false;
            }

            return true;
        }

        ///// <summary>
        ///// 生成一维条码
        ///// </summary>
        ///// <param name="xtdm"></param>
        ///// <param name="gch"></param>
        ///// <param name="ddh"></param>
        ///// <param name="wlbm"></param>
        ///// <returns></returns>
        //public string createYwtm(string xtdm, string gch, string ddh, string wlbm, out string errmsg)
        //{
        //    errmsg = "";
        //    AnSteel.MessagePack mspak = new SapDoWork.AnSteel.MessagePack();
        //    mspak = Utility.getSerive().createYwtm(xtdm, gch, ddh, wlbm);
        //    if (mspak.Code == 0)
        //    {
        //        return mspak.Message;
        //    }
        //    else
        //    {
        //        errmsg = mspak.Message;
        //        return "";
        //    }
        //}

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="ywtm"></param>
        /// <returns>0成功；非0失败</returns>
        public MessagePack queryDd(string ywtm, string pch, enumOpType enumoptype, out DataSet ds)
        {
            MessagePack mspak = Utility.getSerive().queryDd(ywtm, pch, enumoptype, out ds);

            return mspak;
        }

        /// <summary>
        /// 查询一维条码和物料条码的对照关系，返回一维条码、物料条码及其它信息
        /// </summary>
        /// <param name="ywtm"></param>
        /// <param name="enumoptype"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public MessagePack queryYwtm_Wltm(string ywtm, enumOpType enumoptype, out DataSet ds)
        {
            MessagePack mspak = Utility.getSerive().queryYwtm_Wltm(ywtm, enumoptype, out ds);

            return mspak;
        }

        /// <summary>
        /// 根据物料条码查询一维条码
        /// </summary>
        /// <param name="ywtm"></param>
        /// <param name="enumopType"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public MessagePack queryYwtms(string wltms, out DataSet ds)
        {
            //验收入库
            //代管入库

            MessagePack mspak = Utility.getSerive().queryYwtms(wltms, out ds);

            return mspak;
        }
    }
}
