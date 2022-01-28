
using Skeliya.Sdk.Build.Compiler;
using static Skeliya.Sdk.Build.Define.ByteCode;

namespace Skeliya.Sdk.Extensions.TypeConverter
{ 
    public class BaseType
    {
        public static byte[] Serialize(SkeliyaAssembly ClassValue)
        {
            ByteCollection byteCollection = new();
            byteCollection.Write(((short)ClassValue.SasmOpCode).GetBytes());
            byteCollection.Write(((short)ClassValue.Parameters.Count).GetBytes());
            foreach (byte[] param in ClassValue.Parameters)
            {
                byteCollection.Write(param.Length.GetBytes());
            }
            foreach (byte[] param in ClassValue.Parameters)
            {
                byteCollection.Write(param);
            }
            return CompileAssembly.CompressBytes(byteCollection.GetBytes());
        }
        public static SkeliyaAssembly Deserialize(byte[] ClassValue)
        {
            SkeliyaAssembly skeliyaAssembly = new();
            ByteCollection byteCollection = new(CompileAssembly.DecompressBytes(ClassValue));
            skeliyaAssembly.SasmOpCode = (SkeliyaOpCode)byteCollection.Read(sizeof(short)).ToShort();
            short paramsLen = byteCollection.Read(sizeof(short)).ToShort();
            List<int> paramsLenList=new();
            for (short i = 1;i <= paramsLen; i++)
            {
                paramsLenList.Add(byteCollection.Read(sizeof(int)).ToInteger());
            }
            for (short i = 1; i <= paramsLen; i++)
            {
                skeliyaAssembly.Parameters.Add(byteCollection.Read(sizeof(int)));
            }
            return skeliyaAssembly;
        }
    } 
}