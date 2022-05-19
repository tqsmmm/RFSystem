
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
  [RfcStructure(AbapName ="ZSMM_RFC_POX" , Length = 112, Length2 = 206)]
  [Serializable]
  public class ZSMM_RFC_POX : SAPStructure
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
    /// Material Number
    /// </summary>
 
    [RfcField(AbapName = "MATNR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 18, Length2 = 36, Offset = 76, Offset2 = 134)]
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
 
    [RfcField(AbapName = "CHARG", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Length2 = 20, Offset = 94, Offset2 = 170)]
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
 
    [RfcField(AbapName = "WERKS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Length2 = 8, Offset = 104, Offset2 = 190)]
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
    /// Storage location
    /// </summary>
 
    [RfcField(AbapName = "LGORT", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Length2 = 8, Offset = 108, Offset2 = 198)]
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

  }

}