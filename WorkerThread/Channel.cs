    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    namespace WorkerThread
    {
        public class Channel
        {
            private static int MaxRequest { get; } = 100;

            private Queue<Request> RequestQueue { get; }

            private List<WorkerThread> ThreadPool { get; }

            public Channel(int threadsCount)
            {
                RequestQueue = new Queue<Request>(MaxRequest);
                ThreadPool = Enumerable.Range(0, threadsCount)
                    .Select(i => new WorkerThread($"WorkerThread-{i.ToString()}", this))
                    .ToList();
            }

            public void StartWorkers()
            {
                ThreadPool.ForEach(workerThread => workerThread.Start());
            }

            public void PutRequest(Request request)
            {
                lock (this)
                {
                    while (RequestQueue.Count >= MaxRequest)
                    {
                        try
                        {
                            Monitor.Wait(this);
                        }
                        catch (ThreadInterruptedException)
                        {

                        }
                    }
                    RequestQueue.Enqueue(request);
                    Monitor.PulseAll(this);
                }
            }

            public Request TakeRequest()
            {
                lock (this)
                {
                    while (!HasRequest())
                    {
                        try
                        {
                            Monitor.Wait(this);
                        }
                        catch (ThreadInterruptedException)
                        {

                        }
                    }
                    var req = RequestQueue.Dequeue();
                    Monitor.PulseAll(this);

                    return req;
                }
            }

            private bool HasRequest()
            {
                return RequestQueue.Count > 0;
            }
        }
    }