namespace Skeliya.Core.Runtime.Service.Api
{
    /// <summary>
    /// 虚拟机服务描述表
    /// </summary>
    internal class VMServicesDescriptorTable
    {
        public void PrintL(string text)
        {
            Console.WriteLine(text);
        }

        public void Print(string text)
        {
            Console.Write(text);
        }
        public string FileReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}