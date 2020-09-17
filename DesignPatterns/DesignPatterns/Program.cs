using System;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                Task.Run(()=> { writes(i); });
            }
        }

        public static void writes(int i)
        {
            Console.Write(i);
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
