using System;
using System.IO;

namespace ASAM_Client.Model
{
    internal class MainFunctions
    {
        public static void Logger(string lines)
        {
            string path = @"C:\ASAM\Logs\";
            VerifyDir(path);
            string fileName = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".txt";
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(path + "ASAM_Client_CrashLogs " + fileName, true);
                file.WriteLine(DateTime.Now.ToString() + " : " + lines);
                file.Close();
            }
            catch (Exception) { }
        }

        public static void VerifyDir(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (!dir.Exists)
                {
                    dir.Create();
                }
            }
            catch { }
        }


    }

    
}
