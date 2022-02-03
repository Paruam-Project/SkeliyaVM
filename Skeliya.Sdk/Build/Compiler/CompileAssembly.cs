using Skeliya.Sdk.Extensions.LiteDBWrapper;
using static Skeliya.Sdk.Build.Define.ByteCode;

namespace Skeliya.Sdk.Build.Compiler
{
    /// <summary>
    /// 程序集编译
    /// </summary>
    public class CompileAssembly
    {
        /// <summary>
        /// 创建程序集
        /// </summary>
        /// <param name="skeliyaAssemblies">程序集IL码</param>
        /// <param name="outputDB">数据库</param>
        public static void CreateSkeliyaAssembly(SkeliyaAssembly skeliyaAssemblies, LiteDB.LiteDatabase outputDB)
        {
            var db = new FileController(outputDB);
            db.Write(skeliyaAssemblies);
            //db.Close();
        }

        /// <summary>
        /// 解析程序集
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="outputDB">数据库</param>
        /// <returns>程序集IL码</returns>
        public static SkeliyaAssembly CreateSkeliyaAssembly(long index, LiteDB.LiteDatabase outputDB)
        {
            var db = new FileController(outputDB);
            var result = db.Read<SkeliyaAssembly>(new LiteDB.BsonValue(index));
            //db.Close();
            return result;
        }
    }
}