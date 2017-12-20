using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 异步编程模型
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += Wc_DownStringCompled;
            webClient.DownloadStringAsync(new Uri
                ("http://www.github.com"));

        }
        private void Wc_DownStringCompled(object sender, DownloadStringCompletedEventArgs e) {
        textBox1.Text=    e.Result;
        }
    }
}
