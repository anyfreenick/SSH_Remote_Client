using System;
using System.Windows.Forms;

namespace SSH_Remote_Client
{
    public interface ISettingsForm
    {
        // Свойства
        int SelectedProfile { get; set; }
        bool UsernameFieldReadOnly { get; set; }
        string Username { get; set; }
        bool PasswordFieldReadOnly { get; set; }
        string Password { get; set; }
        bool IPFieldReadOnly { get; set; }
        string IP { get; set; }
        bool RemotePathFldReadOnly { get; set; }
        string RemotePath { get; set; }
        ComboBoxStyle ProfileSelectorStyle { get; set; }
        string ProfileName { get; }

        // Методы
        void AddItemToProfileSelector(string item);
        void ClearProfiles();
        void Close();

        // События
        event EventHandler NewProfileButtonClick;
        event EventHandler DeleteProfileButtonClick;
        event EventHandler SaveProfileButtonClick;
        event EventHandler SelectedProfileChanged;
        event EventHandler ExitButtonClick;
    }

    public partial class SettingsForm : Form, ISettingsForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            cmbProfile.SelectedIndex = -1;

            btnNew.Click += BtnNew_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;
            btnExit.Click += BtnExit_Click;
            cmbProfile.SelectedValueChanged += CmbProfile_SelectedValueChanged;
        }

        #region Проброс событий
        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (NewProfileButtonClick != null) NewProfileButtonClick(this, EventArgs.Empty);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteProfileButtonClick != null) DeleteProfileButtonClick(this, EventArgs.Empty);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveProfileButtonClick != null) SaveProfileButtonClick(this, EventArgs.Empty);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (ExitButtonClick != null) ExitButtonClick(this, EventArgs.Empty);
        }

        private void CmbProfile_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SelectedProfileChanged != null) SelectedProfileChanged(this, EventArgs.Empty);
        }
        #endregion

        #region Реализация интерфейса ISettingsForm
        public int SelectedProfile
        {
            get { return cmbProfile.SelectedIndex; }
            set { cmbProfile.SelectedIndex = value; }
        }

        public bool UsernameFieldReadOnly
        {
            get { return fldUserName.ReadOnly; }
            set { fldUserName.ReadOnly = value; }
        }

        public string Username
        {
            get { return fldUserName.Text; }
            set { fldUserName.Text = value; }
        }

        public bool PasswordFieldReadOnly
        {
            get { return fldPasswd.ReadOnly; }
            set { fldPasswd.ReadOnly = value; }
        }

        public string Password
        {
            get { return fldPasswd.Text; }
            set { fldPasswd.Text = value; }
        }

        public bool IPFieldReadOnly
        {
            get { return fldIP.ReadOnly; }
            set { fldIP.ReadOnly = value; }
        }

        public string IP
        {
            get { return fldIP.Text; }
            set { fldIP.Text = value; }
        }

        public bool RemotePathFldReadOnly
        {
            get { return fldRemotePath.ReadOnly; }
            set { fldRemotePath.ReadOnly = value; }
        }

        public string RemotePath
        {
            get { return fldRemotePath.Text; }
            set { fldRemotePath.Text = value; }
        }

        public ComboBoxStyle ProfileSelectorStyle
        {
            get { return cmbProfile.DropDownStyle; }
            set { cmbProfile.DropDownStyle = value; }
        }

        public string ProfileName
        {
            get { return cmbProfile.Text; }            
        }

        public void AddItemToProfileSelector(string item)
        {
            cmbProfile.Items.Add(item);
        }

        public void ClearProfiles()
        {
            cmbProfile.Items.Clear();
        }

        public event EventHandler NewProfileButtonClick;
        public event EventHandler DeleteProfileButtonClick;
        public event EventHandler SaveProfileButtonClick;
        public event EventHandler SelectedProfileChanged;
        public event EventHandler ExitButtonClick;
        #endregion

        #region Код самой формы
        #endregion
    }
}
