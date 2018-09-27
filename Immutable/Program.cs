using System;
using System.Threading;

namespace Immutable
{
    class Program
    {
        static void Main(string[] args)
        {
            var alice = new Person("Alice", "Alaska");
            var printAliceThread = new PrintPersonThread(alice);
            new Thread(new ThreadStart(printAliceThread.Run)).Start();
            new Thread(new ThreadStart(printAliceThread.Run)).Start();
            new Thread(new ThreadStart(printAliceThread.Run)).Start();
        }
    }
}
