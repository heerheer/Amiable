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
    public class A_GroupMsgEvent : IPluginEvent
    {
        public AmiableEventType EventType => AmiableEventType.Group;

        public void Process(AmiableEventArgs _e)
        {
            var e = _e.AsMessageEventArgs();
            if (e.RawMessage == "Amiable")
            {
                var sb = new StringBuilder();
                sb.AppendLine("如果你看到了这个消息，就代表当前测试成功了~");
                sb.AppendLine("这是一个由Amiable开发SDK制作的样例插件");
                sb.AppendLine("这是一个由Amiable开发SDK制作的样例插件");
                e.SendMessage();

            }

        }
    }
}
