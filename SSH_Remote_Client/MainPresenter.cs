using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void _view_SearchFilesClick(object sender, EventArgs e)
        {
            connect();
            List<string> fileList = _manager.GetFileList();
            fileList.Sort();
            foreach (string file in fileList)
                _view.AddItemToList(file);
        }

        private void connect()
        {
            _manager.SetConnection(_view.HostName, _view.UserName, _view.Passwd);
            _manager.RemotePath = _view.RemotePath;
        }
    }
}
