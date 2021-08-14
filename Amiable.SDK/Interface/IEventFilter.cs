using Amiable.SDK.EventArgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amiable.SDK.Interface
{
    public interface IEventFilter
    {
        bool FilterResult(IPluginEvent pluginEvent,AmiableEventArgs eventArgs);
    }
}
