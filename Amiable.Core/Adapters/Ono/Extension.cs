using Amiable.SDK;
using Amiable.SDK.DefaultComponent;

namespace Amiable.Core.Adapters.Ono
{
    public static class Extension
    {
        /// <summary>
        /// 使用先驱SDK的相关转换器与API包装器。
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static AppService AddOnoConfig(this AppService service)
        {
            service.AddAppInfoConverter<OnoAppInfoConverter>("Ono");
            service.ApiWrappers.Add("Ono", new OnoApiWrapper());
            service.CodeProviders.Add("Ono", new IrCodeProvider());
            return service;
        }
    }
}
