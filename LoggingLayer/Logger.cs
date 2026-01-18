using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLayer
{
    public class Logger
    {
        private static readonly string _LogFilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "ClinicLog.txt");
        static Logger()
        {
            string Folder = Path.GetDirectoryName(_LogFilePath);
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }
        }
        public static void LogError(string Message, Exception ex)
        {
            try
            {
                using (StreamWriter Writer = new StreamWriter(_LogFilePath, true))
                {
                    Writer.WriteLine("_____ERROR_____");
                    Writer.WriteLine("Date: {0}", DateTime.Today.ToString("D"));
                    Writer.WriteLine("Time: {0}", DateTime.Now.ToString("T"));
                    Writer.WriteLine("Message: {0}", Message);
                    Writer.WriteLine("Exception: {0}", ex.Message);
                    Writer.WriteLine("Stack Trace: {0}\n", ex.StackTrace);
                }
            }
            catch
            {
                // If logging fails, we silently ignore to avoid crashing the application
            }
        }
        public static void LogInfo(string Message)
        {
            try
            {
                using (StreamWriter Writer = new StreamWriter(_LogFilePath, true))
                {
                    Writer.WriteLine("_____INFO_____");
                    Writer.WriteLine("Date: {0}", DateTime.Today.ToString("D"));
                    Writer.WriteLine("Time: {0}", DateTime.Now.ToString("T"));
                    Writer.WriteLine("Message: {0}\n", Message);
                }
            }
            catch
            {
                // If logging fails, we silently ignore to avoid crashing the application
            }
        }
        public static void LogWarning(string Message)
        {
            try
            {
                using (StreamWriter Writer = new StreamWriter(_LogFilePath, true))
                {
                    Writer.WriteLine("_____WARNING_____");
                    Writer.WriteLine("Date: {0}", DateTime.Today.ToString("D"));
                    Writer.WriteLine("Time: {0}", DateTime.Now.ToString("T"));
                    Writer.WriteLine("Message: {0}\n", Message);
                }
            }
            catch
            {
                // If logging fails, we silently ignore to avoid crashing the application
            }
        }
    }
}
