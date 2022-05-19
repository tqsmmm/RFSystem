using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

namespace SapService
{
    public class clsKCGL
    {

        public int queryYwtmByDdWl(string order_no, string product_no, out string ErrMsg, out DataSet ds)
        {
            ds = new DataSet();
            ErrMsg = "";
            try
            {
                string strsql = "select * from t_take_delivery_ywtm where order_no='" + order_no + "' and product_no='" + product_no + "'";
                System.Data.OleDb.OleDbDataAdapter oda = new System.Data.OleDb.OleDbDataAdapter(strsql, Global.g_ConStr);
                oda.Fill(ds);
                return 0;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return -1;
            }
        }


        /// <summary>
        /// 查询一维条码
        /// </summary>
        /// <param name="ywtm"></param>
        /// <param name="ErrMsg">错误信息</param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int queryYwtm(string ywtm, enumOpType optype, out string ErrMsg, out DataSet ds)
        {
            ds = new DataSet();
            ErrMsg = "";
            try
            {
                string strsql = "";
                switch (optype)
                {
                    case enumOpType.采购收货:
                    case enumOpType.验收入库:
                    case enumOpType.代管入库:
                        //采购收货表
                        strsql = "select ywtm"
                            + " from t_take_delivery_ywtm"
                            + " where ywtm = '" + ywtm + "'";
                        break;
                    default:
                        //case enumOpType.生产领料:
                        //case enumOpType.采购退货:
                        //case enumOpType.库存退货:
                        //case enumOpType.代管出库:
                        //case enumOpType.移至报废库:
                        //case enumOpType.报废出库:
                        //case enumOpType.上架:
                        strsql = "select ywtm,product_barcode,pch"
                            + " from t_stockin_ywtm"
                            + " where ywtm = '" + ywtm + "'";
                        break;

                }
                System.Data.OleDb.OleDbDataAdapter oda = new System.Data.OleDb.OleDbDataAdapter(strsql, Global.g_ConStr);
                oda.Fill(ds);
                return 0;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return -1;
            }
        }

        public int getPzh(string ywtm, enumOpType optype, out string pzh, out string pznd, out string ErrMsg)
        {
            DataSet ds = new DataSet();
            ErrMsg = "";
            pzh = "";
            pznd = "";
            try
            {
                string strsql = "";
                switch (optype)
                {
                    case enumOpType.采购收货:
                    case enumOpType.验收入库:
                    case enumOpType.代管入库:
                        //采购收货表
                        strsql = "select pzh, pznd"
                            + " from t_take_delivery_ywtm"
                            + " where ywtm = '" + ywtm + "'";
                        break;
                    default:
                        strsql = "select pzh, pznd"
                            + " from t_stockin_ywtm"
                            + " where ywtm = '" + ywtm + "'";
                        break;

                }
                System.Data.OleDb.OleDbDataAdapter oda = new System.Data.OleDb.OleDbDataAdapter(strsql, Global.g_ConStr);
                oda.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    ErrMsg = "没找到对应凭证号和凭证年度！";
                    return -1;
                }
                pzh = ds.Tables[0].Rows[0][0].ToString();
                pznd = ds.Tables[0].Rows[0][1].ToString();
                return 0;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return -1;
            }
        }


        public void createYwtm(System.Data.OleDb.OleDbCommand cmd, ref string ywtm, string xtdm, string gch, string ddh, string wlbm, string storeman, string h_no)
        {
            string _ztm = xtdm + gch + ddh + h_no + wlbm;
            string strsql = "";
            string jhcsxh = "";//交货次数序号
            if (ywtm.Trim() != "")
            {
                //xtdm = ywtm.Substring(0, 1);//系统代码
                //gch = ywtm.Substring(1, 4);//工厂号
                //ddh = ywtm.Substring(5, 10);//订单号
                //wlbm = ywtm.Substring(15, 14);//物料编码
                jhcsxh = ywtm.Substring(33, 3);//交货次数序号
            }
            else
            {
                strsql = "select isnull(max(ywtm),'') as ywtm "
                     + " from t_ywtm"
                     + " where xtdm+gch+order_no+h_no+product_no like '" + _ztm + "%'";
                cmd.CommandText = strsql;
                System.Data.OleDb.OleDbDataAdapter oda = new System.Data.OleDb.OleDbDataAdapter();
                oda.SelectCommand = cmd;
                DataTable dt = new DataTable();
                oda.Fill(dt);
                if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString().Trim() != "")
                {
                    string jhcsxh0 = dt.Rows[0][0].ToString().Trim().Substring(33, 3);
                    jhcsxh = (int.Parse(jhcsxh0) + 1).ToString().PadLeft(3, '0');
                }
                else
                {
                    jhcsxh = "001";
                }
                ywtm = _ztm + jhcsxh;
            }

