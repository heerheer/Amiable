using Amiable.SDK.Enum;
using Amiable.SDK.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amiable.SDK.Interface
{
    public interface IPluginEvent
    {
        /// <summary>
        /// Amiable内部允许触发的事件种类
        /// </summary>
        AmiableEventType EventType { get; }

        /// <summary>
        /// 业务处理逻辑实现
        /// </summary>
        /// <param name="e"></param>
        void Process(AmiableEventArgs e);
    }
}
