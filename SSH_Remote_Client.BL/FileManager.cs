using System.IO;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.Collections.Generic;
using System.Linq;

namespace SSH_Remote_Client.BL
{
    public interface IFileManager
    {
        
    }

    public class FileManager: IFileManager
    {
        private readonly string _remotePath = "/tmp/upload";
        private ConnectionInfo connection;

        public FileManager(string[] authParams)
        {
            SetConnection(authParams);
        }

        //убрать хардкодный путь
        public List<string> getFileList()
        {
            List<string> files = new List<string>();
            SftpClient sftp = new SftpClient(connection);
            sftp.Connect();
            sftp.ChangeDirectory("/home/docent");
            List<SftpFile> filelist = sftp.ListDirectory("/home/docent").ToList();
            foreach (SftpFile file in filelist)
            {
                files.Add(file.Name);
            }
            sftp.Disconnect();
            sftp.Dispose();
            return files;
        }

        public void UploadFile(string userName, string passwd, string host)
        {
            SftpClient client = new SftpClient(connection);
            string file = "script.sh";
            var fileStream = File.OpenRead(file);
            client.UploadFile(fileStream, _remotePath + file, true);
            client.Disconnect();
            client.Dispose();
        }

        public string GetFileContent(string filePath)
        {

            return null;
        }

        private void SetConnection(string[] authParams)
        {
            connection = new ConnectionInfo(authParams[0]/*host*/, 22, authParams[1]/*username*/, new AuthenticationMethod[]
            {
                new PasswordAuthenticationMethod(authParams[1], authParams[2]/*password*/)
            });
        }        
    }
}
