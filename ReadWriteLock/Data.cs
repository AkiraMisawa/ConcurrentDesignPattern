using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ReadWriteLock
{
    /// <summary>
    /// This has shared resource role.
    /// </summary>
    public class Data
    {
        private char[] Buffer { get; set; }

        private ReadWriteLock Lock { get; } = new ReadWriteLock();

        public Data(int size)
        {
            Buffer = Enumerable.Repeat('*', size).ToArray();
        }

        internal IEnumerable<char> Read()
        {
            Lock.ReadLock();
            try
            {
                return DoRead();
            }
            finally
            {
                Lock.ReadUnlock();
            }
        }

        internal void Write(char c)
        {
            Lock.WriteLock();
            try
            {
                DoWrite(c);
            }
            finally
            {
                Lock.WriteUnlock();
            }
        }

        private IEnumerable<char> DoRead()
        {
            var newBuffer = new char[Buffer.Length];
            Array.Copy(Buffer, newBuffer, newBuffer.Length);
            Slowly();

            return newBuffer;
        }

        private void DoWrite(char c)
        {
            foreach (int i in Enumerable.Range(0, Buffer.Length))
            {
                Buffer[i] = c;
                Slowly();
            }
        }

        private void Slowly()
        {
            try
            {
                Thread.Sleep(50);
            }
            catch (ThreadInterruptedException)
            {

            }
        }
    }
}