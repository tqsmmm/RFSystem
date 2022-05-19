#define isSaveHistoryData  //是否保存历史记录
#define isSaveNewCharg     //移至报废库的时候是否需要根据返回的物料凭证取得相应的物料新的批次
using System;
using System.Data;
using System.Data.OleDb;

using System.Collections;
namespace SapService
{
	/// <summary>
	/// Business 的摘要说明。
	/// </summary>
	public class Business
	{
		
		public Business()
		{
			//
			// TODO: 在此处添加构造函数逻辑

			//
			
		}


		#region comm
		/// <summary>
		/// 获取工厂号列表以及库存地点列表
		/// </summary>
		/// <param name="poDs"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int GetPlantNSL(out System.Data.DataSet poDs,out string ErrMsg)
		{
			ErrMsg ="";
			poDs = new DataSet();
			System.Data.DataTable dt = new DataTable();
			System.Data.DataTable dt1 = new DataTable();
			TDB db = new TDB(Global.g_ConStr);
			if(0!=db.OpenDataSet("select * from RF_M_Plant",out dt))
			{
				ErrMsg ="获取工厂信息失败";
				return -1;
			}
			if(0!=db.OpenDataSet("select * from RF_M_StoreLocus",out dt1))
			{
				ErrMsg ="获取库存地点信息失败";
				return -1;
			}
			dt.TableName = "RF_M_Plant";
			dt1.TableName ="RF_M_StoreLocus";
			poDs.Tables.Add(dt);
			poDs.Tables.Add(dt1);
			return 0;
		}

		/// <summary>
		/// 获取打印机列表
		/// </summary>
		/// <param name="poDs"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int GetPrintList(out System.Data.DataSet poDs,out string ErrMsg)
		{
			ErrMsg ="";
			poDs = new DataSet();
			System.Data.DataTable dt = new DataTable();
			TDB db = new TDB(Global.g_ConStr);
			if(0!=db.OpenDataSet("select * from RF_M_Printer",out dt))
			{
				ErrMsg ="获取打印机信息失败";
				return -1;
			}
			
			poDs.Tables.Add(dt);
			return 0;
		}
		#endregion

		#region 登录模块
		//登录
		public int Login(string User,string Pass,out privilidge PrivateStr,out string ErrMsg)
		{
			
			PrivateStr =new privilidge();
			ErrMsg ="";

			OutPass pass = new OutPass();
			Pass=pass.DbPass(Pass);


			TDB db = new TDB(Global.g_ConStr);
			string Parm = TDBObject.ToDBVal(User)+",";
			Parm += TDBObject.ToDBVal(Pass);
			System.Data.DataSet  dt1 = new DataSet();
			try
			{
				if(-1==db.OpenProcedure("RF_User_GetByLogin",Parm,out dt1))
				{
					ErrMsg ="用户登录失败";
					return -1;
				}
			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			if(dt1.Tables[0].Rows.Count <=0)
			{
				ErrMsg="用户名或密码不正确";
				return -1;
			}
			
			
			System.Data.DataTable dt = new DataTable();
			if(0!=db.OpenDataSet("select * from RF_UserRoles where User_ID ='"+User+"'",out dt))
			{
				ErrMsg ="获取用户权限出现错误";
				return -1;
			}
			//myl 2008-08-14 
			System.Data.DataTable dtIsAdmin =null;
			if(0!=db.OpenDataSet("select * from RF_Users where User_ID ='"+User+"'",out dtIsAdmin))
			{
				ErrMsg ="获取用户权限出现错误";
				return -1;
			}
			if(dtIsAdmin.Rows.Count <=0)
			{
				ErrMsg ="获取用户权限出现错误";
				return -1;
			}

			if(dtIsAdmin.Rows[0]["IsAdmin"].ToString().Trim()=="True")
			{
				PrivateStr.isAdmin=true;
			}
			else
			{
				PrivateStr.isAdmin=false;
			}
			//
			//


			System.Data.DataRow[] drs = dt.Select("RoleID='DiscardAsUseless'");
			if(drs.Length <=0) //报废
			{
				PrivateStr.BF ="0";
			}
			else
			{
				PrivateStr.BF ="1";
			}
			drs = dt.Select("RoleID='StockCheckAndEnterStore'");
			if(drs.Length <=0) //采购入库
			{
				PrivateStr.CGRK ="0";
			}
			else
			{
				PrivateStr.CGRK ="1";
			}

			drs = dt.Select("RoleID='StockReceive'");
			if(drs.Length <=0) //采购收货
			{
				PrivateStr.CGSH ="0";
			}
			else
			{
				PrivateStr.CGSH ="1";
			}


			drs = dt.Select("RoleID='SupplyEnterStore'");
			if(drs.Length <=0) //代管入库
			{
				PrivateStr.DGRK ="0";
			}
			else
			{
				PrivateStr.DGRK ="1";
			}


			drs = dt.Select("RoleID='StoreMakeInventory'");
			if(drs.Length <=0) //盘点
			{
				PrivateStr.PANDIAN ="0";
			}
			else
			{
				PrivateStr.PANDIAN ="1";
			}


			drs = dt.Select("RoleID='GoodsPositionBarCodePrint'");
			if(drs.Length <=0) //打印货位
			{
				PrivateStr.PrintBin ="0";
			}
			else
			{
				PrivateStr.PrintBin ="1";
			}


			drs = dt.Select("RoleID='MaterielBarCodePrint'");
			if(drs.Length <=0) //打印物料标签
			{
				PrivateStr.PrintLabel ="0";
			}
			else
			{
				PrivateStr.PrintLabel ="1";
			}


			drs = dt.Select("RoleID='ManufactureReceiveMaterial'");
			if(drs.Length <=0) //生产领料
			{
				PrivateStr.SCLL ="0";
			}
			else
			{
				PrivateStr.SCLL ="1";
			}


			drs = dt.Select("RoleID='UntreadGoods'");
			if(drs.Length <=0) //退货
			{
				PrivateStr.TH ="0";
			}
			else
			{
				PrivateStr.TH ="1";
			}

			drs = dt.Select("RoleID='ArriveStoreException'");
			if(drs.Length <=0) //异议入库
			{
				PrivateStr.YCRK ="0";
			}
			else
			{
				PrivateStr.YCRK ="1";
			}


			drs = dt.Select("RoleID='GoodsPositionRemove'");
			if(drs.Length <=0) //移库
			{
				PrivateStr.YK ="0";
			}
			else
			{
				PrivateStr.YK ="1";
			}


			drs = dt.Select("RoleID='StoreInfoSeeAbout'");
			if(drs.Length <=0) //查询
			{
				PrivateStr.YK ="0";
			}
			else
			{
				PrivateStr.YK ="1";
			}

			drs = dt.Select("RoleID='UpShelf'");
			if(drs.Length <=0) //上架
			{
				PrivateStr.SJ ="0";
			}
			else
			{
				PrivateStr.SJ ="1";
			}

			drs = dt.Select("RoleID='SupplyLeaveStore'");
			if(drs.Length <=0) //代保管出库
			{
				PrivateStr.DBGCK ="0";
			}
			else
			{
				PrivateStr.DBGCK ="1";
			}
			
			drs = dt.Select("RoleID='BinQuery'");
			if(drs.Length <=0) //货位查询
			{
				PrivateStr.HWCX ="0";
			}
			else
			{
				PrivateStr.HWCX ="1";
			}

			drs = dt.Select("RoleID='PatchQuery'");
			if(drs.Length <=0) //批次查询
			{
				PrivateStr.PCCX ="0";
			}
			else
			{
				PrivateStr.PCCX ="1";
			}

			drs = dt.Select("RoleID='MaintainQuery'");
			if(drs.Length <=0) //货位查询
			{
				PrivateStr.BYD ="0";
			}
			else
			{
				PrivateStr.BYD ="1";
			}
			
			drs = dt.Select("RoleID='105UntreadGoods'");
			if(drs.Length <=0) //库存退货
			{
				PrivateStr.KCTH ="0";
			}
			else
			{
				PrivateStr.KCTH ="1";
			}

			drs = dt.Select("RoleID='103UntreadGoods'");
			if(drs.Length <=0) //冻结库退货
			{
				PrivateStr.DJKTH ="0";
			}
			else
			{
				PrivateStr.DJKTH ="1";
			}

			//2008-09-04

			PrivateStr.ServerTime=System.DateTime.Now;

			//drs= dt.Select("RoleID='"

			return 0;
		}
		#endregion

		#region 出入库模块

		/// <summary>
		/// 获取Sap入库的单据的信息
		/// </summary>
		/// <param name="User"></param>
		/// <param name="PoID"></param>
		/// <param name="PoType"></param>
		/// <param name="poDs"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int GetPoInfo(string User,string PoID,string piType,bool NeedDetail,out System.Data.DataSet poDs,out string ErrMsg)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			poDs = new DataSet();
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);
			SapService.ZSMM_RFC_PODTable po_Detail  =new ZSMM_RFC_PODTable();
			SapService.ZSMM_RFC_POD po_DetailItem = new ZSMM_RFC_POD();
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			SapService.BAPIRET2 Return0Item = new BAPIRET2();
			
			string ID ="";
			if(piType =="采购收货")
			{
				ID ="103";
			}
			else if(piType =="验收入库")
			{
				ID ="105";
			}
						
			string Ekgrp; //采购组
			string Ekorg; //采购组织
			string lifnr; //供应商编号
			string Name1;//供应商名称
			string Ernam="";//制单员号
			string Name_TextC="";//制单员名字
			

			string Returncode =""; //返回值
			#region 构建头表
			System.Data.DataTable Head = new DataTable();
			Head.Columns.Add(new DataColumn("name_TextC")); 
			Head.Columns.Add(new DataColumn("ERNAM")); 
			Head.Columns.Add(new DataColumn("Ekgrp")); 

			Head.Columns.Add(new DataColumn("Ekorg")); 
			Head.Columns.Add(new DataColumn("lifnr")); 
			Head.Columns.Add(new DataColumn("Name1")); 
			#endregion

			#region 构建详细表
			System.Data.DataTable Detail = new DataTable();

			Detail.Columns.Add(new DataColumn("Ebeln"));   //采购订单号
			Detail.Columns.Add(new DataColumn("Ebelp",Type.GetType("System.Int32")));   //采购订单行项目
			Detail.Columns.Add(new DataColumn("Werks"));  //工厂号
			Detail.Columns.Add(new DataColumn("Lgort"));  //库存地点
			//测试使用的 S
			//			if(piType=="移至报废库")
			//			{
			//				Detail.Columns.Add(new DataColumn("Bukrs")); 
			//				Detail.Columns.Add(new DataColumn("Charg"));  //批次
			//				Detail.Columns.Add(new DataColumn("Lgort1"));  //目标库存地点
			//			}
			//			if(piType=="生产领料")
			//			{
			//				Detail.Columns.Add(new DataColumn("Bukrs")); 
			//				Detail.Columns.Add(new DataColumn("Charg"));  //批次
			//			}
			//测试使用的 e

