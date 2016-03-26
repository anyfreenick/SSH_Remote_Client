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
    }

    public class FileManager: IFileManager
    {
        private string _remotePath;
        private ConnectionInfo _connection;

        public FileManager(string host, string username, string pass)
        {
            string[] authParams = { host, username, pass };
            SetConnection(authParams);
        }

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
            string content = ssh.RunCommand("cat " + _remotePath + fileName).Result;
            return content;
        }

        /// <summary>
        /// Загружает файл на удаленный сервер, а каталог указанный в свойстве RemotePath
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        public void UploadFile(string filePath)
        {
            SftpClient client = new SftpClient(_connection);
            var fileStream = File.OpenRead(filePath);
            client.UploadFile(fileStream, _remotePath + fileStream.Name, true);
            client.Disconnect();
            client.Dispose();
        }
        #endregion

        private void SetConnection(string[] authParams)
        {
            _connection = new ConnectionInfo(authParams[0]/*host*/, 22, authParams[1]/*username*/, new AuthenticationMethod[]
            {
                new PasswordAuthenticationMethod(authParams[1]/*username*/, authParams[2]/*password*/)
            });
        }        
    }
}
