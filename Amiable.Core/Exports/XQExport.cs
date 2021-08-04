using Amiable.SDK.DefaultComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Amiable.Core
{
    public static partial class Export
    {
#if Platform_XQ
        [DllExport(CallingConvention.StdCall)]
        public static void XQ_AuthId(short id, int IMAddr) => AuthCode(id, IMAddr);

        [DllExport(CallingConvention.StdCall)]
        public static void XQ_AutoId(short id, int IMAddr) => AuthCode(id, IMAddr);

        public static void AuthCode(short id, int IMAddr)
        {
            PreInitEvent(id, IMAddr);
        }

        [DllExport(CallingConvention.StdCall)]
        public static string XQ_Create(string frameworkversion) => InitEvent();

        [DllExport(CallingConvention.StdCall)]
        public static int
            XQ_Event(string robotQQ, int eventType, int extraType, string from, string fromQQ, string targetQQ, string content, string index, string msgid, string udpmsg, string unix, int p)
        {
            /*对XQ需要的事件的抓换*/
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
#endif
    }
}
