using Amiable.SDK.DefaultComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amiable.Core
{
    public static partial class Export
    {
        public static int XX_Event(string robotQQ, int eventType, int extraType, string from, string fromQQ, string targetQQ, string content, string index, string msgid, string udpmsg, string unix, int p)
        {
            switch (eventType)
            {
                case (int)DefaultEventConverter.CommonEventType.Friend:
                    Event_PrivateMessage(DateTime.Now.Ticks, long.Parse(robotQQ), "friend", int.Parse(msgid), long.Parse(fromQQ), content, 0, null);
                    break;
                case (int)DefaultEventConverter.CommonEventType.Group:
                    Event_GroupMessage(DateTime.Now.Ticks, long.Parse(robotQQ), "normal", int.Parse(msgid), long.Parse(from), long.Parse(fromQQ), content, 0, null);
                    break;
                default:
                    break;
            }
            return 0;
        }
    }
}
