using LiteDB;

namespace Skeliya.Sdk.Extensions.LiteDBWrapper
{
    /// <summary>
    /// 文件控制器
    /// </summary>
    public class FileController
    {
        public LiteDatabase DataBase { get; }

        public FileController(LiteDatabase dbp)
        {
            DataBase = dbp;
        }

        public void Write<T>(T entries)
        {
            ILiteCollection<T> liteCollection = DataBase.GetCollection<T>();
            liteCollection.Insert(entries);//重复的项不会被插入
            DataBase.Commit();
        }

        public void Write<T>(BsonValue id, T entries)
        {
            ILiteCollection<T> liteCollection = DataBase.GetCollection<T>();
            liteCollection.Insert(id, entries);//重复的项不会被插入
            DataBase.Commit();
        }

        public void WriteFile<T>(T id, string filename)
        {
            ILiteStorage<T> liteCollection = DataBase.GetStorage<T>();
            liteCollection.Upload(id, filename);//重复的项不会被插入
            DataBase.Commit();
        }

        public void WriteFile<T>(T id, string filename, MemoryStream stream)
        {
            ILiteStorage<T> liteCollection = DataBase.GetStorage<T>();
            liteCollection.Upload(id, filename, stream);
            DataBase.Commit();
        }

        public List<T> Read<T>()
        {
            ILiteCollection<T> liteCollection = DataBase.GetCollection<T>();
            return liteCollection.Query().ToList();
        }

        public T Read<T>(BsonValue id)
        {
            ILiteCollection<T> liteCollection = DataBase.GetCollection<T>();
            return liteCollection.Query().ToArray()[id.AsInt64];
        }

        public MemoryStream ReadFile<T>(T id)
        {
            MemoryStream memoryStream = new();
            ILiteStorage<T> liteCollection = DataBase.GetStorage<T>();
            liteCollection.Download(id, memoryStream);
            return memoryStream;
        }

        public void ReadFile<T>(T id, string outputPath, bool overwrite = true)
        {
            ILiteStorage<T> liteCollection = DataBase.GetStorage<T>();
            liteCollection.Download(id, outputPath, overwrite);
        }

        public void Close()
        {
            DataBase.Dispose();
        }

        public static LiteDatabase CreateOrOpenDataBase(string dbPath)
        {
            return new LiteDatabase(dbPath);
        }
    }
}