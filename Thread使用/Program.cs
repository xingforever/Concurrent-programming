using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread使用
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread = new Thread(Run1);
            //thread.Start();
            //while (true)
            //{
            //    Console.WriteLine("主线程中" + DateTime.Now);
            //}
            Thread thread = new Thread(()=> {
                Console.WriteLine("你好");
            });
            thread.Start();
            Console.ReadKey();
        }

        static void Run1()
        {
            while (true)
            {
                Console.WriteLine("子线程中" + DateTime.Now);
            }
        }
    }
}
