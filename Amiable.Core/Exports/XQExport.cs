using Amiable.SDK.DefaultComponent;
using HuajiTech.UnmanagedExports;
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
#if Platform_XQ || DEBUG
        [DllExport]
        public static void XQ_AuthId(short id, int IMAddr) => XQ_AuthCode(id, IMAddr);

        [DllExport]
        public static void XQ_AutoId(short id, int IMAddr) => XQ_AuthCode(id, IMAddr);

        public static void XQ_AuthCode(short id, int IMAddr)
        {
            PreInitEvent(id, IMAddr);
        }

        [DllExport]
        public static string XQ_Create(string frameworkversion) => InitEvent();

        [DllExport]
        public static int
            XQ_Event(string robotQQ, int eventType, int extraType, string from, string fromQQ, string targetQQ, string content, string index, string msgid, string udpmsg, string unix, int p)
        {
            /*对XQ需要的事件的抓换*/
            return XX_Event(robotQQ, eventType, extraType, from, fromQQ, targetQQ, content, index, msgid, udpmsg, unix, p);
        }
#endif
    }
}
