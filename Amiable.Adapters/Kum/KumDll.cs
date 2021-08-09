using System;
using System.Runtime.InteropServices;

namespace Amiable.Adapter.Kum
{
    internal class KumDll
    {

        private const string DLLName = "kumapi.dll";

        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "fsqxx")]
        public static extern IntPtr SendGroupMessage(string group, string content);

        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "fshyxx")]
        public static extern IntPtr SendPrivateMessage(string group, string content);

        
        [DllImport(DLLName, CharSet = CharSet.Ansi, EntryPoint = "tjrz")]
        public static extern IntPtr OutPutLog(string content, int color);

    }
}