using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeliya.Sdk.Build.Define
{
    public class ApplicationManifest
    {
        public class ManifestCollection
        {
            public ManifestType Type { get; set; } = new();
            public string Name { get; set; } = "";
            public string Description { get; set; } = "";
            public Guid Guid { get; set; } = new();
            public Version Version { get; set; } = new();
            public List<PackageReference> PackageReferences { get; set; } = new();
            public uint MinApiSdk { get; set; } = 0;
            public uint MaxApiSdk { get; set; } = 0;
            public DateTime FileStamp { get; set; } = DateTime.Now;
        }
        public class PackageReference
        {
            public string PackagePath { get; set; } = "";
            public string Name { get; set; } = "";
            public string Description { get; set; } = "";
            public Guid Guid { get; set; } = new();
            public Version Version { get; set; } = new();

        }
        public enum ManifestType : short
        {
            Application,
            Library
        }
    }
}
