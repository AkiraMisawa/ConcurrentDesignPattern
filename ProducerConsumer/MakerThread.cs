using System;
using System.Threading;

namespace ProducerConsumer
{
    /// <summary>
    /// This has producer role.
    /// </summary>
    public class MakerThread
    {
        private static object LockObj { get; } = new object();
        private Random Random { get; }

        private Table Table { get; }

        private static int Id { get; set; }

        public MakerThread(Table table, int seed)
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
                    Thread.Sleep(Random.Next(0, 1000));
                    string cake = $"[ Cake No. {NextId().ToString()} by {Thread.CurrentThread.Name} ]";
                    Table.Put(cake);
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

        private static int NextId()
        {
            lock (LockObj)
            {
                return Id++;
            }
        }
    }
}