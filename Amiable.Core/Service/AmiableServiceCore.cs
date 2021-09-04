using Amiable.SDK;
using Amiable.SDK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amiable.SDK.Enum;
using System.Reflection;
using Amiable.Core.Service;

namespace Amiable.Core
{
    /*部分不会需要改动的地方*/
    public static partial class AmiableService
    {
        public static string ApiKey;

        public static AppService App;

        public static List<IPluginEvent> Events = new List<IPluginEvent>();

        /// <summary>
        /// 提供了直接创建IPluginEvent的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void AddPluginEvent<T>() where T : IPluginEvent
        {
            Events.Add((IPluginEvent)Activator.CreateInstance(typeof(T)));
        }

        static AmiableService()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //初始化
            App = new AppService();
            SetAppInfo();
            ServiceBuilder(App);
            RegEvents();

            //唤起AmiableLoaded事件
            EventCore.InvokeEvents(AmiableEventType.AmiableLoaded, new());
            AmiableService.App.Log("[AppDomain]", AppDomain.CurrentDomain.FriendlyName);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            AmiableService.App.Log("[AppDomainError]", e.ExceptionObject.ToString());

        }
    }
}