using Amiable.Adapter.XQ;
using Amiable.SDK;

namespace Amiable.Adapters.XQ
{
    public static class Extension
    {
        /// <summary>
        /// 使用先驱SDK的相关转换器与API包装器。
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static AppService AddXQConfig(this AppService service)
        {
            service.SetAppInfoConverter<XQAppInfoConverter>();
            service.ApiWrappers.Add("XQ",new XQApiWrapper());
            return service;
        }
    }
}
