using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程同步
{
    class Program
    {
        private static int counter = 0;
        private static object locker = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    //利用锁  
                    lock (locker)
                    {
                        counter++;
                    }
                  
                    Thread.Sleep(1);
                }
            });
            t1.Start();
            Thread t2 = new Thread(() =>
            {
               // t1.Join();//等着t1执行结束
                for (int i = 0; i < 1000; i++)
                {
                    lock (locker)
                    {
                        counter++;
                    }
                    Thread.Sleep(1);
                }
            });
            t2.Start();
            //询问线程是否死亡
            //while (t1.IsAlive) { };
            //while (t2.IsAlive) { };
            t1.Join();
            t2.Join();

            Console.WriteLine(counter);
            Console.ReadKey();
        }

    }
}
