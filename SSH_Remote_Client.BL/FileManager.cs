﻿using System.IO;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.Collections.Generic;
using System.Linq;
using IniParser;

namespace SSH_Remote_Client.BL
{
    public interface IFileManager
    {
        string RemotePath { get; set; }

        List<string> GetFileList();
        string GetFileContent(string fileName);
        string SetPath(string sectionName, string configFile);
        void UploadFile(string filePath);
        void UploadFile(string filePath, string remotePath);
        void SetConnection(string sectionName, string configFile);
        void ExecuteCmdOnRemote(string fileName);
        void ExecuteCmdOnRemote(string[] cmds);
        string GetValueFromConfig(string config, string section, string key);
        List<string> LoadSections(string filePath);
    }

    public class FileManager: IFileManager
    {
        private string _remotePath;
        private ConnectionInfo _connection;

        #region Реализация интерфейса IFileManager
        public string RemotePath
        {
            get { return _remotePath; }
            set { _remotePath = value; }
        }

        /// <summary>
        /// Получает список файлов на удаленном сервере, в каталоге указанном в свойстве RemotePath
        /// </summary>
        /// <returns>List<string></returns>
        public List<string> GetFileList()
        {
            List<string> files = new List<string>();
            SftpClient sftp = new SftpClient(_connection);
            sftp.Connect();
            List<SftpFile> filelist = sftp.ListDirectory(_remotePath).ToList();
            foreach (SftpFile file in filelist)
            {
                if (!file.IsDirectory)
                    if (file.Name.Substring(0,1) != ".")
                        files.Add(file.Name);
            }
            sftp.Disconnect();
            sftp.Dispose();
            return files;
        }

        /// <summary>
        /// Получает содержимое текстового файла
        /// </summary>
        /// <param name="fileName">Имя файла, путь к файлу указывается через свойство RemotePath</param>
        /// <returns></returns>
        public string GetFileContent(string fileName)
        {
            SshClient ssh = new SshClient(_connection);
            ssh.Connect();
            string content = ssh.RunCommand("cat " + _remotePath + "/" + fileName).Result;
            content = content.Replace("\n", "\r\n");
            ssh.Disconnect();
            ssh.Dispose();
            return content;
        }        

        public string SetPath(string sectionName, string configFile)
        {
            var parser = new FileIniDataParser();
            var data = parser.ReadFile(configFile);
            return data[sectionName]["remote_path"];
        }

        /// <summary>
        /// Загружает файл на удаленный сервер, а каталог указанный в свойстве RemotePath
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        public void UploadFile(string filePath)
        {
            SftpClient sftp = new SftpClient(_connection);
            sftp.Connect();
            FileInfo file = new FileInfo(filePath);
            string uploadFile = file.FullName;
            var fileStream = new FileStream(uploadFile, FileMode.Open);
            sftp.UploadFile(fileStream, _remotePath + "/" + file.Name, true, null);
            sftp.Disconnect();
            sftp.Dispose();
        }

        /// <summary>
        /// Загружает файл на удаленный сервер, а каталог указанный в свойстве RemotePath
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <param name="remotePath">Путь на удаленном сервере</param>
        public void UploadFile(string filePath, string remotePath)
        {
            SftpClient sftp = new SftpClient(_connection);
            sftp.Connect();
            FileInfo file = new FileInfo(filePath);
            string uploadFile = file.FullName;
            var fileStream = new FileStream(uploadFile, FileMode.Open);
            sftp.UploadFile(fileStream, remotePath + "/" + file.Name, true, null);
            sftp.Disconnect();
            sftp.Dispose();
        }

        public void ExecuteCmdOnRemote(string fileName)
        {
            var ssh = new SshClient(_connection);
            ssh.Connect();
            var cmds = new SshCommand[] { ssh.CreateCommand("chmod +x " + _remotePath + "/" + fileName), ssh.CreateCommand(_remotePath + "/" + fileName), ssh.CreateCommand(_remotePath + "/nginx restart") };
            foreach (var cmd in cmds)
                cmd.Execute();            
        }

        public void ExecuteCmdOnRemote(string[] cmds)
        {
            var ssh = new SshClient(_connection);
            ssh.Connect();
            foreach (string cmd in cmds)            
                ssh.CreateCommand(cmd).Execute();            
        }

        public List<string> LoadSections(string filePath)
        {
            var parser = new FileIniDataParser();
            var parsedData = parser.ReadFile(filePath);
            List<string> result = new List<string>();
            foreach (var section in parsedData.Sections)
                result.Add(section.SectionName);
            return result;
        }

        public string GetValueFromConfig(string config, string section, string key)
        {
            var parser = new FileIniDataParser();
            var parsedData = parser.ReadFile(config);
            return parsedData[section][key];
        }
        #endregion

        public void SetConnection(string sectionName, string configFile)
        {
            var parser = new FileIniDataParser();
            var data = parser.ReadFile(configFile);
            _connection = new ConnectionInfo(data[sectionName]["host"], 22, data[sectionName]["username"], new AuthenticationMethod[]
            {
                new PasswordAuthenticationMethod(data[sectionName]["username"], data[sectionName]["password"])
            });
            _remotePath = data[sectionName]["remote_path"];
        }        
    }
}