			Detail.Columns.Add(new DataColumn("Matnr"));  //物料号
			Detail.Columns.Add(new DataColumn("Txz01"));  //物料描述
			Detail.Columns.Add(new DataColumn("Meins"));  //基本单位
			Detail.Columns.Add(new DataColumn("Menge",Type.GetType("System.Decimal"))); //订单数量
			Detail.Columns.Add(new DataColumn("Netpr",Type.GetType("System.Decimal")));//单价
			Detail.Columns.Add(new DataColumn("Mengw",Type.GetType("System.Decimal")));//未清数量
			Detail.Columns.Add(new DataColumn("Receive",Type.GetType("System.Decimal")));//扩展用来表示在枪里面收取的数量
			if(ID =="105")
			{
				Detail.Columns.Add(new DataColumn("Bin1"));//扩展用来表示在枪里面货位1
				Detail.Columns.Add(new DataColumn("BinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的实发数量
				//Detail.Columns.Add(new DataColumn("RBinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的库存里面有的数量
			
				Detail.Columns.Add(new DataColumn("Bin2"));//扩展用来表示在枪里面货位2
				Detail.Columns.Add(new DataColumn("BinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的实发数量
				//Detail.Columns.Add(new DataColumn("RBinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的库存里面有的数量
				Detail.Columns.Add(new DataColumn("Bin3"));//扩展用来表示在枪里面货位3
				Detail.Columns.Add(new DataColumn("BinCount3",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位3的实发数量
				Detail.Columns.Add(new DataColumn("Desc")); 
				Detail.Columns.Add(new DataColumn("HaveHW"));
				Detail.Columns.Add(new DataColumn("HaveCount"));
				Detail.Columns.Add(new DataColumn("RowID",Type.GetType("System.Decimal")));
				//Detail.Columns.Add(new DataColumn("RBinCount3",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位3的库存里面有的数量*/
				//			Detail.Columns.Add(new DataColumn("Bct10"));//保管员
			}
			
		
			#endregion
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				
				oper.Functions.Zmm_Rfc_Po_Download(ID,PoID,out Ekgrp,out Ekorg,out Ernam,out lifnr,out Name_TextC,out Name1,out Returncode,ref  po_Detail,ref  Return0);
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
								
				System.Data.DataRow dr =Head.NewRow();
				#region 头 正式
				
				dr["Ekgrp"]=Ekgrp.Trim();
				dr["Ekorg"]=Ekorg.Trim();
				dr["lifnr"]=lifnr.Trim();
				dr["Name1"]=Name1.Trim();
				dr["ERNAM"]=Ernam.Trim();
				dr["name_TextC"]=Ekgrp.Trim();
				#endregion
				

				Head.Rows.Add(dr);

				#region 详细  正式
				
				System.Data.DataTable dt = po_Detail.ToADODataTable();
			 
				for(int i=0;i< dt.Rows.Count;i++)
				{
					System.Data.DataRow dr1 =Detail.NewRow();
					dr1["Ebeln"]=PoID;//dt.Rows[i]["Ebeln"].ToString(); 
					dr1["Ebelp"]=dt.Rows[i]["Ebelp"].ToString();
					dr1["Werks"]=dt.Rows[i]["Werks"].ToString();
					dr1["Lgort"]="";//dt.Rows[i]["Lgort"].ToString();

					dr1["Matnr"]=dt.Rows[i]["Matnr"].ToString();
					dr1["Txz01"]=dt.Rows[i]["Txz01"].ToString();
					dr1["Meins"]=dt.Rows[i]["Meins"].ToString();
					dr1["Menge"]=dt.Rows[i]["Menge"].ToString();
					dr1["Netpr"]=dt.Rows[i]["Netpr"].ToString();
					dr1["Mengw"]=dt.Rows[i]["Mengw"].ToString();
					dr1["Receive"]=0;
					if(ID=="105")
					{
						dr1["RowID"] = i.ToString();
						if(dt.Columns.Contains("Bct50") )
						{
							dr1["BinCount1"]=0;	
							dr1["BinCount2"]=0;
							dr1["BinCount3"]=0;

							dr1["Bin1"]="";	
							dr1["Bin2"]="";
							dr1["Bin3"]="";
							string HaveHW="";
							string HaveCount ="";
							if(dt.Rows[i]["Bct50"].ToString().Trim()!="")
							{
								dr1["Bin1"]= dt.Rows[i]["Bct50"].ToString().Trim();
								HaveHW =dt.Rows[i]["Bct50"].ToString().Trim()+"|";
								HaveCount=(dt.Rows[i]["Bct51"].ToString().Trim()==""?"0":dt.Rows[i]["Bct51"].ToString().Trim())+"|";
								if(dt.Rows[i]["Bct60"].ToString().Trim()!="")
								{
									HaveHW +=dt.Rows[i]["Bct60"].ToString().Trim()+"|"+dt.Rows[i]["BCT70"].ToString().Trim();
									HaveCount+=(dt.Rows[i]["Bct61"].ToString().Trim()==""?"0":dt.Rows[i]["Bct61"].ToString().Trim())+"|"+(dt.Rows[i]["Bct71"].ToString().Trim()==""?"0":dt.Rows[i]["Bct71"].ToString().Trim());
									dr1["Bin2"]=dt.Rows[i]["BCT60"].ToString().Trim();
									dr1["Bin3"]=dt.Rows[i]["BCT70"].ToString().Trim();
									
								}
								else if(dt.Rows[i]["Bct70"].ToString().Trim()!="")
								{
									dr1["Bin2"]=dt.Rows[i]["BCT70"].ToString().Trim();
									HaveHW +=dt.Rows[i]["Bct70"].ToString().Trim()+"|"+"";
									HaveCount +=(dt.Rows[i]["Bct71"].ToString().Trim()==""?"0":dt.Rows[i]["Bct71"].ToString().Trim())+"|0";
									
								}
								else
								{
									HaveHW +="|";
									HaveCount+="0|0";
								}
							}
							else if(dt.Rows[i]["Bct60"].ToString().Trim()!="")
							{
								HaveHW +=dt.Rows[i]["Bct60"].ToString().Trim()+"|"+dt.Rows[i]["BCT70"].ToString().Trim()+"|";
								HaveCount+=(dt.Rows[i]["Bct61"].ToString().Trim()==""?"0":dt.Rows[i]["Bct61"].ToString().Trim())+"|"+(dt.Rows[i]["Bct71"].ToString().Trim()==""?"0":dt.Rows[i]["Bct71"].ToString().Trim())+"|0";
								dr1["Bin1"]= dt.Rows[i]["Bct60"].ToString().Trim();
								dr1["Bin2"]= dt.Rows[i]["Bct70"].ToString().Trim();
								

							}
							else if(dt.Rows[i]["Bct70"].ToString().Trim()!="")
							{
								HaveHW +=dt.Rows[i]["Bct70"].ToString().Trim()+"|"+""+"|";
								HaveCount+=(dt.Rows[i]["Bct71"].ToString().Trim()==""?"0":dt.Rows[i]["Bct71"].ToString().Trim())+"|"+"0"+"|0";
								dr1["Bin1"]= dt.Rows[i]["Bct70"].ToString().Trim();
								
							}
							else
							{
								HaveHW="||";
								HaveCount="0|0|0";
							}
							dr1["HaveHW"]=HaveHW;
							dr1["HaveCount"]=HaveCount;
		
						}
						else
						{
							dr1["HaveHW"]="||";
							dr1["HaveCount"]="0|0|0";
						}
						
					}

					Detail.Rows.Add(dr1);
				}
				#region delete
				/*	 
			 
						if(piType =="生产领料" ||piType=="退货" ||piType=="报废出库"||piType=="移至报废库")
						{
							System.Data.DataRow[] NeedNot = dt.Select("Bct10<>'"+User+"'");
							for(int i=0;i< NeedNot.Length;i++)
							{
								dt.Rows.Remove(NeedNot[i]);
							}
						}
							for(int i=0;i< dt.Rows.Count;i++)
							{
								System.Data.DataRow dr1 =Detail.NewRow();
								dr1["Ebeln"]=dt.Rows[i]["Ebeln"].ToString(); 
								dr1["Ebelp"]=dt.Rows[i]["Ebelp"].ToString();
								dr1["Lgort"]=dt.Rows[i]["Lgort"].ToString();
								dr1["Maktx"]=dt.Rows[i]["Maktx"].ToString();
								dr1["Matnr"]=dt.Rows[i]["Matnr"].ToString();
								dr1["Meins"]=dt.Rows[i]["Meins"].ToString();
								dr1["Bstme"]=dt.Rows[i]["Bstme"].ToString();
								dr1["Menge"]=dt.Rows[i]["Menge"].ToString();
								dr1["Netwr"]=dt.Rows[i]["Netwr"].ToString();
								dr1["Ntgew"]=dt.Rows[i]["Ntgew"].ToString();
								dr1["Obmng"]=dt.Rows[i]["Obmng"].ToString();
								dr1["Bin1"]=dt.Rows[i]["Bct50"].ToString();
								dr1["Bin2"]=dt.Rows[i]["Bct60"].ToString();
								dr1["Bin3"]=dt.Rows[i]["Bct70"].ToString();
								dr1["BinCount1"]=dt.Rows[i]["Bct51"].ToString();
								dr1["BinCount2"]=dt.Rows[i]["Bct61"].ToString();
								dr1["BinCount3"]=dt.Rows[i]["Bct71"].ToString();
								dr1["Bct10"] = dt.Rows[i]["Bct10"].ToString();
								Detail.Rows.Add(dr1);
							}
				*/	
				#endregion
				
				#endregion 
				
				Head.TableName ="Head";
				poDs.Tables.Add(Head);
				Detail.TableName ="Detail";
				poDs.Tables.Add(Detail);

			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
			
			return 0;
		}


		/// <summary>
		/// 获取Sap入库的单据的信息
		/// </summary>
		/// <param name="User"></param>
		/// <param name="PoID"></param>
		/// <param name="PoType"></param>
		/// <param name="poDs"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int GetPoInfoYS(string User,string PoID,string piType,bool NeedDetail,out System.Data.DataSet poDs,out string ErrMsg)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			poDs = new DataSet();
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);
			SapService.ZSMM_RFC_PDZTable po_Detail  =new ZSMM_RFC_PDZTable();
			SapService.ZSMM_RFC_PDZ po_DetailItem = new ZSMM_RFC_PDZ();
	
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			SapService.BAPIRET2 Return0Item = new BAPIRET2();
			
			string ID ="";
			if(piType =="采购收货")
			{
				ID ="103";
			}
			else if(piType =="验收入库")
			{
				ID ="105";
			}
			else if(piType=="采购退货")
			{
				ID="105";
			}
					
			string Ekgrp; //采购组
			string Ekorg; //采购组织
			string lifnr; //供应商编号
			string Name1;//供应商名称
			string Ernam="";//制单员号
			string Name_TextC="";//制单员名字
			

			string Returncode =""; //返回值
			#region 构建头表
			System.Data.DataTable Head = new DataTable();
			Head.Columns.Add(new DataColumn("name_TextC")); 
			Head.Columns.Add(new DataColumn("ERNAM")); 
			Head.Columns.Add(new DataColumn("Ekgrp")); 

			Head.Columns.Add(new DataColumn("Ekorg")); 
			Head.Columns.Add(new DataColumn("lifnr")); 
			Head.Columns.Add(new DataColumn("Name1")); 
			#endregion

			#region 构建详细表
			System.Data.DataTable Detail = new DataTable();

			Detail.Columns.Add(new DataColumn("Ebeln"));   //采购订单号
			Detail.Columns.Add(new DataColumn("Ebelp",Type.GetType("System.Int32")));   //采购订单行项目
			Detail.Columns.Add(new DataColumn("Werks"));  //工厂号
			Detail.Columns.Add(new DataColumn("Lgort"));  //库存地点
			
			Detail.Columns.Add(new DataColumn("Matnr"));  //物料号
			Detail.Columns.Add(new DataColumn("Txz01"));  //物料描述
			Detail.Columns.Add(new DataColumn("Meins"));  //基本单位
			Detail.Columns.Add(new DataColumn("Menge",Type.GetType("System.Decimal"))); //订单数量
			Detail.Columns.Add(new DataColumn("Netpr",Type.GetType("System.Decimal")));//单价
			Detail.Columns.Add(new DataColumn("Mengw",Type.GetType("System.Decimal")));//未清数量
			Detail.Columns.Add(new DataColumn("Receive",Type.GetType("System.Decimal")));//扩展用来表示在枪里面收取的数量
			if(ID =="105")
			{
				Detail.Columns.Add(new DataColumn("Bin1"));//扩展用来表示在枪里面货位1
				Detail.Columns.Add(new DataColumn("BinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的实发数量
				
			
				Detail.Columns.Add(new DataColumn("Bin2"));//扩展用来表示在枪里面货位2
				Detail.Columns.Add(new DataColumn("BinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的实发数量
				
				Detail.Columns.Add(new DataColumn("Bin3"));//扩展用来表示在枪里面货位3
				Detail.Columns.Add(new DataColumn("BinCount3",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位3的实发数量
				Detail.Columns.Add(new DataColumn("Desc")); 
				Detail.Columns.Add(new DataColumn("HaveHW"));
				Detail.Columns.Add(new DataColumn("HaveCount"));
				Detail.Columns.Add(new DataColumn("RowID",Type.GetType("System.Decimal")));
				Detail.Columns.Add(new DataColumn("DocID"));
				Detail.Columns.Add(new DataColumn("DocIDItem"));
				Detail.Columns.Add(new DataColumn("DocDate"));
				Detail.Columns.Add(new DataColumn("Reason"));

				
			}
			
		
			#endregion
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				
				oper.Functions.Zmm_Rfc_Receive_Download(ID,PoID,out Ekgrp,out Ekorg,out Ernam,out lifnr,out Name_TextC,out Name1,out Returncode,ref  po_Detail,ref  Return0);
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
							
				System.Data.DataRow dr =Head.NewRow();
				#region 头 正式
				
				dr["Ekgrp"]=Ekgrp.Trim();
				dr["Ekorg"]=Ekorg.Trim();
				dr["lifnr"]=lifnr.Trim();
				dr["Name1"]=Name1.Trim();
				dr["ERNAM"]=Ernam.Trim();
				dr["name_TextC"]=Ekgrp.Trim();
				#endregion
				
				Head.Rows.Add(dr);

				#region 详细  正式
				
				System.Data.DataTable dt = po_Detail.ToADODataTable();
			 
				for(int i=0;i< dt.Rows.Count;i++)
				{
					System.Data.DataRow dr1 =Detail.NewRow();
					dr1["Ebeln"]=PoID;//dt.Rows[i]["Ebeln"].ToString(); 
					dr1["Ebelp"]=dt.Rows[i]["Ebelp"].ToString();
					dr1["Werks"]=dt.Rows[i]["Werks"].ToString();
					dr1["Lgort"]="";//dt.Rows[i]["Lgort"].ToString();

					dr1["Matnr"]=dt.Rows[i]["Matnr"].ToString();
					dr1["Txz01"]=dt.Rows[i]["Txz01"].ToString();
					dr1["Meins"]=dt.Rows[i]["Meins"].ToString();
					dr1["Menge"]=dt.Rows[i]["Menge"].ToString();
					dr1["Netpr"]=dt.Rows[i]["Netpr"].ToString();
					dr1["Mengw"]=dt.Rows[i]["Mengw"].ToString();
					dr1["Receive"]=0;
					if(ID=="105")
					{
						dr1["RowID"] = i.ToString();
//						if(dt.Columns.Contains("Bct50") )
//						{
//							//dr1["Lgort"]=dt.Rows[i]["Lgort"].ToString();
//							dr1["Bin1"]= dt.Rows[i]["Bct50"].ToString().Trim();
//							dr1["BinCount1"]=0;
//							dr1["Bin2"]=dt.Rows[i]["BCT60"].ToString().Trim();
//							dr1["BinCount2"]=0;
//							dr1["Bin3"]=dt.Rows[i]["BCT70"].ToString().Trim();
//							dr1["BinCount3"]=0;
//							dr1["HaveHW"] = dt.Rows[i]["Bct50"].ToString().Trim()+"|"+dt.Rows[i]["BCT60"].ToString().Trim()+"|"+dt.Rows[i]["Bct70"].ToString().Trim() ;
//							dr1["HaveCount"]=dt.Rows[i]["Bct51"].ToString().Trim()+"|"+dt.Rows[i]["BCT61"].ToString().Trim()+"|"+dt.Rows[i]["Bct71"].ToString().Trim() ;
//							dr1["DocID"]=dt.Rows[i]["Mblnr"].ToString().Trim();;
//							dr1["DocIDItem"]=dt.Rows[i]["Zeile"].ToString().Trim();
//							dr1["DocDate"]=dt.Rows[i]["Mjahr"].ToString().Trim();
//							
//							//po_DetailItem.
//							
//
//						}
						if(dt.Columns.Contains("Bct50") )
						{

							dr1["DocID"]=dt.Rows[i]["Mblnr"].ToString().Trim();;
							dr1["DocIDItem"]=dt.Rows[i]["Zeile"].ToString().Trim();
							dr1["DocDate"]=dt.Rows[i]["Mjahr"].ToString().Trim();

							dr1["BinCount1"]=0;	
							dr1["BinCount2"]=0;
							dr1["BinCount3"]=0;

							dr1["Bin1"]="";	
							dr1["Bin2"]="";
							dr1["Bin3"]="";
							string HaveHW="";
							string HaveCount ="";
							if(dt.Rows[i]["Bct50"].ToString().Trim()!="")
							{
								dr1["Bin1"]= dt.Rows[i]["Bct50"].ToString().Trim();
								HaveHW =dt.Rows[i]["Bct50"].ToString().Trim()+"|";
								HaveCount=(dt.Rows[i]["Bct51"].ToString().Trim()==""?"0":dt.Rows[i]["Bct51"].ToString().Trim())+"|";
								if(dt.Rows[i]["Bct60"].ToString().Trim()!="")
								{
									HaveHW +=dt.Rows[i]["Bct60"].ToString().Trim()+"|"+dt.Rows[i]["BCT70"].ToString().Trim();
									HaveCount+=(dt.Rows[i]["Bct61"].ToString().Trim()==""?"0":dt.Rows[i]["Bct61"].ToString().Trim())+"|"+(dt.Rows[i]["Bct71"].ToString().Trim()==""?"0":dt.Rows[i]["Bct71"].ToString().Trim());
									dr1["Bin2"]=dt.Rows[i]["BCT60"].ToString().Trim();
									dr1["Bin3"]=dt.Rows[i]["BCT70"].ToString().Trim();
									
								}
								else if(dt.Rows[i]["Bct70"].ToString().Trim()!="")
								{
									dr1["Bin2"]=dt.Rows[i]["BCT70"].ToString().Trim();
									HaveHW +=dt.Rows[i]["Bct70"].ToString().Trim()+"|"+"";
									HaveCount +=(dt.Rows[i]["Bct71"].ToString().Trim()==""?"0":dt.Rows[i]["Bct71"].ToString().Trim())+"|0";
									
								}
								else
								{
									HaveHW +="|";
									HaveCount+="0|0";
								}
							}
							else if(dt.Rows[i]["Bct60"].ToString().Trim()!="")
							{
								HaveHW +=dt.Rows[i]["Bct60"].ToString().Trim()+"|"+dt.Rows[i]["BCT70"].ToString().Trim()+"|";
								HaveCount+=(dt.Rows[i]["Bct61"].ToString().Trim()==""?"0":dt.Rows[i]["Bct61"].ToString().Trim())+"|"+(dt.Rows[i]["Bct71"].ToString().Trim()==""?"0":dt.Rows[i]["Bct71"].ToString().Trim())+"|0";
								dr1["Bin1"]= dt.Rows[i]["Bct60"].ToString().Trim();
								dr1["Bin2"]= dt.Rows[i]["Bct70"].ToString().Trim();
								

							}
							else if(dt.Rows[i]["Bct70"].ToString().Trim()!="")
							{
								HaveHW +=dt.Rows[i]["Bct70"].ToString().Trim()+"|"+""+"|";
								HaveCount+=(dt.Rows[i]["Bct71"].ToString().Trim()==""?"0":dt.Rows[i]["Bct71"].ToString().Trim())+"|"+"0"+"|0";
								dr1["Bin1"]= dt.Rows[i]["Bct70"].ToString().Trim();
								
							}
							else
							{
								HaveHW="||";
								HaveCount="0|0|0";
							}
							dr1["HaveHW"]=HaveHW;
							dr1["HaveCount"]=HaveCount;
		
						}
						else
						{
							dr1["HaveHW"]="||";
							dr1["HaveCount"]="0|0|0";
						}


						
					}

					Detail.Rows.Add(dr1);
				}
				#region delete
				
				#endregion
				
				#endregion 
				
				Head.TableName ="Head";
				poDs.Tables.Add(Head);
				Detail.TableName ="Detail";
				poDs.Tables.Add(Detail);
			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
			return 0;
		}

		/// <summary>
		/// 获取代管单信息
		/// </summary>
		/// <param name="User"></param>
		/// <param name="PoID"></param>
		/// <param name="piType"></param>
		/// <param name="NeedDetail"></param>
		/// <param name="poDs"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int GetDGInfo(string User,string PoID,string piType,bool NeedDetail,out System.Data.DataSet poDs,out string ErrMsg)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			poDs = new DataSet();
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);
			SapService.ZSMM_RFC_POBTable po_Detail  =new ZSMM_RFC_POBTable();
			SapService.ZSMM_RFC_POB  po_DetailItem = new ZSMM_RFC_POB();
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			SapService.BAPIRET2 Return0Item = new BAPIRET2();
			
			string ID ="";
			if(piType =="代管入库")
			{
				ID ="ZA1";
			}					
			string Ekgrp; //采购组
			string Ekorg; //采购组织
			//string lifnr; //供应商编号
			string Name1;//供应商名称
			string Ernam="";//制单员号
			string Name_TextC="";//制单员名字
			string Reswk="";  //转储的供应(发出)工厂
			
			string Returncode =""; //返回值
			#region 构建头表
			System.Data.DataTable Head = new DataTable();
			Head.Columns.Add(new DataColumn("name_TextC")); 
			Head.Columns.Add(new DataColumn("ERNAM")); 
			Head.Columns.Add(new DataColumn("Ekgrp")); 

			Head.Columns.Add(new DataColumn("Ekorg")); 
			//Head.Columns.Add(new DataColumn("lifnr")); 
			Head.Columns.Add(new DataColumn("Name1")); 
			Head.Columns.Add(new DataColumn("Reswk"));


			#endregion

			#region 构建详细表
			System.Data.DataTable Detail = new DataTable();

			Detail.Columns.Add(new DataColumn("Ebeln"));   //采购订单号
			Detail.Columns.Add(new DataColumn("Ebelp",Type.GetType("System.Int32")));   //采购订单行项目
			Detail.Columns.Add(new DataColumn("Werks"));  //工厂号
			Detail.Columns.Add(new DataColumn("Lgort"));  //库存地点
			

			Detail.Columns.Add(new DataColumn("Matnr"));  //物料号
			Detail.Columns.Add(new DataColumn("Txz01"));  //物料描述
			Detail.Columns.Add(new DataColumn("Meins"));  //基本单位
			Detail.Columns.Add(new DataColumn("Menge",Type.GetType("System.Decimal"))); //订单数量
			Detail.Columns.Add(new DataColumn("Netpr",Type.GetType("System.Decimal")));//单价
			Detail.Columns.Add(new DataColumn("Mengw",Type.GetType("System.Decimal")));//未清数量
			
			
			
			Detail.Columns.Add(new DataColumn("Receive",Type.GetType("System.Decimal")));//扩展用来表示在枪里面收取的数量
			if(ID =="ZA1")
			{
				Detail.Columns.Add(new DataColumn("Bin1"));//扩展用来表示在枪里面货位1
				Detail.Columns.Add(new DataColumn("BinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的实发数量
				//Detail.Columns.Add(new DataColumn("RBinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的库存里面有的数量
			
				Detail.Columns.Add(new DataColumn("Bin2"));//扩展用来表示在枪里面货位2
				Detail.Columns.Add(new DataColumn("BinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的实发数量
				//Detail.Columns.Add(new DataColumn("RBinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的库存里面有的数量
				Detail.Columns.Add(new DataColumn("Bin3"));//扩展用来表示在枪里面货位3
				Detail.Columns.Add(new DataColumn("BinCount3",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位3的实发数量
				Detail.Columns.Add(new DataColumn("Desc")); 
				Detail.Columns.Add(new DataColumn("HaveHW")); 
				
			}
			
		
			#endregion
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}				
				
				oper.Functions.Zmm_Rfc_Dbg_Download(PoID,out Ekgrp,out Ekorg,out Ernam,out Name_TextC,out Name1,out Reswk,out Returncode,ref  po_Detail,ref  Return0);
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}							

				System.Data.DataRow dr =Head.NewRow();
				#region 头 正式
				
				dr["Ekgrp"]=Ekgrp.Trim();
				dr["Ekorg"]=Ekorg.Trim();
				
				dr["Name1"]=Name1.Trim();
				dr["ERNAM"]=Ernam.Trim();
				dr["name_TextC"]=Ekgrp.Trim();

				dr["Reswk"]=Reswk.Trim();

				Head.Rows.Add(dr);
				#endregion

				#region 详细  正式
				
				System.Data.DataTable dt = po_Detail.ToADODataTable();
			 
				for(int i=0;i< dt.Rows.Count;i++)
				{
					System.Data.DataRow dr1 =Detail.NewRow();
					dr1["Ebeln"]=PoID;
					dr1["Ebelp"]=dt.Rows[i]["Ebelp"].ToString();
					dr1["Werks"]=Reswk;
					dr1["Lgort"]="";//dt.Rows[i]["Lgort"].ToString();

					dr1["Matnr"]=dt.Rows[i]["Matnr"].ToString();
					dr1["Txz01"]=dt.Rows[i]["Txz01"].ToString();
					dr1["Meins"]=dt.Rows[i]["Meins"].ToString();
					dr1["Menge"]=dt.Rows[i]["Menge"].ToString();
					dr1["Netpr"]=dt.Rows[i]["Netpr"].ToString();
					dr1["Mengw"]=dt.Rows[i]["Menge"].ToString();//dt.Rows[i]["Mengw"].ToString();//根据sap放的要求，改成未清数量和订单数量一致
					dr1["Receive"]=0;
//					if(dt.Columns.Contains("Bct50"))
//					{
//						dr1["Bin1"]= dt.Rows[i]["Bct50"].ToString().Trim();
//						dr1["BinCoun1"]=0;
//						dr1["Bin2"]=dt.Rows[i]["BCT60"].ToString().Trim();
//						dr1["BinCoun2"]=0;
//						dr1["Bin3"]=dt.Rows[i]["BCT70"].ToString().Trim();
//						dr1["BinCoun3"]=0;
//						dr1["HaveHW"] = dt.Rows[i]["Bct50"].ToString().Trim()+"|"+dt.Rows[i]["BCT60"].ToString().Trim()+"|"+dt.Rows[i]["Bct70"].ToString().Trim() ;
//					}
					if(dt.Columns.Contains("Bct50") )
					{
						dr1["BinCount1"]=0;	
						dr1["BinCount2"]=0;
						dr1["BinCount3"]=0;

						dr1["Bin1"]="";	
						dr1["Bin2"]="";
						dr1["Bin3"]="";
						string HaveHW="";
						string HaveCount ="";
						if(dt.Rows[i]["Bct50"].ToString().Trim()!="")
						{
							dr1["Bin1"]= dt.Rows[i]["Bct50"].ToString().Trim();
							HaveHW =dt.Rows[i]["Bct50"].ToString().Trim()+"|";
							HaveCount=(dt.Rows[i]["Bct51"].ToString().Trim()==""?"0":dt.Rows[i]["Bct51"].ToString().Trim())+"|";
							if(dt.Rows[i]["Bct60"].ToString().Trim()!="")
							{
								HaveHW +=dt.Rows[i]["Bct60"].ToString().Trim()+"|"+dt.Rows[i]["BCT70"].ToString().Trim();
								HaveCount+=(dt.Rows[i]["Bct61"].ToString().Trim()==""?"0":dt.Rows[i]["Bct61"].ToString().Trim())+"|"+(dt.Rows[i]["Bct71"].ToString().Trim()==""?"0":dt.Rows[i]["Bct71"].ToString().Trim());
								dr1["Bin2"]=dt.Rows[i]["BCT60"].ToString().Trim();
								dr1["Bin3"]=dt.Rows[i]["BCT70"].ToString().Trim();
									
							}
							else if(dt.Rows[i]["Bct70"].ToString().Trim()!="")
							{
								dr1["Bin2"]=dt.Rows[i]["BCT70"].ToString().Trim();
								HaveHW +=dt.Rows[i]["Bct70"].ToString().Trim()+"|"+"";
								HaveCount +=(dt.Rows[i]["Bct71"].ToString().Trim()==""?"0":dt.Rows[i]["Bct71"].ToString().Trim())+"|0";
									
							}
							else
							{
								HaveHW +="|";
								HaveCount+="0|0";
							}
						}
						else if(dt.Rows[i]["Bct60"].ToString().Trim()!="")
						{
							HaveHW +=dt.Rows[i]["Bct60"].ToString().Trim()+"|"+dt.Rows[i]["BCT70"].ToString().Trim()+"|";
							HaveCount+=(dt.Rows[i]["Bct61"].ToString().Trim()==""?"0":dt.Rows[i]["Bct61"].ToString().Trim())+"|"+(dt.Rows[i]["Bct71"].ToString().Trim()==""?"0":dt.Rows[i]["Bct71"].ToString().Trim())+"|0";
							dr1["Bin1"]= dt.Rows[i]["Bct60"].ToString().Trim();
							dr1["Bin2"]= dt.Rows[i]["Bct70"].ToString().Trim();
								

						}
						else if(dt.Rows[i]["Bct70"].ToString().Trim()!="")
						{
							HaveHW +=dt.Rows[i]["Bct70"].ToString().Trim()+"|"+""+"|";
							HaveCount+=(dt.Rows[i]["Bct71"].ToString().Trim()==""?"0":dt.Rows[i]["Bct71"].ToString().Trim())+"|"+"0"+"|0";
							dr1["Bin1"]= dt.Rows[i]["Bct70"].ToString().Trim();
								
						}
						else
						{
							HaveHW="||";
							HaveCount="0|0|0";
						}
						dr1["HaveHW"]=HaveHW;
						dr1["HaveCount"]=HaveCount;
		
					}
					else
					{
						dr1["HaveHW"]="||";
					}
					Detail.Rows.Add(dr1);
				}
				
				
				#endregion 
				
				Head.TableName ="Head";
				poDs.Tables.Add(Head);
				Detail.TableName ="Detail";
				poDs.Tables.Add(Detail);

			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
			

			return 0;
		}


		/// <summary>
		/// 提交Sap的采购入库库信息
		/// </summary>
		/// <param name="User"></param>
		/// <param name="PoID"></param>
		/// <param name="PlantID"></param>
		/// <param name="PiType"></param>
		/// <param name="Ds"></param>
		/// <param name="DocumentID"></param>
		/// <param name="DocDate"></param>
		/// <param name="ErrMsg"></param>
        /// <param name="ywtm">一维条码</param>
		/// <returns></returns>
        public int UpdPoInfo(string User, string PoID, string PiType, System.Data.DataSet Ds, ref string ywtm, out string DocumentID, out string DocDate, out string ErrMsg)
        {
            OutPass pass = new OutPass();
            string SapUser, SapPass;
            DocDate = "";
            DocumentID = "";
            //ywtm = "";

            if (0 != pass.DbUserGetSapPass(User, out SapUser, out SapPass, out ErrMsg))
            {
                return -1;
            }
            string Bct10 = User;//保管员 
            string Budat = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString("00") + System.DateTime.Now.Day.ToString("00");//过账日期
            string Ebeln = PoID;//采购订单号
            string Bldat = "";//凭证日期
            string Mblnr = "";//凭证号

#if isSaveHistoryData
            #region 构造DtToRF 2008-08-19 myl

            ArrayList arrColumnCollection = new ArrayList(), arrParaCollection = new ArrayList();


            DataTable DtToRF = new DataTable("ToRF");
            DtToRF.Columns.Add(new DataColumn("order_no")); arrColumnCollection.Add("order_no");
            // dt.Columns.Add(new DataColumn("operator_date"));
            DtToRF.Columns.Add(new DataColumn("item_no")); arrColumnCollection.Add("item_no");
            DtToRF.Columns.Add(new DataColumn("storeman")); arrColumnCollection.Add("storeman");
            DtToRF.Columns.Add(new DataColumn("pzh")); arrColumnCollection.Add("pzh");
            DtToRF.Columns.Add(new DataColumn("pznd")); arrColumnCollection.Add("pznd");
            DtToRF.Columns.Add(new DataColumn("bill_type")); arrColumnCollection.Add("bill_type");
            DtToRF.Columns.Add(new DataColumn("product_no")); arrColumnCollection.Add("product_no");
            DtToRF.Columns.Add(new DataColumn("product_desc")); arrColumnCollection.Add("product_desc");
            DtToRF.Columns.Add(new DataColumn("qty", typeof(decimal))); arrColumnCollection.Add("qty");
            DtToRF.Columns.Add(new DataColumn("gch")); arrColumnCollection.Add("gch");
            DtToRF.Columns.Add(new DataColumn("sl")); arrColumnCollection.Add("sl");
            DtToRF.Columns.Add(new DataColumn("remark")); arrColumnCollection.Add("remark");


            System.Data.OleDb.OleDbParameter para = new OleDbParameter("@order_no", OleDbType.VarChar, 20, "order_no");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@item_no", OleDbType.Integer, 10, "item_no");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@storeman", OleDbType.VarChar, 20, "storeman");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@pzh", OleDbType.VarChar, 20, "pzh");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@pznd", OleDbType.VarChar, 4, "pznd");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@bill_type", OleDbType.VarChar, 20, "bill_type");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@product_no", OleDbType.VarChar, 18, "product_no");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@product_desc", OleDbType.VarChar, 80, "product_desc");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@qty", OleDbType.Decimal, 8, "qty");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@gch", OleDbType.VarChar, 4, "gch");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@sl", OleDbType.VarChar, 10, "sl");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@remark", OleDbType.VarChar, 40, "remark");
            arrParaCollection.Add(para);
            #endregion
#endif

            string Returncode;
            SapService.ZSMM_RFC_POUPTable pt_Kc = new ZSMM_RFC_POUPTable();
            SapService.BAPIRET2Table Return0 = new BAPIRET2Table();

            SapOperator oper = new SapOperator(SapUser, SapPass);

            #region 准备数据

            for (int i = 0; i < Ds.Tables["Detail"].Rows.Count; i++)
            {
                //2008-08-12 myl
                if (Ds.Tables["Detail"].Rows[i]["Receive"].ToString().Trim() == "")
                {
                    Ds.Tables["Detail"].Rows[i]["Receive"] = "0";
                }

                if (Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString()) == 0)
                {
                    continue;
                }
                else
                {
                    SapService.ZSMM_RFC_POUP pop = new ZSMM_RFC_POUP();
                    pop.Ebelp = Ds.Tables["Detail"].Rows[i]["Ebelp"].ToString(); //行项目
                    pop.Lgort = Ds.Tables["Detail"].Rows[i]["Lgort"].ToString(); //行项目
                    pop.Menge = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString());
                    pt_Kc.Add(pop);

#if isSaveHistoryData
                    #region Add to DtToRF 2008-08-19 myl
                    DataRow drToRF = DtToRF.NewRow();
                    drToRF["order_no"] = PoID;
                    drToRF["item_no"] = Convert.ToInt32(pop.Ebelp.Trim());
                    drToRF["storeman"] = User;
                    drToRF["bill_type"] = "采购收货";
                    drToRF["product_no"] = Ds.Tables["Detail"].Rows[i]["Matnr"].ToString();
                    drToRF["product_desc"] = Ds.Tables["Detail"].Rows[i]["Txz01"].ToString();
                    drToRF["qty"] = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString());
                    drToRF["gch"] = Ds.Tables["Detail"].Rows[i]["Werks"].ToString();
                    drToRF["sl"] = Ds.Tables["Detail"].Rows[i]["Lgort"].ToString();
                    DtToRF.Rows.Add(drToRF);
                    #endregion
#endif
                }
            }

            #endregion
            try
            {
                MessagePack pack = oper.Open();
                if (pack.Code != 0)
                {
                    ErrMsg = pack.Message;
                    return -1;
                }
                oper.Functions.Zmm_Rfc_Po_Upload(Bct10, Budat, Ebeln, out Mblnr, out Bldat, out Returncode, ref pt_Kc, ref  Return0);
                if (Returncode.Trim() != "0")
                {
                    if (Return0.Count <= 0)
                    {
                        ErrMsg = "Sap中出现错误，但是没有返回具体错误信息";
                        return -1;
                    }
                    for (int i = 0; i < Return0.Count; i++)
                    {
                        ErrMsg += Return0[i].Message + "\r\n";
                    }
                    return -1;
                }
                DocumentID = Mblnr;
                DocDate = Bldat;
                //				System.Data.DataTable dt = new DataTable();
                //				InsertDoc(dt,DocumentID,DocDate,"103",User,out ErrMsg);

#if isSaveHistoryData
                #region Add to DtToRF 2008-08-19 myl
                foreach (DataRow dr in DtToRF.Rows)
                {
                    dr["pzh"] = Mblnr;
                    dr["pznd"] = Bldat;
                }
                //				for(int i=0;i<100;i++)
                //				{
                //					DataRow drToRF=DtToRF.NewRow();
                //					drToRF["order_no"]=PoID;
                //					drToRF["storeman"]=User;
                //					drToRF["bill_type"]="采购收货"+i.ToString();
                //					drToRF["product_no"]= Ds.Tables["Detail"].Rows[0]["Matnr"].ToString()+i.ToString();
                //					drToRF["product_desc"]= Ds.Tables["Detail"].Rows[0]["Txz01"].ToString();
                //					drToRF["qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[0]["Receive"].ToString());
                //					drToRF["gch"]= Ds.Tables["Detail"].Rows[0]["Werks"].ToString();
                //					drToRF["sl"]= Ds.Tables["Detail"].Rows[0]["Lgort"].ToString();
                //					drToRF["pzh"]=Mblnr;
                //					drToRF["pznd"]=Bldat;
                //					DtToRF.Rows.Add(drToRF);
                //
                //				}
                //				if(InsertInfoToRFdb(arrColumnCollection,arrParaCollection,DtToRF,"t_take_delivery",out ErrMsg)!=0)
                //				{
                //					return -1;
                //				}

                InsertInfoToRFdb_caiggoush(ref ywtm, enumOpType.采购收货, arrColumnCollection, arrParaCollection, DtToRF, "t_take_delivery", out ErrMsg);
                #endregion
#endif

                return 0;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return -1;
            }
            finally
            {
                oper.Close();
            }
        }


		int InsertDoc(System.Data.DataTable dt,string DocID,string DocDate,string CType,string User,string Vendor,out string ErrMsg)
		{
			ErrMsg ="";
			string GUID = System.Guid.NewGuid().ToString();
			System.Data.OleDb.OleDbParameter param2 = new System.Data.OleDb.OleDbParameter();
			param2.DbType = DbType.String;
			param2.SourceColumn = "ItemNo";
			param2.ParameterName = "@ItemNo";
		

			System.Data.OleDb.OleDbParameter param3 = new System.Data.OleDb.OleDbParameter();
			param3.DbType = DbType.String;
			param3.SourceColumn = "Matnr";
			param3.ParameterName = "@Matnr";

			System.Data.OleDb.OleDbParameter param4 = new System.Data.OleDb.OleDbParameter();
			param4.DbType = DbType.String;
			param4.SourceColumn = "Charg";
			param4.ParameterName = "@Charg";
		

			System.Data.OleDb.OleDbParameter param5 = new System.Data.OleDb.OleDbParameter();
			param5.DbType = DbType.String;
			param5.SourceColumn = "Werks";
			param5.ParameterName = "@Werks";

			System.Data.OleDb.OleDbParameter param6 = new System.Data.OleDb.OleDbParameter();
			param6.DbType = DbType.String;
			param6.SourceColumn = "Lgort";
			param6.ParameterName = "@Lgort";

			System.Data.OleDb.OleDbParameter param7 = new System.Data.OleDb.OleDbParameter();
			param7.DbType = DbType.String;
			param7.SourceColumn = "Maktx";
			param7.ParameterName = "@Maktx";

			System.Data.OleDb.OleDbParameter param8 = new System.Data.OleDb.OleDbParameter();
			param8.DbType = DbType.Decimal;
			param8.SourceColumn = "Menge";
			param8.ParameterName = "@Menge";

			System.Data.OleDb.OleDbParameter param9 = new System.Data.OleDb.OleDbParameter();
			param9.DbType = DbType.String;
			param9.SourceColumn = "Bct50";
			param9.ParameterName = "@Bct50";

			System.Data.OleDb.OleDbParameter param10 = new System.Data.OleDb.OleDbParameter();
			param10.DbType = DbType.Decimal;
			param10.SourceColumn = "Bct51";
			param10.ParameterName = "@Bct51";

			System.Data.OleDb.OleDbParameter param11 = new System.Data.OleDb.OleDbParameter();
			param11.DbType = DbType.String;
			param11.SourceColumn = "Bct60";
			param11.ParameterName = "@Bct60";

			System.Data.OleDb.OleDbParameter param12 = new System.Data.OleDb.OleDbParameter();
			param12.DbType = DbType.Decimal;
			param12.SourceColumn = "Bct61";
			param12.ParameterName = "@Bct61";

			System.Data.OleDb.OleDbParameter param13 = new System.Data.OleDb.OleDbParameter();
			param13.DbType = DbType.String;
			param13.SourceColumn = "Bct70";
			param13.ParameterName = "@Bct70";

			System.Data.OleDb.OleDbParameter param14 = new System.Data.OleDb.OleDbParameter();
			param14.DbType = DbType.Decimal;
			param14.SourceColumn = "Bct71";
			param14.ParameterName = "@Bct71";

			System.Data.OleDb.OleDbParameter param15 = new System.Data.OleDb.OleDbParameter();
			param15.DbType = DbType.String;
			param15.SourceColumn = "Closed";
			param15.ParameterName = "@Closed";


//			System.Data.OleDb.OleDbParameter param7 = new System.Data.OleDb.OleDbParameter();
//			param7.DbType = DbType.String;
//			param7.SourceColumn = "DocID";
//			param7.ParameterName = "@DocID";

			System.Data.OleDb.OleDbCommand Head = new System.Data.OleDb.OleDbCommand();
			Head.CommandText = "insert into DocHead (RowNumber,DocID,CUser,CType,CYear,VendorName) values('"+GUID+"','"+DocID+"','"+User+"','"+CType+"','"+DocDate+"','"+Vendor+"')";


			System.Data.OleDb.OleDbCommand Detail = new System.Data.OleDb.OleDbCommand();
			Detail.CommandText = "insert into DocDetail (RowNumber,ItemNo,Matnr,Charg,Werks,Lgort,Maktx,Menge,Bct50,Bct51,Bct60,Bct61,Bct70,Bct71) values('"+GUID+"',?,?,?,?,?,?,?,?,?,?,?,?,?)";
			Detail.Parameters.Add(param2);
			Detail.Parameters.Add(param3);
			Detail.Parameters.Add(param4);
			Detail.Parameters.Add(param5);

			Detail.Parameters.Add(param6);
			Detail.Parameters.Add(param7);
			Detail.Parameters.Add(param8);
			Detail.Parameters.Add(param9);

			Detail.Parameters.Add(param10);
			Detail.Parameters.Add(param11);
			Detail.Parameters.Add(param12);
			Detail.Parameters.Add(param13);
			Detail.Parameters.Add(param14);

			System.Collections.DictionaryEntry endtry = new System.Collections.DictionaryEntry();
			endtry.Key = Head;
			
			System.Collections.ArrayList arr = new System.Collections.ArrayList();
			arr.Add(endtry);
			
			System.Collections.DictionaryEntry endtry1 = new System.Collections.DictionaryEntry();
			endtry1.Key = Detail;
			endtry1.Value = dt;
			TDB db = new TDB(Global.g_ConStr);
			
			if(0!=db.ExcuteInsertCommand(arr))
			{
				ErrMsg = "插入盘点单号头信息到数据库失败";
				return -1;
			}
			return 0;
		}

		/// <summary>
		/// 上传验收入库，代管入库
		/// </summary>
		/// <param name="User"></param>
		/// <param name="PoID"></param>
		/// <param name="PiType"></param>
		/// <param name="Ds"></param>
		/// <param name="DocumentID"></param>
		/// <param name="DocDate"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int UpdReceiveInfo(string User,string PoID,string PiType,System.Data.DataSet Ds,out string DocumentID,out string DocDate,out string ErrMsg,string ywtm)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			DocDate ="";
			DocumentID="";
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			string Bct10=User;//保管员 
			string Budat=System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString("00")+System.DateTime.Now.Day.ToString("00") ;//过账日期
			string Ebeln=PoID;//采购订单号
			string Bldat="";//凭证日期
			string Mblnr="";//凭证号
			
			
			string Returncode;
			SapService.ZSMM_RFC_RCUPTable pt_Kc = new ZSMM_RFC_RCUPTable();
			//SapService.ZSMM_RFC_RCDDTable po_Detail = new ZSMM_RFC_RCDDTable();
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();

			SapOperator oper = new SapOperator(SapUser,SapPass);

			string ID ="";
			if(PiType =="验收入库")
			{
				ID ="105";
			}
			else if(PiType =="代管入库")
			{
				ID ="ZA1";
			}
			else if(PiType=="采购退货")
			{
				ID="124";
			}

#if isSaveHistoryData
			DataTable DtToRF=new DataTable();
			ArrayList arrColumnCollection=new ArrayList(),arrParaCollection=new ArrayList();
			if(PiType =="验收入库" || PiType =="代管入库")
			{
				#region 构造DtToRF 2008-08-19 myl  验收入库  OR  代管入库
			

				//			DataTable DtToRF=new DataTable("ToRF");
				//			DtToRF.Columns.Add(new DataColumn("order_no"));											arrColumnCollection.Add("order_no");
				//			DtToRF.Columns.Add(new DataColumn("item_no",typeof(int)));								arrColumnCollection.Add("item_no");   //序号 
				//			// dt.Columns.Add(new DataColumn("operator_date"));
				//			DtToRF.Columns.Add(new DataColumn("storeman"));											arrColumnCollection.Add("storeman");
				//			DtToRF.Columns.Add(new DataColumn("pzh"));												arrColumnCollection.Add("pzh");
				//			DtToRF.Columns.Add(new DataColumn("pznd"));												arrColumnCollection.Add("pznd");
				//			DtToRF.Columns.Add(new DataColumn("bill_type"));										arrColumnCollection.Add("bill_type");
				//			DtToRF.Columns.Add(new DataColumn("product_barcode"));									arrColumnCollection.Add("product_barcode"); //物料条码 
				//			DtToRF.Columns.Add(new DataColumn("product_desc"));										arrColumnCollection.Add("product_desc");
				//			DtToRF.Columns.Add(new DataColumn("qty",typeof(decimal)));								arrColumnCollection.Add("qty");
				//			DtToRF.Columns.Add(new DataColumn("gch"));												arrColumnCollection.Add("gch");
				//			DtToRF.Columns.Add(new DataColumn("sl"));												arrColumnCollection.Add("sl");
				//			DtToRF.Columns.Add(new DataColumn("bin1"));												arrColumnCollection.Add("bin1");
				//			DtToRF.Columns.Add(new DataColumn("bin1_qty",typeof(decimal)));							arrColumnCollection.Add("bin1_qty");
				//			DtToRF.Columns.Add(new DataColumn("bin2"));												arrColumnCollection.Add("bin2");
				//			DtToRF.Columns.Add(new DataColumn("bin2_qty",typeof(decimal)));							arrColumnCollection.Add("bin2_qty");
				//			DtToRF.Columns.Add(new DataColumn("bin3"));												arrColumnCollection.Add("bin3");
				//			DtToRF.Columns.Add(new DataColumn("bin3_qty",typeof(decimal)));							arrColumnCollection.Add("bin3_qty");
				//			DtToRF.Columns.Add(new DataColumn("remark"));											arrColumnCollection.Add("remark");


			
				arrColumnCollection.Add("order_no");
				arrColumnCollection.Add("item_no");   //序号 
			
				arrColumnCollection.Add("storeman");
				arrColumnCollection.Add("pzh");
				arrColumnCollection.Add("pznd");
				arrColumnCollection.Add("bill_type");
				arrColumnCollection.Add("product_barcode"); //物料条码 
				arrColumnCollection.Add("product_desc");
				arrColumnCollection.Add("qty");
				arrColumnCollection.Add("gch");
				arrColumnCollection.Add("sl");
				arrColumnCollection.Add("bin1");
				arrColumnCollection.Add("bin1_qty");
				arrColumnCollection.Add("bin2");
				arrColumnCollection.Add("bin2_qty");
				arrColumnCollection.Add("bin3");
				arrColumnCollection.Add("bin3_qty");
				arrColumnCollection.Add("remark");



				System.Data.OleDb.OleDbParameter para=new OleDbParameter("@order_no", OleDbType.VarChar, 20, "order_no");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@item_no", OleDbType.Integer, 4, "item_no");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@storeman", OleDbType.VarChar, 20, "storeman");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@pzh", OleDbType.VarChar, 20, "pzh");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@pznd", OleDbType.VarChar, 4, "pznd");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@bill_type", OleDbType.VarChar, 20, "bill_type");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@product_barcode", OleDbType.VarChar,32, "product_barcode");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@product_desc", OleDbType.VarChar, 80, "product_desc");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@qty", OleDbType.Decimal, 8, "qty");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@gch", OleDbType.VarChar, 4, "gch");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@sl", OleDbType.VarChar, 10, "sl");
				arrParaCollection.Add(para);


