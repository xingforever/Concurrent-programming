using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 异步编程TPL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FileStream fs = File.OpenRead("1.txt"))
            {
                byte[] buffer = new byte[16];
                Task<int> task = fs.ReadAsync(buffer, 0, buffer.Length);
                task.Wait();
                MessageBox.Show("读取了" + task.Result + "个字节");
                MessageBox.Show(Encoding.UTF8.GetString(buffer));
            } 
           
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (FileStream fs = File.OpenRead("1.txt"))
            {
                byte[] buffer = new byte[16];
               await fs.ReadAsync(buffer, 0, buffer.Length);
                string s = Encoding.UTF8.GetString(buffer);
                this.textBox1.Text = s;


              
            }
        }
    }
}
