using Skeliya.Sdk.Build.Define;
using Skeliya.Sdk.Extensions.LiteDBWrapper;
using Skeliya.Sdk.Extensions.TypeConverter;
using System.IO.Compression;
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


        //压缩字节
        //1.创建压缩的数据流 
        //2.设定compressStream为存放被压缩的文件流,并设定为压缩模式
        //3.将需要压缩的字节写到被压缩的文件流
        public static byte[] CompressBytes(byte[] bytes )
        {
            using MemoryStream compressStream = new();
            using GZipStream zipStream = new(compressStream, CompressionMode.Compress);
            zipStream.Write(bytes, 0, bytes.Length);
            zipStream.Flush();
            zipStream.Dispose();
            return compressStream.GetBuffer();
        }
        //解压缩字节
        //1.创建被压缩的数据流
        //2.创建zipStream对象，并传入解压的文件流
        //3.创建目标流
        //4.zipStream拷贝到目标流
        //5.返回目标流输出字节
        public static byte[] DecompressBytes(byte[] bytes )
        {
            using MemoryStream compressStream = new(bytes);
            using GZipStream zipStream = new(compressStream, CompressionMode.Decompress);
            using MemoryStream resultStream = new();
            compressStream.Flush();
            zipStream.CopyTo(resultStream);
            zipStream.Flush();
            zipStream.Dispose();
            compressStream.Dispose();
            return resultStream.GetBuffer();

        }
    }
}
