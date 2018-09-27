using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProducerConsumer
{
    public class Table
    {
        private object Locker { get; } = new object();

        private List<string> CakeBuffer { get; set; }

        private int Tail { get; set; }

        private int Head { get; set; }

        /// <summary>
        /// The number of cakes which is in this table.
        /// </summary>
        private int Count { get; set; }

        public Table(int capacity)
        {
            CakeBuffer = new List<string>(capacity);
            Head = 0;
            Tail = 0;
            Count = 0;
        }

        public void Put(string cake)
        {
            lock (Locker)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} puts {cake}");
                // You can't put a cake to this table when #cakes >= capacity.
                while (Count >= CakeBuffer.Capacity)
                {
                    Monitor.Wait(Locker);
                }
                CakeBuffer.Insert(Tail, cake);
                Tail = (Tail + 1) % CakeBuffer.Count;
                Count++;
                Monitor.PulseAll(Locker);
            }
        }

        public string Take()
        {
            lock (Locker)
            {
                while (Count <= 0)
                {
                    Monitor.Wait(Locker);
                }
                string cake = CakeBuffer[Head];
                Head = (Head + 1) % CakeBuffer.Count;
                Count--;
                Monitor.PulseAll(Locker);
                Console.WriteLine($"{Thread.CurrentThread.Name} takes {cake}");

                return cake;
            }
        }
    }
}