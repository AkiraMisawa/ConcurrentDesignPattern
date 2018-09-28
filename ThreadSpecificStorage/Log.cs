using System;
using System.IO;
using System.Threading;

namespace ThreadSpecificStorage
{
    public class Log
    {
        private static ThreadLocal<ThreadLocalLog> TlLogCollection { get; } = new ThreadLocal<ThreadLocalLog>();

        public static void WriteLine(string s)
        {
            GetThreadLocalLog().WriteLine(s);
        }

        public static void Close()
        {
            GetThreadLocalLog().Close();
        }

        private static ThreadLocalLog GetThreadLocalLog()
        {
            var tlLog = TlLogCollection.Value;
            if (tlLog == null)
            {
                tlLog = new ThreadLocalLog($"{Thread.CurrentThread.Name}-log.txt");
                TlLogCollection.Value = tlLog;
            }

            return tlLog;
        }
    }
}