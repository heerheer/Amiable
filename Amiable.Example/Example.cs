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
                Version = "1.0.2",
                Description = "样例应用",
                AppId = "top.amiable.example"
            };
        }
    }

    public class AmiableTest : IPluginEvent
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
                sb.AppendLine("下面这行使用了适配器赋予的CodeProvider");
                sb.AppendLine(AppService.Instance.DefaultCodeProvider.At(e.UserId.ToString()));
                sb.AppendLine("项目地址:https://github.com/heerheer/Amiable");
                sb.AppendLine("当前开发状态:24%");
                sb.AppendLine($"当前使用的API适配器:{e.ApiWrapper.GetType().Name}");
                sb.AppendLine($"当前API适配器列表:\n{string.Join("\n", AppService.Instance.ApiWrappers.Select(x => x.Key))}");
                e.SendMessage(sb.ToString());
                e.HandleResult = EventHandleResult.INTERCEPT;

                var path = @"C:\Users\17674\fxe.jpg";
                e.SendMessage($"测试默认CQ码发送[CQ:image,file={path}]");

                e.SendMessage(CodeProvider.ConvertCqCodeToIrCode($"测试CQ码->IR码(转换器)发送[CQ:image,file={path}]"));
                
                e.SendMessage($"测试IR码发送[pic={path}]");

                e.SendMessage(CodeProvider.ConvertCqCodeToIrCode($"测试使用Provider发送{AppService.Instance.DefaultCodeProvider.Image(path)}"));

                
            }
        }
    }
}