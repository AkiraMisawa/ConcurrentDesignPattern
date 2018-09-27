using System;
using System.Linq;
using System.Threading;

namespace ReadWriteLock
{
    /// <summary>
    /// This has a writer role.
    /// </summary>
    public class WriterThread
    {
        private static Random Random { get; } = new Random();

        private Data Data { get; }

        private string Filter { get; }

        private int Index { get; set; } = 0;

        public WriterThread(Data data, string filter)
        {
            Data = data;
            Filter = filter;
        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    char c = NextChar();
                    Data.Write(c);
                    Thread.Sleep(Random.Next(minValue: 0, maxValue: 3000));
                }
            }
            catch (ThreadInterruptedException)
            {

            }
        }

        private char NextChar()
        {
            char c = Filter.ElementAt(Index);
            Index++;
            if (Index >= Filter.Length)
            {
                Index = 0;
            }

            return c;
        }
    }
}