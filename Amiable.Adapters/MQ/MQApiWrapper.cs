using Amiable.SDK.EventArgs;
using Amiable.SDK.Wrapper;
using System;
using System.IO;
using System.Linq;

namespace Amiable.Adapter.MQ
{
    /// <summary>
    /// 对MQAPI的包装实现
    /// </summary>
    public class MQApiWrapper : IApiWrapper
    {

        private string RobotQQ;

        public void SendGroupMessage(string group, string msg)
        {
            MQDLL.Api_SendMsgEx(RobotQQ,0,2,group,string.Empty, msg,0);
        }
        public void SendPrivateMessage(string qq, string msg)
        {
            MQDLL.Api_SendMsgEx(RobotQQ,0,1,string.Empty, qq , msg,0);
        }

        public void OutPutLog(string message)
        {
            MQDLL.Api_OutPutLog(message);
        }

        public void Init(params object[] args)
        {
            
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
            RobotQQ = data.Robot.ToString();
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
            return base.MemberwiseClone();
        }

    }
}
