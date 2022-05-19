
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
  [RfcStructure(AbapName ="ZSMM_RFC_PDZ" , Length = 174, Length2 = 310)]
  [Serializable]
  public class ZSMM_RFC_PDZ : SAPStructure
  {
   

    /// <summary>
    /// Item Number of Purchasing Document
    /// </summary>
 
    [RfcField(AbapName = "EBELP", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 5, Length2 = 10, Offset = 0, Offset2 = 0)]
    [XmlElement("EBELP")]
    public string Ebelp
    { 
       get
       {
          return _Ebelp;
       }
       set
       {
          _Ebelp = value;
       }
    }
    private string _Ebelp;


    /// <summary>
    /// Material Number
    /// </summary>
 
    [RfcField(AbapName = "MATNR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 18, Length2 = 36, Offset = 5, Offset2 = 10)]
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
    /// Short text
    /// </summary>
 
    [RfcField(AbapName = "TXZ01", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Length2 = 80, Offset = 23, Offset2 = 46)]
    [XmlElement("TXZ01")]
    public string Txz01
    { 
       get
       {
          return _Txz01;
       }
       set
       {
          _Txz01 = value;
       }
    }
    private string _Txz01;


    /// <summary>
    /// Base Unit of Measure
    /// </summary>
 
    [RfcField(AbapName = "MEINS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 3, Length2 = 6, Offset = 63, Offset2 = 126)]
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
    /// Purchase order quantity
    /// </summary>
 
    [RfcField(AbapName = "MENGE", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 66, Offset2 = 132)]
    [XmlElement("MENGE")]
    public Decimal Menge
    { 
       get
       {
          return _Menge;
       }
       set
       {
          _Menge = value;
       }
    }
    private Decimal _Menge;


    /// <summary>
    /// Net price in purchasing document (in document currency)
    /// </summary>
 
    [RfcField(AbapName = "NETPR", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 6, Length2 = 6, Decimals = 2, Offset = 73, Offset2 = 139)]
    [XmlElement("NETPR")]
    public Decimal Netpr
    { 
       get
       {
          return _Netpr;
       }
       set
       {
          _Netpr = value;
       }
    }
    private Decimal _Netpr;


    /// <summary>
    /// 
    /// </summary>
 
    [RfcField(AbapName = "MENGW", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 79, Offset2 = 145)]
    [XmlElement("MENGW")]
    public Decimal Mengw
    { 
       get
       {
          return _Mengw;
       }
       set
       {
          _Mengw = value;
       }
    }
    private Decimal _Mengw;


    /// <summary>
    /// Plant
    /// </summary>
 
    [RfcField(AbapName = "WERKS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Length2 = 8, Offset = 86, Offset2 = 152)]
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
    /// Char 15
    /// </summary>
 
    [RfcField(AbapName = "BCT50", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 15, Length2 = 30, Offset = 90, Offset2 = 160)]
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
 
    [RfcField(AbapName = "BCT51", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 105, Offset2 = 190)]
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
 
    [RfcField(AbapName = "BCT60", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 15, Length2 = 30, Offset = 112, Offset2 = 198)]
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
 
    [RfcField(AbapName = "BCT61", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 127, Offset2 = 228)]
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
 
    [RfcField(AbapName = "BCT70", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 15, Length2 = 30, Offset = 134, Offset2 = 236)]
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
 
    [RfcField(AbapName = "BCT71", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 149, Offset2 = 266)]
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
    /// Number of Material Document
    /// </summary>
 
    [RfcField(AbapName = "MBLNR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Length2 = 20, Offset = 156, Offset2 = 274)]
    [XmlElement("MBLNR")]
    public string Mblnr
    { 
       get
       {
          return _Mblnr;
       }
       set
       {
          _Mblnr = value;
       }
    }
    private string _Mblnr;


    /// <summary>
    /// Material Document Year
    /// </summary>
 
    [RfcField(AbapName = "MJAHR", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 4, Length2 = 8, Offset = 166, Offset2 = 294)]
    [XmlElement("MJAHR")]
    public string Mjahr
    { 
       get
       {
          return _Mjahr;
       }
       set
       {
          _Mjahr = value;
       }
    }
    private string _Mjahr;


    /// <summary>
    /// Item in Material Document
    /// </summary>
 
    [RfcField(AbapName = "ZEILE", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 4, Length2 = 8, Offset = 170, Offset2 = 302)]
    [XmlElement("ZEILE")]
    public string Zeile
    { 
       get
       {
          return _Zeile;
       }
       set
       {
          _Zeile = value;
       }
    }
    private string _Zeile;

  }

}
