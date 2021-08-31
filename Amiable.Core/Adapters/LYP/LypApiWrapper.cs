using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using Amiable.Adapter.MQ;
using Amiable.SDK;
using Amiable.SDK.EventArgs;
using Amiable.SDK.Wrapper;

namespace Amiable.Adapters.LYP
{
    /// <summary>
    /// 对MQAPI的包装实现
    /// </summary>
    public class LypApiWrapper : IApiWrapper
    {
        private int _authCode;

        private string appDirectory;
        private int logger;
        private int getInstalledApps;
        private int downLoad;

        private string appId;

        private Dictionary<string, int> sdkMethods = new();


        public void SendGroupMessage(string group, string msg)
        {
            Marshal.GetDelegateForFunctionPointer<LypDelegates.SendGroupMsgDelegate>(new(sdkMethods["发送群消息"]))
                .Invoke(long.Parse(group), msg, appId);
        }

        public void SendPrivateMessage(string qq, string msg)
        {
            Marshal.GetDelegateForFunctionPointer<LypDelegates.SendPriMsgDelegate>(new(sdkMethods["发送群消息"]))
                .Invoke(long.Parse(qq), msg, appId);
        }

        public void OutPutLog(string message)
        {
        }

        private delegate string GetSdkFuncs();

        public void Init(params object[] args)
        {
            AppService.Instance.Log("[Lyp]AuthCode");

            var authCode = (int)args[0];
            _authCode = authCode;
            AppService.Instance.Log($"[Lyp]{authCode}");

            var json = Marshal.PtrToStringAnsi(new(authCode));
            JsonDocument jsonDocument = JsonDocument.Parse(json ?? throw new Exception("Lyp初始化: Authcode Json为空"));
            appId = jsonDocument.RootElement.GetProperty("id").GetString();
            logger = GetJsonRootElementValueInt32(jsonDocument, "loggerAddr");
            getInstalledApps = GetJsonRootElementValueInt32(jsonDocument, "getInstalledApps");
            downLoad = GetJsonRootElementValueInt32(jsonDocument, "downLoad");
            var sdkFuncs = GetJsonRootElementValueInt32(jsonDocument, "sdkFuncs");

            GetSdkFuncs getSdkFuncs = Marshal.GetDelegateForFunctionPointer<GetSdkFuncs>(new(sdkFuncs));
            jsonDocument.Dispose();

            var sdkFuncsJson = getSdkFuncs();
            JsonDocument sdkMethodsDocument = JsonDocument.Parse(sdkFuncsJson);

            var methodList = new[]
            {
                "取登录昵称",
                "取登录帐号",
                "撤回消息",
                "发送群消息",
                "发送私聊消息",
                "发送赞",
                "接收图片",
                "接收语音",
                "取Cookies",
                "取CsrfToken",
                "取好友列表",
                "取陌生人信息",
                "取群成员列表",
                "取群列表",
                "是否支持发送图片",
                "是否支持发送语音",
                "置好友添加请求",
                "置匿名群员禁言",
                "置全群禁言",
                "置群成员名片",
                "置群成员专属头衔",
                "置群管理员",
                "置群匿名设置",
                "置群添加请求",
                "置群退出",
                "置群员禁言",
                "置群员移除",
                "取头像_地址",
                "取头像_字节集",
            };

            foreach (var methodStr in methodList)
            {
                SetSdkMethodIntptr(sdkMethodsDocument, methodStr);
            }

            sdkMethodsDocument.Dispose();
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

        private void SetSdkMethodIntptr(JsonDocument doc, string key)
        {
            if (sdkMethods.ContainsKey(key) is false)
            {
                sdkMethods.Add(key, 0);
            }

            sdkMethods[key] = GetJsonRootElementValueInt32(doc, key);
        }

        private int GetJsonRootElementValueInt32(JsonDocument doc, string key)
        {
            var prop = doc.RootElement.GetProperty(key);
            return prop.ValueKind switch
            {
                JsonValueKind.Number => prop.GetInt32(),
                JsonValueKind.String => int.Parse(prop.GetString() ?? "0"),
                _ => 0
            };
        }
    }
}