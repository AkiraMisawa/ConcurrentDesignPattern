using System;
using System.Threading;

namespace ProducerConsumer
{
    public class EaterThread
    {
        private Random Random { get; }

        private Table Table { get; }

        public EaterThread(Table table, int seed)
        {
            Table = table;
            Random = new Random(seed);
        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    string cake = Table.Take();
                    Thread.Sleep(Random.Next(0, 1000));
                }
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}