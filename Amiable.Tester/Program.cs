using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Amiable.Tester
{
    class Program
    {

        public delegate int Called();
        public delegate string D2(string str);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            /*            {

                            var path = @"E:\Amiable\source\Amiable.Core\bin\x86\Debug\net5.0\Amiable.Core.dll";
                            var dllptr = Kernel32.LoadLibraryA(path);

                            if (dllptr.ToInt32() == 0)
                            {
                                throw new Exception("DLL句柄为0");
                            }
                            var process = Kernel32.GetProcAddress(dllptr, "Test");
                            var tmethod = Marshal.GetDelegateForFunctionPointer(process, typeof(Called)) as Called;
                            Console.WriteLine(tmethod.Invoke());
                        }*/

            /*            {
                            var path = @"E:\Amiable\source\Amiable.Standard2.1\bin\x86\Debug\netstandard2.1\Amiable.Standard2.1.dll";
                            var dllptr = Kernel32.LoadLibraryA(path);

                            if (dllptr.ToInt32() == 0)
                            {
                                throw new Exception("DLL句柄为0");
                            }
                            var process = Kernel32.GetProcAddress(dllptr, "Export");
                            var tmethod = Marshal.GetDelegateForFunctionPointer(process, typeof(Called)) as Called;
                            Console.WriteLine(tmethod.Invoke());

                        }*/
            {
                var path = @"E:\Amiable\source\Amiable.Core\bin\x86\Debug\Amiable.Core.dll";
                var dllptr = Kernel32.LoadLibraryA(path);

                if (dllptr.ToInt32() == 0)
                {
                    throw new Exception("DLL句柄为0");
                }
                {

                    var process = Kernel32.GetProcAddress(dllptr, "XQ_Create");
                    var method = Marshal.GetDelegateForFunctionPointer(process, typeof(D2)) as D2;
                    Console.WriteLine(method.Invoke(""));

                }
                {
                    //var process = Kernel32.GetProcAddress(dllptr, "Test");
                    //var method = Marshal.GetDelegateForFunctionPointer(process, typeof(Called)) as Called;
                   // Console.WriteLine(method.Invoke());

                }

                Console.ReadKey();

            }
        }
    }


}
