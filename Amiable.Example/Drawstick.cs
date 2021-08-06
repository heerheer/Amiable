using Amiable.SDK.Enum;
using Amiable.SDK.EventArgs;
using Amiable.SDK.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XQ.Net.HIni.Tool;

namespace Amiable.Example
{
    public class EventEnable : IPluginEvent
    {
        public AmiableEventType EventType => AmiableEventType.PluginEnable;

        public void Process(AmiableEventArgs e)
        {
            var stick_Path = Path.Combine(e.AppDirectory, "签.ini");

            if (!File.Exists(stick_Path))
            {
                //没签？
                Task.Factory.StartNew(async () => {
                    //e.XQAPI.Log("联网获取抽签数据...");
                    var str = await new HttpClient().GetAsync("https://gitee.com/heerkaisair/Draw-A-Stick/raw/master/%E7%AD%BE.ini");
                    File.WriteAllText(stick_Path, await str.Content.ReadAsStringAsync());

                    e.ApiWrapper.OutPutLog("初始化抽签2资源成功");
                });
            }
        }
    }

    public class Drawstick : IPluginEvent
    {
        public AmiableEventType EventType => AmiableEventType.Group;

        public void Process(AmiableEventArgs _e)
        {

            AmiableMessageEventArgs e = _e as AmiableMessageEventArgs;

            if(e.RawMessage is "抽签" or "解签")
            {

            }
            var data_Path = Path.Combine(e.AppDirectory, "data.ini");
            var stick_Path = Path.Combine(e.AppDirectory, "签.ini");

            IniObject dataini = new IniObject(data_Path);
            IniObject qini = new IniObject(stick_Path);

            dataini.Load();
            qini.Load();
            //抽签 解签
            if (e.RawMessage == "抽签")
            {
                if (qini.Sections.Count <= 0)
                {
                    e.SendMessage("抽签罐空空如也...");
                    return;
                }

                var str = "";
                if (qini["是否开启"]["分群"] == "1")
                {
                    str = dataini[$"{e.GroupId}-{e.UserId}"][DateTime.Today.ToString()];
                }
                else
                {
                    str = dataini[$"{e.UserId}"][DateTime.Today.ToString()];
                }

                //判断是否抽过签
                if (str == null || str == "")
                {
                    //没有抽过
                    var qs = qini.Sections;
                    qs = qs.FindAll(s => s.SectionName != "是否开启");

                    var stick = qs[new Random().Next(0, qs.Count)].SectionName;

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"[@{e.UserId}]");

                    sb.AppendLine($"签位：{stick}");
                    var qwmsg = qini[stick]["签诗"];
                    sb.AppendLine(qwmsg);
                    sb.Append("解签请发送 解签");

                    e.SendMessage(sb.ToString());

                    if (qini["是否开启"]["分群"] == "1")
                    {
                        dataini[$"{e.GroupId}-{e.UserId}"][DateTime.Today.ToString()] = stick;
                    }
                    else
                    {
                        dataini[$"{e.UserId}"][DateTime.Today.ToString()] = stick;
                    }

                    dataini.Save();
                }
                else
                {
                    //抽过
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"[@{e.UserId}]");
                    sb.AppendLine($"您今天已经抽过签了！");
                    sb.AppendLine($"签位：{str}");
                    var qwmsg = qini[str]["签诗"];
                    sb.AppendLine(qwmsg);
                    sb.Append("解签请发送 解签");

                    e.SendMessage(sb.ToString());
                }
            }

            if (e.RawMessage == "解签")
            {
                //判断是否抽过签
                var str = "";
                if (qini["是否开启"]["分群"] == "1")
                {
                    str = dataini[$"{e.GroupId}-{e.UserId}"][DateTime.Today.ToString()];
                }
                else
                {
                    str = dataini[$"{e.UserId}"][DateTime.Today.ToString()];
                }

                if (str == null || str == "")
                {
                    //没抽过
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"[@{e.UserId}]");
                    sb.AppendLine($"您今天还未抽过签！");
                    sb.Append("抽签请发送 抽签");

                    e.SendMessage(sb.ToString());
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"[@{e.UserId}]");
                    sb.AppendLine($"解签 {str}");
                    var msg = qini[str]["解签"];
                    sb.Append(msg);

                    e.SendMessage(sb.ToString());
                }
            }
        }
    }
}
