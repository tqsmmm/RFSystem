using System;

namespace AnComm
{
	/// <summary>
	/// Utility 的摘要说明。
	/// </summary>
	public class Utility
	{
		public Utility()
		{
		}

/// <summary>
/// 对数据进行压缩
/// </summary>
/// <param name="needAdd"></param>
/// <returns></returns>
		public static byte[] addZip(byte[] needAdd )
		{
			System.IO.MemoryStream ms = new System.IO.MemoryStream();
			try
			{
				ICSharpCode.SharpZipLib.GZip.GZipOutputStream zipOut = new ICSharpCode.SharpZipLib.GZip.GZipOutputStream( ms ) ;
				
				zipOut.Write(needAdd, 0 , needAdd.Length ) ;
				zipOut.Finish();
				zipOut.Close();
			
				return ms.ToArray(); 
			}
			finally
			{
				ms.Close(); 
			}
		}


		public static string padRightSPACE(int length,string val)
		{
			byte[] retval = new byte[length] ;
			for(int i = 0;i <length;i++)
			{
				retval[i] = (byte)' ';
			}
			byte[] bytval = System.Text.Encoding.GetEncoding("gb2312").GetBytes(val);  
			if(bytval.Length == length)
			{
				return val;
			}
			else
			{
				Array.Copy(bytval,0,retval,0,bytval.Length); 
			}
			return System.Text.Encoding.GetEncoding("gb2312").GetString( retval,0,retval.Length);
		}

		public static string padLeftSPACE(int length,string val)
		{
			byte[] retval = new byte[length] ;
			for(int i = 0;i <length;i++)
			{
				retval[i] = (byte)' ';
			}
			byte[] bytval = System.Text.Encoding.GetEncoding("gb2312").GetBytes(val);  
			if(bytval.Length == length)
			{
				return val;
			}
			else
			{
				Array.Copy(bytval,0,retval,retval.Length -bytval.Length,bytval.Length); 
			}
			return System.Text.Encoding.GetEncoding("gb2312").GetString( retval,0,retval.Length);
		}

/// <summary>
/// 对数据进行解压缩
/// </summary>
/// <param name="needExact"></param>
/// <returns></returns>
		public static byte[] ExactZip(byte[] needExact )
		{
			System.IO.MemoryStream ret = new System.IO.MemoryStream(needExact);
			System.IO.MemoryStream ret1 = new System.IO.MemoryStream();

			ICSharpCode.SharpZipLib.GZip.GZipInputStream zipIn = new ICSharpCode.SharpZipLib.GZip.GZipInputStream(ret);
			
			byte[] buffer = new byte[2048] ;
			int size = 2048;
			while (true)
			{
				size = zipIn.Read (buffer, 0, buffer.Length);
				if (size > 0)
				{
					ret1.Write(buffer, 0, size);
				}
				else
				{
					break;
				}
			}
			return ret1.ToArray(); 
		}

/// <summary>
/// 对行定长且数据是按照某一列正向排序的数据进行二分法查找，且查找出所有匹配的数据
/// </summary>
/// <param name="barCode"></param>
/// <param name="barCodeLen"></param>
/// <param name="startPos"></param>
/// <param name="lineLen"></param>
/// <param name="filePath"></param>
/// <param name="bookInfo"></param>
/// <returns></returns>
		public static bool gotMainInfo(string barCode,int barCodeLen,int startPos ,int lineLen,string filePath,ref System.Collections.ArrayList  bookInfo)
		{
			System.IO.FileStream fs = null;
			long pos = 0;
			//bookInfo = new ArrayList(); 
			try
			{
				string findLine = "";
				if(barCode.Length > barCodeLen)
				{
					return false;
				}
				barCode = barCode.PadRight(barCodeLen,' '); 
				fs = new System.IO.FileStream(filePath,System.IO.FileMode.Open,System.IO.FileAccess.Read,System.IO.FileShare.Read );     
				if(Binary_Search(fs,startPos,lineLen,barCode,out pos,out findLine) == 0)
				{
					return false;
				}
				long SeekPos = 0;
				SeekPos = pos;
				int sldAdd = 0;
				while(true)
				{
					if(SeekPos == 0)
					{
						sldAdd = 0;
						break;
					}
					SeekPos = SeekPos - lineLen;
					sldAdd = 1;
					if(SearchValue(fs,startPos,SeekPos,lineLen,barCode,out findLine)== 0)
					{
						break;
					}
				}
				if(sldAdd != 0)
				{
					SeekPos = SeekPos + lineLen;
				}
				while(true)
				{
					if(SearchValue(fs,startPos,SeekPos,lineLen,barCode,out findLine)== 0)
					{
						break;
					}
					
					SeekPos = SeekPos + lineLen;
					bookInfo.Add(findLine);
				}
				return true;
			}
			catch(Exception)
			{
				return false;
			}
			finally
			{
				if(fs != null)
				{
					fs.Close(); 
				}
			}
		}



