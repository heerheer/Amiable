﻿using Amiable.Adapter.Kum;
using Amiable.SDK;

namespace Amiable.Adapters.Kum
{
    public static class Extension
    {
        /// <summary>
        /// 使用先驱SDK的相关转换器与API包装器。
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static AppService AddKumConfig(this AppService service)
        {
            service.SetAppInfoConverter<KumAppInfoConverter>();
            service.ApiWrappers.Add("Kum",new KumApiWrapper());
            return service;
        }
    }
}
