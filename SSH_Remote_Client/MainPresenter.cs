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

        public MainPresenter(IMainForm view, IFileManager manager, IMessageService service)
        {
            _view = view;
            _manager = manager;
            _messageService = service;
            
            _view.SearchFilesClick += _view_SearchFilesClick;
            _view.ListBoxItemDoubleClick += _view_ListBoxItemDoubleClick;
            _view.ToolStripMenuAboutClick += _view_ToolStripMenuAboutClick;
            _view.FileUploadClick += _view_FileUploadClick;
        }

        private void _view_FileUploadClick(object sender, EventArgs e)
        {
            if (!CheckCredsEntered())
                return;
            connect();
            _manager.UploadFile("script.sh");
            _manager.ExecuteCmdOnRemote("script.sh");
        }

        private void _view_ToolStripMenuAboutClick(object sender, EventArgs e)
        {
            _messageService.ShowMessage("Надо написать какой-нибудь бред!!!");
        }

        private void _view_ListBoxItemDoubleClick(object sender, EventArgs e)
        {
            if (!CheckCredsEntered())
                return;
            connect();
            string log = _manager.GetFileContent(_view.SelectedItem);
            if (log != "")
                _view.Log = log;                         
            else
                _messageService.ShowMessage("Log file is empty");
        }

        private void _view_SearchFilesClick(object sender, EventArgs e)
        {
            if (!CheckCredsEntered())
                return;
            connect();
            List<string> fileList = _manager.GetFileList();
            fileList.Sort();
            foreach (string file in fileList)
                _view.AddItemToList(file);
        }

        private bool CheckCredsEntered()
        {
            if (_view.HostName == "")
            {
                _messageService.ShowError("Не заполнено поле IP или имя сервера");
                return false;
            }
                
            if (_view.UserName == "")
            {
                _messageService.ShowError("Не введено имя пользователя");
                return false;
            }
                
            if (_view.Passwd == "")
            {
                _messageService.ShowError("Не введен пароль");
                return false;
            }
            return true;
        }

        private void connect()
        {
            _manager.SetConnection(_view.HostName, _view.UserName, _view.Passwd);
            _manager.RemotePath = _view.RemotePath;
        }
    }
}
