using System;
using System.Threading;

namespace Future
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main BEGIN");

            var host = new Host();
            IData data1 = host.Request(10, 'A');
            IData data2 = host.Request(20, 'B');
            IData data3 = host.Request(30, 'C');

            Console.WriteLine("Main other job BEGIN");
            try
            {
                Thread.Sleep(2000);
            }
            catch (ThreadInterruptedException)
            {

            }
            Console.WriteLine("Main other job END");

            Console.WriteLine($"data1 = {data1.GetContent()}");
            Console.WriteLine($"data2 = {data2.GetContent()}");
            Console.WriteLine($"data3 = {data3.GetContent()}");

            Console.WriteLine("Main END");
        }
    }
}
