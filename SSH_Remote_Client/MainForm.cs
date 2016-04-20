using System;
using System.Windows.Forms;

namespace SSH_Remote_Client
{
    public interface IMainForm
    {
        #region SSH tab
        // Properties
        string Log { get; set; }
        string RemotePath { get; set; }
        string SelectedItem { get; }
        string Profile { get; }
        int SelectedProfile { get; set; }

        // Methods
        void AddItemToList(object item);
        void ClearListBox();
        void ClearProfiles();
        void AddProfile(string profileName);

        // Events
        event EventHandler FileUploadClick;
        event EventHandler SearchFilesClick;
        event EventHandler ListBoxItemDoubleClick;
        event EventHandler SelectedProfileChanged;
        event EventHandler ProfileClick;
        #endregion

        #region Install swagger tab
        //Properties
        bool ProgressBarVisible { get; set; }
        bool LabelProgressVisible { get; set; }
        int CurrentProgress { get; }

        // Methods
        void IncreaseInstallationProgress(int percent);

        // Events
        event EventHandler InstallButtonClick;
        #endregion

        #region Upload files to linux tab
        // Свойства
        string LocalFilePath { get; }

        // Методы        
        void AddItemToLocalFileList(object item);

        // События
        event EventHandler LocalFilePathPressEnter;
        event EventHandler RemoteFilePathPressEnter;
        #endregion

        event EventHandler ToolStripMenuAboutClick;
        event EventHandler ToolStripMenuSettingsClick;
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
            btnInstall.Click += BtnInstall_Click;
            fldLocalFilePath.KeyPress += FldLocalFilePath_KeyPress;
        }

        #region Проброс событий

        #region SSH tab
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

        #region Install swagger tab
        private void BtnInstall_Click(object sender, EventArgs e)
        {
            if (InstallButtonClick != null) InstallButtonClick(this, EventArgs.Empty);
        }
        #endregion

        #region Upload files to linux tab
        private void FldLocalFilePath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (LocalFilePathPressEnter != null) LocalFilePathPressEnter(this, EventArgs.Empty);
            }
        }
        #endregion

        private void TsmiSettings_Click(object sender, EventArgs e)
        {
            if (ToolStripMenuSettingsClick != null) ToolStripMenuSettingsClick(this, EventArgs.Empty);
        }

        private void TsmiAbout_Click(object sender, EventArgs e)
        {
            if (ToolStripMenuAboutClick != null) ToolStripMenuAboutClick(this, EventArgs.Empty);
        }
        #endregion

        #region Реализация интерфейса IMainForm

        #region SSH tab
        // Properties
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

        // Methods
        public void AddItemToList(object item)
        {
            lstFileList.Items.Add(item);
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

        // Events
        public event EventHandler FileUploadClick;
        public event EventHandler SearchFilesClick;
        public event EventHandler ListBoxItemDoubleClick;
        public event EventHandler SelectedProfileChanged;
        public event EventHandler ProfileClick;
        #endregion

        #region Install swagger tab
        //Properties
        public bool ProgressBarVisible
        {
            get { return pbInstall.Visible; }
            set { pbInstall.Visible = value; }
        }

        public int CurrentProgress
        {
            get { return pbInstall.Value; }
        }

        public bool LabelProgressVisible
        {
            get { return lblProgress.Visible; }
            set { lblProgress.Visible = value; }
        }

        // Methods
        public void IncreaseInstallationProgress(int percent)
        {
            pbInstall.Value += percent;
        }
        
        // Events
        public event EventHandler InstallButtonClick;
        #endregion

        #region Upload files to linux tab
        // Propoerties
        public string LocalFilePath
        {
            get { return fldLocalFilePath.Text; }
        }

        // Methods
        public void AddItemToLocalFileList(object item)
        {
            lstLocalFiles.Items.Add(item);
        }

        // Events
        public event EventHandler LocalFilePathPressEnter;
        public event EventHandler RemoteFilePathPressEnter;
        #endregion

        public event EventHandler ToolStripMenuAboutClick;
        public event EventHandler ToolStripMenuSettingsClick;        
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
