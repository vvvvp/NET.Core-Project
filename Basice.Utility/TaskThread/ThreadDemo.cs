using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Basice.Utility.TaskThread
{
    /// <summary>
    /// 
    /// </summary>
    public class ThreadDemo
    {
        public void Start()
        {
            Thread thread = new Thread(Run);
            Thread threadPara = new Thread(new ParameterizedThreadStart(ParaRun));
            thread.Start();
            Model model = new Model()
            {
                NAME = "name",
                AGE = 20
            };
            threadPara.Start(model);

            Console.WriteLine("执行Start-Success");
        }

        public void Run()
        {
            Console.WriteLine("执行Run-Success!");
        }
        public void ParaRun(object str)
        {
            var model = str as Model;
            Console.WriteLine("参数值：" + model.NAME+model.AGE);
        }
    }

    public class Model
    {
        public string NAME { get; set; }
        public short AGE{ get; set; }
    }
}
