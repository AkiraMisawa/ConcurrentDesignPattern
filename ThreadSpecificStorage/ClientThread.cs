using System;
using System.Linq;
using System.Threading;

namespace ThreadSpecificStorage
{
    public class ClientThread
    {
        private Thread ThisThread { get; }

        public ClientThread(string name)
        {
            ThisThread = new Thread(Run) { Name = name };
        }

        public void Start()
        {
            ThisThread.Start();
        }

        public void Run()
        {
            Console.WriteLine($"{ThisThread.Name} BEGIN");
            foreach (int i in Enumerable.Range(0, 10))
            {
                Log.WriteLine($"i = {i.ToString()}");
                try
                {
                    Thread.Sleep(100);
                }
                catch (ThreadInterruptedException)
                {

                }
            }
            Log.Close();
            Console.WriteLine($"{ThisThread.Name} END");
        }
    }
}