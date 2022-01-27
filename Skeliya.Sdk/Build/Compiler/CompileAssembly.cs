using Skeliya.Sdk.Build.Define;
using Skeliya.Sdk.Extensions.TypeConverter;
using static Skeliya.Sdk.Build.Define.ByteCode;

namespace Skeliya.Sdk.Build.Compiler
{
    public class CompileAssembly
    {
        public static byte[] CreateSkeliyaAssembly(Assemblys skeliyaAssemblies)
        {
            return BaseType<Assemblys>.Serialize(skeliyaAssemblies);
        }
        public static Assemblys CreateSkeliyaAssembly(byte[] skeliyaAssemblies)
        {
            return BaseType<Assemblys>.Deserialize(skeliyaAssemblies);
        }
        public class Assemblys
        {
            public List<SkeliyaAssembly> skeliyaAssemblies { get; set; } =new();
        }
    }
}
