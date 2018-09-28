using System;
using System.Threading;

namespace ThreadPerMessage
{
    public class Host
    {
        private Helper Helper { get; } = new Helper();

        public void Request(int count, char c)
        {
            Console.WriteLine($"    Request({count.ToString()}, {c.ToString()}) BEGIN");
            new Thread(() => Helper.Handle(count, c)).Start();
            Console.WriteLine($"    Request({count.ToString()}, {c.ToString()}) END");
        }
    }
}