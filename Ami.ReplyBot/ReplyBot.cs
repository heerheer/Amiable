using Amiable.SDK;
using Amiable.SDK.Enum;
using Amiable.SDK.EventArgs;
using Amiable.SDK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ami.ReplyBot
{
    public class ReplyBot
    {
        public static AppInfo GetAppInfo()
        {
            return new AppInfo
            {
                Name = "ReplyBot复读姬",
                Author = "Heer Kaisair",
                Version = "1.0.0",
                Description = "1,2,3,复读!!~",
                AppId = "top.amiable.replybot"
            };
        }

    }

    public class ReplyEvent : IPluginEvent
    {

        public static Dictionary<long, List<string>> MsgTemps = new Dictionary<long, List<string>>();
        public AmiableEventType EventType => AmiableEventType.Group;

        public void Process(AmiableEventArgs _e)
        {
            AmiableMessageEventArgs e = (AmiableMessageEventArgs)_e;

            if (!MsgTemps.ContainsKey(e.GroupId))
            {
                MsgTemps.Add(e.GroupId, new List<string>());
                e.ApiWrapper.OutPutLog("新增群列表");

            }

            if (MsgTemps[e.GroupId].Count == 0)
            {
                MsgTemps[e.GroupId].Add(e.RawMessage);
                return;
            }

            if (MsgTemps[e.GroupId].Last() == e.RawMessage)
            {
                //最后一项相等
                if (MsgTemps[e.GroupId].Count >= 1)
                {
                    //需要复读

                    if (new Random().NextDouble() >= 0.5)
                    {
                        e.SendMessage(e.RawMessage);
                        e.ApiWrapper.OutPutLog("复读");
                    }
                    else
                    {
                        e.SendMessage("陌生的旅人打破了复读");
                        e.ApiWrapper.OutPutLog("打破复读");

                    }


                    //清空这个群的记录缓存
                    MsgTemps[e.GroupId].Clear();
                }
                else
                {
                    //还没两次，列表+1
                    MsgTemps[e.GroupId].Add(e.RawMessage);
                }
            }
            else
            {
                //若有人打断了复读，就清空缓存列表，把这句打断人的话加进去
                MsgTemps[e.GroupId].Clear();
                MsgTemps[e.GroupId].Add(e.RawMessage);
            }




        }
    }
}
