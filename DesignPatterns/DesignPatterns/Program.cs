using DesignPatterns.Redis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
          var test= RedisClientHelper.GetRedis("192.168.1.99:6379");
         var test2 = DesignPatterns.Redis.RedisHelper.GetClient("192.168.1.99:6379");
       //var test3=     test2.StringSet("a111a", "bbb", new TimeSpan(TimeSpan.TicksPerMinute));
            test.Set("a112a", "aaa",100);
            //test.MSet();
            //test.IncrBy();
           
           Console.WriteLine(test.Get("a111a"));
           // Console.WriteLine(test2.StringGet("a112a"));
            Console.ReadKey();
        }


    }

    public class Worker3
    {
        public bool IsComplete { get; private set; }
        internal void DoWork()
        {
            this.IsComplete = false;
            Console.WriteLine("Doing Work.");
            Task.Run(new Action(LongOperation));
            Console.WriteLine("Work Completed");
            IsComplete = true;
        }

        private void LongOperation()
        {
            Console.WriteLine("long operation thread thread :" + Thread.CurrentThread.ManagedThreadId);//Thread Id = 7. it is different from main thread id.
            Console.WriteLine("Working!");
            Thread.Sleep(3000);
        }
    }

    public class Worker2
    {
        public bool IsComplete { get; private set; }
        internal async void DoWork()
        {
            this.IsComplete = false;
            Console.WriteLine("Doing Work.");
            await LongOperation();
            Console.WriteLine("Work Completed");
            IsComplete = true;
        }

        private Task LongOperation()
        {

            return Task.Run(() =>
            {
                Console.WriteLine("long operation thread thread :" + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Working!");
                Thread.Sleep(3000);
            });
        }
    }

}
