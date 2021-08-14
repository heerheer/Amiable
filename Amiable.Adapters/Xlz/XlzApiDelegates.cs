using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Amiable.Adapters.Xlz
{
    public class XlzApiDelegates
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr SendPivateMsg(string pkey, long ThisQQ, long SenderQQ, [MarshalAs(UnmanagedType.LPStr)] string MessageContent, ref long MessageRandom, ref uint MessageReq);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr OutputLog(string pkey, [MarshalAs(UnmanagedType.LPStr)] string message, int text_color, int background_color);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr SendGroupMsg(string pkey, long thisQQ, long groupQQ, [MarshalAs(UnmanagedType.LPStr)] string msgcontent, bool anonymous);
    }
}