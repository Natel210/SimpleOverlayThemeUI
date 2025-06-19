namespace SimpleOverlayTheme.Share.StringTable.Item
{
    /// <summary>
    /// Represents a key within a specific section of an INI configuration file. <br/>
    /// This class is used to uniquely identify entries in a sectioned key-value structure.
    /// </summary>
    public class IniPair
    {
        /// <summary> The name of the INI section (e.g., "[Graphics]" or "[Settings]"). </summary>
        public readonly string Section;

        /// <summary> The key name within the specified section (e.g., "Resolution" or "EnableFeatureX"). </summary>
        public readonly string Key;

        /// <summary> Initializes a new instance of the <see cref="IniPair"/> class using the specified section and key. </summary>
        /// <param name="section">The name of the INI section.</param>
        /// <param name="key">The key within the specified section.</param>
        public IniPair(string section, string key)
        {
            Section = section;
            Key = key;
        }
    }
}
