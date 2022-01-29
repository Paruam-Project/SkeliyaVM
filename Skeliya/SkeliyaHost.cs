using Skeliya.Sdk.Build.Compiler;
using Skeliya.Sdk.Build.Define;
using Skeliya.Sdk.Extensions.LiteDBWrapper;
using Skeliya.Sdk.Extensions.TypeConverter;

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
            var db = FileController.CreateOrOpenDataBase("TestDS.db");

            ////*
            var sasm = new List<ByteCode.SkeliyaAssembly>();
            for (int i = 0; i <= 5000; i++)
            {
                //GC.Collect();
                sasm.Add(new ByteCode.SkeliyaAssembly
                {
                    SasmOpCode = ByteCode.SkeliyaOpCode.IL_START,
                    Parameters = new List<byte[]>() { i.ToString().GetBytes() }
                });
            }
             
             CompileAssembly.CreateSkeliyaAssembly(sasm, db);
            //*/ 
            Console.WriteLine(CompileAssembly.CreateSkeliyaAssembly(db)[5].Parameters[0].ToStrings());
        }
    }
}