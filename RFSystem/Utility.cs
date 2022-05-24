using RFSystem.AnSteel;
using RFSystem.CommonClass;
using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text;

namespace RFSystem
{
    public class Utility
    {

        public static int Binary_Search(FileStream stream, int stPos, int lineLen, string findVal, out long pos, out string findLine)
        {
            long num = 0L;
            long num2 = (stream.Length / lineLen) - 1L;
            byte[] buffer = new byte[lineLen];
            pos = 0L;

            while (num <= num2)
            {
                long num3 = (num + num2) / 2L;
                stream.Seek(0L, SeekOrigin.Begin);
                stream.Seek(num3 * lineLen, SeekOrigin.Begin);
                stream.Read(buffer, 0, lineLen);
                int num4 = Encoding.GetEncoding("gb2312").GetString(buffer, stPos, Encoding.GetEncoding("gb2312").GetBytes(findVal).Length).CompareTo(findVal);

                if (num4 > 0)
                {
                    num2 = num3 - 1L;
                }
                else if (num4 < 0)
                {
                    num = num3 + 1L;
                }
                else
                {
                    findLine = Encoding.GetEncoding("gb2312").GetString(buffer, 0, buffer.Length);
                    pos = stream.Position - lineLen;
                    return findLine.Length;
                }
            }

            findLine = "";

            return 0;
        }

