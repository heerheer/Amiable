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

            try
            {

                switch (eventType)
                {
                    case (int)DefaultEventConverter.CommonEventType.Friend:
                        return Event_PrivateMessage(DateTime.Now.Ticks, long.Parse(robotQQ), "friend", int.Parse(msgid), long.Parse(fromQQ), content, 0, null);
                    case (int)DefaultEventConverter.CommonEventType.Group:
                        return Event_GroupMessage(DateTime.Now.Ticks, long.Parse(robotQQ), "normal", int.Parse(msgid), long.Parse(from), long.Parse(fromQQ), content, 0, null);
                    case (int)DefaultEventConverter.CommonEventType.PluginLoaded:
                        Event_PluginLoad(GetAmiableEventArgs(DateTime.Now.Ticks, 0, SDK.Enum.EventType.META_EVENT));
                        break;
                    case (int)DefaultEventConverter.CommonEventType.PluginEnable:
                        Event_PluginEnable(GetAmiableEventArgs(DateTime.Now.Ticks, 0, SDK.Enum.EventType.META_EVENT));
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
