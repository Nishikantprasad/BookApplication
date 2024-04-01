using System.ComponentModel;

namespace BookApplication.Services
{
    public class SingletonLoggingService
    {
        private static SingletonLoggingService _instance;
        private SingletonLoggingService() { }
        public static SingletonLoggingService GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SingletonLoggingService();
                }
                return _instance;
            }
        }
        public void Log(string message)
        {
            string logFilePath = "Logs/logfile.txt";

            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                writer.WriteLine(message);
            }
        }

    }
}