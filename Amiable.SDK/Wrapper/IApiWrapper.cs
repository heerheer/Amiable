using Amiable.SDK.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amiable.SDK.Wrapper
{
    /// <summary>
    /// ApiWrapper接口
    /// 目标是单Q
    /// 多Q请自行在Event后根据Groups来为e.ApiWrapper赋予特定的ApiWrapper
    /// </summary>
    public interface IApiWrapper:ICloneable
    {
        /// <summary>
        /// 传入AppName来获取插件目录
        /// </summary>
        /// <param name="AppName"></param>
        /// <returns></returns>
        public string GetAppDirectory(string AppName);
        /// <summary>
        /// ApiWrapper初始化方法，会在Create事件之前唤起
        /// </summary>
        /// <param name="args"></param>
        public void Init(params object[] args);
        
        /// <summary>
        /// 将rawData传递进API实现操作
        /// </summary>
        /// <param name="data"></param>
        public void SetData(AmiableEventArgs data);

        /// <summary>
        /// 向指定群发送消息
        /// </summary>
        /// <param name="group"></param>
        /// <param name="msg"></param>
        public void SendGroupMessage(string group, string msg);

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="msg"></param>
        public void SendPrivateMessage(string qq, string msg);

        public string GetGroupAdmin(string group);

        /// <summary>
        /// 取QQ昵称
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public string GetNick(string qq);

        /// <summary>
        /// 取好友备注姓名
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public string GetFriendsRemark(string qq);


        /// <summary>
        /// 取指定的群名称
        /// </summary>
        /// <param name="Group"></param>
        /// <returns></returns>
        public string GetGroupName(string group);


        /// <summary>
        /// 检查指定QQ是否在线
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public bool IsOnline(string qq);

        /// <summary>
        /// 取机器人账号在线信息
        /// </summary>
        /// <returns></returns>
        public string GetRobotOnlineInfo();

        /// <summary>
        /// 通过图片GUID获取图片下载链接
        /// </summary>
        /// <param name="ImageType"></param>
        /// <param name="Group"></param>
        /// <param name="ImageGUID"></param>
        /// <returns></returns>
        public string GetPicLink(int imageType, string group, string imageGUID);

        /// <summary>
        /// 撤回群消息
        /// </summary>
        /// <param name="Group"></param>
        /// <param name="MessageNumber"></param>
        /// <param name="MessageID"></param>
        /// <returns></returns>
        public string WithdrawGroupMessage(string group, string messageNumber, string messageId);

        /// <summary>
        /// 输出日志 (在框架中显示)
        /// </summary>
        /// <param name="Message"></param>
        public void OutPutLog(string message);

        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public string SendPraise( string qq);

        /// <summary>
        /// 置群请求
        /// </summary>
        /// <param name="RequestType"></param>
        /// <param name="QQ"></param>
        /// <param name="Group"></param>
        /// <param name="Seq"></param>
        /// <param name="MessageType"></param>
        /// <param name="Message"></param>
        public void HandleGroupEvent(int requestType, string QQ, string group, string Seq, int messageType, string message);

        /// <summary>
        /// 通过语音GUID获取语音文件下载连接
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public string GetVoiLink(string message);

        /// <summary>
        /// 群签到
        /// </summary>
        /// <param name="Group"></param>
        /// <param name="Address"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public bool SignIn(string group, string address, string message);
    }
}
