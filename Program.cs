using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_sharp_thread
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new FormBackgroundWorker());

            Application.Run(new FormTPL());
        }
    }

    class APM
    {
        static void Main(string[] args)
        {
            // 1. APM
            //Console.ReadKey();
            //AsyncromousDelegates();
            //Console.ReadKey();

            // 2. Thread Class
        }

#region  1 APM - Asynchromous Programming Model
        // Since at the beginning of .NET
        
        static async void BackgroundTask1(int p)
        {  
            for (int i = 0; i < p; i++)
            {
                Console.WriteLine($"task1 {i}");
                // Task.Delay(3 * 1000).Wait();
                await Task.Delay(3 * 1000); // for .Net 4.5
            }
        }
        static void BackgroundTask2(int p)
        {
            for (int i = 0; i < p; i++)
            {
                Console.WriteLine($" --------- task2 {i}");
                Task.Delay(500).Wait(); // 
            }
        }

        static void OnCompleted(IAsyncResult result)
        {
            Console.WriteLine("Done!");
            // Console.WriteLine(result);
            
        }

        static void AsyncromousDelegates()
        {
            Action<int> task1 = BackgroundTask1;            
            Action<int> task2 = BackgroundTask2;

            task1.BeginInvoke(10, OnCompleted, null);
            task2.BeginInvoke(13, OnCompleted, null);

            // Anonymous method with Action delegate
            //Action<int> task = delegate (int p) {
            //    for (int i = 0; i < p; i++)
            //    {
            //        Console.WriteLine(i);
            //    }
            //};
            //task.BeginInvoke(13, OnCompleted, null);
        }

        #endregion

        #region Thread Class
        //  Since at the beginning of .NET
        



        #endregion
    }
}
