using static Skeliya.Sdk.Build.Define.ApplicationManifest;

namespace Skeliya.Core.Runtime.Service.Api
{
    /// <summary>
    /// 虚拟机服务描述表
    /// </summary>
    internal class VMServicesDescriptorTable
    {
        [RequireToken(TokenOfAssembly.Ouput)]
        public void PrintLine(string text)
        {
            Console.WriteLine(text);
        }

        [RequireToken(TokenOfAssembly.Ouput)]
        public void Print(string text)
        {
            Console.Write(text);
        }

        [RequireToken(TokenOfAssembly.ReadFile)]
        public string FileReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}