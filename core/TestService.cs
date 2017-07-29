using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class TestService
    {
        private static ConnectionMultiplexer redis;
        private static TestService _instance { get; set; }
        private TestService()
        {
            if (redis==null)
            {
                redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            }
        }
        public static TestService Instance()
        {
            if (_instance==null)
            {
                _instance = new TestService();
            }
            return _instance;
        }
        public void Get(string key)
        {
            var db = redis.GetDatabase();
            string guid = db.StringGet(key);
            Console.WriteLine(guid);
        }
        public void Set(string key,string value)
        {
            var db = redis.GetDatabase();
            db.StringSet(key, value);
        }
        public void Pub(string subname,string msg)
        {
            ISubscriber sub = redis.GetSubscriber();
            sub.Publish(subname, msg);
        }
        public void Sub(string subname)
        {
            ISubscriber sub = redis.GetSubscriber();
            sub.Subscribe(subname, (channel, message) => {
                Console.WriteLine((string)message);
            });
        }
    }
}
