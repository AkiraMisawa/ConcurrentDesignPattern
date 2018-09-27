using System;
using System.Threading;
using System.Threading.Tasks;

namespace SingleThreadedExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Gate, hit Ctrl+C to exit.");
            var gate = new Gate();
            var user1 = new UserThread(gate, "Alice", "Alaska");
            var user2 = new UserThread(gate, "Bobby", "Brazil");
            var user3 = new UserThread(gate, "Chris", "Canada");

            new Thread(new ThreadStart(user1.Run)).Start();
            new Thread(new ThreadStart(user2.Run)).Start();
            new Thread(new ThreadStart(user3.Run)).Start();
        }
    }
}
