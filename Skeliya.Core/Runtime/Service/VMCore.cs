using Skeliya.Sdk.Build.Define;
using Skeliya.Sdk.Extensions.LiteDBWrapper;

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

        private Dictionary<string,FileController> FilePathList { get; } = new();
        private string MainFile { get; set; } = "";
        public VMCore(VMRuntime parentContainer,string mainFile)
        {
            VMEnvironment = parentContainer;
            FilePathList.Add(mainFile, GetFileController(mainFile));
            MainFile = mainFile;
        }
        private FileController GetFileController(string fileName)//添加依赖的File操作器到字典
        {
            if (FilePathList.ContainsKey(fileName))
            {
                return FilePathList[fileName];//有则直接返回
            }
            else
            {
                //无则添加
                FileController fileController = new(FileController.CreateOrOpenDataBase(fileName));
                FilePathList.Add(fileName, fileController);
                return fileController;
            }
        }
        public void Initial()
        {
            //file-loader
            var refs = new ReferenceResolve();
            
      

        }

        public ContainerState Load(string filePath)
        {
            return 0;
        }

        public IContainer Fork()
        {
            return this;
        }

        public void Dispose()
        {
            //销毁容器

        }

        internal class ReferenceResolve
        {
            /// <summary>
            /// 依赖项操作对象列表
            /// </summary>
            public List<FileController> References { get; } = new();
            public void Load(string mainFile)
            {
                RefLoader(mainFile);
            }
            private void RefLoader(string filePath)
            {
                FileController fileController = new(FileController.CreateOrOpenDataBase(filePath));
                if(References.Contains(fileController)==false)
                {
                    References.Add(fileController);
                }
                ApplicationManifest.ManifestCollection? manifestThisFile = fileController.Read<ApplicationManifest.ManifestCollection>().FirstOrDefault();
                if(manifestThisFile != null)
                {
                    if(manifestThisFile.PackageReferences.Count != 0)
                    {
                        foreach(var reference in manifestThisFile.PackageReferences)
                        {
                            RefLoader(reference);
                        }
                    }
                }
                else
                {
                    throw new Exception("error Assembly! notfoundManifestFile");
                }
            }
        }
    }
}