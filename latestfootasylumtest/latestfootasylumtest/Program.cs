using System;
using System.Collections.Generic;
using System.Linq;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CheckoutRoutine("https://www.footasylum.com/page/xt_orderform_additem/?target=basket&sku=", "4033756", "7", "morganicfruit@gmail.com", "Penguin1"));
        }
    }
}
