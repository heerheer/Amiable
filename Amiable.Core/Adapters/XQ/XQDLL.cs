using System;
using System.Runtime.InteropServices;

namespace Amiable.Adapter.Ono
{
    internal class XQDLL
    {
        static XQDLL()
        {
        }

        private const string DLLName = "xqapi.dll";

        #region 获取消息 OR 设置

        /// <summary>
        /// 获取好友列表-http模式
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="QQ">机器人QQ</param>
        /// <returns>原始JSON格式信息</returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetFriendList")]
        public static extern IntPtr GetFriendList(byte[] Authid, string QQ);

        /// <summary>
        /// 获取群列表
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="QQ">机器人QQ</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetGroupList")]
        public static extern IntPtr GetGroupList(byte[] Authid, string QQ);

        /// <summary>
        /// 获取机器人在线账号列表
        /// </summary>
        /// <param name="Authid"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetOnLineList")]
        public static extern IntPtr GetOnLineList(byte[] Authid);

        /// <summary>
        /// 获取机器人账号是否在线
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="QQ">机器人QQ</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_Getbotisonline")]
        public static extern bool Getbotisonline(byte[] Authid, string QQ);

        /// <summary>
        /// 获取群员列表
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="QQ">机器人QQ</param>
        /// <param name="Group">群号</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetGroupMemberList")]
        public static extern IntPtr GetGroupMemberList(byte[] Authid, string QQ, string Group);

        /// <summary>
        /// 获取群成员名片
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="Group">群号</param>
        /// <param name="QQ">群成员QQ</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetGroupCard")]
        public static extern IntPtr GetGroupCard(byte[] Authid, string RobotQQ, string Group, string QQ);

        /// <summary>
        /// 获取群管理⚪列表
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="Group">QQ群号</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetGroupAdmin")]
        public static extern IntPtr GetGroupAdmin(byte[] Authid, string RobotQQ, string Group);

        /// <summary>
        /// 获取群通知
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="Group">群号</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetNotice")]
        public static extern IntPtr GetNotice(byte[] Authid, string RobotQQ, string Group);

        /// <summary>
        /// 获取群成员禁言状态
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="Group">群号</param>
        /// <param name="QQ">QQ</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_IsShutUp")]
        public static extern bool IsShutUp(byte[] Authid, string RobotQQ, string Group, string QQ);

        /// <summary>
        /// 是否是好友
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="QQ">QQ</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_IfFriend")]
        public static extern bool IfFriend(byte[] Authid, string RobotQQ, string QQ);

        /// <summary>
        /// 取得QQ群页面操作用参数P_skey
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetGroupPsKey")]
        public static extern IntPtr GetGroupPsKey(byte[] Authid, string RobotQQ);

        /// <summary>
        /// 取得QQ空间页面操作用参数P_skey
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetZonePsKey")]
        public static extern IntPtr GetZonePsKey(byte[] Authid, string RobotQQ);

        /// <summary>
        /// 取得机器人网页操作用的Cookies
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetCookies")]
        public static extern IntPtr GetCookies(byte[] Authid, string RobotQQ);

        /// <summary>
        /// 获取赞数量
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="QQ">QQ</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetObjVote")]
        public static extern int GetObjVote(byte[] Authid, string RobotQQ, string QQ);

        /// <summary>
        /// 取插件是否启用
        /// </summary>
        /// <param name="Authid"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_IsEnable")]
        public static extern bool IsEnable(byte[] Authid);

        /// <summary>
        /// 取所有QQ列表
        /// </summary>
        /// <param name="Authid"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetQQList")]
        public static extern IntPtr GetQQList(byte[] Authid);

        /// <summary>
        /// 取QQ昵称
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetNick")]
        public static extern IntPtr GetNick(byte[] Authid, string RobotQQ, string QQ);

        /// <summary>
        /// 取好友备注姓名
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetFriendsRemark")]
        public static extern IntPtr GetFriendsRemark(byte[] Authid, string RobotQQ, string QQ);

        /// <summary>
        /// 取短Clientkey
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetClientkey")]
        public static extern IntPtr GetClientkey(byte[] Authid, string RobotQQ);

