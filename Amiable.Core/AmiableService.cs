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
    public class AmiableService
    {
        public static AppService App;

        public static List<IPluginEvent> Events;

        public static void RegEvents()
        {
            var ass = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var item in ass)
            {
                var types = item.GetTypes().ToList().Where(s => s != typeof(IPluginEvent) && typeof(IPluginEvent).IsAssignableFrom(s));
                types.ToList().ForEach(
                    t => Events.Add((IPluginEvent)Activator.CreateInstance(t)));
            }
        }

        static AmiableService()
        {
            App = new();
            SetAppInfo();
            ServiceBuilder(App);
        }

        /// <summary>
        /// 设置App信息
        /// </summary>
        public static void SetAppInfo()
        {
            App.AppInfo = new()
            {
                Name = "AmiableTestPlugin",
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
