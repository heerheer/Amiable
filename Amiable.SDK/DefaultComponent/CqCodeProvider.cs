using Amiable.SDK.Interface;

namespace Amiable.SDK.DefaultComponent
{
    public class CqCodeProvider : CodeProvider
    {
        public override string At(string target)
        {
            return $"[CQ:at,qq={target}]";
        }

        public override string Image(string path)
        {
            return $"[CQ:image,file=file:///{path}]";
        }
    }
}