using Amiable.SDK.Enum;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amiable.SDK.EventArgs
{
    public class AmiableMessageEventArgs : AmiableEventArgs
    {

        [JsonPropertyName("message_type")]
        [JsonConverter(typeof(EnumConverter<MessageEventType>))]
        public MessageEventType MessageType { get; set; }

        [JsonPropertyName("sub_type")]
        [JsonConverter(typeof(EnumConverter<MessageEventSubType>))]
        public MessageEventSubType SubType { get; set; }

        [JsonPropertyName("message_id")]
        public int MessageId { get; set; }

        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }

        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("raw_message")]
        public string RawMessage { get; set; }

        [JsonPropertyName("font")]
        public int Font { get; set; }

        [JsonPropertyName("sender")]
        public object Sender { get; set; }

        /// <summary>
        /// 向消息源发送消息
        /// </summary>
        /// <param name="contents"></param>
        public void SendMessage(params object[] contents)
        {
            var _contents = string.Join("", contents);
            switch(MessageType)
            {
                case MessageEventType.GROUP:
                    ApiWrapper.SendGroupMessage(this.GroupId.ToString(), _contents);
                    break;
                case MessageEventType.PRIVATE: 
                    ApiWrapper.SendPrivateMessage(this.UserId.ToString(), _contents);
                    break;
             }
            
        }
    }
}
