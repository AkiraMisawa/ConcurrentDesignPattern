using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ReadWriteLock
{
    /// <summary>
    /// This has a reader role.
    /// </summary>
    public class ReaderThread
    {
        private Data Data { get; }

        public ReaderThread(Data data)
        {
            Data = data;
        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    IEnumerable<char> readbuf = Data.Read();
                    Console.WriteLine($"{Thread.CurrentThread.Name} reads {new string(readbuf.ToArray())}");
                }
            }
            catch (ThreadInterruptedException)
            {

            }
        }
    }
}