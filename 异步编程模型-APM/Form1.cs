using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 异步编程模型_APM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            ThreadPool.QueueUserWorkItem((state) =>
            {
                //同步方法: 做完才返回
                //异步方法:启动一件事 然后返回 
            using (FileStream fs = File.OpenRead("1.txt"))
            {
                byte[] butt = new byte[20];
                IAsyncResult result = fs.BeginRead(butt, 0, butt.Length, null, null);
                result.AsyncWaitHandle.WaitOne
                    ();
                string s = Encoding.UTF8.GetString(butt);
                fs.EndRead(result);
                textBox1.BeginInvoke(new Action(()=>{
                    textBox1.Text = s;
                }));
                };
            });
           
        }
    }
}
