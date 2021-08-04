using Amiable.SDK.Enum;
using Amiable.SDK.EventArgs;
using Amiable.SDK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amiable.SDK.DefaultComponent
{
    public class DefaultEventConverter : IEventConverter
    {
        enum XQEventType
        {
            None = -1,
            OnlineTmp = 0,
            /// <summary>
            /// 好友私聊消息
            /// </summary>
            Friend = 1,
            /// <summary>
            /// 群消息
            /// </summary>
            Group = 2,
            /// <summary>
            /// 来自群的临时消息
            /// </summary>
            GroupTmp = 4,
            /// <summary>
            /// 来自好友验证的对话消息
            /// </summary>
            AddFriendReply = 7,
            /// <summary>
            /// 收到财付通转账
            /// </summary>
            Money = 6,
            SomeoneWantAddFriend = 101,
            BeRemovedFriend = 104,
            FriendReceivedFile = 105,
            BeCommented = 107,
            SomeoneLeaveGroup = 201,
            BanSpeak = 203,
            UnBanSpeak = 204,
            AllBanSpeak = 205,
            AllUnBanSpeak = 206,
            SomeoneBeAllowedToGroup = 212,
            SomeoneWantAddGroup = 213,
            SelfBeInvitedToGroup = 214,
            SomeoneBeInvitedToGroup = 215,
            GroupDissolved = 216,
            GroupCardChanged = 217,
            SomeoneHasBeenInvitedIntoGroup = 219,
            GroupNameChanged = 220,
            BeRefusedGroup = 221,
            QQLogin = 1101,
            PluginEnable = 12000,
            PluginClicked = 12003,
        }

        class EventTypeAndSub
        {
            public int type; public int subtype; public AmiableEventType AmiableEventType;

            public EventTypeAndSub(int type, int subtype, AmiableEventType amiableEventType)
            {
                this.type = type;
                this.subtype = subtype;
                AmiableEventType = amiableEventType;
            }
        }

        Dictionary<int, EventTypeAndSub> dic = new()
        {
            { (int)XQEventType.Friend, new((int)EventType.MESSAGE, (int)MessageEventSubType.FRIEND, AmiableEventType.Private) },

            { (int)XQEventType.Group, new((int)EventType.MESSAGE, (int)MessageEventSubType.NORMAL, AmiableEventType.Group) },

            { (int)XQEventType.GroupTmp, new((int)EventType.MESSAGE, (int)MessageEventSubType.GROUP, AmiableEventType.Private) }


        };

        public AmiableEventType Convert(int eventType, int subType)
        {
            if (dic.ContainsKey(eventType))
            {
                var rec = dic[eventType];
                return rec.AmiableEventType;
            }
            else
            {
                return AmiableEventType.Error;
            }
        }

        public EventType GetOnebotEventType(int eventType)
        {
            if (dic.ContainsKey(eventType))
            {
                var rec = dic[eventType];
                return (EventType)rec.type;
            }
            else
            {
                throw new Exception("暂不支持的事件");
            }
        }
    }
}
