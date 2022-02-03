namespace Skeliya.Core.Runtime.Service
{
    /// <summary>
    /// 虚拟机核心容器实例
    /// </summary>
    internal class VMCore : IContainer
    {
        /// <summary>
        /// 公共运行时IOC
        /// </summary>
        private VMRuntime VMEnvironment { get; }

        public List<string> FilePathList { get; } = new();

        public VMCore(VMRuntime parentContainer)
        {
            VMEnvironment = parentContainer;
        }

        public void Initial()
        {
        }

        public ContainerState Load(string filePath)
        {
            throw new NotImplementedException();
        }

        public IContainer Fork()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        protected static class ReferenceResolve
        {
        }
    }
}