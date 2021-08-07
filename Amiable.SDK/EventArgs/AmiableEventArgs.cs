using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amiable.SDK.Wrapper;
using Amiable.SDK.Enum;
using Amiable.SDK.Interface;

namespace Amiable.SDK.EventArgs
{
    /// <summary>
    /// 最基础的事件参数集 遵循OneBot标准
    /// </summary>
    public class AmiableEventArgs : System.EventArgs
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        [JsonPropertyName("time")]
        public long Timestamp { get; set; }

        /// <summary>
        /// 触发事件的机器人QQ
        /// </summary>
        [JsonPropertyName("self_id")]
        public long Robot { get; set; }

        /// <summary>
        /// 事件类型，Onebot标准
        /// </summary>
        [JsonPropertyName("post_type")]
        [JsonConverter(typeof(EnumConverter<EventType>))]
        public EventType EventType { get; set; }

        public EventHandleResult HandleResult { get; set; } = EventHandleResult.NEGLECT;

        /// <summary>
        /// API包装器，用于调用API
        /// </summary>
        public IApiWrapper ApiWrapper;

        /// <summary>
        /// 原始数据
        /// </summary>
        [Obsolete]
        public EventRawData rawData;

        /// <summary>
        /// 插件信息
        /// </summary>
        public AppInfo AppInfo;

        /// <summary>
        /// 转化为其他的事件参数类型
        /// </summary>
        /// <returns></returns>
        [Obsolete("若在相应事件处理中，请直接进行强制类型转换")]
        public AmiableMessageEventArgs AsMessageEventArgs() => this as AmiableMessageEventArgs;

        /// <summary>
        /// 使用AppId作为关键文件夹得到配置目录
        /// </summary>
        public string AppDirectory => ApiWrapper.GetAppDirectory(AppInfo.AppId);

    }
}
