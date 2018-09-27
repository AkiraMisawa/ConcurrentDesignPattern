using System;
using System.Linq;
using System.Threading;

namespace GuardedSuspension
{
    public class ServerThread
    {
        private Random Random { get; }

        private RequestQueue Requests { get; }

        public ServerThread(RequestQueue requestQueue, string name, int seed)
        {
            Requests = requestQueue;
            Random = new Random(seed);
        }

        public void Run()
        {
            foreach (int i in Enumerable.Range(0, 10000))
            {
                var req = Requests.GetRequest();
                Console.WriteLine($"Thread-{Thread.CurrentThread.ManagedThreadId} handles {req}");
                try
                {
                    Thread.Sleep(Random.Next(1000));
                }
                catch (ThreadInterruptedException)
                {
                    
                }
            }
        }
    }
}