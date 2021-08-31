using Amiable.SDK.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amiable.Adapters.Xlz
{
    public class XlzCodeProvider : CodeProvider
    {

        public override string At(string target)
        {
            return $"[CQ:at,qq={target}]";
        }

        public override string Image(string path)
        {
            var xlzpic = @$"[picFile,path={ path}]";
            return xlzpic;
        }



    }
}
