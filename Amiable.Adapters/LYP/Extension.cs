using Amiable.Adapter.MQ;
using Amiable.SDK;

namespace Amiable.Adapters.LYP
{
    public static class Extension
    {
        /// <summary>
        /// 使用MQSDK的相关转换器与API包装器。
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static AppService AddLypConfig(this AppService service)
        {
            service.AddAppInfoConverter<LypAppInfoConverter>("Lyp");
            service.ApiWrappers.Add("Lyp",new LypApiWrapper());
            return service;
        }
    }
}
