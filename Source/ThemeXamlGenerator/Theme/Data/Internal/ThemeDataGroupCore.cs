using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThemeXamlGenerator.Theme.Data.Internal
{
    /// <summary>Singleton</summary>
    internal class ThemeDataGroupCore : IThemeDataGroupCore
    {
        /// <summary></summary>
        static internal IThemeDataGroupCore Instance { get; } = new ThemeDataGroupCore();
        private ThemeDataGroupCore() { }

        private ConcurrentDictionary<string, ThemeData> _themeDataDic = new ();

        private DirectoryInfo? _dataRootPath = null;
        private readonly ReaderWriterLockSlim _dataRootPathLock = new();
        /// <summary>
        /// theme data json root path. <br/>
        /// get => deep copy, only view, don't able chanage items.
        /// </summary>
        public DirectoryInfo? DataRootPath
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
        public bool CreateData(string key)
        {
            ThemeData themeData = new();
            if (DataRootPath is not null)
                themeData.FilePath = new(Path.Combine(DataRootPath.FullName, $"{key}.json"));
            return _themeDataDic.TryAdd(key, themeData);
        }

        /// <summary></summary>
        /// <returns>null if not found</returns>
        public IThemeData? GetData(string key) => _themeDataDic.TryGetValue(key, out ThemeData? themeData) is true ? themeData : null;

        /// <summary></summary>
        public IThemeData GetData_NullThrow(string key) => GetData(key) ?? throw new InvalidDataException($"ThemeData '{key}' is null or not initialized.");

        /// <summary></summary>
        public ICollection<string> DataKeys() => new List<string>(_themeDataDic.Keys);

        /// <summary></summary>
        public bool RemoveData(string name) => _themeDataDic.TryRemove(name, out _);

        /// <summary></summary>
        public void ClearData() => _themeDataDic.Clear();

        /// <summary>Data Discover From <see cref="DataRootPath"/></summary>
        public void DiscoverData()
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
        }

        /// <summary></summary>
        public void LoadData(string name) => GetData_NullThrow(name).Load();

        /// <summary></summary>
        public void LoadDataAll() => Parallel.ForEach(_themeDataDic.Values, themeData => themeData.Load());

        /// <summary></summary>
        public void SaveData(string name) => GetData_NullThrow(name).Save();

        /// <summary></summary>
        public void SaveDataAll() => Parallel.ForEach(_themeDataDic.Values, themeData => themeData.Save());

        /// <summary></summary>
        public void SetDataToDefault()
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
            CreateData("Light");
            var themeData = GetData_NullThrow("Light");
            themeData.GetNullThrow("FontSize.Header").Value = "44.0";
            themeData.GetNullThrow("FontSize.Default").Value = "24.0";
            themeData.GetNullThrow("Color.Common.Background.Default").Value = "#FFFFFFFF";
            themeData.GetNullThrow("Color.Common.Foreground.Default").Value = "#FF151515";
            themeData.GetNullThrow("Color.Common.Foreground.Disable").Value = "#A0808080";
            themeData.GetNullThrow("Color.Common.Outline.Default").Value = "#FF808080";
            themeData.GetNullThrow("Color.Effect.Background.Active").Value = "#40808080";
            themeData.GetNullThrow("Color.Effect.Background.Mouseover").Value = "#25808080";
            themeData.GetNullThrow("Color.Effect.Outline.Active").Value = "#FF000000";
            themeData.GetNullThrow("Color.Effect.Outline.Mouseover").Value = "#D0000000";
        }

        private void CreateDarkTheme()
        {
            CreateData("Dark");
            var themeData = GetData_NullThrow("Dark");
            themeData.GetNullThrow("FontSize.Header").Value = "44.0";
            themeData.GetNullThrow("FontSize.Default").Value = "24.0";
            themeData.GetNullThrow("Color.Common.Background.Default").Value = "#FFFFFFFF";
            themeData.GetNullThrow("Color.Common.Foreground.Default").Value = "#FF151515";
            themeData.GetNullThrow("Color.Common.Foreground.Disable").Value = "#A0808080";
            themeData.GetNullThrow("Color.Common.Outline.Default").Value = "#FF808080";
            themeData.GetNullThrow("Color.Effect.Background.Active").Value = "#40808080";
            themeData.GetNullThrow("Color.Effect.Background.Mouseover").Value = "#25808080";
            themeData.GetNullThrow("Color.Effect.Outline.Active").Value = "#FF000000";
            themeData.GetNullThrow("Color.Effect.Outline.Mouseover").Value = "#D0000000";
        }

        private void CreateClassicTheme()
        {
            CreateData("Classic");
            var themeData = GetData_NullThrow("Classic");
            themeData.GetNullThrow("FontSize.Header").Value = "44.0";
            themeData.GetNullThrow("FontSize.Default").Value = "24.0";
            themeData.GetNullThrow("Color.Common.Background.Default").Value = "#FFFFFFFF";
            themeData.GetNullThrow("Color.Common.Foreground.Default").Value = "#FF151515";
            themeData.GetNullThrow("Color.Common.Foreground.Disable").Value = "#A0808080";
            themeData.GetNullThrow("Color.Common.Outline.Default").Value = "#FF808080";
            themeData.GetNullThrow("Color.Effect.Background.Active").Value = "#40808080";
            themeData.GetNullThrow("Color.Effect.Background.Mouseover").Value = "#25808080";
            themeData.GetNullThrow("Color.Effect.Outline.Active").Value = "#FF000000";
            themeData.GetNullThrow("Color.Effect.Outline.Mouseover").Value = "#D0000000";
        }

        private void CreateCurrentTheme()
        {
            CreateData("Current");
            var themeData = GetData_NullThrow("Current");
            themeData.GetNullThrow("FontSize.Header").Value = "44.0";
            themeData.GetNullThrow("FontSize.Default").Value = "24.0";
            themeData.GetNullThrow("Color.Common.Background.Default").Value = "#FFFFFFFF";
            themeData.GetNullThrow("Color.Common.Foreground.Default").Value = "#FF151515";
            themeData.GetNullThrow("Color.Common.Foreground.Disable").Value = "#A0808080";
            themeData.GetNullThrow("Color.Common.Outline.Default").Value = "#FF808080";
            themeData.GetNullThrow("Color.Effect.Background.Active").Value = "#40808080";
            themeData.GetNullThrow("Color.Effect.Background.Mouseover").Value = "#25808080";
            themeData.GetNullThrow("Color.Effect.Outline.Active").Value = "#FF000000";
            themeData.GetNullThrow("Color.Effect.Outline.Mouseover").Value = "#D0000000";
        }

    }
}
