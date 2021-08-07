using Amiable.SDK;
using Amiable.SDK.DefaultComponent;

namespace Amiable.Adapter.Kum
{
    public static class Extension
    {
        /// <summary>
        /// 使用先驱SDK的相关转换器与API包装器。
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static AppService UseKumConfig(this AppService service)
        {
            service.SetAppInfoConverter<KumAppInfoConverter>();
            service.DefaultApiWrapper = new KumApiWrapper();
            return service;
        }
    }
}
