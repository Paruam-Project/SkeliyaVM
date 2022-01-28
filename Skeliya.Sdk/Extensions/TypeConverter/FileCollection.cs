namespace Skeliya.Sdk.Extensions.TypeConverter
{
    public class FileCollection
    {
        public FileStream FileStreamProvider { get; }

        public FileCollection(string filePath, FileMode fileMode = FileMode.OpenOrCreate, FileAccess fileAccess = FileAccess.ReadWrite,FileShare fileShare=FileShare.ReadWrite)
        {
            FileStreamProvider = new(filePath, fileMode, fileAccess, fileShare);
        }

        public byte[] Read(int len, int offest = 0)
        {
            byte[] bytes = new byte[len];
            FileStreamProvider.Read(bytes, offest, bytes.Length);
            return bytes;
        }

        public void Write(byte[] bytes, int offest = 0)
        {
            FileStreamProvider.Write(bytes, offest, bytes.Length);
            FileStreamProvider.Flush();
        }
        public long GetLength()
        {
            return FileStreamProvider.Length;
        }
    }
}