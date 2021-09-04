using Amiable.Core.Adapters.Ono;
using Amiable.SDK.EventArgs;
using Amiable.SDK.Wrapper;
using System;
using System.IO;
using System.Linq;

namespace Amiable.Core.Adapters.Mini
{
    /// <summary>
    /// 对XQAPI的包装实现
    /// </summary>
    public class MiniApiWrapper : IApiWrapper
    {

        public string RobotQQ { get; set; }

        public void Init(params object[] args)
        {

        }

        public void OutPutLog(string message)
        {
            MiniDLL.Api_OutPutLog(message);
        }

        public void SendGroupMessage(string group, string msg)
        {
            MiniDLL.Api_SendMsg(RobotQQ, 2, group, "", msg);
        }

        public void SendPrivateMessage(string qq, string msg)
        {
            MiniDLL.Api_SendMsg(RobotQQ, 1, "", qq, msg);
        }

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

        public void HandleGroupEvent(int requestType, string QQ, string group, string Seq, int messageType, string message)
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
            return MemberwiseClone();
        }

        public string GetAppDirectory(string AppName)
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "Config", AppName);
            if (Directory.Exists(dir) is false)
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }

        public void SetData(AmiableEventArgs data)
        {
            RobotQQ = data.Robot.ToString();
        }
    }
}
