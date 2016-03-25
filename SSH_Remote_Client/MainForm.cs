using System;
using System.Windows.Forms;

namespace SSH_Remote_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fldLogin.Text = "root";
            fldPass.Text = "kronites";
        }

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
