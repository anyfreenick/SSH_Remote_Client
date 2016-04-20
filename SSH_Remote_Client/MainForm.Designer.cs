namespace SSH_Remote_Client
{
    partial class MainForm
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
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.fldLog = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.fldRemotePath = new System.Windows.Forms.TextBox();
            this.btnSrchFiles = new System.Windows.Forms.Button();
            this.lstFileList = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnRunSwagger = new System.Windows.Forms.Button();
            this.lblSwaggerInstalled = new System.Windows.Forms.Label();
            this.lblCurProgress = new System.Windows.Forms.Label();
            this.btnInstallSwagger = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pbInstall = new System.Windows.Forms.ProgressBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnDownloadFromRemote = new System.Windows.Forms.Button();
            this.btnUploadToRemote = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fldRemoteFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fldLocalFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstLocalFiles = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbProfile = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Location = new System.Drawing.Point(3, 65);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(121, 23);
            this.btnUploadFile.TabIndex = 6;
            this.btnUploadFile.Text = "Upload file";
            this.btnUploadFile.UseVisualStyleBackColor = true;
            // 
            // fldLog
            // 
            this.fldLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fldLog.Location = new System.Drawing.Point(128, 38);
            this.fldLog.Multiline = true;
            this.fldLog.Name = "fldLog";
            this.fldLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.fldLog.Size = new System.Drawing.Size(555, 454);
            this.fldLog.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Log";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 67);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(918, 526);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnUploadFile);
            this.tabPage1.Controls.Add(this.fldRemotePath);
            this.tabPage1.Controls.Add(this.btnSrchFiles);
            this.tabPage1.Controls.Add(this.lstFileList);
            this.tabPage1.Controls.Add(this.fldLog);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(910, 500);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "SSH";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(686, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Remote path";
            // 
            // fldRemotePath
            // 
            this.fldRemotePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fldRemotePath.Location = new System.Drawing.Point(689, 15);
            this.fldRemotePath.Name = "fldRemotePath";
            this.fldRemotePath.Size = new System.Drawing.Size(141, 20);
            this.fldRemotePath.TabIndex = 14;
            // 
            // btnSrchFiles
            // 
            this.btnSrchFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSrchFiles.Location = new System.Drawing.Point(689, 469);
            this.btnSrchFiles.Name = "btnSrchFiles";
            this.btnSrchFiles.Size = new System.Drawing.Size(99, 23);
            this.btnSrchFiles.TabIndex = 13;
            this.btnSrchFiles.Text = "Поиск файлов";
            this.btnSrchFiles.UseVisualStyleBackColor = true;
            // 
            // lstFileList
            // 
            this.lstFileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFileList.FormattingEnabled = true;
            this.lstFileList.HorizontalScrollbar = true;
            this.lstFileList.Location = new System.Drawing.Point(689, 38);
            this.lstFileList.Name = "lstFileList";
            this.lstFileList.Size = new System.Drawing.Size(215, 420);
            this.lstFileList.TabIndex = 12;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnRunSwagger);
            this.tabPage3.Controls.Add(this.lblSwaggerInstalled);
            this.tabPage3.Controls.Add(this.lblCurProgress);
            this.tabPage3.Controls.Add(this.btnInstallSwagger);
            this.tabPage3.Controls.Add(this.lblProgress);
            this.tabPage3.Controls.Add(this.pbInstall);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(910, 500);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "InstallSwagger";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnRunSwagger
            // 
            this.btnRunSwagger.Location = new System.Drawing.Point(11, 93);
            this.btnRunSwagger.Name = "btnRunSwagger";
            this.btnRunSwagger.Size = new System.Drawing.Size(115, 23);
            this.btnRunSwagger.TabIndex = 5;
            this.btnRunSwagger.Text = "Run Swagger";
            this.btnRunSwagger.UseVisualStyleBackColor = true;
            this.btnRunSwagger.Visible = false;
            // 
            // lblSwaggerInstalled
            // 
            this.lblSwaggerInstalled.AutoSize = true;
            this.lblSwaggerInstalled.Location = new System.Drawing.Point(8, 77);
            this.lblSwaggerInstalled.Name = "lblSwaggerInstalled";
            this.lblSwaggerInstalled.Size = new System.Drawing.Size(138, 13);
            this.lblSwaggerInstalled.TabIndex = 4;
            this.lblSwaggerInstalled.Text = "Swagger is not installed yet.";
            // 
            // lblCurProgress
            // 
            this.lblCurProgress.AutoSize = true;
            this.lblCurProgress.Location = new System.Drawing.Point(51, 35);
            this.lblCurProgress.Name = "lblCurProgress";
            this.lblCurProgress.Size = new System.Drawing.Size(0, 13);
            this.lblCurProgress.TabIndex = 3;
            // 
            // btnInstallSwagger
            // 
            this.btnInstallSwagger.Location = new System.Drawing.Point(8, 6);
            this.btnInstallSwagger.Name = "btnInstallSwagger";
            this.btnInstallSwagger.Size = new System.Drawing.Size(104, 23);
            this.btnInstallSwagger.TabIndex = 2;
            this.btnInstallSwagger.Text = "Install swagger";
            this.btnInstallSwagger.UseVisualStyleBackColor = true;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(5, 35);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(51, 13);
            this.lblProgress.TabIndex = 1;
            this.lblProgress.Text = "Progress:";
            this.lblProgress.Visible = false;
            // 
            // pbInstall
            // 
            this.pbInstall.Location = new System.Drawing.Point(8, 51);
            this.pbInstall.Name = "pbInstall";
            this.pbInstall.Size = new System.Drawing.Size(894, 23);
            this.pbInstall.Step = 1;
            this.pbInstall.TabIndex = 0;
            this.pbInstall.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(910, 500);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Jenkins";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.btnDownloadFromRemote);
            this.tabPage4.Controls.Add(this.btnUploadToRemote);
            this.tabPage4.Controls.Add(this.listBox2);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.fldRemoteFilePath);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.fldLocalFilePath);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.lstLocalFiles);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(910, 500);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Upload files to linux host";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnDownloadFromRemote
            // 
            this.btnDownloadFromRemote.Location = new System.Drawing.Point(403, 87);
            this.btnDownloadFromRemote.Name = "btnDownloadFromRemote";
            this.btnDownloadFromRemote.Size = new System.Drawing.Size(122, 23);
            this.btnDownloadFromRemote.TabIndex = 9;
            this.btnDownloadFromRemote.Text = "Download from remote";
            this.btnDownloadFromRemote.UseVisualStyleBackColor = true;
            // 
            // btnUploadToRemote
            // 
            this.btnUploadToRemote.Location = new System.Drawing.Point(403, 58);
            this.btnUploadToRemote.Name = "btnUploadToRemote";
            this.btnUploadToRemote.Size = new System.Drawing.Size(122, 23);
            this.btnUploadToRemote.TabIndex = 8;
            this.btnUploadToRemote.Text = "Upload to remote";
            this.btnUploadToRemote.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(203, 58);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(194, 485);
            this.listBox2.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Files on remote";
            // 
            // fldRemoteFilePath
            // 
            this.fldRemoteFilePath.Location = new System.Drawing.Point(203, 20);
            this.fldRemoteFilePath.Name = "fldRemoteFilePath";
            this.fldRemoteFilePath.Size = new System.Drawing.Size(194, 20);
            this.fldRemoteFilePath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Remote path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Files on local";
            // 
            // fldLocalFilePath
            // 
            this.fldLocalFilePath.Location = new System.Drawing.Point(3, 20);
            this.fldLocalFilePath.Name = "fldLocalFilePath";
            this.fldLocalFilePath.Size = new System.Drawing.Size(194, 20);
            this.fldLocalFilePath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local path";
            // 
            // lstLocalFiles
            // 
            this.lstLocalFiles.FormattingEnabled = true;
            this.lstLocalFiles.Items.AddRange(new object[] {
            ".."});
            this.lstLocalFiles.Location = new System.Drawing.Point(3, 58);
            this.lstLocalFiles.Name = "lstLocalFiles";
            this.lstLocalFiles.Size = new System.Drawing.Size(194, 485);
            this.lstLocalFiles.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Profile";
            // 
            // cmbProfile
            // 
            this.cmbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfile.FormattingEnabled = true;
            this.cmbProfile.Location = new System.Drawing.Point(4, 40);
            this.cmbProfile.Name = "cmbProfile";
            this.cmbProfile.Size = new System.Drawing.Size(121, 21);
            this.cmbProfile.Sorted = true;
            this.cmbProfile.TabIndex = 16;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(918, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(92, 22);
            this.tsmiExit.Text = "Exit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettings});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(116, 22);
            this.tsmiSettings.Text = "Settings";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(107, 22);
            this.tsmiAbout.Text = "About";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(403, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(503, 55);
            this.label8.TabIndex = 10;
            this.label8.Text = "Not implemented yet!!!";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(204, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(503, 55);
            this.label9.TabIndex = 11;
            this.label9.Text = "Not implemented yet!!!";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 593);
            this.Controls.Add(this.cmbProfile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.TextBox fldLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnSrchFiles;
        private System.Windows.Forms.ListBox lstFileList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fldRemotePath;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbProfile;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar pbInstall;
        private System.Windows.Forms.Button btnInstallSwagger;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnDownloadFromRemote;
        private System.Windows.Forms.Button btnUploadToRemote;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox fldRemoteFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fldLocalFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstLocalFiles;
        private System.Windows.Forms.Label lblCurProgress;
        private System.Windows.Forms.Button btnRunSwagger;
        private System.Windows.Forms.Label lblSwaggerInstalled;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}