            strsql = "insert into t_ywtm(xtdm,gch ,order_no ,product_no ,jhcsxh ,operator_date ,storeman, h_no)"
                + " values('" + xtdm + "','" + gch + "' ,'" + ddh + "','" + wlbm + "' ,'" + jhcsxh + "',getdate() ,'" + storeman + "', '" + h_no + "')";
            cmd.CommandText = strsql;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 查询订单未清数量等信息(验收入库)
        /// </summary>
        /// <param name="ywtm"></param>
        /// <param name="ErrMsg"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int queryDd(string ywtm, string pch, enumOpType enumoptype, out string ErrMsg, out DataSet ds)
        {
            ds = new DataSet();
            ErrMsg = "";
            string strsql = "";
            try
            {
                switch (enumoptype)
                {
                    case enumOpType.验收入库:
                        strsql = "select t.order_no,t.operator_date,t.storeman,t.pzh,t.pznd,t.product_no,t.qty,t.gch"
                            + " ,isnull(sum(s.qty),0) as rksl,t.qty-isnull(sum(s.qty),0) as wqsl"
                            + " from t_take_delivery_ywtm y"
                            + " inner join t_take_delivery t on t.pzh=y.pzh and t.pznd=y.pznd"
                            + " left join t_stockin_ywtm ys on ys.ywtm=y.ywtm"
                            + " left join t_stockin s on s.pzh=ys.pzh and s.pznd=ys.pznd"
                            + " where (y.ywtm = '" + ywtm + "')"
                            + " group by y.ywtm,t.order_no,t.operator_date,t.storeman,t.pzh,t.pznd,t.product_no,t.qty,t.gch";

                        break;
                    default:
                        //移至报废库
                        //代管出库
                        //生产领料
                        //验收入库
                        //代管入库
                        //采购退货 等
                        strsql = "select ys.operator_date,ys.storeman,ys.product_barcode,ys.ywtm,ys.pch"
                            + " from t_stockin_ywtm ys"
                            + " inner join t_stockin s on s.pzh=ys.pzh and s.pznd=ys.pznd"
                            + " where (ys.ywtm = '" + ywtm + "')"
                            + " order by ys.ywtm,ys.product_barcode";
                        break;

                }

                System.Data.OleDb.OleDbDataAdapter oda = new System.Data.OleDb.OleDbDataAdapter(strsql, Global.g_ConStr);
                oda.Fill(ds);
                return 0;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return -1;
            }
        }

