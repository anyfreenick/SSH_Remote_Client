using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSH_Remote_Client
{
    public interface ISettingsForm
    {
        // Свойства
        int SelectedProfile { get; set; }
        bool UsernameFieldReadOnly { get; set; }
        bool PasswordFieldReadOnly { get; set; }
        bool IPFieldReadOnly { get; set; }
        ComboBoxStyle ProfileSelectorStyle { get; set; }

        // Методы
        void AddItemToProfileSelector(string item);

        // События
        event EventHandler NewProfileButtonClick;
        event EventHandler EditProfileButtonClick;
        event EventHandler SaveProfileButtonClick;
        event EventHandler SelectedProfileChanged;
    }

    public partial class SettingsForm : Form, ISettingsForm
    {
        public SettingsForm()
        {
            InitializeComponent();

            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;
            btnExit.Click += BtnExit_Click;
            cmbProfile.SelectedValueChanged += CmbProfile_SelectedValueChanged;
        }

        #region Проброс событий
        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (NewProfileButtonClick != null) NewProfileButtonClick(this, EventArgs.Empty);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (EditProfileButtonClick != null) EditProfileButtonClick(this, EventArgs.Empty);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveProfileButtonClick != null) SaveProfileButtonClick(this, EventArgs.Empty);
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

        public bool PasswordFieldReadOnly
        {
            get { return fldPasswd.ReadOnly; }
            set { fldPasswd.ReadOnly = value; }
        }

        public bool IPFieldReadOnly
        {
            get { return fldIP.ReadOnly; }
            set { fldIP.ReadOnly = value; }
        }

        public ComboBoxStyle ProfileSelectorStyle
        {
            get { return cmbProfile.DropDownStyle; }
            set { cmbProfile.DropDownStyle = value; }
        }

        public void AddItemToProfileSelector(string item)
        {
            cmbProfile.Items.Add(item);
        }

        public event EventHandler NewProfileButtonClick;
        public event EventHandler EditProfileButtonClick;
        public event EventHandler SaveProfileButtonClick;
        public event EventHandler SelectedProfileChanged;
        #endregion

        #region Код самой формы
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
