using Amiable.SDK.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Amiable.Core
{
#if Platform_Kum
    public static partial class Export
    {
        [DllExport("消息_事件_收到群聊消息", System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static int Kum_GroupMsgEvent(string self_id,string sub_type,string msg_id,string group_id,string sender_id,string msg,string anym,string sender_info,string raw)
        {
            var e = JsonSerializer.Deserialize<AmiableMessageEventArgs>(raw);
            Event_GroupMessage(e);//触发标准事件
            return 0;
        }

        [DllExport("消息_事件_收到群聊消息", System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static int Kum_PrivateMsgEvent(string self_id, string sub_type,string temp_from ,string msg_id, string sender_id, string msg,string sender_info, string raw)
        {
            var e = JsonSerializer.Deserialize<AmiableMessageEventArgs>(raw);
            Event_PrivateMessage(e);//触发标准事件
            return 0;
        }
    }
#endif
}
