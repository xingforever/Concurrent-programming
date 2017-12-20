using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPL探密
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            string i1 = await F1Async();
            MessageBox.Show("i1=" + i1);
            string i2 = await F2Async();
            MessageBox.Show("i2=" + i2);
        }
        static Task<string> F1Async()
        {
            MessageBox.Show("F1 Start");
            return Task.Run(() => {
                System.Threading.Thread.Sleep(1000);
                MessageBox.Show("F1 Run");
                return "F1";
            });
        }
        static Task<string> F2Async()
        {
            MessageBox.Show("F2 Start");
            return Task.Run(() => {
                System.Threading.Thread.Sleep(2000);
                MessageBox.Show("F2 Run");
                return "F2";
            });
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Task<string> task1 = F1Async();
            Task<string> task2 = F2Async();
            string i1 = await task1;
            MessageBox.Show("i1=" + i1);
            string i2 = await task2;
            MessageBox.Show("i2=" + i2);
        }
    }
    
}