        /// <summary>
        /// 取得机器人网页操作用的长Clientkey
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetLongClientkey")]
        public static extern IntPtr GetLongClientkey(byte[] Authid, string RobotQQ);

        /// <summary>
        /// 取得腾讯课堂页面操作用参数P_skey
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetClassRoomPsKey")]
        public static extern IntPtr GetClassRoomPsKey(byte[] Authid, string RobotQQ);

        /// <summary>
        /// 取得QQ举报页面操作用参数P_skey
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetRepPsKey")]
        public static extern IntPtr GetRepPsKey(byte[] Authid, string RobotQQ);

        /// <summary>
        /// 取得财付通页面操作用参数P_skey
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetTenPayPsKey")]
        public static extern IntPtr GetTenPayPsKey(byte[] Authid, string RobotQQ);

        /// <summary>
        /// 取bkn
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetBkn")]
        public static extern IntPtr GetBkn(byte[] Authid, string RobotQQ);

        /// <summary>
        /// 封包模式获取群号列表(最多可以取得999)
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetGroupList_B")]
        public static extern IntPtr GetGroupList_B(byte[] Authid, string RobotQQ);

        /// <summary>
        /// 封包模式取好友列表(与封包模式取群列表同源)
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetFriendList_B")]
        public static extern IntPtr GetFriendList_B(byte[] Authid, string RobotQQ);

        /// <summary>
        /// 取登录二维码base64
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetQrcode")]
        public static extern IntPtr GetQrcode(byte[] Authid, string key);

        /// <summary>
        /// 检查登录二维码状态
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_CheckQrcode")]
        public static extern int CheckQrcode(byte[] Authid, string key);

