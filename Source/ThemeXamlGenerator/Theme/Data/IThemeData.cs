namespace ThemeXamlGenerator.Theme.Data
{
    /// <summary></summary>
    public interface IThemeData
    {
        /// <summary> get => deep copy, only view, don't able chanage items... </summary>
        System.IO.FileInfo? FilePath { get; set; }

        /// <summary></summary>
        IThemeData Clone();

        /// <summary></summary>
        bool Add(string key);

        /// <summary></summary>
        bool Add(string key, string type, string value, string xamlKey);

        /// <summary></summary>
        IThemeDataProperty? Get(string key);

        /// <summary></summary>
        IThemeDataProperty GetNullThrow(string key);

        /// <summary></summary>
        System.Collections.Generic.ICollection<string> Keys();

        /// <summary></summary>
        bool Remove(string name);

        /// <summary></summary>
        public void Clear();
        
        /// <summary></summary>
        void Load();

        /// <summary></summary>
        void Save();
    }
}
