﻿using Ami.Draw_A_Stick;
using Ami.ReplyBot;
using Amiable.Adapter.Kum;
using Amiable.Adapter.MQ;
using Amiable.SDK;
using Amiable.SDK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

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
                Name = "Amiable.Core",
                Author = "Heer Kaisair",
                Version = "1.0.0",
                Description = "样例",
                AppId = "top.amiable.core"
            };

            App.AppInfo = ReplyBot.GetAppInfo();

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
