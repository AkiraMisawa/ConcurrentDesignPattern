using System;
using System.IO;
using System.Threading;

namespace Balking
{
    public class SaverThread
    {
        private Data Data { get; }

        public SaverThread(string name, Data data)
        {
            if (string.IsNullOrEmpty(Thread.CurrentThread.Name))
            {
                Thread.CurrentThread.Name = name;
            }
            Data = data;
        }

        public void Run()
        {
            try{
                while (true)
                {
                    Data.Save();
                    Thread.Sleep(1000);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}