        /// <summary>
        /// 取指定的群名称
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Group"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetGroupName")]
        public static extern IntPtr GetGroupName(byte[] Authid, string RobotQQ, string Group);

        /// <summary>
        /// 取群人数上线与当前人数 换行符分隔
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Group"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetGroupMemberNum")]
        public static extern IntPtr GetGroupMemberNum(byte[] Authid, string RobotQQ, string Group);

        /// <summary>
        /// 取群等级
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Group"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetGroupLv")]
        public static extern int GetGroupLv(byte[] Authid, string RobotQQ, string Group);

        /// <summary>
        /// 取群成员列表
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Group"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetGroupMemberList_B")]
        public static extern IntPtr GetGroupMemberList_B(byte[] Authid, string RobotQQ, string Group);

        /// <summary>
        /// 封包模式取群成员列表返回重组后的json文本
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Group"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetGroupMemberList_C")]
        public static extern IntPtr GetGroupMemberList_C(byte[] Authid, string RobotQQ, string Group);

        /// <summary>
        /// 检查指定QQ是否在线
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_IsOnline")]
        public static extern bool IsOnline(byte[] Authid, string RobotQQ, string QQ);

        /// <summary>
        /// 取机器人账号在线信息
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetRInf")]
        public static extern IntPtr GetRInf(byte[] Authid, string RobotQQ);

        /// <summary>
        /// 查询指定群是否允许匿名消息
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Group"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetAnon")]
        public static extern bool GetAnon(byte[] Authid, string RobotQQ, string Group);

        /// <summary>
        /// 通过图片GUID获取图片下注链接
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="ImageType">(图片类型)2群 讨论组  1临时会话和好友</param>
        /// <param name="Group">图片所属对应的群号（可随意乱填写，只有群图片需要填写）</param>
        /// <param name="ImageGUID">(图片GUID)[IR:pic={xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}.jpg]</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetPicLink")]
        public static extern IntPtr GetPicLink(byte[] Authid, string RobotQQ, int ImageType, string Group, string ImageGUID);

        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "Api_GetVer")]
        public static extern IntPtr GetVer();

        /// <summary>
        /// 获取指定QQ个人资料的年龄
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetAge")]
        public static extern int GetAge(byte[] Authid, string RobotQQ, string QQ);

        /// <summary>
        /// 获取QQ个人资料的性别
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetGender")]
        public static extern int GetGender(byte[] Authid, string RobotQQ, string QQ);

        #endregion 获取消息 OR 设置

        #region 发送 OR 设置

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="MessageType">信息类型 : 0在线临时会话/1好友/2群/3讨论群/4群临时会话/5讨论组临时会话/7好友验证回复会话</param>
        /// <param name="Group">QQ群号(发送群信息、讨论组等时候填写，其他为0或者为空)</param>
        /// <param name="QQ">收信人QQ</param>
        /// <param name="Message">消息内容</param>
        /// <param name="BubbleID">气泡ID</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_SendMsg")]
        public static extern void SendMsg(byte[] Authid, string RobotQQ, int MessageType, string Group, string QQ, string Message, int BubbleID);

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="MessageType">上传类型（1好友、临时会话  2群、讨论组 Ps：好友临时会话用类型 1，群讨论组用类型 2；当填写错误时，图片GUID发送不会成功）</param>
        /// <param name="GroupOrQQ">上传到QQ群或者QQ（填写群号或者QQ）</param>
        /// <param name="Message">图片字节集数据</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_UpLoadPic")]
        public static extern IntPtr UpLoadPic(byte[] Authid, string RobotQQ, int MessageType, string GroupOrQQ, byte[] Message);

        /// <summary>
        /// 群禁言
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="Group">QQ群号</param>
        /// <param name="QQ">禁言对象QQ(为空则为全员禁言)(QQ机器人需要管理员权限)</param>
        /// <param name="Time">禁言时间(0:解除禁言)(单位:秒)</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_ShutUP")]
        public static extern void ShutUP(byte[] Authid, string RobotQQ, string Group, string QQ, int Time);

        /// <summary>
        /// 修改群成员昵称
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="Group">QQ群号</param>
        /// <param name="QQ">被修改人QQ</param>
        /// <param name="Card">修改的名片</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_SetGroupCard")]
        public static extern bool SetGroupCard(byte[] Authid, string RobotQQ, string Group, string QQ, string Card);

        /// <summary>
        /// 群删除成员
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="Group">群号</param>
        /// <param name="QQ">被移除人QQ</param>
        /// <param name="Allow">是否不在允许接受申请入群(true/false)</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_KickGroupMBR")]
        public static extern void KickGroupMBR(byte[] Authid, string RobotQQ, string Group, string QQ, bool Allow);

        /// <summary>
        /// 修改QQ在线状态
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="OnLineType">类型(1、我在线上 2、Q我吧 3、离开 4、忙碌 5、请勿打扰 6、隐身 7、修改昵称 8、修改个性签名 9、修改性别)</param>
        /// <param name="Message">修改内容(类型为7和8时填写修改内容  类型9时“1”为男 “2”为女      其他填“”)</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_SetRInf")]
        public static extern void SetRInf(byte[] Authid, string RobotQQ, string OnLineType, string Message);

        /// <summary>
        /// 发布群公告
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="Group">群号</param>
        /// <param name="MessageTitle">公告标题</param>
        /// <param name="Message">公告内容</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_PBGroupNotic")]
        public static extern bool PBGroupNotic(byte[] Authid, string RobotQQ, string Group, string MessageTitle, string Message);

        /// <summary>
        /// 撤回群消息
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="Group">群号</param>
        /// <param name="MessageNumber">消息序号</param>
        /// <param name="MessageID">消息ID</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_WithdrawMsg")]
        public static extern IntPtr WithdrawMsg(byte[] Authid, string RobotQQ, string Group, string MessageNumber, string MessageID);

        /// <summary>
        /// 输出日志 (在框架中显示)
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="Message">内容</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_OutPutLog")]
        public static extern void OutPutLog(byte[] Authid, string Message);

        /// <summary>
        /// 提取图片文字
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="ImageMessage">图片数据</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_OcrPic")]
        public static extern IntPtr OcrPic(byte[] Authid, string RobotQQ, byte[] ImageMessage);

        /// <summary>
        /// 主动加群
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="Group">群号</param>
        /// <param name="Message">附加理由，可留空（需回答正确问题时，请填写问题答案</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_JoinGroup")]
        public static extern void JoinGroup(byte[] Authid, string RobotQQ, string Group, string Message);

        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="QQ">QQ</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_UpVote")]
        public static extern IntPtr UpVote(byte[] Authid, string RobotQQ, string QQ);

        /// <summary>
        /// 通过列表或群临时通道点赞
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="QQ">QQ</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_UpVote_temp")]
        public static extern IntPtr UpVote_temp(byte[] Authid, string RobotQQ, string QQ);

        /// <summary>
        /// 置好友添加请求
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="QQ">申请入群 被邀请人 请求添加好友人的QQ （当请求类型为214时这里为邀请人QQ</param>
        /// <param name="MessageType">10同意 20拒绝 30忽略 40同意单项好友的请求</param>
        /// <param name="Message">拒绝入群，拒绝添加好友 附加信息</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_HandleFriendEvent")]
        public static extern void HandleFriendEvent(byte[] Authid, string RobotQQ, string QQ, int MessageType, string Message);

        /// <summary>
        /// 置群请求
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="RequestType">213请求入群  214我被邀请加入某群  215某人被邀请加入群  101某人请求添加好友</param>
        /// <param name="QQ">申请入群 被邀请人 请求添加好友人的QQ （当请求类型为214时这里为邀请人QQ）</param>
        /// <param name="Group">收到请求群号（好友添加时这里请为空）</param>
        /// <param name="Seq">需要处理事件的seq</param>
        /// <param name="MessageType">10同意 20拒绝 30忽略</param>
        /// <param name="Message">拒绝入群，拒绝添加好友 附加信息</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_HandleGroupEvent")]
        public static extern void HandleGroupEvent(byte[] Authid, string RobotQQ, int RequestType, string QQ, string Group, string Seq, int MessageType, string Message);

        /// <summary>
        /// 向框架添加一个QQ
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="Account">帐号</param>
        /// <param name="Password">密码</param>
        /// <param name="Automatic">自动登录</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_AddQQ")]
        public static extern IntPtr AddQQ(byte[] Authid, string Account, string Password, bool Automatic);

        /// <summary>
        /// 登录指定QQ
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="QQ"></param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_LoginQQ")]
        public static extern void LoginQQ(byte[] Authid, string QQ);

        /// <summary>
        /// 离线指定QQ
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="QQ"></param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_OffLineQQ")]
        public static extern void OffLineQQ(byte[] Authid, string QQ);

        /// <summary>
        /// 删除指定QQ
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="QQ"></param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_DelQQ")]
        public static extern IntPtr DelQQ(byte[] Authid, string QQ);

        /// <summary>
        /// 删除指定好友
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="QQ">被删除对象</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_DelFriend")]
        public static extern bool DelFriend(byte[] Authid, string RobotQQ, string QQ);

        /// <summary>
        /// 修改好友备注名称
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="Message">需要修改的备注姓名</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_SetFriendsRemark")]
        public static extern void SetFriendsRemark(byte[] Authid, string RobotQQ, string QQ, string Message);

        /// <summary>
        /// 邀请好友加入群
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Group">被邀请加入的群号</param>
        /// <param name="QQ"></param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_InviteGroup")]
        public static extern void InviteGroup(byte[] Authid, string RobotQQ, string Group, string QQ);

        /// <summary>
        /// 邀请群成员加入群
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Group">邀请到哪个群</param>
        /// <param name="GroupY">被邀请成员所在群</param>
        /// <param name="QQ">被邀请人的QQ</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_InviteGroupMember")]
        public static extern bool InviteGroupMember(byte[] Authid, string RobotQQ, string Group, string GroupY, string QQ);

        /// <summary>
        /// 创建群 组包模式
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_CreateDisGroup")]
        public static extern IntPtr CreateDisGroup(byte[] Authid, string RobotQQ);

        /// <summary>
        /// 创建群 群官网Http模式
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_CreateGroup")]
        public static extern IntPtr CreateGroup(byte[] Authid, string RobotQQ);

        /// <summary>
        /// 退出群
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Group">欲退出的群号</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_QuitGroup")]
        public static extern void QuitGroup(byte[] Authid, string RobotQQ, string Group);

        /// <summary>
        /// 屏蔽或接收某群消息
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Group"></param>
        /// <param name="MessageType">真 为屏蔽接收  假为接收并提醒</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_SetShieldedGroup")]
        public static extern void SetShieldedGroup(byte[] Authid, string RobotQQ, string Group, bool MessageType);

        /// <summary>
        ///  多功能删除好友 可删除陌生人或者删除为单项好友
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="MessageType">1为在对方的列表删除我 2为在我的列表删除对方</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_DelFriend_A")]
        public static extern void DelFriend_A(byte[] Authid, string RobotQQ, string QQ, int MessageType);

        /// <summary>
        /// 设置机器人被添加好友时的验证方式
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="MessageType">0 允许任何人 1 需要验证消息 2不允许任何人 3需要回答问题 4需要回答问题并由我确认</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_Setcation")]
        public static extern void Setcation(byte[] Authid, string RobotQQ, int MessageType);

        /// <summary>
        /// 设置机器人被添加好友时的问题与答案
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Problem">设置的问题</param>
        /// <param name="Answer">设置的问题答案 </param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_Setcation_problem_A")]
        public static extern void Setcation_problem_A(byte[] Authid, string RobotQQ, string Problem, string Answer);

        /// <summary>
        /// 设置机器人被添加好友时的三个可选问题
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Problem1">设置问题一</param>
        /// <param name="Problem2">设置问题二</param>
        /// <param name="Problem3">设置问题三</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_Setcation_problem_B")]
        public static extern void Setcation_problem_B(byte[] Authid, string RobotQQ, string Problem1, string Problem2, string Problem3);

        /// <summary>
        /// 主动添加好友
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="Message">验证消息</param>
        /// <param name="xxlay">(来源信息)1QQ号码查找 2昵称查找 3条件查找 5临时会话 6QQ群 10QQ空间 11拍拍网 12最近联系人 14企业查找 其他的自己测试吧 1-255</param>
        /// <returns>请求成功返回真否则返回假</returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_AddFriend")]
        public static extern bool AddFriend(byte[] Authid, string RobotQQ, string QQ, string Message, int xxlay);

        /// <summary>
        /// 发送json结构消息
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="SendType">(发送方式)1普通 2匿名（匿名需要群开启）</param>
        /// <param name="MessageType">(信息类型)0在线临时会话 1好友 2群 3讨论组 4群临时会话 5讨论组临时会话 7好友验证回复会话</param>
        /// <param name="Group">发送群信息、讨论组、群或讨论组临时会话信息时填，如发送对象为好友或信息类型是0时可空</param>
        /// <param name="QQ"></param>
        /// <param name="JsonMessage">Json结构内容</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_SendJSON")]
        public static extern void SendJSON(byte[] Authid, string RobotQQ, int SendType, int MessageType, string Group, string QQ, string JsonMessage);

        /// <summary>
        /// 发送xml结构消息
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="SendType">(发送方式)1普通 2匿名（匿名需要群开启）</param>
        /// <param name="MessageType">(信息类型)0在线临时会话 1好友 2群 3讨论组 4群临时会话 5讨论组临时会话 7好友验证回复会话</param>
        /// <param name="Group">发送群信息、讨论组、群或讨论组临时会话信息时填，如发送对象为好友或信息类型是0时可空</param>
        /// <param name="QQ"></param>
        /// <param name="XMLMessage">XML结构内容</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_SendXML")]
        public static extern void SendXML(byte[] Authid, string RobotQQ, int SendType, int MessageType, string Group, string QQ, string XMLMessage);

        /// <summary>
        ///上传silk语音文件
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="SendType">(上传类型)2、QQ群 讨论组</param>
        /// <param name="Group">需上传的群号</param>
        /// <param name="Message">语音字节集数据（AMR Silk编码）</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_UpLoadVoice")]
        public static extern IntPtr UpLoadVoice(byte[] Authid, string RobotQQ, int SendType, string Group, byte[] Message);

        /// <summary>
        /// 发送普通消息支持群匿名方式
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="MessageType"></param>
        /// <param name="Group"></param>
        /// <param name="QQ"></param>
        /// <param name="Message"></param>
        /// <param name="BubbleID"></param>
        /// <param name="Anonymous">不需要匿名请填写假 可调用Api_GetAnon函数 查看群是否开启匿名如果群没有开启匿名发送消息会失败</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_SendMsgEX")]
        public static extern IntPtr SendMsgEX(byte[] Authid, string RobotQQ, int MessageType, string Group, string QQ, string Message, int BubbleID, bool Anonymous);

        /// <summary>
        /// 通过语音GUID获取语音文件下载连接
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Message">(语音GUID)[IR:Voi={xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx}.amr]</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_GetVoiLink")]
        public static extern IntPtr GetVoiLink(byte[] Authid, string RobotQQ, string Message);

        /// <summary>
        /// 开关群匿名功能
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Group"></param>
        /// <param name="kg">真开    假关</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_SetAnon")]
        public static extern bool SetAnon(byte[] Authid, string RobotQQ, string Group, bool kg);

        /// <summary>
        /// 修改机器人自身头像
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Message">(图像数据)</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_SetHeadPic")]
        public static extern bool SetHeadPic(byte[] Authid, string RobotQQ, byte[] Message);

        /// <summary>
        /// 语音GUID转换为文本内容
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="ckdx">参考对象</param>
        /// <param name="cklx">参考类型</param>
        /// <param name="yyGUID">语音GUID</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_VoiToText")]
        public static extern IntPtr VoiToText(byte[] Authid, string RobotQQ, string ckdx, int cklx, string yyGUID);

        /// <summary>
        /// 群签到
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="Group"></param>
        /// <param name="Address">签到地名</param>
        /// <param name="Message">想发表的内容</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_SignIn")]
        public static extern bool SignIn(byte[] Authid, string RobotQQ, string Group, string Address, string Message);

        /// <summary>
        /// 向好友发送窗口抖动消息
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_ShakeWindow")]
        public static extern bool ShakeWindow(byte[] Authid, string RobotQQ, string QQ);

        /// <summary>
        /// 同步发送消息 有返回值可以用来撤回机器人自己发送的消息
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="MessageType"></param>
        /// <param name="Group"></param>
        /// <param name="QQ"></param>
        /// <param name="Message"></param>
        /// <param name="BubbleID"></param>
        /// <param name="Anonymous"></param>
        /// <param name="JSONMessage">附加JSON参数</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_SendMsgEX_V2")]
        public static extern IntPtr SendMsgEX_V2(byte[] Authid, string RobotQQ, int MessageType, string Group, string QQ, string Message, int BubbleID, bool Anonymous, string JSONMessage);

        /// <summary>
        /// 撤回群消息或者私聊消息
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="RobotQQ"></param>
        /// <param name="WithdrawType">1好友 2群聊 4群临时会话 </param>
        /// <param name="Group">非临时会话时请留空 临时会话请填群号</param>
        /// <param name="QQ">非私聊消息请留空 私聊消息请填写对方QQ号码</param>
        /// <param name="MessageNumber">需撤回消息序号</param>
        /// <param name="MessageID">需撤回消息ID</param>
        /// <param name="MessageTime">私聊消息需要群聊时3可留空</param>
        /// <returns></returns>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_WithdrawMsgEX")]
        public static extern IntPtr WithdrawMsgEX(byte[] Authid, string RobotQQ, int WithdrawType, string Group, string QQ, string MessageNumber, string MessageID, string MessageTime);

        [DllImport(DLLName, CharSet = CharSet.Ansi)]
        public static extern IntPtr Api_GetGroupList(string robotQQ);

        #endregion 发送 OR 设置

        #region Debug 函数

        /// <summary>
        /// 标记函数执行流程 debug时使用 每个函数内只需要调用一次
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="Message">标记内容</param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_DbgName")]
        public static extern void DbgName(byte[] Authid, string Message);

        /// <summary>
        /// 函数内标记附加信息 函数内可多次调用
        /// </summary>
        /// <param name="Authid"></param>
        /// <param name="Message"></param>
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "S3_Api_Mark")]
        public static extern void Mark(byte[] Authid, string Message);

        #endregion Debug 函数

        #region 指针转String

        [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory")]
        public static extern bool RtlMoveMemory(byte[] dest, IntPtr src, int Length);

        [DllImport("kernel32.dll", EntryPoint = "GetProcessHeap")]
        public static extern int GetProcessHeap();

        [DllImport("kernel32.dll", EntryPoint = "HeapFree")]
        public static extern int HeapFree1(int hheap, int dwflags, IntPtr lpmeem);

        [DllImport("kernel32.dll", EntryPoint = "lstrlenA", CharSet = CharSet.Ansi)]
        public extern static int LstrlenA(IntPtr ptr);

        #endregion 指针转String
    }
}