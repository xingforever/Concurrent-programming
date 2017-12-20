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

namespace 异步下载三个网站
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            string html =await     webClient.DownloadStringTaskAsync(textBox1.Text);
            string html2 = await webClient.DownloadStringTaskAsync(textBox2.Text);
            string html3 = await webClient.DownloadStringTaskAsync(textBox3.Text);
            label1.Text = html.Length.ToString();
            label2.Text = html2.Length.ToString();
            label3.Text = html3.Length.ToString();
        }
    }
}
