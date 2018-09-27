using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace Balking
{
    public class ChangerThread
    {
        private Data Data { get; }

        private Random Random { get; }

        public ChangerThread(string name, Data data)
        {
            if (string.IsNullOrEmpty(Thread.CurrentThread.Name))
            {
                Thread.CurrentThread.Name = name;
            }
            Data = data;
            Random = new Random();
        }

        public void Run()
        {
            try{
                foreach (int i in Enumerable.Range(0, int.MaxValue))
                {
                    Data.Change($"No. {i}");
                    Thread.Sleep(Random.Next(1000));
                    Data.Save();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}