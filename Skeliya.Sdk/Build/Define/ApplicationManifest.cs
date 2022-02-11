namespace Skeliya.Sdk.Build.Define
{
    public class ApplicationManifest
    {
        /// <summary>
        /// 清单收集器
        /// </summary>
        public class ManifestCollection
        {
            public ManifestType Type { get; set; } = new();//程序类型
            public string FileName { get; set; } = ""; //警告，文件名必须与此处一致，否则找不到依赖项（dll文件改名无效同理）
            public string Name { get; set; } = "";//显示名称
            public string Description { get; set; } = "";//描述
            public Guid Guid { get; set; } = new();//guid标识符-警告！！
            public Version Version { get; set; } = new();//版本
            public long AssemblyAllCounts { get; set; } = 0;//程序字节码总数
            public List<string> PackageReferences { get; set; } = new();//依赖列表
            public uint MinApiSdk { get; set; } = 0;//最小sdk版本
            public uint MaxApiSdk { get; set; } = 0;//最大sdk版本
            public DateTime FileStamp { get; set; } = DateTime.Now;//时间戳
            public List<TokenOfAssembly> TokenOfAssembly { get; set; } = new();
        }

        /// <summary>
        /// 程序集类型枚举
        /// </summary>
        public enum ManifestType : short
        {
            /// <summary>
            /// 应用程序
            /// </summary>
            Application,
            /// <summary>
            /// 动态库
            /// </summary>
            Library
        }
        public enum TokenOfAssembly : long
        {
            None=1,
            ReadFile=2,
            WriteFile=4,
            Ouput=6,
            Input=8
        }

        [AttributeUsage(AttributeTargets.All)]
        public class RequireToken : Attribute
        {
            public TokenOfAssembly Tokens { get;}

            public RequireToken(TokenOfAssembly tokens)
            {
                Tokens = tokens;
            }
        }
    }
}