using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_sharp_thread
{
    public partial class FormBackgroundWorker : Form
    {
        BackgroundWorker bgWorker1;
        BackgroundWorker bgWorker2;

        public FormBackgroundWorker()
        {
            InitializeComponent();

            bgWorker1 = new BackgroundWorker();
            bgWorker1.WorkerReportsProgress = true;
            bgWorker1.WorkerSupportsCancellation = true;
            bgWorker1.DoWork += new DoWorkEventHandler(bgWorker1_DoWork);
            bgWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker1_RunWorkerCompleted);
            bgWorker1.ProgressChanged += new ProgressChangedEventHandler(bgWorker1_ProgressChanged);


            bgWorker2 = new BackgroundWorker();
            bgWorker2.WorkerReportsProgress = true;
            bgWorker2.WorkerSupportsCancellation = true;
            bgWorker2.DoWork += new DoWorkEventHandler(bgWorker2_DoWork);
            bgWorker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker2_RunWorkerCompleted);
            bgWorker2.ProgressChanged += new ProgressChangedEventHandler(bgWorker2_ProgressChanged);
            
        }

        // random 200 - 1000
        //static int RandomNumber(int min, int max)
        //{
        //    Random random = new Random();
        //    var result = random.Next(min, max);
        //    return result * 100;
        //}

        private void bgWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 1; i <= 10; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(400);
                    worker.ReportProgress(i * 10);
                }
            }
        }
        private void bgWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 1; i <= 10; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(800);
                    worker.ReportProgress(i * 10);
                }
            }
        }

        void Reset()
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            this.progressBar1.ResetText();
            this.progressBar2.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // New BackgroundWorker
            Reset();

            // Start the asynchronous operation.
            bgWorker1.RunWorkerAsync();
            bgWorker2.RunWorkerAsync();
        }

        private void bgWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.label2.Text = (e.ProgressPercentage.ToString() + "%");
            this.progressBar1.Value = e.ProgressPercentage;
        }
        private void bgWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.label3.Text = (e.ProgressPercentage.ToString() + "%");
            this.progressBar2.Value = e.ProgressPercentage;
        }

        // This event handler deals with the results of the background operation.
        private void bgWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                this.label2.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                this.label2.Text = "Error: " + e.Error.Message;
            }
            else
            {
                this.label2.Text = "Done!";
            }
        }
        private void bgWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                this.label3.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                this.label3.Text = "Error: " + e.Error.Message;
            }
            else
            {
                this.label3.Text = "Done!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bgWorker1.CancelAsync();
                bgWorker2.CancelAsync();
            }
            catch (Exception)
            {
                
            }            
        }
    }
}
