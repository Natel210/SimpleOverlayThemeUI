namespace SimpleVisualTheme.Theme.Data
{
    /// <summary></summary>
    public interface IThemeData
    {
        /// <summary> get => deep copy, only view, don't able chanage items... </summary>
        System.IO.FileInfo? FilePath { get; set; }

        /// <summary></summary>
        void Load();

        /// <summary></summary>
        void Save();

        /// <summary></summary>
        IThemeData Clone();

        /// <summary></summary>
        bool AddProperty(string key);

        /// <summary></summary>
        bool AddProperty(string key, string type, string value, string xamlKey);

        /// <summary></summary>
        IThemeDataProperty? GetProperty(string key);

        /// <summary></summary>
        IThemeDataProperty GetPropertyNullThrow(string key);

        /// <summary></summary>
        System.Collections.Generic.ICollection<string> PropertyKeys();

        /// <summary></summary>
        bool RemoveProperty(string name);

        /// <summary></summary>
        public void ClearProperty();

    }
}
