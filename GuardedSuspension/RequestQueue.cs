using System;
using System.Collections.Generic;
using System.Threading;

namespace GuardedSuspension
{
    public class RequestQueue
    {
        private object lockObj = new object();
        private Queue<Request> Queue { get; set; }

        public RequestQueue()
        {
            Queue = new Queue<Request>();
        }

        public Request GetRequest()
        {
            lock (lockObj)
            {
                Console.WriteLine($"Thread-{Thread.CurrentThread.ManagedThreadId} is getting request.");
                while (Queue.Count == 0)
                {
                    try
                    {
                        Console.WriteLine("Now RequestQueue is empty, so waiting this object's state will be changed.");
                        Monitor.Wait(lockObj);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine("ThreadInterruptedException is caught.");
                        Console.WriteLine(e.Message);
                    }
                }

                return Queue.Dequeue();
            }
        }

        public void PutRequest(Request request)
        {
            Console.WriteLine($"Thread-{Thread.CurrentThread.ManagedThreadId} is putting request.");
            lock (lockObj)
            {
                Queue.Enqueue(request);
                Monitor.PulseAll(lockObj);
            }
        }
    }
}