        public static bool chkEAN(string EAN)
        {
            int num = 0;
            int num2 = 0;

            try
            {
                EAN = EAN.Trim();

                if ((EAN.Length == 13) || (EAN.Length == 8) || (EAN.Length == 12))
                {
                    char ch;
                    int num4;

                    for (int i = 0; i < (EAN.Length - 1); i++)
                    {
                        if ((i % 2) == 0)
                        {
                            ch = EAN[i];
                            num += Convert.ToInt32(ch.ToString());
                        }
                        else
                        {
                            ch = EAN[i];
                            num2 += Convert.ToInt32(ch.ToString());
                        }
                    }

                    if ((EAN.Length == 8) || (EAN.Length == 12))
                    {
                        num4 = 10 - ((num2 + (num * 3)) % 10);
                        ch = EAN[EAN.Length - 1];

                        return (num4.ToString() == ch.ToString()) || ((num4 = 10 - ((num2 + (num * 3)) % 10)).ToString() == "10");
                    }

                    if (EAN.Length == 13)
                    {
                        num4 = 10 - (((num2 * 3) + num) % 10);
                        ch = EAN[EAN.Length - 1];

                        return (num4.ToString() == ch.ToString()) || ((num4 = 10 - (((num2 * 3) + num) % 10)).ToString() == "10");
                    }

                    return false;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public static AnSteelInterFace getSerive()
        {
            Serivce serivce = new Serivce(ConstDefine.g_User, ConstDefine.g_PassWord, ConstDefine.g_ConnStr);

            return serivce.ServiceS;
        }

        public static bool gotMainInfo(string barCode, int barCodeLen, int startPos, int lineLen, string filePath, ref ArrayList bookInfo)
        {
            FileStream stream = null;
            bool flag;
            
            try
            {
                bool flag2;
                string findLine = "";

                if (barCode.Length > barCodeLen)
                {
                    return false;
                }

                barCode = barCode.PadRight(barCodeLen, ' ');
                stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

                long pos;

                if (Binary_Search(stream, startPos, lineLen, barCode, out pos, out findLine) == 0)
                {
                    return false;
                }

                long seekPos = 0L;
                seekPos = pos;
                int num3 = 0;
                goto Label_00A3;
            Label_006A:
                if (seekPos == 0L)
                {
                    num3 = 0;
                    goto Label_00A8;
                }

                seekPos -= lineLen;
                num3 = 1;

                if (SearchValue(stream, startPos, seekPos, lineLen, barCode, out findLine) == 0)
                {
                    goto Label_00A8;
                }
            Label_00A3:
                flag2 = true;
                goto Label_006A;
            Label_00A8:
                if (num3 != 0)
                {
                    seekPos += lineLen;
                }

                goto Label_00E8;
            Label_00BC:
                if (SearchValue(stream, startPos, seekPos, lineLen, barCode, out findLine) == 0)
                {
                    goto Label_00ED;
                }

                seekPos += lineLen;
                bookInfo.Add(findLine);
            Label_00E8:
                flag2 = true;
                goto Label_00BC;
            Label_00ED:
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return flag;
        }

        public static bool gotMainInfoVal(string barCode, int barCodeLen, int startPos, int lineLen, string filePath, ref ArrayList bookInfo)
        {
            FileStream stream = null;
            bool flag;
            long pos = 0L;

            try
            {
                bool flag2;
                string findLine = "";

                if (barCode.Length > barCodeLen)
                {
                    return false;
                }

                barCode = barCode.PadRight(barCodeLen, ' ');
                stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

                if (Binary_Search(stream, startPos, lineLen, barCode, out pos, out findLine) == 0)
                {
                    return false;
                }

                long seekPos = 0L;
                seekPos = pos;
                int num3 = 0;
                goto Label_00A3;
            Label_006A:
                if (seekPos == 0L)
                {
                    num3 = 0;
                    goto Label_00A8;
                }

                seekPos -= lineLen;
                num3 = 1;

                if (SearchValueVal(stream, startPos, seekPos, lineLen, barCode, out findLine) == 0)
                {
                    goto Label_00A8;
                }
            Label_00A3:
                flag2 = true;
                goto Label_006A;
            Label_00A8:
                if (num3 != 0)
                {
                    seekPos += lineLen;
                }

                goto Label_00E8;
            Label_00BC:
                if (SearchValueVal(stream, startPos, seekPos, lineLen, barCode, out findLine) == 0)
                {
                    goto Label_00ED;
                }

                seekPos += lineLen;
                bookInfo.Add(findLine);
            Label_00E8:
                flag2 = true;

                goto Label_00BC;
            Label_00ED:
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return flag;
        }

        public static string LabelFormat(int LineLen, string val)
        {
            try
            {
                string str = "";
                byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(val);
                int length = bytes.Length;

                if (length <= LineLen)
                {
                    return val;
                }

                int num2 = 0;

                while (length > LineLen)
                {
                    byte[] buffer2;

                    if (bytes[LineLen - 1] < 0x80)
                    {
                        str = str + "\n" + Encoding.GetEncoding("gb2312").GetString(bytes, 0, LineLen);
                        length -= LineLen;
                        num2 += LineLen;
                        buffer2 = new byte[length];
                        Array.Copy(bytes, LineLen, buffer2, 0, length);
                        bytes = buffer2;
                    }
                    else if (bytes[LineLen - 1] >= 0x80)
                    {
                        int num3 = 0;

                        for (int i = 0; i <= (LineLen - 1); i++)
                        {
                            if (bytes[i] >= 0x80)
                            {
                                num3++;
                            }
                        }

                        if ((num3 % 2) == 0)
                        {
                            str = str + "\n" + Encoding.GetEncoding("gb2312").GetString(bytes, 0, LineLen);
                            length -= LineLen;
                            num2 += LineLen;
                            buffer2 = new byte[length];
                            Array.Copy(bytes, LineLen, buffer2, 0, length);
                            bytes = buffer2;
                        }
                        else
                        {
                            str = str + "\n" + Encoding.GetEncoding("gb2312").GetString(bytes, 0, LineLen - 1);
                            length = length - LineLen + 1;
                            num2 = num2 + LineLen - 1;
                            buffer2 = new byte[length];
                            Array.Copy(bytes, LineLen - 1, buffer2, 0, length);
                            bytes = buffer2;
                        }
                    }
                }

                str = str + "\n" + Encoding.GetEncoding("gb2312").GetString(bytes, 0, length);

                if (str.Length > 0)
                {
                    while (str[0] == '\n')
                    {
                        str = str.Substring(1);

                        if (str.Length == 0)
                        {
                            break;
                        }
                    }
                }

                return str;
            }
            catch
            {
                return val;
            }
        }

        public static string RunPath()
        {
            FileInfo info = new FileInfo(Path.GetFullPath(Assembly.GetExecutingAssembly().GetName().CodeBase));

            return info.DirectoryName;
        }

        public static int SearchAllSubValue(FileStream stream, int stPos, long SeekPos, int lineLen, string findVal, int findItemLen, out ArrayList findInfo)
        {
            findInfo = new ArrayList();
            stream.Seek(SeekPos, SeekOrigin.Begin);
            byte[] buffer = new byte[lineLen];
            int length = Encoding.GetEncoding("gb2312").GetBytes(findVal).Length;

            while (stream.Read(buffer, 0, buffer.Length) == lineLen)
            {
                if (Encoding.GetEncoding("gb2312").GetString(buffer, stPos, findItemLen).IndexOf(findVal) != -1)
                {
                    findInfo.Add(Encoding.GetEncoding("gb2312").GetString(buffer, 0, buffer.Length));
                }
            }

            if (findInfo.Count == 0)
            {
                return -1;
            }

            return 0;
        }

        public static int SearchAllValue(FileStream stream, int stPos, long SeekPos, int lineLen, string findVal, out ArrayList findInfo)
        {
            findInfo = new ArrayList();
            stream.Seek(SeekPos, SeekOrigin.Begin);
            byte[] buffer = new byte[lineLen];
            int length = Encoding.GetEncoding("gb2312").GetBytes(findVal).Length;

            while (stream.Read(buffer, 0, buffer.Length) == lineLen)
            {
                if (findVal == Encoding.GetEncoding("gb2312").GetString(buffer, stPos, length))
                {
                    findInfo.Add(Encoding.GetEncoding("gb2312").GetString(buffer, 0, buffer.Length));
                }
            }

            if (findInfo.Count == 0)
            {
                return -1;
            }

            return 0;
        }

        public static int SearchValue(FileStream stream, int stPos, long SeekPos, int lineLen, string findVal, out string findLine)
        {
            stream.Seek(SeekPos, SeekOrigin.Begin);
            byte[] buffer = new byte[lineLen];
            int length = Encoding.GetEncoding("gb2312").GetBytes(findVal).Length;

            if ((stream.Read(buffer, 0, buffer.Length) == lineLen) && (findVal == Encoding.GetEncoding("gb2312").GetString(buffer, stPos, length)))
            {
                findLine = Encoding.GetEncoding("gb2312").GetString(buffer, 0, buffer.Length);

                return findLine.Length;
            }

            findLine = "";

            return 0;
        }

        public static int SearchValueVal(FileStream stream, int stPos, long SeekPos, int lineLen, string findVal, out string findLine)
        {
            stream.Seek(SeekPos, SeekOrigin.Begin);
            byte[] buffer = new byte[lineLen];
            int length = Encoding.GetEncoding("gb2312").GetBytes(findVal).Length;

            if ((stream.Read(buffer, 0, buffer.Length) == lineLen) && (findVal.ToUpper() == Encoding.GetEncoding("gb2312").GetString(buffer, stPos, length).ToUpper()))
            {
                findLine = Encoding.GetEncoding("gb2312").GetString(buffer, 0, buffer.Length);

                return findLine.Length;
            }

            findLine = "";

            return 0;
        }
    }
}
