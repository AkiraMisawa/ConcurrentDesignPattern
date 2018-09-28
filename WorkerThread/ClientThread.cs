using System;
using System.Linq;
using System.Threading;

namespace WorkerThread
{
    public class ClientThread
    {
        private string Name;

        private Channel Channel;

        private Random Random { get; } = new Random();

        public ClientThread(string name, Channel channel)
        {
            Name = name;
            Channel = channel;
        }

        public void Run()
        {
            try
            {
                foreach (int i in Enumerable.Range(0, int.MaxValue))
                {
                    var req = new Request(Thread.CurrentThread.Name, i);
                    Channel.PutRequest(req);
                    Thread.Sleep(Random.Next(minValue: 0, maxValue: 1000));
                }
            }
            catch (ThreadInterruptedException)
            {

            }
        }

        public void Start()
        {
            var thread = new Thread(Run) { Name = this.Name + "ClientThread" };
            thread.Start();
        }
    }
}