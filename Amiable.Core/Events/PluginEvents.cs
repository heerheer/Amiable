using Amiable.SDK.Enum;
using Amiable.SDK.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amiable.Core
{
    public static partial class Export
    {


        /// <summary>
        /// 触发插件被加载事件
        /// </summary>
        /// <param name="eventArgs"></param>
        public static void Event_PluginLoad(AmiableEventArgs eventArgs)
        {
            AmiableEventType amiableEventType = AmiableEventType.PluginLoaded;

            InvokeEvents(amiableEventType, eventArgs);
        }

        /// <summary>
        /// 触发插件被启用事件 建议在这里写插件初始化代码
        /// </summary>
        /// <param name="eventArgs"></param>
        public static void Event_PluginEnable(AmiableEventArgs eventArgs)
        {
            AmiableEventType amiableEventType = AmiableEventType.PluginEnable;

            InvokeEvents(amiableEventType, eventArgs);
        }
    }
}
