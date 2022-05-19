using System.Text;

namespace BL
{
    public class Utility
    {
        public static string CleanString(string inputString)
        {
            StringBuilder builder = new StringBuilder();

            if ((inputString != null) && (inputString != string.Empty))
            {
                inputString = inputString.Trim();

                for (int i = 0; i < inputString.Length; i++)
                {
                    switch (inputString[i])
                    {
                        case '<':
                            {
                                builder.Append("&lt;");
                                continue;
                            }
                        case '>':
                            {
                                builder.Append("&gt;");
                                continue;
                            }
                        case '"':
                            {
                                builder.Append("&quot;");
                                continue;
                            }
                    }

                    builder.Append(inputString[i]);
                }

                builder.Replace("'", " ");
            }

            return builder.ToString();
        }

        public static string DeCode(string inputString)
        {
            if ((inputString != null) && (inputString != string.Empty))
            {
                inputString = inputString.Replace("&amp;", "&");
                inputString = inputString.Replace("&lt;", "<");
                inputString = inputString.Replace("&gt;", ">");
                inputString = inputString.Replace("&#39;", "'");
                inputString = inputString.Replace("&quot;", "\"");
                inputString = inputString.Replace("<br>", "\r\n");
            }

            return inputString;
        }

        public static string EnCode(string inputString)
        {
            if ((inputString != null) && (inputString != string.Empty))
            {
                inputString = inputString.Replace("&", "&amp;");
                inputString = inputString.Replace("<", "&lt;");
                inputString = inputString.Replace(">", "&gt;");
                inputString = inputString.Replace("'", "&#39;");
                inputString = inputString.Replace("\"", "&quot;");
                inputString = inputString.Replace("\r\n", "<br>");
            }

            return inputString;
        }
    }
}