        /// <summary>
        /// 一维条码与原物料条码关联查询
        /// </summary>
        /// <param name="ywtm"></param>
        /// <param name="enumoptype"></param>
        /// <param name="ErrMsg"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int queryYwtm_Wltm(string ywtm, enumOpType enumoptype, out string ErrMsg, out DataSet ds)
        {
            clsYwtm cls_ywtm = new clsYwtm(ywtm);
            ds = new DataSet();
            ErrMsg = "";
            string strsql = "";
            try
            {
                strsql = "select y.ywtm, y.product_barcode,y.pch"
                        + " ,pch=substring(t.product_barcode,5,10)"
                        + " from t_stockin t"
                        + " left join t_stockin_ywtm y on t.product_barcode = y.product_barcode"
                        + " where 1=1";
                if (cls_ywtm.Tmlx == enum条码类型.一维条码)
                {
                    strsql += " and y.ywtm = '" + ywtm + "'";//返回记录>=1条（多个批次）
                }
                else if (cls_ywtm.Tmlx == enum条码类型.原物料条码)
                {
                    strsql += " and t.product_barcode = '" + ywtm + "'";//返回记录1条(一个批次一个条码)
                }
                else
                {
                    ErrMsg = "未识别的条码类型";
                    return -1;
                }
                strsql += " order by t.product_barcode";

                System.Data.OleDb.OleDbDataAdapter oda = new System.Data.OleDb.OleDbDataAdapter(strsql, Global.g_ConStr);
                oda.Fill(ds);
                if (cls_ywtm.Tmlx == enum条码类型.原物料条码 && ds.Tables[0].Rows.Count <= 0)
                {
                    //未查询到物料条码信息时，返回传入的条码
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ywtm");
                    dt.Columns.Add("product_barcode");
                    dt.Columns.Add("pch");
                    DataRow dr = dt.NewRow();
                    dr["ywtm"] = ywtm;
                    dr["product_barcode"] = ywtm;
                    dr["pch"] = cls_ywtm.Pch;
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                }

                return 0;
                //switch (enumoptype)
                //{
                //    case enumOpType.上架:
                //    case enumOpType.生产领料:
                //    case enumOpType.批次查询:
                //    case enumOpType.库存退货:
                //    case enumOpType.实时盘点:
                //    case enumOpType.批处理盘点:
                //    ////strsql = "select y.ywtm, y.product_barcode,y.pch"//t.order_no,t.storeman,t.operator_date,t.pzh,t.pznd,t.bill_type,t.product_barcode,t.product_desc,t.qty,t.gch,t.sl,t.bin1,t.bin1_qty,t.bin2,t.bin2_qty,t.bin3,t.bin3_qty,t.remark"
                //    ////                + " ,pch=substring(t.product_barcode,5,10)"
                //    ////                + " from t_stockin t"
                //    ////                + " left join t_stockin_ywtm y on t.product_barcode = y.product_barcode"
                //    ////                + " where 1=1";
                //    ////    if (cls_ywtm.Tmlx == enum条码类型.一维条码)
                //    ////    {
                //    ////        strsql += " and y.ywtm = '" + ywtm + "'";//返回记录>=1条（多个批次）
                //    ////    }
                //    ////    else if (cls_ywtm.Tmlx == enum条码类型.原物料条码)
                //    ////    {
                //    ////        strsql += " and t.product_barcode = '" + ywtm + "'";//返回记录1条(一个批次一个条码)
                //    ////    }
                //    ////    else
                //    ////    {
                //    ////        ErrMsg = "未识别的条码类型";
                //    ////        return -1;
                //    ////    }
                //    ////    strsql += " order by t.product_barcode";
                ////        break;
                ////    default:
                ////        break;
                ////}
                ////if (strsql != "")
                ////{
                //    System.Data.OleDb.OleDbDataAdapter oda = new System.Data.OleDb.OleDbDataAdapter(strsql, Global.g_ConStr);
                //    oda.Fill(ds);
                //    return 0;
                ////}
                ////else
                ////{
                ////    ErrMsg = "错误的查询类型";
                ////    return -1;
                ////}
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return -1;
            }
        }


