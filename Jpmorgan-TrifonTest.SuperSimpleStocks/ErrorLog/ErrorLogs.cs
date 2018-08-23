using System;
using System.IO;
using System.Text;

namespace Jpmorgan_TrifonTest.SuperSimpleStocks.ErrorLog
{
    public static class ErrorLogs
    {
        public static string ErrorMessage(Exception exception)
        {
            StringBuilder message = new StringBuilder();

            try
            {
                message.Append("Exception: ");

                message.Append(DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss") + " " +exception);
                if (exception.InnerException != null)
                {
                    message.Append(DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss") + " " +exception.InnerException);
                }
                return message.ToString();
            }
            catch
            {
                message.Append("Unknown Exception.");
                return message.ToString();
            }

        }

        public static void CreateLogFile(string message)
        {
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {
                string filePath = @"c:\Logs\";

                filePath = filePath + "jpmorganLog" + "-" + DateTime.Today.ToString("dd-MM-yyyy") + "." + "txt";

                if (filePath.Equals("")) return;
                FileInfo logInfo = new FileInfo(filePath);
                DirectoryInfo dirInfo = new DirectoryInfo(logInfo.DirectoryName ?? throw new InvalidOperationException());
                if (!dirInfo.Exists) dirInfo.Create();

                fileStream = !logInfo.Exists ? logInfo.Create() : new FileStream(filePath, FileMode.Append);
                streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(message);
            }
            finally
            {
                streamWriter?.Close();
                fileStream?.Close();
            }

        }
    }
}
