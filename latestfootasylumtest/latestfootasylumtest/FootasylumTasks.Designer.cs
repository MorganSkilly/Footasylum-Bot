namespace latestfootasylumtest
{
    partial class FootasylumTasks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FootasylumTasks));
            this.button1 = new System.Windows.Forms.Button();
            this.style = new System.Windows.Forms.TextBox();
            this.size = new System.Windows.Forms.TextBox();
            this.stylelabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "run task";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // style
            // 
            this.style.Location = new System.Drawing.Point(115, 193);
            this.style.Name = "style";
            this.style.Size = new System.Drawing.Size(100, 20);
            this.style.TabIndex = 1;
            this.style.Tag = "";
            this.style.TextChanged += new System.EventHandler(this.style_TextChanged);
            // 
            // size
            // 
            this.size.Location = new System.Drawing.Point(115, 219);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(100, 20);
            this.size.TabIndex = 2;
            this.size.Tag = "";
            this.size.TextChanged += new System.EventHandler(this.size_TextChanged);
            // 
            // stylelabel
            // 
            this.stylelabel.AutoSize = true;
            this.stylelabel.Location = new System.Drawing.Point(51, 196);
            this.stylelabel.Name = "stylelabel";
            this.stylelabel.Size = new System.Drawing.Size(58, 13);
            this.stylelabel.TabIndex = 3;
            this.stylelabel.Text = "Style Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Size Code";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(99, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(127, 284);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "clear basket";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Basket must be clear before running tasks!";
            // 
            // FootasylumTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(311, 363);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stylelabel);
            this.Controls.Add(this.size);
            this.Controls.Add(this.style);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FootasylumTasks";
            this.Text = "FootasylumTasks";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FootasylumTasks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox style;
        private System.Windows.Forms.TextBox size;
        private System.Windows.Forms.Label stylelabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
    }
}