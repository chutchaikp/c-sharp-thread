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
        }

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
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(i * 10);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // New BackgroundWorker
            bgWorker1 = new BackgroundWorker();
            bgWorker1.WorkerReportsProgress = true;
            bgWorker1.WorkerSupportsCancellation = true;
            bgWorker1.DoWork += new DoWorkEventHandler(bgWorker1_DoWork);

            bgWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

            bgWorker1.ProgressChanged += new ProgressChangedEventHandler(bgWorker1_ProgressChanged);
            
            // Start the asynchronous operation.
            bgWorker1.RunWorkerAsync();
        }

        private void bgWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {   
            this.label2.Text = (e.ProgressPercentage.ToString() + "%");
            this.progressBar1.Value = e.ProgressPercentage;
        }
        private void bgWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.label3.Text = (e.ProgressPercentage.ToString() + "%");
        }

        // This event handler deals with the results of the background operation.
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                this.label1.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                this.label1.Text = "Error: " + e.Error.Message;
            }
            else
            {
                this.label1.Text = "Done!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
            {

            }
        }
}
