using Basice.Utility.Redis;
using Basice.Utility.TaskThread;
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
            ////DGss(1);
            //RedisHelper redis = new RedisHelper();
            //redis.Set("MainClick", "hahahahhaah", 30000);//分钟

            //ThreadDemo demo = new ThreadDemo();
            //demo.Start();
            //Console.WriteLine(Sum(1));
            //Console.WriteLine(Sum(2));
            //Console.WriteLine(Sum(3));
            //Console.WriteLine(Sum(4));
            //Console.WriteLine(Sum(5));
            //Console.WriteLine(Sum(6));
            //new B();

            Console.WriteLine("Main-Success!");
            Console.Read();
        }

        public static int Sum(int A)
        {
            // 1 2 3 5 8 13 21 34
            if (A < 0)
                return 0;
            else if (A == 1 || A == 0)
                return 1;
            else
                return Sum(A - 1) + Sum(A - 2);
        }

        static void DGss(int k)
        {
            while (k < 10)
            {
                Thread.Sleep(1000);
                Console.WriteLine(k);
                DGss(++k);
            }
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


    class A
    {
        public A()
        {
            PrintFields();
        }
        public virtual void PrintFields() { }
    }
    class B : A
    {
        int x = 1;
        int y;
        public B()
        {
            y = -1;
            PrintFields();
        }
        public override void PrintFields()
        {
            Console.WriteLine("x={0},y={1}", x, y);
        }
    }
}
