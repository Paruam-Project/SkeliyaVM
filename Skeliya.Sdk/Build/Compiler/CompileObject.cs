using System.Text;
using static Skeliya.Sdk.Build.Define.ByteCode;

namespace Skeliya.Sdk.Build.Compiler
{
    public class CompileObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static SkeliyaAssembly[] CreateObject(string filePath)
        {
            string inputCodeText = ReadFile(filePath);
            string[] everyLine = inputCodeText.Split("\r\n",StringSplitOptions.RemoveEmptyEntries);
            List<SkeliyaAssembly> assemblies = new();
            foreach (string line in everyLine)
            {
                string[] lines = line.Trim().Split();
                if (line.Trim().StartsWith("#") == false) 
                { 
                    if (lines.Length >=1)
                    {
                        SkeliyaAssembly assembly = new();
                        assembly.SasmOpCode = StringConvertToSkeliyaOpCode(lines[0].Trim());
                        if (lines.Length > 1)
                        {
                            foreach (string param in lines[1].Split(","))
                            {
                                assembly.Parameters.Add(param.Trim());
                            }
                        }
                        assemblies.Add(assembly);
                    } 
                } 
            }
            return assemblies.ToArray();
        }
        public static SkeliyaOpCode StringConvertToSkeliyaOpCode(string str)
        {
            SkeliyaOpCode OpCode;
            try
            {
                OpCode = (SkeliyaOpCode)Enum.Parse(typeof(SkeliyaOpCode), str,true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex); 
            }

            return OpCode;
        }
        public static string ReadFile(string path,string encodings = "utf-8")
        {
            string fileData;
            try
            {   ///读取文件的内容      
                StreamReader reader = new(path, Encoding.GetEncoding(encodings));
                fileData = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);    
            }  ///抛出异常      
            return fileData;
        }
    }
}
