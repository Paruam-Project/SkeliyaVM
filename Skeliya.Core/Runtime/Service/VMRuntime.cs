using System.Reflection;

namespace Skeliya.Core.Runtime.Service
{
    public class VMRuntime
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public VMRuntime()
        {
            // TODO:构造方法
        }

        /// <summary>
        /// 系统回调，可自动根据参数类型进行重载
        /// </summary>
        /// <param name="LClass">完全限定命名空间+类名</param>
        /// <param name="LVoid">方法名称</param>
        /// <param name="paramOfApi">参数</param>
        /// <returns>回调函数返回值</returns>
        public static object? SystemCallback(string LClass, string LVoid, object[]? paramOfApi = null)
        {
            //此处限定命名空间“Skeliya.Core.Runtime.Service.Api”，防止有程序跨程序集调用危险API
            Type? typeOfClassName = Type.GetType("Skeliya.Core.Runtime.Service.Api." + LClass, true, true);
            if (typeOfClassName != null)
            {
                object? obj = Activator.CreateInstance(typeOfClassName);
                if (obj != null)
                {
                    Type[]? type;
                    if (paramOfApi != null)
                    {
                        type = Type.GetTypeArray(paramOfApi);
                    }
                    else
                    {
                        type = Array.Empty<Type>();
                    }
                    MethodInfo? method = typeOfClassName.GetMethod(LVoid, type);
                    if (method != null)
                    {
                        return method.Invoke(obj, paramOfApi);
                    }
                    else
                    {
                        return default;
                    }
                }
                else
                {
                    return default;
                }
            }
            else
            {
                return default;
            }
        }
    }

    /// <summary>
    /// 虚拟机容器
    /// </summary>
    internal interface IContainer
    {
        /// <summary>
        /// 初始化容器
        /// </summary>
        public void Initial();

        /// <summary>
        /// 加载文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>容器状态</returns>
        public ContainerState Load(string filePath);

        /// <summary>
        /// fork自己
        /// </summary>
        /// <returns>fork后的容器</returns>
        public IContainer Fork();

        /// <summary>
        /// 销毁容器
        /// </summary>
        public void Dispose();
    }

    /// <summary>
    /// 容器状态
    /// </summary>
    internal enum ContainerState
    {
        Exception = -1,
        Normal = 0
    }
}