using System.Collections.Generic;
using ThemeXamlGenerator.Theme.Data.Internal;

namespace ThemeXamlGenerator.Theme.Data
{
    /// <summary></summary>
    static public class ThemeDataGroup
    {
        /// <summary></summary>
        static public System.IO.DirectoryInfo? RootPath {
            get => ThemeDataGroupCore.Instance.DataRootPath;
            set => ThemeDataGroupCore.Instance.DataRootPath = value;
        }

        /// <summary>internal new <see cref="IThemeData"/></summary>
        static public bool AddData(string key) => ThemeDataGroupCore.Instance.CreateData(key);

        /// <summary></summary>
        /// <returns>null if not found</returns>
        static public IThemeData? GetData(string key) => ThemeDataGroupCore.Instance.GetData(key);

        /// <summary></summary>
        static public IThemeData GetData_NullThrow(string key) => ThemeDataGroupCore.Instance.GetData_NullThrow(key);

        /// <summary></summary>
        static public ICollection<string> DataKeys() => ThemeDataGroupCore.Instance.DataKeys();

        /// <summary></summary>
        static public bool RemoveData(string name) => ThemeDataGroupCore.Instance.RemoveData(name);

        /// <summary></summary>
        static public void ClearData() => ThemeDataGroupCore.Instance.ClearData();

        /// <summary>Discover From <see cref="RootPath"/></summary>
        static public void DiscoverData() => ThemeDataGroupCore.Instance.DiscoverData();

        /// <summary></summary>
        static public void LoadData(string name) => ThemeDataGroupCore.Instance.LoadData(name);

        /// <summary></summary>
        static public void LoadDataAll() => ThemeDataGroupCore.Instance.LoadDataAll();

        /// <summary></summary>
        static public void SaveData(string name) => ThemeDataGroupCore.Instance.SaveData(name);

        /// <summary></summary>
        static public void SaveDataAll() => ThemeDataGroupCore.Instance.SaveDataAll();

        /// <summary></summary>
        static public void SetDataToDefault() => ThemeDataGroupCore.Instance.SetDataToDefault();
    }
}
