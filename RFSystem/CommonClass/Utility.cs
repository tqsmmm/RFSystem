using System.IO;
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
    }
}
