using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Media;

namespace latestfootasylumtest
{
    public enum Size
    {
        three = 1,
        four = 3,
        five = 5,
        six = 7,
        seven = 9,
        eight = 11,
        nine = 13,
        ten = 15,
        eleven = 17,
        twelve = 19,
        thirteen = 21,

        threeandhalf = 2,
        fourandhalf = 4,
        fiveandhalf = 6,
        sixandhalf = 8,
        sevenandhalf = 10,
        eightandhalf = 12,
        nineandhalf = 14,
        tenandhalf = 16,
        elevenandhalf = 18,
        twelveandhalf = 20,
        thirteenandhalf = 22,
    }

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

        private void CheckoutRoutine_Load(object sender, EventArgs e)
        {

        }

        public CheckoutRoutine(string footasylumATClink, string stylecode, string sizecode, string email, string password)
        {

            this.footasylumATClink = footasylumATClink;
            this.stylecode = stylecode;
            this.sizecode = sizecode;
            this.email = email;
            this.password = sizecode;

            bool carted = false;
            bool loggedin = false;

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

                    var oosscript = "document.querySelector('#container > div > div > div.plr3.align-center.nogpas > div').textContent";                    
                    string oosoutput = null;
                    oosoutput = await chromeBrowser.GetMainFrame().EvaluateScriptAsync(oosscript, new TimeSpan(0, 0, 5).ToString())
.ContinueWith(t =>
{
    var result = t.Result;
    if (result.Result == null)
        return "unable to pull HTML";
    else
        return result.Result.ToString();
});

                    SetText(oosoutput);

                    if (oosoutput.Contains("bag is currently empty"))
                    {
                        oosoutput = "RESET";
                        chromeBrowser.Load(footasylumATClink + stylecode + sizecode);
                    }
                    else
                    {
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
                    }
                    else if (currentAddress.Contains("https://secure.footasylum.com/"))
                    {
                        var script = "document.querySelector('#root > div > div.row.text-center.border-none.mobile-header.seven-header > div.col-sm-4.col-sm-offset-4.col-md-4.col-md-offset-4 > img').click()";
                        if (!loggedin)
                        {
                            loggedin = true;
                        }
                        else
                        {
                            script = @"
                            document.getElementById('customer_Email').click();document.getElementById('customer_Email').value = '" + email + "';";

                            TimeSpan diff = DateTime.Now.Subtract(localDate);
                            SetText("processed in " + diff.Seconds + " seconds");

                            if (!sentwebhook)
                            {

                                sentwebhook = true;
                                Invoke((MethodInvoker)delegate { Alert(); });

                                DiscordBot checkoutlink = new DiscordBot(ConfigurationManager.AppSettings["discordwebhook"], "Footasylum Checkout", "http://morgan.games/kraken/krakenbeta.png");

                                DiscordEmbedField style = new DiscordEmbedField(productname, stylecode);
                                DiscordEmbedField size = new DiscordEmbedField("Size code " + sizecode, "Size " + CheckGSSize(int.Parse(sizecode)));
                                DiscordEmbedField details = new DiscordEmbedField("Task took " + diff.Seconds + " seconds", "Checkout Now!");
                                DiscordEmbedField cart = new DiscordEmbedField("Checkout Link", "[Checkout Page](" + currentAddress + ")");

                                checkoutlink.SendDiscordWebHookEmbeded(
                                            productimg,
                                            "Kraken x Footasylum Checkout Link",
                                            currentAddress,
                                            style,
                                            size,
                                            details,
                                            cart);
                                SetText("sending discord webhook");
                            }
                        }                                             

                        chromeBrowser.ExecuteScriptAsyncWhenPageLoaded(script);

                        

                        script = @"
                            setTimeout(() => {  document.querySelector('#payPalButton').click(); }, 1000);
                            setTimeout(() => {  window.scrollTo(0, document.body.scrollHeight); }, 1000);
                        
";
                        chromeBrowser.ExecuteScriptAsyncWhenPageLoaded(script);
                        SetText("trying to checkout with paypal");


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
                }
            };
        }

        public ChromiumWebBrowser chromeBrowser;

        public void InitializeChromium()
        {
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

        private void Alert()
        {
            SetText("ALERT");
            string strExeFilePath = Assembly.GetExecutingAssembly().Location;
            string strWorkPath = Path.GetDirectoryName(strExeFilePath);
            SoundPlayer simpleSound = new SoundPlayer(Path.Combine(strWorkPath, "alert.wav"));
            simpleSound.Play();
            TopMost = true;
        }

        private string CheckGSSize(int code)
        {
            string checkedsize = "null";

            if (code == 2)
                checkedsize = "3";
            else if (code == 3)
                checkedsize = "3.5";
            else if (code == 4)
                checkedsize = "4";
            else if (code == 5)
                checkedsize = "4.5";
            else if (code == 6)
                checkedsize = "5";
            else if (code == 7)
                checkedsize = "5.5";
            else if (code == 8)
                checkedsize = "6";

            return checkedsize;
        }

        private string CheckSize(int code)
        {
            string checkedsize = "null";

            if (code == 1)
                checkedsize = "3";
            else if (code == 2)
                checkedsize = "3.5";
            else if (code == 3)
                checkedsize = "4";
            else if (code == 4)
                checkedsize = "4.5";
            else if (code == 5)
                checkedsize = "5";
            else if (code == 6)
                checkedsize = "5.5";
            else if (code == 7)
                checkedsize = "6";
            else if (code == 8)
                checkedsize = "6.5";
            else if (code == 9)
                checkedsize = "7";
            else if (code == 10)
                checkedsize = "7.5";
            else if (code == 11)
                checkedsize = "8";
            else if (code == 12)
                checkedsize = "8.5";
            else if (code == 13)
                checkedsize = "9";
            else if (code == 14)
                checkedsize = "9.5";
            else if (code == 15)
                checkedsize = "10";
            else if (code == 16)
                checkedsize = "10.5";
            else if (code == 17)
                checkedsize = "11";
            else if (code == 18)
                checkedsize = "11.5";
            else if (code == 19)
                checkedsize = "12";
            else if (code == 20)
                checkedsize = "12.5";
            else if (code == 21)
                checkedsize = "13";
            else if (code == 22)
                checkedsize = "13.5";
            else if (code == 23)
                checkedsize = "14";
            else if (code == 24)
                checkedsize = "14.5";

            return checkedsize;
        }
    }


    
}
