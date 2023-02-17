using System;
using System.Threading;
using static Server.File.Def.Server;

namespace Server
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Server";

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalErrorHandler);
            Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(GlobalErrorHandler);

            RunHost();

        }

        private static void GlobalErrorHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Console.WriteLine("A global error has occurred: " + ex.Message);
        }

    }
}
