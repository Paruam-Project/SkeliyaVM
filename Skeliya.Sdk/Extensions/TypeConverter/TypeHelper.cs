using System.IO.Compression;
using System.Text;

namespace Skeliya.Sdk.Extensions.TypeConverter
{
    /// <summary>
    /// 类型转换工具类
    /// </summary>
    public static class TypeHelper
    {
        public static string ToStrings(this byte[] obj, string encodingStr = "UTF-8")
        {
            return Encoding.GetEncoding(encodingStr).GetString(obj);
        }

        public static long ToLong(this byte[] obj)
        {
            return BitConverter.ToInt64(obj, 0);
        }

        public static int ToInteger(this byte[] obj)
        {
            return BitConverter.ToInt32(obj, 0);
        }

        public static short ToShort(this byte[] obj)
        {
            return BitConverter.ToInt16(obj, 0);
        }

        public static ulong ToULong(this byte[] obj)
        {
            return BitConverter.ToUInt64(obj, 0);
        }

        public static uint ToUInteger(this byte[] obj)
        {
            return BitConverter.ToUInt32(obj, 0);
        }

        public static ushort ToUShort(this byte[] obj)
        {
            return BitConverter.ToUInt16(obj, 0);
        }

        public static float ToSingle(this byte[] obj)
        {
            return BitConverter.ToSingle(obj, 0);
        }

        public static double ToDouble(this byte[] obj)
        {
            return BitConverter.ToDouble(obj, 0);
        }

        public static char ToChar(this byte[] obj)
        {
            return BitConverter.ToChar(obj, 0);
        }

        public static bool ToBoolean(this byte[] obj)
        {
            return BitConverter.ToBoolean(obj, 0);
        }

        public static byte[] GetBytes(this bool value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(this char value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(this double value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(this short value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(this int value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(this long value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(this float value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(this ushort value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(this uint value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(this ulong value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(this string value, string encodingStr = "UTF-8")
        {
            return Encoding.GetEncoding(encodingStr).GetBytes(value);
        }

        //压缩字节
        //1.创建压缩的数据流
        //2.设定compressStream为存放被压缩的文件流,并设定为压缩模式
        //3.将需要压缩的字节写到被压缩的文件流
        public static byte[] CompressBytes(byte[] bytes)
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
        public static byte[] DecompressBytes(byte[] bytes)
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