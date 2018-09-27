using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;

namespace GuardedSuspension
{
    public class RequestQueue
    {
        private ConcurrentQueue<Request> Queue { get; set; }

        public RequestQueue()
        {
            Queue = new ConcurrentQueue<Request>();
        }

        public Request GetRequest()
        {
            Request req = null;
            while (!Queue.TryPeek(out req))
            {

            }
            Queue.TryDequeue(out req);

            return req;
        }

        public void PutRequest(Request request)
        {
            Queue.Enqueue(request);
        }
    }
}