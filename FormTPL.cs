using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_sharp_thread
{
    public partial class FormTPL : Form
    {
        public FormTPL()
        {
            InitializeComponent();
        }
        public static double SumRootN(int root)
        {
            double result = 0;
            for (int i = 1; i < 10000000; i++)
            { result += Math.Exp(Math.Log(i) / root); }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            label1.Text = "Milliseconds: ";

            var watch = Stopwatch.StartNew();
            List<Task> tasks = new List<Task>();
            for (int i = 2; i < 20; i++)
            {
                int j = i;
                var t = Task.Factory.StartNew(() =>
                {
                    var result = SumRootN(j);
                    richTextBox1.Invoke(new Action(
                            () =>
                            richTextBox1.Text += "root " + j.ToString() + " "
                                  + result.ToString() + Environment.NewLine));
                });
                tasks.Add(t);
            }

            Task.Factory.ContinueWhenAll(tasks.ToArray(),
                  result =>
                  {
                      var time = watch.ElapsedMilliseconds;
                      label1.Invoke(new Action(() => label1.Text += time.ToString()));
                  });
        }

        //async void Update()
        //{
        //    var task = await Task.Run(() =>
        //    {
        //        return -1;
        //    });

        //    this.label1.Text = task.ToString();
        //}
    }
}
