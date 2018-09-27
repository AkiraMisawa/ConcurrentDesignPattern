using System;
using System.Threading;

namespace Balking
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Data("data.txt", "(empty)");
            var changer = new Thread(new ChangerThread("ChangerThread", data).Run);
            var saver = new Thread(new SaverThread("SaverThread", data).Run);
            
            changer.Start();
            saver.Start();
        }
    }
}
