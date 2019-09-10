using System;
using System.Net.NetworkInformation;
using System.Threading;

namespace pingass
{
    internal class Program
    {


        /* Bad implementation
         * To be fixed if can be asked
         */
        private static void Main(string[] args)
        {
            String addr = null;
        ASK:
            if (args.Length == 1 || addr != null)
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
                while (true)
                {
                    if (addr == null)
                    {
                        PingController.Ping(args[0]);
                    } else
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
