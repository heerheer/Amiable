using Amiable.Adapter.MQ;
using Amiable.SDK;

namespace Amiable.Adapters.MQ
{
    public static class Extension
    {
        /// <summary>
        /// 使用MQSDK的相关转换器与API包装器。
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static AppService AddMQConfig(this AppService service)
        {
            service.AddAppInfoConverter<MQAppInfoConverter>("MQ");
            service.ApiWrappers.Add("MQ",new MQApiWrapper());
            return service;
        }
    }
}
