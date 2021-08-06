using Amiable.SDK;
using Amiable.SDK.DefaultComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amiable.Adapter.MQ
{
    public static class Extension
    {
        /// <summary>
        /// 使用先驱SDK的相关转换器与API包装器。
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static AppService UseMQConfig(this AppService service)
        {
            service.SetAppInfoConverter<MQAppInfoConverter>();
            service.SetEventConverter<DefaultEventConverter>();
            service.DefaultApiWrapper = new MQApiWrapper();
            return service;
        }
    }
}
