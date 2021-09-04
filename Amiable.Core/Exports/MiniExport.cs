using Amiable.Core.Service;
using HuajiTech.UnmanagedExports;
using System;
using System.Runtime.InteropServices;

namespace Amiable.Core
{
    public static class MiniExport
    {


        [DllExport]
        public static int MQend()
        {

            return 0;
        }

        [DllExport]
        public static void MQset()
        {
            AmiableService.ApiKey = "Mini";
            PluginEvents.Event_PluginMenu(
                new SDK.EventArgs.AmiableEventArgs { Robot = 0, EventType = SDK.Enum.EventType.META_EVENT, Timestamp = DateTime.Now.Ticks });
        }

        [DllExport]
        public static IntPtr MQinfo()
        {
            AmiableService.ApiKey = "Mini";
            var str = EventCore.InitEvent();
            AmiableService.App.Log(str);
            return Marshal.StringToHGlobalAnsi(str);
        }

        [DllExport]
        public static int
            MQEvent(string robotQQ, int eventType, int extraType, string from, string fromQQ, string targetQQ, string content, string index, string msgid, string udpmsg, int pText)
        {
            AmiableService.App.Log("事件" + eventType.ToString());

            AmiableService.ApiKey = "Mini";
            try
            {
                return CommonEvents.XX_Event(robotQQ, eventType, extraType, from, fromQQ, targetQQ, content, index, msgid, udpmsg, "", pText);

            }
            catch (Exception ex)
            {

                AmiableService.App.Log($"Event异常:{ex}");
                return 0;
            }
            return 1;
        }

    }
}
