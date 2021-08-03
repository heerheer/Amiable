using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amiable.SDK.Enum
{
    /// <summary>
    /// Onebot标准的事件类型
    /// </summary>
    public enum EventType
    {
        /*
        message：消息事件
        notice：通知事件
        request：请求事件
        meta_event：元事件
        */
        MESSAGE,
        NOTICE,
        REQUEST,
        META_EVENT
    }
    /// <summary>
    /// Onebot标准的消息事件类型
    /// </summary>
    public enum MessageEventType
    {
        /// <summary>
        /// 私聊消息
        /// </summary>
        PRIVATE = 1,
        /// <summary>
        /// 群聊消息
        /// </summary>
        GROUP = 2,
            
    }

    public enum MessageEventSubType
    {
        /// <summary>
        /// 私聊子事件类型:好友
        /// </summary>
        FRIEND,
        /// <summary>
        /// 私聊子事件类型:群临时消息
        /// </summary>
        GROUP,
        /// <summary>
        /// 私聊子事件类型:其他人
        /// </summary>
        OTHER,
        /// <summary>
        /// 群聊子事件类型:正常
        /// </summary>
        NORMAL,
        /// <summary>
        /// 群聊子事件类型:匿名
        /// </summary>
        ANONYMOUS,
        /// <summary>
        /// 群聊子事件类型:通知
        /// </summary>
        NOTICE
    }
}
