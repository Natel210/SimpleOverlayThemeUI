using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;

namespace ThemeXamlGenerator.Theme.Data.Internal
{
    internal class ThemeData : IThemeData
    {
        private FileInfo? _filePath = null;
        private readonly ReaderWriterLockSlim _filePathLock = new();
        /// <summary> get => deep copy, only view, don't able chanage items... </summary>
        public FileInfo? FilePath
        {
            get
            {
                _filePathLock.EnterReadLock();
                try
                {
                    return _filePath is not null ? new(_filePath.FullName) : null;
                }
                finally
                {
                    _filePathLock.ExitReadLock();
                }
            }
            set
            {
                _filePathLock.EnterWriteLock();
                try
                {
                    _filePath = value;
                }
                finally
                {
                    _filePathLock.ExitWriteLock();
                }
            }
        }

        public ConcurrentDictionary<string, ThemeDataProperty> _properties { get; private set; } = new() {
            ["FontSize.Header"] = new ThemeDataProperty() { Type = "Double", Value = "44.0",
                XamlKey = "SimpleVisualTheme.ThemeKey.FontSize.Header"
            },
            ["FontSize.Default"] = new ThemeDataProperty() { Type = "Double", Value = "24.0",
                XamlKey = "SimpleVisualTheme.ThemeKey.FontSize.Default"
            },
            ["Color.Common.Background.Default"] = new ThemeDataProperty() { Type = "SolidColorBrush", Value = "#FFFFFFFF",
                XamlKey = "SimpleVisualTheme.ThemeKey.Color.Common.Background.Default"
            },
            ["Color.Common.Foreground.Default"] = new ThemeDataProperty() { Type = "SolidColorBrush", Value = "#FF151515",
                XamlKey = "SimpleVisualTheme.ThemeKey.Color.Common.Foreground.Default"
            },
            ["Color.Common.Foreground.Disable"] = new ThemeDataProperty() { Type = "SolidColorBrush", Value = "#A0808080",
                XamlKey = "SimpleVisualTheme.ThemeKey.Color.Common.Foreground.Disable"
            },
            ["Color.Common.Outline.Default"] = new ThemeDataProperty() { Type = "SolidColorBrush", Value = "#FF808080",
                XamlKey = "SimpleVisualTheme.ThemeKey.Color.Common.Outline.Default"
            },
            ["Color.Effect.Background.Active"] = new ThemeDataProperty() { Type = "SolidColorBrush", Value = "#40808080",
                XamlKey = "SimpleVisualTheme.ThemeKey.Color.Effect.Background.Active"
            },
            ["Color.Effect.Background.Mouseover"] = new ThemeDataProperty() { Type = "SolidColorBrush", Value = "#25808080",
                XamlKey = "SimpleVisualTheme.ThemeKey.Color.Effect.Background.Mouseover"
            },
            ["Color.Effect.Outline.Active"] = new ThemeDataProperty() { Type = "SolidColorBrush", Value = "#FF000000",
                XamlKey = "SimpleVisualTheme.ThemeKey.Color.Effect.Outline.Active"
            },
            ["Color.Effect.Outline.Mouseover"] = new ThemeDataProperty() { Type = "SolidColorBrush", Value = "#D0000000",
                XamlKey = "SimpleVisualTheme.ThemeKey.Color.Effect.Outline.Mouseover"
            },
        };



        /// <summary></summary>
        public IThemeData Clone() => new ThemeData
        {
            FilePath = FilePath is not null ? new(FilePath.FullName) : null,
            _properties = new(_properties.ToDictionary()),
        };

        /// <summary></summary>
        public bool Add(string key) => _properties.TryAdd(key, new ThemeDataProperty());

        /// <summary></summary>
        public bool Add(string key, string type, string value, string xamlKey) => _properties.TryAdd(key, new ThemeDataProperty() { Type = type, Value = value, XamlKey = xamlKey });

        /// <summary></summary>
        public IThemeDataProperty? Get(string key) => _properties.TryGetValue(key, out var value) ? value : null;

        /// <summary></summary>
        public IThemeDataProperty GetNullThrow(string key) =>
            _properties.TryGetValue(key, out var value) ? value : throw new InvalidDataException($"Property '{key}' is null.");

        /// <summary></summary>
        public ICollection<string> Keys() => new List<string>(_properties.Keys);

        /// <summary></summary>
        public bool Remove(string name) => _properties.TryRemove(name, out _);

        /// <summary></summary>
        public void Clear() => _properties.Clear();

        /// <summary></summary>
        public void Load()
        {
            if (FilePath is null)
            {
                throw new ArgumentNullException($"{nameof(FilePath)} is null.");
            }

            string filePath = FilePath.FullName;

            if (Path.Exists(filePath) is false)
            {
                throw new ArgumentException($"{nameof(FilePath)} is not Exists.\n  Path:{filePath}");
            }

            var properties = JsonSerializer.Deserialize<Dictionary<string, ThemeDataProperty>>(File.ReadAllText(filePath));

            if (properties is null)
            {
                throw new InvalidDataException($"Json deserialize return null.\n  Path:{filePath}");
            }

            _properties = new(properties);
        }

        /// <summary></summary>
        public void Save()
        {
            if (FilePath is null)
            {
                throw new ArgumentNullException($"{nameof(FilePath)} is null.");
            }

            var filePath = FilePath;
            string? parentDirectory = filePath.DirectoryName;

            if (parentDirectory is null)
            {
                throw new ArgumentNullException($"{nameof(FilePath)} root directory is null.\n  Path:{filePath.FullName}");
            }

            if (Directory.Exists(parentDirectory) is false)
            {
                Directory.CreateDirectory(parentDirectory);
            }

            var property = _properties.ToDictionary();
            var jsonString = JsonSerializer.Serialize(property, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath.FullName, jsonString);
        }
    }
}
