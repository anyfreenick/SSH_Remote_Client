﻿using System.IO;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.Collections.Generic;
using System.Linq;

namespace SSH_Remote_Client.BL
{
    public interface IFileManager
    {
        string RemotePath { get; set; }
        List<string> GetFileList();
        void UploadFile(string filePath);
    }

    public class FileManager: IFileManager
    {
        private string _remotePath;
        private ConnectionInfo _connection;

        public string RemotePath
        {
            get { return _remotePath; }
            set { _remotePath = value; }
        }

        public FileManager(string host, string username, string pass)
        {
            string[] authParams = { host, username, pass };
            SetConnection(authParams);
        }

        public List<string> GetFileList()
        {
            List<string> files = new List<string>();
            SftpClient sftp = new SftpClient(_connection);
            sftp.Connect();
            List<SftpFile> filelist = sftp.ListDirectory(_remotePath).ToList();
            foreach (SftpFile file in filelist)
            {
                if (!file.IsDirectory)
                files.Add(file.Name);
            }
            sftp.Disconnect();
            sftp.Dispose();
            return files;
        }

        public void UploadFile(string filePath)
        {
            SftpClient client = new SftpClient(_connection);
            var fileStream = File.OpenRead(filePath);
            client.UploadFile(fileStream, _remotePath + fileStream.Name, true);
            client.Disconnect();
            client.Dispose();
        }

        public void SetRemotePath(string path)
        {
            _remotePath = path;
        }

        private void SetConnection(string[] authParams)
        {
            _connection = new ConnectionInfo(authParams[0]/*host*/, 22, authParams[1]/*username*/, new AuthenticationMethod[]
            {
                new PasswordAuthenticationMethod(authParams[1]/*username*/, authParams[2]/*password*/)
            });
        }        
    }
}
