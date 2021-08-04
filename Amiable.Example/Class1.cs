using Amiable.SDK.Enum;
using Amiable.SDK.EventArgs;
using Amiable.SDK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amiable.Example
{

    public static class Example
    {
        public static void DoNothing()
        {

        }
    }

    public class A_GroupMsgEvent : IPluginEvent
    {
        public AmiableEventType EventType => AmiableEventType.Group;

        public void Process(AmiableEventArgs _e)
        {
            var e = _e as AmiableMessageEventArgs;
           
            if (e.RawMessage == "Amiable")
            {
                var sb = new StringBuilder();
                sb.AppendLine("如果你看到了这个消息，就代表当前测试成功了~");
                sb.AppendLine("而且这个事件的强制类型转换也成功了！OWO");
                sb.AppendLine("这是一个由Amiable开发SDK制作的样例插件");
                sb.AppendLine("项目地址:https://github.com/heerheer/Amiable");
                sb.AppendLine("当前开发状态:2%");
                sb.AppendLine($"当前使用的API适配器:{e.ApiWrapper.GetType().Name}");
                e.SendMessage(sb.ToString());
            }

        }
    }
}
