using Amiable.Core.Service;
using Amiable.SDK.EventArgs;
using HuajiTech.UnmanagedExports;
using System;
using System.Text.Json;

namespace Amiable.Core
{
    //Moh
    public static partial class KumExpport
    {
        [DllExport(EntryPoint = "sj_ql")]//消息_事件_收到群聊消息
        public static int Kum_GroupMsg_AAAAAAAAAAAAAA(string self_id, string sub_type, string msg_id, string group_id, string sender_id, string msg, string anym, string sender_info, string raw)
        {
            try
            {
                var e = JsonSerializer.Deserialize<AmiableMessageEventArgs>(raw);
                return MessageEvents.Event_GroupMessage(e);//触发标准事件

            }
            catch (Exception ex)
            {
                AmiableService.App.Log(ex.ToString());

            }
            return 0;
        }

        [DllExport(EntryPoint = "sj_sl")]//消息_事件_收到私聊消息
        public static int Kum_PrivateMsg_AAAAAAAAAAAAAA(string self_id, string sub_type, string temp_from, string msg_id, string sender_id, string msg, string sender_info, string raw)
        {
            try
            {
                var e = JsonSerializer.Deserialize<AmiableMessageEventArgs>(raw);
                return MessageEvents.Event_PrivateMessage(e);//触发标准事件
            }
            catch (Exception ex)
            {

                AmiableService.App.Log(ex.ToString());
            }
            return 0;
        }

        [DllExport]//插件启用
        public static int plugin_qy()
        {
            PluginEvents.Event_PluginEnable(EventCore.GetAmiableEventArgs(DateTime.Now.Ticks, 0, SDK.Enum.EventType.META_EVENT));

            return 0;
        }

        [DllExport]//插件启用
        public static int plugin_ty()
        {
            //Event_PluginEnable(GetAmiableEventArgs(DateTime.Now.Ticks, 0, SDK.Enum.EventType.META_EVENT));

            return 0;
        }

        [DllExport]//框架启动
        public static int kj_qd()
        {
            PluginEvents.Event_PluginLoad(EventCore.GetAmiableEventArgs(DateTime.Now.Ticks, 0, SDK.Enum.EventType.META_EVENT));

            return 0;
        }

        [DllExport]//插件信息
        public static string plugin_info()
        {
            AmiableService.ApiKey = "Kum";
            return EventCore.InitEvent();
        }

        [DllExport]//框架启动
        public static int plugin_set()
        {
            PluginEvents.Event_PluginMenu(EventCore.GetAmiableEventArgs(DateTime.Now.Ticks, 0, SDK.Enum.EventType.META_EVENT));

            return 0;
        }

        /*
         群成员减少 sj_qcyjs
群成员增加 sj_qcyzj
好友增加 sj_hyzj
好友请求 sj_hyqq
加群请求 sj_jqqq*/
    }
}