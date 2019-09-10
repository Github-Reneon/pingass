using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;

namespace pingass
{
    class Program
    {

        private static void CreateLog(string filename, IPStatus status)
        {
            try
            {
                StreamWriter file = new StreamWriter(filename, true);
                DateTime now = DateTime.Now;
                file.WriteLine("[" + now.ToString() + "]: " + status);
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private static void CreateLog(string filename, String status)
        {
            try
            {
                StreamWriter file = new StreamWriter(filename, true);
                DateTime now = DateTime.Now;
                file.WriteLine("[" + now.ToString() + "]: " + status);
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void ping(string sender)
        {
            try
            {
                Ping ping = new Ping();
                PingReply pr = ping.Send(sender, 1000);
                if (pr != null)
                {
                    CreateLog("pingasslog.txt", pr.Status);
                    Console.WriteLine(pr.Status);
                }

            }
            catch
            {
                CreateLog("pingasslog.txt", "Error ping timout");
                Console.WriteLine("Error ping timout");
            }
        }

        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                float time = 1f;
                ASK:
                try
                {
                    Console.Write("How many seconds for each ping?: ");
                     time = float.Parse(Console.ReadLine());
                } catch
                {
                    goto ASK;
                }
                while (true)
                {
                    ping(args[0]);
                    Thread.Sleep((int)(Math.Round(time * 1000)));
                }
            }
        }
    }
}
