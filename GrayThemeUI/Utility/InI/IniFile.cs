using System.IO;
using System.Windows.Media;

namespace Utility.InI
{
    public partial class IniFile
    {
        private readonly string filePath;
        private readonly Dictionary<string, Dictionary<string, string>> sections = [];
        private static readonly char[] separator = [','];

        public IniFile(string path)
        {
            filePath = path;
            Load();
        }

        public string? GetValue(string section, string key , string? defaultString = null)
        {
            if (sections.ContainsKey(section) is true && sections[section].ContainsKey(key) is true)
            {
                return sections[section][key];
            }
            return defaultString;
        }

        public void SetValue(string section, string key, string value)
        {
            if (sections.ContainsKey(section) is false)
            {
                sections[section] = [];
            }
            sections[section][key] = value;
        }
        public void Save()
        {
            if (!File.Exists(filePath))
            {
                string? directoryPath = Path.GetDirectoryName(filePath);
                if (directoryPath is null)
                    return;
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
            }
            using StreamWriter writer = new(filePath);
            foreach (var section in sections)
            {
                writer.WriteLine($"[{section.Key}]");
                foreach (var keyValue in section.Value)
                {
                    writer.WriteLine($"{keyValue.Key} = {keyValue.Value}");
                }
                writer.WriteLine();
            }
        }

        public void Load()
        {
            if (CheckFileExist() is true)
            {
                string currentSection = "";
                foreach (string line in File.ReadLines(filePath))
                {
                    string trimmedLine = line.Trim();
                    if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                    {
                        currentSection = trimmedLine.Substring(1, trimmedLine.Length - 2);
                        if (!sections.ContainsKey(currentSection))
                        {
                            sections[currentSection] = new Dictionary<string, string>();
                        }
                    }
                    else if (trimmedLine.Contains("=") && !trimmedLine.StartsWith(";") && currentSection != "")
                    {
                        string[] parts = trimmedLine.Split(['='], 2);
                        sections[currentSection][parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }
        }

        public bool CheckFileExist()
        {
            return File.Exists(filePath);
        }
    }

    /// <summary>
    /// 확장 기능
    /// </summary>
    public partial class IniFile
    {
        public DirectoryInfo? GetValueToDirectoryInfo(DirectoryInfo superDirectory, string section, string key, string? defaultString = null)
        {
            string? tempString = GetValue(section, key, defaultString);
            if (tempString is null && tempString != "")
                return null;
            if (superDirectory is null)
                return new DirectoryInfo(tempString);
            else
            {
                if (defaultString is null)
                    return null;
                else
                    return new DirectoryInfo(Path.Combine(superDirectory.FullName, defaultString));
            }
                
        }

        public bool SetValueToDirectoryInfo(string section, string key, DirectoryInfo sourceDirectory, DirectoryInfo? superDirectory = null)
        {
            if (sourceDirectory is null)
                return false;
            string sourcePath = sourceDirectory.FullName;
            string superPath = "";
            if (superDirectory != null)
                superPath = superDirectory.FullName;
            if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(superPath) || !sourcePath.Contains(superPath))
                return false;
            string relativePath = sourcePath.Replace(superPath, "");
            SetValue(section, key, relativePath);
            return true;
        }

        public FileInfo? GetValueToFileInfo(DirectoryInfo superDirectory, string section, string key, string? defaultString = null)
        {
            if(superDirectory is null)
                return null;
            string? tempString = GetValue(section, key, defaultString);
            if (tempString is null && tempString != "")
                return null;
            return new FileInfo(Path.Combine(superDirectory.FullName, tempString));
        }

        public bool SetValueToFileInfo(string section, string key, FileInfo sourceFile)
        {
            if (sourceFile is null)
                return false;
            SetValue(section, key, sourceFile.Name);
            return true;
        }

        public Color GetValueToColor(string section, string key, Color defaultColor = new Color())
        {
            string? tempString = GetValue(section, key, null);
            if (tempString is null && tempString != "")
                return defaultColor;
            try
            {
                var resultColor = defaultColor;
                string[] colorValues = tempString.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(item => item.Trim()).ToArray();
                if (colorValues.Length is 4)
                {
                    if (byte.TryParse(colorValues[0], out byte a)
                        && byte.TryParse(colorValues[1], out byte r)
                        && byte.TryParse(colorValues[2], out byte g)
                        && byte.TryParse(colorValues[3], out byte b))
                        resultColor = System.Windows.Media.Color.FromArgb(a, r, g, b);
                }
                else if (colorValues.Length is 3)
                {
                    if (byte.TryParse(colorValues[0], out byte r)
                        && byte.TryParse(colorValues[1], out byte g)
                        && byte.TryParse(colorValues[2], out byte b))
                        resultColor = System.Windows.Media.Color.FromRgb(r, g, b);
                }
                else
                {
                }
                return resultColor;
            }
            catch (Exception)
            {
                return defaultColor;
            }
        }

        public bool SetValueToColor(string section, string key, Color sourceColor)
        {
            string colorString = "";
            colorString += sourceColor.A;
            colorString += ", ";
            colorString += sourceColor.R;
            colorString += ", ";
            colorString += sourceColor.G;
            colorString += ", ";
            colorString += sourceColor.B;
            SetValue(section, key, colorString);
            return true;
        }

        public string[]? GetValueToStringList(string section, string key, string[]? defaultString = null)
        {
            string? tempString = GetValue(section, key);
            if (tempString is null && tempString != "")
                return defaultString;
            return tempString.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(item => item.Trim()).ToArray();
        }

        public bool SetValueToStringList(string section, string key, string[]? sourceString)
        {
            if (sourceString is null)
                return false;
            if (sourceString.Length is 0)
                return false;
            SetValue(section, key, string.Join(", ", sourceString));
            return true;
        }
    }

}