        /// <summary>
        /// 得到货物查询信息
        /// </summary>
        /// <param name="User"></param>
        /// <param name="BaoGuanYuan"></param>
        /// <param name="HuoWei"></param>
        /// <param name="Lgort"></param>
        /// <param name="Werks"></param>
        /// <param name="cxDs"></param>
        /// <param name="ErrMsg"></param>
        /// <returns></returns>
        public int GetHWCXInfo_RF(string User, string BaoGuanYuan/*保管员*/, string HuoWei/*货位*/, string Lgort/*库存地点*/, string Werks/*工厂*/, out System.Data.DataSet cxDs, out string ErrMsg)
        {
            OutPass pass = new OutPass();
            string SapUser, SapPass;
            cxDs = new DataSet();


            TDB db = new TDB(Global.g_ConStr);
            System.Data.DataTable dt1 = null;
            if (0 != db.OpenDataSet("select * from RF_Users where User_ID ='" + User + "'", out dt1))
            {
                ErrMsg = "获取用户权限出现错误";
                return -1;
            }
            if (dt1.Rows.Count <= 0)
            {
                ErrMsg = "获取用户权限出现错误";
                return -1;
            }
            if (dt1.Rows[0]["IsAdmin"].ToString().Trim() != "True" && User != BaoGuanYuan)
            {
                ErrMsg = "你不是管理员，无权查询别的保管员保管的物品";
                return -1;
            }


            if (0 != pass.DbUserGetSapPass(User, out SapUser, out SapPass, out ErrMsg))
            {
                return -1;
            }


            #region 构建查询详细表
            System.Data.DataTable Detail = new DataTable();

            Detail.Columns.Add(new DataColumn("Werks"));  //工厂
            Detail.Columns.Add(new DataColumn("Matnr"));  //物料号
            Detail.Columns.Add(new DataColumn("Charg"));  //批号
            Detail.Columns.Add(new DataColumn("Lgort"));  //库存地点
            Detail.Columns.Add(new DataColumn("Maktx"));  //物料描述
            Detail.Columns.Add(new DataColumn("Meins"));  //基本计量单位

            Detail.Columns.Add(new DataColumn("Bct50"));
            Detail.Columns.Add(new DataColumn("Bct51"));

            Detail.Columns.Add(new DataColumn("Bct60"));
            Detail.Columns.Add(new DataColumn("Bct61"));

            Detail.Columns.Add(new DataColumn("Bct70"));
            Detail.Columns.Add(new DataColumn("Bct71"));

            Detail.Columns.Add(new DataColumn("Bct10"));  //保管员代码
            Detail.Columns.Add(new DataColumn("Bct20")); //生产厂代码

            //07-24 myl
            Detail.Columns.Add(new DataColumn("Ebeln"));//采购订单号
            Detail.Columns.Add(new DataColumn("Name1"));
            Detail.Columns.Add(new DataColumn("Ntgew"));
            Detail.Columns.Add(new DataColumn("Verpr"));
            Detail.Columns.Add(new DataColumn("Menge"));
            //Detail.Columns.Add(new DataColumn("Bct20"));


            #endregion

            #region Start Operator
            try
            {
                string strsql = "select t.gch as werks,t.product_no as matnr,t.patch as charg,t.sl as lgort,t.product_desc as Maktx"
                    + " ,t.unit as Meins,t.bin1 as bct50,t.bin1_qty as bct51,t.bin2 as bct60,t.bin2_qty as bct61,t.bin3 as bct70,t.bin3_qty as bct71"
                    + " ,t.storeman as bct10,' ' as bct20,i.order_no as Ebeln,t.supplier as Name1,t.weight as Ntgew,null as Verpr,t.stock_qty as menge"
                    + " from t_stock t"
                    + " left join t_stockin i on i.product_barcode=t.product_barcode"
                    + " where 1=1";
                if (User.Trim() != "") strsql += " and t.storeman like '%" + BaoGuanYuan + "%'";
                if (HuoWei.Trim() != "") strsql += " and (t.bin1 like '%" + HuoWei + "%' or t.bin2 like '%" + HuoWei + "%' or t.bin3 like '%" + HuoWei + "%')";
                if (Lgort.Trim() != "") strsql += " and t.sl ='" + Lgort + "'";
                if (Werks.Trim() != "") strsql += " and t.gch='" + Werks + "'";
                strsql += " order by t.product_no";
                System.Data.OleDb.OleDbDataAdapter oda = new System.Data.OleDb.OleDbDataAdapter(strsql, Global.g_ConStr);
                DataTable dt = new DataTable();
                oda.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    DataRow drNew = Detail.NewRow();
                    drNew["Werks"] = dr["Werks"].ToString();//工厂--gch
                    drNew["Matnr"] = dr["Matnr"].ToString();//物料号--product_no
                    drNew["Charg"] = dr["Charg"].ToString();//批次号--dr["product_barcode"].ToString().Trim().Substring(4,10)
                    drNew["Lgort"] = dr["Lgort"].ToString();//库存地点--sl
                    drNew["Maktx"] = dr["Maktx"].ToString();//物料描述--product_desc
                    drNew["Meins"] = dr["Meins"].ToString();  //基本单位--product_unit

                    drNew["Bct50"] = dr["Bct50"].ToString();//Bin1 //扩展用来表示在枪里面货位1
                    drNew["Bct51"] = dr["Bct51"].ToString();//RBinCount1 //扩展用来表示在枪里面货位1的实发数量
                    drNew["Bct60"] = dr["Bct60"].ToString();//Bin2 //扩展用来表示在枪里面货位2
                    drNew["Bct61"] = dr["Bct61"].ToString();//RBinCount2 //扩展用来表示在枪里面货位2的实发数量
                    drNew["Bct70"] = dr["Bct70"].ToString();//Bin3
                    drNew["Bct71"] = dr["Bct71"].ToString();//RBinCount3

                    drNew["Bct10"] = dr["Bct10"].ToString();//保管员代码 --User
                    drNew["Bct20"] = dr["Bct20"].ToString();//生产厂代码
                    drNew["Ebeln"] = dr["Ebeln"].ToString();//采购订单号
                    drNew["Name1"] = dr["Name1"].ToString();//供应商
                    drNew["Ntgew"] = dr["Ntgew"].ToString();//净重
                    drNew["Verpr"] = dr["Verpr"].ToString();//周期单价
                    drNew["Menge"] = dr["Menge"].ToString();//数量--qty

                    if (dt1.Rows[0]["IsAdmin"].ToString().Trim() != "True")
                    {
                        if (drNew["Bct10"].ToString().Trim() != User)
                        {
                            continue;
                        }
                    }
                    Detail.Rows.Add(drNew);
                }

            #endregion
                if (Detail.Rows.Count <= 0)
                {
                    ErrMsg = "该货位上没有该保管员的货品";
                    return -1;
                }
                Detail.TableName = "Detail";
                cxDs.Tables.Add(Detail);

            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return -1;
            }
            //#endregion

