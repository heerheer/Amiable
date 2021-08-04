using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amiable.SDK.Wrapper;
using Amiable.SDK.Enum;

namespace Amiable.SDK.EventArgs
{
    /// <summary>
    /// 最基础的事件参数集 遵循OneBot标准
    /// </summary>
    public class AmiableEventArgs:System.EventArgs
    {
        [JsonPropertyName("time")]
        public long Timestamp { get; set; }

        [JsonPropertyName("self_id")]
        public long Robot { get; set; }

        [JsonPropertyName("post_type")]
        [JsonConverter(typeof(EnumConverter<EventType>))]
        public EventType EventType { get; set; }

        public IApiWrapper ApiWrapper;

        public EventRawData rawData;

        public AmiableMessageEventArgs AsMessageEventArgs()
        {
            //TODO 转化为另一种e
            var e =  (AmiableMessageEventArgs)this;
            return e;
        }
    }
}
