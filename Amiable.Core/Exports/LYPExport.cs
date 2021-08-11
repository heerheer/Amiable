using HuajiTech.UnmanagedExports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amiable.Core
{

    public static partial class Export
    {
        public static string AppInfo() => InitEvent();

        public static int Initialize(int authCode)
        {
            PreInitEvent(authCode);
            return 0;
        }

        public static int _eventStartup()
        {

            return 0;
        }
        public static int _eventExit()
        {
            return 0;
        }
        public static int _eventEnable()
        {
            return 0;
        }
        public static int _eventDisable()
        {
            return 0;
        }
        public static int _eventPrivateMsg(int subType, int msgId, long user_id, string msg, int font)
        {
            return 0;
        }
        public static int _eventGroupMsg(int subType, int msgId, long group, long user_id,string fromAnonymous, string msg, int font)
        {
            return 0;
        }

        //[DllExport(EntryPoint = "请求-好友添加")]
        public static int _eventRequest_AddFriend(int subType, int sendTime, long user_id, string msg, string responseFlag)
        {
            return 0;
        }
        //[DllExport(EntryPoint = "请求-群添加")]
        public static int _eventRequest_AddGroup(int subType, int sendTime, long group,long user_id, string msg, string responseFlag)
        {
            return 0;
        }
    }

}
