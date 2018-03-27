using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basice.Utility.Redis;
using Microsoft.AspNetCore.Mvc;

namespace NET.Core_Project.Controllers
{
    /// <summary>
    /// redis的集群测试
    /// </summary>
    public class RedisController : Controller
    {
        public IActionResult Index()
        {
            /* （1）测试节点备份、同步
             * （2）关闭其中一个节点，对其中关闭的节点数据写入测试
             * （3）恢复该关闭的节点，查看同步状态
             */
            RedisHelper redisHelper = new RedisHelper("127.0.0.1:6390");
            string value = "mykey_1111111111111111";
            bool r1 = redisHelper.SetValue("mykey_3", value);
            //redisHelper.SetValue("mykey_4", value);
            //redisHelper.SetValue("mykey_5", value);
            //redisHelper.SetValue("mykey_6", value);
            //redisHelper.SetValue("mykey_7", value);
            string saveValue = redisHelper.GetValue("mykey3");
            //bool r2 = redisHelper.SetValue("mykey", "NewValue");
            //saveValue = redisHelper.GetValue("mykey");
            //bool r3 = redisHelper.DeleteKey("mykey");
            //string uncacheValue = redisHelper.GetValue("mykey");
            return Content(saveValue);
        }
    }
}