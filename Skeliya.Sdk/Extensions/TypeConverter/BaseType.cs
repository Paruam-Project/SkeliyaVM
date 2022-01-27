using System.Text.Json;

namespace Skeliya.Sdk.Extensions.TypeConverter
{
    public class BaseType<T>
    {
        public static readonly JsonSerializerOptions jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true};
        public static byte[] Serialize(T ClassValue)
        {
            return JsonSerializer.SerializeToUtf8Bytes(ClassValue, jsonSerializerOptions);
        }
        public static T Deserialize(byte[] ClassValue)
        {
           Utf8JsonReader utf8Reader = new(ClassValue);
#pragma warning disable CS8603 // 可能返回 null 引用。
            return JsonSerializer.Deserialize<T>(ref utf8Reader, jsonSerializerOptions);
#pragma warning restore CS8603 
        }
         
    }
}
