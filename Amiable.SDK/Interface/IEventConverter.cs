using Amiable.SDK.Enum;
using Amiable.SDK.EventArgs;

namespace Amiable.SDK.Interface
{
    /// <summary>
    /// 将原来的PCQQ事件代码转化为Onebot标准的事件代码
    /// 重写AmiableEventArgs中的参数
    /// 返回Amiable允许的事件类型
    /// 默认事件代码来源:
    /// </summary>
    public interface IEventConverter
    {
        public AmiableEventType Convert(int eventType,int subType);

        public EventType GetOnebotEventType(int eventType);

        public MessageEventType GetMessageEventType(int eventType, int subType);

        public MessageEventSubType GetMessageEventSubType(int eventType, int subType);

    }
}