using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPL高级
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string cacheHtml;

        private  async void button1_Click(object sender, EventArgs e)
        {
            string html = await  GetRupengAsync();
            MessageBox.Show(html);
        }
        static async Task<string> GetRupengAsync()
        {

            if (cacheHtml!=null )
            {
                return cacheHtml;
            }
            else
            {
                HttpClient httpClient = new HttpClient();
                var msg = await httpClient.GetAsync("http://www.rupeng.com");
                string html = await msg.Content.ReadAsStringAsync();
                cacheHtml = html;
                return html;
            }
          
        }

        private  async void button2_Click(object sender, EventArgs e)
        {
            int i = await FlAsync();
            MessageBox.Show(i.ToString());
        }
       static Task<int> FlAsync()
        {
            return Task.Run(() =>
            {
                return 2;
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        static Task<int> F3Async()
        {
            //return Task.Run(() =>
            //{
            //    return 5;
            //});
            int i = 0;
            if (i==0)
            {
                Task.Delay(5000);//延迟5秒
            }
            return Task.FromResult(5);

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        //static Task<string>F5Async(){
        //    using (FileStream fs=File.OpenRead("1.txt"))
        //    {
        //        byte[] buff = new byte[50];
        //     IAsyncResult result=   fs.BeginRead(buff, 0, buff.Length, null, null);
        //        return Task.Factory.FromAsync(result, fs.EndRead);
        //    }
        //}
    }
}
