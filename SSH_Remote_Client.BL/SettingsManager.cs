using IniParser;
using IniParser.Model;
using System.Collections.Generic;
using System.Text;

namespace SSH_Remote_Client.BL
{
    public interface ISettingsManager
    {
        List<string> LoadSections(string filePath);
        string[] LoadConfig(string sectionName, string filePath);
        void AddSectionToConfig(string sectionName, string username, string password, string host, string remotePath, string configFile);
        void RemoveSectionFromConfig(string sectionName, string filePath);
    }

    public class SettingsManager: ISettingsManager
    {
        public List<string> LoadSections(string filePath)
        {
            var parser = new FileIniDataParser();
            IniData parsedData = parser.ReadFile(filePath);
            List<string> result = new List<string>();
            foreach (SectionData section in parsedData.Sections)
                result.Add(section.SectionName);
            return result;
        }

        public string[] LoadConfig(string sectionName, string filePath)
        {
            string[] result = new string[4];
            var parser = new FileIniDataParser();
            IniData parsedData = parser.ReadFile(filePath);
            result[0] = parsedData[sectionName]["username"];
            result[1] = parsedData[sectionName]["password"];
            result[2] = parsedData[sectionName]["host"];
            result[3] = parsedData[sectionName]["remote_path"];
            return result;
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

        public void RemoveSectionFromConfig(string sectionName, string filePath)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(filePath);
            data.Sections.RemoveSection(sectionName);
            parser.WriteFile(filePath, data, Encoding.UTF8);
        }
    }
}
