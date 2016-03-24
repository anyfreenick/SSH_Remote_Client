namespace SSH_Remote_Client
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.fldLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fldPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fldIP = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.fldLog = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // fldLogin
            // 
            this.fldLogin.Location = new System.Drawing.Point(12, 25);
            this.fldLogin.Name = "fldLogin";
            this.fldLogin.Size = new System.Drawing.Size(100, 20);
            this.fldLogin.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // fldPass
            // 
            this.fldPass.Location = new System.Drawing.Point(12, 64);
            this.fldPass.Name = "fldPass";
            this.fldPass.Size = new System.Drawing.Size(100, 20);
            this.fldPass.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Server name or IP";
            // 
            // fldIP
            // 
            this.fldIP.Location = new System.Drawing.Point(12, 103);
            this.fldIP.Name = "fldIP";
            this.fldIP.Size = new System.Drawing.Size(100, 20);
            this.fldIP.TabIndex = 5;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 129);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Запуск";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // fldLog
            // 
            this.fldLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fldLog.Location = new System.Drawing.Point(118, 25);
            this.fldLog.Multiline = true;
            this.fldLog.Name = "fldLog";
            this.fldLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.fldLog.Size = new System.Drawing.Size(563, 525);
            this.fldLog.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Log";
            // 
            // btnGetLog
            // 
            this.btnGetLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetLog.Location = new System.Drawing.Point(118, 556);
            this.btnGetLog.Name = "btnGetLog";
            this.btnGetLog.Size = new System.Drawing.Size(105, 23);
            this.btnGetLog.TabIndex = 9;
            this.btnGetLog.Text = "Посмотреть лог";
            this.btnGetLog.UseVisualStyleBackColor = true;
            this.btnGetLog.Click += new System.EventHandler(this.btnGetLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 591);
            this.Controls.Add(this.btnGetLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fldLog);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.fldIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fldPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fldLogin);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fldLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fldPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fldIP;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox fldLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetLog;
    }
}

