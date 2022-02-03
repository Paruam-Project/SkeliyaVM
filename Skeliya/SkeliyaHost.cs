using Skeliya.Core.Runtime.Service;

namespace Skeliya
{
    /// <summary>
    /// 主运行类
    /// </summary>
    public class SkeliyaHost
    {
        /// <summary>
        /// 应用程序入口点
        /// </summary>
        public static void Main()
        {
            VMRuntime.SystemCallback("VMServicesDescriptorTable", "PrintL", new string[] { "VMSDT->PrintL SYSCALL OKAY" });
        }
    }
}