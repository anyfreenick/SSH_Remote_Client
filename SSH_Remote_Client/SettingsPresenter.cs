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
        private readonly ISettingManager _manager;
        private readonly IMessageService _messageService;
        private readonly string _configFile = "config.ini";

        public SettingsPresenter(ISettingsForm view, IMessageService service, ISettingManager manager)
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
            _view.UsernameFieldReadOnly = true;
            _view.PasswordFieldReadOnly = true;
            _view.IPFieldReadOnly = true;
            _view.ProfileSelectorStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void _view_NewProfileButtonClick(object sender, EventArgs e)
        {
            _view.UsernameFieldReadOnly = false;
            _view.PasswordFieldReadOnly = false;
            _view.IPFieldReadOnly = false;
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
