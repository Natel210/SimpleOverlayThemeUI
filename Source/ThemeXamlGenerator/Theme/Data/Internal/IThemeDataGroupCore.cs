namespace ThemeXamlGenerator.Theme.Data.Internal
{
    internal interface IThemeDataGroupCore
    {

        /// <summary>
        /// theme json root path. <br/>
        /// get => deep copy, only view, don't able chanage items...
        /// </summary>
        System.IO.DirectoryInfo? DataRootPath { get; set; }

        /// <summary>internal new <see cref="IThemeData"/></summary>
        bool CreateData(string key);

        /// <summary></summary>
        /// <returns>null if not found</returns>
        IThemeData? GetData(string key);

        /// <summary></summary>
        IThemeData GetData_NullThrow(string key);

        /// <summary></summary>
        System.Collections.Generic.ICollection<string> DataKeys();

        /// <summary></summary>
        bool RemoveData(string name);

        /// <summary></summary>
        void ClearData();

        /// <summary>Discover From <see cref="DataRootPath"/></summary>
        void DiscoverData();

        /// <summary></summary>
        void LoadData(string name);

        /// <summary></summary>
        void LoadDataAll();

        /// <summary></summary>
        void SaveData(string name);

        /// <summary></summary>
        void SaveDataAll();

        /// <summary></summary>
        void SetDataToDefault();
    }
}
