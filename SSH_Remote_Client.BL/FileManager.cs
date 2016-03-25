using System.Text;
using System.IO;
using Renci.SshNet;

namespace SSH_Remote_Client.BL
{
    public interface IFileManager
    {
        
    }

    class FileManager: IFileManager
    {
        private readonly string _remotePath = "/tmp/upload";

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
