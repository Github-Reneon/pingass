using System;
using System.Net.NetworkInformation;

namespace pingass
{
    internal class PingController
    {
        public static void Ping(string sender)
        {
            try
            {
                Ping ping = new Ping();
                PingReply pr = ping.Send(sender, 1000);
                if (pr != null)
                {
                    LogWriter.CreateLog("pingasslog.txt", pr.Status + " @ " + pr.Address + ": " + pr.RoundtripTime + "ms");
                    Console.WriteLine(pr.Status + " @ " + pr.Address + ": " + pr.RoundtripTime + "ms");
                }

            }
            catch
            {
                LogWriter.CreateLog("pingasslog.txt", "Error ping timout");
                Console.WriteLine("Error ping timout");
            }
        }
    }
}