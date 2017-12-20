using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace HttpClientss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async  void button1_Click(object sender, EventArgs e)
        {
            System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            string html = await httpClient.GetStringAsync("http://www.baidu.com");

        }

        private  async void button2_Click(object sender, EventArgs e)
        {
            System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            List<KeyValuePair<string,string>> parmters = new List<System.Collections.Generic.KeyValuePair<string, string>>();
            parmters.Add(new KeyValuePair<string, string>("userName", "admin"));
            parmters.Add(new KeyValuePair<string, string>("password", "123"));
            FormUrlEncodedContent content = new FormUrlEncodedContent(parmters);

          HttpResponseMessage msg=await   httpClient.PostAsync("http://localhost:8011/Home/Login", content);
            //msg.content
            //msg.header
            MessageBox.Show("响应码"+msg.StatusCode);//响应码
            string htmld = await msg.Content.ReadAsStringAsync();
            MessageBox.Show("内容" + htmld);

                
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            string json = "{userName:'admin',password:'123'}";
            StringContent content = new StringContent(json);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            HttpResponseMessage msg = await httpClient.PostAsync("http://localhost:8011/Home/Login2", content);
            MessageBox.Show(msg.StatusCode.ToString());
           string html =await   msg.Content.ReadAsStringAsync();
            MessageBox.Show("内容" + html);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent content = new MultipartFormDataContent();
            content.Headers.Add("userName", "admin");
            content.Headers.Add("password", "123");
            using (Stream stream = File.OpenRead(@"有趣三维.gif"))
            {
                content.Add(new StreamContent(stream), "file", "logo.png");
                var respMsg = await httpClient.PostAsync("http://127.0.0.1:8011/Home/Upload/", content);
                string msgBody = await respMsg.Content.ReadAsStringAsync();
                MessageBox.Show(respMsg.StatusCode.ToString());
                MessageBox.Show(msgBody);
            }
        }
    }
}
