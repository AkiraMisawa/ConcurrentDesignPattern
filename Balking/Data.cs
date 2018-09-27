using System;
using System.IO;
using System.Threading;

namespace Balking
{
    public class Data
    {
        private object LockObj { get; } = new object();
        private string FileName { get; }

        private string Content { get; set; }

        private bool IsChanged { get; set; }

        public Data(string filename, string content)
        {
            FileName = filename;
            Content = content;
            IsChanged = true;
        }

        public void Change(string newContent)
        {
            lock (LockObj)
            {
                Content = newContent;
                IsChanged = true;
            }
        }

        public void Save()
        {
            lock (LockObj)
            {
                if (!IsChanged)
                {
                    // balking
                    return;
                }
                DoSave();
                IsChanged = false;
            }
        }

        private void DoSave()
        {
            Console.WriteLine($"Thread-{Thread.CurrentThread.ManagedThreadId} calls DoSave, Content = {Content}");
            File.WriteAllText(FileName, Content);
        }
    }
}