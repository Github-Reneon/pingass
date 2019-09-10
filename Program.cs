using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace pingass
{
    internal class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;

        /* Bad implementation
         * To be fixed if can be asked
         */
        private static void Main(string[] args)
        {
            string addr = null;
        ASK:
            if (args.Length >= 1 || addr != null)
            {
                float time;

                try
                {
                    Console.Write("How many seconds for each ping?: ");
                    time = float.Parse(Console.ReadLine());
                }
                catch
                {
                    goto ASK;
                }
                if (args.Length >= 2)
                {
                    if (args[1] == "hide")
                    {
                        var handle = GetConsoleWindow();
                        // Hide window
                        ShowWindow(handle, SW_HIDE);
                    }
                }
                while (true)
                {
                    if (addr == null)
                    {
                        PingController.Ping(args[0]);
                    }
                    else
                    {
                        PingController.Ping(addr);
                    }
                    Thread.Sleep((int)(Math.Round(time * 1000)));
                }
            }
            else
            {
                Console.WriteLine("Where would you like to ping?");
                addr = Console.ReadLine();
                goto ASK;
            }
        }
    }
}
