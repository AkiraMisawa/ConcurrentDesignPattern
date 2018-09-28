using System;
using System.Threading;

namespace WorkerThread
{
    public class WorkerThread
    {
        private Channel Channel { get; }

        private string Name { get; }

        public WorkerThread(string name, Channel channel)
        {
            Name = name;
            Channel = channel;
        }

        public void Run()
        {
            while (true)
            {
                var req = Channel.TakeRequest();
                req.Execute();
            }
        }

        public void Start()
        {
            var thread = new Thread(Run) { Name = this.Name };
            thread.Start();
        }
    }
}