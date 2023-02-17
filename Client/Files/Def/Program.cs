using System;
using System.Threading;
using System.Windows.Forms;

namespace Client.Files.Def
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalErrorHandler);
            Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(GlobalErrorHandler);
            Application.Run(new Client.Menu.Forms.MainForm());
        }

        private static void GlobalErrorHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            MessageBox.Show(ex.Message,"Global error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
