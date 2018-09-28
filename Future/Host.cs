using System;
using System.Threading;

namespace Future
{
    public class Host
    {
        public IData Request(int count, char c)
        {
            Console.WriteLine($"    Request({count.ToString()}, {c.ToString()}) BEGIN");
            var future = new FutureData();

            new Thread(
                () => 
                {
                    var real = new RealData(count, c);
                    future.Real = real;
                }
            ).Start();

            Console.WriteLine($"    Request({count.ToString()}, {c.ToString()}) END");

            return future;
        }
    }
}