using System.Text;
using System.IO;

namespace SSH_Remote_Client.BL
{
    class FileManager
    {
        private readonly Encoding _defaultencoding = Encoding.GetEncoding(1200);

        public string GetContent(string filePath)
        {
            return GetContent(filePath, _defaultencoding);
        }

        public string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }
    }
}
