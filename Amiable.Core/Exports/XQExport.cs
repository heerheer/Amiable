using Amiable.Core.Service;
using HuajiTech.UnmanagedExports;

namespace Amiable.Core
{
    public static partial class XQExport
    {
        [DllExport]
        public static void XQ_AuthId(short id, int IMAddr) => XQ_AuthCode(id, IMAddr);

        [DllExport]
        public static void XQ_AutoId(short id, int IMAddr) => XQ_AuthCode(id, IMAddr);

        public static void XQ_AuthCode(short id, int IMAddr)
        {
            AmiableService.ApiKey = "XQ";
            EventCore.PreInitEvent(id, IMAddr);
        }

        [DllExport]
        public static string XQ_Create(string frameworkversion)
        {
            AmiableService.ApiKey = "XQ";
            return EventCore.InitEvent();
        }

        [DllExport]
        public static int
            XQ_Event(string robotQQ, int eventType, int extraType, string from, string fromQQ, string targetQQ, string content, string index, string msgid, string udpmsg, string unix, int p)
        {
            /*对XQ需要的事件的抓换*/
            return CommonEvents.XX_Event(robotQQ, eventType, extraType, from, fromQQ, targetQQ, content, index, msgid, udpmsg, unix, p);
        }

        [DllExport]
        public static int XQ_SetUp() => PluginEvents.Event_PluginMenu(new());
    }
}
