using Amiable.Core.Service;
using Amiable.SDK.DefaultComponent;
using System;

namespace Amiable.Core
{
    public static class CommonEvents
    {
        public static int XX_Event(string robotQQ, int eventType, int extraType, string from, string fromQQ, string targetQQ, string content, string index, string msgid, string udpmsg, string unix, long p)
        {

            try
            {

                switch (eventType)
                {
                    case (int)DefaultEventConverter.CommonEventType.Friend:
                        return MessageEvents.Event_PrivateMessage(DateTime.Now.Ticks, long.Parse(robotQQ), "friend", int.Parse(msgid), long.Parse(fromQQ), content, 0, null);
                    case (int)DefaultEventConverter.CommonEventType.Group:
                        return MessageEvents.Event_GroupMessage(DateTime.Now.Ticks, long.Parse(robotQQ), "normal", int.Parse(msgid), long.Parse(from), long.Parse(fromQQ), content, 0, null);
                    case (int)DefaultEventConverter.CommonEventType.PluginLoaded:
                        PluginEvents.Event_PluginLoad(EventCore.GetAmiableEventArgs(DateTime.Now.Ticks, 0, SDK.Enum.EventType.META_EVENT));
                        break;
                    case (int)DefaultEventConverter.CommonEventType.PluginEnable:
                        PluginEvents.Event_PluginEnable(EventCore.GetAmiableEventArgs(DateTime.Now.Ticks, 0, SDK.Enum.EventType.META_EVENT));
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                AmiableService.App.Log($"[XXEvent错误]\n来源:{ex.Source}\n问题:{ex.Message}\nStack{ex.StackTrace}");
            }
            return 0;
        }
    }
}
