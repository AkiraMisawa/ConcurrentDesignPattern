using System;
using System.Linq;
using System.Threading;

namespace Future
{
    public class RealData : IData
    {
        private string Content { get; }

        public RealData(int count, char c)
        {
            Console.WriteLine($"    making RealData({count.ToString()}, {c.ToString()}) BEGIN");
            var buffer = Enumerable.Range(0, count)
                .Select(
                    _ => 
                    {
                        try { Thread.Sleep(100); }
                        catch (ThreadInterruptedException) {}
                        return c;
                    });
            Console.WriteLine($"    making RealData({count.ToString()}, {c.ToString()}) END");

            Content = new string(buffer.ToArray());
        }

        public string GetContent()
        {
            return Content;
        }
    }
}