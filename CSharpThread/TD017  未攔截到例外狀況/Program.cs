namespace TD017__未攔截到例外狀況
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 這裡程式碼將會捕捉到沒有被程式碼攔截到的例外異常
            AppDomain appDomain = AppDomain.CurrentDomain;
            appDomain.UnhandledException += (s, e) =>
            {
                Console.WriteLine($"接收到 未攔截例外狀況的通知");
                Exception exception = e.ExceptionObject as Exception;
                Console.WriteLine($" > 例外異常訊息 : {exception.Message}");
                Console.WriteLine($" > 當時呼叫堆疊 : {exception.StackTrace}");
            };
            #endregion

            Console.WriteLine($"啟動一個非同步執行緒");
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine($"   非同步委派方法開始執行");
                Task.Delay(3000).Wait();
                Console.WriteLine($"   模擬呼叫的 API 拋出例外異常");
                throw new Exception("喔喔，發生不明的錯誤");
                Console.WriteLine($"   非同步委派方法結束執行");
            });
            Console.WriteLine($"等候5秒鐘");
            Thread.Sleep(5000);

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}