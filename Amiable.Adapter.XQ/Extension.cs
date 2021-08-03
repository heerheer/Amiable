using Amiable.SDK;
using Amiable.SDK.DefaultComponent;

namespace Amiable.Adapter.XQ
{
    public static class Extension
    {
        /// <summary>
        /// 使用先驱SDK的相关转换器与API包装器。
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static AppService UseXQConfig(this AppService service)
        {
            service.SetAppInfoConverter<XQAppInfoConverter>();
            service.DefaultApiWrapper = new XQApiWrapper();
            service.SetEventConverter<DefaultEventConverter>();
            return service;
        }
    }
}
