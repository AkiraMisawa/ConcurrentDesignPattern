using System;
using System.Threading;

namespace ProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new Table(3);
            var maker1 = new Thread(new MakerThread(table, 31415).Run)
            {
                Name = "MakerThread-1"
            };
            var maker2 = new Thread(new MakerThread(table, 92653).Run)
            {
                Name = "MakerThread-2"
            };
            var maker3 = new Thread(new MakerThread(table, 58979).Run)
            {
                Name = "MakerThread-3"
            };
            var eater1 = new Thread(new EaterThread(table, 32384).Run)
            {
                Name = "EaterThread-1"
            };
            var eater2 = new Thread(new EaterThread(table, 62643).Run)
            {
                Name = "EaterThread-2"
            };
            var eater3 = new Thread(new EaterThread(table, 38323).Run)
            {
                Name = "EaterThread-3"
            };

            maker1.Start();
            maker2.Start();
            maker3.Start();
            eater1.Start();
            eater2.Start();
            eater3.Start();
        }
    }
}
