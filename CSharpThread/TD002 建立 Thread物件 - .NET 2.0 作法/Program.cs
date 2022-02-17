using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TD002_建立_Thread物件___.NET_2._0_作法
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread1 = new Thread(delegate ()
            //{
            //    for (int i = 0; i < 500; i++)
            //    {
            //        Console.Write("*");
            //    }
            //});
            //Thread thread2 = new Thread(delegate (object message)
            //{
            //    for (int i = 0; i < 500; i++)
            //    {
            //        Console.Write(message.ToString());
            //    }
            //});

            #region .NET Framework 2.0 的非匿名委派用法
            Thread thread1 = new Thread(M1);
            Thread thread2 = new Thread(M2b);
            #endregion

            Console.WriteLine("將要休息五秒鐘，" +
                "觀察看看剛剛建立的兩個執行緒，是否有啟動");
            Thread.Sleep(5000);

            Console.WriteLine("現在要啟動執行兩個執行緒了");
            thread1.Start();
            // 要將引數傳入 ParameterizedThreadStart 委派方法內
            // 在 Start 方法中指定要傳入的引數
            thread2.Start("@");

            Thread.Sleep(3000);

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
        private static void M1()
        {
            for (int i = 0; i < 500; i++)
            {
                Console.Write("*");
            }
        }
        private static void M2(object message)
        {
            for (int i = 0; i < 500; i++)
            {
                Console.Write(message.ToString());
            }
        }
    }

}