        public static bool gotMainInfoVal(string barCode, int barCodeLen, int startPos, int lineLen, string filePath, ref System.Collections.ArrayList bookInfo)
        {
            System.IO.FileStream fs = null;
            long pos = 0;
            //bookInfo = new ArrayList(); 
            try
            {
                string findLine = "";
                if (barCode.Length > barCodeLen)
                {
                    return false;
                }
                barCode = barCode.PadRight(barCodeLen, ' ');
                fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                if (Binary_Search(fs, startPos, lineLen, barCode, out pos, out findLine) == 0)
                {
                    return false;
                }
                long SeekPos = 0;
                SeekPos = pos;
                int sldAdd = 0;
                while (true)
                {
                    if (SeekPos == 0)
                    {
                        sldAdd = 0;
                        break;
                    }
                    SeekPos = SeekPos - lineLen;
                    sldAdd = 1;
                    if (SearchValueVal(fs, startPos, SeekPos, lineLen, barCode, out findLine) == 0)
                    {
                        break;
                    }
                }
                if (sldAdd != 0)
                {
                    SeekPos = SeekPos + lineLen;
                }
                while (true)
                {
                    if (SearchValueVal(fs, startPos, SeekPos, lineLen, barCode, out findLine) == 0)
                    {
                        break;
                    }

                    SeekPos = SeekPos + lineLen;
                    bookInfo.Add(findLine);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

/// <summary>
/// 对行定长且数据是按照某一列正向排序的数据进行二分法查找
/// </summary>
/// <param name="stream"></param>
/// <param name="stPos"></param>
/// <param name="lineLen"></param>
/// <param name="findVal"></param>
/// <param name="pos"></param>
/// <param name="findLine"></param>
/// <returns></returns>
		public static int Binary_Search(System.IO.FileStream stream,int stPos,int lineLen,string findVal,out long pos,out string findLine)
		{
			long low = 0;
			long high = stream.Length/lineLen -1; 
			byte[] val = new byte[lineLen];
			pos = 0;
			while(low <= high)
			{
				long mid = (low + high)/2;
				stream.Seek(0,System.IO.SeekOrigin.Begin);
				stream.Seek(mid*lineLen,System.IO.SeekOrigin.Begin); 
				stream.Read(val,0,lineLen);
				int compare = System.Text.Encoding.GetEncoding("gb2312").GetString(val,stPos,System.Text.Encoding.GetEncoding("gb2312").GetBytes(findVal).Length).CompareTo(findVal);
				if(compare > 0)
				{
					high = mid -1;
					
				}
				else if(compare < 0)
				{
					low = mid + 1;
				}
				else
				{
					findLine = System.Text.Encoding.GetEncoding("gb2312").GetString(val,0,val.Length); 
					pos = stream.Position - lineLen;
					return findLine.Length;
				}
			}
			findLine = "";
			return 0;
		}

/// <summary>
/// 对行定长的文件进行顺序查找
/// </summary>
/// <param name="stream"></param>
/// <param name="stPos"></param>
/// <param name="SeekPos"></param>
/// <param name="lineLen"></param>
/// <param name="findVal"></param>
/// <param name="findLine"></param>
/// <returns></returns>
		public static  int SearchValue(System.IO.FileStream stream,int stPos,long SeekPos,int lineLen,string findVal,out string findLine)
		{
			stream.Seek(SeekPos,System.IO.SeekOrigin.Begin);
			byte[] array = new byte[lineLen];
			int findLen = System.Text.Encoding.GetEncoding("gb2312") .GetBytes(findVal).Length; 
			if(stream.Read(array,0,array.Length) == lineLen)
			{
				if( findVal == System.Text.Encoding.GetEncoding("gb2312").GetString(array,stPos,findLen) )
				{
					findLine = System.Text.Encoding.GetEncoding("gb2312").GetString(array,0,array.Length); 
					return findLine.Length; 
				}
			}
			findLine = "";
			return 0;
		}


        public static int SearchValueVal(System.IO.FileStream stream, int stPos, long SeekPos, int lineLen, string findVal, out string findLine)
        {
            stream.Seek(SeekPos, System.IO.SeekOrigin.Begin);
            byte[] array = new byte[lineLen];
            int findLen = System.Text.Encoding.GetEncoding("gb2312").GetBytes(findVal).Length;
            if (stream.Read(array, 0, array.Length) == lineLen)
            {
                if (findVal.ToUpper() == System.Text.Encoding.GetEncoding("gb2312").GetString(array, stPos, findLen).ToUpper())
                {
                    findLine = System.Text.Encoding.GetEncoding("gb2312").GetString(array, 0, array.Length);
                    return findLine.Length;
                }
            }
            findLine = "";
            return 0;
        }



		/// <summary>
		/// 对行定长的文件进行顺序查找
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="stPos"></param>
		/// <param name="SeekPos"></param>
		/// <param name="lineLen"></param>
		/// <param name="findVal"></param>
		/// <param name="findLine"></param>
		/// <returns></returns>
		public static  int SearchAllValue(System.IO.FileStream stream,int stPos,long SeekPos,int lineLen,string findVal,out System.Collections.ArrayList findInfo)
		{
			findInfo = new System.Collections.ArrayList(); 
			stream.Seek(SeekPos,System.IO.SeekOrigin.Begin);
			byte[] array = new byte[lineLen];
			int findLen = System.Text.Encoding.GetEncoding("gb2312") .GetBytes(findVal).Length; 
			while(stream.Read(array,0,array.Length) == lineLen)
			{
				if( findVal == System.Text.Encoding.GetEncoding("gb2312").GetString(array,stPos,findLen) )
				{
					findInfo.Add(System.Text.Encoding.GetEncoding("gb2312").GetString(array,0,array.Length)); 
				}
			}
			if(findInfo.Count == 0)
			{
				return -1;
			}
			return 0;
		}


        /// <summary>
        /// 对行定长的文件进行顺序查找
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="stPos"></param>
        /// <param name="SeekPos"></param>
        /// <param name="lineLen"></param>
        /// <param name="findVal"></param>
        /// <param name="findLine"></param>
        /// <returns></returns>
        public static int SearchAllSubValue(System.IO.FileStream stream, int stPos, long SeekPos, int lineLen, string findVal,int findItemLen, out System.Collections.ArrayList findInfo)
        {
            findInfo = new System.Collections.ArrayList();
            stream.Seek(SeekPos, System.IO.SeekOrigin.Begin);
            byte[] array = new byte[lineLen];
            int findLen = System.Text.Encoding.GetEncoding("gb2312").GetBytes(findVal).Length;
            while (stream.Read(array, 0, array.Length) == lineLen)
            {
                if (System.Text.Encoding.GetEncoding("gb2312").GetString(array, stPos, findItemLen).IndexOf(findVal)!=-1)
                {
                    findInfo.Add(System.Text.Encoding.GetEncoding("gb2312").GetString(array, 0, array.Length));
                }
            }
            if (findInfo.Count == 0)
            {
                return -1;
            }
            return 0;
        }





/// <summary>
/// 用来加密数据
/// </summary>
/// <param name="needEncode"></param>
/// <returns></returns>
		public static  byte[] EncodeValue(byte[] needEncode)
		{
			byte[] addEncode = addZip(needEncode);
			byte[] Encode = new byte[addEncode.Length];
			for(int i = addEncode.Length -1,j= 0;i >= 0;i--,j++ )
			{
				Encode[j] = addEncode[i];
			}
			return Encode;
		}



/// <summary>
/// 用来解密数据
/// </summary>
/// <param name="needDecode"></param>
/// <returns></returns>
		public static  byte[] DecodeValue(byte[] needDecode)
		{
			byte[] Encode = new byte[needDecode.Length];
			for(int i = needDecode.Length -1,j= 0;i >= 0;i--,j++ )
			{
				Encode[j] = needDecode[i];
			}
			byte[] addEncode = ExactZip(Encode);
			
			return addEncode;
		}


		public static byte[] addDataSet(System.Data.DataSet ds)
		{
			System.IO.MemoryStream ms = new System.IO.MemoryStream();
			System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(ms,System.Text.Encoding.UTF8);  
			//xmlWrite.lo
			//ds.WriteXml(
			ds.WriteXml(writer,System.Data.XmlWriteMode.WriteSchema);
		
			 
			ms.Seek(0,System.IO.SeekOrigin.Begin);
			byte[] kao = new byte[ms.Length ]; 
			ms.Read (kao,0,kao.Length );
			ms.Close(); 
			return addZip(kao);
		}

		public static System.Data.DataSet ExactDataSet(byte[] addDs)
		{
			byte[] kao = ExactZip(addDs);
			System.Data.DataSet ds = new System.Data.DataSet();
			System.IO.MemoryStream ms = new System.IO.MemoryStream();
			ms.Write(kao,0,kao.Length);
			
			ms.Seek(0,System.IO.SeekOrigin.Begin); 
			System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(ms); 
			ds.ReadXml(reader,System.Data.XmlReadMode.Auto);
//			ms.Seek(0,System.IO.SeekOrigin.Begin); 
//			byte[] shit = new byte[ms.Length]; 
//			ms.Read(shit,0,(int)ms.Length);
//			System.IO.FileStream fs = new System.IO.FileStream("a.txt",System.IO.FileMode.CreateNew);
//			fs.Write(shit,0,shit.Length);
//			fs.Close(); 
			
			ms.Close(); 
			
			 
			return ds;
		}

		public static bool chkEAN(string EAN)
		{
			int oddVal = 0;
			int ouVal = 0;
			try
			{
				EAN = EAN.Trim(); 
				if(EAN.Length == 13 || EAN.Length == 8 || EAN.Length == 12)
				{
					for(int i = 0; i< EAN.Length -1; i++)
					{
						if(i% 2 == 0)
						{
							oddVal =oddVal + Convert.ToInt32( EAN[i].ToString() );
						}
						else
						{
							ouVal = ouVal + Convert.ToInt32( EAN[i].ToString() );
						}
					}
					if(EAN.Length == 8 || EAN.Length == 12)
					{
						if(((10 -(ouVal + oddVal*3)%10).ToString() == EAN[EAN.Length -1].ToString() )
							|| ((10 -(ouVal + oddVal*3)%10).ToString() == "10"))
						{
							return true;
						}
						return false;
					}
					else if(EAN.Length == 13)
					{
						if(((10 -(ouVal*3 + oddVal)%10).ToString() == EAN[EAN.Length -1].ToString() )
							|| ((10 -(ouVal*3 + oddVal)%10).ToString() == "10"))
						{
							return true;
						}
						return false;
					}

					return false;
				}
				else 
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
		}


		public static string  LabelFormat(int LineLen,string val)
		{
			try
			{
				string lab = "";
				byte[] byteVal = System.Text.Encoding.GetEncoding("gb2312").GetBytes(val);  
				int Len = byteVal.Length; 
				if(Len <= LineLen)
				{
					lab = val;
					return lab;
				}
				else
				{
					int m = 0;
					while(Len > LineLen)
					{
						if(byteVal[LineLen-1] <128)
						{
							lab = lab +"\n"+ System.Text.Encoding.GetEncoding("gb2312").GetString(byteVal,0,LineLen);
							Len = Len -LineLen;
							m = m+ LineLen;
							byte[] shit = new byte[Len];
							Array.Copy(byteVal,LineLen,shit,0,Len); 
							byteVal = shit;
						}
						else
						{
							if(byteVal[LineLen -1] >=128 )
							{
								int s = 0;
								for(int k = 0; k<= LineLen -1;k++)
								{
									if(byteVal[k]>=128)
									{
										s++;
									}
								}
								if(s%2== 0)
								{
									lab = lab +"\n"+ System.Text.Encoding.GetEncoding("gb2312").GetString(byteVal,0,LineLen);
									Len = Len -LineLen;
									m = m+ LineLen;
									byte[] shit = new byte[Len];
									Array.Copy(byteVal,LineLen,shit,0,Len); 
									byteVal = shit;
								}
								else
								{
									lab = lab +"\n"+ System.Text.Encoding.GetEncoding("gb2312").GetString(byteVal,0,LineLen-1);
									Len = Len -LineLen +1;
									m = m+ LineLen-1;
									byte[] shit = new byte[Len];
									Array.Copy(byteVal,LineLen-1,shit,0,Len); 
									byteVal = shit;
								}
							}
						}
					}
					lab = lab +"\n"+ System.Text.Encoding.GetEncoding("gb2312").GetString(byteVal,0,Len);
					if(lab.Length > 0)
					{
						while(lab[0] =='\n')
						{
							lab = lab.Substring(1); 
							if(lab.Length == 0)
							{
								break;
							}
						}
					}
					return lab;
				}
			}
			catch
			{
				return val;
			}
		}

        public static string RunPath()
        {
            System.IO.FileInfo Fi = new System.IO.FileInfo(System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase));
            return Fi.DirectoryName; 
        }

		
	}
}
