using Amiable.SDK.Enum;
using Amiable.SDK.EventArgs;
using Amiable.SDK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Net.HIni.Tool;

namespace Amiable.Example
{
    public class Drawstick : IPluginEvent
    {
        public AmiableEventType EventType => throw new NotImplementedException();

        public void Process(AmiableEventArgs _e)
        {
            AmiableMessageEventArgs e = _e as AmiableMessageEventArgs;
            IniObject dataini = new IniObject(e.ApiWrapper.GetAppDirectory() + "data.ini");
            IniObject qini = new IniObject(e.XQAPI.AppDirectory + "签.ini");
            dataini.Load();
            qini.Load();
            //抽签 解签
            if (e.Message == "抽签")
            {
                if (qini.Sections.Count <= 0)
                {
                    e.SendMsg("抽签罐空空如也...");
                    return;
                }

                var str = "";
                if (qini["是否开启"]["分群"] == "1")
                {
                    str = dataini[$"{e.FromGroup}-{e.FromQQ}"][DateTime.Today.ToString()];
                }
                else
                {
                    str = dataini[$"{e.FromQQ}"][DateTime.Today.ToString()];
                }

                //判断是否抽过签
                if (str == null || str == "")
                {
                    //没有抽过
                    var qs = qini.Sections;
                    qs = qs.FindAll(s => s.SectionName != "是否开启");

                    var stick = qs[new Random().Next(0, qs.Count)].SectionName;

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"[@{e.FromQQ}]");

                    sb.AppendLine($"签位：{stick}");
                    var qwmsg = qini[stick]["签诗"];
                    sb.AppendLine(qwmsg);
                    sb.Append("解签请发送 解签");

                    e.SendMsg(sb.ToString());

                    if (qini["是否开启"]["分群"] == "1")
                    {
                        dataini[$"{e.FromGroup}-{e.FromQQ}"][DateTime.Today.ToString()] = stick;
                    }
                    else
                    {
                        dataini[$"{e.FromQQ}"][DateTime.Today.ToString()] = stick;
                    }

                    dataini.Save();
                }
                else
                {
                    //抽过
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"[@{e.FromQQ}]");
                    sb.AppendLine($"您今天已经抽过签了！");
                    sb.AppendLine($"签位：{str}");
                    var qwmsg = qini[str]["签诗"];
                    sb.AppendLine(qwmsg);
                    sb.Append("解签请发送 解签");

                    e.SendMsg(sb.ToString());
                }
            }

            if (e.Message == "解签")
            {
                //判断是否抽过签
                var str = "";
                if (qini["是否开启"]["分群"] == "1")
                {
                    str = dataini[$"{e.FromGroup}-{e.FromQQ}"][DateTime.Today.ToString()];
                }
                else
                {
                    str = dataini[$"{e.FromQQ}"][DateTime.Today.ToString()];
                }

                if (str == null || str == "")
                {
                    //没抽过
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"[@{e.FromQQ}]");
                    sb.AppendLine($"您今天还未抽过签！");
                    sb.Append("抽签请发送 抽签");

                    e.SendMsg(sb.ToString());
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"[@{e.FromQQ}]");
                    sb.AppendLine($"解签 {str}");
                    var msg = qini[str]["解签"];
                    sb.Append(msg);

                    e.SendMsg(sb.ToString());
                }
            }
        }
    }
}
