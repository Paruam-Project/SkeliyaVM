namespace Skeliya.Sdk.Build.Define
{
    public class ApplicationManifest
    {
        /// <summary>
        /// 清单收集器
        /// </summary>
        public class ManifestCollection
        {
            public ManifestType Type { get; set; } = new();
            public string Name { get; set; } = "";
            public string Description { get; set; } = "";
            public Guid Guid { get; set; } = new();
            public Version Version { get; set; } = new();
            public long AssemblyAllCounts { get; set; } = 0;
            public List<PackageReference> PackageReferences { get; set; } = new();
            public uint MinApiSdk { get; set; } = 0;
            public uint MaxApiSdk { get; set; } = 0;
            public DateTime FileStamp { get; set; } = DateTime.Now;
        }

        /// <summary>
        /// 程序集依赖项
        /// </summary>
        public class PackageReference
        {
            public string PackagePath { get; set; } = "";
            public string Name { get; set; } = "";
            public string Description { get; set; } = "";
            public Guid Guid { get; set; } = new();
            public Version Version { get; set; } = new();
        }

        /// <summary>
        /// 程序集类型
        /// </summary>
        public enum ManifestType : short
        {
            Application,
            Library
        }
    }
}