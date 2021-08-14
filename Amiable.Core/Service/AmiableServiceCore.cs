using Amiable.SDK;
using Amiable.SDK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amiable.SDK.Enum;

namespace Amiable.Core
{
    /*部分不会需要改动的地方*/
    public static partial class AmiableService
    {
        public static string ApiKey;

        public static AppService App;

        public static List<IPluginEvent> Events = new List<IPluginEvent>();

        //会在Init后注册。
        public static void RegEvents()
        {
            //注册事件
            //这里很有必要因为Assembly读不了...我也不知道怎么回事
            //Events.Add((IPluginEvent)Activator.CreateInstance<>()));

            //上面那个是.net core开发时候的问题...
            var ass = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var item in ass)
            {
                var types = item.GetTypes().ToList()
                    .Where(s => s != typeof(IPluginEvent) && typeof(IPluginEvent).IsAssignableFrom(s));
                types.ToList().ForEach(
                    t =>
                    {
                        if (!Events.Exists(x => x.GetType() == t))
                        {
                            Events.Add((IPluginEvent)Activator.CreateInstance(t));
                            AmiableService.App.Log($"[注册事件]实例类型:{t.Name}");
                        }
                    }
                );
            }
        }

        static AmiableService()
        {
            //初始化
            App = new AppService();
            SetAppInfo();
            ServiceBuilder(App);
            RegEvents(); //注册所有事件

            //唤起AmiableLoaded事件
            Export.InvokeEvents(AmiableEventType.AmiableLoaded, null);
            AmiableService.App.Log("[AppDomain]", AppDomain.CurrentDomain.FriendlyName);
        }
    }
}