            return 0;
        }

        public int queryYwtms(string wltms, out string ErrMsg, out DataSet ds)
        {
            ds = new DataSet();
            ErrMsg = "";
            try
            {
                string strsql = "select isnull(y.ywtm,'') as ywtm, t.product_barcode,substring(t.product_barcode,5,10) as pch"
                        + " ,t.storeman,t.operator_date as rkrq,t.pzh,t.pznd,isnull(s.supplier,'') as ghdw"
                        + " from t_stockin t"
                        + " left join t_stockin_ywtm y on y.product_barcode = t.product_barcode"
                        + " left join t_stock s on s.product_barcode = t.product_barcode"
                        + " where t.product_barcode in " + wltms
                        + " order by t.product_barcode";

                System.Data.OleDb.OleDbDataAdapter oda = new System.Data.OleDb.OleDbDataAdapter(strsql, Global.g_ConStr);
                oda.Fill(ds);
                return 0;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return -1;
            }
        }
        public int queryYwtms_s(string pzh, string pznd, out string ErrMsg, out DataSet ds)
        {
            ds = new DataSet();
            ErrMsg = "";
            try
            {
                string strsql = "select a.ywtm, b.product_barcode, a.pch, a.storeman, a.operator_date AS rkrq, a.pzh, a.pznd, isnull((select supplier from t_stock where product_barcode = a.product_barcode),'') ghdw from t_stockin_ywtm a, t_stockin b where a.pzh = b.pzh and a.pznd = b.pznd and a.pzh = '" + pzh + "' and a.pznd = '" + pznd + "' union select a.ywtm, gch + product_no, '', '', '', pzh, pznd, ''  from t_take_delivery_ywtm a where pzh = '" + pzh + "' and pznd = '" + pznd + "'";


                System.Data.OleDb.OleDbDataAdapter oda = new System.Data.OleDb.OleDbDataAdapter(strsql, Global.g_ConStr);
                oda.Fill(ds);
                return 0;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return -1;
            }
        }
    }
}

//public int opYwtm(string ywtm, out string ErrMsg)
//{
//    ErrMsg = "";
//    System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(Global.g_ConStr);
//    System.Data.OleDb.OleDbTransaction tran = null;
//    try
//    {
//        if (conn.State != System.Data.ConnectionState.Open)
//        {
//            conn.Open();
//        }
//        tran = conn.BeginTransaction();
//        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
//        cmd.Connection = conn;
//        cmd.Transaction = tran;
//        string commandText = "select ....";
//        cmd.CommandText = commandText;
//        cmd.CommandText = "insert into t_take_delivery(order_no,storeman,pzh,pznd,bill_type,product_no,product_desc,qty,gch,sl,remark) values(?,?,?,?,?,?,?,?,?,?,?)";
//        DB.OleDbDataAdapter adp = new System.Data.OleDb.OleDbDataAdapter();//'@operator_date'
//        System.Data.OleDb.OleDbDataAdapter adp = new System.Data.OleDb.OleDbDataAdapter();
//        adp.InsertCommand = cmd;
//        tran.Commit();


//        return 0;
//    }
//    catch (Exception ex)
//    {
//        ErrMsg = ex.Message;
//        if (tran != null)
//        {
//            tran.Rollback();
//            tran = null;
//        }
//        return -1;
//    }
//    finally
//    {
//        if (conn.State != ConnectionState.Closed)
//        {
//            conn.Close();
//        }
//    }
//}
