using System;

namespace ThreadPerMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main BEGIN");
            var host = new Host();
            host.Request(10, 'A');
            host.Request(20, 'B');
            host.Request(30, 'C');
            Console.WriteLine("Main END");
        }
    }
}
