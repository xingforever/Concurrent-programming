using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 线程的终止
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread t1;
        private void button1_Click(object sender, EventArgs e)
        {

           t1  = new Thread(() =>
              {
                  try
                  {
                      while (true)
                      {
                          MessageBox.Show("hello");
                          Thread.Sleep(1000);
                      }
                  }
                  catch (ThreadAbortException ex)
                  {

                      MessageBox.Show(ex.ToString());
                  
                  }
                 
              });
            t1.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            t1.Abort();
        }
    }
}
