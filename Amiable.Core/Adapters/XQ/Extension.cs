using Amiable.Adapter.Ono;
using Amiable.SDK;
using Amiable.SDK.DefaultComponent;

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
            service.AddAppInfoConverter<XQAppInfoConverter>("XQ");
            service.ApiWrappers.Add("XQ",new XQApiWrapper());
            service.CodeProviders.Add("XQ",new IrCodeProvider());
            return service;
        }
    }
}
