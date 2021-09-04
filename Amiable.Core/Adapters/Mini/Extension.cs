using Amiable.Core.Adapters.Ono;
using Amiable.SDK;
using Amiable.SDK.DefaultComponent;

namespace Amiable.Core.Adapters.Mini
{
    public static class Extension
    {
        /// <summary>
        /// 使用MiniSDK的相关转换器与API包装器。
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static AppService AddMiniConfig(this AppService service)
        {
            service.AddAppInfoConverter<MiniAppInfoConverter>("Mini");
            service.ApiWrappers.Add("Mini", new MiniApiWrapper());
            service.CodeProviders.Add("Mini", new IrCodeProvider());
            return service;
        }
    }
}
