namespace latestfootasylumtest
{
    partial class CheckoutRoutine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Status = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Stop = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.URL = new System.Windows.Forms.Button();
            this.CCCVC = new System.Windows.Forms.Button();
            this.CCExp = new System.Windows.Forms.Button();
            this.CCNum = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Kill = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(10, 10);
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.Status.Size = new System.Drawing.Size(295, 120);
            this.Status.TabIndex = 4;
            this.Status.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Controls.Add(this.reload);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Stop);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Kill);
            this.panel1.Controls.Add(this.Status);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 288);
            this.panel1.TabIndex = 5;
            // 
            // reload
            // 
            this.reload.BackColor = System.Drawing.Color.SteelBlue;
            this.reload.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.reload.Location = new System.Drawing.Point(103, 195);
            this.reload.Name = "reload";
            this.reload.Size = new System.Drawing.Size(44, 57);
            this.reload.TabIndex = 12;
            this.reload.Text = "F5";
            this.reload.UseVisualStyleBackColor = false;
            this.reload.Click += new System.EventHandler(this.reload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pre Alpha Kraken Bot";
            // 
            // Stop
            // 
            this.Stop.BackColor = System.Drawing.Color.DimGray;
            this.Stop.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Stop.Location = new System.Drawing.Point(10, 195);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(90, 57);
            this.Stop.TabIndex = 11;
            this.Stop.Text = "STOP AUTOMATION";
            this.Stop.UseVisualStyleBackColor = false;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.URL);
            this.panel2.Controls.Add(this.CCCVC);
            this.panel2.Controls.Add(this.CCExp);
            this.panel2.Controls.Add(this.CCNum);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(156, 136);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(143, 137);
            this.panel2.TabIndex = 10;
            // 
            // URL
            // 
            this.URL.Location = new System.Drawing.Point(13, 107);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(118, 23);
            this.URL.TabIndex = 9;
            this.URL.Text = "Current URL";
            this.URL.UseVisualStyleBackColor = true;
            this.URL.Click += new System.EventHandler(this.URL_Click);
            // 
            // CCCVC
            // 
            this.CCCVC.Location = new System.Drawing.Point(13, 78);
            this.CCCVC.Name = "CCCVC";
            this.CCCVC.Size = new System.Drawing.Size(118, 23);
            this.CCCVC.TabIndex = 8;
            this.CCCVC.Text = "CC CVC";
            this.CCCVC.UseVisualStyleBackColor = true;
            this.CCCVC.Click += new System.EventHandler(this.CCCVC_Click);
            // 
            // CCExp
            // 
            this.CCExp.Location = new System.Drawing.Point(13, 53);
            this.CCExp.Name = "CCExp";
            this.CCExp.Size = new System.Drawing.Size(118, 23);
            this.CCExp.TabIndex = 7;
            this.CCExp.Text = "CC Expire";
            this.CCExp.UseVisualStyleBackColor = true;
            this.CCExp.Click += new System.EventHandler(this.CCExp_Click);
            // 
            // CCNum
            // 
            this.CCNum.Location = new System.Drawing.Point(13, 29);
            this.CCNum.Name = "CCNum";
            this.CCNum.Size = new System.Drawing.Size(118, 23);
            this.CCNum.TabIndex = 6;
            this.CCNum.Text = "CC Number";
            this.CCNum.UseVisualStyleBackColor = true;
            this.CCNum.Click += new System.EventHandler(this.CCNum_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "COPY TO CLIPBOARD";
            // 
            // Kill
            // 
            this.Kill.BackColor = System.Drawing.Color.DarkRed;
            this.Kill.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Kill.Location = new System.Drawing.Point(10, 136);
            this.Kill.Name = "Kill";
            this.Kill.Size = new System.Drawing.Size(137, 57);
            this.Kill.TabIndex = 9;
            this.Kill.Text = "KILL TASK";
            this.Kill.UseVisualStyleBackColor = false;
            this.Kill.Click += new System.EventHandler(this.Kill_Click);
            // 
            // CheckoutRoutine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 639);
            this.Controls.Add(this.panel1);
            this.Name = "CheckoutRoutine";
            this.Text = "Kraken x Footasylum Checkout Routine";
            this.Load += new System.EventHandler(this.CheckoutRoutine_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox Status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button URL;
        private System.Windows.Forms.Button CCCVC;
        private System.Windows.Forms.Button CCExp;
        private System.Windows.Forms.Button CCNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Kill;
        private System.Windows.Forms.Button reload;
    }
}

