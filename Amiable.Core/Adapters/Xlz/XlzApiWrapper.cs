using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using Amiable.SDK;
using Amiable.SDK.EventArgs;
using Amiable.SDK.Wrapper;

namespace Amiable.Adapters.Xlz
{
    /// <summary>
    /// 对MQAPI的包装实现
    /// </summary>
    public class XlzApiWrapper : IApiWrapper
    {
        public static Dictionary<string, long> HandlerIntptrs;
        public static Dictionary<string, long> ApiIntptrs;


        private long _robot;
        private string _pluginKey;

        private string appDirectory;


        private string appId;


        public void SendGroupMessage(string group, string msg)
        {
            var delegateFor = Marshal.GetDelegateForFunctionPointer<XlzApiDelegates.SendGroupMsg>
                (new(ApiIntptrs["发送群消息"]));
            delegateFor.Invoke(_pluginKey, _robot, long.Parse(group), msg, false);
        }

        public void SendPrivateMessage(string qq, string msg)
        {
        }

        public void OutPutLog(string message)
        {
        }


        public void Init(params object[] args)
        {
            //小栗子API初始化，这里会传入apidata和pluginkey
            //我们要做的就是存起来pluginkey，解析apidata成为多个委托。

            var apidata = args[1] as string; //api的列表？

            var pluginKey = args[0] as string; //插件key

            var delegateList = args[2] as Dictionary<string, long>; //从Core传过来的委托列表


            HandlerIntptrs = delegateList;

            AppService.Instance.Log(">[Xlz] apidata与pluginKey接收完成");

            _pluginKey = pluginKey; //放入ApiWrapper


            var json = apidata;
            //将api数据变成字典
            ApiIntptrs =
                JsonSerializer.Deserialize<Dictionary<string, long>>(json ??
                                                                     throw new Exception("Lyp初始化: Authcode Json为空"));

            AppService.Instance.Log(json);
            AppService.Instance.Log(pluginKey);


            //看不懂代码，看json得了
        }

        public string GetAppDirectory(string AppName)
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "config", AppName);
            if (Directory.Exists(dir) is false)
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public void SetData(AmiableEventArgs data)
        {
            _robot = data.Robot;
        }
        //下面都是默认不去实现的。

        public string GetFriendsRemark(string qq)
        {
            throw new NotImplementedException();
        }

        public string GetGroupAdmin(string group)
        {
            throw new NotImplementedException();
        }

        public string GetGroupName(string group)
        {
            throw new NotImplementedException();
        }

        public string GetNick(string qq)
        {
            throw new NotImplementedException();
        }

        public string GetPicLink(int imageType, string group, string imageGUID)
        {
            throw new NotImplementedException();
        }

        public string GetRobotOnlineInfo()
        {
            throw new NotImplementedException();
        }

        public string GetVoiLink(string message)
        {
            throw new NotImplementedException();
        }

        public void HandleGroupEvent(int requestType, string QQ, string group, string Seq, int messageType,
            string message)
        {
            throw new NotImplementedException();
        }


        public bool IsOnline(string qq)
        {
            throw new NotImplementedException();
        }

        public string SendPraise(string qq)
        {
            throw new NotImplementedException();
        }


        public bool SignIn(string group, string address, string message)
        {
            throw new NotImplementedException();
        }

        public string WithdrawGroupMessage(string group, string messageNumber, string messageId)
        {
            throw new NotImplementedException();
        }


        public object Clone()
        {
            return base.MemberwiseClone();
        }
    }
}