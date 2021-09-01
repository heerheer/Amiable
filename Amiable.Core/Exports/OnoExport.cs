using Amiable.Core.Service;
using HuajiTech.UnmanagedExports;

namespace Amiable.Core
{
    public static class OnoExport
    {
        [DllExport]
        public static string OQ_Create()
        {
            AmiableService.ApiKey = "Ono";
            return EventCore.InitEvent();
        }

        [DllExport]
        public static int
            OQ_Event(string robotQQ, int eventType, int extraType, string from, string fromQQ, string targetQQ, string content, string index, string msgid, string udpmsg, string unix, int p)
        {
            /*对XQ需要的事件的抓换*/
            return CommonEvents.XX_Event(robotQQ, eventType, extraType, from, fromQQ, targetQQ, content, index, msgid, udpmsg, unix, p);
        }

        [DllExport]
        public static int OQ_SetUp() => PluginEvents.Event_PluginMenu(new());
    }
}
