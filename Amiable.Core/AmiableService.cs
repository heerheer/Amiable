using Ami.ReplyBot;
using Amiable.Adapter.Kum;
using Amiable.Adapter.MQ;
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
                        if(!Events.Exists(x=>x.GetType() == t))
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

            //这里要让插件成功引用其他的项目。
            //Example.Example.DoNothing();


            //初始化
            App = new AppService();
            SetAppInfo();
            ServiceBuilder(App);
            RegEvents();//注册所有事件
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
                Description = "样例",
                AppId="top.amiable.core"
            };

            //为方便一个解决方案多个项目，特此使用其他项目来覆盖AppInfo;

            App.AppInfo = ReplyBot.GetAppInfo();

            //App.AppInfo = Draw_A_Stick.GetAppInfo();
        }

        /// <summary>
        /// 对AppService的建造
        /// </summary>
        /// <param name="service"></param>
        public static void ServiceBuilder(AppService service)
        {
           
            service.UseMQConfig();
        }
    }
}
