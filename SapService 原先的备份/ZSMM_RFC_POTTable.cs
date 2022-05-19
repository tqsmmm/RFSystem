
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
  /// A typed collection of ZSMM_RFC_POT elements.
  /// </summary>
  [Serializable]
  public class ZSMM_RFC_POTTable : SAPTable 
  {
  
    /// <summary>
    /// Returns the element type ZSMM_RFC_POT.
    /// </summary>
    /// <returns>The type ZSMM_RFC_POT.</returns>
    public override Type GetElementType() 
    {
        return (typeof(ZSMM_RFC_POT));
    }

    /// <summary>
    /// Creates an empty new row of type ZSMM_RFC_POT.
    /// </summary>
    /// <returns>The newZSMM_RFC_POT.</returns>
    public override object CreateNewRow()
    { 
        return new ZSMM_RFC_POT();
    }
     
    /// <summary>
    /// The indexer of the collection.
    /// </summary>
    public ZSMM_RFC_POT this[int index] 
    {
        get 
        {
            return ((ZSMM_RFC_POT)(List[index]));
        }
        set 
        {
            List[index] = value;
        }
    }
        
    /// <summary>
    /// Adds a ZSMM_RFC_POT to the end of the collection.
    /// </summary>
    /// <param name="value">The ZSMM_RFC_POT to be added to the end of the collection.</param>
    /// <returns>The index of the newZSMM_RFC_POT.</returns>
    public int Add(ZSMM_RFC_POT value) 
    {
        return List.Add(value);
    }
        
    /// <summary>
    /// Inserts a ZSMM_RFC_POT into the collection at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which value should be inserted.</param>
    /// <param name="value">The ZSMM_RFC_POT to insert.</param>
    public void Insert(int index, ZSMM_RFC_POT value) 
    {
        List.Insert(index, value);
    }
        
    /// <summary>
    /// Searches for the specified ZSMM_RFC_POT and returnes the zero-based index of the first occurrence in the collection.
    /// </summary>
    /// <param name="value">The ZSMM_RFC_POT to locate in the collection.</param>
    /// <returns>The index of the object found or -1.</returns>
    public int IndexOf(ZSMM_RFC_POT value) 
    {
        return List.IndexOf(value);
    }
        
    /// <summary>
    /// Determines wheter an element is in the collection.
    /// </summary>
    /// <param name="value">The ZSMM_RFC_POT to locate in the collection.</param>
    /// <returns>True if found; else false.</returns>
    public bool Contains(ZSMM_RFC_POT value) 
    {
        return List.Contains(value);
    }
        
    /// <summary>
    /// Removes the first occurrence of the specified ZSMM_RFC_POT from the collection.
    /// </summary>
    /// <param name="value">The ZSMM_RFC_POT to remove from the collection.</param>
    public void Remove(ZSMM_RFC_POT value) 
    {
        List.Remove(value);
    }

    /// <summary>
    /// Copies the contents of the ZSMM_RFC_POTTable to the specified one-dimensional array starting at the specified index in the target array.
    /// </summary>
    /// <param name="array">The one-dimensional destination array.</param>           
    /// <param name="index">The zero-based index in array at which copying begins.</param>           
    public void CopyTo(ZSMM_RFC_POT[] array, int index) 
    {
        List.CopyTo(array, index);
	}
  }
}
