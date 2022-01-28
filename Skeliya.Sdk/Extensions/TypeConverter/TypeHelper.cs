

using System.Text;

namespace Skeliya.Sdk.Extensions.TypeConverter
{
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
    }
}
