using Amiable.SDK.Enum;
using Amiable.SDK.EventArgs;

namespace Amiable.Core
{
    /* 目的是将所有的框架参数转换为Onebot标准的事件参数*/

    public static partial class Export
    {


        public static int Event_PrivateMessage(long time, long self_id, string sub_type, int msg_id, long user_id, string message, int font, object sender_info)
        {
            AmiableMessageEventArgs eventArgs = new AmiableMessageEventArgs
            {
                EventType = EventType.MESSAGE,
                MessageType = MessageEventType.PRIVATE,
                Timestamp = time,
                Robot = self_id,
                RawMessage = message,
                Font = font,
                MessageId = msg_id,
                UserId = user_id,
                Sender = sender_info,
            };

            return Event_PrivateMessage(eventArgs);
        }

        /// <summary>
        /// 以Onebot标准参数触发私聊事件
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        public static int Event_PrivateMessage(AmiableMessageEventArgs eventArgs)
        {
            AmiableEventType amiableEventType = AmiableEventType.Private;

            InvokeEvents(amiableEventType, eventArgs);
            return (int)eventArgs.HandleResult;
        }

        public static int Event_GroupMessage(long time, long self_id, string sub_type, int msg_id, long group_id, long user_id, string message, int font, object sender_info)
        {

            AmiableMessageEventArgs eventArgs = new AmiableMessageEventArgs
            {
                EventType = EventType.MESSAGE,
                MessageType = MessageEventType.GROUP,
                Timestamp = time,
                Robot = self_id,
                RawMessage = message,
                Font = font,
                GroupId = group_id,
                MessageId = msg_id,
                UserId = user_id,
                Sender = sender_info,
            };

            return Event_GroupMessage(eventArgs);

        }

        /// <summary>
        /// 以Onebot标准参数触发群聊事件
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        public static int Event_GroupMessage(AmiableMessageEventArgs eventArgs)
        {
            AmiableEventType amiableEventType = AmiableEventType.Group;

            InvokeEvents(amiableEventType, eventArgs);

            return (int)eventArgs.HandleResult;
        }


    }
}
