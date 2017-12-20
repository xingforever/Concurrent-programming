using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread优先级
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0,j=0;
            Thread t1 = new Thread(() =>
            {
                while (true)
                {
                    i++;
                }
            });
            //优先级设计
            t1.Priority = ThreadPriority.AboveNormal;
             Thread t2 = new Thread((obj) =>
                {
                    while (true)
                    {
                        j++;
                    }
             });
            t1.Start();
            t2.Start();

            Thread.Sleep(3000);
            Console.WriteLine( $"i={i} j={j}");
            Console.ReadKey();
        }
    }
}
