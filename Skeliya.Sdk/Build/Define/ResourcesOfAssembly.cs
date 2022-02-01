using LiteDB;
using Skeliya.Sdk.Extensions.LiteDBWrapper;

namespace Skeliya.Sdk.Build.Define
{
    public class ResourcesOfAssembly
    {
        public static T GetResources<T>(BsonValue id, LiteDatabase outputdb)
        {
            var db = new FileController(outputdb);
            return db.Read<T>(id);
        }
        public static List<T> GetResources<T>(LiteDatabase outputdb)
        {
            var db = new FileController(outputdb);
            return db.Read<T>();
        }
        public static byte[] GetResourcesFile(string namePath,LiteDatabase outputdb)
        {
            var db = new FileController(outputdb);
            return db.ReadFile(namePath).GetBuffer();
        }
        public static void AddResources<T>(BsonValue id,T Value, LiteDatabase outputdb)
        {
            var db = new FileController(outputdb);
            db.Write(id,Value);
        }
        public static void AddResources<T>(T Value, LiteDatabase outputdb)
        {
            var db = new FileController(outputdb);
            db.Write(Value);
        }
        public static void AddResourcesFile(string namePath, LiteDatabase outputdb)
        {
            var db = new FileController(outputdb);
            db.WriteFile(namePath, namePath);
        }
        public static void AddResourcesFile(string namePath, byte[] bytes, LiteDatabase outputdb)
        {
            var db = new FileController(outputdb);
            db.WriteFile(namePath, namePath, new MemoryStream(bytes));
        }
    }
}
