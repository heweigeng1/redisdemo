using core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string key = "testabccc";
            //设置与获取
            for (int i = 0; i < 100; i++)
            {
                var test =TestService.Instance();
                test.Set(key, $"{Guid.NewGuid()}");
                test.Get(key);
            }
            //推送
            //test.Pub("testsub", "hello sub");
            //订阅
            //test.Sub("testsub");
            Console.ReadKey();
        }
    }
}
