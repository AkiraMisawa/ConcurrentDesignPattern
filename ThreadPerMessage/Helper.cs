using System;
using System.Linq;
using System.Threading;

namespace ThreadPerMessage
{
    public class Helper
    {
        public void Handle(int count, char c)
        {
            Console.WriteLine($"    Handle({count.ToString()}, {c.ToString()}) BEGIN");
            foreach (int i in Enumerable.Range(0, count))
            {
                Slowly();
                Console.Write(c);
            }
            Console.WriteLine("");
            Console.WriteLine($"    Handle({count.ToString()}, {c.ToString()}) END");
        }

        private void Slowly()
        {
            try
            {
                Thread.Sleep(100);
            }
            catch (ThreadInterruptedException)
            {

            }
        }
    }
}