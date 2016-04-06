using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSH_Remote_Client.BL
{
    public interface ISettingManager
    {
        List<string> LoadConfig(string filePath);
    }

    public class SettingsManager: ISettingManager
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
    }
}
