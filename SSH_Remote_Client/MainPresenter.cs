using System;
using System.Collections.Generic;
using SSH_Remote_Client.BL;

namespace SSH_Remote_Client
{
    public class MainPresenter
    {
        private readonly IMainForm _view;
        private readonly IFileManager _manager;
        private readonly IMessageService _messageService;
        private readonly string _configFile = "config.ini";

        public MainPresenter(IMainForm view, IFileManager manager, IMessageService service)
        {
            _view = view;
            _manager = manager;
            _messageService = service;

            LoadProfiles(_configFile);
            _view.RemotePath = _manager.SetPath(_view.Profile, _configFile);

            _view.FileUploadClick += _view_FileUploadClick;
            _view.SearchFilesClick += _view_SearchFilesClick;
            _view.ListBoxItemDoubleClick += _view_ListBoxItemDoubleClick;
            _view.ToolStripMenuSettingsClick += _view_ToolStripMenuSettingsClick;
            _view.ToolStripMenuAboutClick += _view_ToolStripMenuAboutClick;            
            _view.SelectedProfileChanged += _view_SelectedProfileChanged;
            _view.ProfileClick += _view_ProfileClick;
            _view.InstallButtonClick += _view_InstallButtonClick;
        }        

        #region Обработка событий
        // Клик по кнопке Upload File
        private void _view_FileUploadClick(object sender, EventArgs e)
        {
            connect();
            _manager.UploadFile("script.sh");
            _manager.ExecuteCmdOnRemote("script.sh");
        }

        // Клик по кнопке Search Files
        private void _view_SearchFilesClick(object sender, EventArgs e)
        {
            _view.ClearListBox();
            connect();
            List<string> fileList = _manager.GetFileList();
            fileList.Sort();
            foreach (string file in fileList)
                _view.AddItemToList(file);
        }

        // Двойной клик по имени файла в списке
        private void _view_ListBoxItemDoubleClick(object sender, EventArgs e)
        {
            connect();
            string log = _manager.GetFileContent(_view.SelectedItem);
            if (log != "")
                _view.Log = log;
            else
                _messageService.ShowMessage("File is empty");
        }

        // Клик по элементу меню Tools --> Settings
        private void _view_ToolStripMenuSettingsClick(object sender, EventArgs e)
        {
            SettingsForm form2 = new SettingsForm();
            MessageService service = new MessageService();
            SettingsManager man = new SettingsManager();

            SettingsPresenter pres = new SettingsPresenter(form2, service, man);
            form2.Show();
        }

        // Клик по элементу меню Tools --> About
        private void _view_ToolStripMenuAboutClick(object sender, EventArgs e)
        {
            _messageService.ShowMessage("Надо написать какой-нибудь бред!!!");
        }

        // Выбор элемента в списке Profile
        private void _view_SelectedProfileChanged(object sender, EventArgs e)
        {
            _view.RemotePath = _manager.SetPath(_view.Profile, _configFile);
        }

        // Клик по комбобоксу
        private void _view_ProfileClick(object sender, EventArgs e)
        {
            _view.ClearProfiles();
            LoadProfiles(_configFile);
        }

        // Клик по кнопке Install swagger
        private void _view_InstallButtonClick(object sender, EventArgs e)
        {
            _view.ProgressBarVisible = true;
            _view.LabelProgressVisible = true;
        }
        #endregion

        private void connect()
        {
            _manager.SetConnection(_view.Profile, _configFile);
            _manager.RemotePath = _view.RemotePath;
        }
        
        private void LoadProfiles(string filePath)
        {
            foreach (string section in _manager.LoadSections(filePath))
                _view.AddProfile(section);
            _view.SelectedProfile = 0;
        }
    }
}
