﻿using System;
using System.Windows.Forms;

namespace SSH_Remote_Client
{
    public interface IMainForm
    {
        string UserName { get; }
        string Passwd { get; }
        string HostName { get; }
        string Log { get; set; }
    }

    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            fldLogin.Text = "root";
            fldPass.Text = "kronites";
        }

        #region Реализация интерфейса
        public string UserName
        {
            get { return fldLogin.Text; }
        }

        public string Passwd
        {
            get { return fldPass.Text; }
        }

        public string HostName
        {
            get { return fldIP.Text; }
        }

        public string Log
        {
            get { return fldLog.Text; }
            set { fldLog.Text = value; }
        }
        #endregion

        private void btnStart_Click(object sender, EventArgs e)
        {
            SSH_Remote_Client.BL.ServerManager.copyFileToServer("script.sh", fldIP.Text, fldLogin.Text, fldPass.Text);
            SSH_Remote_Client.BL.ServerManager.runCommandOnServer(fldIP.Text, fldLogin.Text, fldPass.Text);
        }

        private void btnGetLog_Click(object sender, EventArgs e)
        {
            fldLog.Clear();
            string log = SSH_Remote_Client.BL.ServerManager.getLog(fldIP.Text, fldLogin.Text, fldPass.Text);
            if (log == "")
                MessageBox.Show("Log is empty");
            else
                fldLog.Text = SSH_Remote_Client.BL.ServerManager.getLog(fldIP.Text, fldLogin.Text, fldPass.Text);
        }
    }
}
