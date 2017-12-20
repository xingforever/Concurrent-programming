using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform多线程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string html=string.Empty;
            ThreadPool.QueueUserWorkItem(state =>
            {

                WebClient webClient = new WebClient();
                 html = webClient.DownloadString("http://www.github.com");
                //把代码放入UI线程
                textBox1.BeginInvoke(new Action(() =>
                {
                    textBox1.Text = html; //主线程的控件只能有主线程操作
                }));
            });
            //或者
           

        }
    }
}
