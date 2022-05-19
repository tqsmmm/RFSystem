
//------------------------------------------------------------------------------
// 
//     This code was generated by a SAP. NET Connector Proxy Generator Version 2.0
//     Created at 2008-08-13
//     Created from Windows
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// 
//------------------------------------------------------------------------------
using System;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using SAP.Connector;

namespace SapService
{

  /// <summary>
  /// 
  /// </summary>
  [RfcStructure(AbapName ="ZSMM_RFC_BGY" , Length = 230, Length2 = 424)]
  [Serializable]
  public class ZSMM_RFC_BGY : SAPStructure
  {
   

    /// <summary>
    /// Char 15
    /// </summary>
 
    [RfcField(AbapName = "BCT50", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 15, Length2 = 30, Offset = 0, Offset2 = 0)]
    [XmlElement("BCT50")]
    public string Bct50
    { 
       get
       {
          return _Bct50;
       }
       set
       {
          _Bct50 = value;
       }
    }
    private string _Bct50;


    /// <summary>
    /// Quantity
    /// </summary>
 
    [RfcField(AbapName = "BCT51", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 15, Offset2 = 30)]
    [XmlElement("BCT51")]
    public Decimal Bct51
    { 
       get
       {
          return _Bct51;
       }
       set
       {
          _Bct51 = value;
       }
    }
    private Decimal _Bct51;


    /// <summary>
    /// Char 15
    /// </summary>
 
    [RfcField(AbapName = "BCT60", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 15, Length2 = 30, Offset = 22, Offset2 = 38)]
    [XmlElement("BCT60")]
    public string Bct60
    { 
       get
       {
          return _Bct60;
       }
       set
       {
          _Bct60 = value;
       }
    }
    private string _Bct60;


    /// <summary>
    /// Quantity
    /// </summary>
 
    [RfcField(AbapName = "BCT61", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 37, Offset2 = 68)]
    [XmlElement("BCT61")]
    public Decimal Bct61
    { 
       get
       {
          return _Bct61;
       }
       set
       {
          _Bct61 = value;
       }
    }
    private Decimal _Bct61;


    /// <summary>
    /// Char 15
    /// </summary>
 
    [RfcField(AbapName = "BCT70", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 15, Length2 = 30, Offset = 44, Offset2 = 76)]
    [XmlElement("BCT70")]
    public string Bct70
    { 
       get
       {
          return _Bct70;
       }
       set
       {
          _Bct70 = value;
       }
    }
    private string _Bct70;


    /// <summary>
    /// Quantity
    /// </summary>
 
    [RfcField(AbapName = "BCT71", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 59, Offset2 = 106)]
    [XmlElement("BCT71")]
    public Decimal Bct71
    { 
       get
       {
          return _Bct71;
       }
       set
       {
          _Bct71 = value;
       }
    }
    private Decimal _Bct71;


    /// <summary>
    /// Character Field Length = 10
    /// </summary>
 
    [RfcField(AbapName = "BCT10", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Length2 = 20, Offset = 66, Offset2 = 114)]
    [XmlElement("BCT10")]
    public string Bct10
    { 
       get
       {
          return _Bct10;
       }
       set
       {
          _Bct10 = value;
       }
    }
    private string _Bct10;


    /// <summary>
    /// 
    /// </summary>
 
    [RfcField(AbapName = "BCT20", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Length2 = 20, Offset = 76, Offset2 = 134)]
    [XmlElement("BCT20")]
    public string Bct20
    { 
       get
       {
          return _Bct20;
       }
       set
       {
          _Bct20 = value;
       }
    }
    private string _Bct20;


    /// <summary>
    /// Material Number
    /// </summary>
 
