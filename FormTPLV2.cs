using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_sharp_thread
{
    public partial class FormTPLV2 : Form
    {
        TaskScheduler uiScheduler;
        public FormTPLV2()
        {
            InitializeComponent();
            uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        CancellationTokenSource src;
        
        void UpdateUI(Post post)
        {
            Task.Factory.StartNew(
                () => {
                    this.labelPost.Text = post.title;
                }, CancellationToken.None, TaskCreationOptions.None, uiScheduler);
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            try
            {
                src = new CancellationTokenSource();
                CancellationToken ct = src.Token;
                ct.Register(() => Console.WriteLine("Abbruch des Tasks"));

                while (true)
                {
                    Task.Run(
                    () =>
                    {
                        Task.Delay(3000).Wait();

                        ct.ThrowIfCancellationRequested();

                        Random random = new Random(13);
                        var id = random.Next(1, 100);

                        // do request 
                        string html = string.Empty;
                        string url = @"https://jsonplaceholder.typicode.com/posts/" + id;
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        request.AutomaticDecompression = DecompressionMethods.GZip;
                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        using (Stream stream = response.GetResponseStream())
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            html = reader.ReadToEnd();
                        }
                        // return html;

                        var post = JsonHelper.JsonDeserialize<Post>(html);
                        UpdateUI(post);

                    }, ct);
                    //.ContinueWith((cw) =>
                    //{
                    //    var post = JsonHelper.JsonDeserialize<Post>(cw.Result);
                    //    UpdateUI(post);
                    //    Thread.Sleep(3000);
                    //}, ct);


                    Thread.Sleep(10 * 1000);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            src.Cancel();
        }
    }
}
