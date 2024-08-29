using System;
using System.IO;
using System.Numerics;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;

namespace utility.ini
{
    public class IniItem<T> where T : notnull
    {
        public string Section { get; set; } = "";
        public string Key { get; set; } = "";
        public T DefaultValue { get; set; } = CreateInstanceOrAssign();
        public T Value { get; set; } = CreateInstanceOrAssign();
        public bool IsValidSectionKey { get => !string.IsNullOrEmpty(Section) && !string.IsNullOrEmpty(Key); }

        public IniItem()
        {
        }

        public IniItem(IniItem<T> iniItem)
        {
            Section = iniItem.Section ?? throw new ArgumentNullException(nameof(iniItem.Section));
            Key = iniItem.Key ?? throw new ArgumentNullException(nameof(iniItem.Key));
            DefaultValue = CreateInstanceOrAssign(iniItem.DefaultValue);
            Value = CreateInstanceOrAssign(iniItem.Value);
        }

        static private T CreateInstanceOrAssign()
        {
            if (typeof(T).IsValueType)
            {
#pragma warning disable CS8600
                T result = default;
#pragma warning restore CS8600
                if (result is null)
                    throw new ArgumentNullException($"Type {typeof(T)} default value is null.");
                return result;
            }
                
            var constructor = typeof(T).GetConstructor(Type.EmptyTypes);
            if (constructor != null)
                return (T)constructor.Invoke(null);
            throw new InvalidOperationException($"Type {typeof(T)} does not have a parameterless constructor.");
        }

        private T CreateInstanceOrAssign(T value)
        {
            var constructor = typeof(T).GetConstructor(new[] { typeof(T) });
            if (constructor != null)
                return (T)constructor.Invoke(new object[] { value });
            else
                return value;
        }
    }

    public partial class IniFile
    {
        private string _filePath = "";
        private readonly Dictionary<string, Dictionary<string, string>> _sections = new();

