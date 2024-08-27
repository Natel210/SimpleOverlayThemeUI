using System.IO;
using System.Numerics;
using System.Windows.Media;


namespace Utility.InI
{
    public class IniItem<T>
    {
        public string Section { get; set; } = "";
        public string Key { get; set; } = "";
        public T? DefaultValue { get; internal set; } = default;
        public T? Value { get; set; } = default;
        public bool IsValidSectionKey
        {
            get
            {
                if (string.IsNullOrEmpty(Section) is true)
                    return false;
                if (string.IsNullOrEmpty(Key) is true)
                    return false;
                return true;
            }
        }
        public IniItem()
        { }

        public IniItem(IniItem<T> iniItem)
        {
            Section = iniItem.Section;
            Key = iniItem.Key;
            DefaultValue = iniItem.DefaultValue;
            Value = iniItem.Value;
        }

    }

    public partial class IniFile
    {
        private readonly string filePath;
        private readonly Dictionary<string, Dictionary<string, string>> sections = [];
        

        public IniFile(string path)
        {
            filePath = path;
            Load();
        }

        public T? GetValue<T>(string section, string key, T? defaultValue = default)
        {
            if (sections.ContainsKey(section) && sections[section].ContainsKey(key))
            {
                string value = sections[section][key];

                // 기본적으로 값을 변환하려고 시도합니다.
                try
                {
                    return (T)Convert.ChangeType(value, typeof(T));
                }
                catch
                {
                    return defaultValue;
                }
            }
            return defaultValue;
        }


        public string? GetValue(string section, string key , string? defaultValue = null)
        {
            if (sections.ContainsKey(section) is false)
                return defaultValue;
            if (sections[section].ContainsKey(key) is false)
                return defaultValue;
            string tempValue = sections[section][key];
            if (string.IsNullOrEmpty(tempValue) is true)
                return defaultValue;
            return tempValue;
        }

