using System;
using System.Threading;

namespace ReadWriteLock
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Data(10);
            var reader1 = new Thread(new ReaderThread(data).Run) { Name = "ReaderThread-1" };
            var reader2 = new Thread(new ReaderThread(data).Run) { Name = "ReaderThread-2" };
            var reader3 = new Thread(new ReaderThread(data).Run) { Name = "ReaderThread-3" };
            var reader4 = new Thread(new ReaderThread(data).Run) { Name = "ReaderThread-4" };
            var reader5 = new Thread(new ReaderThread(data).Run) { Name = "ReaderThread-5" };
            var reader6 = new Thread(new ReaderThread(data).Run) { Name = "ReaderThread-6" };
            var writer1 = new Thread(new WriterThread(data, "ABCDEFGHIJKLMNOPQRSTUVWXYZ").Run)
            {
                Name = "WriterThread-1"
            };
            var writer2 = new Thread(new WriterThread(data, "abcdefghijklmnopqrstuvwxyz").Run)
            {
                Name = "WriterThread-2"
            };

            reader1.Start();
            reader2.Start();
            reader3.Start();
            reader4.Start();
            reader5.Start();
            reader6.Start();
            writer1.Start();
            writer2.Start();
        }
    }
}