				para=new OleDbParameter("@bin1", OleDbType.VarChar, 20, "bin1");
				arrParaCollection.Add(para);
				para=new OleDbParameter("@bin1_qty", OleDbType.Decimal, 8, "bin1_qty");
				arrParaCollection.Add(para);
				para=new OleDbParameter("@bin2", OleDbType.VarChar, 20, "bin2");
				arrParaCollection.Add(para);
				para=new OleDbParameter("@bin2_qty", OleDbType.Decimal, 8, "bin2_qty");
				arrParaCollection.Add(para);
				para=new OleDbParameter("@bin3", OleDbType.VarChar, 20, "bin3");
				arrParaCollection.Add(para);
				para=new OleDbParameter("@bin3_qty", OleDbType.Decimal, 8, "bin3_qty");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@remark", OleDbType.VarChar, 40, "remark");
				arrParaCollection.Add(para);
				#endregion
			}
			else
			{	
				#region 采购退货(冻结库退货)

				DtToRF.Columns.Add(new DataColumn("order_no"));											arrColumnCollection.Add("order_no");
				DtToRF.Columns.Add(new DataColumn("item_no"));											arrColumnCollection.Add("item_no");
				DtToRF.Columns.Add(new DataColumn("storeman"));											arrColumnCollection.Add("storeman");
				DtToRF.Columns.Add(new DataColumn("pzh"));												arrColumnCollection.Add("pzh");
				DtToRF.Columns.Add(new DataColumn("pznd"));												arrColumnCollection.Add("pznd");
				DtToRF.Columns.Add(new DataColumn("bill_type"));										arrColumnCollection.Add("bill_type");
				DtToRF.Columns.Add(new DataColumn("product_barcode"));									arrColumnCollection.Add("product_no"); //物料条码 
				DtToRF.Columns.Add(new DataColumn("product_desc"));										arrColumnCollection.Add("product_desc");
				DtToRF.Columns.Add(new DataColumn("qty",typeof(decimal)));								arrColumnCollection.Add("qty");
				DtToRF.Columns.Add(new DataColumn("gch"));												arrColumnCollection.Add("gch");
				DtToRF.Columns.Add(new DataColumn("sl"));												arrColumnCollection.Add("sl");
				DtToRF.Columns.Add(new DataColumn("remark"));											arrColumnCollection.Add("remark");


				System.Data.OleDb.OleDbParameter para=new OleDbParameter("@order_no", OleDbType.VarChar, 20, "order_no");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@item_no", OleDbType.VarChar, 20, "item_no");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@storeman", OleDbType.VarChar, 20, "storeman");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@pzh", OleDbType.VarChar, 20, "pzh");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@pznd", OleDbType.VarChar, 4, "pznd");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@bill_type", OleDbType.VarChar, 20, "bill_type");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@product_barcode", OleDbType.VarChar,32, "product_barcode");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@product_desc", OleDbType.VarChar, 80, "product_desc");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@qty", OleDbType.Decimal, 8, "qty");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@gch", OleDbType.VarChar, 4, "gch");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@sl", OleDbType.VarChar, 10, "sl");
				arrParaCollection.Add(para);

				para=new OleDbParameter("@remark", OleDbType.VarChar, 40, "remark");
				arrParaCollection.Add(para);
				#endregion
			}
#endif
			
			#region 准备数据

			for(int i=0;i<Ds.Tables["Detail"].Rows.Count;i++ )
			{
				//2008-08-12 myl
				if(Ds.Tables["Detail"].Rows[i]["Receive"].ToString().Trim()=="")
				{
					Ds.Tables["Detail"].Rows[i]["Receive"]="0";
				}
				if(Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString()) ==0 )
				{
					continue;
				}
				else
				{
					SapService.ZSMM_RFC_RCUP pop = new ZSMM_RFC_RCUP();
					pop.Ebelp = Ds.Tables["Detail"].Rows[i]["Ebelp"].ToString(); //行项目
					pop.Lgort = Ds.Tables["Detail"].Rows[i]["Lgort"].ToString(); //行项目
					pop.Menge = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString());
					pop.Bct50 = Ds.Tables["Detail"].Rows[i]["Bin1"].ToString(); 
					if(ID=="105")
					{
						pop.Mjahr = Ds.Tables["Detail"].Rows[i]["DocDate"].ToString(); 
						pop.Mblnr = Ds.Tables["Detail"].Rows[i]["DocID"].ToString(); 
						pop.Zeile = Ds.Tables["Detail"].Rows[i]["DocIDItem"].ToString(); 
						string[] val = Ds.Tables["Detail"].Rows[i]["HaveCount"].ToString().Split(new char[]{'|'}); 
					
						System.Decimal minBct51 =Convert.ToDecimal(val[0].Trim() ==""?0:Convert.ToDecimal(val[0].Trim()));
						pop.Bct51 = (Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString()))+minBct51;
						

						pop.Bct60 = Ds.Tables["Detail"].Rows[i]["Bin2"].ToString(); 
						System.Decimal minBct61 =Convert.ToDecimal(val[1].Trim() ==""?0:Convert.ToDecimal(val[1].Trim()));
						pop.Bct61 = (Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString()))+minBct61;
						
						
						pop.Bct70 = Ds.Tables["Detail"].Rows[i]["Bin3"].ToString(); 
						System.Decimal minBct71 =Convert.ToDecimal(val[2].Trim() ==""?0:Convert.ToDecimal(val[2].Trim()));
						pop.Bct71 = (Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString()))+minBct71;


					}
					else if(ID=="ZA1")
					{
						pop.Bct51 = Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString());

						pop.Bct60 = Ds.Tables["Detail"].Rows[i]["Bin2"].ToString(); 
						pop.Bct61 = Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString());
						pop.Bct70 = Ds.Tables["Detail"].Rows[i]["Bin3"].ToString(); 
						
						pop.Bct71 =Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString());
					}
					else
					{
						pop.Mjahr = Ds.Tables["Detail"].Rows[i]["DocDate"].ToString(); 
						pop.Mblnr = Ds.Tables["Detail"].Rows[i]["DocID"].ToString(); 
						pop.Zeile = Ds.Tables["Detail"].Rows[i]["DocIDItem"].ToString(); 
						pop.Reason = Ds.Tables["Detail"].Rows[i]["Reason"].ToString(); 

#if isSaveHistoryData
						#region 添加采购退货的数据到历史数据表中
						DataRow drCGTH=DtToRF.NewRow();
						drCGTH["order_no"]=PoID;
						drCGTH["item_no"]=Convert.ToInt32( pop.Ebelp.Trim());
						drCGTH["storeman"]=User;
						drCGTH["bill_type"]="冻结库退货";
						drCGTH["product_barcode"]=Ds.Tables["Detail"].Rows[i]["Matnr"].ToString();
						drCGTH["product_desc"]=Ds.Tables["Detail"].Rows[i]["Txz01"].ToString();
						drCGTH["qty"]=Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString().Trim());
						drCGTH["gch"]=Ds.Tables["Detail"].Rows[i]["Werks"].ToString();
						drCGTH["sl"]=Ds.Tables["Detail"].Rows[i]["Lgort"].ToString();
						drCGTH["remark"]=Ds.Tables["Detail"].Rows[i]["Reason"].ToString();
						DtToRF.Rows.Add(drCGTH);

						#endregion
#endif

					}
					
					pt_Kc.Add(pop);
				}
			}



			#endregion
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				oper.Functions.Zmm_Rfc_Receive_Upload(Bct10,Budat,ID,Ebeln,out Mblnr ,out Bldat ,out Returncode,/*ref po_Detail,*/ref pt_Kc,ref  Return0);
				if(Returncode.Trim() !="0")
				{
					if(Return0.Count <=0)
					{
						ErrMsg="Sap中出现错误，但是没有返回具体错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
				DocumentID = Mblnr;
				DocDate = Bldat;

#if isSaveHistoryData
				if(PiType =="验收入库" || PiType =="代管入库")
				{
					#region 根据Sap操作成功返回的凭证号获取对应的批次号
                    GetWLPZInfo(Bct10, Bct10, Bldat, Mblnr, PoID, PiType, out DtToRF, out ErrMsg);

					#endregion

					#region Add to DtToRF 2008-08-19 myl
                    InsertInfoToRFdb_yanshourk(arrColumnCollection, arrParaCollection, DtToRF, "t_stockin ", out ErrMsg, ywtm);
					#endregion
				}
				else
				{
					#region 采购退货
					foreach(DataRow dr in DtToRF.Rows)
					{
						dr["pzh"]=Mblnr;
						dr["pznd"]=Bldat;
					}

					InsertInfoToRFdb(arrColumnCollection,arrParaCollection,DtToRF,"t_take_delivery ",out ErrMsg);
					#endregion
				}
#endif

				#region myl 2008-08-20 去
//				System.Data.DataTable dt = new DataTable();
//				string Vendor="";
//				InsertDoc(dt,DocumentID,DocDate,ID,User,Vendor,out ErrMsg);
				#endregion

				return 0;
			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
		}


		/// <summary>
		/// 生产领料提交
		/// </summary>
		/// <param name="User"></param>
		/// <param name="PoID"></param>
		/// <param name="PiType"></param>
		/// <param name="Ds"></param>
		/// <param name="DocumentID"></param>
		/// <param name="DocDate"></param>
		/// <param name="ErrMsg"></param>
        /// <param name="ywtm">一维条码</param>
		/// <returns></returns>
		public int UpdSCLLInfo(string User,string PoID,string PiType,System.Data.DataSet Ds,out string DocumentID,out string DocDate,out string ErrMsg,string ywtm)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			DocDate ="";
			DocumentID="";
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			string Bct10=User;//保管员 
			string Aedat=System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString("00")+System.DateTime.Now.Day.ToString("00") ;//过账日期
			string Ebeln=PoID;//领料单号
			//string Bldat="";//凭证日期
			string Mblnr="";//凭证号
			
			
			string Returncode;
			SapService.ZSMM_RFC_PABTable pt_Kc = new ZSMM_RFC_PABTable();
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();

			SapOperator oper = new SapOperator(SapUser,SapPass);

			string ID ="";
			if(PiType =="生产领料"  ||PiType == "代管出库")
			{
				ID ="Z91";
			}
//			else if(PiType =="代管入库")
//			{
//				ID ="ZA1";
//			}

#if isSaveHistoryData
			#region 构造DtToRF 2008-08-21 myl  生产领料  OR  

			ArrayList arrColumnCollection=new ArrayList(),arrParaCollection=new ArrayList();
			

			DataTable DtToRF=new DataTable("ToRF");
			DtToRF.Columns.Add(new DataColumn("order_no"));											arrColumnCollection.Add("order_no");
			DtToRF.Columns.Add(new DataColumn("item_no",typeof(int)));								arrColumnCollection.Add("item_no");   //序号 
			// dt.Columns.Add(new DataColumn("operator_date"));
			DtToRF.Columns.Add(new DataColumn("storeman"));											arrColumnCollection.Add("storeman");
			DtToRF.Columns.Add(new DataColumn("pzh"));												arrColumnCollection.Add("pzh");
			DtToRF.Columns.Add(new DataColumn("pznd"));												arrColumnCollection.Add("pznd");
			DtToRF.Columns.Add(new DataColumn("bill_type"));										arrColumnCollection.Add("bill_type");
			DtToRF.Columns.Add(new DataColumn("product_barcode"));									arrColumnCollection.Add("product_barcode"); //物料条码 
			DtToRF.Columns.Add(new DataColumn("product_desc"));										arrColumnCollection.Add("product_desc");
			DtToRF.Columns.Add(new DataColumn("qty",typeof(decimal)));								arrColumnCollection.Add("qty");
			DtToRF.Columns.Add(new DataColumn("gch"));												arrColumnCollection.Add("gch");
			DtToRF.Columns.Add(new DataColumn("sl"));												arrColumnCollection.Add("sl");
			DtToRF.Columns.Add(new DataColumn("bin1"));												arrColumnCollection.Add("bin1");
			DtToRF.Columns.Add(new DataColumn("bin1_qty",typeof(decimal)));							arrColumnCollection.Add("bin1_qty");
			DtToRF.Columns.Add(new DataColumn("bin2"));												arrColumnCollection.Add("bin2");
			DtToRF.Columns.Add(new DataColumn("bin2_qty",typeof(decimal)));							arrColumnCollection.Add("bin2_qty");
			DtToRF.Columns.Add(new DataColumn("bin3"));												arrColumnCollection.Add("bin3");
			DtToRF.Columns.Add(new DataColumn("bin3_qty",typeof(decimal)));							arrColumnCollection.Add("bin3_qty");
			DtToRF.Columns.Add(new DataColumn("remark"));											arrColumnCollection.Add("remark");

			System.Data.OleDb.OleDbParameter para=new OleDbParameter("@order_no", OleDbType.VarChar, 20, "order_no");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@item_no", OleDbType.Integer, 4, "item_no");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@storeman", OleDbType.VarChar, 20, "storeman");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@pzh", OleDbType.VarChar, 20, "pzh");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@pznd", OleDbType.VarChar, 4, "pznd");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@bill_type", OleDbType.VarChar, 20, "bill_type");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@product_barcode", OleDbType.VarChar,32, "product_barcode");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@product_desc", OleDbType.VarChar, 80, "product_desc");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@qty", OleDbType.Decimal, 8, "qty");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@gch", OleDbType.VarChar, 4, "gch");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@sl", OleDbType.VarChar, 10, "sl");
			arrParaCollection.Add(para);


			para=new OleDbParameter("@bin1", OleDbType.VarChar, 20, "bin1");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin1_qty", OleDbType.Decimal, 8, "bin1_qty");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin2", OleDbType.VarChar, 20, "bin2");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin2_qty", OleDbType.Decimal, 8, "bin2_qty");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin3", OleDbType.VarChar, 20, "bin3");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin3_qty", OleDbType.Decimal, 8, "bin3_qty");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@remark", OleDbType.VarChar, 40, "remark");
			arrParaCollection.Add(para);
			#endregion
