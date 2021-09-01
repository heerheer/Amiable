using HuajiTech.UnmanagedExports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Amiable.SDK;
using Amiable.SDK.EventArgs;
using Amiable.Core.Service;

namespace Amiable.Core
{
    public static class LypExport
    {
        [DllExport]
        public static IntPtr AppInfo()
        {
            AmiableService.ApiKey = "Lyp";
            AmiableService.App.Log("[Lyp]AppInfo");
            return Marshal.StringToHGlobalAnsi(
                EventCore.InitEvent()
            );
        }


        [DllExport] //应用AuthCode接收 
        public static int Initialize(int authCode)
        {
            AmiableService.ApiKey = "Lyp";
            EventCore.PreInitEvent(authCode);
            return 0;
        }

        [DllExport]
        public static int _eventStartup()
        {
            return 0;
        }

        [DllExport]
        public static int _eventExit()
        {
            return 0;
        }

        [DllExport]
        public static int _eventEnable()
        {
            PluginEvents.Event_PluginEnable(new AmiableEventArgs());
            return 0;
        }

        [DllExport]
        public static int _eventDisable()
        {
            return 0;
        }

        [DllExport] //私聊消息
        public static int _eventPrivateMsg(int subType, int msgId, long userId, string msg, int font)
        {
            AmiableService.ApiKey = "Lyp";
            return MessageEvents.Event_PrivateMessage(DateTime.Now.Ticks, 0, "", msgId, userId, msg, font, null); //触发标准事件
        }

        [DllExport] //群消息
        public static int _eventGroupMsg(int subType, int msgId, long group, long userId, string fromAnonymous,
            string msg, int font)
        {
            AmiableService.App.Log("[Lyp]_eventGroupMsg");

            AmiableService.ApiKey = "Lyp";
            return MessageEvents.Event_GroupMessage(DateTime.Now.Ticks, 0, "", msgId, group, userId, msg, font, null); //触发标准事件
        }

        [DllExport] //讨论组消息,【已废弃，请监听群消息】
        public static int _eventDiscussMsg(int subType, int msgId, long fromDiscuss, long userId, string msg, int font)
        {
            return 0;
        }


        [DllExport] //群文件上传事件【LY修改事件】
        public static int _eventGroupUpload(int subType, int sendTime, long group, long userId, string file)
        {
            return 0;
        }

        [DllExport] //群事件-管理员变
        public static int _eventSystem_GroupAdmin(int subType, int sendTime, long group, long beingOperateAccount)
        {
            return 0;
        }

        [DllExport] //群事件-群成员增加
        public static int _eventSystem_GroupMemberIncrease(int subType, int sendTime, long group, long userId,
            long beingOperateAccount)
        {
            return 0;
        }

        [DllExport] //群事件-群成员增加
        public static int _eventSystem_GroupMemberDecrease(int subType, int sendTime, long group, long userId,
            long beingOperateAccount)
        {
            return 0;
        }

        [DllExport] //群事件-群禁言
        public static int _eventSystem_GroupBan(int subType, int sendTime, long group, long beingOperateAccount,
            long duration)
        {
            return 0;
        }

        [DllExport] //好友事件-好友已添加
        public static int _eventFriend_Add(int subType, int sendTime, long fromAccount)
        {
            return 0;
        }

        [DllExport] //群事件-群消息撤回【LY新增事件】
        public static int _eventGroup_Recall(int subType, int sendTime, long group, long fromAccount,
            long beingOperateAccount, string msg)
        {
            return 0;
        }

        [DllExport] //好友事件-消息撤回【LY新增事件】
        public static int _eventFriend_Recall(int subType, int sendTime, long fromAccount,
            string msg)
        {
            return 0;
        }

        [DllExport] //戳一戳事件【LY新增事件】
        public static int _eventPoke(int subType, int sendTime, long group, long userId, long targetAccount)
        {
            return 0;
        }

        [DllExport] //红包运气王事件【LY新增事件】
        public static int _eventLucky_King(int subType, int sendTime, long group, long userId, long targetAccount)
        {
            return 0;
        }

        [DllExport] //群事件-群成员荣誉变更事件【LY新增事件】
        public static int _eventHonor_Changed(int subType, int sendTime, long group, long userId)
        {
            return 0;
        }

        [DllExport] //群事件-群成员名片更新事件【LY新增事件】
        public static int _eventGroupCard_Changed(int subType, int sendTime, long group, long userId, string newCard,
            string oldCard)
        {
            return 0;
        }

        [DllExport] //请求-好友添加
        public static int _eventRequest_AddFriend(int subType, int sendTime, long userId, string msg,
            string responseFlag)
        {
            return 0;
        }

        [DllExport] //请求-群添加
        public static int _eventRequest_AddGroup(int subType, int sendTime, long group, long userId, string msg,
            string responseFlag)
        {
            return 0;
        }

        [DllExport] //载入窗口
        public static int _menuA()
        {
            PluginEvents.Event_PluginMenu(new());
            return 0;
        }

    }
}