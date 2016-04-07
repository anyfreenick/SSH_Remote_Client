using System;
using SSH_Remote_Client.BL;

namespace SSH_Remote_Client
{
    class SettingsPresenter
    {
        private readonly ISettingsForm _view;
        private readonly ISettingsManager _manager;
        private readonly IMessageService _messageService;
        private readonly string _configFile = "config.ini";
        private bool configSaved = true;

        public SettingsPresenter(ISettingsForm view, IMessageService service, ISettingsManager manager)
        {
            _view = view;
            _messageService = service;
            _manager = manager;

            LoadProfiles(_configFile);
            LoadProfile(_view.ProfileName);
            

            _view.NewProfileButtonClick += _view_NewProfileButtonClick;
            _view.SaveProfileButtonClick += _view_SaveProfileButtonClick;
            _view.DeleteProfileButtonClick += _view_DeleteProfileButtonClick;
            _view.ExitButtonClick += _view_ExitButtonClick;
            _view.SelectedProfileChanged += _view_SelectedProfileChanged;
        }
        
        #region Обработка событий
        private void _view_NewProfileButtonClick(object sender, EventArgs e)
        {
            configSaved = false;
            UnlockFields();
        }

        private void _view_SaveProfileButtonClick(object sender, EventArgs e)
        {
            _manager.AddSectionToConfig(_view.ProfileName, _view.Username, _view.Password, _view.IP, _view.RemotePath, _configFile);
            configSaved = true;
            LockFields();
            _view.ClearProfiles();
            LoadProfiles(_configFile);
        }

        private void _view_DeleteProfileButtonClick(object sender, EventArgs e)
        {
            _manager.RemoveSectionFromConfig(_view.ProfileName, _configFile);
            _messageService.ShowMessage("Profile " + _view.ProfileName + " deleted");
            _view.SelectedProfile = -1;
            _view.ClearProfiles();
            LoadProfiles(_configFile);
        }

        private void _view_ExitButtonClick(object sender, EventArgs e)
        {
            if (configSaved)
            {
                _view.Close();
                return;
            }                
            if (_messageService.ShowConfirmation("Profile not saved!\nSave it?"))
            {
                _view_SaveProfileButtonClick(_view, EventArgs.Empty);
                _view.Close();
            }
            else
                _view.Close();
        }

        private void _view_SelectedProfileChanged(object sender, EventArgs e)
        {
            if (_view.SelectedProfile < 0)
                return;
            LockFields();
            LoadProfile(_view.ProfileName);
        }
        #endregion

        private void LoadProfiles(string filePath)
        {
            foreach (string section in _manager.LoadSections(filePath))
                _view.AddItemToProfileSelector(section);
            _view.SelectedProfile = 0;
        }

        private void LoadProfile(string sectionName)
        {
            string[] values = _manager.LoadConfig(sectionName, _configFile);
            _view.Username = values[0];
            _view.Password = values[1];
            _view.IP = values[2];
            _view.RemotePath = values[3];
        }

        private void LockFields()
        {
            _view.UsernameFieldReadOnly = true;
            _view.PasswordFieldReadOnly = true;
            _view.IPFieldReadOnly = true;
            _view.RemotePathFldReadOnly = true;
            _view.ProfileSelectorStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void UnlockFields()
        {
            _view.SelectedProfile = -1;           
            _view.Username = "";
            _view.Password = "";
            _view.IP = "";
            _view.RemotePath = "";
            _view.ProfileSelectorStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            _view.UsernameFieldReadOnly = false;            
            _view.PasswordFieldReadOnly = false;            
            _view.IPFieldReadOnly = false;            
            _view.RemotePathFldReadOnly = false;
        }
    }
}
