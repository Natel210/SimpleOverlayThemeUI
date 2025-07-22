using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleVisualTheme.Theme.Data.Internal
{
    /// <summary>Singleton</summary>
    internal class ThemeDataGroup
    {
        /// <summary></summary>
        static internal ThemeDataGroup Instance { get; } = new ThemeDataGroup();
        private ThemeDataGroup() { }

        private ConcurrentDictionary<string, ThemeData> _themeDataDic = new ();

        private DirectoryInfo? _dataRootPath = null;
        private readonly ReaderWriterLockSlim _dataRootPathLock = new();
        /// <summary>
        /// theme data json root path. <br/>
        /// get => deep copy, only view, don't able chanage items.
        /// </summary>
        internal DirectoryInfo? DataRootPath
        {
            get
            {
                _dataRootPathLock.EnterReadLock();
                try
                {
                    return _dataRootPath is not null ? new(_dataRootPath.FullName) : null;
                }
                finally
                {
                    _dataRootPathLock.ExitReadLock();
                }
            }
            set
            {
                _dataRootPathLock.EnterWriteLock();
                try
                {
                    _dataRootPath = value;
                }
                finally
                {
                    _dataRootPathLock.ExitWriteLock();
                }
            }
        }

        /// <summary>internal new <see cref="IThemeData"/>()</summary>
        internal bool CreateData(string key)
        {
            ThemeData themeData = new();
            if (DataRootPath is not null)
                themeData.FilePath = new(Path.Combine(DataRootPath.FullName, $"{key}.json"));
            return _themeDataDic.TryAdd(key, themeData);
        }

        /// <summary></summary>
        /// <returns>null if not found</returns>
        internal IThemeData? GetData(string key) => _themeDataDic.TryGetValue(key, out ThemeData? themeData) is true ? themeData : null;

        /// <summary></summary>
        internal IThemeData GetDataNullThrow(string key) => GetData(key) ?? throw new InvalidDataException($"ThemeData '{key}' is null or not initialized.");

        /// <summary></summary>
        internal ICollection<string> DataKeys() => new List<string>(_themeDataDic.Keys);

        /// <summary></summary>
        internal bool RemoveData(string name) => _themeDataDic.TryRemove(name, out _);

        /// <summary></summary>
        internal void ClearData() => _themeDataDic.Clear();

        /// <summary>Data Discover From <see cref="DataRootPath"/></summary>
        internal void DiscoverData()
        {
            if (DataRootPath is null)
            {
                throw new ArgumentNullException($"{nameof(DataRootPath)} is null.");
            }

            if (DataRootPath.Exists is false)
            {
                DataRootPath.Create();
            }

            ClearData();
            var fileInfoList = DataRootPath.EnumerateFiles("*.json", SearchOption.TopDirectoryOnly).ToList();
            if (fileInfoList.Count > 0)
            {
                Parallel.ForEach(
                    fileInfoList,
                    new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                    fileInfo =>
                    {
                        string fileName = Path.GetFileNameWithoutExtension(fileInfo.Name);
                        CreateData(fileName);
                        if (GetData(fileName) is var themeData && themeData is not null)
                        {
                            themeData.FilePath = fileInfo;
                            themeData.Load();
                        }
                    }
                );
            }
            else
            {
                SetDataToDefault();
            }
        }

        /// <summary></summary>
        internal void LoadData(string name) => GetDataNullThrow(name).Load();

        /// <summary></summary>
        internal void LoadDataAll() => Parallel.ForEach(_themeDataDic.Values, themeData => themeData.Load());

        /// <summary></summary>
        internal void SaveData(string name) => GetDataNullThrow(name).Save();

        /// <summary></summary>
        internal void SaveDataAll() => Parallel.ForEach(_themeDataDic.Values, themeData => themeData.Save());

        /// <summary></summary>
        internal void SetDataToDefault()
        {
            if (DataRootPath is null)
            {
                throw new ArgumentNullException($"{nameof(DataRootPath)} is null.");
            }

            if (DataRootPath.Exists is false)
            {
                DataRootPath.Create();
            }

            ClearData();
            CreateLightTheme();
            CreateDarkTheme();
            //SetDefaultAtClassic(); // not yet.
            CreateCurrentTheme();
        }

        private void CreateLightTheme()
        {
            var themeDataName = "Light";
            CreateData(themeDataName);
            var themeData = GetData(themeDataName) ?? throw new InvalidDataException($"ThemeData '{themeDataName}' is null or not initialized.");
            themeData.GetPropertyNullThrow("FontSize.Header").Value = "44.0";
            themeData.GetPropertyNullThrow("FontSize.Default").Value = "24.0";
            themeData.GetPropertyNullThrow("Color.Common.Background.Default").Value = "#FFFFFFFF";
            themeData.GetPropertyNullThrow("Color.Common.Foreground.Default").Value = "#FF151515";
            themeData.GetPropertyNullThrow("Color.Common.Foreground.Disable").Value = "#A0808080";
            themeData.GetPropertyNullThrow("Color.Common.Outline.Default").Value = "#FF808080";
            themeData.GetPropertyNullThrow("Color.Effect.Background.Active").Value = "#40808080";
            themeData.GetPropertyNullThrow("Color.Effect.Background.Mouseover").Value = "#25808080";
            themeData.GetPropertyNullThrow("Color.Effect.Outline.Active").Value = "#FF000000";
            themeData.GetPropertyNullThrow("Color.Effect.Outline.Mouseover").Value = "#D0000000";
        }

        private void CreateDarkTheme()
        {
            var themeDataName = "Dark";
            CreateData(themeDataName);
            var themeData = GetData(themeDataName) ?? throw new InvalidDataException($"ThemeData '{themeDataName}' is null or not initialized.");
            themeData.GetPropertyNullThrow("FontSize.Header").Value = "44.0";
            themeData.GetPropertyNullThrow("FontSize.Default").Value = "24.0";
            themeData.GetPropertyNullThrow("Color.Common.Background.Default").Value = "#FF252525";
            themeData.GetPropertyNullThrow("Color.Common.Foreground.Default").Value = "#FFDADADA";
            themeData.GetPropertyNullThrow("Color.Common.Foreground.Disable").Value = "#A0808080";
            themeData.GetPropertyNullThrow("Color.Common.Outline.Default").Value = "#80808080";
            themeData.GetPropertyNullThrow("Color.Effect.Background.Active").Value = "#40808080";
            themeData.GetPropertyNullThrow("Color.Effect.Background.Mouseover").Value = "#25808080";
            themeData.GetPropertyNullThrow("Color.Effect.Outline.Active").Value = "#FFEBEBEB";
            themeData.GetPropertyNullThrow("Color.Effect.Outline.Mouseover").Value = "#80EBEBEB";
        }

        private void CreateClassicTheme()
        {
            var themeDataName = "Classic";
            CreateData(themeDataName);
            var themeData = GetData(themeDataName) ?? throw new InvalidDataException($"ThemeData '{themeDataName}' is null or not initialized.");
            themeData.GetPropertyNullThrow("FontSize.Header").Value = "44.0";
            themeData.GetPropertyNullThrow("FontSize.Default").Value = "24.0";
            themeData.GetPropertyNullThrow("Color.Common.Background.Default").Value = "#FFFFFFFF";
            themeData.GetPropertyNullThrow("Color.Common.Foreground.Default").Value = "#FF151515";
            themeData.GetPropertyNullThrow("Color.Common.Foreground.Disable").Value = "#A0808080";
            themeData.GetPropertyNullThrow("Color.Common.Outline.Default").Value = "#FF808080";
            themeData.GetPropertyNullThrow("Color.Effect.Background.Active").Value = "#40808080";
            themeData.GetPropertyNullThrow("Color.Effect.Background.Mouseover").Value = "#25808080";
            themeData.GetPropertyNullThrow("Color.Effect.Outline.Active").Value = "#FF000000";
            themeData.GetPropertyNullThrow("Color.Effect.Outline.Mouseover").Value = "#D0000000";
        }

        private void CreateCurrentTheme()
        {
            var themeDataName = "Current";
            CreateData(themeDataName);
            var themeData = GetData(themeDataName) ?? throw new InvalidDataException($"ThemeData '{themeDataName}' is null or not initialized.");
            themeData.GetPropertyNullThrow("FontSize.Header").Value = "44.0";
            themeData.GetPropertyNullThrow("FontSize.Default").Value = "24.0";
            themeData.GetPropertyNullThrow("Color.Common.Background.Default").Value = "#FFFFFFFF";
            themeData.GetPropertyNullThrow("Color.Common.Foreground.Default").Value = "#FF151515";
            themeData.GetPropertyNullThrow("Color.Common.Foreground.Disable").Value = "#A0808080";
            themeData.GetPropertyNullThrow("Color.Common.Outline.Default").Value = "#FF808080";
            themeData.GetPropertyNullThrow("Color.Effect.Background.Active").Value = "#40808080";
            themeData.GetPropertyNullThrow("Color.Effect.Background.Mouseover").Value = "#25808080";
            themeData.GetPropertyNullThrow("Color.Effect.Outline.Active").Value = "#FF000000";
            themeData.GetPropertyNullThrow("Color.Effect.Outline.Mouseover").Value = "#D0000000";
        }

    }
}
