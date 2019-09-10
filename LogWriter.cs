using System;
using System.IO;
using System.Net.NetworkInformation;

namespace pingass
{
    internal class LogWriter
    {
        public static void CreateLog(string filename, IPStatus status)
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
        public static void CreateLog(string filename, String status)
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

    }
}