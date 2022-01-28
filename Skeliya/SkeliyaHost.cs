using Skeliya.Sdk.Build.Compiler;
using Skeliya.Sdk.Build.Define;

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
        {   /*
            var sasm = new List<ByteCode.SkeliyaAssembly>();
            for (int i = 0; i <= 50000; i++)
            {
                //GC.Collect();
                sasm.Add(new ByteCode.SkeliyaAssembly
                {
                    SasmOpCode = ByteCode.SkeliyaOpCode.IL_START,
                    Parameters = new List<byte[]>() { new byte[] { 0 } }
                });
            }
             
             CompileAssembly.CreateSkeliyaAssembly(sasm, "TestDS.bin");
            */ 
            Console.WriteLine(CompileAssembly.CreateSkeliyaAssembly("TestDS.bin")[0].SasmOpCode);
        }
    }
}