using Amiable.SDK;
using Amiable.SDK.DefaultComponent;

namespace Amiable.Adapters.Xlz
{
    public static class Extension
    {
        /// <summary>
        /// 使用MQSDK的相关转换器与API包装器。
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static AppService AddXlzConfig(this AppService service)
        {
            service.AddAppInfoConverter<XlzAppInfoConverter>("Xlz");
            service.ApiWrappers.Add("Xlz",new XlzApiWrapper());
            service.CodeProviders.Add("Xlz",new XlzCodeProvider());
            return service;
        }
    }
}
