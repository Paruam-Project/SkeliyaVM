using Skeliya.Sdk.Build.Define;
using Skeliya.Sdk.Extensions.TypeConverter;
using System.IO.Compression;
using static Skeliya.Sdk.Build.Define.ByteCode;

namespace Skeliya.Sdk.Build.Compiler
{
    public class CompileAssembly
    {
        public static void CreateSkeliyaAssembly(List<SkeliyaAssembly> skeliyaAssemblies,string outputPath)
        {
            FileCollection fileCollection = new(outputPath);
            fileCollection.Write(skeliyaAssemblies.Count.GetBytes()); //int程序集指令数量
            foreach (SkeliyaAssembly skeliyaAssembly in skeliyaAssemblies)
            {
                fileCollection.Write(BaseType.Serialize(skeliyaAssembly).Length.GetBytes());//int每个程序集指令大小
                fileCollection.Write(BaseType.Serialize(skeliyaAssembly));
            }

        }
        public static List<SkeliyaAssembly> CreateSkeliyaAssembly(string outputPath)
        {
            FileCollection fileCollection = new(outputPath);
            List<SkeliyaAssembly> skeliyaAssemblyResult = new();
            int counts = fileCollection.Read(sizeof(int)).ToInteger();
            for (int i = 1; i <= counts; i++)
            {
                int skeliyaAssemblyCurrentLength = fileCollection.Read(sizeof(int)).ToInteger();
                byte[] skeliyaAssemblyCurrentBytes= fileCollection.Read(skeliyaAssemblyCurrentLength);
                skeliyaAssemblyResult.Add(BaseType.Deserialize(skeliyaAssemblyCurrentBytes));
            }
            return skeliyaAssemblyResult;
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
