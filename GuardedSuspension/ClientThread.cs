using System;
using System.Linq;
using System.Threading;

namespace GuardedSuspension
{
    public class ClientThread
    {
        private RequestQueue Requests { get; }

        private Random Random { get; }

        public ClientThread(RequestQueue requestQueue, string name, int seed)
        {
            Requests = requestQueue;
            Random = new Random(seed);
        }

        public void Run()
        {
            try
            {
                foreach (int i in Enumerable.Range(0, 10000))
                {
                    var req = new Request($"No. {i.ToString()}");
                    Console.WriteLine($"Thread-{Thread.CurrentThread.ManagedThreadId} requests {req.ToString()}");
                    Requests.PutRequest(req);
                    Thread.Sleep(Random.Next(1000));
                }
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine($"caught ThreadInterruptedException in ClientThread: {e.Message}");
            }
        }
    }
}