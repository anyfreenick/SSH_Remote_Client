using System;
using SSH_Remote_Client.BL;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SSH_Remote_Client
{
    public interface IMainForm
    {
        string UserName { get; }
        string Passwd { get; }
        string HostName { get; }
        string Log { get; set; }
        string RemotePath { get; }
        void AddItemToList(object item);

        //events
        event EventHandler FileUploadClick;
        event EventHandler SearchFilesClick;
        event EventHandler ShowLogClick;
        event EventHandler ListBoxItemDoubleClick;
    }

    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            btnUploadFile.Click += BtnUploadFile_Click;
            btnSrchFiles.Click += BtnSrchFiles_Click;
            btnGetLog.Click += BtnGetLog_Click;
            lstFileList.MouseDoubleClick += LstFileList_MouseDoubleClick;
        }

        #region Проброс событий
        private void BtnUploadFile_Click(object sender, EventArgs e)
        {
            if (FileUploadClick != null) FileUploadClick(this, EventArgs.Empty);
        }

        private void BtnSrchFiles_Click(object sender, EventArgs e)
        {
            if (SearchFilesClick != null) SearchFilesClick(this, EventArgs.Empty);
        }

        private void BtnGetLog_Click(object sender, EventArgs e)
        {
            if (ShowLogClick != null) ShowLogClick(this, EventArgs.Empty);
        }

        private void LstFileList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListBoxItemDoubleClick != null) ListBoxItemDoubleClick(this, EventArgs.Empty);
        }

        #endregion

        #region Реализация интерфейса IMainForm
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

        public string RemotePath
        {
            get { return fldRemotePath.Text; }
        }

        public void AddItemToList(object item)
        {
            lstFileList.Items.Add(item);
        }

        public event EventHandler FileUploadClick;
        public event EventHandler SearchFilesClick;
        public event EventHandler ShowLogClick;
        public event EventHandler ListBoxItemDoubleClick;
        #endregion
    }
}
