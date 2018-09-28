using System;
using System.Threading;

namespace WorkerThread
{
    public class Request
    {
        private string Name { get; }

        private int Number { get; }

        private Random Random { get; } = new Random();

        public Request(string name, int number)
        {
            Name = name;
            Number = number;
        }

        public void Execute()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} executes {ToString()}");
            try
            {
                Thread.Sleep(1000);
            }
            catch (ThreadInterruptedException)
            {

            }
        }

        public override string ToString()
        {
            return $"[ Request from {Name} No. {Number.ToString()} ]";
        }
    }
}