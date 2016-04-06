using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSH_Remote_Client.BL;

namespace SSH_Remote_Client
{
    class SettingsPresenter
    {
        private readonly ISettingsForm _view;
        private readonly ISettingsManager _manager;
        private readonly IMessageService _messageService;
        private readonly string _configFile = "config.ini";

        public SettingsPresenter(ISettingsForm view, IMessageService service, ISettingsManager manager)
        {
            _view = view;
            _messageService = service;
            _manager = manager;

            loadConfig(_configFile);

            _view.NewProfileButtonClick += _view_NewProfileButtonClick;
            _view.SaveProfileButtonClick += _view_SaveProfileButtonClick;
        }

        private void _view_SaveProfileButtonClick(object sender, EventArgs e)
        {
            _manager.AddSectionToConfig(_view.ProfileName, _view.Username, _view.Password, _view.IP, _view.RemotePath, _configFile);
            _view.UsernameFieldReadOnly = true;
            _view.PasswordFieldReadOnly = true;
            _view.IPFieldReadOnly = true;
            _view.RemotePathFldReadOnly = true;
            _view.ProfileSelectorStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _view.ClearProfiles();
            loadConfig(_configFile);
        }

        private void _view_NewProfileButtonClick(object sender, EventArgs e)
        {
            _view.UsernameFieldReadOnly = false;
            _view.Username = "";
            _view.PasswordFieldReadOnly = false;
            _view.Password = "";
            _view.IPFieldReadOnly = false;
            _view.IP = "";
            _view.RemotePathFldReadOnly = false;
            _view.RemotePath = "";
            _view.SelectedProfile = -1;
            _view.ProfileSelectorStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
        }

        private void loadConfig(string filePath)
        {
            foreach (string section in _manager.LoadConfig(filePath))
                _view.AddItemToProfileSelector(section);
            _view.SelectedProfile = 0;
        }
    }
}
