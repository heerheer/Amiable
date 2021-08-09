using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amiable.SDK.Enum
{
    public enum EventHandleResult
    {
        /// <summary>
        /// 忽略
        /// </summary>
        NEGLECT=0,
        /// <summary>
        /// 继续
        /// </summary>
        CONTINUE =1,
        /// <summary>
        /// 拦截
        /// </summary>
        INTERCEPT=2,

        /// <summary>
        /// 同意
        /// </summary>
        AGREE =10,
        /// <summary>
        /// 拒绝
        /// </summary>
        REFUSE =20

    }
}
