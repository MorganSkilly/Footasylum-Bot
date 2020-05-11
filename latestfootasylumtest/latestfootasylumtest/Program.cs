using CefSharp;
using CefSharp.WinForms;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace latestfootasylumtest
{

    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CefSettings settings = new CefSettings();
            settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF";
            Cef.Initialize(settings);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FootasylumTasks());
            //Application.Run(new CheckoutRoutine("https://www.footasylum.com/page/xt_orderform_additem/?target=basket&sku=", ConfigurationManager.AppSettings["stylecode"], ConfigurationManager.AppSettings["sizecode"], ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["password"]));

            

        }

    }
}
