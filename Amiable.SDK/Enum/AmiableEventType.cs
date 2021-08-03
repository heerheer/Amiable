using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amiable.SDK.Enum
{
    public enum AmiableEventType
    {
        /// <summary>
        /// 无法被解析(暂不支持的事件)
        /// </summary>
        Error,
        /// <summary>
        /// 私聊事件
        /// </summary>
       Private,
       /// <summary>
       /// 群消息事件
       /// </summary>
       Group,
       /// <summary>
       /// 增加好友请求
       /// </summary>
       AddFriend,
       /// <summary>
       /// 添加群请求
       /// </summary>
       AddGroup
    }
}
