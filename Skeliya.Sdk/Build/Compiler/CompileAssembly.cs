using Skeliya.Sdk.Build.Define;
using Skeliya.Sdk.Extensions.LiteDBWrapper;
using Skeliya.Sdk.Extensions.TypeConverter;
using static Skeliya.Sdk.Build.Define.ByteCode;

namespace Skeliya.Sdk.Build.Compiler
{
    public class CompileAssembly
    {
        public static void CreateSkeliyaAssembly(SkeliyaAssembly skeliyaAssemblies,LiteDB.LiteDatabase outputDB)
        {
            var db = new FileController(outputDB);
            db.Write(skeliyaAssemblies);
            //db.Close();
        }
        public static SkeliyaAssembly CreateSkeliyaAssembly(long index, LiteDB.LiteDatabase outputDB)
        {
            var db = new FileController(outputDB);
            var result = db.Read<SkeliyaAssembly>(index);
            //db.Close();
            return result;
        }
    }
}
