using System.IO;
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
        string GetFileContent(string fileName);
        void UploadFile(string filePath);
        void SetConnection(string host, string user, string pass);
        void ExecuteCmdOnRemote(string fileName);
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

        public void ExecuteCmdOnRemote(string fileName)
        {
            var ssh = new SshClient(_connection);
            ssh.Connect();
            var  cmds = new SshCommand[3];
            cmds[0] = ssh.CreateCommand("chmod +x " + _remotePath + "/" + fileName);
            cmds[1] = ssh.CreateCommand(_remotePath + "/" + fileName);
            cmds[2] = ssh.CreateCommand(_remotePath + "/nginx restart");
            foreach (var cmd in cmds)
                cmd.Execute();            
        }
        #endregion

        public void SetConnection(string host, string user, string pass)
        {
            _connection = new ConnectionInfo(host, 22, user, new AuthenticationMethod[]
            {
                new PasswordAuthenticationMethod(user, pass)
            });
        }        
    }
}
