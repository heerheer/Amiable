using Amiable.Core.Service;
using HuajiTech.UnmanagedExports;
using System;

namespace Amiable.Core
{
    public static class MQExport
    {


        [DllExport]
        public static int MQ_End()
        {

            return 0;
        }

        [DllExport]
        public static int MQ_Message(string SelfId, int Type, string Raw, string Cookies, String SessionKey, string ClientKey) => 0;

        [DllExport]
        public static void MQ_Set()
        {
            AmiableService.ApiKey = "MQ";
            PluginEvents.Event_PluginMenu(
                new SDK.EventArgs.AmiableEventArgs { Robot = 0, EventType = SDK.Enum.EventType.META_EVENT, Timestamp = DateTime.Now.Ticks });
        }

        [DllExport]
        public static string MQ_Info()
        {
            AmiableService.ApiKey = "MQ";
            return EventCore.InitEvent();
        }

        [DllExport]
        public static int
            MQ_Event(string robotQQ, int eventType, int extraType, string from, string fromQQ, string targetQQ, string content, string index, string msgid, string udpmsg, string unix, IntPtr p)
        {
            AmiableService.ApiKey = "MQ";
            try
            {
                return CommonEvents.XX_Event(robotQQ, eventType, extraType, from, fromQQ, targetQQ, content, index, msgid, udpmsg, unix, p.ToInt64());

            }
            catch (Exception ex)
            {

                AmiableService.App.Log($"Event异常:{ex}");
                return 0;
            }

        }

    }
}
