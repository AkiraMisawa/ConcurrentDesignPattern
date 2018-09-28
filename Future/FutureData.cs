using System;
using System.Threading;

namespace Future
{
    public class FutureData : IData
    {
        private RealData real = null;
        public RealData Real 
        { 
            get
            {
                return real;
            }
            set
            {
                lock (this)
                {
                    if (Ready)
                    {
                        // balking pattern
                        return;
                    }
                    real = value;
                    Ready = true;
                    Monitor.PulseAll(this);
                }
            }
        }

        private bool Ready { get; set; } = false;

        public string GetContent()
        {
            lock (this)
            {
                while (!Ready)
                {
                    try
                    {
                        Monitor.Wait(this);
                    }
                    catch (ThreadInterruptedException)
                    {

                    }
                }

                return Real.GetContent();
            }
        }
    }
}