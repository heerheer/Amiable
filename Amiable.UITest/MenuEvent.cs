using Amiable.SDK.Enum;
using Amiable.SDK.EventArgs;
using Amiable.SDK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amiable.UITest
{
    public class MenuEvent : IPluginEvent
    {


        public AmiableEventType EventType => AmiableEventType.PluginMenu;

        [STAThread]
        public void Process(AmiableEventArgs e)
        {
            MainWindow.Instance.Activate();
        }
    }
}
