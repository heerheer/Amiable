using Amiable.Adapter.XQ;
using Amiable.SDK;
using Amiable.SDK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amiable.Core
{
    public static class AmiableService
    {
        public static AppService App;

        public static List<IPluginEvent> Events = new List<IPluginEvent>();

        //会在Init后注册。
        public static void RegEvents()
        {
            //这里要让插件成功引用其他的部分。
            Example.Example.DoNothing();

            //注册事件
            //这里很有必要因为Assembly读不了...我也不知道怎么回事
            //Events.Add((IPluginEvent)Activator.CreateInstance<>()));

            //上面那个是.net core开发时候的问题...
            var ass = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var item in ass)
            {
                var types = item.GetTypes().ToList().Where(s => s != typeof(IPluginEvent) && typeof(IPluginEvent).IsAssignableFrom(s));
                types.ToList().ForEach(
                    t =>
                    {
                        Events.Add((IPluginEvent)Activator.CreateInstance(t));
                        AmiableService.App.Log($"事件注册完成{t.Name}");
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
        }

        /// <summary>
        /// 设置App信息
        /// </summary>
        public static void SetAppInfo()
        {
            App.AppInfo = new AppInfo
            {
                Name = "Amiable.Core",
                Author = "Heer Kaisair",
                Version = "1.0.0",
                Description = "Amiable例程插件",
            };
        }

        /// <summary>
        /// 对AppService的建造
        /// </summary>
        /// <param name="service"></param>
        public static void ServiceBuilder(AppService service)
        {
            //使用先驱配置
            service.UseXQConfig();
        }
    }
}
