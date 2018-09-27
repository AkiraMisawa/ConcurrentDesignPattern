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

            var clientThread = new Thread(new ThreadStart(client.Run));
            var serverThread = new Thread(new ThreadStart(server.Run));
            clientThread.Start();
            serverThread.Start();

            try
            {
                Thread.Sleep(10000);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine($"caught in Main thread: {e.Message}");
            }

            Console.WriteLine("***** calling interrupt *****");
            clientThread.Interrupt();
            serverThread.Interrupt();
        }
    }
}
