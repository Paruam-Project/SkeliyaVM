using Skeliya.Sdk.Build.Compiler;
using Skeliya.Sdk.Build.Define;
using Skeliya.Sdk.Extensions.LiteDBWrapper;
using Skeliya.Sdk.Extensions.TypeConverter;
using System.Diagnostics;

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
            var st = new Stopwatch();
            st.Start();
            var db = FileController.CreateOrOpenDataBase("Appx-temp.pkgs");
            /*
            for(int x = 1; x <= 100000; x++)
            {
                Console.WriteLine(x);
                CompileAssembly.CreateSkeliyaAssembly(new ByteCode.SkeliyaAssembly() { SasmOpCode = ByteCode.SkeliyaOpCode.IL_START, Parameters = new List<object>() { "wdnmd" + x.ToString() } }, db);

            }
            */
            st.Stop();
            Console.WriteLine(st.ElapsedMilliseconds / 1000);
            Console.WriteLine("----------------------------");
            Console.WriteLine(CompileAssembly.CreateSkeliyaAssembly(50000,db).SasmOpCode);
        }
    }
}