using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Configuration;

namespace latestfootasylumtest
{
    public partial class CheckoutRoutine : Form
    {        
        string footasylumATClink, stylecode, sizecode, email, password, productname, productimg;
        bool autoEnabled = true;

        DateTime localDate;
        

        private void Kill_Click(object sender, EventArgs e)
        {
            this.Close();
            SetText("KILLING TASK...");
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            autoEnabled = false;
            SetText("STOPPING AUTOMATION...");
        }

        private void URL_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(chromeBrowser.Address);
        }

        private void CCNum_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(ConfigurationManager.AppSettings["ccnum"]);
        }

        private void CCExp_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(ConfigurationManager.AppSettings["ccexp"]);
        }

        private void CCCVC_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(ConfigurationManager.AppSettings["cccvc"]);
        }

        private void reload_Click(object sender, EventArgs e)
        {
            chromeBrowser.Reload(true);
        }

        public CheckoutRoutine(string footasylumATClink, string stylecode, string sizecode, string email, string password)
        {

            this.footasylumATClink = footasylumATClink;
            this.stylecode = stylecode;
            this.sizecode = sizecode;
            this.email = email;
            this.password = sizecode;

            bool carted = false;

            InitializeComponent();
            InitializeChromium();
            
            bool sentwebhook = false;

            localDate = DateTime.Now;
            SetText("TIMESTAMP" + localDate.ToString());
            
            chromeBrowser.FrameLoadEnd += async (sender, args) =>
            {
                var currentAddress = chromeBrowser.Address;
                SetText("loaded page: " + currentAddress);

                if (autoEnabled)
                {                    
                    Console.WriteLine(currentAddress);
                    
                    if (!carted)
                    {
                        carted = true;
                        SetText("item added to cart");

                        var script = @"
                            document.querySelector('#container > div > div.bsktcontainer.nogaps.mtb2 > div.bsktmain > div.bsktitemcontainer > div > div > div > span').click()";
                        chromeBrowser.ExecuteScriptAsyncWhenPageLoaded(script);
                    }
                    else if (currentAddress.Contains("https://www.footasylum.com/page/login/"))
                    {
                        var script = @"
                            document.getElementById('email1').value = '" + email + "'; document.getElementById('passwordOnSignIn').value = '" + password + "'; document.getElementById('mainLogin').submit();";
                        chromeBrowser.ExecuteScriptAsyncWhenPageLoaded(script);

                        SetText("logging in");
                    }
                    else if (currentAddress.Contains("https://www.footasylum.com/page/basket/") && carted)
                    {
                        var testscript = "document.querySelector('div.nogaps > div.nogaps > div:nth-child(1) > div > div.pf_name > a > span:nth-child(2)').textContent";
                        string output = null;
                        output = await chromeBrowser.GetMainFrame().EvaluateScriptAsync(testscript, new TimeSpan(0,0,5).ToString())
    .ContinueWith(t =>
    {
        var result = t.Result;
        if (result.Result == null)
            return "unable to pull HTML";
        else
            return result.Result.ToString();
    });
                        SetText("Pulled HTML - " + output);
                        productname = output;

                        testscript = "document.querySelector('#container > div > div.bsktcontainer.nogaps.mtb2 > div.bsktmain > div.bsktitemcontainer > form > div:nth-child(1)').firstElementChild.firstElementChild.firstElementChild.src";
                        output = null;
                        output = await chromeBrowser.GetMainFrame().EvaluateScriptAsync(testscript, new TimeSpan(0, 0, 5).ToString())
    .ContinueWith(t =>
    {
        var result = t.Result;
        if (result.Result == null)
            return "unable to pull HTML";
        else
            return result.Result.ToString();
    });
                        SetText("Pulled HTML - " + output);
                        productimg = output;

                        var script = @"
                            NWSubmit();gaPushLayer(1);
                        ";
                        chromeBrowser.ExecuteScriptAsyncWhenPageLoaded(script);

                        SetText("checking out");

                        sentwebhook = false;
                    }
                    else if (currentAddress.Contains("https://secure.footasylum.com/"))
                    {
                        var script = @"
                            document.getElementById('customer_Email').click();document.getElementById('customer_Email').value = '" + email + "';";

                        chromeBrowser.ExecuteScriptAsyncWhenPageLoaded(script);

                        TimeSpan diff = DateTime.Now.Subtract(localDate);
                        SetText("processed in " + diff.Seconds + " seconds");

                        if (!sentwebhook)
                        {
                            DiscordBot checkoutlink = new DiscordBot("https://discordapp.com/api/webhooks/686768082429149186/p8KqcdkS3gRasGPZXYCwbdg74-nlkX0zX8mLCQwwvNy4BKt5K8vRTjOTn3ldkm16eEoH", "Footasylum Checkout", "http://morgan.games/kraken/krakenbeta.png");

                            DiscordEmbedField style = new DiscordEmbedField(productname, stylecode);
                            DiscordEmbedField size = new DiscordEmbedField("Size code " + sizecode, "Size " + "Unknown");
                            DiscordEmbedField details = new DiscordEmbedField("Task took " + diff.Seconds + " seconds", "Checkout Now!");
                            DiscordEmbedField cart = new DiscordEmbedField("Checkout Link", "[Checkout Page](" + currentAddress + ")");

                            checkoutlink.SendDiscordWebHookEmbeded(
                                        productimg,
                                        "This is a test",
                                        currentAddress,
                                        style,
                                        size,
                                        details,
                                        cart);
                            sentwebhook = true;
                            SetText("sending discord webhook");

                            script = @"
                            setTimeout(() => {  document.querySelector('#payPalButton').click(); }, 1000);
                            setTimeout(() => {  window.scrollTo(0, document.body.scrollHeight); }, 1000);
                        
";
                            chromeBrowser.ExecuteScriptAsyncWhenPageLoaded(script);
                            SetText("trying to checkout with paypal");
                        }




                        this.Invoke((MethodInvoker)delegate
                        {
                            this.Activate();
                        });
                    }
                    else if (!currentAddress.Contains("/page/basket") || !currentAddress.Contains("/page/payment") || !currentAddress.Contains("/page/login"))
                    {
                        var script = @"
                            window.location.href = 'https://www.footasylum.com/page/payment/';
                        ";
                        chromeBrowser.ExecuteScriptAsyncWhenPageLoaded(script);
                    }
                }
            };
        }

        public ChromiumWebBrowser chromeBrowser;

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            settings.CachePath = AppDomain.CurrentDomain.BaseDirectory + "cache";

            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser(footasylumATClink + stylecode + sizecode);
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.Status.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (!Status.IsDisposed)
                {
                    this.Status.Text += text + "\n";
                    this.Status.SelectionStart = this.Status.Text.Length;
                    this.Status.ScrollToCaret();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }


    
}
