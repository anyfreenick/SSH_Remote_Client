using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSH_Remote_Client.BL
{
    public interface ISettingsManager
    {
        List<string> LoadConfig(string filePath);
        void AddSectionToConfig(string sectionName, string username, string password, string host, string remotePath, string configFile);
    }

    public class SettingsManager: ISettingsManager
    {
        public List<string> LoadConfig(string filePath)
        {
            var parser = new FileIniDataParser();
            IniData parsedData = parser.ReadFile(filePath);
            List<string> values = new List<string>();
            foreach (SectionData section in parsedData.Sections)
                values.Add(section.SectionName);
            return values;
        }

        public void AddSectionToConfig(string sectionName, string username, string password, string host, string remotePath, string configFile)
        {
            var parser = new FileIniDataParser();
            IniData parsedData = parser.ReadFile(configFile);
            parsedData.Sections.AddSection(sectionName);
            parsedData[sectionName].AddKey("username", username);
            parsedData[sectionName].AddKey("password", password);
            parsedData[sectionName].AddKey("host", host);
            parsedData[sectionName].AddKey("remote_path", remotePath);
            parser.WriteFile(configFile, parsedData, Encoding.UTF8);
        }
    }
}
