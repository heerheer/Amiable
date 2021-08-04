using Amiable.SDK.EventArgs;
using Amiable.SDK.Wrapper;
using System;
using System.Linq;

namespace Amiable.Adapter.XQ
{
    /// <summary>
    /// 对XQAPI的包装实现
    /// </summary>
    public class KumApiWrapper : IApiWrapper
    {
        private static byte[] AuthId;

        public string RobotQQ { get; set; }

        void SetAuthID(int id, int addr)
        {
            AuthId = BitConverter.GetBytes(id).Concat(BitConverter.GetBytes(addr)).ToArray();
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

        public void Init(params object[] args)
        {
            SetAuthID((short)args[0], (int)args[1]);
            //初始化AuthID
        }

        public bool IsOnline(string qq)
        {
            throw new NotImplementedException();
        }

        public void OutPutLog(string message)
        {
            KumDll.OutPutLog(AuthId,message);
        }

        public void SendGroupMessage(string group, string msg)
        {
            KumDll.SendMsgEX(AuthId,RobotQQ,2,group,"",msg,0,false);
        }

        public string SendPraise(string qq)
        {
            throw new NotImplementedException();
        }

        public void SendPrivateMessage(string qq, string msg)
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

        public void SetData(AmiableEventArgs data)
        {
            RobotQQ = data.Robot.ToString();
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }
    }
}
