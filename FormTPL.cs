using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_sharp_thread
{
    public partial class FormTPL : Form
    {
        TaskScheduler uiScheduler;
        public FormTPL()
        {
            InitializeComponent();

            uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }
       
        void UpdateUI(User user)
        {
            Task.Factory.StartNew(
                () => {
                    this.labelUser.Text = user.email;
                }, CancellationToken.None, TaskCreationOptions.None, uiScheduler);
        }

        void UpdateUI(Post post)
        {
            Task.Factory.StartNew(
                () => {
                    this.labelPost.Text = post.title;
                }, CancellationToken.None, TaskCreationOptions.None, uiScheduler);

        }

        private void buttonUser_Click(object sender, EventArgs e)
        {
            BusinessLayer2.ProcessUserData(13, (users) => {
                foreach (var user in users)
                {
                    UpdateUI(user);
                    Task.Delay(800).Wait();
                }
            });
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            BusinessLayer2.ProcessPostData(13, (posts) => {
                foreach (var post in posts)
                {
                    UpdateUI(post);
                    Task.Delay(1000).Wait();
                }
            });
        }

        private void buttonCancelUser_Click(object sender, EventArgs e)
        {

        }
    }
}
