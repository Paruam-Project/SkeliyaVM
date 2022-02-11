using Skeliya.Core.Runtime.Service;
using Skeliya.Sdk.Build.Compiler;

namespace Skeliya
{
    /// <summary>
    /// 主运行类
    /// </summary>
    public class SkeliyaHost
    {
        /// <summary>
        /// 应用程序入口点
        /// </summary>
        public static void Main()
        {
            //该过程会自动在VMCore内完成，将对应指令解析为VMRuntime
            //var txt = VMRuntime.SystemCallback("VMServicesDescriptorTable", "FileReadAllText", new string[] { "main.bytecode" });
            //先读取txt
            //if(txt != null)
            //{
            //    VMRuntime.SystemCallback("VMServicesDescriptorTable", "PrintL", new string[] { (string)txt });
            //}

            //createobject
            var result = CompileObject.CreateObject("testCode_2obj.txt");
            Console.ReadKey();
        }
    }
}