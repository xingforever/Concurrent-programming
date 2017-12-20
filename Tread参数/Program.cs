using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tread参数
{
    class Program
    {
        static void Main(string[] args)
        {
           

            Sleep();
        }
        static void paramer()
        {
            int i = 5;
            Thread thread = new Thread((obj) =>
            {
                Console.WriteLine($"obj={obj}");
            });
            thread.Start(i);
            i = 6;


            for (int j = 0; j < 10; j++)
            {
                Thread the = new Thread((obj) =>
                {
                    Console.WriteLine("j" + obj);
                });
                the.Start(j);
            }
            Console.ReadKey();
        }

        static void Sleep()
        {
            Thread thread = new Thread(() =>
              {
                  Console.WriteLine("thread线程要睡了");
                  Thread.Sleep(1000);
                  Console.WriteLine("thread线程要醒了");

              });
            thread.Start();
            Console.WriteLine("主线程要睡啦"); ;
            Thread.Sleep(500);
            Console.WriteLine("主线程要睡啦");
            Console.ReadKey();


        }
    }
}
