using IniParser;
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
        #region ISettingsManager

        /// <summary>
        /// Get list of section in ini config file
        /// </summary>
        /// <param name="filePath">Path to config file(*.ini)</param>
        /// <returns>Returns list of section in the file</returns>
        public List<string> LoadSections(string filePath)
        {
            var parser = new FileIniDataParser();
            var parsedData = parser.ReadFile(filePath);
            List<string> result = new List<string>();
            foreach (var section in parsedData.Sections)
                result.Add(section.SectionName);
            return result;
        }

        /// <summary>
        /// Parses the section in the ini file
        /// </summary>
        /// <param name="sectionName">name of section that needs to be parsed</param>
        /// <param name="filePath">path to the config file</param>
        /// <returns>returns List of values of the following keys: username, password, host, remote_path</returns>
        public string[] LoadConfig(string sectionName, string filePath)
        {
            string[] result = new string[4];
            var parser = new FileIniDataParser();
            var parsedData = parser.ReadFile(filePath);
            result[0] = parsedData[sectionName]["username"];
            result[1] = parsedData[sectionName]["password"];
            result[2] = parsedData[sectionName]["host"];
            result[3] = parsedData[sectionName]["remote_path"];
            return result;
        }

        /// <summary>
        /// Adds a new section to the config file
        /// </summary>
        /// <param name="sectionName">name of a new section</param>
        /// <param name="username">value of the key 'username'</param>
        /// <param name="password">value of the key 'password'</param>
        /// <param name="host">value of the key 'host'</param>
        /// <param name="remotePath">value of the key 'remote_path'</param>
        /// <param name="configFile">path to the config file</param>
        public void AddSectionToConfig(string sectionName, string username, string password, string host, string remotePath, string configFile)
        {
            var parser = new FileIniDataParser();
            var parsedData = parser.ReadFile(configFile);
            parsedData.Sections.AddSection(sectionName);
            parsedData[sectionName].AddKey("username", username);
            parsedData[sectionName].AddKey("password", password);
            parsedData[sectionName].AddKey("host", host);
            parsedData[sectionName].AddKey("remote_path", remotePath);
            parser.WriteFile(configFile, parsedData, Encoding.UTF8);
        }

        /// <summary>
        /// Deletes a section from the config file
        /// </summary>
        /// <param name="sectionName">name of the section that needs to be deleted</param>
        /// <param name="filePath">path to the config file</param>
        public void RemoveSectionFromConfig(string sectionName, string filePath)
        {
            var parser = new FileIniDataParser();
            var data = parser.ReadFile(filePath);
            data.Sections.RemoveSection(sectionName);
            parser.WriteFile(filePath, data, Encoding.UTF8);
        }
        #endregion
    }
}
