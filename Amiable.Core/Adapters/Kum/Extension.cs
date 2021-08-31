using Amiable.Adapter.Kum;
using Amiable.SDK;
using Amiable.SDK.DefaultComponent;

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
            service.AddAppInfoConverter<KumAppInfoConverter>("Kum");
            service.ApiWrappers.Add("Kum",new KumApiWrapper());
            service.CodeProviders.Add("Kum",new CqCodeProvider());
            return service;
        }
    }
}
