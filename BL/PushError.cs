namespace BL
{
    public class PushError
    {
        public string PushNow(int iPullErrorId)
        {
            switch (iPullErrorId)
            {
                case 0:
                    return @"未知错误,请检查服务器E:\\log\\logerror.txt文件";

                case 1:
                    return "你的信息已经提交";

                case 2:
                    return @"本跟踪当前正在运行.此时更改跟踪将导致错误,请检查服务器E:\\log\\logerror.txt文件";

                case 3:
                    return @"本跟踪当前正在运行。此时更改跟踪将导致错误,请检查服务器E:\\log\\logerror.txt文件";

                case 4:
                    return @"指定的列无效。,请检查服务器E:\\log\\logerror.txt文件";

                case 9:
                    return @"指定的跟踪句柄无效。,请检查服务器E:\\log\\logerror.txt文件";

                case 11:
                    return @"指定的列在内部使用并且不能删除。,请检查服务器E:\\log\\logerror.txt文件";

                case 13:
                    return @"内存不足。在没有足够内存执行指定的操作时返回此代码。,请检查服务器E:\\log\\logerror.txt文件";

                case 0x10:
                    return @"该函数对此跟踪无效。,请检查服务器E:\\log\\logerror.txt文件";
            }
            return @"未知错误,请检查服务器E:\\log\\logerror.txt文件";
        }
    }
}
