using System;

namespace WorkerThread
{
    class Program
    {
        /// <summary>
        /// channel has 5 worker threads and 3 clients share it.
        /// </summary>
        static void Main(string[] args)
        {
            var channel = new Channel(5);
            channel.StartWorkers();
            new ClientThread("Alice", channel).Start();
            new ClientThread("Bobby", channel).Start();
            new ClientThread("Chris", channel).Start();
        }
    }
}
