using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 编写自定义异步方法
{
    class Program
    {
        static void Main(string[] args)
        {
               getF2(); 
            Console.ReadKey();
        }
        public static async void  getF2()
        {
            string sfd = await F2Async();
            Console.WriteLine(sfd);
        }
        static Task<string> F2Async()
        {
            return Task.Run(() => {
                System.Threading.Thread.Sleep(2000);
                return "F2";
            });
        }
    }
}