#endif

			
			#region 准备数据

			for(int i=0;i<Ds.Tables["Detail"].Rows.Count;i++ )
			{
				//2008-08-12 myl
				if(Ds.Tables["Detail"].Rows[i]["Receive"].ToString().Trim()=="")
				{
					Ds.Tables["Detail"].Rows[i]["Receive"]="0";
				}

				if(Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString()) ==0 )
				{
					continue;
				}
				else
				{
					SapService.ZSMM_RFC_PAB pop = new ZSMM_RFC_PAB();
					pop.Ebelp = Ds.Tables["Detail"].Rows[i]["Ebelp"].ToString(); //行项目
					pop.Lgort = Ds.Tables["Detail"].Rows[i]["Lgort"].ToString(); //行项目
					pop.Mengw = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString());/////////////////////////////
					pop.Bct50 = Ds.Tables["Detail"].Rows[i]["Bin1"].ToString(); 
					System.Decimal minBct51 =Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString()));
					if(minBct51== Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount1"].ToString()))
					{
						pop.Bct50 ="";
						pop.Bct51 =0;
					}
					else
					{
						pop.Bct51 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount1"].ToString())-minBct51;
					}
					//pop.Bct51 = Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString());

					pop.Bct60 = Ds.Tables["Detail"].Rows[i]["Bin2"].ToString(); 
					System.Decimal minBct61 =Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString()));
					if(minBct61== Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount2"].ToString()))
					{
						pop.Bct60 ="";
						pop.Bct61 =0;
					}
					else
					{
						pop.Bct61 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount2"].ToString())-minBct61;
					}
					//pop.Bct61 = Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString());

					pop.Bct70 = Ds.Tables["Detail"].Rows[i]["Bin3"].ToString(); 

					System.Decimal minBct71 =Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString()));
					if(minBct71== Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount3"].ToString()))
					{
						pop.Bct70 ="";
						pop.Bct71 =0;
					}
					else
					{
						pop.Bct71 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount3"].ToString())-minBct71;
					}
					//pop.Bct71 =Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString());
					
					pt_Kc.Add(pop);

#if isSaveHistoryData
					#region Add to DtToRF 2008-08-21 myl
					DataRow drToRF=DtToRF.NewRow();
					drToRF["order_no"]=PoID; //领料单号
					drToRF["item_no"]=Convert.ToInt32(Ds.Tables["Detail"].Rows[i]["Ebelp"].ToString()); //行项目
					drToRF["storeman"]=User;
					drToRF["bill_type"]=PiType;
					drToRF["product_barcode"]= Ds.Tables["Detail"].Rows[i]["Werks"].ToString()+Ds.Tables["Detail"].Rows[i]["Charg"].ToString()+Ds.Tables["Detail"].Rows[i]["Matnr"].ToString();
					drToRF["product_desc"]= Ds.Tables["Detail"].Rows[i]["Txz01"].ToString();
					drToRF["qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString());
					drToRF["gch"]= Ds.Tables["Detail"].Rows[i]["Werks"].ToString();
					drToRF["sl"]= Ds.Tables["Detail"].Rows[i]["Lgort"].ToString();

					drToRF["bin1"]= Ds.Tables["Detail"].Rows[i]["bin1"].ToString();
					drToRF["bin1_qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString());
					drToRF["bin2"]= Ds.Tables["Detail"].Rows[i]["bin2"].ToString();
					drToRF["bin2_qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString());
					drToRF["bin3"]=Ds.Tables["Detail"].Rows[i]["bin3"].ToString();
					drToRF["bin3_qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString());

					DtToRF.Rows.Add(drToRF);
					#endregion
#endif		
				}
			}


			string MyPlant=Ds.Tables["Detail"].Rows[0]["Werks"].ToString().Trim();

			#endregion
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				oper.Functions.Zmm_Rfc_Lyck_Upload(Aedat,Bct10,ID,Ebeln,MyPlant,out Mblnr ,out Returncode,ref pt_Kc,ref  Return0);
				
				if(Returncode.Trim() !="0")
				{
					if(Return0.Count <=0)
					{
						ErrMsg="Sap中出现错误，但是没有返回具体错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
				DocumentID = Mblnr;
				DocDate = System.DateTime.Now.Year.ToString();

				
				//				System.Data.DataTable dt = new DataTable();
				//				InsertDoc(dt,DocumentID,DocDate,ID,User,out ErrMsg);




#if isSaveHistoryData
				#region Add to DtToRF 2008-08-19 myl
				foreach(DataRow dr in DtToRF.Rows)
				{
					dr["pzh"]=Mblnr;
					dr["pznd"]=DocDate;
				}
                InsertInfoToRFdb_shengchanll(arrColumnCollection, arrParaCollection, DtToRF, "t_stockout", out ErrMsg, ywtm);
				#endregion
#endif

				return 0;
			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
		}


		/// <summary>
		/// 生产领料获取
		/// </summary>
		/// <param name="User"></param>
		/// <param name="PoID"></param>
		/// <param name="piType"></param>
		/// <param name="NeedDetail"></param>
		/// <param name="poDs"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int GetSCLLInfo(string User,string PoID,string piType,bool NeedDetail,out System.Data.DataSet poDs,out string ErrMsg)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			poDs = new DataSet();
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);
			SapService.ZSMM_RFC_POSTable po_Detail  =new ZSMM_RFC_POSTable();
			SapService.ZSMM_RFC_POS po_DetailItem = new ZSMM_RFC_POS();
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			SapService.BAPIRET2 Return0Item = new BAPIRET2();
			

			

			string Reswk; //供方
			
			string Name1;//供应商名称
			
			

			string Returncode =""; //返回值
			#region 构建头表
			System.Data.DataTable Head = new DataTable();
			Head.Columns.Add(new DataColumn("Reswk")); 
			Head.Columns.Add(new DataColumn("Name1")); 
			#endregion

			#region 构建详细表
			System.Data.DataTable Detail = new DataTable();

			Detail.Columns.Add(new DataColumn("Ebeln"));   //采购订单号
			Detail.Columns.Add(new DataColumn("Ebelp",Type.GetType("System.Int32")));   //采购订单行项目
			Detail.Columns.Add(new DataColumn("Werks"));  //工厂号
			Detail.Columns.Add(new DataColumn("Lgort"));  //库存地点
			
			if(piType=="生产领料" ||piType=="代管出库")
			{
				
				Detail.Columns.Add(new DataColumn("Charg"));  //批次
			}
			//测试使用的 e

			Detail.Columns.Add(new DataColumn("Matnr"));  //物料号
			Detail.Columns.Add(new DataColumn("Txz01"));  //物料描述
			Detail.Columns.Add(new DataColumn("Meins"));  //基本单位
			Detail.Columns.Add(new DataColumn("Menge",Type.GetType("System.Decimal"))); //订单数量
			Detail.Columns.Add(new DataColumn("Netpr",Type.GetType("System.Decimal")));//单价
			Detail.Columns.Add(new DataColumn("Mengw",Type.GetType("System.Decimal")));//未清数量
			Detail.Columns.Add(new DataColumn("Receive"));//,Type.GetType("System.Decimal")));//扩展用来表示在枪里面收取的数量
			//Detail.Columns.Add(new DataColumn("Receive",Type.GetType("System.Decimal")));//扩展用来表示在枪里面收取的数量

			if(piType =="生产领料"||piType=="代管出库")
			{
				Detail.Columns.Add(new DataColumn("Bin1"));//扩展用来表示在枪里面货位1
				Detail.Columns.Add(new DataColumn("BinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的实发数量
				Detail.Columns.Add(new DataColumn("RBinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的库存里面有的数量
			
				Detail.Columns.Add(new DataColumn("Bin2"));//扩展用来表示在枪里面货位2
				Detail.Columns.Add(new DataColumn("BinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的实发数量
				Detail.Columns.Add(new DataColumn("RBinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的库存里面有的数量
				Detail.Columns.Add(new DataColumn("Bin3"));//扩展用来表示在枪里面货位3
				Detail.Columns.Add(new DataColumn("BinCount3",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位3的实发数量
				//Detail.Columns.Add(new DataColumn("Desc")); 
				Detail.Columns.Add(new DataColumn("RBinCount3",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位3的库存里面有的数量*/
				Detail.Columns.Add(new DataColumn("Bct10"));//保管员
			}
			
		
			#endregion
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				if(piType =="生产领料")
				{
					oper.Functions.Zmm_Rfc_Lyck_Download(PoID,out Name1,out Reswk,out Returncode,ref  po_Detail,ref  Return0);//生产领料
				}
				else
				{
					oper.Functions.Zmm_Rfc_Dbqc_Download(PoID,out Name1,out Reswk,out Returncode,ref  po_Detail,ref  Return0);//代管出库
				}
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
				
				

				System.Data.DataRow dr =Head.NewRow();
				#region 头 正式
				
				dr["Reswk"]=Reswk.Trim();
				dr["Name1"]=Name1.Trim();
				Head.Rows.Add(dr);
				//				dr["lifnr"]=lifnr.Trim();
				//				dr["Name1"]=Name1.Trim();
				//				dr["ERNAM"]=Ernam.Trim();
				//				dr["name_TextC"]=Ekgrp.Trim();
				#endregion
				
				#region 详细  正式
				
				System.Data.DataTable dt = po_Detail.ToADODataTable();
			 
				
				for(int i=0;i< dt.Rows.Count;i++)
				{
					if(dt.Rows[i]["Bct10"].ToString().Trim()!=User)
					{
						continue;
					}

					System.Data.DataRow dr1 =Detail.NewRow();
					dr1["Ebeln"]=PoID;//dt.Rows[i]["Ebeln"].ToString(); 
					dr1["Ebelp"]=dt.Rows[i]["Ebelp"].ToString();
					dr1["Werks"]=dt.Rows[i]["Werks"].ToString();
					dr1["Lgort"]=dt.Rows[i]["Lgort"].ToString();
					dr1["Txz01"]=dt.Rows[i]["Txz01"].ToString();
					dr1["Matnr"]=dt.Rows[i]["Matnr"].ToString();
					dr1["Charg"]=dt.Rows[i]["Bwtar"].ToString();
					dr1["Meins"]=dt.Rows[i]["Meins"].ToString();
								
					dr1["Menge"]=dt.Rows[i]["Menge"].ToString();
					dr1["Netpr"]=dt.Rows[i]["Netpr"].ToString();
								
					dr1["Mengw"]=dt.Rows[i]["Mengw"].ToString();
					dr1["Bin1"]=dt.Rows[i]["Bct50"].ToString();
					dr1["Bin2"]=dt.Rows[i]["Bct60"].ToString();
					dr1["Bin3"]=dt.Rows[i]["Bct70"].ToString();
					dr1["RBinCount1"]=dt.Rows[i]["Bct51"].ToString();
					dr1["RBinCount2"]=dt.Rows[i]["Bct61"].ToString();
					dr1["RBinCount3"]=dt.Rows[i]["Bct71"].ToString();

					dr1["Bct10"] = dt.Rows[i]["Bct10"].ToString();
dr1["Receive"]="";
					Detail.Rows.Add(dr1);
				}
				if(Detail.Rows.Count<=0)
				{
					ErrMsg="该单据里面没有该保管员需要处理的物料";
					return -1;
				}

				#endregion 
				
				Head.TableName ="Head";
				poDs.Tables.Add(Head);
				Detail.TableName ="Detail";
				poDs.Tables.Add(Detail);

			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
			return 0;
		}


		/// <summary>
		/// 验收退货提交
		/// </summary>
		/// <param name="User"></param>
		/// <param name="PoID"></param>
		/// <param name="PiType"></param>
		/// <param name="Ds"></param>
		/// <param name="DocumentID"></param>
		/// <param name="DocDate"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int UpdYSTHInfo(string User,string PoID,string PiType,System.Data.DataSet Ds,out string DocumentID,out string DocDate,out string ErrMsg)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			DocDate ="";
			DocumentID="";
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			string Bct10=User;//保管员 
			string Aedat=System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString("00")+System.DateTime.Now.Day.ToString("00") ;//过账日期
			string Ebeln=PoID;//领料单号
			//string Bldat="";//凭证日期
			string Mblnr="";//凭证号
			string Mjahr="";//凭证年度
			
			
			string Returncode;
			SapService.ZSMM_RFC_RCUPTable pt_Kc = new ZSMM_RFC_RCUPTable();
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();

			SapOperator oper = new SapOperator(SapUser,SapPass);

#if isSaveHistoryData 

			#region 构造DtToRF 2008-08-25 myl  验收退货  (库存退货)

			ArrayList arrColumnCollection=new ArrayList(),arrParaCollection=new ArrayList();
			

			DataTable DtToRF=new DataTable("ToRF");
			DtToRF.Columns.Add(new DataColumn("order_no"));											arrColumnCollection.Add("order_no");
			DtToRF.Columns.Add(new DataColumn("item_no",typeof(int)));								arrColumnCollection.Add("item_no");   //序号 
			// dt.Columns.Add(new DataColumn("operator_date"));
			DtToRF.Columns.Add(new DataColumn("storeman"));											arrColumnCollection.Add("storeman");
			DtToRF.Columns.Add(new DataColumn("pzh"));												arrColumnCollection.Add("pzh");
			DtToRF.Columns.Add(new DataColumn("pznd"));												arrColumnCollection.Add("pznd");
			DtToRF.Columns.Add(new DataColumn("bill_type"));										arrColumnCollection.Add("bill_type");
			DtToRF.Columns.Add(new DataColumn("product_barcode"));									arrColumnCollection.Add("product_barcode"); //物料条码 
			DtToRF.Columns.Add(new DataColumn("product_desc"));										arrColumnCollection.Add("product_desc");
			DtToRF.Columns.Add(new DataColumn("qty",typeof(decimal)));								arrColumnCollection.Add("qty");
			DtToRF.Columns.Add(new DataColumn("gch"));												arrColumnCollection.Add("gch");
			DtToRF.Columns.Add(new DataColumn("sl"));												arrColumnCollection.Add("sl");
			DtToRF.Columns.Add(new DataColumn("bin1"));												arrColumnCollection.Add("bin1");
			DtToRF.Columns.Add(new DataColumn("bin1_qty",typeof(decimal)));							arrColumnCollection.Add("bin1_qty");
			DtToRF.Columns.Add(new DataColumn("bin2"));												arrColumnCollection.Add("bin2");
			DtToRF.Columns.Add(new DataColumn("bin2_qty",typeof(decimal)));							arrColumnCollection.Add("bin2_qty");
			DtToRF.Columns.Add(new DataColumn("bin3"));												arrColumnCollection.Add("bin3");
			DtToRF.Columns.Add(new DataColumn("bin3_qty",typeof(decimal)));							arrColumnCollection.Add("bin3_qty");
			DtToRF.Columns.Add(new DataColumn("remark"));											arrColumnCollection.Add("remark");

			System.Data.OleDb.OleDbParameter para=new OleDbParameter("@order_no", OleDbType.VarChar, 20, "order_no");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@item_no", OleDbType.Integer, 10, "item_no");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@storeman", OleDbType.VarChar, 20, "storeman");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@pzh", OleDbType.VarChar, 20, "pzh");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@pznd", OleDbType.VarChar, 4, "pznd");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@bill_type", OleDbType.VarChar, 20, "bill_type");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@product_barcode", OleDbType.VarChar,32, "product_barcode");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@product_desc", OleDbType.VarChar, 80, "product_desc");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@qty", OleDbType.Decimal, 8, "qty");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@gch", OleDbType.VarChar, 4, "gch");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@sl", OleDbType.VarChar, 10, "sl");
			arrParaCollection.Add(para);


			para=new OleDbParameter("@bin1", OleDbType.VarChar, 20, "bin1");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin1_qty", OleDbType.Decimal, 8, "bin1_qty");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin2", OleDbType.VarChar, 20, "bin2");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin2_qty", OleDbType.Decimal, 8, "bin2_qty");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin3", OleDbType.VarChar, 20, "bin3");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin3_qty", OleDbType.Decimal, 8, "bin3_qty");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@remark", OleDbType.VarChar, 40, "remark");
			arrParaCollection.Add(para);
			#endregion
#endif
		
			#region 准备数据

			for(int i=0;i<Ds.Tables["Detail"].Rows.Count;i++ )
			{
				//2008-08-12 myl
				if(Ds.Tables["Detail"].Rows[i]["Receive"].ToString().Trim()=="")
				{
					Ds.Tables["Detail"].Rows[i]["Receive"]="0";
				}

				if(Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString()) ==0 )
				{
					continue;
				}
				else
				{
					SapService.ZSMM_RFC_RCUP pop = new ZSMM_RFC_RCUP();
					pop.Ebelp = Ds.Tables["Detail"].Rows[i]["Ebelp"].ToString(); //行项目
					pop.Lgort = Ds.Tables["Detail"].Rows[i]["Lgort"].ToString(); //行项目
					pop.Menge = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString());
					pop.Bct50 = Ds.Tables["Detail"].Rows[i]["Bin1"].ToString(); 
					System.Decimal minBct51 =Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString()));
					if(minBct51== Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount1"].ToString()))
					{
						pop.Bct50 ="";
						pop.Bct51 =0;
					}
					else
					{
						pop.Bct51 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount1"].ToString())-minBct51;
					}
					//pop.Bct51 = Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString());

					pop.Bct60 = Ds.Tables["Detail"].Rows[i]["Bin2"].ToString(); 
					System.Decimal minBct61 =Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString()));
					if(minBct61== Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount2"].ToString()))
					{
						pop.Bct60 ="";
						pop.Bct61 =0;
					}
					else
					{
						pop.Bct61 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount2"].ToString())-minBct61;
					}
					//pop.Bct61 = Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString());

					pop.Bct70 = Ds.Tables["Detail"].Rows[i]["Bin3"].ToString(); 

					System.Decimal minBct71 =Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString()));
					if(minBct71== Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount3"].ToString()))
					{
						pop.Bct70 ="";
						pop.Bct71 =0;
					}
					else
					{
						pop.Bct71 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount3"].ToString())-minBct71;
					}
					
					
					pt_Kc.Add(pop);


#if isSaveHistoryData
					#region Add to DtToRF 2008-08-25 myl 验收退货提交
					DataRow drToRF=DtToRF.NewRow();
					drToRF["order_no"]=PoID; //领料单号
					drToRF["item_no"]=Convert.ToInt32(Ds.Tables["Detail"].Rows[i]["Ebelp"].ToString()); //行项目
					drToRF["storeman"]=User;
					drToRF["bill_type"]=PiType;
					drToRF["product_barcode"]= Ds.Tables["Detail"].Rows[i]["Werks"].ToString()+Ds.Tables["Detail"].Rows[i]["Charg"].ToString()+Ds.Tables["Detail"].Rows[i]["Matnr"].ToString();
					drToRF["product_desc"]= Ds.Tables["Detail"].Rows[i]["Txz01"].ToString();
					drToRF["qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString());
					drToRF["gch"]= Ds.Tables["Detail"].Rows[i]["Werks"].ToString();
					drToRF["sl"]= Ds.Tables["Detail"].Rows[i]["Lgort"].ToString();

					drToRF["bin1"]= Ds.Tables["Detail"].Rows[i]["bin1"].ToString();
					drToRF["bin1_qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString());
					drToRF["bin2"]= Ds.Tables["Detail"].Rows[i]["bin2"].ToString();
					drToRF["bin2_qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString());
					drToRF["bin3"]=Ds.Tables["Detail"].Rows[i]["bin3"].ToString();
					drToRF["bin3_qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString());

					DtToRF.Rows.Add(drToRF);
					#endregion
#endif		
				}
			}



			#endregion
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				oper.Functions.Zmm_Rfc_Poth_Upload(Bct10,Aedat,"101",PoID,out Mblnr ,out Mjahr,out Returncode,ref pt_Kc,ref  Return0);
				if(Returncode.Trim() !="0")
				{
					if(Return0.Count <=0)
					{
						ErrMsg="Sap中出现错误，但是没有返回具体错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
//				DocumentID = Mblnr;
//				DocDate = System.DateTime.Now.Year.ToString();

				DocumentID = Mblnr;
				DocDate = Mjahr;
				//				System.Data.DataTable dt = new DataTable();
				//				InsertDoc(dt,DocumentID,DocDate,"101",User,out ErrMsg);


#if isSaveHistoryData
				#region Add to DtToRF 2008-08-25 myl
				foreach(DataRow dr in DtToRF.Rows)
				{
					dr["pzh"]=Mblnr;
					dr["pznd"]=DocDate;
				}
				InsertInfoToRFdb(arrColumnCollection,arrParaCollection,DtToRF,"t_stockin",out ErrMsg);
				#endregion
#endif
				return 0;
			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
		}
		/// <summary>
		/// Sap上架操作
		/// </summary>
		/// <param name="User"></param>
		/// <param name="piType"></param>
		/// <param name="piDs"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int InBound(string User,string piType,ref System.Data.DataSet piDs,out string ErrMsg)
		{
			//piType 分两种，O代表从sap中取，I代表把数据插入到Sap
			ErrMsg ="";
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);
			string Returncode="";
			SapService.ZSMM_RFC_INBOUNDTable Pt_Inbound =new ZSMM_RFC_INBOUNDTable();
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();

			

			if(piType =="I")
			{

				for(int i=0;i< piDs.Tables[0].Rows.Count;i++)
				{
					SapService.ZSMM_RFC_INBOUND inbound = new ZSMM_RFC_INBOUND();
					inbound.Bct10 =piDs.Tables[0].Rows[i]["Bct10"].ToString();//保管员
					inbound.Bct50 =piDs.Tables[0].Rows[i]["Bct50"].ToString();//货位1
					inbound.Bct51= ((piDs.Tables[0].Rows[i]["Bct51"].ToString().Trim()=="")?0:Convert.ToDecimal(piDs.Tables[0].Rows[i]["Bct51"].ToString())); //货位1数量
					inbound.Bct60=piDs.Tables[0].Rows[i]["Bct60"].ToString();//货位2
					inbound.Bct61=((piDs.Tables[0].Rows[i]["Bct61"].ToString().Trim()=="")?0:Convert.ToDecimal(piDs.Tables[0].Rows[i]["Bct61"].ToString())); //货位2数量
					inbound.Bct70=piDs.Tables[0].Rows[i]["Bct70"].ToString();//货位1
					inbound.Bct71=((piDs.Tables[0].Rows[i]["Bct71"].ToString().Trim()=="")?0:Convert.ToDecimal(piDs.Tables[0].Rows[i]["Bct71"].ToString()));  //货位3数量
					inbound.Bukrs=piDs.Tables[0].Rows[i]["Bukrs"].ToString();//代表公司代码
					inbound.Charg=piDs.Tables[0].Rows[i]["Charg"].ToString();//代表公司批号
					inbound.Lgort=piDs.Tables[0].Rows[i]["Lgort"].ToString();//代表 库存地点
					inbound.Matnr=piDs.Tables[0].Rows[i]["Matnr"].ToString();//代表物料号
					inbound.Menge=Convert.ToDecimal(piDs.Tables[0].Rows[i]["Menge"].ToString());//代表总数量
					
					
					Pt_Inbound.Add(inbound);
				}
			}
			
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				oper.Functions.Zmm_Rfc_Inbound_Ud_Load(piType,out Returncode,ref Pt_Inbound,ref  Return0);
				oper.Close();
				if(Returncode.Trim() !="0")
				{
					if(Return0.Count <=0)
					{
						ErrMsg="Sap中出现错误，但是没有返回具体错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
				if(piType =="O")
				{
					#region 测试
					for(int i=0;i<piDs.Tables[0].Rows.Count;i++ )
					{
						piDs.Tables[0].Rows[i]["Menge"] ="5"; 
					}
					#endregion
					piDs.Tables.Clear();
					System.Data.DataTable dt = Pt_Inbound.ToADODataTable();
					piDs.Tables.Add(dt);
				}
				
				return 0;
			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
		}


		/// <summary>
		/// 获取报废信息
		/// </summary>
		/// <param name="User"></param>
		/// <param name="PoID"></param>
		/// <param name="piType"></param>
		/// <param name="NeedDetail"></param>
		/// <param name="poDs"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int GetBFInfo(string User,string PoID,string piType,bool NeedDetail,out System.Data.DataSet poDs,out string ErrMsg)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			poDs = new DataSet();
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			SapService.BAPIRET2 Return0Item = new BAPIRET2();
			SapService.ZSMM_RFC_PBFTable PBFTab = new ZSMM_RFC_PBFTable();


			SapService.ZSMM_RFC_PBF PBF = new ZSMM_RFC_PBF();
			
			

			

			string Rsnum=PoID; //报废预留单
			
			

			string Returncode =""; //返回值
			#region 构建头表
			System.Data.DataTable Head = new DataTable();
			Head.Columns.Add(new DataColumn("Werks")); 
			Head.Columns.Add(new DataColumn("Lgort")); 
			
			#endregion

			#region 构建详细表
			System.Data.DataTable Detail = new DataTable();

			//PBF.
			Detail.Columns.Add(new DataColumn("Ebeln"));   //采购订单号
			Detail.Columns.Add(new DataColumn("Rspos",Type.GetType("System.Int32")));   //行项目
			Detail.Columns.Add(new DataColumn("Werks"));  //工厂号
			Detail.Columns.Add(new DataColumn("Lgort"));  //库存地点

			Detail.Columns.Add(new DataColumn("Umwrk"));  //目标工厂号
			Detail.Columns.Add(new DataColumn("Umlrt"));  //目标库存地点
			

			Detail.Columns.Add(new DataColumn("Matnr"));  //物料号
			Detail.Columns.Add(new DataColumn("Charg"));  //库存地点
			Detail.Columns.Add(new DataColumn("Txz01"));  //物料描述
			Detail.Columns.Add(new DataColumn("Meins"));  //基本单位
			Detail.Columns.Add(new DataColumn("Menge",Type.GetType("System.Decimal"))); //订单数量
			Detail.Columns.Add(new DataColumn("Netpr",Type.GetType("System.Decimal")));//单价
			Detail.Columns.Add(new DataColumn("Mengw",Type.GetType("System.Decimal")));//未清数量
			Detail.Columns.Add(new DataColumn("Receive",Type.GetType("System.Decimal")));//扩展用来表示在枪里面收取的数量
			
			Detail.Columns.Add(new DataColumn("Bin1"));//扩展用来表示在枪里面货位1
			Detail.Columns.Add(new DataColumn("BinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的实发数量
			Detail.Columns.Add(new DataColumn("RBinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的库存里面有的数量
			
			Detail.Columns.Add(new DataColumn("Bin2"));//扩展用来表示在枪里面货位2
			Detail.Columns.Add(new DataColumn("BinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的实发数量
			Detail.Columns.Add(new DataColumn("RBinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的库存里面有的数量
			Detail.Columns.Add(new DataColumn("Bin3"));//扩展用来表示在枪里面货位3
			Detail.Columns.Add(new DataColumn("BinCount3",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位3的实发数量
			Detail.Columns.Add(new DataColumn("Desc")); 
			Detail.Columns.Add(new DataColumn("RBinCount3",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位3的库存里面有的数量*/
			Detail.Columns.Add(new DataColumn("Bct10"));//保管员
			
			
		
			#endregion
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				
				oper.Functions.Zmm_Rfc_Bf_Download(Rsnum,out Returncode,ref PBFTab,ref Return0);
				//oper.Functions.Zmm_Rfc_Po_Download(ID,PoID,out Ekgrp,out Ekorg,out Ernam,out lifnr,out Name_TextC,out Name1,out Returncode,ref  po_Detail,ref  Return0);
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}

				
				

				#region   正式
				
				System.Data.DataTable dt = PBFTab.ToADODataTable();
				if(dt.Rows.Count >0)
				{
					System.Data.DataRow dr =Head.NewRow();
					dr["Werks"] =dt.Rows[0]["Werks"].ToString();
					dr["Lgort"] =dt.Rows[0]["Lgort"].ToString();
					Head.Rows.Add(dr);
				}
				
				for(int i=0;i< dt.Rows.Count;i++)
				{
					System.Data.DataRow dr1 =Detail.NewRow();
					dr1["Ebeln"]=PoID;
					dr1["Rspos"]=dt.Rows[i]["Rspos"].ToString();
					dr1["Werks"]=dt.Rows[i]["Werks"].ToString();
					dr1["Lgort"]=dt.Rows[i]["Lgort"].ToString();
					dr1["Txz01"]=dt.Rows[i]["Maktx"].ToString();
					dr1["Matnr"]=dt.Rows[i]["Matnr"].ToString();
					dr1["Charg"]=dt.Rows[i]["Charg"].ToString();
					dr1["Meins"]=dt.Rows[i]["ERFME"].ToString();
								
					dr1["Umwrk"]=dt.Rows[i]["Umwrk"].ToString();
					dr1["Umlrt"]=dt.Rows[i]["Umlgo"].ToString();

					dr1["Menge"]=dt.Rows[i]["ERFMG"].ToString();
					//dr1["Netpr"]=dt.Rows[i]["Netpr"].ToString();
								
					dr1["Mengw"]=dt.Rows[i]["Mengw"].ToString();
					dr1["Bin1"]=dt.Rows[i]["Bct50"].ToString();
					dr1["Bin2"]=dt.Rows[i]["Bct60"].ToString();
					dr1["Bin3"]=dt.Rows[i]["Bct70"].ToString();
					dr1["RBinCount1"]=dt.Rows[i]["Bct51"].ToString();
					dr1["RBinCount2"]=dt.Rows[i]["Bct61"].ToString();
					dr1["RBinCount3"]=dt.Rows[i]["Bct71"].ToString();



					
					dr1["Bct10"] = dt.Rows[i]["Bct10"].ToString();
					if(dr1["Bct10"].ToString().Trim()!=User)
					{
						continue;
					}
					Detail.Rows.Add(dr1);
				}
					
				if(Detail.Rows.Count<=0)
				{
					ErrMsg="该报废预留单里面没有该保管员需要处理的信息";
					return -1;
				}
										
				#endregion 
				Head.TableName ="Head";
				poDs.Tables.Add(Head);
				Detail.TableName ="Detail";
				poDs.Tables.Add(Detail);

			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
			

			return 0;
		}


		/// <summary>
		/// 移至报废库上传提交
		/// </summary>
		/// <param name="User"></param>
		/// <param name="PoID"></param>
		/// <param name="PiType"></param>
		/// <param name="Ds"></param>
		/// <param name="DocumentID"></param>
		/// <param name="DocDate"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int UpdBF(string ywtm,string User,string DesUser,string PoID,string PiType,System.Data.DataSet Ds,out string DocumentID,out string DocDate,out string ErrMsg)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			DocDate ="";
			DocumentID="";
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			string Bct10=User;//保管员 
			string Aedat=System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString("00")+System.DateTime.Now.Day.ToString("00") ;//过账日期
			string Ebeln=PoID;//领料单号
			
			string Mblnr="";//凭证号
			string Mjahr="";//凭证日期
			
			
			string Returncode;
			SapService.ZSMM_RFC_PBATable pt_Kc = new ZSMM_RFC_PBATable();
			SapService.ZSMM_RFC_RCTPTable po_Detail = new ZSMM_RFC_RCTPTable();
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();

			SapOperator oper = new SapOperator(SapUser,SapPass);
			

#if isSaveHistoryData
			#region 构造DtToRF 2008-08-21 myl  移至报废库  

			ArrayList arrColumnCollection=new ArrayList(),arrParaCollection=new ArrayList();
			

			DataTable DtToRF=new DataTable("ToRF");
			DtToRF.Columns.Add(new DataColumn("bf_yld"));											arrColumnCollection.Add("bf_yld");    //报废预留单
			//DtToRF.Columns.Add(new DataColumn("item_no",typeof(int)));							arrColumnCollection.Add("item_no");   //序号 
			// dt.Columns.Add(new DataColumn("operator_date"));
			DtToRF.Columns.Add(new DataColumn("storeman"));											arrColumnCollection.Add("storeman");
			DtToRF.Columns.Add(new DataColumn("Dstoreman"));										arrColumnCollection.Add("Dstoreman");//目标保管员
			DtToRF.Columns.Add(new DataColumn("pzh"));												arrColumnCollection.Add("pzh");
			DtToRF.Columns.Add(new DataColumn("pznd"));												arrColumnCollection.Add("pznd");
			//DtToRF.Columns.Add(new DataColumn("bill_type"));										arrColumnCollection.Add("bill_type");
			DtToRF.Columns.Add(new DataColumn("product_barcode"));									arrColumnCollection.Add("product_barcode"); //物料条码 
			DtToRF.Columns.Add(new DataColumn("newCharg"));									        arrColumnCollection.Add("newCharg"); //新的批次 

			DtToRF.Columns.Add(new DataColumn("product_desc"));										arrColumnCollection.Add("product_desc");
			DtToRF.Columns.Add(new DataColumn("product_unit"));										arrColumnCollection.Add("product_unit");
			DtToRF.Columns.Add(new DataColumn("qty",typeof(decimal)));								arrColumnCollection.Add("qty");			
			DtToRF.Columns.Add(new DataColumn("SourceGch"));									    arrColumnCollection.Add("SourceGch");
			DtToRF.Columns.Add(new DataColumn("ssl"));												arrColumnCollection.Add("ssl");			
			DtToRF.Columns.Add(new DataColumn("DestinationGch"));									arrColumnCollection.Add("DestinationGch");
			DtToRF.Columns.Add(new DataColumn("dsl"));												arrColumnCollection.Add("dsl");
			DtToRF.Columns.Add(new DataColumn("bin1"));												arrColumnCollection.Add("bin1");
			DtToRF.Columns.Add(new DataColumn("bin1_qty",typeof(decimal)));							arrColumnCollection.Add("bin1_qty");
			DtToRF.Columns.Add(new DataColumn("bin2"));												arrColumnCollection.Add("bin2");
			DtToRF.Columns.Add(new DataColumn("bin2_qty",typeof(decimal)));							arrColumnCollection.Add("bin2_qty");
			DtToRF.Columns.Add(new DataColumn("bin3"));												arrColumnCollection.Add("bin3");
			DtToRF.Columns.Add(new DataColumn("bin3_qty",typeof(decimal)));							arrColumnCollection.Add("bin3_qty");
			DtToRF.Columns.Add(new DataColumn("remark"));											arrColumnCollection.Add("remark");

			System.Data.OleDb.OleDbParameter para=new OleDbParameter("@bf_yld", OleDbType.VarChar, 20, "bf_yld");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@storeman", OleDbType.VarChar, 20, "storeman");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@Dstoreman", OleDbType.VarChar, 20, "Dstoreman");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@pzh", OleDbType.VarChar, 20, "pzh");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@pznd", OleDbType.VarChar, 4, "pznd");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@product_barcode", OleDbType.VarChar,32, "product_barcode");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@newCharg", OleDbType.VarChar,20, "newCharg");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@product_desc", OleDbType.VarChar, 80, "product_desc");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@product_unit", OleDbType.VarChar, 10, "product_unit");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@qty", OleDbType.Decimal, 8, "qty");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@SourceGch", OleDbType.VarChar, 4, "SourceGch");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@ssl", OleDbType.VarChar, 10, "ssl");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@DestinationGch", OleDbType.VarChar, 4, "DestinationGch");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@dsl", OleDbType.VarChar, 10, "dsl");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@bin1", OleDbType.VarChar, 20, "bin1");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin1_qty", OleDbType.Decimal, 8, "bin1_qty");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin2", OleDbType.VarChar, 20, "bin2");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin2_qty", OleDbType.Decimal, 8, "bin2_qty");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin3", OleDbType.VarChar, 20, "bin3");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin3_qty", OleDbType.Decimal, 8, "bin3_qty");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@remark", OleDbType.VarChar, 40, "remark");
			arrParaCollection.Add(para);
			#endregion
#endif
			string ID ="";
			if(PiType =="移至报废库")
			{
				ID="Z95";
			}


			
			#region 准备数据

			for(int i=0;i<Ds.Tables["Detail"].Rows.Count;i++ )
			{
				if(Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["Receive"].ToString()) ==0 )
				{
					continue;
				}
				else
				{
					SapService.ZSMM_RFC_PBA pop = new ZSMM_RFC_PBA();
					pop.Rspos = Ds.Tables["Detail"].Rows[i]["Rspos"].ToString(); //行项目
					pop.Lgort = Ds.Tables["Detail"].Rows[i]["Lgort"].ToString(); //
					pop.Menge = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString());
					pop.Bct50 = Ds.Tables["Detail"].Rows[i]["Bin1"].ToString(); 

					pop.Bct10=Bct10; //

					pop.Reason =Ds.Tables["Detail"].Rows[i]["Desc"].ToString(); 
					System.Decimal minBct51 =Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString()));
					if(minBct51== Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount1"].ToString()))
					{
						pop.Bct50 ="";
						pop.Bct51 =0;
					}
					else
					{
						pop.Bct51 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount1"].ToString())-minBct51;
					}

					pop.Bct60 = Ds.Tables["Detail"].Rows[i]["Bin2"].ToString(); 
					System.Decimal minBct61 =Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString()));
					if(minBct61== Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount2"].ToString()))
					{
						pop.Bct60 ="";
						pop.Bct61 =0;
					}
					else
					{
						pop.Bct61 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount2"].ToString())-minBct61;
					}

					pop.Bct70 = Ds.Tables["Detail"].Rows[i]["Bin3"].ToString(); 

					System.Decimal minBct71 =Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString().Trim() ==""?0:Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString()));
					if(minBct71== Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount3"].ToString()))
					{
						pop.Bct70 ="";
						pop.Bct71 =0;
					}
					else
					{
						pop.Bct71 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["RBinCount3"].ToString())-minBct71;
					}
					pop.Pct10=DesUser;
//					pop.Pct50 ="99999999";
//					pop.Pct51 = pop.Bct51+pop.Bct61+pop.Bct71;
					pop.Pct50 = Ds.Tables["Detail"].Rows[i]["Bin1"].ToString();
					pop.Pct51 = minBct51;
					if(minBct51==0)
					{
						pop.Pct50 ="";
					}

					pop.Pct60 = Ds.Tables["Detail"].Rows[i]["Bin2"].ToString();
					pop.Pct61 = minBct61;
					if(minBct61==0)
					{
						pop.Pct60="";
					}

					pop.Pct70 = Ds.Tables["Detail"].Rows[i]["Bin3"].ToString();
					pop.Pct71 = minBct71;
					if(minBct71==0)
					{
						pop.Pct70 ="";
					}


					pt_Kc.Add(pop);


#if isSaveHistoryData
					#region Add to DtToRF 2008-08-21 myl
					DataRow drToRF=DtToRF.NewRow();
					drToRF["bf_yld"]=PoID; //报废预留单
					
					drToRF["storeman"]=User;drToRF["Dstoreman"]=DesUser;

					drToRF["product_barcode"]= Ds.Tables["Detail"].Rows[i]["Werks"].ToString()+Ds.Tables["Detail"].Rows[i]["Charg"].ToString()+Ds.Tables["Detail"].Rows[i]["Matnr"].ToString();
					drToRF["product_desc"]= Ds.Tables["Detail"].Rows[i]["Txz01"].ToString();

					drToRF["product_unit"]= Ds.Tables["Detail"].Rows[i]["Meins"].ToString();

					drToRF["qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString());
					drToRF["SourceGch"]= Ds.Tables["Detail"].Rows[i]["Werks"].ToString();
					drToRF["ssl"]= Ds.Tables["Detail"].Rows[i]["Lgort"].ToString();
					drToRF["DestinationGch"]= Ds.Tables["Detail"].Rows[i]["Umwrk"].ToString();
					drToRF["dsl"]= Ds.Tables["Detail"].Rows[i]["Umlrt"].ToString();

					drToRF["bin1"]= Ds.Tables["Detail"].Rows[i]["bin1"].ToString();
					drToRF["bin1_qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString());
					drToRF["bin2"]= Ds.Tables["Detail"].Rows[i]["bin2"].ToString();
					drToRF["bin2_qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString());
					drToRF["bin3"]=Ds.Tables["Detail"].Rows[i]["bin3"].ToString();
					drToRF["bin3_qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString());

					drToRF["remark"]= Ds.Tables["Detail"].Rows[i]["Desc"].ToString();
					DtToRF.Rows.Add(drToRF);
					#endregion
#endif	
				}
			}



			#endregion
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				oper.Functions.Zmm_Rfc_Bf_Upload(Aedat,Bct10,ID,Ebeln,Ds.Tables["Detail"].Rows[0]["Werks"].ToString(),out Mblnr ,out Mjahr,out Returncode,ref po_Detail,ref pt_Kc,ref  Return0);
				if(Returncode.Trim() !="0")
				{
					if(Return0.Count <=0)
					{
						ErrMsg="Sap中出现错误，但是没有返回具体错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
				DocumentID = Mblnr;
				DocDate = Mjahr;


#if isSaveHistoryData
				#region Add to DtToRF 2008-08-21 myl
				foreach(DataRow dr in DtToRF.Rows)
				{
					dr["pzh"]=Mblnr;
					dr["pznd"]=DocDate;
				}

				#region 得到相应的移至报废库后的物料的新的批次信息

#if isSaveNewCharg
				System.Data.DataSet TempDS=new DataSet();
				GetWLPZInfo(User,User,DocDate,Mblnr,out TempDS,out ErrMsg);
				foreach(DataRow dr in DtToRF.Rows)
				{
					//System.Data.DataRow[] oneRow=TempDS.Tables[0].Select("Matnr='"+dr["product_barcode"].ToString().Trim().Substring(14)+"' and Charg='"+dr["product_barcode"].ToString().Trim().Substring(4,10)+"' and Werks='"+dr["SourceGch"].ToString().Trim()+"' and Lgort='"+dr["ssl"].ToString().Trim()+"'");

					int Index=-1;
					for(int k=0;k<TempDS.Tables[0].Rows.Count;k++)
					{
						if(	TempDS.Tables[0].Rows[k]["Werks"].ToString().Trim()==dr["SourceGch"].ToString().Trim()						&&
							TempDS.Tables[0].Rows[k]["Lgort"].ToString().Trim()==dr["ssl"].ToString().Trim()							&& 
							TempDS.Tables[0].Rows[k]["Matnr"].ToString().Trim()==dr["product_barcode"].ToString().Trim().Substring(14)  && 
							TempDS.Tables[0].Rows[k]["Charg"].ToString().Trim()==dr["product_barcode"].ToString().Trim().Substring(4,10)   )
						{
							Index=k;
							break;
						}
						else
						{
							continue;
						}
					}
					dr["newCharg"]=TempDS.Tables[0].Rows[Index+1]["Charg"].ToString();
				}

#endif
				#endregion

                InsertInfoToRFdb_yizhibfk(arrColumnCollection, arrParaCollection, DtToRF, "t_stock_bfk", out ErrMsg, ywtm);

				#endregion
#endif

				#region 2008 08-21 myl 去

//				System.Data.DataTable dt = new DataTable();
//				string Vendor="";
//				InsertDoc(dt,DocumentID,DocDate,ID,User,Vendor,out ErrMsg);
				#endregion

				return 0;
			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
		}


		/// <summary>
		/// 报废出库的上传提交
		/// </summary>
		/// <param name="User"></param>
		/// <param name="Plant"></param>
		/// <param name="Ds"></param>
		/// <param name="DocumentID"></param>
		/// <param name="DocDate"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int UpdBFCK(string User,string Plant,System.Data.DataSet Ds,out string DocumentID,out string DocDate,out string ErrMsg,string ywtm)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			DocDate ="";
			DocumentID="";
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			string Bct10=User;//保管员 
			string Aedat=System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString("00")+System.DateTime.Now.Day.ToString("00") ;//过账日期
			
			
			string Mblnr="";//凭证号
			string Mjahr="";//凭证日期
			


#if isSaveHistoryData
			#region 构造DtToRF 2008-08-22 myl  报废出库 t_stock_bfck 

			ArrayList arrColumnCollection=new ArrayList(),											arrParaCollection=new ArrayList();
			

			DataTable DtToRF=new DataTable("ToRF");
			DtToRF.Columns.Add(new DataColumn("storeman"));											arrColumnCollection.Add("storeman");
			DtToRF.Columns.Add(new DataColumn("pzh"));												arrColumnCollection.Add("pzh");
			DtToRF.Columns.Add(new DataColumn("pznd"));												arrColumnCollection.Add("pznd");
			DtToRF.Columns.Add(new DataColumn("product_barcode"));									arrColumnCollection.Add("product_barcode"); //物料条码 
			DtToRF.Columns.Add(new DataColumn("product_desc"));										arrColumnCollection.Add("product_desc");
			DtToRF.Columns.Add(new DataColumn("product_unit"));										arrColumnCollection.Add("product_unit");
			DtToRF.Columns.Add(new DataColumn("gch"));												arrColumnCollection.Add("gch");
			DtToRF.Columns.Add(new DataColumn("sl"));												arrColumnCollection.Add("sl");
			DtToRF.Columns.Add(new DataColumn("qty",typeof(decimal)));								arrColumnCollection.Add("qty");
			DtToRF.Columns.Add(new DataColumn("bin1"));												arrColumnCollection.Add("bin1");
			DtToRF.Columns.Add(new DataColumn("bin1_qty",typeof(decimal)));							arrColumnCollection.Add("bin1_qty");
			DtToRF.Columns.Add(new DataColumn("bin2"));												arrColumnCollection.Add("bin2");
			DtToRF.Columns.Add(new DataColumn("bin2_qty",typeof(decimal)));							arrColumnCollection.Add("bin2_qty");
			DtToRF.Columns.Add(new DataColumn("bin3"));												arrColumnCollection.Add("bin3");
			DtToRF.Columns.Add(new DataColumn("bin3_qty",typeof(decimal)));							arrColumnCollection.Add("bin3_qty");
			DtToRF.Columns.Add(new DataColumn("remark"));											arrColumnCollection.Add("remark");

			System.Data.OleDb.OleDbParameter para=new OleDbParameter("@storeman", OleDbType.VarChar, 20, "storeman");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@pzh", OleDbType.VarChar, 20, "pzh");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@pznd", OleDbType.VarChar, 4, "pznd");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@product_barcode", OleDbType.VarChar,32, "product_barcode");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@product_desc", OleDbType.VarChar, 80, "product_desc");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@product_unit", OleDbType.VarChar, 10, "product_unit");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@gch", OleDbType.VarChar, 4, "gch");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@sl", OleDbType.VarChar, 10, "sl");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@qty", OleDbType.Decimal, 8, "qty");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@bin1", OleDbType.VarChar, 20, "bin1");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin1_qty", OleDbType.Decimal, 8, "bin1_qty");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin2", OleDbType.VarChar, 20, "bin2");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin2_qty", OleDbType.Decimal, 8, "bin2_qty");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin3", OleDbType.VarChar, 20, "bin3");
			arrParaCollection.Add(para);
			para=new OleDbParameter("@bin3_qty", OleDbType.Decimal, 8, "bin3_qty");
			arrParaCollection.Add(para);

			para=new OleDbParameter("@remark", OleDbType.VarChar, 40, "remark");
			arrParaCollection.Add(para);
			#endregion
#endif


			
			string Returncode;
			SapService.ZSMM_RFC_BFCKTable pt_Kc = new ZSMM_RFC_BFCKTable();
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();

			SapOperator oper = new SapOperator(SapUser,SapPass);

			
			#region 准备数据

			for(int i=0;i<Ds.Tables["Detail"].Rows.Count;i++ )
			{
				//2008-08-12 myl
				if(Ds.Tables["Detail"].Rows[i]["Receive"].ToString().Trim()=="")
				{
					Ds.Tables["Detail"].Rows[i]["Receive"]="0";
				}

				if(Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString()) ==0 )
				{
					continue;
				}
				else
				{
					//注意 这里比较特别，邱晨在系统内是自己去减货位数量的，所以我们不要去处理
					SapService.ZSMM_RFC_BFCK pop = new ZSMM_RFC_BFCK();
					pop.Charg = Ds.Tables["Detail"].Rows[i]["Charg"].ToString();
					pop.Lgort = Ds.Tables["Detail"].Rows[i]["Lgort"].ToString();
					pop.Matnr=Ds.Tables["Detail"].Rows[i]["Matnr"].ToString();
					pop.Menge=Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"]);
					pop.Werks=Ds.Tables["Detail"].Rows[i]["Werks"].ToString();
					string[] HWs = Ds.Tables["Detail"].Rows[i]["HW"].ToString().Split(new char[]{'|'});

					if(HWs[0].Trim()!="")
					{
						pop.Bct51= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString()); 
						if(HWs[1].Trim()!="")
						{
							pop.Bct61 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString());
							pop.Bct71 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString());
						}
						else
						{
							pop.Bct61=0;
							pop.Bct71 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString());
						}
					}
					else if(HWs[1].Trim()!="")
					{
						pop.Bct51=0;
						pop.Bct61 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString());
						pop.Bct71 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString());
					}
					else if(HWs[2].Trim()!="")
					{
						pop.Bct51=0;
						pop.Bct61 =0;
						pop.Bct71 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString());
					}


//					pop.Bct51 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString());
//					pop.Bct61 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString());
//					pop.Bct71 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString());
					
					
					pt_Kc.Add(pop);



#if isSaveHistoryData
					#region Add to DtToRF 2008-08-22 myl 报废出库
					DataRow drToRF=DtToRF.NewRow();
					
					drToRF["storeman"]=User;
					drToRF["product_barcode"]= Ds.Tables["Detail"].Rows[i]["Werks"].ToString()+Ds.Tables["Detail"].Rows[i]["Charg"].ToString()+Ds.Tables["Detail"].Rows[i]["Matnr"].ToString();
					drToRF["product_desc"]= Ds.Tables["Detail"].Rows[i]["Txz01"].ToString();
					drToRF["product_unit"]= Ds.Tables["Detail"].Rows[i]["Meins"].ToString();
					drToRF["gch"]=Plant;// Ds.Tables["Detail"].Rows[i]["Werks"].ToString();
					drToRF["sl"]= Ds.Tables["Detail"].Rows[i]["Lgort"].ToString();
					drToRF["qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Receive"].ToString());
					drToRF["bin1"]= Ds.Tables["Detail"].Rows[i]["bin1"].ToString();
					drToRF["bin1_qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount1"].ToString());
					drToRF["bin2"]= Ds.Tables["Detail"].Rows[i]["bin2"].ToString();
					drToRF["bin2_qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount2"].ToString());
					drToRF["bin3"]=Ds.Tables["Detail"].Rows[i]["bin3"].ToString();
					drToRF["bin3_qty"]= Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString()==""?"0":Ds.Tables["Detail"].Rows[i]["BinCount3"].ToString());

					DtToRF.Rows.Add(drToRF);
					#endregion
