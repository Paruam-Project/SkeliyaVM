namespace Skeliya.Sdk.Extensions.TypeConverter
{
    public class ByteCollection
    {
        public MemoryStream MemoryStreamProvider { get; }
        public ByteCollection()
        {
            MemoryStreamProvider=new();
        }
        public ByteCollection(byte[] bytes)
        {
            MemoryStreamProvider = new(bytes);
        }
        public byte[] Read(int len,int offest=0)
        {
            byte[] bytes = new byte[len];
            MemoryStreamProvider.Read(bytes,offest, bytes.Length);
            return bytes;
        }
        public void Write(byte[] bytes, int offest = 0)
        {
            MemoryStreamProvider.Write(bytes, offest, bytes.Length);
            MemoryStreamProvider.Flush();
        }
        public byte[] GetBytes()
        {
            return MemoryStreamProvider.GetBuffer();
        }

    }
}
