using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoResetEvents
{
    class Program
    {
        static void Main(string[] args)
        {

            test();

        }

        static void test()
        {
            AutoResetEvent are = new AutoResetEvent(false);
            Thread t1 = new Thread(() => {
                while (true)
                {
                    Console.WriteLine("开始等着开门");
                    are.WaitOne();
                    Console.WriteLine("终于等到你");
                }
            });
            t1.Start();
            Console.WriteLine("按任意键开门");
            Console.ReadKey();
            are.Set();//开门
            Console.WriteLine("按任意键开门");
            Console.ReadKey();
            are.Set();
            Console.WriteLine("按任意键开门");
            Console.ReadKey();
            are.Set();
            Console.ReadKey();
        }
    }
}
