using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 多线程与单例模式
{
    class God
    {
        private static God instance = null;
        private static object locker = new object();
        private God()
        {
        }
        public static God GetInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new God();
                    }
                }               
            }
            return instance;
        }
    }
}
