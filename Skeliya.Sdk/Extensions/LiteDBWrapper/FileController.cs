using LiteDB;
using LiteDB.Engine;
namespace Skeliya.Sdk.Extensions.LiteDBWrapper
{
    public class FileController<T>
    {
        public LiteDatabase DataBase { get; }
        public FileController(LiteDatabase dbp)
        {
            DataBase = dbp;
        }
        public void Write(T entries)
        {
            ILiteCollection<T> liteCollection= DataBase.GetCollection<T>();
            liteCollection.Insert(entries);//重复的项不会被插入
            DataBase.Commit();
        }
        public void WriteFile(T id, string filename, MemoryStream stream)
        {
            ILiteStorage<T> liteCollection = DataBase.GetStorage<T>();
            liteCollection.Upload(id, filename, stream);//重复的项不会被插入
            DataBase.Commit();
        }
        public List<T> Read()
        {
            ILiteCollection<T> liteCollection = DataBase.GetCollection<T>();
            return liteCollection.Query().ToList();
        }
        public T Read(long index)
        {
            ILiteCollection<T> liteCollection = DataBase.GetCollection<T>();
            return liteCollection.Query().ToArray()[index];
        }
        public MemoryStream ReadFile(T id)
        {
            MemoryStream memoryStream = new();
            ILiteStorage<T> liteCollection = DataBase.GetStorage<T>();
            liteCollection.Download(id, memoryStream);
            return memoryStream;
        }
        public static LiteDatabase CreateOrOpenDataBase(string dbPath)
        {
            return new LiteDatabase(dbPath);
        }
    }
}
