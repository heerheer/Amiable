using System;
using System.Runtime.InteropServices;

namespace Amiable.Tester
{
    class Program
    {

        public delegate int Called();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var path = @"E:\Amiable\source\Amiable.Core\bin\x86\Debug\net5.0\Amiable.Core.dll";
            var dllptr = Kernel32.LoadLibraryA(path);

            if (dllptr.ToInt32() == 0)
            {
                throw new Exception("DLL句柄为0");
            }

            var process = Kernel32.GetProcAddress(dllptr, "Test");
            var method = Marshal.GetDelegateForFunctionPointer(process, typeof(Called)) as Called;
            var  result = method.Invoke();
            Console.WriteLine(result);
        }
    }


}
