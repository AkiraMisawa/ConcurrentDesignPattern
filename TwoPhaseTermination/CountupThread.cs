using System;
using System.Threading;

namespace TwoPhaseTermination
{
    public class CountupThread
    {
        private long Counter { get; set; }

        private Thread Thread { get; }

        private volatile bool shutdownRequested = false;
        public bool IsShutdownRequested { get { return shutdownRequested; } }

        public CountupThread()
        {
            this.Thread = new Thread(Run);
        }

        public void Start()
        {
            this.Thread.Start();
        }

        public void Join()
        {
            this.Thread.Join();
        }

        public void ShutdownRequest()
        {
            shutdownRequested = true;
            Thread.Interrupt();
        }

        public void Run()
        {
            try
            {
                while (!IsShutdownRequested)
                {
                    DoWork();
                }
            }
            catch (ThreadInterruptedException) { }
            finally 
            {
                DoShutdown();
            }
        }

        private void DoShutdown()
        {
            Console.WriteLine($"DoShutdown: counter = {Counter.ToString()}");
        }

        private void DoWork()
        {
            Counter++;
            Console.WriteLine($"DoWork: counter = {Counter.ToString()}");
            Thread.Sleep(500);
        }
    }
}