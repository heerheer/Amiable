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
    public class DefaultEventConverter
    {
        /// <summary>
        /// PCQQ标准的事件
        /// </summary>
        public enum CommonEventType
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
            PluginLoaded = 12000,
            PluginEnable = 12001,
            PluginClicked = 12003,
        }

    }
}
