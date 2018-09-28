using System;
using System.Threading;

namespace TwoPhaseTermination
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main: BEGIN");
            try
            {
                var t = new CountupThread();
                t.Start();

                Thread.Sleep(10000);

                Console.WriteLine("Main: ShutdownRequest");
                t.ShutdownRequest();

                Console.WriteLine("Main: Join");
                t.Join();
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Console.WriteLine("Main: END");
        }
    }
}
