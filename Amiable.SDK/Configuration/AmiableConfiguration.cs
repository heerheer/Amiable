using Amiable.SDK.EventArgs;
using Amiable.SDK.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amiable.SDK.Configuration
{
    public class AmiableConfiguration
    {
        public List<string> AllowGroups { get; set; }
        public List<string> AllowFriends { get; set; }

        public string Master { get; set; }
        public List<string> Admins { get; set; }
    }

    public class AmiableConfig
    {
        public class AllowGroups : Attribute
        {
            
        }
    }

    public class AmiableConfigService:IService
    {
        public string ServiceName => "AmiableConfig";

        public string ServiceVersion => "1.0.0";
    }
    
    
    public  interface IService
    {
        string ServiceName { get; } 
        string ServiceVersion { get; }
    }

    public static class AmiableConfigurationExtension
    {
        public static void UseAmiableConfiguration(this AppService appService)
        {
            appService.Services.Add(new AmiableConfigService());
            appService.EventFilters.Add(new AmiableConfigurationEventFilter());
        }

    }

    public class AmiableConfigurationEventFilter : IEventFilter
    {
        public bool FilterResult(IPluginEvent pluginEvent, AmiableEventArgs eventArgs)
        {
            if (Attribute.IsDefined(pluginEvent.GetType(), typeof(AmiableConfig.AllowGroups)))
            {
                //群授权
                
            }

            return true;
        }


    }
}
