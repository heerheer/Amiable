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
#if Platform_MQ || DEBUG

        [DllExport]
        public static int MQ_End() => 0;

        [DllExport]
        public static int MQ_Message() => 0;

        [DllExport]
        public static void MQ_Set() { }

        [DllExport]
        public static string MQ_Info() => InitEvent();

        [DllExport]
        public static int
            MQ_Event(string robotQQ, int eventType, int extraType, string from, string fromQQ, string targetQQ, string content, string index, string msgid, string udpmsg, string unix, int p)
        {
            return XX_Event(robotQQ, eventType, extraType, from, fromQQ, targetQQ, content, index, msgid, udpmsg, unix, p);

        }

#endif
    }
}
