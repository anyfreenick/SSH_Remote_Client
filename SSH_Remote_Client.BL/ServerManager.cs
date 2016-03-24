using System;
using System.IO;
using Renci.SshNet;

namespace SSH_Remote_Client.BL
{
    public class ServerManager
    {
        private static readonly string _remotePath = "/usr/local/nginx/";

        public static void copyFileToServer(string filePath, string remotePath, string serverName, string userName, string passwd)
        {
            FileInfo file = new FileInfo(filePath);
            string uploadFile = file.FullName;
            var client = new SftpClient(serverName, 22, userName, passwd);
            client.Connect();
            var fileStream = new FileStream(uploadFile, FileMode.Open);
            client.BufferSize = 4 * 1024;
            client.UploadFile(fileStream, remotePath + file.Name, true, null);
            client.Disconnect();
            client.Dispose();
        }

        public static void copyFileToServer(string filePath, string serverName, string userName, string passwd)
        {
            copyFileToServer(filePath, _remotePath, serverName, userName, passwd);
        }

        public static void runCommandOnServer(string serverName, string userName, string passwd)
        {
            SshClient client = new SshClient(serverName, 22, userName, passwd);
            client.Connect();
            SshCommand cmd1 = client.CreateCommand("chmod +x /usr/local/nginx/script.sh");
            SshCommand cmd2 = client.CreateCommand("/usr/local/nginx/script.sh");
            SshCommand cmd3 = client.CreateCommand("/usr/local/nginx/nginx restart");
            cmd1.Execute();
            cmd2.Execute();
            cmd3.Execute();
            client.Disconnect();
            client.Dispose();            
        }

        public static string getLog(string serverName, string userName, string passwd)
        {
            SshClient client = new SshClient(serverName, 22, userName, passwd);
            client.Connect();
            var terminal = client.RunCommand("cat /usr/local/nginx/log/access_postdata.log");
            string log = terminal.Result;
            client.Disconnect();
            client.Dispose();
            log = log.Replace("\n", "\r\n");
            return log;
        }
    }
}
