namespace SimpleOverlayTheme.Share.StringTable.Item
{
    /// <summary>
    /// Represents a mapping between a XAML resource name and an INI section/key pair. <br/>
    /// Used to associate a visual theme element with a configuration source.
    /// </summary>
    public class ThemePair
    {
        /// <summary> The INI section/key pair that identifies the configuration source. </summary>
        public readonly IniPair Ini;

        /// <summary> The name of the XAML resource or key associated with this theme element. </summary>
        public readonly string Xaml;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemePair"/> class
        /// using the given XAML resource name and INI section/key strings.
        /// </summary>
        /// <param name="xaml">The name of the XAML resource or key.</param>
        /// <param name="iniSection">The INI section name.</param>
        /// <param name="iniKey">The INI key within the section.</param>
        public ThemePair(string xaml, string iniSection, string iniKey)
        {
            Xaml = xaml;
            Ini = new(iniSection, iniKey);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemePair"/> class
        /// using the given XAML resource name and an <see cref="IniPair"/>.
        /// </summary>
        /// <param name="xaml">The name of the XAML resource or key.</param>
        /// <param name="iniPair">An <see cref="IniPair"/> representing the section/key.</param>
        public ThemePair(string xaml, IniPair iniPair)
        {
            Xaml = "";
            Ini = iniPair;
        }

    }
}
