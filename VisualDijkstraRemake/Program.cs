using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

//[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace VisualDijkstraRemake
{
    static class Program
    {

        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ILoggerRepository logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            log4net.ILog logger = LogManager.GetLogger(typeof(Program));

            logger.Debug("Debug");
            logger.Error("Error");
            logger.Info("Info");
            logger.Warn("Warning");
            logger.Fatal("Fatal error");

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
