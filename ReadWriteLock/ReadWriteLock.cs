using System;
using System.Threading;

namespace ReadWriteLock
{
    public class ReadWriteLock
    {
        /// <summary>
        /// The number of threads which is really reading data.
        /// </summary>
        private int ReadingReadersCount { get; set; } = 0;

        /// <summary>
        /// The number of threads which arrive at WriteLock but is waiting for Wait.
        /// </summary>
        private int WaitingWritersCount { get; set; } = 0;

        /// <summary>
        /// The number of threads which is really writing data.
        /// </summary>
        private int WritingWritersCount { get; set; } = 0;

        private bool PreferWriter { get; set; } = true;
        public ReadWriteLock()
        {

        }

        public void ReadLock()
        {
            lock (this)
            {
                while (!CanRead())
                {
                    Monitor.Wait(this);
                }
                ReadingReadersCount++;
            }
        }

        public void ReadUnlock()
        {
            lock (this)
            {
                ReadingReadersCount--;
                PreferWriter = true;
                Monitor.PulseAll(this);
            }
        }

        public void WriteLock()
        {
            lock (this)
            {
                WaitingWritersCount++;
                try
                {
                    while (!CanWrite())
                    {
                        Monitor.Wait(this);
                    }
                }
                finally
                {
                    WaitingWritersCount--;
                }
                WritingWritersCount++;
            }
        }

        public void WriteUnlock()
        {
            lock (this)
            {
                WritingWritersCount--;
                PreferWriter = false;
                Monitor.PulseAll(this);
            }
        }

        private bool CanRead()
        {
            return WritingWritersCount <= 0 && (!PreferWriter || WaitingWritersCount <= 0);
        }

        private bool CanWrite()
        {
            return (ReadingReadersCount <= 0) && (WritingWritersCount <= 0);
        }
    }
}