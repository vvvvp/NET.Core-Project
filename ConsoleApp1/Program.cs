using System;
using System.IO;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// NET Core 的控制台应用程序
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WriteCode();
            Console.WriteLine("SUCCESS");
            Console.Read();
        }
        static int DGss(int k)
        {
            while (k > 10) {
                k += DGss(k);
            }
            Thread.Sleep(1000);
            return k;
        }
        static void WriteCode()
        {
            StringBuilder sbuild = new StringBuilder();
            sbuild.Append("using System; \n");
            sbuild.Append("using System.Collections.Generic; \n");
            sbuild.Append("using System.Text; \n");
            sbuild.Append("namespace ConsoleApp1 \n");
            sbuild.Append("{ \n");
            sbuild.Append("class Class2 \n");
            sbuild.Append("{ \n");
            sbuild.Append("} \n");
            sbuild.Append("} \n");
            StringWriter s = new StringWriter(sbuild);
            File.WriteAllText("E:\\AAA_CD\\BaiduYunTB\\百度云同步盘\\2017我的框架\\NET.Core Project\\NET.Core Project\\ConsoleApp1\\Class2.cs", s.ToString());
        }
    }
}