        public string FilePath
        {
            get => _filePath;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value));
                if (_filePath != value)
                {
                    _filePath = value;
                    Load();
                }
            }
        }

        public IniFile(string path)
        {
            FilePath = path ?? throw new ArgumentNullException(nameof(path));
        }

        public string GetValue(string section, string key, string defaultValue)
        {
            if (_sections.ContainsKey(section) is false)
                return defaultValue;
            if (_sections[section].ContainsKey(key) is false)
                return defaultValue;
            string tempValue = _sections[section][key];
            if (string.IsNullOrEmpty(tempValue) is true)
                return defaultValue;
            return tempValue;
        }

        public bool SetValue(string section, string key, string value)
        {
            if (string.IsNullOrEmpty(section))
                throw new ArgumentNullException(nameof(section));
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            if (!_sections.ContainsKey(section))
                _sections[section] = new Dictionary<string, string>();

            _sections[section][key] = value;
            return true;
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(_filePath))
                throw new InvalidOperationException("File path cannot be null or empty.");

            if (!File.Exists(_filePath))
            {
                string? directoryPath = Path.GetDirectoryName(_filePath);
                if (directoryPath is null)
                    throw new InvalidOperationException("Directory path cannot be determined.");
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
            }

            using StreamWriter writer = new(_filePath);
            foreach (var section in _sections)
            {
                writer.WriteLine($"[{section.Key}]");
                foreach (var keyValue in section.Value)
                {
                    writer.WriteLine($"{keyValue.Key} = {keyValue.Value}");
                }
                writer.WriteLine();
            }
        }

        public bool Load()
        {
            if (CheckFileExist() is false)
                return false;

            string currentSection = "";
            foreach (string line in File.ReadLines(_filePath))
            {
                string trimmedLine = line.Trim();
                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    currentSection = trimmedLine.Substring(1, trimmedLine.Length - 2);
                    if (!_sections.ContainsKey(currentSection))
                    {
                        _sections[currentSection] = new Dictionary<string, string>();
                    }
                }
                else if (trimmedLine.Contains("=") && !trimmedLine.StartsWith(";") && currentSection != "")
                {
                    string[] parts = trimmedLine.Split('=', 2);
                    _sections[currentSection][parts[0].Trim()] = parts[1].Trim();
                }
            }
            return true;
        }

        public bool CheckFileExist()
        {
            return File.Exists(_filePath);
        }
    }

    /// <summary>
    /// 확장 기능
    /// </summary>
    public partial class IniFile
    {
        public string GetValue(IniItem<string> item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!item.IsValidSectionKey)
                return item.DefaultValue;
            item.Value = GetValue(item.Section, item.Key, item.DefaultValue);
            return item.Value;
        }

        public bool SetValue(IniItem<string> item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!item.IsValidSectionKey)
                return false;
            return SetValue(item.Section, item.Key, item.Value);
        }

        public double GetValue(string section, string key, double defaultValue)
        {
            string tempValue = GetValue(section, key, defaultValue.ToString());
            if (double.TryParse(tempValue, out double result))
                return result;
            return defaultValue;
        }

        public bool SetValue(string section, string key, double value)
        {
            return SetValue(section, key, value.ToString());
        }

        public double GetValue(IniItem<double> item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!item.IsValidSectionKey)
                return item.DefaultValue;
            item.Value = GetValue(item.Section, item.Key, item.DefaultValue);
            return item.Value;
        }

        public bool SetValue(IniItem<double> item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!item.IsValidSectionKey)
                return false;
            return SetValue(item.Section, item.Key, item.Value);
        }

        public DirectoryInfo GetValue(string section, string key, DirectoryInfo defaultValue, DirectoryInfo? superDirectory = null)
        {
            string tempValue = GetValue(section, key, defaultValue.FullName);
            return superDirectory is null
                ? new DirectoryInfo(tempValue)
                : new DirectoryInfo(Path.Combine(superDirectory.FullName, tempValue));
        }

        public bool SetValue(string section, string key, DirectoryInfo value, DirectoryInfo? superDirectory = null)
        {
            string relativePath = superDirectory is null
                ? value.FullName
                : value.FullName.Replace(superDirectory.FullName, "").TrimStart(Path.DirectorySeparatorChar);
            return SetValue(section, key, relativePath);
        }

        public DirectoryInfo GetValue(IniItem<DirectoryInfo> item, DirectoryInfo? superDirectory = null)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!item.IsValidSectionKey)
                return item.DefaultValue;
            return GetValue(item.Section, item.Key, item.DefaultValue, superDirectory);
        }

        public bool SetValue(IniItem<DirectoryInfo> item, DirectoryInfo? superDirectory = null)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!item.IsValidSectionKey)
                return false;
            return SetValue(item.Section, item.Key, item.Value, superDirectory);
        }

        public FileInfo GetValue(string section, string key, FileInfo defaultValue, DirectoryInfo? superDirectory = null)
        {
            string tempValue = GetValue(section, key, defaultValue.FullName);
            return superDirectory is null
                ? new FileInfo(tempValue)
                : new FileInfo(Path.Combine(superDirectory.FullName, tempValue));
        }

        public bool SetValue(string section, string key, FileInfo value, DirectoryInfo? superDirectory = null)
        {
            string relativePath = superDirectory is null
                ? value.FullName
                : value.FullName.Replace(superDirectory.FullName, "").TrimStart(Path.DirectorySeparatorChar);
            return SetValue(section, key, relativePath);
        }

        public FileInfo GetValue(IniItem<FileInfo> item, DirectoryInfo? superDirectory = null)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!item.IsValidSectionKey)
                return item.DefaultValue;
            return GetValue(item.Section, item.Key, item.DefaultValue, superDirectory);
        }

        public bool SetValue(IniItem<FileInfo> item, DirectoryInfo? superDirectory = null)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!item.IsValidSectionKey)
                return false;
            return SetValue(item.Section, item.Key, item.Value, superDirectory);
        }

        public string[] GetValue(string section, string key, string[] defaultValue)
        {
            string tempValue = GetValue(section, key, string.Join(", ", defaultValue));
            return tempValue.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(item => item.Trim())
                .ToArray();
        }

        public bool SetValue(string section, string key, string[] value)
        {
            return value.Length > 0 && SetValue(section, key, string.Join(", ", value));
        }

        public string[] GetValue(IniItem<string[]> item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!item.IsValidSectionKey)
                return item.DefaultValue;
            item.Value = GetValue(item.Section, item.Key, item.DefaultValue);
            return item.Value;
        }

        public bool SetValue(IniItem<string[]> item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!item.IsValidSectionKey)
                return false;
            return SetValue(item.Section, item.Key, item.Value);
        }

        public Color GetValue(string section, string key, Color defaultValue)
        {
            string[] tempValue = GetValue(section, key, Array.Empty<string>());
            if (tempValue.Length is 3 || tempValue.Length is 4)
            {
                byte a = tempValue.Length == 4 ? byte.Parse(tempValue[0]) : (byte)255;
                byte r = byte.Parse(tempValue[tempValue.Length - 3]);
                byte g = byte.Parse(tempValue[tempValue.Length - 2]);
                byte b = byte.Parse(tempValue[tempValue.Length - 1]);
                return Color.FromArgb(a, r, g, b);
            }
            return defaultValue;
        }

        public bool SetValue(string section, string key, Color value)
        {
            string[] tempValue = new string[]
            {
                value.A.ToString(), value.R.ToString(),
                value.G.ToString(), value.B.ToString()
            };
            return SetValue(section, key, tempValue);
        }

        public Color GetValue(IniItem<Color> item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!item.IsValidSectionKey)
                return item.DefaultValue;
            item.Value = GetValue(item.Section, item.Key, item.DefaultValue);
            return item.Value;
        }

        public bool SetValue(IniItem<Color> item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!item.IsValidSectionKey)
                return false;
            return SetValue(item.Section, item.Key, item.Value);
        }

        public Vector4 GetValue(string section, string key, Vector4 defaultValue)
        {
            string[] tempValue = GetValue(section, key, Array.Empty<string>());
            if (tempValue.Length is 4)
            {
                float x = float.Parse(tempValue[0]);
                float y = float.Parse(tempValue[1]);
                float z = float.Parse(tempValue[2]);
                float w = float.Parse(tempValue[3]);
                return new Vector4(x, y, z, w);
            }
            return defaultValue;
        }

        public bool SetValue(string section, string key, Vector4 value)
        {
            string[] tempValue = new string[]
            {
                value.X.ToString(), value.Y.ToString(),
                value.Z.ToString(), value.W.ToString()
            };
            return SetValue(section, key, tempValue);
        }

        public Vector4 GetValue(IniItem<Vector4> item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!item.IsValidSectionKey)
                return item.DefaultValue;
            item.Value = GetValue(item.Section, item.Key, item.DefaultValue);
            return item.Value;
        }

        public bool SetValue(IniItem<Vector4> item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!item.IsValidSectionKey)
                return false;
            return SetValue(item.Section, item.Key, item.Value);
        }
    }
}