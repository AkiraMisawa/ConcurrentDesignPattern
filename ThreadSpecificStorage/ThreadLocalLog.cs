using System;
using System.IO;
using System.Threading;

namespace ThreadSpecificStorage
{
    public class ThreadLocalLog
    {
        private StreamWriter Writer { get; } = null;

        public ThreadLocalLog(string filename)
        {
            try
            {
                Writer = new StreamWriter(filename, false);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void WriteLine(string s)
        {
            Writer.WriteLine(s);
        }

        public void Close()
        {
            Writer.WriteLine("===== End of log =====");
            Writer.Close();
        }
    }
}