using Skeliya.Sdk.Build.Define;
using Skeliya.Sdk.Extensions.LiteDBWrapper;
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
            File.WriteAllBytes("TestDS.bin", CompileAssembly.CreateSkeliyaAssembly(new CompileAssembly.Assemblys() { 
                skeliyaAssemblies={
                    new ByteCode.SkeliyaAssembly{
                        SasmOpCode=ByteCode.SkeliyaOpCode.IL_START, Parameters=new List<object>() { "123456xxx","",1588 }.ToArray()
                    },
                    new ByteCode.SkeliyaAssembly{
                        SasmOpCode=ByteCode.SkeliyaOpCode.IL_START, Parameters=new List<object>() { "45688444","x",1688 }.ToArray()
                    }


                } } ));
            var file = File.ReadAllBytes("TestDS.bin");
            Console.WriteLine(CompileAssembly.CreateSkeliyaAssembly(file).skeliyaAssemblies.Count.ToString()); 
        }
    }
}