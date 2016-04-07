using System;
using System.Windows.Forms;

namespace SSH_Remote_Client
{
    public interface IMainForm
    {
        // properties
        string Log { get; set; }
        string RemotePath { get; set; }
        string SelectedItem { get; }
        string Profile { get; }
        int SelectedProfile { get; set; }

        // methods
        void AddItemToList(object item);
        void ClearListBox();
        void ClearProfiles();
        void AddProfile(string profileName);

        // events
        event EventHandler FileUploadClick;
        event EventHandler SearchFilesClick;
        event EventHandler ListBoxItemDoubleClick;
        event EventHandler ToolStripMenuAboutClick;
        event EventHandler ToolStripMenuSettingsClick;
        event EventHandler SelectedProfileChanged;
        event EventHandler ProfileClick;
    }

    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();

            btnUploadFile.Click += BtnUploadFile_Click;
            btnSrchFiles.Click += BtnSrchFiles_Click;
            lstFileList.MouseDoubleClick += LstFileList_MouseDoubleClick;
            tsmiSettings.Click += TsmiSettings_Click;
            tsmiAbout.Click += TsmiAbout_Click;
            tsmiExit.Click += TsmiExit_Click;
            fldRemotePath.KeyPress += FldRemotePath_KeyPress1;
            cmbProfile.SelectedIndexChanged += CmbProfile_SelectedIndexChanged;
            cmbProfile.Click += CmbProfile_Click;
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

        private void LstFileList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListBoxItemDoubleClick != null) ListBoxItemDoubleClick(this, EventArgs.Empty);
        }

        private void TsmiSettings_Click(object sender, EventArgs e)
        {
            if (ToolStripMenuSettingsClick != null) ToolStripMenuSettingsClick(this, EventArgs.Empty);
        }

        private void TsmiAbout_Click(object sender, EventArgs e)
        {
            if (ToolStripMenuAboutClick != null) ToolStripMenuAboutClick(this, EventArgs.Empty);
        }

        private void FldRemotePath_KeyPress1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (SearchFilesClick != null) SearchFilesClick(this, EventArgs.Empty);
            }
        }

        private void CmbProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedProfileChanged != null) SelectedProfileChanged(this, EventArgs.Empty);
        }

        private void CmbProfile_Click(object sender, EventArgs e)
        {
            if (ProfileClick != null) ProfileClick(this, EventArgs.Empty);
        }
        #endregion

        #region Реализация интерфейса IMainForm
        public string Log
        {
            get { return fldLog.Text; }
            set { fldLog.Text = value; }
        }

        public string RemotePath
        {
            get { return fldRemotePath.Text; }
            set { fldRemotePath.Text = value; }
        }

        public void AddItemToList(object item)
        {
            lstFileList.Items.Add(item);
        }

        public string SelectedItem
        {
            get { return lstFileList.SelectedItem.ToString(); }
        }

        public string Profile
        {
            get { return cmbProfile.Text; }
        }

        public int SelectedProfile
        {
            get { return cmbProfile.SelectedIndex; }
            set { cmbProfile.SelectedIndex = value; }
        }

        public void ClearListBox()
        {
            lstFileList.Items.Clear();
        }

        public void AddProfile(string profileName)
        {
            cmbProfile.Items.Add(profileName);
        }

        public void ClearProfiles()
        {
            cmbProfile.Items.Clear();
        }

        public event EventHandler FileUploadClick;
        public event EventHandler SearchFilesClick;
        public event EventHandler ListBoxItemDoubleClick;
        public event EventHandler ToolStripMenuAboutClick;
        public event EventHandler ToolStripMenuSettingsClick;
        public event EventHandler SelectedProfileChanged;
        public event EventHandler ProfileClick;
        #endregion

        #region Код самой формы
        private void TsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Временные костыли
        #endregion
    }
}
