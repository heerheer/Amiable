using Amiable.SDK;
using Amiable.SDK.Interface;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Amiable.Core.Adapters.Ono
{
    /// <summary>
    /// 允许将AppInfo转换为Ono可用的Json
    /// </summary>
    public class OnoAppInfoConverter : IAppInfoConverter
    {

        public string Convert(AppInfo info)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"插件名称{{{info.Name}}}");
            sb.AppendLine($"插件版本{{{info.Version}}}");
            sb.AppendLine($"插件作者{{{info.Author}}}");
            sb.AppendLine($"插件说明{{{info.Description}}}");
            sb.AppendLine($"插件skey{{{"8956RTEWDFG3216598WERDF3"}}}");
            sb.AppendLine($"插件sdk{{{"S3"}}}");
            return sb.ToString();
        }
    }
}
