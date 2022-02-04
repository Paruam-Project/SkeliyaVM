namespace Skeliya.Sdk.Build.Define
{
    /// <summary>
    /// 字节码定义
    /// </summary>
    public class ByteCode
    {
        /// <summary>
        /// Sasm汇编代码单元
        /// </summary>
        public class SkeliyaAssembly
        {
            public SkeliyaOpCode SasmOpCode { get; set; }
            public List<object> Parameters { get; set; } = new();

            //LiteDB传入类中不得有构造参数
        }

        /// <summary>
        /// 在此基础上做了些修改：https://www.cnblogs.com/john-d/archive/2009/12/05/1617710.html 同时也参考了Smali汇编代码，原理部分源自Jvm
        /// </summary>
        public enum SkeliyaOpCode : short
        {
            //字节码流标志
            IL_START,

            IL_END,

            //操作
            IL_NativeMethod, /*虚拟机Kernel方法*/

            IL_InvokeMethod, /*程序内部/引用方法*/
            IL_SyscallMethod,/*虚拟机API方法*/

            //逻辑
            IL_IF_LT, /* < */ //if-lf v1,v2,:0xc00000001 => v1 v2 if? ->address

            IL_IF_LE, /* <= */
            IL_IF_GT, /* > */
            IL_IF_GE, /* >= */
            IL_IF_EQ, /* == */
            IL_IF_NE, /* != */
            IL_IF_LTZ, /* <0 */ //if-lf v1,0,:0xc00000001 => v1 0 if? ->address
            IL_IF_LEZ, /* <=0 */
            IL_IF_GTZ, /* >0 */
            IL_IF_GEZ, /* >=0 */
            IL_IF_EQZ, /* ==0 */
            IL_IF_NEZ, /* !=0 */

            //操作值（仅限寄存器之间，不得用于赋值操作）
            IL_MOVE_PTR, /* mov-ptr v1,v2 */

            IL_MOVE_OBJECT,
            IL_MOVE_VALUE,

            //返回
            IL_RETURN_PTR, /*return-ptr void*/

            IL_RETURN_OBJECT, //直接返回 寄存器对象即可 : return-object v1
            IL_RETURN_VALUE, /* return-value v1 */

            //常量
            IL_CONST_PTR, /* const-ptr v1,"hello world!" => string->v1 lamada: v1->string */

            IL_CONST_OBJECT,
            IL_CONST_VALUE,

            //取值
            IL_GET_PTR,  /* get-ptr v1,v2  => v2->v1   lamada:v1->v2 */

            IL_GET_OBJECT,
            IL_GET_VALUE,

            //赋值
            IL_PUT_PTR,  /* put-ptr v1,v2  => v1->v2   lamada:v2->v1 */

            IL_PUT_OBJECT,
            IL_PUT_VALUE
        }
    }
}