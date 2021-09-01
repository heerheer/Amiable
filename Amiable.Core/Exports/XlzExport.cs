using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Amiable.Adapters.Xlz;
using Amiable.Core.Service;
using Amiable.SDK.EventArgs;
using HuajiTech.UnmanagedExports;

// ReSharper disable InconsistentNaming

namespace Amiable.Core
{
    public static class XlzExport
    {
        [DllExport]
        [return: MarshalAs(UnmanagedType.LPStr)]
        // ReSharper disable once IdentifierTypo
        public static string apprun(
            [MarshalAs(UnmanagedType.LPStr)] string apidata, [MarshalAs(UnmanagedType.LPStr)] string pluginkey)
        {
            AmiableService.ApiKey = "Xlz";
            //将委托转换为IntPtr(long)
            var delegateIntptrs = new Dictionary<string, long>()
            {
                { "friendmsaddres", Xlz_Delegates.Get(Xlz_Delegates.ReceivePrivateMsgDelegate) },
                { "groupmsaddres", Xlz_Delegates.Get(Xlz_Delegates.ReceiveGroupMesgDelegate) },
                { "eventmsaddres ", Xlz_Delegates.Get(Xlz_Delegates.ReceiveEventCallBackDelegate) },
                { "useproaddres ", Xlz_Delegates.Get(Xlz_Delegates.RobotAppEnableDelegate) },
                { "unitproaddres  ", Xlz_Delegates.Get(Xlz_Delegates.AppUninstallDelegate) },
                { "banproaddres ", Xlz_Delegates.Get(Xlz_Delegates.AppDisabledDelegate) },
                { "setproaddres", Xlz_Delegates.Get(Xlz_Delegates.AppSettingDelegate) }
            };
            EventCore.PreInitEvent(pluginkey, apidata, delegateIntptrs);
            return EventCore.InitEvent(pluginkey);
        }
    }

    public class Xlz_Delegates
    {
        public static long Get(Delegate value)
        {
            return Marshal.GetFunctionPointerForDelegate(value).ToInt64();
        }

        public delegate int ReceivePrivateMsg(IntPtr intPtr);

        public delegate int ReceiveGroupMsg(IntPtr intPtr);

        public delegate int RobotAppEnable();

        public delegate int ReceiveEventCallBack(IntPtr intPtr);

        public delegate int AppSetting();

        public delegate void AppUninstall();

        public delegate void AppDisabled();

        public delegate void GetSmsVerificationCode(long fromQQ, IntPtr phone);

        public delegate void SliderRecognition(long fromQQ, IntPtr url);

        public static ReceivePrivateMsg ReceivePrivateMsgDelegate = delegate (IntPtr ptr)
        {
            var s = Marshal.PtrToStructure<Adapters.Xlz.Structs.PrivateMessageEvent>(ptr);
            AmiableService.App.DefaultApiWrapper.SetData(new AmiableEventArgs()
            {
                Robot = s.ThisQQ
            });
            MessageEvents.Event_PrivateMessage(DateTime.Now.Ticks, s.ThisQQ, "", 0,
                 s.SenderQQ, s.MessageContent, 0, s);
            return 0;
        };

        public static ReceiveGroupMsg ReceiveGroupMesgDelegate = delegate (IntPtr ptr)
        {
            var s = Marshal.PtrToStructure<Adapters.Xlz.Structs.XlzGroupMessageEvent>(ptr);
            AmiableService.App.DefaultApiWrapper.SetData(new AmiableEventArgs()
            {
                Robot = s.ThisQQ
            });
            MessageEvents.Event_GroupMessage(DateTime.Now.Ticks, s.ThisQQ, "normal", s.MessageAppID,
                s.MessageGroupQQ, s.SenderQQ, s.MessageContent, 0, s);
            return 0;
        };

        public static ReceiveEventCallBack ReceiveEventCallBackDelegate = delegate (IntPtr ptr) { return 0; };

        public static RobotAppEnable RobotAppEnableDelegate = delegate () { return 0; };
        public static AppSetting AppSettingDelegate = delegate ()
        {
            PluginEvents.Event_PluginMenu(new());
            return 0;
        };
        public static AppUninstall AppUninstallDelegate = delegate () { };
        public static AppDisabled AppDisabledDelegate = delegate () { };
        public static GetSmsVerificationCode GetSmsVerificationCodeDelegate = delegate (long fromQQ, IntPtr phone) { };
        public static SliderRecognition SliderRecognitionDelegate = delegate (long fromQQ, IntPtr url) { };
    }
}