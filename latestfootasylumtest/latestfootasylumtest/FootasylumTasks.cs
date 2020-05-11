using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace latestfootasylumtest
{
    public partial class FootasylumTasks : Form
    {
        private string stylecode = ConfigurationManager.AppSettings["stylecode"], sizecode = ConfigurationManager.AppSettings["sizecode"];

        public FootasylumTasks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();

            Thread t = new Thread(StartMyForm);
            t.TrySetApartmentState(ApartmentState.STA);
            t.Start();
            

            void StartMyForm()
            {
                Application.Run(new MultiFormContext(new CheckoutRoutine("https://www.footasylum.com/page/xt_orderform_additem/?target=basket&sku=", stylecode, sizecode, ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["password"])));
            }
        }

        private void size_TextChanged(object sender, EventArgs e)
        {
            sizecode = Text;
        }

        private void FootasylumTasks_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe", "https://www.footasylum.com/page/basket/");
        }

        private void style_TextChanged(object sender, EventArgs e)
        {
            stylecode = Text;
        }
    }

    public class MultiFormContext : ApplicationContext
    {
        private int openForms;
        public MultiFormContext(params Form[] forms)
        {
            openForms = forms.Length;

            foreach (var form in forms)
            {
                form.FormClosed += (s, args) =>
                {
                    //When we have closed the last of the "starting" forms, 
                    //end the program.
                    if (Interlocked.Decrement(ref openForms) == 0)
                        ExitThread();
                };

                form.Show();
            }
        }
    }
}