#endif	
				}
			}



			#endregion
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				oper.Functions.Zmm_Rfc_Bfck_Upload(Bct10,Aedat,Plant,out Mblnr ,out Mjahr,out Returncode,ref pt_Kc,ref Return0);
				if(Returncode.Trim() !="0")
				{
					if(Return0.Count <=0)
					{
						ErrMsg="Sap中出现错误，但是没有返回具体错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					
					return -1;
				}
				DocumentID = Mblnr;
				DocDate = Mjahr;


#if isSaveHistoryData
				#region Add to DtToRF 2008-08-22 myl
				foreach(DataRow dr in DtToRF.Rows)
				{
					dr["pzh"]=Mblnr;
					dr["pznd"]=Mjahr;
				}
                InsertInfoToRFdb_yizhibfk(arrColumnCollection, arrParaCollection, DtToRF, "t_stock_bfck", out ErrMsg, ywtm);//InsertInfoToRFdb
				#endregion
#endif



				#region myl 2008-08-22 去

//				System.Data.DataTable dt = new DataTable();
//				string Vendor="";
//				InsertDoc(dt,DocumentID,DocDate,"Z97",User,Vendor,out ErrMsg);
				#endregion
				return 0;
			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
		}


		public int GetYSTHInfo(string User,string PoID,string piType,bool NeedDetail,out System.Data.DataSet poDs,out string ErrMsg)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			poDs = new DataSet();
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);
			SapService.ZSMM_RFC_POHTable po_Detail  =new ZSMM_RFC_POHTable();
			SapService.ZSMM_RFC_POH po_DetailItem = new ZSMM_RFC_POH();
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			SapService.BAPIRET2 Return0Item = new BAPIRET2();



			string Ekgrp; //采购组
			string Ekorg; //采购组织
			string lifnr; //供应商编号
			string Name1;//供应商名称
			string Ernam="";//制单员号
			string Name_TextC="";//制单员名字
			
			

			string Returncode =""; //返回值
			#region 构建头表
			System.Data.DataTable Head = new DataTable();
			Head.Columns.Add(new DataColumn("name_TextC")); 
			Head.Columns.Add(new DataColumn("ERNAM")); 
			Head.Columns.Add(new DataColumn("Ekgrp")); 

			Head.Columns.Add(new DataColumn("Ekorg")); 
			Head.Columns.Add(new DataColumn("lifnr")); 
			Head.Columns.Add(new DataColumn("Name1")); 
			#endregion

			#region 构建详细表
			System.Data.DataTable Detail = new DataTable();

			Detail.Columns.Add(new DataColumn("Ebeln"));   //采购订单号
			Detail.Columns.Add(new DataColumn("Ebelp",Type.GetType("System.Int32")));   //采购订单行项目
			Detail.Columns.Add(new DataColumn("Werks"));  //工厂号
			Detail.Columns.Add(new DataColumn("Lgort"));  //库存地点
			
			
				
			Detail.Columns.Add(new DataColumn("Charg"));  //批次
		

			Detail.Columns.Add(new DataColumn("Matnr"));  //物料号
			Detail.Columns.Add(new DataColumn("Txz01"));  //物料描述
			Detail.Columns.Add(new DataColumn("Meins"));  //基本单位
			Detail.Columns.Add(new DataColumn("Menge",Type.GetType("System.Decimal"))); //订单数量
			Detail.Columns.Add(new DataColumn("Netpr",Type.GetType("System.Decimal")));//单价
			Detail.Columns.Add(new DataColumn("Mengw",Type.GetType("System.Decimal")));//未清数量
			Detail.Columns.Add(new DataColumn("Receive",Type.GetType("System.Decimal")));//扩展用来表示在枪里面收取的数量
			
			Detail.Columns.Add(new DataColumn("Bin1"));//扩展用来表示在枪里面货位1
			Detail.Columns.Add(new DataColumn("BinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的实发数量
			Detail.Columns.Add(new DataColumn("RBinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的库存里面有的数量
			
			Detail.Columns.Add(new DataColumn("Bin2"));//扩展用来表示在枪里面货位2
			Detail.Columns.Add(new DataColumn("BinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的实发数量
			Detail.Columns.Add(new DataColumn("RBinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的库存里面有的数量
			Detail.Columns.Add(new DataColumn("Bin3"));//扩展用来表示在枪里面货位3
			Detail.Columns.Add(new DataColumn("BinCount3",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位3的实发数量
			//Detail.Columns.Add(new DataColumn("Desc")); 
			Detail.Columns.Add(new DataColumn("RBinCount3",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位3的库存里面有的数量*/
			Detail.Columns.Add(new DataColumn("Bct10"));//保管员
			
			
		
			#endregion
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				
				oper.Functions.Zmm_Rfc_Poth_Download(PoID,out Ekgrp,out Ekorg,out Ernam,out lifnr,out Name_TextC,out Name1,out Returncode,ref  po_Detail,ref  Return0);
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
				
				

				System.Data.DataRow dr =Head.NewRow();
				#region 头 正式
				
				dr["Ekgrp"]=Ekgrp.Trim();
				dr["Ekorg"]=Ekorg.Trim();
				dr["lifnr"]=lifnr.Trim();
				dr["Name1"]=Name1.Trim();
				dr["ERNAM"]=Ernam.Trim();
				dr["name_TextC"]=Ekgrp.Trim();
				#endregion
				

				Head.Rows.Add(dr);

			
				

				

				#region 详细  正式
				
				System.Data.DataTable dt = po_Detail.ToADODataTable();
			 
									
				for(int i=0;i< dt.Rows.Count;i++)
				{
					System.Data.DataRow dr1 =Detail.NewRow();
					dr1["Ebeln"]=PoID;
					dr1["Ebelp"]=dt.Rows[i]["Ebelp"].ToString();
					dr1["Werks"]=dt.Rows[i]["Werks"].ToString();
					dr1["Lgort"]=dt.Rows[i]["Lgort"].ToString();
					dr1["Txz01"]=dt.Rows[i]["Txz01"].ToString();
					dr1["Matnr"]=dt.Rows[i]["Matnr"].ToString();
					dr1["Charg"]=dt.Rows[i]["Charg"].ToString();
					dr1["Meins"]=dt.Rows[i]["Meins"].ToString();
								
					dr1["Menge"]=dt.Rows[i]["Menge"].ToString();
					dr1["Netpr"]=dt.Rows[i]["Netpr"].ToString();
								
					dr1["Mengw"]=dt.Rows[i]["Mengw"].ToString();
					dr1["Bin1"]=dt.Rows[i]["Bct50"].ToString();
					dr1["Bin2"]=dt.Rows[i]["Bct60"].ToString();
					dr1["Bin3"]=dt.Rows[i]["Bct70"].ToString();
					dr1["RBinCount1"]=dt.Rows[i]["Bct51"].ToString();
					dr1["RBinCount2"]=dt.Rows[i]["Bct61"].ToString();
					dr1["RBinCount3"]=dt.Rows[i]["Bct71"].ToString();
					dr1["Bct10"] = dt.Rows[i]["Bct10"].ToString();
					if(dr1["Bct10"].ToString().Trim()!=User)
					{
						continue;
					}
					Detail.Rows.Add(dr1);
				}
				if(Detail.Rows.Count<=0)
				{
					ErrMsg="该验收退货单中没有该保管员需要处理的物料";
					return -1;
				}
					
				
				
				#endregion 
				
				Head.TableName ="Head";
				poDs.Tables.Add(Head);
				Detail.TableName ="Detail";
				poDs.Tables.Add(Detail);

			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
			

			return 0;
		}
	  

		#endregion

		#region 打印模块
		public int  GetReceiveInfo(string User,string RPo,string Plant,out System.Data.DataSet poDs,out string poErrMsg)
		{
			poErrMsg ="";
			poDs = new DataSet();
			string SapUser,SapPass;
			OutPass pass = new OutPass();
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out poErrMsg))
			{
				return -1;
			}
//			SapOperator oper = new SapOperator(SapUser,SapPass);
//			string Bukrs ="", Mblnr="", Blart="", Bldat="", Lifnr="", Name1="",Returncode="";
//			SapService.BAPIRET2Table Return0 =new BAPIRET2Table();
//			SapService.ZSMM_RFC_RECTable Z_Rec_Msg = new ZSMM_RFC_RECTable();
//			try
//			{
//				MessagePack pack =oper.Open();
//				if(pack.Code !=0)
//				{
//					poErrMsg = pack.Message;
//					return -1;
//				}
//				oper.Functions.Zmm_Rfc_Receive_Download(Bukrs, Mblnr,out Blart,out Bldat,out Lifnr,out  Name1,out Returncode,ref  Return0,ref  Z_Rec_Msg);
//				oper.Close();
//				if(Returncode.Trim() !="0")
//				{
//					if(Return0.Count <=0)
//					{
//						poErrMsg="Sap中出现错误，但是没有返回具体错误信息";
//						return -1;
//					}
//					poErrMsg = Return0[0].Message;
//					return -1;
//				}
//
//				#region 构建头表
//				System.Data.DataTable Head = new DataTable();
//				Head.Columns.Add(new DataColumn("Blart"));//凭证类型
//				Head.Columns.Add(new DataColumn("Bldat"));//
//				Head.Columns.Add(new DataColumn("Lifnr"));//供应商号
//				Head.Columns.Add(new DataColumn("Name1"));//供应商名称
//				System.Data.DataRow dr =Head.NewRow();
//				#region 正式
//				/*dr["Blart"]=Blart;
//				  dr["Bldat"]=Bldat;
//				  dr["Lifnr"]=Lifnr;
//				  dr["Name1"]=Name1;*/
//				#endregion 
//
//				#region 测试
//				dr["Blart"]="121";
//				dr["Bldat"]="213213";
//				dr["Lifnr"]="34";
//				dr["Name1"]="上海太迅";
//				#endregion
//				Head.Rows.Add(dr);
//
//				#endregion
//
//				#region 构建详细表
//				/*SapService.ZSMM_RFC_REC rec = new ZSMM_RFC_REC();
//				rec.Bukrs ="";//公司代码
//				rec.Charg ="";//批次号
//				rec.Ekgrp="";//采购组
//				rec.Ekorg="";//采购组织
//				rec.Lgort="";//库存地点
//				rec.Maktx="";//物料描述
//				rec.Matnr="";//物料号
//				rec.Meins="";//基本单位
//				rec.Menge="";//收货数量
//				rec.Netwr="";//单价
//				rec.Ntgew="";//重量
//				rec.Text ="";//异议原因，验收依据
//				rec.Zeile="";//行项目号*/
//			
//				System.Data.DataTable dt = new DataTable();
//				dt.Columns.Add(new DataColumn("Bukrs"));
//				dt.Columns.Add(new DataColumn("Charg"));
//				dt.Columns.Add(new DataColumn("Ekgrp"));
//				dt.Columns.Add(new DataColumn("Ekorg"));
//				dt.Columns.Add(new DataColumn("Lgort"));
//				dt.Columns.Add(new DataColumn("Maktx"));
//				dt.Columns.Add(new DataColumn("Matnr"));
//				dt.Columns.Add(new DataColumn("Meins"));
//				dt.Columns.Add(new DataColumn("Menge"));
//				dt.Columns.Add(new DataColumn("Netwr"));
//				dt.Columns.Add(new DataColumn("Ntgew"));
//				dt.Columns.Add(new DataColumn("Text"));
//				dt.Columns.Add(new DataColumn("Zeile"));
//				dt.Columns.Add(new DataColumn("PrintCount"));
//				#region 正式
//				/*for(int i=0;i< Z_Rec_Msg.Count;i++)
//				{
//					System.Data.DataRow dr1 =dt.NewRow();
//					dr1["Bukrs"] = Z_Rec_Msg[i].Bukrs;
//					dr1["Charg"]= Z_Rec_Msg[i].Charg ;
//					dr1["Ekgrp"]= Z_Rec_Msg[i].Ekgrp;
//					dr1["Ekorg"]= Z_Rec_Msg[i].Ekorg;
//					dr1["Lgort"]= Z_Rec_Msg[i].Lgort;
//					dr1["Maktx"]= Z_Rec_Msg[i].Maktx;
//					dr1["Matnr"]= Z_Rec_Msg[i].Matnr;
//					dr1["Meins"]= Z_Rec_Msg[i].Meins;
//					dr1["Menge"]= Z_Rec_Msg[i].Menge;
//					dr1["Netwr"]= Z_Rec_Msg[i].Netwr;
//					dr1["Ntgew"]= Z_Rec_Msg[i].Ntgew;
//					dr1["Text"]= Z_Rec_Msg[i].Text ;
//					dr1["Zeile"]= Z_Rec_Msg[i].Zeile;
//					dr1["PrintCount"]= Z_Rec_Msg[i].Menge;//打印数量默认和收货数量一至
//					dt.Rows.Add(dr1);
//
//				}*/
//				#endregion
//
//				#region 测试
//				for(int i=0;i< 9;i++)
//				{
//					System.Data.DataRow dr1 =dt.NewRow();
//					dr1["Bukrs"] = "1";
//					dr1["Charg"]= "1234567890" ;
//					dr1["Ekgrp"]= "1321";
//					dr1["Ekorg"]= "234234";
//					dr1["Lgort"]= "34";
//					dr1["Maktx"]= "可口可乐"+i.ToString();
//					dr1["Matnr"]= "12345678901234567"+i.ToString();
//					dr1["Meins"]= "PC";
//					dr1["Menge"]= "5";
//					dr1["Netwr"]= "3";
//					dr1["Ntgew"]= "2";
//					dr1["Text"]= "损坏" ;
//					dr1["Zeile"]= i.ToString();
//					dr1["PrintCount"]= "5";//打印数量默认和收货数量一至
//					dt.Rows.Add(dr1);
//
//				}
//				#endregion
//
//				#endregion
//				//				System.Data.DataTable dt = new DataTable();
//				//				dt = Z_Rec_Msg.ToADODataTable();
//				dt.TableName="Detail";
//				Head.TableName ="Head";
//				poDs.Tables.Add(Head);
//				poDs.Tables.Add(dt);	
//				return 0;
//			}
//			catch(Exception ex)
//			{
//				poErrMsg = ex.Message;
//				return -1;
//			}
//			finally
//			{
//				oper.Close();
//			}
			return 0;

		}
		#endregion

		#region 盘点模块
		/// <summary>
		/// 获取是否有盘点任务
		/// </summary>
		/// <param name="Operator"></param>
		/// <param name="STOrderDs"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int GetOperatorSTNumber(string Operator,out System.Data.DataSet STOrderDs,out string ErrMsg)
		{
			ErrMsg ="";
			STOrderDs = new DataSet();
			TDB db = new TDB(Global.g_ConStr);
			if(0!=db.OpenDataSet("select STOrder.*,STOrderDetail.OperatorUser from STOrder,STOrderDetail where STOrder.STSerial=STOrderDetail.STSerial and STOrder.STstatus=2 and STOrderDetail.OperatorUser='"+Operator+"'",out STOrderDs))
			{
				ErrMsg ="获取盘点信息失败";
				return -1;
			}
			if(STOrderDs.Tables[0].Rows.Count<=0)
			{
				ErrMsg="你暂时没有盘点任务";
				return -1;
			}
			return 0;

		}

/// <summary>
/// 实时盘点时获取盘点物料的信息
/// </summary>
/// <param name="User"></param>
/// <param name="STNumber"></param>
/// <param name="Plant"></param>
/// <param name="STLocation"></param>
/// <param name="Bin"></param>
/// <param name="Material"></param>
/// <param name="Charg"></param>
/// <param name="ArtName"></param>
/// <param name="Unit"></param>
/// <param name="Operator"></param>
/// <param name="ErrMsg"></param>
/// <returns></returns>
		public int GeMaterialInfo(string User,string STNumber,string Plant,string STLocation,string Bin,string Material,string Charg,out string ArtName,out string Unit,out string Operator ,out string ErrMsg)
		{
			ErrMsg ="";
			Unit ="";
			ArtName ="";
			Operator = "";
			TDB db = new TDB(Global.g_ConStr);
			System.Data.DataTable dt = new DataTable();
			string Sql ="select * from SapStockInfo where STSerial='"+STNumber+"' and Plant='"+Plant+"' and Material='"+Material+"' and BNumber='"+Charg+"'";
			
			if(0!=db.OpenDataSet(Sql,out dt))
			{
				ErrMsg ="获取物料信息失败";
				return -1;
			}
			if(dt.Rows.Count <=0)
			{
				ErrMsg ="库存中没有该物料的信息，你确认要操作么？";
				ArtName ="未知";
				Unit ="未知";
				Operator = "未知";
				return 1;
			}
			else 
			{
				System.Data.DataRow[] drs= dt.Select("SLocation='"+STLocation+"'");
				if(drs.Length <=0)
				{
					Operator = dt.Rows[0]["OperatorUser"].ToString();
					if(User != Operator.Trim())
					{
						ErrMsg ="该物料不属于该用户管理，不能盘点";
						return -1;
					}
					ErrMsg ="该物料在这个库存地点的系统库存中不存在，请确认你现在的库存地点，你确认要操作么？";
					ArtName=dt.Rows[0]["MDesc"].ToString();
					Unit =dt.Rows[0]["UNIT"].ToString();
					
					return 2;
				}
				else
				{
					Operator = drs[0]["OperatorUser"].ToString();
					if(User != Operator.Trim())
					{
						ErrMsg ="该物料不属于该用户管理，不能盘点";
						return -1;
					}
					if(drs[0]["Bin1"].ToString().Trim()!=Bin && drs[0]["Bin2"].ToString().Trim()!=Bin && drs[0]["Bin3"].ToString().Trim()!=Bin)
					{
						ErrMsg = "系统中该物料在该库存地点所在的货位，没有你所输入的，是不是你换了货位忘记扫描了？";
						ArtName =drs[0]["MDesc"].ToString();
						Unit = drs[0]["UNIT"].ToString();
						return 3;
					}
					ArtName =drs[0]["MDesc"].ToString();
					Unit = drs[0]["UNIT"].ToString();
					return 0;
				}
			}

		}


		/// <summary>
		/// 获取某个人已经盘点的信息
		/// </summary>
		/// <param name="User"></param>
		/// <param name="STNumber"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int GeDoSTJobInfo(string User,string STNumber,out System.Data.DataSet Ds,out string ErrMsg)
		{
			ErrMsg ="";
			Ds =new DataSet();
			TDB db = new TDB(Global.g_ConStr);
			System.Data.DataTable dt = new DataTable();
			string @Sql="select STOrigin.plant,STOrigin.SLocation,STOrigin.Material,STOrigin.BNumber,Bin,BinCount,isnull(MDesc,'未知') MDesc,STOrigin.ItemNo from STOrigin left join sapStockInfo on  STOrigin.STSerial=SapStockInfo.STSerial  ";
							Sql +=" and STOrigin.ItemStatus='1' and STOrigin.OperatorUser='"+User+"'"; 
							Sql +=" and STOrigin.Material=SapStockInfo.Material";
							Sql +=" and STOrigin.SLocation=SapStockInfo.SLocation";
							Sql +=" and STOrigin.BNumber=SapStockInfo.BNumber";
							Sql +=" and STOrigin.plant=SapStockInfo.plant";
							Sql +=" where  STOrigin.STSerial="+STNumber; 



			if(0!=db.OpenDataSet(Sql,out dt))
			{
				ErrMsg ="查询数据失败";
				return -1;
			}
			if(dt.Rows.Count <=0)
			{
				ErrMsg="该用户还没有盘点的数据";
				return -1;
			}
			Ds.Tables.Add(dt);
			return 0;

		}


/// <summary>
/// 把盘点错误的行项目状态改成0，代表删除该行项目
/// </summary>
/// <param name="User"></param>
/// <param name="STNumber"></param>
/// <param name="ItemNo"></param>
/// <param name="ErrMsg"></param>
/// <returns></returns>
		public int UpdateItemStaus(string User,string STNumber,string ItemNo,out string ErrMsg)
		{
			ErrMsg ="";
			TDB db = new TDB(Global.g_ConStr);
			System.Data.DataTable dt = new DataTable();
			string @Sql="update STOrigin set ItemStatus='0' where STSerial="+STNumber+" and ItemNo="+ItemNo; 

			if(0>db.ExecSQL(Sql))
			{
				ErrMsg ="更新数据失败";
				return -1;
			}
			return 0;

		}

/// <summary>
/// 用来获取所有该用户需要盘点的信息，同时用字段Checked代表该行项目已经有被盘点过。
/// </summary>
/// <param name="User"></param>
/// <param name="STNumber"></param>
/// <param name="ItemNo"></param>
/// <param name="ErrMsg"></param>
/// <returns></returns>
		public int GetNeedSTInfo(string User,string STNumber,out System.Data.DataSet Ds,out string ErrMsg)
		{
			ErrMsg ="";
			Ds =new DataSet();
			TDB db = new TDB(Global.g_ConStr);
			System.Data.DataTable dt = new DataTable();
			string @Sql="select  sapstockinfo.plant,sapstockinfo.SLocation,sapstockinfo.Material,sapstockinfo.MDesc,sapstockinfo.BNumber,case when s.ItemNo is null then 'F' else 'T' end as Checked from sapstockinfo  left join (select distinct sapStockinfo.ItemNo   from sapstockinfo ,StOrigin "; 
                         Sql+=" where sapStockinfo.STserial="+STNumber ;
						Sql+=" and STOrigin.Material=SapStockInfo.Material and STOrigin.SLocation=SapStockInfo.SLocation and STOrigin.BNumber=SapStockInfo.BNumber and STOrigin.plant=SapStockInfo.plant";
                        Sql+=" and STOrigin.OperatorUser='"+User+"') s on s.ItemNo= sapStockinfo.ItemNo where sapStockinfo.STserial="+STNumber+" and OperatorUser='"+User+"'";


			if(0!=db.OpenDataSet(Sql,out dt))
			{
				ErrMsg ="查询数据失败";
				return -1;
			}
			if(dt.Rows.Count <=0)
			{
				ErrMsg="该用户没有可盘点的数据";
				return -1;
			}
			Ds.Tables.Add(dt);
			return 0;

		}






		public int InSertMaterialCount(string User,string STNumber,string Plant,string STLocation,string Bin,string Material,string Charg,System.Decimal STCount,out string ErrMsg)
		{
			ErrMsg ="";
			TDB db = new TDB(Global.g_ConStr);
			System.Data.DataTable dt = new DataTable();
			if(0!=db.OpenDataSet("select count(*) from STOrder,STOrderDetail where STOrder.STSerial = STOrderDetail.STSerial and STOrder.STSerial='"+STNumber+"' and STStatus=2 and OperatorUser='"+User+"'",out dt))
			{
				ErrMsg ="查询数据失败";
				return -1;
			}
			if(Convert.ToInt32(dt.Rows[0][0].ToString())<=0)
			{
				ErrMsg ="该用户在该盘点状态下已经不能提交数据了，请确认是否本次盘点已经被停止";
				return -1;
			}
			int i=db.ExecSQL("insert into STOrigin (STSerial,Plant,SLocation,Material,BNumber,Bin,BinCount,OperatorUser,ItemStatus) values('"+STNumber+"','"+Plant+"','"+STLocation+"','"+Material+"','"+Charg+"','"+Bin+"',"+STCount+",'"+User+"','1')");
			if(i <=0)
			{
				ErrMsg ="插入数据失败";
				return -1;
			}
			return 0;
		}




		public int InsertBatchMCount(string User,string STNumber,System.Data.DataSet piDs,out string ErrMsg)
		{
			ErrMsg ="";
			TDB db = new TDB(Global.g_ConStr);
			System.Data.DataTable dt = new DataTable();
			if(0!=db.OpenDataSet("select count(*) from STOrder,STOrderDetail where STOrder.STSerial = STOrderDetail.STSerial and STOrder.STSerial='"+STNumber+"' and STStatus=2 and OperatorUser='"+User+"'",out dt))
			{
				ErrMsg ="查询数据失败";
				return -1;
			}
			if(Convert.ToInt32(dt.Rows[0][0].ToString())<=0)
			{
				ErrMsg ="该用户在该盘点状态下已经不能提交数据了，请确认是否本次盘点已经被停止";
				return -1;
			}
			for(int i=piDs.Tables[0].Rows.Count-1;i>=0;i-- )
			{
				if(Convert.ToDecimal(piDs.Tables[0].Rows[i]["Count"].ToString())==0  )
				{
					piDs.Tables[0].Rows.RemoveAt(i);
				}
			}

			/*Matnr"
			 *Charg" 
			 *Burks" 
			 *Lgort" 
			 *Bin")) 
			 *Count" 
			 * 
			 * */


			System.Data.OleDb.OleDbParameter param2 = new System.Data.OleDb.OleDbParameter();
			param2.DbType = DbType.String;
			param2.SourceColumn = "Bukrs";
			param2.ParameterName = "@Bukrs";
			param2.Size = 10;

			System.Data.OleDb.OleDbParameter param3 = new System.Data.OleDb.OleDbParameter();
			param3.DbType = DbType.String;
			param3.SourceColumn = "Lgort";
			param3.ParameterName = "@Lgort";
			param3.Size = 10;

           
			System.Data.OleDb.OleDbParameter param = new System.Data.OleDb.OleDbParameter();
			param.DbType = DbType.String;
			param.SourceColumn = "Matnr";
			param.ParameterName = "@Matnr";
			param.Size = 30;
			// param.Value = "@User_ID";

			System.Data.OleDb.OleDbParameter param1 = new System.Data.OleDb.OleDbParameter();
			param1.DbType = DbType.String;
			param1.SourceColumn = "Charg";
			param1.ParameterName = "@Charg";
			

			// Head
			

			System.Data.OleDb.OleDbParameter param4 = new System.Data.OleDb.OleDbParameter();
			param4.DbType = DbType.String;
			param4.SourceColumn = "Bin";
			param4.ParameterName = "@Bin";
			param4.Size = 10;

			System.Data.OleDb.OleDbParameter param5 = new System.Data.OleDb.OleDbParameter();
			param5.DbType = DbType.Decimal;
			param5.SourceColumn = "Count";
			param5.ParameterName = "@Count";
			


			System.Data.OleDb.OleDbCommand Head = new System.Data.OleDb.OleDbCommand();
			Head.CommandText = "insert into STOrigin (STSerial,Plant,SLocation,Material,BNumber,Bin,BinCount,OperatorUser,ItemStatus) values("+STNumber+",?,?,?,?,?,?,'"+User+"','1')";//(@STSerial,@STType,@STStatus,@STDesc,@STCreateUser)";
			Head.Parameters.Add(param2);
			Head.Parameters.Add(param3);
			Head.Parameters.Add(param);
			Head.Parameters.Add(param1);
			Head.Parameters.Add(param4);
			Head.Parameters.Add(param5);

           

			System.Data.DataTable dt1 = new DataTable();
			dt1 = piDs.Tables[0].Clone();
			for (int i = 0; i < piDs.Tables[0].Rows.Count; i++)
			{
				dt1.Rows.Add(piDs.Tables[0].Rows[i].ItemArray); 
			}

			System.Collections.DictionaryEntry endtry = new System.Collections.DictionaryEntry();
			endtry.Key = Head;
			endtry.Value = dt1;
			System.Collections.ArrayList arr = new System.Collections.ArrayList();
			arr.Add(endtry);
			
			
			
			if(0!=db.ExcuteInsertCommand(arr))
			{
				ErrMsg = "插入盘点单号头信息到数据库失败";
				return -1;
			}
			return 0;
		
		}

		/// <summary>
		/// 下载盘点用户所管理的库存到扫描枪
		/// </summary>
		/// <param name="User"></param>
		/// <param name="STNumber"></param>
		/// <param name="Stream"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int DLOpSTInfo(string User,string STNumber,out byte[] Stream,out string ErrMsg)
		{
			ErrMsg ="";
			Stream = new byte[0];
			TDB db = new TDB(Global.g_ConStr);
			string Sql ="select *,Plant+BNumber+ Material+space(18-len(Material)) as BarCode from SapStockInfo where STSerial='"+STNumber+"' and OperatorUser ='"+User+"' order by BarCode";
			System.Data.DataTable dt = new DataTable();
			if(0!=db.OpenDataSet("select count(*) from STOrder,STOrderDetail where STOrder.STSerial = STOrderDetail.STSerial and STOrder.STSerial='"+STNumber+"' and STStatus=2 and OperatorUser='"+User+"'",out dt))
			{
				ErrMsg ="查询数据失败";
				return -1;
			}
			if(Convert.ToInt32(dt.Rows[0][0].ToString())<=0)
			{
				ErrMsg ="该用户在该盘点状态下已经不能下载系统库存了，请确认是否本次盘点已经被停止";
				return -1;
			}
			if(0!=db.OpenDataSet(Sql,out dt))
			{
				ErrMsg ="获取信息失败";
				return -1;
			}
			System.Text.StringBuilder sb = new System.Text.StringBuilder(10000);
			for(int i=0;i< dt.Rows.Count;i++)
			{
				//myl 2008-08-08 添加库位数量
				string Item="";
				Item+=dt.Rows[i]["BarCode"].ToString()+dt.Rows[i]["SLocation"].ToString().PadLeft(STStruct.SLocationL,' ');
				Item+=AnComm.Utility.padRightSPACE(STStruct.MDescL,dt.Rows[i]["MDesc"].ToString()) + AnComm.Utility.padRightSPACE(STStruct.UNITL,dt.Rows[i]["UNIT"].ToString());
				Item+=AnComm.Utility.padRightSPACE(STStruct.Bin1L,dt.Rows[i]["Bin1"].ToString())  +AnComm.Utility.padRightSPACE(STStruct.Bin2L,dt.Rows[i]["Bin2"].ToString()) ;
				Item+=AnComm.Utility.padRightSPACE(STStruct.Bin3L,dt.Rows[i]["Bin3"].ToString())+"F";
				Item+=AnComm.Utility.padRightSPACE(15,dt.Rows[i]["ACount1"].ToString())+AnComm.Utility.padRightSPACE(15,dt.Rows[i]["ACount2"].ToString())+AnComm.Utility.padRightSPACE(15,dt.Rows[i]["ACount3"].ToString())+"\r\n";
				sb.Append(Item); 
				//


				//sb.Append(dt.Rows[i]["BarCode"].ToString()+dt.Rows[i]["SLocation"].ToString().PadLeft(STStruct.SLocationL,' ')+AnComm.Utility.padRightSPACE(STStruct.MDescL,dt.Rows[i]["MDesc"].ToString()) + AnComm.Utility.padRightSPACE(STStruct.UNITL,dt.Rows[i]["UNIT"].ToString())+AnComm.Utility.padRightSPACE(STStruct.Bin1L,dt.Rows[i]["Bin1"].ToString())  +AnComm.Utility.padRightSPACE(STStruct.Bin2L,dt.Rows[i]["Bin2"].ToString())  +AnComm.Utility.padRightSPACE(STStruct.Bin3L,dt.Rows[i]["Bin3"].ToString())+"F"+"\r\n"); 

			}
			string tempVal =sb.ToString();
			Stream = AnComm.Utility.addZip(System.Text.Encoding.GetEncoding("gb2312").GetBytes(tempVal)); 
			return 0;

		}
		/// <summary>
		/// 用来下载Sap库存到RF系统中
		/// </summary>
		/// <param name="STNumber"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int DownLoadSTInfo(string User,string STNumber,out string ErrMsg)
		{
			ErrMsg ="";
			TDB db = new TDB(Global.g_ConStr);
			System.Data.DataTable dt = new DataTable();
			if (0 != db.OpenDataSet("select * from STOrder where STSerial=" + STNumber + " and STStatus =0", out dt))
			{
				ErrMsg = "获取盘点单号状态失败";
				return -1;
			}
			if (dt.Rows.Count <= 0)
			{
				ErrMsg = "该单据所处的状态不能够进行库存的下载";
				return -1;
			}
			string Werks ="";
			Werks = dt.Rows[0]["Plant"].ToString();
			string DocumentID = dt.Rows[0]["DocumentID"].ToString();

			if (0 != db.OpenDataSet("select count(*) from SapStockInfo where STSerial=" + STNumber, out dt))
			{
				ErrMsg = "获取盘点单号状态失败";
				return -1;
			}
			
			if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
			{
				ErrMsg = "该单据的库存信息已经被下载过了，不能再次下载";
				return -1;
			}
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			string Returncode="";
			
			//从Sap中获取库存信息
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);
			SapService.ZSMM_RFC_PDSMTable P_Getail  =new ZSMM_RFC_PDSMTable();


			ZSMM_RFC_PDSM P_GetailItem = new ZSMM_RFC_PDSM();
			
			
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			SapService.BAPIRET2 Return0Item = new BAPIRET2();
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				
				oper.Functions.Zmm_Rfc_Pdsm_Download(DocumentID,Werks,out Returncode,ref P_Getail,ref Return0);
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}

			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
			
			System.Data.DataTable m_Dt = new DataTable();
			m_Dt = P_Getail.ToADODataTable();

			System.Data.DataTable dtUser = new DataTable();
			dtUser.Columns.Add(new DataColumn("STSerial"));
			dtUser.Columns.Add(new DataColumn("STUser"));
			System.Collections.Hashtable hs = new System.Collections.Hashtable();
			for(int i =0;i< m_Dt.Rows.Count;i++)
			{
				if(hs.ContainsKey(m_Dt.Rows[i]["Bgydm"].ToString().Trim()))
				{
				}
				else
				{
					if(m_Dt.Rows[i]["Bgydm"].ToString().Trim()!="")
					{
						System.Data.DataRow dr =dtUser.NewRow();
						dr["STSerial"]=STNumber;
						dr["STUser"]=m_Dt.Rows[i]["Bgydm"].ToString().Trim();
						dtUser.Rows.Add(dr);
						hs.Add(m_Dt.Rows[i]["Bgydm"].ToString().Trim(),"");
						
					}
				}
			}
			
			System.Data.OleDb.OleDbParameter param1 = new System.Data.OleDb.OleDbParameter();
			param1.DbType = DbType.String;
			param1.SourceColumn = "Werks";
			param1.ParameterName = "@Werks";
			//param2.Size = 10;
			//Plant,SLocation,SubPlant,Material,MDesc,BNumber,UNIT,SPEC,ACount,Bin1,Price,Weight,ACount1,Bin2,ACount2,Bin3,ACount3,OperatorUser 
			System.Data.OleDb.OleDbParameter param2 = new System.Data.OleDb.OleDbParameter();
			param2.DbType = DbType.String;
			param2.SourceColumn = "Lgort";
			param2.ParameterName = "@Lgort";

           
			System.Data.OleDb.OleDbParameter param3 = new System.Data.OleDb.OleDbParameter();
			param3.DbType = DbType.String;
			param3.SourceColumn = "Bct20";
			param3.ParameterName = "@Bct20";
			
			

			System.Data.OleDb.OleDbParameter param4 = new System.Data.OleDb.OleDbParameter();
			param4.DbType = DbType.String;
			param4.SourceColumn = "Matnr";
			param4.ParameterName = "@Matnr";
			
			System.Data.OleDb.OleDbParameter param5 = new System.Data.OleDb.OleDbParameter();
			param5.DbType = DbType.String;
			param5.SourceColumn = "Maktx";
			param5.ParameterName = "@Maktx";
			//BNumber,UNIT,ACount,Bin1,Price,Weight,ACount1,Bin2,ACount2,Bin3,ACount3,OperatorUser 	

			System.Data.OleDb.OleDbParameter param6 = new System.Data.OleDb.OleDbParameter();
			param6.DbType = DbType.String ;
			param6.SourceColumn = "Charg";
			param6.ParameterName = "@Charg";

			System.Data.OleDb.OleDbParameter param7 = new System.Data.OleDb.OleDbParameter();
			param7.DbType = DbType.String ;
			param7.SourceColumn = "Meins";
			param7.ParameterName = "@Meins";

			System.Data.OleDb.OleDbParameter param8 = new System.Data.OleDb.OleDbParameter();
			param8.DbType = DbType.Decimal ;
			param8.SourceColumn = "ZDQKC";
			param8.ParameterName = "@ZDQKC";

			System.Data.OleDb.OleDbParameter param9 = new System.Data.OleDb.OleDbParameter();
			param9.DbType = DbType.String  ;
			param9.SourceColumn = "BCT50";
			param9.ParameterName = "@BCT50";

			System.Data.OleDb.OleDbParameter param10 = new System.Data.OleDb.OleDbParameter();
			param10.DbType = DbType.Decimal  ;
			param10.SourceColumn = "Verpr";
			param10.ParameterName = "@Verpr";

			System.Data.OleDb.OleDbParameter param11 = new System.Data.OleDb.OleDbParameter();
			param11.DbType = DbType.Decimal  ;
			param11.SourceColumn = "BCT51";
			param11.ParameterName = "@BCT51";

			System.Data.OleDb.OleDbParameter param12 = new System.Data.OleDb.OleDbParameter();
			param12.DbType = DbType.String ;
			param12.SourceColumn = "BCT60";
			param12.ParameterName = "@BCT60";

			System.Data.OleDb.OleDbParameter param13 = new System.Data.OleDb.OleDbParameter();
			param13.DbType = DbType.Decimal ;
			param13.SourceColumn = "BCT61";
			param13.ParameterName = "@BCT61";

			System.Data.OleDb.OleDbParameter param14 = new System.Data.OleDb.OleDbParameter();
			param14.DbType = DbType.String ;
			param14.SourceColumn = "BCT70";
			param14.ParameterName = "@BCT70";

			System.Data.OleDb.OleDbParameter param15 = new System.Data.OleDb.OleDbParameter();
			param15.DbType = DbType.Decimal ;
			param15.SourceColumn = "BCT71";
			param15.ParameterName = "@BCT71";

			System.Data.OleDb.OleDbParameter param16 = new System.Data.OleDb.OleDbParameter();
			param16.DbType = DbType.String ;
			param16.SourceColumn = "BGYDM";
			param16.ParameterName = "@BGYDM";
			//ACount1,Bin2,ACount2,Bin3,ACount3,OperatorUser 	

			//ItemNo,STSerial,Plant,SLocation,SubPlant,Material,MDesc,BNumber,UNIT,SPEC,ACount,Bin1,Price,Weight,ACount1,Bin2,ACount2,Bin3,ACount3,OperatorUser    
			
			System.Data.OleDb.OleDbCommand Head = new System.Data.OleDb.OleDbCommand();
			Head.CommandText = @"insert into SapStockInfo (STSerial,Plant,SLocation,SubPlant,Material,MDesc,BNumber,UNIT,ACount,Bin1,Price,ACount1,Bin2,ACount2,Bin3,ACount3,OperatorUser) 
            values('"+STNumber+"',?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";//(@STSerial,@STType,@STStatus,@STDesc,@STCreateUser)";
			Head.Parameters.Add(param1);
			Head.Parameters.Add(param2);
			Head.Parameters.Add(param3);
			Head.Parameters.Add(param4);
			Head.Parameters.Add(param5);
			Head.Parameters.Add(param6);

			Head.Parameters.Add(param7);
			Head.Parameters.Add(param8);
			Head.Parameters.Add(param9);
			Head.Parameters.Add(param10);
			Head.Parameters.Add(param11);
			Head.Parameters.Add(param12);

			Head.Parameters.Add(param13);
			Head.Parameters.Add(param14);
			Head.Parameters.Add(param15);
			Head.Parameters.Add(param16);
			//把信息插入到RF数据库中

			System.Collections.DictionaryEntry endtry = new System.Collections.DictionaryEntry();
			endtry.Key = Head;
			endtry.Value = m_Dt;
			System.Collections.ArrayList arr = new System.Collections.ArrayList();
			arr.Add(endtry);

			System.Data.OleDb.OleDbCommand Detail = new System.Data.OleDb.OleDbCommand();
			Detail.CommandText = "update StOrder set StStatus=1 where STSerial=" + STNumber + " and STStatus =0";
			
			System.Collections.DictionaryEntry endtry1 = new System.Collections.DictionaryEntry();
			endtry1.Key = Detail;
			arr.Add(endtry1);
			

			System.Data.OleDb.OleDbCommand Detail1 = new System.Data.OleDb.OleDbCommand();
			Detail1.CommandText = "insert into StOrderDetail(StSerial,OperatorUser) values(?,?)";
			System.Data.OleDb.OleDbParameter paramD1 = new System.Data.OleDb.OleDbParameter();
			paramD1.DbType = DbType.String  ;
			paramD1.SourceColumn = "STSerial";
			paramD1.ParameterName = "@STSerial";

			System.Data.OleDb.OleDbParameter paramD2 = new System.Data.OleDb.OleDbParameter();
			paramD2.DbType = DbType.String ;
			paramD2.SourceColumn = "STUser";
			paramD2.ParameterName = "@STUser";
			Detail1.Parameters.Add(paramD1);
			Detail1.Parameters.Add(paramD2);
			
			
			System.Collections.DictionaryEntry endtry2 = new System.Collections.DictionaryEntry();
			endtry2.Key = Detail1;
			endtry2.Value =dtUser;
			arr.Add(endtry2);

			if(0!=db.ExcuteInsertCommand(arr))
			{
				ErrMsg = "下载盘点信息到数据库失败";
				return -1;
			}
			return 0;
			
		}



		public int UpLoadSTInfo(string User,string STNumber,out string ErrMsg)
		{
			ErrMsg ="";
			TDB db = new TDB(Global.g_ConStr);
			System.Data.DataTable dt = new DataTable();
            
			if (0 != db.OpenDataSet("select * from STOrder where STSerial=" + STNumber + " and STStatus =4", out dt))
			{
				ErrMsg = "获取盘点单号状态失败";
				return -1;
			}
			if (dt.Rows.Count <= 0)
			{
				ErrMsg = "该单据所处的状态不能够进行库存的上传";
				return -1;
			}
			if(dt.Rows[0]["STType"].ToString()=="1")
			{
				ErrMsg ="该单据为日常盘点的不能被上传至Sap";
				return -1;
			}

            
			string Aedat=System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString("00")+System.DateTime.Now.Day.ToString("00") ;//过账日期
			string Werks ="";
			Werks = dt.Rows[0]["Plant"].ToString();
			string DocumentID = dt.Rows[0]["DocumentID"].ToString();
			if (0 != db.OpenDataSet("select * from STCompare where STSerial=" + STNumber, out dt))
			{
				ErrMsg = "获取盘点汇总数据失败";
				return -1;
			}
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			string Returncode="";
			
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);
			SapService.ZSMM_RFC_PDSZTable P_Getail  =new ZSMM_RFC_PDSZTable();

			
			
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			SapService.BAPIRET2 Return0Item = new BAPIRET2();
			//STSerial,Plant,SLocation,SubPlant,Material,BNumber,SapCount,STCount,Causation,SapBin1,SapBinCount1,SapBin2,SapBinCount2,SapBin3,SapBinCount3,STBin1,STBinCount1,STBin2,STBinCount2,STBin3,STBinCount3,OperatorUser                                       
			for(int i=0;i< dt.Rows.Count;i++)
			{
				ZSMM_RFC_PDSZ P_GetailItem = new ZSMM_RFC_PDSZ();
				P_GetailItem.Bct10= dt.Rows[i]["OperatorUser"].ToString();
				P_GetailItem.Bct50 = dt.Rows[i]["STBin1"].ToString();
				P_GetailItem.Bct51 = Convert.ToDecimal(dt.Rows[i]["STBinCount1"]);

				P_GetailItem.Bct60 = dt.Rows[i]["STBin2"].ToString();
				P_GetailItem.Bct61 = Convert.ToDecimal(dt.Rows[i]["STBinCount2"]);

				P_GetailItem.Bct70 = dt.Rows[i]["STBin3"].ToString();
				P_GetailItem.Bct71 = Convert.ToDecimal(dt.Rows[i]["STBinCount3"]);

				P_GetailItem.Charg = dt.Rows[i]["BNumber"].ToString();
				P_GetailItem.Grund = dt.Rows[i]["Causation"].ToString();
				P_GetailItem.Iblnr = DocumentID;
				P_GetailItem.Lgort = dt.Rows[i]["SLocation"].ToString();
				P_GetailItem.Matnr = dt.Rows[i]["Material"].ToString();
				P_GetailItem.Menge = Convert.ToDecimal(dt.Rows[i]["STCount"].ToString().Trim()==""?"0":dt.Rows[i]["STCount"].ToString().Trim());
				P_GetailItem.State ="X";
				P_GetailItem.Werks = dt.Rows[i]["Plant"].ToString();
				P_GetailItem.Zkczt = "10";
				P_GetailItem.Zldat = Aedat;
				P_GetailItem.Zyksl = Convert.ToDecimal(P_GetailItem.Menge)-Convert.ToDecimal(dt.Rows[i]["SapCount"]);
				P_Getail.Add(P_GetailItem);

			}
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				
				oper.Functions.Zmm_Rfc_Pdsm_Upload(DocumentID,Werks,Aedat,"03",out Returncode,ref P_Getail,ref Return0);
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
			
				System.Collections.ArrayList arr = new System.Collections.ArrayList();
				

				System.Data.OleDb.OleDbCommand Detail = new System.Data.OleDb.OleDbCommand();
				Detail.CommandText = "update StOrder set StStatus=5 where STSerial=" + STNumber + " and STStatus =4";
			
				System.Collections.DictionaryEntry endtry1 = new System.Collections.DictionaryEntry();
				endtry1.Key = Detail;
				arr.Add(endtry1);
			
				if(0!=db.ExcuteInsertCommand(arr))
				{
					ErrMsg = "请注意该盘点凭证已经上传成功，但是在更改盘点状态时出现了错误，请联系系统管理员，请不要再次上传该盘点凭证";
					return -1;
				}
				return 0;

			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
			//return 0;
		}
		#endregion

		#region 移库模块
		public int GoodsMoveGetInfo(string User,ref System.Data.DataSet refDs,out string ErrMsg)
		{
			ErrMsg ="";
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}


			#region 测试构建
			System.Data.DataTable m_ItemDt = new DataTable();
			m_ItemDt.Columns.Add(new DataColumn("Plant"));//工厂号
			m_ItemDt.Columns.Add(new DataColumn("Lgort"));//库存地点
			m_ItemDt.Columns.Add(new DataColumn("Matnr"));//物料号
			m_ItemDt.Columns.Add(new DataColumn("Charg"));//批次
			m_ItemDt.Columns.Add(new DataColumn("Bukrs"));//工厂号
			m_ItemDt.Columns.Add(new DataColumn("Maktx"));//物料描述
			m_ItemDt.Columns.Add(new DataColumn("Bstme"));//单位
			m_ItemDt.Columns.Add(new DataColumn("Netwr"));//单价
			m_ItemDt.Columns.Add(new DataColumn("Ntgew"));//净重
			m_ItemDt.Columns.Add(new DataColumn("Menge"));//库存数量
			m_ItemDt.Columns.Add(new DataColumn("bct50"));//库位1
			m_ItemDt.Columns.Add(new DataColumn("bct51"));//库位1数量
			m_ItemDt.Columns.Add(new DataColumn("bct60"));//库位2
			m_ItemDt.Columns.Add(new DataColumn("bct61"));//库位2数量
			m_ItemDt.Columns.Add(new DataColumn("bct70"));//库位3
			m_ItemDt.Columns.Add(new DataColumn("bct71"));//库位3数量
			System.Data.DataRow dr =m_ItemDt.NewRow();
			dr["Plant"]="2001";
			dr["Lgort"]="2001";
			dr["Matnr"]="1111";
			dr["Charg"]="1111111111";
			dr["Bukrs"]="2001";
			dr["Maktx"]="2001";
			dr["Bstme"]="2001";
			dr["Netwr"]="2001";
			dr["Ntgew"]="2001";
			dr["Menge"]="2001";
			dr["bct50"]="2001";
			dr["bct51"]="2001";
			dr["bct60"]="2002";
			dr["bct61"]="2001";
			dr["bct70"]="2003";
			dr["bct71"]="2001";
			m_ItemDt.Rows.Add(dr);
			refDs.Tables.Clear();
			refDs.Tables.Add(m_ItemDt);

			return 0;






			#endregion
			//SapOperator oper = new SapOperator(SapUser,SapPass);
			//			try
			//			{
			//				MessagePack pack =oper.Open();
			//				if(pack.Code !=0)
			//				{
			//					ErrMsg = pack.Message;
			//					return -1;
			//				}
			//				return 0;
			//			}
			//			catch(Exception ex)
			//			{
			//				ErrMsg =ex.Message;
			//				return -1;
			//			}
			//			finally
			//			{
			//				oper.Close();
			//			}
		}

		
		public int GetYKInfo(string User,string Matnr/*物料号*/,string Charg/*批号*/,string Werks/*工厂*/,string Lgort/*库存地点*/, string piType,bool NeedDetail,out System.Data.DataSet poDs,out string ErrMsg)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			poDs = new DataSet();


//			TDB db = new TDB(Global.g_ConStr);
//			System.Data.DataTable dtAdmin =null;
//			if(0!=db.OpenDataSet("select * from RF_Users where User_ID ='"+User+"'",out dtAdmin))
//			{
//				ErrMsg ="获取用户权限出现错误";
//				return -1;
//			}
//			if(dtAdmin.Rows.Count <=0)
//			{
//				ErrMsg ="获取用户权限出现错误";
//				return -1;
//			}

			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);

			


			SapService.ZSMM_RFC_POTTable G_Detail  =new ZSMM_RFC_POTTable();

			SapService.ZSMM_RFC_POT Line_G_Detail=new ZSMM_RFC_POT();
			SapService.ZSMM_RFC_POMTable P_Detail = new ZSMM_RFC_POMTable();

			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			//SapService.BAPIRET2 Return0Item = new BAPIRET2();
			
			Line_G_Detail.Matnr=Matnr;
			Line_G_Detail.Lgort=Lgort;
			Line_G_Detail.Charg=Charg;
			Line_G_Detail.Werks=Werks;

			G_Detail.Add(Line_G_Detail);


			
			//			string ID ="";
			//			if(piType =="库位移动")
			//			{
			//				ID ="YK";
			//			}
			
			//			string Matnr=""; //物料号
			//			string Charg=""; //批号
			//			string Werks=""; //工厂
			//			string Lgort="";//库存地点
			

			string Returncode =""; //返回值

			#region 构建头表
			//			System.Data.DataTable Head = new DataTable();
			//			Head.Columns.Add(new DataColumn("Matnr")); 
			//			Head.Columns.Add(new DataColumn("Charg")); 
			//			Head.Columns.Add(new DataColumn("Werks")); 
			//			Head.Columns.Add(new DataColumn("Lgort")); 
			#endregion
			#region 构建详细表
			System.Data.DataTable Detail = new DataTable();



			Detail.Columns.Add(new DataColumn("BCT50"));   
			Detail.Columns.Add(new DataColumn("BCT51"));

			Detail.Columns.Add(new DataColumn("BCT60"));   
			Detail.Columns.Add(new DataColumn("BCT61"));

			Detail.Columns.Add(new DataColumn("BCT70"));   
			Detail.Columns.Add(new DataColumn("BCT71"));


			Detail.Columns.Add(new DataColumn("BCT10"));  


			Detail.Columns.Add(new DataColumn("Matnr"));  //物料号
			Detail.Columns.Add(new DataColumn("Charg"));  //批号
			Detail.Columns.Add(new DataColumn("Werks"));  //工厂
			Detail.Columns.Add(new DataColumn("Maktx"));  //物料描述
			Detail.Columns.Add(new DataColumn("Meins"));  //基本计量单位

			Detail.Columns.Add(new DataColumn("Clabs"));  //非限制使用的估价的库存
			

						
			//	Detail.Columns.Add(new DataColumn("Receive",Type.GetType("System.Decimal")));//扩展用来表示在枪里面收取的数量
			//if(ID =="YK")
		{
			Detail.Columns.Add(new DataColumn("Bin1"));//扩展用来表示在枪里面货位1
			Detail.Columns.Add(new DataColumn("BinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的实发数量
			//Detail.Columns.Add(new DataColumn("RBinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的库存里面有的数量
			
			Detail.Columns.Add(new DataColumn("Bin2"));//扩展用来表示在枪里面货位2
			Detail.Columns.Add(new DataColumn("BinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的实发数量
			//Detail.Columns.Add(new DataColumn("RBinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的库存里面有的数量
			Detail.Columns.Add(new DataColumn("Bin3"));//扩展用来表示在枪里面货位3
			Detail.Columns.Add(new DataColumn("BinCount3",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位3的实发数量
			Detail.Columns.Add(new DataColumn("Desc")); 
				
		}
			
		
			#endregion
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				oper.Functions.Zmm_Rfc_Hwyd_Download(out Returncode,ref G_Detail,ref P_Detail,ref Return0);
				
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
				
								
				#region 头 正式
				

				//				System.Data.DataTable dtHeader=G_Detail.ToADODataTable();
				//
				//				foreach(DataRow drEach in dtHeader.Rows)
				//				{
				//					System.Data.DataRow _dr =Head.NewRow();
				//					_dr["Matnr"]=drEach["Matnr"].ToString();
				//					_dr["Charg"]=drEach["Charg"].ToString();
				//					_dr["Werks"]=drEach["Werks"].ToString();
				//					_dr["Lgort"]=drEach["Lgort"].ToString();
				//					Head.Rows.Add(_dr);
				//				}

				#endregion
				
				
				#region 详细  正式
				
				System.Data.DataTable dt =P_Detail.ToADODataTable();
			 
				for(int i=0;i< dt.Rows.Count;i++)
				{
//					if(dtAdmin.Rows[0]["IsAdmin"].ToString().Trim()!="True" )
//					{
						if(dt.Rows[i]["BCT10"].ToString().Trim()!=User)
						{
							continue;
						}
//					} 
					System.Data.DataRow dr1 =Detail.NewRow();
					dr1["BCT50"]=dt.Rows[i]["BCT50"].ToString();
					dr1["BCT51"]=dt.Rows[i]["BCT51"].ToString();

					dr1["BCT60"]=dt.Rows[i]["BCT60"].ToString();
					dr1["BCT61"]=dt.Rows[i]["BCT61"].ToString();

					dr1["BCT70"]=dt.Rows[i]["BCT70"].ToString();
					dr1["BCT71"]=dt.Rows[i]["BCT71"].ToString();

					dr1["BCT10"]=dt.Rows[i]["BCT10"].ToString();
					dr1["Matnr"]=dt.Rows[i]["Matnr"].ToString();

					dr1["Charg"]=dt.Rows[i]["Charg"].ToString();
					dr1["Werks"]=dt.Rows[i]["Werks"].ToString();

					dr1["Maktx"]=dt.Rows[i]["Maktx"].ToString();
					dr1["Meins"]=dt.Rows[i]["Meins"].ToString();
					dr1["Clabs"]=dt.Rows[i]["Clabs"].ToString();

					Detail.Rows.Add(dr1);
				}


				if(Detail.Rows.Count <=0)
				{
					ErrMsg ="该货位上没有该保管员可以移动的物料!";
					return -1;
				}
				
				
				#endregion 
				
				//				Head.TableName ="Head";
				//				poDs.Tables.Add(Head);
				Detail.TableName ="Detail";
				poDs.Tables.Add(Detail);

			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
			

			return 0;
		}

		/// <summary>
		/// 获取移库货物信息
		/// </summary>
		/// <param name="User"></param>
		/// <param name="ds"></param>
		/// <param name="piType"></param>
		/// <param name="NeedDetail"></param>
		/// <param name="poDs"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int GetYKInfo(string User,DataSet ds, string piType,bool NeedDetail,out System.Data.DataSet poDs,out string ErrMsg)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			poDs = new DataSet();

			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);

			


			SapService.ZSMM_RFC_POTTable G_Detail  =new ZSMM_RFC_POTTable();
			
			for(int i =0;i< ds.Tables[0].Rows.Count;i++ )
			{
				SapService.ZSMM_RFC_POT DetailItem = new ZSMM_RFC_POT();
				DetailItem.Matnr = ds.Tables[0].Rows[i]["Matnr"].ToString();
				DetailItem.Charg = ds.Tables[0].Rows[i]["Charg"].ToString();
				DetailItem.Lgort = ds.Tables[0].Rows[i]["Lgort"].ToString();
				DetailItem.Werks= ds.Tables[0].Rows[i]["Werks"].ToString();
				G_Detail.Add(DetailItem);
			}

			
			SapService.ZSMM_RFC_POMTable P_Detail = new ZSMM_RFC_POMTable();

			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			

			//G_Detail.FromADODataTable(ds.Tables[0]);
		

			string Returncode =""; //返回值

			
			#region 构建详细表
			System.Data.DataTable Detail = new DataTable();

			Detail.Columns.Add(new DataColumn("BCT50"));   
			Detail.Columns.Add(new DataColumn("BCT51"));

			Detail.Columns.Add(new DataColumn("BCT60"));   
			Detail.Columns.Add(new DataColumn("BCT61"));

			Detail.Columns.Add(new DataColumn("BCT70"));   
			Detail.Columns.Add(new DataColumn("BCT71"));


			Detail.Columns.Add(new DataColumn("BCT10"));  


			Detail.Columns.Add(new DataColumn("Matnr"));  //物料号
			Detail.Columns.Add(new DataColumn("Charg"));  //批号
			Detail.Columns.Add(new DataColumn("Lgort"));  //库存地点
			Detail.Columns.Add(new DataColumn("Werks"));  //工厂
			Detail.Columns.Add(new DataColumn("Maktx"));  //物料描述
			Detail.Columns.Add(new DataColumn("Meins"));  //基本计量单位

			Detail.Columns.Add(new DataColumn("Clabs"));  //非限制使用的估价的库存
			

						
			//	Detail.Columns.Add(new DataColumn("Receive",Type.GetType("System.Decimal")));//扩展用来表示在枪里面收取的数量
			//if(ID =="YK")
		{
			Detail.Columns.Add(new DataColumn("Bin1"));//扩展用来表示在枪里面货位1
			Detail.Columns.Add(new DataColumn("BinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的实发数量
			//Detail.Columns.Add(new DataColumn("RBinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的库存里面有的数量
			
			Detail.Columns.Add(new DataColumn("Bin2"));//扩展用来表示在枪里面货位2
			Detail.Columns.Add(new DataColumn("BinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的实发数量
			//Detail.Columns.Add(new DataColumn("RBinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的库存里面有的数量
			Detail.Columns.Add(new DataColumn("Bin3"));//扩展用来表示在枪里面货位3
			Detail.Columns.Add(new DataColumn("BinCount3",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位3的实发数量
			Detail.Columns.Add(new DataColumn("Desc")); 
				
		}
			
		
			#endregion
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				oper.Functions.Zmm_Rfc_Hwyd_Download(out Returncode,ref G_Detail,ref P_Detail,ref Return0);
				
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
				
								
				#region 头 正式

				#endregion
				
				
				#region 详细  正式
				
				System.Data.DataTable dt =P_Detail.ToADODataTable();
				string FilterError="";
				for(int i=0;i< dt.Rows.Count;i++)
				{
					System.Data.DataRow dr1 =Detail.NewRow();
					dr1["BCT50"]=dt.Rows[i]["BCT50"].ToString();
					dr1["BCT51"]=dt.Rows[i]["BCT51"].ToString();

					dr1["BCT60"]=dt.Rows[i]["BCT60"].ToString();
					dr1["BCT61"]=dt.Rows[i]["BCT61"].ToString();

					dr1["BCT70"]=dt.Rows[i]["BCT70"].ToString();
					dr1["BCT71"]=dt.Rows[i]["BCT71"].ToString();

					dr1["BCT10"]=dt.Rows[i]["BCT10"].ToString();
					dr1["Matnr"]=dt.Rows[i]["Matnr"].ToString();

					dr1["Charg"]=dt.Rows[i]["Charg"].ToString();
					dr1["Werks"]=dt.Rows[i]["Werks"].ToString();

					dr1["Maktx"]=dt.Rows[i]["Maktx"].ToString();
					dr1["Meins"]=dt.Rows[i]["Meins"].ToString();
					dr1["Clabs"]=dt.Rows[i]["Clabs"].ToString();
					dr1["Lgort"]= dt.Rows[i]["Lgort"].ToString();
					if(dr1["BCT10"].ToString().Trim()!=User)
					{
						FilterError += "物品："+dr1["Maktx"].ToString()+ "物料号："+dr1["Matnr"].ToString()+"批次："+dr1["Charg"].ToString()+"工厂："+dr1["Werks"].ToString()+"库存地点："+dr1["Lgort"].ToString()+"\r\n";
					}
					
					Detail.Rows.Add(dr1);
				}
				if(FilterError.Trim()!="")
				{
					ErrMsg = FilterError+"不是由该保管员保管，你无权获取信息";
					return -1;
				}
				
				
				#endregion 
				
				Detail.TableName ="Detail";
				poDs.Tables.Add(Detail);

			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
			

			return 0;
		}



		public int GetBFCKInfo(string User,DataSet ds, string piType,bool NeedDetail,out System.Data.DataSet poDs,out string ErrMsg)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			poDs = new DataSet();
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);

			


			SapService.ZSMM_RFC_POTTable G_Detail  =new ZSMM_RFC_POTTable();
			
			for(int i =0;i< ds.Tables[0].Rows.Count;i++ )
			{
				SapService.ZSMM_RFC_POT DetailItem = new ZSMM_RFC_POT();
				DetailItem.Matnr = ds.Tables[0].Rows[i]["Matnr"].ToString();
				DetailItem.Charg = ds.Tables[0].Rows[i]["Charg"].ToString();
				DetailItem.Lgort = ds.Tables[0].Rows[i]["Lgort"].ToString();
				DetailItem.Werks= ds.Tables[0].Rows[i]["Werks"].ToString();
				G_Detail.Add(DetailItem);
			}

			
			SapService.ZSMM_RFC_POMTable P_Detail = new ZSMM_RFC_POMTable();

			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			

			//G_Detail.FromADODataTable(ds.Tables[0]);
		

			string Returncode =""; //返回值

			
			#region 构建详细表
			System.Data.DataTable Detail = new DataTable();

			Detail.Columns.Add(new DataColumn("BCT50"));   
			Detail.Columns.Add(new DataColumn("BCT51"));

			Detail.Columns.Add(new DataColumn("BCT60"));   
			Detail.Columns.Add(new DataColumn("BCT61"));

			Detail.Columns.Add(new DataColumn("BCT70"));   
			Detail.Columns.Add(new DataColumn("BCT71"));


			Detail.Columns.Add(new DataColumn("BCT10"));  


			Detail.Columns.Add(new DataColumn("Matnr"));  //物料号
			Detail.Columns.Add(new DataColumn("Charg"));  //批号
			Detail.Columns.Add(new DataColumn("Lgort"));  //库存地点
			Detail.Columns.Add(new DataColumn("Werks"));  //工厂
			Detail.Columns.Add(new DataColumn("Maktx"));  //物料描述
			Detail.Columns.Add(new DataColumn("Meins"));  //基本计量单位

			Detail.Columns.Add(new DataColumn("Clabs"));  //非限制使用的估价的库存
			

						
			//	Detail.Columns.Add(new DataColumn("Receive",Type.GetType("System.Decimal")));//扩展用来表示在枪里面收取的数量
			//if(ID =="YK")
		{
			Detail.Columns.Add(new DataColumn("Bin1"));//扩展用来表示在枪里面货位1
			Detail.Columns.Add(new DataColumn("BinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的实发数量
			//Detail.Columns.Add(new DataColumn("RBinCount1",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位1的库存里面有的数量
			
			Detail.Columns.Add(new DataColumn("Bin2"));//扩展用来表示在枪里面货位2
			Detail.Columns.Add(new DataColumn("BinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的实发数量
			//Detail.Columns.Add(new DataColumn("RBinCount2",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位2的库存里面有的数量
			Detail.Columns.Add(new DataColumn("Bin3"));//扩展用来表示在枪里面货位3
			Detail.Columns.Add(new DataColumn("BinCount3",Type.GetType("System.Decimal")));//扩展用来表示在枪里面货位3的实发数量
			Detail.Columns.Add(new DataColumn("Desc")); 
			Detail.Columns.Add(new DataColumn("HW")); 
				
		}
			
		
			#endregion
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				oper.Functions.Zmm_Rfc_Bfck_Download(out Returncode,ref G_Detail,ref P_Detail,ref Return0);
				
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
				
								
				#region 头 正式

				#endregion
				
				
				#region 详细  正式
				
				System.Data.DataTable dt =P_Detail.ToADODataTable();
				string FilterError ="";
				for(int i=0;i< dt.Rows.Count;i++)
				{
					System.Data.DataRow dr1 =Detail.NewRow();
					dr1["BCT50"]=dt.Rows[i]["BCT50"].ToString().Trim();
					dr1["BCT51"]=dt.Rows[i]["BCT51"].ToString().Trim();

					dr1["BCT60"]=dt.Rows[i]["BCT60"].ToString().Trim();
					dr1["BCT61"]=dt.Rows[i]["BCT61"].ToString().Trim();

					dr1["BCT70"]=dt.Rows[i]["BCT70"].ToString().Trim();
					dr1["BCT71"]=dt.Rows[i]["BCT71"].ToString().Trim();

					dr1["BCT10"]=dt.Rows[i]["BCT10"].ToString().Trim();
					dr1["Matnr"]=dt.Rows[i]["Matnr"].ToString().Trim();

					dr1["Charg"]=dt.Rows[i]["Charg"].ToString().Trim();
					dr1["Werks"]=dt.Rows[i]["Werks"].ToString().Trim();

					dr1["Maktx"]=dt.Rows[i]["Maktx"].ToString().Trim();
					dr1["Meins"]=dt.Rows[i]["Meins"].ToString().Trim();
					dr1["Clabs"]=dt.Rows[i]["Clabs"].ToString().Trim();
					dr1["Lgort"]= dt.Rows[i]["Lgort"].ToString().Trim();
					if(Convert.ToDecimal(dr1["Clabs"]) <=0)
					{
						ErrMsg ="库存数量小于等于零，不能进行报废出库";
						return -1;
					}
					dr1["HW"] =dt.Rows[i]["BCT50"].ToString().Trim()+"|"+ dt.Rows[i]["BCT60"].ToString().Trim()+"|"+ dt.Rows[i]["BCT70"].ToString().Trim();
					if(dr1["BCT10"].ToString().Trim()!=User)
					{
						FilterError += "物品："+dr1["Maktx"].ToString()+ "物料号："+dr1["Matnr"].ToString()+"批次："+dr1["Charg"].ToString()+"工厂："+dr1["Werks"].ToString()+"库存地点："+dr1["Lgort"].ToString()+"\r\n";
					}

					Detail.Rows.Add(dr1);
				}
				if(FilterError.Trim()!="")
				{
					ErrMsg = FilterError+"不是由该保管员保管，你无权获取信息";
					return -1;
				}
				
				
				#endregion 
				
				Detail.TableName ="Detail";
				poDs.Tables.Add(Detail);

			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
			

			return 0;
		}


        public int UpYKInfo(string User, string PiType, System.Data.DataSet Ds, out string ErrMsg, string ywtm)
        {
            OutPass pass = new OutPass();
            string SapUser, SapPass;
            if (0 != pass.DbUserGetSapPass(User, out SapUser, out SapPass, out ErrMsg))
            {
                return -1;
            }

            string Returncode;

            SapService.ZSMM_RFC_POXTable pt_Kc = new ZSMM_RFC_POXTable();
            SapService.BAPIRET2Table Return0 = new BAPIRET2Table();

            SapOperator oper = new SapOperator(SapUser, SapPass);

            //TODO:ToRF : 移库 OR 上架 
#if isSaveHistoryData
            #region 构造DtToRF 2008-08-22 myl  移库 OR 上架

            ArrayList arrColumnCollection = new ArrayList(), arrParaCollection = new ArrayList();


            DataTable DtToRF = new DataTable("ToRF");

            DtToRF.Columns.Add(new DataColumn("storeman")); arrColumnCollection.Add("storeman");
            DtToRF.Columns.Add(new DataColumn("product_barcode")); arrColumnCollection.Add("product_barcode"); //物料条码 
            DtToRF.Columns.Add(new DataColumn("product_desc")); arrColumnCollection.Add("product_desc");
            DtToRF.Columns.Add(new DataColumn("product_unit")); arrColumnCollection.Add("product_unit");
            DtToRF.Columns.Add(new DataColumn("gch")); arrColumnCollection.Add("gch");
            DtToRF.Columns.Add(new DataColumn("sl")); arrColumnCollection.Add("sl");
            DtToRF.Columns.Add(new DataColumn("bill_type")); arrColumnCollection.Add("bill_type");
            DtToRF.Columns.Add(new DataColumn("qty", typeof(decimal))); arrColumnCollection.Add("qty");
            DtToRF.Columns.Add(new DataColumn("bin1")); arrColumnCollection.Add("bin1");
            DtToRF.Columns.Add(new DataColumn("bin1_qty", typeof(decimal))); arrColumnCollection.Add("bin1_qty");
            DtToRF.Columns.Add(new DataColumn("bin2")); arrColumnCollection.Add("bin2");
            DtToRF.Columns.Add(new DataColumn("bin2_qty", typeof(decimal))); arrColumnCollection.Add("bin2_qty");
            DtToRF.Columns.Add(new DataColumn("bin3")); arrColumnCollection.Add("bin3");
            DtToRF.Columns.Add(new DataColumn("bin3_qty", typeof(decimal))); arrColumnCollection.Add("bin3_qty");
            DtToRF.Columns.Add(new DataColumn("remark")); arrColumnCollection.Add("remark");


            System.Data.OleDb.OleDbParameter para = new OleDbParameter("@storeman", OleDbType.VarChar, 20, "storeman");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@product_barcode", OleDbType.VarChar, 32, "product_barcode");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@product_desc", OleDbType.VarChar, 80, "product_desc");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@product_unit", OleDbType.VarChar, 10, "product_unit");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@gch", OleDbType.VarChar, 4, "gch");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@sl", OleDbType.VarChar, 10, "sl");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@bill_type", OleDbType.VarChar, 20, "bill_type");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@qty", OleDbType.Decimal, 8, "qty");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@bin1", OleDbType.VarChar, 20, "bin1");
            arrParaCollection.Add(para);
            para = new OleDbParameter("@bin1_qty", OleDbType.Decimal, 8, "bin1_qty");
            arrParaCollection.Add(para);
            para = new OleDbParameter("@bin2", OleDbType.VarChar, 20, "bin2");
            arrParaCollection.Add(para);
            para = new OleDbParameter("@bin2_qty", OleDbType.Decimal, 8, "bin2_qty");
            arrParaCollection.Add(para);
            para = new OleDbParameter("@bin3", OleDbType.VarChar, 20, "bin3");
            arrParaCollection.Add(para);
            para = new OleDbParameter("@bin3_qty", OleDbType.Decimal, 8, "bin3_qty");
            arrParaCollection.Add(para);

            para = new OleDbParameter("@remark", OleDbType.VarChar, 40, "remark");
            arrParaCollection.Add(para);
            #endregion
#endif

            #region 准备数据

            for (int i = 0; i < Ds.Tables["Detail"].Rows.Count; i++)
            {
                //SapService.ZSMM_RFC_POX pox = new ZSMM_RFC_POX();
                ZSMM_RFC_POX pox = (ZSMM_RFC_POX)pt_Kc.CreateNewRow();


                pox.Bct50 = Ds.Tables["Detail"].Rows[i]["Bct50"].ToString();
                pox.Bct51 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Bct51"].ToString() == "" ? "0" : Ds.Tables["Detail"].Rows[i]["Bct51"].ToString());
                pox.Bct60 = Ds.Tables["Detail"].Rows[i]["Bct60"].ToString();
                pox.Bct61 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Bct61"].ToString() == "" ? "0" : Ds.Tables["Detail"].Rows[i]["Bct61"].ToString());
                pox.Bct70 = Ds.Tables["Detail"].Rows[i]["Bct70"].ToString();
                pox.Bct71 = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Bct71"].ToString() == "" ? "0" : Ds.Tables["Detail"].Rows[i]["Bct71"].ToString());

                pox.Charg = Ds.Tables["Detail"].Rows[i]["Charg"].ToString();//批号
                pox.Lgort = Ds.Tables["Detail"].Rows[i]["Lgort"].ToString();//库存地点
                pox.Matnr = Ds.Tables["Detail"].Rows[i]["Matnr"].ToString();//物料号
                pox.Werks = Ds.Tables["Detail"].Rows[i]["Werks"].ToString(); //工厂

                pox.Bct10 = Ds.Tables["Detail"].Rows[i]["Bct10"].ToString(); //长度为6的字符字段（保管员）

                pt_Kc.Add(pox);

                //TODO:获取移库或者上架的信息到ToRF
#if isSaveHistoryData

                #region Add to DtToRF 2008-08-22 myl
                DataRow drToRF = DtToRF.NewRow();
                drToRF["storeman"] = Ds.Tables["Detail"].Rows[i]["Bct10"].ToString();
                drToRF["bill_type"] = PiType;
                drToRF["product_barcode"] = Ds.Tables["Detail"].Rows[i]["Werks"].ToString().Trim() + Ds.Tables["Detail"].Rows[i]["Charg"].ToString().Trim() + Ds.Tables["Detail"].Rows[i]["Matnr"].ToString().Trim();
                drToRF["product_desc"] = Ds.Tables["Detail"].Rows[i]["Maktx"].ToString();
                drToRF["product_unit"] = Ds.Tables["Detail"].Rows[i]["Meins"].ToString();

                drToRF["qty"] = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Clabs"].ToString());
                drToRF["gch"] = Ds.Tables["Detail"].Rows[i]["Werks"].ToString();
                drToRF["sl"] = Ds.Tables["Detail"].Rows[i]["Lgort"].ToString();

                drToRF["bin1"] = Ds.Tables["Detail"].Rows[i]["Bct50"].ToString();
                drToRF["bin1_qty"] = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Bct51"].ToString() == "" ? "0" : Ds.Tables["Detail"].Rows[i]["Bct51"].ToString());
                drToRF["bin2"] = Ds.Tables["Detail"].Rows[i]["Bct60"].ToString();
                drToRF["bin2_qty"] = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Bct61"].ToString() == "" ? "0" : Ds.Tables["Detail"].Rows[i]["Bct61"].ToString());
                drToRF["bin3"] = Ds.Tables["Detail"].Rows[i]["Bct70"].ToString();
                drToRF["bin3_qty"] = Convert.ToDecimal(Ds.Tables["Detail"].Rows[i]["Bct71"].ToString() == "" ? "0" : Ds.Tables["Detail"].Rows[i]["Bct71"].ToString());

                DtToRF.Rows.Add(drToRF);
                #endregion

#endif
            }
            #endregion
            try
            {
                MessagePack pack = oper.Open();
                if (pack.Code != 0)
                {
                    ErrMsg = pack.Message;
                    return -1;
                }

                oper.Functions.Zmm_Rfc_Hwyd_Upload(out Returncode, ref pt_Kc, ref Return0);
                //
                //
                if (Returncode.Trim() != "0")
                {
                    if (Return0.Count <= 0)
                    {
                        ErrMsg = "Sap中出现错误，但是没有返回具体错误信息";
                        return -1;
                    }

                    for (int i = 0; i < Return0.Count; i++)
                    {
                        ErrMsg += Return0[i].Message + "\r\n";
                    }
                    return -1;
                }


#if isSaveHistoryData

                InsertInfoToRFdb_shangjia(arrColumnCollection, arrParaCollection, DtToRF, "t_stock_op ", out ErrMsg, ywtm);
#endif

                return 0;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return -1;
            }
            finally
            {
                oper.Close();
            }
        }


		#endregion

		#region 查询模块


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
		public int GetHWCXInfo(string User,string BaoGuanYuan/*保管员*/,string HuoWei/*货位*/,string Lgort/*库存地点*/,string Werks/*工厂*/,out System.Data.DataSet cxDs,out string ErrMsg)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			cxDs = new DataSet();


			TDB db = new TDB(Global.g_ConStr);
			System.Data.DataTable dt1 =null;
			if(0!=db.OpenDataSet("select * from RF_Users where User_ID ='"+User+"'",out dt1))
			{
				ErrMsg ="获取用户权限出现错误";
				return -1;
			}
			if(dt1.Rows.Count <=0)
			{
				ErrMsg ="获取用户权限出现错误";
				return -1;
			}
			if(dt1.Rows[0]["IsAdmin"].ToString().Trim()!="True" &&User !=BaoGuanYuan)
			{
				ErrMsg ="你不是管理员，无权查询别的保管员保管的物品";
				return -1;
			}


			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);
			SapService.ZSMM_RFC_HUOWCXTable hwcx_Detail=new ZSMM_RFC_HUOWCXTable();
			//SapService.ZSMM_RFC_HUOWCX hwcx =new ZSMM_RFC_HUOWCX();
			
		
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			string Returncode =""; //返回值

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
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				
				oper.Functions.Zmm_Rfc_Hwcx_Dwnload(BaoGuanYuan,HuoWei,Lgort,Werks,out Returncode,ref hwcx_Detail,ref Return0);
				
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
				
				#region GetData From SAP Table
				
				SapService.ZSMM_RFC_HUOWCX [] hwcx_All =new ZSMM_RFC_HUOWCX[hwcx_Detail.Count];
				hwcx_Detail.CopyTo(hwcx_All,0);

				foreach(SapService.ZSMM_RFC_HUOWCX hwcx in hwcx_All)
				{
					System.Data.DataRow drNew =Detail.NewRow();
					drNew["Werks"]=hwcx.Werks;
					drNew["Matnr"]=hwcx.Matnr;
					drNew["Charg"]=hwcx.Charg;
					drNew["Lgort"]=hwcx.Lgort;
					drNew["Maktx"]=hwcx.Maktx;
					drNew["Meins"]=hwcx.Meins;

					drNew["Bct50"]=hwcx.Bct50;
					drNew["Bct51"]=hwcx.Bct51;
					drNew["Bct60"]=hwcx.Bct60;
					drNew["Bct61"]=hwcx.Bct61;
					drNew["Bct70"]=hwcx.Bct70;
					drNew["Bct71"]=hwcx.Bct71;

					drNew["Bct10"]=hwcx.Bct10;
					drNew["Bct20"]=hwcx.Bct20;
					drNew["Ebeln"]=hwcx.Ebeln;//采购订单号
					drNew["Name1"]=hwcx.Name1;//供应商
					drNew["Ntgew"]=hwcx.Ntgew;//净重
					drNew["Verpr"]=hwcx.Verpr;//周期单价
					drNew["Menge"]=hwcx.Clabs;//数量
					
					if(dt1.Rows[0]["IsAdmin"].ToString().Trim()!="True" )
					{
						if(drNew["Bct10"].ToString().Trim()!=User)
						{
							continue;
						}
					}
					Detail.Rows.Add(drNew);
				}

				#region Another Method

				/*
				System.Data.DataTable dt =hwcx_Detail.ToADODataTable();
			 
				for(int i=0;i< dt.Rows.Count;i++)
				{
					System.Data.DataRow dr1 =Detail.NewRow();
					dr1["Bct50"]=dt.Rows[i]["BCT50"].ToString();
					dr1["BCT51"]=dt.Rows[i]["BCT51"].ToString();

					dr1["BCT60"]=dt.Rows[i]["BCT60"].ToString();
					dr1["BCT61"]=dt.Rows[i]["BCT61"].ToString();

					dr1["BCT70"]=dt.Rows[i]["BCT70"].ToString();
					dr1["BCT71"]=dt.Rows[i]["BCT71"].ToString();

					dr1["BCT10"]=dt.Rows[i]["BCT10"].ToString();
					dr1["Matnr"]=dt.Rows[i]["Matnr"].ToString();

					dr1["Charg"]=dt.Rows[i]["Charg"].ToString();
					dr1["Werks"]=dt.Rows[i]["Werks"].ToString();

					dr1["Maktx"]=dt.Rows[i]["Maktx"].ToString();
					dr1["Meins"]=dt.Rows[i]["Meins"].ToString();
					dr1["Clabs"]=dt.Rows[i]["Clabs"].ToString();

					Detail.Rows.Add(dr1);
				}
				*/
				#endregion

				#endregion 
				if(Detail.Rows.Count <=0)
				{
					ErrMsg ="该货位上没有该保管员的货品";
					return -1;
				}
				Detail.TableName ="Detail";
				cxDs.Tables.Add(Detail);

			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
			#endregion

			return 0;
		}


		/// <summary>
		/// 得到批次查询信息
		/// </summary>
		/// <param name="User"></param>
		/// <param name="Werks"></param>
		/// <param name="Charg"></param>
		/// <param name="Matnr"></param>
		/// <param name="pccxDs"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int GetHWPCCXInfo(string User,string BaoGuanYuan,string Werks/*工厂*/,string Charg/*批次*/,string  Matnr/*物料*/,out System.Data.DataSet pccxDs,out string ErrMsg)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			pccxDs = new DataSet();

			TDB db = new TDB(Global.g_ConStr);
			System.Data.DataTable dt1 =null;
			if(0!=db.OpenDataSet("select * from RF_Users where User_ID ='"+User+"'",out dt1))
			{
				ErrMsg ="获取用户权限出现错误";
				return -1;
			}
			if(dt1.Rows.Count <=0)
			{
				ErrMsg ="获取用户权限出现错误";
				return -1;
			}
			if(dt1.Rows[0]["IsAdmin"].ToString().Trim()!="True" &&User !=BaoGuanYuan)
			{
				ErrMsg ="你不是管理员，无权查询别的保管员保管的物品";
				return -1;
			}
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);
			SapService.ZSMM_RFC_HWPCCXTable hwpccx_Detail=new ZSMM_RFC_HWPCCXTable();
			//SapService.ZSMM_RFC_HWCX hwcx =new ZSMM_RFC_HWCX();
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			string Returncode =""; //返回值
			//string Eblen ="";

			#region 构建查询详细表
			System.Data.DataTable Detail = new DataTable();

			Detail.Columns.Add(new DataColumn("Werks"));  //工厂
			Detail.Columns.Add(new DataColumn("Matnr"));  //物料号
			Detail.Columns.Add(new DataColumn("Charg"));  //批号
			Detail.Columns.Add(new DataColumn("Lgort"));  //库存地点
			Detail.Columns.Add(new DataColumn("Clabs"));  //总库存量
			Detail.Columns.Add(new DataColumn("Maktx"));  //物料描述
			Detail.Columns.Add(new DataColumn("Meins"));  //基本计量单位
			Detail.Columns.Add(new DataColumn("Verpr"));  //移动平均价格/周期单价

			Detail.Columns.Add(new DataColumn("Bct50"));   
			Detail.Columns.Add(new DataColumn("Bct51"));

			Detail.Columns.Add(new DataColumn("Bct60"));   
			Detail.Columns.Add(new DataColumn("Bct61"));

			Detail.Columns.Add(new DataColumn("Bct70"));   
			Detail.Columns.Add(new DataColumn("Bct71"));

			Detail.Columns.Add(new DataColumn("Bct10"));  //保管员代码
			Detail.Columns.Add(new DataColumn("Bct20")); //生产厂代码

			Detail.Columns.Add(new DataColumn("Ebeln"));//采购订单号
			Detail.Columns.Add(new DataColumn("Name1"));//供应商
			Detail.Columns.Add(new DataColumn("Ntgew"));//净重
			Detail.Columns.Add(new DataColumn("Menge"));//数量
			

			#endregion

			#region Start Operator
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				
				oper.Functions.Zmm_Rfc_Hwpccx_Dwnload(Charg,Matnr,Werks,out Returncode,ref hwpccx_Detail,ref Return0);
				
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
				
				#region GetData From SAP Table
				
				SapService.ZSMM_RFC_HWPCCX[] hwpccx_All =new ZSMM_RFC_HWPCCX[hwpccx_Detail.Count];
				hwpccx_Detail.CopyTo(hwpccx_All,0);

				foreach(SapService.ZSMM_RFC_HWPCCX hwpccx in hwpccx_All)
				{
					System.Data.DataRow drNew =Detail.NewRow();
					drNew["Werks"]=hwpccx.Werks;
					drNew["Matnr"]=hwpccx.Matnr;
					drNew["Charg"]=hwpccx.Charg;
					drNew["Lgort"]=hwpccx.Lgort;
					drNew["Clabs"]=hwpccx.Clabs;
					drNew["Maktx"]=hwpccx.Maktx;
					drNew["Meins"]=hwpccx.Meins;
					drNew["Verpr"]=hwpccx.Verpr;

					drNew["Bct50"]=hwpccx.Bct50;
					drNew["Bct51"]=hwpccx.Bct51;
					drNew["Bct60"]=hwpccx.Bct60;
					drNew["Bct61"]=hwpccx.Bct61;
					drNew["Bct70"]=hwpccx.Bct70;
					drNew["Bct71"]=hwpccx.Bct71;

					drNew["Bct10"]=hwpccx.Bct10;
					drNew["Bct20"]=hwpccx.Bct20;

					drNew["Ebeln"]=hwpccx.Ebeln;//
					drNew["Name1"]=hwpccx.Name1;//
					drNew["Ntgew"]=hwpccx.Ntgew;//
					drNew["Menge"]=hwpccx.Clabs;//


					if(dt1.Rows[0]["IsAdmin"].ToString().Trim()!="True")
					{
						if(hwpccx.Bct10.Trim()!=User)
						{
							continue;
						}
					}
					Detail.Rows.Add(drNew);
				}


				#endregion 
				if(Detail.Rows.Count<=0)
				{
					ErrMsg ="该物料批次不属于该保管员管理";
					return -1;
				}
				Detail.TableName ="Detail";
				pccxDs.Tables.Add(Detail);

			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
			#endregion

			return 0;
		}

		/// <summary>
		/// 获取物料凭证信息
		/// </summary>
		/// <param name="User"></param>
		/// <param name="Audate"></param>
		/// <param name="DocumentID"></param>
		/// <param name="Ds"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int GetWLPZInfo(string User,string BaoGuanyuan,string Audate,string DocumentID,out System.Data.DataSet Ds,out string ErrMsg)
		{
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			Ds = new DataSet();
			
			TDB db = new TDB(Global.g_ConStr);
			System.Data.DataTable dt1 =null;
			if(0!=db.OpenDataSet("select * from RF_Users where User_ID ='"+User+"'",out dt1))
			{
				ErrMsg ="获取用户权限出现错误";
				return -1;
			}
			if(dt1.Rows.Count <=0)
			{
				ErrMsg ="获取用户权限出现错误";
				return -1;
			}
			if(dt1.Rows[0]["IsAdmin"].ToString().Trim()!="True" &&User !=BaoGuanyuan)
			{
				ErrMsg ="你不是管理员，无权查询别的保管员保管的物料凭证";
				return -1;
			}
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);
			ZSMM_RFC_WLPZTable P_Getail = new ZSMM_RFC_WLPZTable();
			ZSMM_RFC_WLPZ P_GetailItem = new ZSMM_RFC_WLPZ();
		    

			

			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			string Returncode =""; //返回值
			//			string Eblen ="";
			//
			//			#region 构建查询详细表
			System.Data.DataTable Detail = new DataTable();
			Detail.Columns.Add(new DataColumn("Bct10")); 
			Detail.Columns.Add(new DataColumn("Bct20")); 
			Detail.Columns.Add(new DataColumn("Bct50")); 
			Detail.Columns.Add(new DataColumn("Bct51")); 
			Detail.Columns.Add(new DataColumn("Bct60")); 
			Detail.Columns.Add(new DataColumn("Bct61")); 
			Detail.Columns.Add(new DataColumn("Bct70")); 
			Detail.Columns.Add(new DataColumn("Bct71")); 
			Detail.Columns.Add(new DataColumn("Budat")); 
			Detail.Columns.Add(new DataColumn("Charg")); 
			Detail.Columns.Add(new DataColumn("Dmbtr")); 
			Detail.Columns.Add(new DataColumn("Lgort")); 
			Detail.Columns.Add(new DataColumn("Maktx")); 
			Detail.Columns.Add(new DataColumn("Matnr")); 
			Detail.Columns.Add(new DataColumn("Meins")); 
			Detail.Columns.Add(new DataColumn("Menge"));   
			Detail.Columns.Add(new DataColumn("Name1"));
			Detail.Columns.Add(new DataColumn("Ntgew"));   
			Detail.Columns.Add(new DataColumn("Sgtxt")); 
			Detail.Columns.Add(new DataColumn("Werks"));
			Detail.Columns.Add(new DataColumn("Zeile"));   
			Detail.Columns.Add(new DataColumn("Ebeln"));   //
			Detail.Columns.Add(new DataColumn("Xauto"));  //2008-08-01  myl
			
			
			//
			//			#endregion

			#region Start Operator
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				
				oper.Functions.Zmm_Rfc_Wlpz_Download(DocumentID,Audate,out Returncode,ref  P_Getail,ref Return0);
				
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}			
				System.Data.DataTable dt =P_Getail.ToADODataTable();
				for(int i=0;i< dt.Rows.Count;i++)
				{
					System.Data.DataRow dr =Detail.NewRow();

					if(dt.Rows[i]["Bct10"].ToString().Trim()!=BaoGuanyuan && dt1.Rows[0]["IsAdmin"].ToString().Trim()!="True")
					{
						ErrMsg="该物料凭证不是该保管员产生，不能查看";
						return -1;
					}
					dr["Bct10"]=dt.Rows[i]["Bct10"].ToString().Trim();
					dr["Bct20"]=dt.Rows[i]["Bct20"].ToString().Trim();
					dr["Bct50"]=dt.Rows[i]["Bct50"].ToString().Trim();
					dr["Bct51"]=dt.Rows[i]["Bct51"].ToString().Trim();
					dr["Bct60"]=dt.Rows[i]["Bct60"].ToString().Trim();
					dr["Bct61"]=dt.Rows[i]["Bct61"].ToString().Trim();
					dr["Bct70"]=dt.Rows[i]["Bct70"].ToString().Trim();
					dr["Bct71"]=dt.Rows[i]["Bct71"].ToString().Trim();
					dr["Budat"]=dt.Rows[i]["Budat"].ToString().Trim();
					dr["Charg"]=dt.Rows[i]["Charg"].ToString().Trim();
					dr["Dmbtr"]=dt.Rows[i]["Dmbtr"].ToString().Trim();
					dr["Lgort"]=dt.Rows[i]["Lgort"].ToString().Trim();
					dr["Maktx"]=dt.Rows[i]["Maktx"].ToString().Trim();
					dr["Matnr"]=dt.Rows[i]["Matnr"].ToString().Trim();
					dr["Meins"]=dt.Rows[i]["Meins"].ToString().Trim();
					dr["Menge"]=dt.Rows[i]["Menge"].ToString().Trim();
					dr["Name1"]=dt.Rows[i]["Name1"].ToString().Trim();
					dr["Ntgew"]=dt.Rows[i]["Ntgew"].ToString().Trim();
					dr["Sgtxt"]=dt.Rows[i]["Sgtxt"].ToString().Trim();
					dr["Werks"]=dt.Rows[i]["Werks"].ToString().Trim();
					dr["Zeile"]=dt.Rows[i]["Zeile"].ToString().Trim();
					dr["Ebeln"]=dt.Rows[i]["Ebeln"].ToString().Trim();//
					dr["Xauto"]=dt.Rows[i]["Xauto"].ToString().Trim();//2008-08-01  myl


//					if(Convert.ToDecimal(dr["Menge"])<=0)
//					{
//						ErrMsg="该物料的库存小于等于零，不能做报废出库功能";
//						return -1;
//					}

					Detail.Rows.Add(dr);
					
				}
				Ds.Tables.Add(Detail);
				return 0;

			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
			#endregion

		
		}


		public int GetBGYInfo(string User,string BGY,out System.Data.DataSet Ds,out string ErrMsg)
		{

			Ds = new DataSet();
			ErrMsg ="";
			OutPass pass = new OutPass();
			string SapUser,SapPass;
			Ds = new DataSet();


			TDB db = new TDB(Global.g_ConStr);
			System.Data.DataTable dt1 =null;
			if(0!=db.OpenDataSet("select * from RF_Users where User_ID ='"+User+"'",out dt1))
			{
				ErrMsg ="获取用户权限出现错误";
				return -1;
			}
			if(dt1.Rows.Count <=0)
			{
				ErrMsg ="获取用户权限出现错误";
				return -1;
			}
			if(dt1.Rows[0]["IsAdmin"].ToString().Trim()!="True" &&User !=BGY)
			{
				ErrMsg ="你不是管理员，无权查询别的保管员保管的物品";
				return -1;
			}
			
			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}

			SapService.ZSMM_RFC_BGYTable P_Getail = new ZSMM_RFC_BGYTable();
			ZSMM_RFC_BGY P_GetailItem = new ZSMM_RFC_BGY();
			
			SapOperator oper = new SapOperator(SapUser,SapPass);
			string Returncode =""; //返回值
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			System.Data.DataTable Detail = new DataTable();

			//			Detail.Columns.Add(new DataColumn("Bct20")); 
			//			Detail.Columns.Add(new DataColumn("Budat")); 
			//			Detail.Columns.Add(new DataColumn("Charg")); 
			//			Detail.Columns.Add(new DataColumn("Dmbtr")); 
			//			Detail.Columns.Add(new DataColumn("Lgort")); 
			//			Detail.Columns.Add(new DataColumn("Maktx")); 
			//			Detail.Columns.Add(new DataColumn("Matnr")); 
			//			Detail.Columns.Add(new DataColumn("Meins")); 
			//			Detail.Columns.Add(new DataColumn("Menge"));   
			//			Detail.Columns.Add(new DataColumn("Name1"));
			//			Detail.Columns.Add(new DataColumn("Ntgew"));   
			//			Detail.Columns.Add(new DataColumn("Sgtxt")); 
			//			Detail.Columns.Add(new DataColumn("Werks"));
			//			Detail.Columns.Add(new DataColumn("Zeile"));   
			//			P_GetailItem.Bct10 ="";
			//			P_GetailItem.Bct20 ="";
			//			P_GetailItem.Bct50="";
			//			P_GetailItem.Bct51="";
			//			P_GetailItem.Bct60="";
			//			P_GetailItem.Bct61="";
			//			P_GetailItem.Bct70="";
			//			P_GetailItem.Bct71="";
			//			P_GetailItem.Charg ="";
			//			P_GetailItem.Lgort="";
			//			P_GetailItem.Maktx="";
			//			P_GetailItem.Matnr="";
			//			P_GetailItem.Meins="";
			//			P_GetailItem.Werks="";

			Detail.Columns.Add(new DataColumn("Bct10")); 
			Detail.Columns.Add(new DataColumn("Bct20")); 
			Detail.Columns.Add(new DataColumn("Maktx"));   
			Detail.Columns.Add(new DataColumn("Matnr")); 
			Detail.Columns.Add(new DataColumn("Bct50")); 
			Detail.Columns.Add(new DataColumn("Bct51")); 
			Detail.Columns.Add(new DataColumn("Bct60")); 
			Detail.Columns.Add(new DataColumn("Bct61")); 
			Detail.Columns.Add(new DataColumn("Bct70")); 
			Detail.Columns.Add(new DataColumn("Bct71")); 
			Detail.Columns.Add(new DataColumn("Charg"));   
			Detail.Columns.Add(new DataColumn("Lgort"));
			Detail.Columns.Add(new DataColumn("Meins"));
			Detail.Columns.Add(new DataColumn("Werks"));  
			Detail.Columns.Add(new DataColumn("Ebeln"));  
			Detail.Columns.Add(new DataColumn("Verpr"));//单价
			Detail.Columns.Add(new DataColumn("Name1"));//供应商
			Detail.Columns.Add(new DataColumn("Ntgew"));//净重
			Detail.Columns.Add(new DataColumn("Clabs"));//库存数

				
			


			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				
				oper.Functions.Zmm_Rfc_Bgy_Download(BGY,out Returncode,ref  P_Getail,ref Return0);
				
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}
				
			

				System.Data.DataTable dt =P_Getail.ToADODataTable();
				for(int i=0;i< dt.Rows.Count;i++)
				{
					System.Data.DataRow dr =Detail.NewRow();
					dr["Bct10"]=dt.Rows[i]["Bct10"].ToString().Trim();
					dr["Bct20"]=dt.Rows[i]["Bct20"].ToString().Trim();
					dr["Bct50"]=dt.Rows[i]["Bct50"].ToString().Trim();
					dr["Bct51"]=dt.Rows[i]["Bct51"].ToString().Trim();
					dr["Bct60"]=dt.Rows[i]["Bct60"].ToString().Trim();
					dr["Bct61"]=dt.Rows[i]["Bct61"].ToString().Trim();
					dr["Bct70"]=dt.Rows[i]["Bct70"].ToString().Trim();
					dr["Bct71"]=dt.Rows[i]["Bct71"].ToString().Trim();
					dr["Charg"]=dt.Rows[i]["Charg"].ToString().Trim();
					dr["Lgort"]=dt.Rows[i]["Lgort"].ToString().Trim();
					dr["Maktx"]=dt.Rows[i]["Maktx"].ToString().Trim();
					dr["Matnr"]=dt.Rows[i]["Matnr"].ToString().Trim();
					dr["Meins"]=dt.Rows[i]["Meins"].ToString().Trim();
					dr["Werks"]=dt.Rows[i]["Werks"].ToString().Trim();
					dr["Ebeln"]=dt.Rows[i]["Ebeln"].ToString().Trim();

					dr["Verpr"]=dt.Rows[i]["Verpr"].ToString().Trim();
					dr["Name1"]=dt.Rows[i]["Name1"].ToString().Trim();
					dr["Ntgew"]=dt.Rows[i]["Ntgew"].ToString().Trim();
					dr["Clabs"]=dt.Rows[i]["Clabs"].ToString().Trim();


					Detail.Rows.Add(dr);
					
				}
				Ds.Tables.Add(Detail);
				Detail.TableName ="Detail";
				return 0;

			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}

			//return 0;


		}
		#endregion
		
		#region 保养模块

		public int GetMaintainNum(string storeMan,out System.Data.DataSet dsMaintainList,out string ErrMsg)
		{
			ErrMsg ="";
			dsMaintainList = new DataSet();
			TDB db = new TDB(Global.g_ConStr);
			string sqlStr = string.Empty;
			sqlStr = "select MAINTAIN_NO as 保养单号 from RF_Maintain where STOREMAN='"+storeMan+"' and State='1'";
			if(0!=db.OpenDataSet(sqlStr,out dsMaintainList))
			{
				ErrMsg ="获取保养单信息失败";
				return -1;
			}
			if(dsMaintainList.Tables[0].Rows.Count<=0)
			{
				ErrMsg="你暂时没有保养单";
				return -1;
			}
			return 0;
		}

		public int GetGoodsInfo(string maintainNo,out System.Data.DataSet dsGoodsList,out string ErrMsg)
		{
			ErrMsg ="";
			dsGoodsList = new DataSet();
			TDB db = new TDB(Global.g_ConStr);
			System.Text.StringBuilder selectSQL = new System.Text.StringBuilder();
			selectSQL.Append("SELECT FACTORY_NO as 公司, PRODUCT_NO as 物料, PATCH_NO as 批次, PRODUCT_NAME as 物品名, UNIT as 单位,BIN as 货位, PLAN_NUM as 保养单数量, MAINTAINNUM as 保养数量, SUPPLIER_NO as 二级厂, OPERATOR as 制单人, OPERATE_TIME as 制单日期, BARCODE as 条码号 FROM RF_VIEW_Maintain where MAINTAIN_NO='"+maintainNo+"'");
			
			if(0!=db.OpenDataSet(selectSQL.ToString(),out dsGoodsList))
			{
				ErrMsg ="获取货物信息失败";
				return -1;
			}
			if(dsGoodsList.Tables[0].Rows.Count<=0)
			{
				ErrMsg="你暂时没有保养货物";
				return -1;
			}
			return 0;
		}
		

		public int UpdateMaintainNum(string maintainNum,string maintainNo,string barCode,string bin,out string ErrMsg)
		{
			ErrMsg ="";
			TDB db = new TDB(Global.g_ConStr);
			int execCount = 0;
			string sql = "declare @changeNum decimal(12,3) set @changeNum="+maintainNum+" update RF_Maintain_Detail set MAINTAINNUM=MAINTAINNUM+@changeNum where MAINTAIN_NO='"+maintainNo+"' and BARCODE='"+barCode+"' and BIN='"+bin+"' and PLAN_NUM>=MAINTAINNUM+@changeNum";
			execCount=db.ExecSQL(sql);
			if(execCount!=0)
			{
				ErrMsg ="保养成功";
				return 0;
			}
			else
			{
				ErrMsg ="保养失败";
				return -1;
			}
		}
		

		public int MaintainModEnd(string maintainNum,out string ErrMsg)
		{
			ErrMsg ="";
			TDB db = new TDB(Global.g_ConStr);
			int execCount = 0;
			execCount=db.ExecSQL("update RF_Maintain set State='2' where State='1' and MAINTAIN_NO='"+maintainNum+"'");
			if(execCount!=0)
			{
				ErrMsg ="保养成功";
				return 1;
			}
			else
			{
				ErrMsg ="保养失败";
				return 0;
			}
		}

		public bool MaintainCompleteCheck(string maintainNum,out string ErrMsg)
		{
			ErrMsg ="";
			TDB db = new TDB(Global.g_ConStr);
			int execCount = 0;
			DataTable dtUnComplete = new DataTable();

			string Parm = TDBObject.ToDBVal(maintainNum);
			try
			{
				execCount=db.OpenProcedure("RF_Maintain_CompleteCheck",Parm,out dtUnComplete);
			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return false;
			}

			if(execCount==-1)
			{
				ErrMsg = "没有检索到相关数据";
				return false;
			}
			else if(dtUnComplete.Rows.Count==0)
			{
				ErrMsg ="可以完成";
				return true;
			}
			else
			{
				ErrMsg ="此单据中还有未保养完成的货物，请完成保养后在结束本次保养";
				return false;
			}
		}

		#endregion

		#region 插入历史数据到RF后台
        /// <summary>
        /// 插入历史数据到RF后台
        /// </summary>
        /// <param name="arrColumnCollection">表列集合</param>
        /// <param name="arrParaCollection">Command参数集合</param>
        /// <param name="dataToInsert">数据DataTable</param>
        /// <param name="tableName">表名</param>
        /// <param name="ErrMsg">错误信息</param>
        /// <returns></returns>
        public int InsertInfoToRFdb(ArrayList arrColumnCollection, ArrayList arrParaCollection, DataTable dataToInsert, string tableName, out string ErrMsg)
        {
            ErrMsg = "";
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(Global.g_ConStr);
            System.Data.OleDb.OleDbTransaction tran = null;
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                tran = conn.BeginTransaction();

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();

                cmd.Connection = conn;

                // cmd.CommandText = "insert into t_take_delivery(order_no,storeman,pzh,pznd,bill_type,product_no,product_desc,qty,gch,sl,remark) values('@order_no','@storeman','@pzh','@pznd','@bill_type','@product_no','@product_desc','@qty','@gch','@sl','@remark')";
                //cmd.CommandText = "insert into t_take_delivery(order_no,storeman,pzh,pznd,bill_type,product_no,product_desc,qty,gch,sl,remark) values(@order_no,@storeman,@pzh,@pznd,@bill_type,@product_no,@product_desc,@qty,@gch,@sl,@remark)";
                cmd.Transaction = tran;
                string commandText = "", separator = "";
                commandText += "insert into " + tableName + "( ";
                foreach (object ob in arrColumnCollection)
                {
                    commandText += (string)ob + ",";
                    separator += "?,";
                }
                separator = separator.Trim().TrimEnd(new char[] { ',' }); commandText = commandText.Trim().TrimEnd(new char[] { ',' });
                commandText += ") VALUES(" + separator + ")";
                cmd.CommandText = commandText;

                //cmd.CommandText = "insert into t_take_delivery(order_no,storeman,pzh,pznd,bill_type,product_no,product_desc,qty,gch,sl,remark) values(?,?,?,?,?,?,?,?,?,?,?)";
                // DB.OleDbDataAdapter adp = new System.Data.OleDb.OleDbDataAdapter();//'@operator_date'
                System.Data.OleDb.OleDbDataAdapter adp = new System.Data.OleDb.OleDbDataAdapter();
                adp.InsertCommand = cmd;


                foreach (object ob in arrParaCollection)
                {
                    if (ob is System.Data.OleDb.OleDbParameter)
                    {
                        cmd.Parameters.Add(ob);
                    }
                }
//
//				cmd.Parameters.Add("@order_no", OleDbType.VarChar, 20, "order_no");
//				cmd.Parameters.Add("@storeman", OleDbType.VarChar, 20, "storeman");
//				cmd.Parameters.Add("@pzh", OleDbType.VarChar, 20, "pzh");
//				cmd.Parameters.Add("@pznd", OleDbType.VarChar, 4, "pznd");
//				cmd.Parameters.Add("@bill_type", OleDbType.VarChar, 20, "bill_type");
//				cmd.Parameters.Add("@product_no", OleDbType.VarChar, 18, "product_no");
//				cmd.Parameters.Add("@product_desc", OleDbType.VarChar, 80, "product_desc");
//				cmd.Parameters.Add("@qty", OleDbType.Decimal, 8, "qty");
//				cmd.Parameters.Add("@gch", OleDbType.VarChar, 4, "gch");
//				cmd.Parameters.Add("@sl", OleDbType.VarChar, 10, "sl");
//				cmd.Parameters.Add("@remark", OleDbType.VarChar, 40, "remark");


                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    cmd.CommandText = "insert into t_take_delivery(order_no,storeman,pzh,pznd,bill_type,product_no,product_desc,qty,gch,sl,remark) values ('@order_no',@storeman,@pzh,@pznd,@bill_type,@product_no,@product_desc,@qty,@gch,@sl,@remark)";
                //    //cmd.CommandText = "insert into t_take_delivery(order_no,storeman,pzh,pznd,bill_type,product_no,product_desc,qty,gch,sl,remark) values('@order_no','@storeman','@pzh','@pznd','@bill_type','@product_no','@product_desc','@qty','@gch','@sl','@remark')";
                //    cmd.ExecuteNonQuery();
                //}


                adp.Update(dataToInsert);
                //cmd.ExecuteNonQuery();

                tran.Commit();
                //MessageBox.Show("OKOKOK");
                return 0;
            }
            catch (System.Data.SqlClient.SqlException exc)
            {
                ErrMsg = exc.Message;
                if (tran != null)
                {
                    tran.Rollback(); tran = null;
                }
                return -1;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                }
                return -1;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        public void InsertInfoToRFdb(System.Data.OleDb.OleDbCommand cmd, ArrayList arrColumnCollection, ArrayList arrParaCollection, DataTable dataToInsert, string tableName)
        {
            string commandText = "", separator = "";
            commandText += "insert into " + tableName + "( ";
            foreach (object ob in arrColumnCollection)
            {
                commandText += (string)ob + ",";
                separator += "?,";
            }
            separator = separator.Trim().TrimEnd(new char[] { ',' }); commandText = commandText.Trim().TrimEnd(new char[] { ',' });
            commandText += ") VALUES(" + separator + ")";
            cmd.CommandText = commandText;

            System.Data.OleDb.OleDbDataAdapter adp = new System.Data.OleDb.OleDbDataAdapter();
            adp.InsertCommand = cmd;

            foreach (object ob in arrParaCollection)
            {
                if (ob is System.Data.OleDb.OleDbParameter)
                {
                    cmd.Parameters.Add(ob);
                }
            }

            adp.Update(dataToInsert);

        }

		/// <summary>
		/// 采购收货保存
		/// </summary>
		/// <param name="arrColumnCollection">表列集合</param>
		/// <param name="arrParaCollection">Command参数集合</param>
		/// <param name="dataToInsert">数据DataTable</param>
		/// <param name="tableName">表名</param>
		/// <param name="ErrMsg">错误信息</param>
        /// <param name="ywtm">一维条码</param>
		/// <returns></returns>
        public int InsertInfoToRFdb_caiggoush(ref string ywtm, enumOpType optype, ArrayList arrColumnCollection, ArrayList arrParaCollection, DataTable dataToInsert, string tableName, out string ErrMsg)
        {
            //ywtm可能是空字符也可能是 有数值的
            //ywtm = "";
            ErrMsg = "";
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(Global.g_ConStr);
            System.Data.OleDb.OleDbTransaction tran = null;
            try
            {
                conn.Open();
                tran = conn.BeginTransaction();

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.Connection = conn;
                cmd.Transaction = tran;

                InsertInfoToRFdb(cmd, arrColumnCollection, arrParaCollection, dataToInsert, tableName);
                tran.Commit();
                
                //保存一维条码信息表   dataToInsert是一条记录？？？
                for (int i = 0; i < dataToInsert.Rows.Count; i++)
                {
                    
                    clsKCGL cls = new clsKCGL();
                    /*
                    #region 判断条码是否已存在
                    if (ywtm.Trim() != "")
                    {
                        DataSet ds = new DataSet();
                        cls.queryYwtm(ywtm, optype, out ErrMsg, out ds);
                        if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                        {
                            ErrMsg = "此条码已存在，不能保存。";
                            return -1;
                        }
                    }
                    #endregion
                    */

                    string pzh = dataToInsert.Rows[i]["pzh"].ToString();
                    string pznd = dataToInsert.Rows[i]["pznd"].ToString();
                    string xtdm = StringConst.xtdm;// ywtm.Substring(0, 1);
                    string gch = dataToInsert.Rows[i]["gch"].ToString();// ywtm.Substring(1, 4);
                    string order_no = dataToInsert.Rows[i]["order_no"].ToString();// ywtm.Substring(5, 10);
                    string product_no = dataToInsert.Rows[i]["product_no"].ToString();// ywtm.Substring(15, 14);
                    string storeman = dataToInsert.Rows[i]["storeman"].ToString();
                    string h_no = dataToInsert.Rows[i]["item_no"].ToString();
                    h_no = ("0000").Substring(0, 4 -h_no.Length) + h_no;

                    //保存一维条码总表
                    cls.createYwtm(cmd, ref ywtm, xtdm, gch, order_no, product_no, storeman, h_no);

                    //保存一维条码与采购收货对照关系表
                    string jhcsxh = ywtm.Substring(33, 3);
                    cmd.CommandText = "insert into t_take_delivery_ywtm(pzh,pznd,xtdm,gch,order_no,h_no, product_no,jhcsxh,operator_date,storeman)"
                    + " values('" + pzh + "','" + pznd + "','" + xtdm + "','" + gch + "','" + order_no + "', '" + h_no + "', '" + product_no + "','" + jhcsxh + "',getdate(),'" + storeman + "')";
                    cmd.ExecuteNonQuery();
                }
                
                
                return 0;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                tran.Rollback();
                return -1;
            }
            finally
            {
                tran.Dispose();
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                conn.Dispose();
            }
        }

        /// <summary>
        /// 验收入库提交
        /// </summary>
        /// <param name="arrColumnCollection"></param>
        /// <param name="arrParaCollection"></param>
        /// <param name="dataToInsert"></param>
        /// <param name="tableName"></param>
        /// <param name="ErrMsg"></param>
        /// <param name="ywtm"></param>
        /// <returns></returns>
        public int InsertInfoToRFdb_yanshourk(ArrayList arrColumnCollection, ArrayList arrParaCollection, DataTable dataToInsert, string tableName, out string ErrMsg, string ywtm)
        {
            ErrMsg = "";
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(Global.g_ConStr);
            System.Data.OleDb.OleDbTransaction tran = null;
            try
            {
                conn.Open();
                tran = conn.BeginTransaction();

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.Connection = conn;
                cmd.Transaction = tran;

                InsertInfoToRFdb(cmd, arrColumnCollection, arrParaCollection, dataToInsert, tableName);


                for (int i = 0; i < dataToInsert.Rows.Count; i++)
                {
                    string pzh = dataToInsert.Rows[i]["pzh"].ToString();
                    string pznd = dataToInsert.Rows[i]["pznd"].ToString();
                    string product_barcode = dataToInsert.Rows[i]["product_barcode"].ToString();
                    string storeman = dataToInsert.Rows[i]["storeman"].ToString();
                    cmd.CommandText = "insert into t_stockin_ywtm(ywtm,pzh,pznd,product_barcode,operator_date,storeman)"
                    + " values('" + ywtm + "','" + pzh + "','" + pznd + "','" + product_barcode + "',getdate(),'" + storeman + "')";
                    cmd.ExecuteNonQuery();

                }





                tran.Commit();
                //MessageBox.Show("OKOKOK");
                return 0;
            }
            catch (System.Data.SqlClient.SqlException exc)
            {
                ErrMsg = exc.Message;
                if (tran != null)
                {
                    tran.Rollback(); tran = null;
                }
                return -1;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                }
                return -1;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 上架提交
        /// </summary>
        /// <param name="arrColumnCollection"></param>
        /// <param name="arrParaCollection"></param>
        /// <param name="dataToInsert"></param>
        /// <param name="tableName"></param>
        /// <param name="ErrMsg"></param>
        /// <param name="ywtm"></param>
        /// <returns></returns>
        public int InsertInfoToRFdb_shangjia(ArrayList arrColumnCollection, ArrayList arrParaCollection, DataTable dataToInsert, string tableName, out string ErrMsg, string ywtm)
        {
            ErrMsg = "";
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(Global.g_ConStr);
            System.Data.OleDb.OleDbTransaction tran = null;
            try
            {
                conn.Open();
                tran = conn.BeginTransaction();

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.Connection = conn;
                cmd.Transaction = tran;

                InsertInfoToRFdb(cmd, arrColumnCollection, arrParaCollection, dataToInsert, tableName);


                for (int i = 0; i < dataToInsert.Rows.Count; i++)
                {
                    string product_barcode = dataToInsert.Rows[i]["product_barcode"].ToString();
                    string storeman = dataToInsert.Rows[i]["storeman"].ToString();
                    cmd.CommandText = "insert into t_stock_op_ywtm(ywtm,product_barcode,operator_date,storeman)"
                    + " values('" + ywtm + "','" + product_barcode + "',getdate(),'" + storeman + "')";
                    cmd.ExecuteNonQuery();
                }



                tran.Commit();
                //MessageBox.Show("OKOKOK");
                return 0;
            }
            catch (System.Data.SqlClient.SqlException exc)
            {
                ErrMsg = exc.Message;
                if (tran != null)
                {
                    tran.Rollback(); tran = null;
                }
                return -1;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                }
                return -1;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 生产领料提交
        /// </summary>
        /// <param name="arrColumnCollection"></param>
        /// <param name="arrParaCollection"></param>
        /// <param name="dataToInsert"></param>
        /// <param name="tableName"></param>
        /// <param name="ErrMsg"></param>
        /// <param name="ywtm"></param>
        /// <returns></returns>
        public int InsertInfoToRFdb_shengchanll(ArrayList arrColumnCollection, ArrayList arrParaCollection, DataTable dataToInsert, string tableName, out string ErrMsg, string ywtm)
        {
            ErrMsg = "";
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(Global.g_ConStr);
            System.Data.OleDb.OleDbTransaction tran = null;
            try
            {
                conn.Open();
                tran = conn.BeginTransaction();

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.Connection = conn;
                cmd.Transaction = tran;

                InsertInfoToRFdb(cmd, arrColumnCollection, arrParaCollection, dataToInsert, tableName);


                for (int i = 0; i < dataToInsert.Rows.Count; i++)
                {
                    string product_barcode = dataToInsert.Rows[i]["product_barcode"].ToString();
                    string storeman = dataToInsert.Rows[i]["storeman"].ToString();
                    cmd.CommandText = "insert into t_stockout_ywtm(ywtm,product_barcode,operator_date,storeman)"
                    + " values('" + ywtm + "','" + product_barcode + "',getdate(),'" + storeman + "')";
                    cmd.ExecuteNonQuery();
                }



                tran.Commit();
                //MessageBox.Show("OKOKOK");
                return 0;
            }
            catch (System.Data.SqlClient.SqlException exc)
            {
                ErrMsg = exc.Message;
                if (tran != null)
                {
                    tran.Rollback(); tran = null;
                }
                return -1;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                }
                return -1;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 移至报废库提交
        /// </summary>
        /// <param name="arrColumnCollection"></param>
        /// <param name="arrParaCollection"></param>
        /// <param name="dataToInsert"></param>
        /// <param name="tableName"></param>
        /// <param name="ErrMsg"></param>
        /// <param name="ywtm"></param>
        /// <returns></returns>
        public int InsertInfoToRFdb_yizhibfk(ArrayList arrColumnCollection, ArrayList arrParaCollection, DataTable dataToInsert, string tableName, out string ErrMsg, string ywtm)
        {
            ErrMsg = "";
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(Global.g_ConStr);
            System.Data.OleDb.OleDbTransaction tran = null;
            try
            {
                conn.Open();
                tran = conn.BeginTransaction();

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.Connection = conn;
                cmd.Transaction = tran;

                InsertInfoToRFdb(cmd, arrColumnCollection, arrParaCollection, dataToInsert, tableName);


                for (int i = 0; i < dataToInsert.Rows.Count; i++)
                {
                    string product_barcode = dataToInsert.Rows[i]["product_barcode"].ToString();
                    string storeman = dataToInsert.Rows[i]["storeman"].ToString();
                    cmd.CommandText = "insert into t_stock_bfk_ywtm(ywtm,product_barcode,operator_date,storeman)"
                    + " values('" + ywtm + "','" + product_barcode + "',getdate(),'" + storeman + "')";
                    cmd.ExecuteNonQuery();
                }



                tran.Commit();
                //MessageBox.Show("OKOKOK");
                return 0;
            }
            catch (System.Data.SqlClient.SqlException exc)
            {
                ErrMsg = exc.Message;
                if (tran != null)
                {
                    tran.Rollback(); tran = null;
                }
                return -1;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                }
                return -1;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }


		/// <summary>
		/// 将RF历史数据（验收入库...）插入后台时，根据生成的物料凭证获得相应的批次，以组成Table插入到后台数据库
		/// </summary>
		/// <param name="User"></param>
		/// <param name="BaoGuanyuan"></param>
		/// <param name="Audate">凭证年度</param>
		/// <param name="DocumentID">凭证号</param>
		/// <param name="order_no">订单号</param>
		/// <param name="Bill_Type">操作类型(验收入库，代保管入库，异议入库)</param>
		/// <param name="DtToRF"></param>
		/// <param name="ErrMsg"></param>
		/// <returns></returns>
		public int GetWLPZInfo(string User,string BaoGuanyuan,string Audate,string DocumentID,string order_no,string Bill_Type,out System.Data.DataTable DtToRF,out string ErrMsg)
		{
			DtToRF=new DataTable("ToRF");
			OutPass pass = new OutPass();
			string SapUser,SapPass;

			if(0!=pass.DbUserGetSapPass(User,out SapUser,out SapPass,out ErrMsg))
			{
				return -1;
			}
			SapOperator oper = new SapOperator(SapUser,SapPass);
			ZSMM_RFC_WLPZTable P_Getail = new ZSMM_RFC_WLPZTable();
			ZSMM_RFC_WLPZ P_GetailItem = new ZSMM_RFC_WLPZ();
		    
			SapService.BAPIRET2Table Return0 = new BAPIRET2Table();
			string Returncode =""; //返回值

			DtToRF.Columns.Add(new DataColumn("order_no"));		
			DtToRF.Columns.Add(new DataColumn("item_no",typeof(int)));	//序号 
			// dt.Columns.Add(new DataColumn("operator_date"));
			DtToRF.Columns.Add(new DataColumn("storeman"));										
			DtToRF.Columns.Add(new DataColumn("pzh"));												
			DtToRF.Columns.Add(new DataColumn("pznd"));											
			DtToRF.Columns.Add(new DataColumn("bill_type"));										
			DtToRF.Columns.Add(new DataColumn("product_barcode"));		//物料条码 
			DtToRF.Columns.Add(new DataColumn("product_desc"));									
			DtToRF.Columns.Add(new DataColumn("qty",typeof(decimal)));								
			DtToRF.Columns.Add(new DataColumn("gch"));												
			DtToRF.Columns.Add(new DataColumn("sl"));												
			DtToRF.Columns.Add(new DataColumn("bin1"));											
			DtToRF.Columns.Add(new DataColumn("bin1_qty",typeof(decimal)));							
			DtToRF.Columns.Add(new DataColumn("bin2"));												
			DtToRF.Columns.Add(new DataColumn("bin2_qty",typeof(decimal)));
			DtToRF.Columns.Add(new DataColumn("bin3"));						
			DtToRF.Columns.Add(new DataColumn("bin3_qty",typeof(decimal)));							
			DtToRF.Columns.Add(new DataColumn("remark"));											
			
			//
			//			#endregion

			#region Start Operator
			try
			{
				MessagePack pack =oper.Open();
				if(pack.Code !=0)
				{
					ErrMsg = pack.Message;
					return -1;
				}
				
				oper.Functions.Zmm_Rfc_Wlpz_Download(DocumentID,Audate,out Returncode,ref  P_Getail,ref Return0);
				
				oper.Close();
				if(Returncode.Trim()!="0")
				{
					
					if(Return0.Count <=0)
					{
						ErrMsg ="Sap中出现了错误，但是没有返回错误信息";
						return -1;
					}
					for(int i=0;i< Return0.Count;i++)
					{
						ErrMsg += Return0[i].Message+"\r\n";
					}
					return -1;
				}			
				System.Data.DataTable dt =P_Getail.ToADODataTable();
				for(int i=0;i< dt.Rows.Count;i++)
				{
					System.Data.DataRow dr =DtToRF.NewRow();

//					if(dt.Rows[i]["Bct10"].ToString().Trim()!=BaoGuanyuan && dt1.Rows[0]["IsAdmin"].ToString().Trim()!="True")
//					{
//						ErrMsg="该物料凭证不是该保管员产生，不能查看";
//						return -1;
//					}

					dr["order_no"]=order_no;
					dr["item_no"]=Convert.ToInt32(dt.Rows[i]["Zeile"].ToString().Trim());
					dr["bin1"]=dt.Rows[i]["Bct50"].ToString().Trim();
					dr["bin1_qty"]=Convert.ToDecimal(dt.Rows[i]["Bct51"].ToString().Trim()==""?"0":dt.Rows[i]["Bct51"].ToString().Trim());
					dr["bin2"]=dt.Rows[i]["Bct60"].ToString().Trim();
					dr["bin2_qty"]=Convert.ToDecimal(dt.Rows[i]["Bct61"].ToString().Trim()==""?"0":dt.Rows[i]["Bct61"].ToString().Trim());
					dr["bin3"]=dt.Rows[i]["Bct70"].ToString().Trim();
					dr["bin3_qty"]=Convert.ToDecimal(dt.Rows[i]["Bct71"].ToString().Trim()==""?"0":dt.Rows[i]["Bct71"].ToString().Trim());
					dr["storeman"]=dt.Rows[i]["bct10"].ToString().Trim();
					//dr["Charg"]=dt.Rows[i]["Charg"].ToString().Trim();
					dr["pznd"]=Audate;
					dr["pzh"]=DocumentID;
					dr["qty"]=Convert.ToDecimal(dt.Rows[i]["Menge"].ToString().Trim());
					dr["gch"]=dt.Rows[i]["Werks"].ToString().Trim();
					dr["bill_type"]=Bill_Type;
					dr["sl"]=dt.Rows[i]["Lgort"].ToString().Trim();
					dr["product_barcode"]=dt.Rows[i]["Werks"].ToString().Trim()+dt.Rows[i]["Charg"].ToString().Trim()+dt.Rows[i]["Matnr"].ToString().Trim();
					dr["product_desc"]=dt.Rows[i]["Maktx"].ToString().Trim();

					dr["remark"]="";

					DtToRF.Rows.Add(dr);

                    //LGORT 库存地点 | CHARG 批次编号 | INSMK 库存类型
                    //product_barcode:工厂号(Werks)+批次号(Charg)+物料编码(Matnr)

				}
				return 0;

			}
			catch(Exception ex)
			{
				ErrMsg = ex.Message;
				return -1;
			}
			finally
			{
				oper.Close();
			}
			#endregion
		}

		#endregion

	}
}