        public bool SetValue(string section, string key, string? value)
        {
            if (sections.ContainsKey(section) is false)
                sections[section] = [];
            if (value is null)
                return false;
            if (string.IsNullOrEmpty(value) is true)
                return false;
            sections[section][key] = value;
            return true;
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
        public string? GetValue(IniItem<string> item)
        {
            if (item is null)
                return null;
            if (item.IsValidSectionKey is false)
                return item.DefaultValue;
            item.Value = GetValue(item.Section, item.Key, item.DefaultValue);
            return item.Value;
        }

        public bool SetValue(IniItem<string> item)
        {
            if (item is null)
                return false;
            if (item.IsValidSectionKey is false)
                return false;
            return SetValue(item.Section, item.Key, item.Value);
        }

        public double? GetValue(string section, string key, double? defaultValue = null)
        {
            string? tempValue = GetValue(section, key, defaultValue?.ToString() ?? null);
            if (string.IsNullOrEmpty(tempValue) is true)
                return defaultValue;
            if (double.TryParse(tempValue, out double result) is false)
                return result;
            return defaultValue;
        }

        public bool SetValue(string section, string key, double? value)
        {
            if (value is null)
                return false;
            return SetValue(section, key, value.ToString());
        }

        public double? GetValue(IniItem<double> item)
        {
            if (item is null)
                return null;
            if (item.IsValidSectionKey is false)
                return item.DefaultValue;
            item.Value = GetValue(item.Section, item.Key, item.DefaultValue);
            return item.Value;
        }

        public bool SetValue(IniItem<double> item)
        {
            if (item is null)
                return false;
            if (item.IsValidSectionKey is false)
                return false;
            return SetValue(item.Section, item.Key, item.Value);
        }

        public DirectoryInfo? GetValue(string section, string key, DirectoryInfo? defaultValue = null, DirectoryInfo? superDirectory = null)
        {
            string? tempValue = GetValue(section, key, defaultValue?.FullName ?? null);
            if (string.IsNullOrEmpty(tempValue) is true)
                return defaultValue;
            if (superDirectory is null)
                return new DirectoryInfo(tempValue);
            return new DirectoryInfo(Path.Combine(superDirectory.FullName, tempValue));
        }

        public bool SetValue(string section, string key, DirectoryInfo? value, DirectoryInfo? superDirectory = null)
        {
            if (value is null)
                return false;
            string relativePath;
            if (superDirectory is null)
                relativePath = value.FullName;
            else
                relativePath = value.FullName.Replace(superDirectory.FullName, "");
            return SetValue(section, key, relativePath);
        }

        public DirectoryInfo? GetValue(IniItem<DirectoryInfo> item, DirectoryInfo? superDirectory = null)
        {
            if (item is null)
                return null;
            if (item.IsValidSectionKey is false)
                return item.DefaultValue;
            return GetValue(item.Section, item.Key, item.DefaultValue, superDirectory);
        }

        public bool SetValue(IniItem<DirectoryInfo> item, DirectoryInfo? superDirectory = null)
        {
            if (item is null)
                return false;
            if (item.IsValidSectionKey is false)
                return false;
            return SetValue(item.Section, item.Key, item.Value, superDirectory);
        }

        public FileInfo? GetValue(string section, string key, FileInfo? defaultValue = null, DirectoryInfo? superDirectory = null)
        {
            string? tempValue = GetValue(section, key, defaultValue?.FullName ?? null);
            if (string.IsNullOrEmpty(tempValue) is true)
                return defaultValue;
            if (superDirectory is null)
                return new FileInfo(tempValue);
            return new FileInfo(Path.Combine(superDirectory.FullName, tempValue));
        }

        public bool SetValue(string section, string key, FileInfo? value, DirectoryInfo? superDirectory = null)
        {
            if (value is null)
                return false;
            string relativePath;
            if (superDirectory is null)
                relativePath = value.FullName;
            else
                relativePath = value.FullName.Replace(superDirectory.FullName, "");
            return SetValue(section, key, relativePath);
        }

        public FileInfo? GetValue(IniItem<FileInfo> item, DirectoryInfo? superDirectory = null)
        {
            if (item is null)
                return null;
            if (item.IsValidSectionKey is false)
                return item.DefaultValue;
            return GetValue(item.Section, item.Key, item.DefaultValue, superDirectory);
        }

        public bool SetValue(IniItem<FileInfo> item, DirectoryInfo? superDirectory = null)
        {
            if (item is null)
                return false;
            if (item.IsValidSectionKey is false)
                return false;
            return SetValue(item.Section, item.Key, item.Value, superDirectory);
        }

        public string[]? GetValue(string section, string key, string[]? defaultValue = null)
        {
            string? tempValue = GetValue(section, key, "");
            if (string.IsNullOrEmpty(tempValue) is true)
                return null;
            return tempValue.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(item => item.Trim()).ToArray();
        }

        public bool SetValue(string section, string key, string[]? value)
        {
            if (value is null)
                return false;
            if (value.Length is 0)
                return false;
            SetValue(section, key, string.Join(", ", value));
            return true;
        }

        public string[]? GetValue(IniItem<string[]> item)
        {
            if (item is null)
                return null;
            if (item.IsValidSectionKey is false)
                return item.DefaultValue;
            return GetValue(item.Section, item.Key, item.DefaultValue);
        }

        public bool SetValue(IniItem<string[]> item)
        {
            if (item is null)
                return false;
            if (item.IsValidSectionKey is false)
                return false;
            return SetValue(item.Section, item.Key, item.Value);
        }

        public Color? GetValue(string section, string key, Color? defaultValue = null)
        {
            string[]? tempValue = GetValue<string[]>(section, key, null);
            if (tempValue is null)
                return defaultValue;
            byte a = 255;
            byte r = 0;
            byte g = 0;
            byte b = 0;
            try
            {
                if (tempValue.Length is 4)
                {
                    if(byte.TryParse(tempValue[0], out a) is false)
                        return defaultValue;
                    if(byte.TryParse(tempValue[1], out r) is false)
                        return defaultValue;
                    if (byte.TryParse(tempValue[2], out g) is false)
                        return defaultValue;
                    if (byte.TryParse(tempValue[3], out b) is false)
                        return defaultValue;
                }
                else if (tempValue.Length is 3)
                {
                    if (byte.TryParse(tempValue[0], out r) is false)
                        return defaultValue;
                    if (byte.TryParse(tempValue[1], out g) is false)
                        return defaultValue;
                    if (byte.TryParse(tempValue[2], out b) is false)
                        return defaultValue;
                }
                else { return defaultValue; }
            }
            catch (System.Exception) { return defaultValue; }
            return Color.FromArgb(a,r,g,b);
        }

        public bool SetValue(string section, string key, Color? value)
        {
            if (value is null)
                return false;
            string[] tempValue = [value.Value.A.ToString(), value.Value.R.ToString(),
                value.Value.G.ToString(), value.Value.B.ToString()];
            return SetValue(section, key, tempValue);
        }

        public Color? GetValue(IniItem<Color> item)
        {
            if (item is null)
                return null;
            if (item.IsValidSectionKey is false)
                return item.DefaultValue;
            return GetValue(item.Section, item.Key, item.DefaultValue);
        }

        public bool SetValue(IniItem<Color> item)
        {
            if (item is null)
                return false;
            if (item.IsValidSectionKey is false)
                return false;
            return SetValue(item.Section, item.Key, item.Value);
        }

        public Vector4? GetValue(string section, string key, Vector4? defaultValue = null)
        {
            string[]? tempValue = GetValue<string[]>(section, key, null);
            if (tempValue is null)
                return defaultValue;
            if (tempValue.Length is not 4)
                return defaultValue;
            float x = 0;
            float y = 0;
            float z = 0;
            float w = 0;
            try
            {
                if (float.TryParse(tempValue[0], out x) is false)
                    return defaultValue;
                if (float.TryParse(tempValue[1], out y) is false)
                    return defaultValue;
                if (float.TryParse(tempValue[2], out z) is false)
                    return defaultValue;
                if (float.TryParse(tempValue[3], out w) is false)
                    return defaultValue;
            }
            catch (System.Exception) { return defaultValue; }
            return new Vector4(x, y, z, w);
        }

        public bool SetValue(string section, string key, Vector4? value)
        {
            if (value is null)
                return false;
            string[] tempValue = [value.Value.X.ToString(), value.Value.Y.ToString(),
                value.Value.Z.ToString(), value.Value.W.ToString()];
            return SetValue(section, key, tempValue.ToArray());
        }

        public Vector4? GetValue(IniItem<Vector4> item)
        {
            if (item is null)
                return null;
            if (item.IsValidSectionKey is false)
                return item.DefaultValue;
            return GetValue(item.Section, item.Key, item.DefaultValue);
        }

        public bool SetValue(IniItem<Vector4> item)
        {
            if (item is null)
                return false;
            if (item.IsValidSectionKey is false)
                return false;
            return SetValue(item.Section, item.Key, item.Value);
        }

    }

}
