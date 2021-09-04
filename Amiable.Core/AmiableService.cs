
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
using Amiable.Core.Adapters.Ono;
using Amiable.SDK.Enum;
using Amiable.SDK.EventArgs;
using System.Text;
using Amiable.Core.Adapters.Mini;

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

            AddPluginEvent<TestEvent>();

        }



        /// <summary>
        /// 对AppService的建造
        /// </summary>
        /// <param name="service"></param>
        public static void ServiceBuilder(AppService service)
        {
            //添加对这些框架的API包装器
            service.AddMQConfig().AddKumConfig().AddXQConfig().AddLypConfig().AddXlzConfig().AddOnoConfig().AddMiniConfig();
        }


    }

    public class TestEvent : IPluginEvent
    {
        public AmiableEventType EventType => AmiableEventType.Group;

        public void Process(AmiableEventArgs e)
        {
            if ((e as AmiableMessageEventArgs).RawMessage == "#Amiable")
            {
                var sb = new StringBuilder();
                sb.AppendLine("Amiable测试成功!接触神经元链接稳定!");
                sb.AppendLine($"当前API:{AmiableService.ApiKey}");
                sb.AppendLine($"更多:赫尔<你知道吗>数据库正在建设中!");
                (e as AmiableMessageEventArgs).SendMessage(sb.ToString());
            }
        }
    }
}
