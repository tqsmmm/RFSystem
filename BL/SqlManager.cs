namespace BL
{
    internal class SqlManager
    {
        public static readonly string ARRIVESTORE_MERGE_ADDSTORGE = "insert RF_ArriveStoreStorageInfo values (?,?,?,?)";
        public static readonly string ARRIVESTORE_SPLIT = "insert RF_ArriveStoreStorageInfo select top 1 ?,StorageID+1,?,?,? from RF_ArriveStoreStorageInfo where ArriveListID=? order by StorageID desc";
        public static readonly string ARRIVESTORE_SPLIT_ADDZERO = "insert RF_ArriveStoreStorageInfo values (?,0,'',0,'')";
        public static readonly string ARRIVESTORE_SPLIT_DELZERO = "delete RF_ArriveStoreStorageInfo where ArriveListID=? and StorageID=0";
        public static readonly string EXCELSTOCK_DELETE = "delete RF_Xml_Stock where gch=? and product_no=? and patch=?";
        public static readonly string EXCELSTOCK_INSERT = "insert into RF_Xml_Stock values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        public static readonly string MAINTAIN_INSERTLIST = "insert RF_Maintain_Detail values (?,?,?,?,?,?,?,?,?,?,?,?,?,null)";
        public static readonly string MAINTAIN_INSERTMAIN = "insert RF_Maintain values (?,?,?,?,?,?,0)";
        public static readonly string MAINTAIN_REMAINTAIN = "update RF_Maintain_Detail set MAINTAINNUM=? where MAINTAIN_NO=? and BARCODE=? and BIN=?";
        public static readonly string STATISTIC_DELETE_BIN = "delete t_stock where bin1 like ?+'%' or bin2 like ?+'%' or bin3 like ?+'%'";
        public static readonly string STATISTIC_DELETE_STOREMAN = "delete t_stock where storeman=?";
        public static readonly string STATISTIC_INSERT = "insert into t_stock values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
    }
}



//using System;
//using System.Collections.Generic;
//////using System.Linq;
//using System.Text;

//namespace BL
//{
//    internal class SqlManager
//    {
//        // Fields
//        public static readonly string ARRIVESTORE_MERGE_ADDSTORGE;
//        public static readonly string ARRIVESTORE_SPLIT;
//        public static readonly string ARRIVESTORE_SPLIT_ADDZERO;
//        public static readonly string ARRIVESTORE_SPLIT_DELZERO;
//        public static readonly string EXCELSTOCK_DELETE;
//        public static readonly string EXCELSTOCK_INSERT;
//        public static readonly string MAINTAIN_INSERTLIST;
//        public static readonly string MAINTAIN_INSERTMAIN;
//        public static readonly string MAINTAIN_REMAINTAIN;
//        public static readonly string STATISTIC_DELETE_BIN;
//        public static readonly string STATISTIC_DELETE_STOREMAN;
//        public static readonly string STATISTIC_INSERT;

//        // Methods
//        static SqlManager()
//        {
//            ARRIVESTORE_SPLIT = "insert RF_ArriveStoreStorageInfo select top 1 ?,StorageID+1,?,?,? from RF_ArriveStoreStorageInfo where ArriveListID=? order by StorageID desc";
//            ARRIVESTORE_SPLIT_ADDZERO = "insert RF_ArriveStoreStorageInfo values (?,0,'',0,'')";
//            ARRIVESTORE_SPLIT_DELZERO = "delete RF_ArriveStoreStorageInfo where ArriveListID=? and StorageID=0";
//            ARRIVESTORE_MERGE_ADDSTORGE = "insert RF_ArriveStoreStorageInfo values (?,?,?,?)";
//            MAINTAIN_INSERTMAIN = "insert RF_Maintain values (?,?,?,?,?,?,0)";
//            MAINTAIN_INSERTLIST = "insert RF_Maintain_Detail values (?,?,?,?,?,?,?,?,?,?,?,?,?,null)";
//            MAINTAIN_REMAINTAIN = "update RF_Maintain_Detail set MAINTAINNUM=? where MAINTAIN_NO=? and BARCODE=? and BIN=?";
//            STATISTIC_DELETE_STOREMAN = "delete t_stock where storeman=?";
//            STATISTIC_DELETE_BIN = "delete t_stock where bin1 like ?+'%' or bin2 like ?+'%' or bin3 like ?+'%'";
//            STATISTIC_INSERT = "insert into t_stock values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
//            EXCELSTOCK_DELETE = "delete RF_Xml_Stock where gch=? and product_no=? and patch=?";
//            EXCELSTOCK_INSERT = "insert into RF_Xml_Stock values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
//        }
//        public SqlManager()
//        {
//        }
//    }
//}
