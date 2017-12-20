using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaitHander
{
    class Program
    {
        static void Main(string[] args)
        {
            ManualResetEvent mre = new ManualResetEvent(false);
            //构造函数false表示“初始状态为关门”，设置为true则初始化为开门状态
            Thread t1 = new Thread(() => {
                Console.WriteLine("开始等着开门");
                mre.WaitOne();
                Console.WriteLine("终于等到你");
            });
            t1.Start();
            Console.WriteLine("按任意键开门");
            Console.ReadKey();
            mre.Set();//开门
            Console.ReadKey();
        }

        static void test()
        {
            ManualResetEvent mre = new ManualResetEvent(false);
            //false表示“初始状态为关门”
            Thread t1 = new Thread(() => {
                Console.WriteLine("开始等着开门");
                if (mre.WaitOne(5000))
                {
                    Console.WriteLine("终于等到你");
                }
                else
                {
                    Console.WriteLine("等了5秒钟都没等到");
                }
            });
            t1.Start();
            Console.WriteLine("按任意键开门");
            Console.ReadKey();
            mre.Set();//开门
            Console.ReadKey();
        }
    }
}
