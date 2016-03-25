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

        //убрать хардкодный путь
        public List<string> getFileList(string user, string pass, string host)
        {
            List<string> files = new List<string>();
            SftpClient sftp = new SftpClient(SetConnection(user, pass, host));
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
            SftpClient client = new SftpClient(SetConnection(userName, passwd, host));
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

        private ConnectionInfo SetConnection(string username, string passwd, string host, int port = 22)
        {
            ConnectionInfo connection = new ConnectionInfo(host, port, username, new AuthenticationMethod[] 
            { new PasswordAuthenticationMethod(username, passwd) });
            return connection;
        }
    }
}
