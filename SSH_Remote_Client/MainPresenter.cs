using System;
using System.Diagnostics;
using System.Collections.Generic;
using SSH_Remote_Client.BL;
using System.IO;

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
            _view.InstallSwaggerButtonClick += _view_InstallSwaggerButtonClick;
            _view.LocalFilePathPressEnter += _view_LocalFilePathPressEnter;
            _view.ButtonRunSwaggerClick += _view_ButtonRunSwaggerClick;
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
        private void _view_InstallSwaggerButtonClick(object sender, EventArgs e)
        {
            _view.ProgressBarVisible = true;
            _view.LabelProgressVisible = true;
            _view.LabelCurrentProgress = "Uploading archive";
            connect();
            _manager.UploadFile("public.zip", "/root");
            if (_view.CurrentProgress < 100)
                _view.IncreaseInstallationProgress(50);
            _view.LabelCurrentProgress = "Extracting archive";
            string[] cmds = { "unzip /root/public.zip -d /usr/local/kronos/tomcat/webapps/wfc/" };
            _manager.ExecuteCmdOnRemote(cmds);
            if (_view.CurrentProgress < 100)
                _view.IncreaseInstallationProgress(50);
            _view.LabelCurrentProgress = "Done!!!";
            _view.ButtonIstallSwaggerEnabled = false;
            _view.LabelSwaggerInstalledVisible = true;
            _view.ButtonRunSwaggerVisible = true;            
        }

        // Нажатие Enter в поле local file path
        private void _view_LocalFilePathPressEnter(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(_view.LocalFilePath);
            List<string> dirs = new List<string>();
            List<string> files = new List<string>();
            foreach (var folder in dir.GetDirectories())
                dirs.Add(folder.Name);
            foreach (var file in dir.GetFiles())
                files.Add(file.Name);
            dirs.Sort();
            files.Sort();
            foreach (var item in dirs)
                _view.AddItemToLocalFileList(item);
            foreach (var item in files)
                _view.AddItemToLocalFileList(item);
        }

        //Клик по кнопке Run Swagger
        private void _view_ButtonRunSwaggerClick(object sender, EventArgs e)
        {
            string host = _manager.GetValueFromConfig(_configFile, _view.Profile, "host");
            Process.Start("http://" + host + "/wfc/public/docs/index.html");
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
