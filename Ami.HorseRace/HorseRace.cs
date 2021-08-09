using Amiable.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ami.HorseRace
{
    public class HorseRace
    {
        public static AppInfo GetAppInfo()
        {
            return new AppInfo
            {
                Name = "HorseRace赛马",
                Author = "Heer Kaisair",
                Version = "1.0.0",
                Description = "冲冲冲!",
                AppId = "top.amiable.horserace"
            };
        }
    }
}
