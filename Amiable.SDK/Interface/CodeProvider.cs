using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Amiable.SDK.Interface
{
    /// <summary>
    /// 默认实现的Ir码与CQ码转换器
    /// </summary>
    public abstract class CodeProvider
    {
        /// <summary>
        /// CQCode与IRCode转换器字典
        /// </summary>
        static Dictionary<string, (string IRCode, string CQCode)> Ir2CqRegexs = new()
        {
            { "Image", (@"[pic=$1]", @"[CQ:image,file=$1]") },
            { "Face", (@"[Face$1.gif]", @"[CQ:face,id=$1]") },
            { "Record", (@"[Voi=$1]", @"[CQ:record,file=$1]") },
            { "At", (@"[@$1]", @"[CQ:at,qq=$1]") },
        };


        public static string ConvertCqCodeToIrCode(string str)
        {
            foreach (var regex in Ir2CqRegexs)
            {
                str = Regex.Replace(str,
                    regex.Value.CQCode
                        .Replace("[", @"\[")
                        .Replace("]", @"\]")
                        .Replace("$1", "(.*?)"),
                    regex.Value.IRCode);
            }

            return str;
        }

        public static string ConvertIrCodeToCqCode(string str)
        {
            foreach (var regex in Ir2CqRegexs)
            {
                str = Regex.Replace(str,
                    regex.Value.IRCode
                        .Replace("[", @"\[")
                        .Replace("]", @"\]")
                        .Replace("$1", "(.*?)"),
                    regex.Value.CQCode);
            }

            return str;
        }

        /// <summary>
        /// 默认是QQ号，也可以填all
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public virtual string At(string target)
        {
            return $"[@{target}]";
        }

        /// <summary>
        /// 以路径方式生成Image码
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual string Image(string path)
        {
            return $"[pic={path}]";
        }
    }
}