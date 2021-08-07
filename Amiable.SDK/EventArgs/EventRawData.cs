using System;

namespace Amiable.SDK.EventArgs
{
    [Obsolete]
    public class EventRawData
    {
        public EventRawData(string robotQQ, int eventType, int subType, string from, string fromQQ, string targetQQ, string content, string index, string msgId, string udpMsg, string unix, int p)
        {
            this.robotQQ = robotQQ;
            EventType = eventType;
            SubType = subType;
            From = from;
            FromQQ = fromQQ;
            TargetQQ = targetQQ;
            Content = content;
            Index = index;
            MsgId = msgId;
            UdpMsg = udpMsg;
            Unix = unix;
            this.p = p;
        }

        public string robotQQ { get; set; }
        public int EventType { get; set; }
        public int SubType { get; set; }
        public string From { get; set; }
        public string FromQQ { get; set; }
        public string TargetQQ { get; set; }
        public string Content { get; set; }
        public string Index { get; set; }
        public string MsgId { get; set; }
        public string UdpMsg { get; set; }
        public string Unix { get; set; }
        public int p { get; set; }
    }
}
