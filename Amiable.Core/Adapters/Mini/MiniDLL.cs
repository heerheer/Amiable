using System;
using System.Runtime.InteropServices;

namespace Amiable.Core.Adapters.Mini
{
    internal class MiniDLL
    {
        static MiniDLL()
        {
        }

        private const string DLLName = "MingQQAPI.DLL";


        [DllImport(DLLName, CharSet = CharSet.Ansi)]
        public static extern void Api_SendMsg(string RobotQQ, int MessageType, string Group, string QQ, string Message);

        [DllImport(DLLName, CharSet = CharSet.Ansi)]
        public static extern void Api_OutPutLog(string content);


    }
}