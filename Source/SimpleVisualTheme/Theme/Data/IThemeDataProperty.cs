namespace SimpleVisualTheme.Theme.Data
{
    /// <summary></summary>
    public interface IThemeDataProperty
    {
        /// <summary></summary>
        string XamlKey { get; set; }

        /// <summary></summary>
        string Type { get; set; }

        /// <summary></summary>
        string Value { get; set; }

        /// <summary></summary>
        IThemeDataProperty Clone();
    }
}
