using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程池
{
    class Program
    {
        static void Main(string[] args)
        {

            Dataing();
            Console.ReadKey();
        }
        static void GetData()
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                for (int i = 0; i < 200; i++)
                {
                    Console.WriteLine(i);
                }
            });
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine("hello");
            }
        }
        static  void Dataing()
        {
            for (int i = 0; i < 1; i++)
            {
                ThreadPool.QueueUserWorkItem(state =>
                {
                    Console.WriteLine(state);
                    int workThreads; int compltortThreads;
                    ThreadPool.GetAvailableThreads(out workThreads, out compltortThreads);
                    Console.WriteLine(workThreads+"    "+ compltortThreads);
                }, 1);
            }
         
        }
    }
}