    [RfcField(AbapName = "MATNR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 18, Length2 = 36, Offset = 86, Offset2 = 154)]
    [XmlElement("MATNR")]
    public string Matnr
    { 
       get
       {
          return _Matnr;
       }
       set
       {
          _Matnr = value;
       }
    }
    private string _Matnr;


    /// <summary>
    /// Batch Number
    /// </summary>
 
    [RfcField(AbapName = "CHARG", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Length2 = 20, Offset = 104, Offset2 = 190)]
    [XmlElement("CHARG")]
    public string Charg
    { 
       get
       {
          return _Charg;
       }
       set
       {
          _Charg = value;
       }
    }
    private string _Charg;


    /// <summary>
    /// Plant
    /// </summary>
 
    [RfcField(AbapName = "WERKS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Length2 = 8, Offset = 114, Offset2 = 210)]
    [XmlElement("WERKS")]
    public string Werks
    { 
       get
       {
          return _Werks;
       }
       set
       {
          _Werks = value;
       }
    }
    private string _Werks;


    /// <summary>
    /// Material description
    /// </summary>
 
    [RfcField(AbapName = "MAKTX", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Length2 = 80, Offset = 118, Offset2 = 218)]
    [XmlElement("MAKTX")]
    public string Maktx
    { 
       get
       {
          return _Maktx;
       }
       set
       {
          _Maktx = value;
       }
    }
    private string _Maktx;


    /// <summary>
    /// Base Unit of Measure
    /// </summary>
 
    [RfcField(AbapName = "MEINS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 3, Length2 = 6, Offset = 158, Offset2 = 298)]
    [XmlElement("MEINS")]
    public string Meins
    { 
       get
       {
          return _Meins;
       }
       set
       {
          _Meins = value;
       }
    }
    private string _Meins;


    /// <summary>
    /// Storage location
    /// </summary>
 
    [RfcField(AbapName = "LGORT", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Length2 = 8, Offset = 161, Offset2 = 304)]
    [XmlElement("LGORT")]
    public string Lgort
    { 
       get
       {
          return _Lgort;
       }
       set
       {
          _Lgort = value;
       }
    }
    private string _Lgort;


    /// <summary>
    /// Purchasing Document Number
    /// </summary>
 
    [RfcField(AbapName = "EBELN", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Length2 = 20, Offset = 165, Offset2 = 312)]
    [XmlElement("EBELN")]
    public string Ebeln
    { 
       get
       {
          return _Ebeln;
       }
       set
       {
          _Ebeln = value;
       }
    }
    private string _Ebeln;


    /// <summary>
    /// Valuated stock with unrestricted use
    /// </summary>
 
    [RfcField(AbapName = "CLABS", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 175, Offset2 = 332)]
    [XmlElement("CLABS")]
    public Decimal Clabs
    { 
       get
       {
          return _Clabs;
       }
       set
       {
          _Clabs = value;
       }
    }
    private Decimal _Clabs;


    /// <summary>
    /// Name 1
    /// </summary>
 
    [RfcField(AbapName = "NAME1", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 35, Length2 = 70, Offset = 182, Offset2 = 340)]
    [XmlElement("NAME1")]
    public string Name1
    { 
       get
       {
          return _Name1;
       }
       set
       {
          _Name1 = value;
       }
    }
    private string _Name1;


    /// <summary>
    /// Moving Average Price/Periodic Unit Price
    /// </summary>
 
    [RfcField(AbapName = "VERPR", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 6, Length2 = 6, Decimals = 2, Offset = 217, Offset2 = 410)]
    [XmlElement("VERPR")]
    public Decimal Verpr
    { 
       get
       {
          return _Verpr;
       }
       set
       {
          _Verpr = value;
       }
    }
    private Decimal _Verpr;


    /// <summary>
    /// Net weight
    /// </summary>
 
    [RfcField(AbapName = "NTGEW", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 223, Offset2 = 416)]
    [XmlElement("NTGEW")]
    public Decimal Ntgew
    { 
       get
       {
          return _Ntgew;
       }
       set
       {
          _Ntgew = value;
       }
    }
    private Decimal _Ntgew;

  }

}
