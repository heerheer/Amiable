
using Amiable.Adapter.Kum;
using Amiable.Adapter.MQ;
using Amiable.SDK;
using Amiable.SDK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Amiable.Adapters.Kum;
using Amiable.Adapters.LYP;
using Amiable.Adapters.MQ;
using Amiable.Adapters.Xlz;
using Amiable.Adapters.XQ;

namespace Amiable.Core
{
    public static partial class AmiableService
    {
        /// <summary>
        /// 设置App信息
        /// </summary>
        public static void SetAppInfo()
        {
            App.AppInfo = new AppInfo
            {
                Name = "Amiable.Example",
                Author = "Heer Kaisair",
                Version = "1.0.0",
                Description = "样例",
                AppId = "top.amiable.example"
            };
        }

        /// <summary>
        /// 在这里注册事件
        /// </summary>
        private static void RegEvents()
        {
            AddPluginEvent<Example.AmiableTest>();
            AddPluginEvent<UITest.MenuEvent>();

            //AddPluginEvent<IPluginEvent类型>();

        }



        /// <summary>
        /// 对AppService的建造
        /// </summary>
        /// <param name="service"></param>
        public static void ServiceBuilder(AppService service)
        {
            //添加对这些框架的API包装器
            service.AddMQConfig().AddKumConfig().AddXQConfig().AddLypConfig().AddXlzConfig();
        }
    }
}