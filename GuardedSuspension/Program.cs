using System;
using System.Threading;

namespace GuardedSuspension
{
    class Program
    {
        static void Main(string[] args)
        {
            var requestQueue = new RequestQueue();
            var client = new ClientThread(requestQueue, "Alice", 3141592);
            var server = new ServerThread(requestQueue, "Bobby", 6535897);

            new Thread(new ThreadStart(client.Run)).Start();
            new Thread(new ThreadStart(server.Run)).Start();
        }
    }
}
