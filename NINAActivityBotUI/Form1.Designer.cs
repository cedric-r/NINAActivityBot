namespace NINAActivityBotUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBox1SocialNetName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1SocialNetServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSocialUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNINABaseURL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMonitorIageURL = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(140, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 0;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBox1SocialNetName
            // 
            this.textBox1SocialNetName.Location = new System.Drawing.Point(115, 52);
            this.textBox1SocialNetName.Name = "textBox1SocialNetName";
            this.textBox1SocialNetName.Size = new System.Drawing.Size(100, 23);
            this.textBox1SocialNetName.TabIndex = 2;
            this.textBox1SocialNetName.TextChanged += new System.EventHandler(this.textBox1SocialNetName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Social network:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server:";
            // 
            // textBox1SocialNetServer
            // 
            this.textBox1SocialNetServer.Location = new System.Drawing.Point(115, 81);
            this.textBox1SocialNetServer.Name = "textBox1SocialNetServer";
            this.textBox1SocialNetServer.Size = new System.Drawing.Size(100, 23);
            this.textBox1SocialNetServer.TabIndex = 4;
            this.textBox1SocialNetServer.TextChanged += new System.EventHandler(this.textBox1SocialNetServer_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Username:";
            // 
            // textBoxSocialUsername
            // 
            this.textBoxSocialUsername.Location = new System.Drawing.Point(115, 110);
            this.textBoxSocialUsername.Name = "textBoxSocialUsername";
            this.textBoxSocialUsername.Size = new System.Drawing.Size(100, 23);
            this.textBoxSocialUsername.TabIndex = 6;
            this.textBoxSocialUsername.TextChanged += new System.EventHandler(this.textBoxSocialUsername_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(115, 139);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(100, 23);
            this.textBoxPassword.TabIndex = 8;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "NINA base URL:";
            // 
            // textBoxNINABaseURL
            // 
            this.textBoxNINABaseURL.Location = new System.Drawing.Point(115, 168);
            this.textBoxNINABaseURL.Name = "textBoxNINABaseURL";
            this.textBoxNINABaseURL.Size = new System.Drawing.Size(100, 23);
            this.textBoxNINABaseURL.TabIndex = 10;
            this.textBoxNINABaseURL.TextChanged += new System.EventHandler(this.textBoxNINABaseURL_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Monitor URL:";
            // 
            // textBoxMonitorIageURL
            // 
            this.textBoxMonitorIageURL.Location = new System.Drawing.Point(115, 197);
            this.textBoxMonitorIageURL.Name = "textBoxMonitorIageURL";
            this.textBoxMonitorIageURL.Size = new System.Drawing.Size(100, 23);
            this.textBoxMonitorIageURL.TabIndex = 12;
            this.textBoxMonitorIageURL.TextChanged += new System.EventHandler(this.textBoxMonitorIageURL_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 235);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxMonitorIageURL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxNINABaseURL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSocialUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1SocialNetServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1SocialNetName);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonStop);
            this.Name = "Form1";
            this.Text = "NINA Activity Bot";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonStop;
        private Button buttonStart;
        private TextBox textBox1SocialNetName;
        private Label label1;
        private Label label2;
        private TextBox textBox1SocialNetServer;
        private Label label3;
        private TextBox textBoxSocialUsername;
        private Label label4;
        private TextBox textBoxPassword;
        private Label label5;
        private TextBox textBoxNINABaseURL;
        private Label label6;
        private TextBox textBoxMonitorIageURL;
    }
}