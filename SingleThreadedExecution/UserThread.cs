using System;

namespace SingleThreadedExecution 
{
    class UserThread
    {
        private Gate Gate { get; }
        private string Name { get; }
        private string Address { get; }

        public UserThread(Gate gate, string name, string address)
        {
            Gate = gate;
            Name = name;
            Address = address;
        }

        public void Run()
        {
            Console.WriteLine($"{Name} BEGIN");
            while (true)
            {
                Gate.Pass(Name, Address);
            }
        }
    }
}