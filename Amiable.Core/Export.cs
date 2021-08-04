#define Platform_XQ

using Amiable.SDK.Enum;
using Amiable.SDK.EventArgs;
using Amiable.SDK.Wrapper;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Amiable.Core
{
    public static class Export
    {

#if Platform_XQ

        [DllExport(CallingConvention.StdCall)]
        public static int Test()
        {
            File.AppendAllText("a.txt", "OK");
            return 233;
        }

        [DllExport(CallingConvention.StdCall)]
        public static void XQ_AuthId(short id, int IMAddr) => AuthCode(id, IMAddr);

        [DllExport(CallingConvention.StdCall)]
        public static void XQ_AutoId(short id, int IMAddr) => AuthCode(id, IMAddr);

        public static void AuthCode(short id, int IMAddr)
        {
            PreInitEvent(id, IMAddr);
        }

        [DllExport(CallingConvention.StdCall)]
        public static string XQ_Create(string frameworkversion) => InitEvent();

        [DllExport(CallingConvention.StdCall)]
        public static int
    XQ_Event(string robotQQ, int eventType, int extraType, string from, string fromQQ, string targetQQ, string content, string index, string msgid, string udpmsg, string unix, int p)
            => PluginEvent(
                robotQQ, eventType, extraType, from, fromQQ, targetQQ, content, index, msgid, udpmsg, unix, p);

#endif
        /// <summary>
        /// 预加载事件
        /// </summary>
        /// <param name="args"></param>
        private static void PreInitEvent(params object[] args)
        {
            ///初始化API包装器
            AmiableService.App.DefaultApiWrapper.Init(args);
            File.WriteAllLines("log.txt", new[] { "PreInit" });
        }

        /// <summary>
        /// 创建插件事件(需要返回JSON时)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static string InitEvent(params object[] args)
        {
            AmiableService.RegEvents();

            return AmiableService.App.GetAppInfoSring();
        }

        /// <summary>
        /// 插件创建完成
        /// </summary>
        /// <param name="args"></param>
        private static void AfterInitEvent(params object[] args)
        {
            //TODO
        }

        private static int PluginEvent(string robotQQ, int eventType, int extraType, string from, string fromQQ, string targetQQ, string content, string index, string msgid, string udpmsg, string unix, int p)
        {
            //获取Amiable支持的事件类型
            AmiableEventType a_eventType = AmiableService.App.EventConverter.Convert(eventType, extraType);
            //获取原始数据
            var raw = new EventRawData(robotQQ, eventType, extraType, from, fromQQ, targetQQ, content, index, msgid, udpmsg, unix, p);
            //克隆ApiWrapper
            IApiWrapper apiWrapper = AmiableService.App.DefaultApiWrapper.Clone() as IApiWrapper;

            //ApiWrapper设置数据,若没实现会没有任何效果。
            apiWrapper.SetData(raw);
            //创建EventArgs
            AmiableEventArgs e = new AmiableEventArgs
            {
                EventType = AmiableService.App.EventConverter.GetOnebotEventType(eventType),
                Robot = long.Parse(robotQQ),
                Timestamp = DateTime.Now.Ticks,
                ApiWrapper = apiWrapper,
                rawData = raw
            };

            //TODO 返回值

            //执行所有注册过的事件。
            AmiableService.Events.FindAll(x => x.EventType == a_eventType).ForEach(x => x.Process(e));

            return 0;
        }
    }
}