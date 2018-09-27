using System;
using System.Threading;
using System.Threading.Tasks;

namespace Immutable
{
    public class PrintPersonThread
    {
        private Person Person { get; }
        public PrintPersonThread(Person person)
        {
            Person = person;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine($"Thread-{Thread.CurrentThread.ManagedThreadId} prints {Person}");
            }
        }
    }
}