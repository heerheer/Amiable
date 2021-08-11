using Amiable.SDK.Enum;
using Amiable.SDK.EventArgs;
using Amiable.SDK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amiable.SDK;

namespace Amiable.Example
{

    public static class Example
    {
        public static AppInfo GetAppInfo()
        {
            return new AppInfo
            {
                Name = "Amiable.Example",
                Author = "Heer Kaisair",
                Version = "1.0.0",
                Description = "样例应用",
                AppId = "top.amiable.example"
            };
        }
    }

    public class Amiable_Test : IPluginEvent
    {
        public AmiableEventType EventType => AmiableEventType.Group;

        public void Process(AmiableEventArgs _e)
        {
            var e = _e as AmiableMessageEventArgs;
           
            if (e.RawMessage == "#Amiable")
            {
                e.ApiWrapper.OutPutLog("Amiable发现了你哦~");
                var sb = new StringBuilder();
                sb.AppendLine("这是一个由Amiable开发SDK制作的插件");
                sb.AppendLine("项目地址:https://github.com/heerheer/Amiable");
                sb.AppendLine("当前开发状态:14%");
                sb.AppendLine($"当前使用的API适配器:{e.ApiWrapper.GetType().Name}");
                sb.AppendLine($"当前API适配器列表:\n{string.Join("\n",AppService.Instance.ApiWrappers.Select(x=>x.Key))}");
                e.SendMessage(sb.ToString());
                e.HandleResult = EventHandleResult.INTERCEPT;
            }

            

        }
    }
}
