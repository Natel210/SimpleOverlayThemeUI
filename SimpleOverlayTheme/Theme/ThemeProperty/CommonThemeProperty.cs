using SimpleFileIO.State.Ini;
using SimpleOverlayTheme.Share.StringTable;
using SimpleOverlayTheme.Theme.Interface;
using System.Windows;
using System.Windows.Media;

namespace SimpleOverlayTheme.Theme.ThemeProperty
{
    /// <summary>
    /// Represents the common theme properties group. <br/>
    /// Includes base information such as theme name, font sizes, UI spacing, and basic color palette.
    /// </summary>
    internal partial class CommonThemeProperty : IThemeProperty
    {
        /// <summary> Collection of all overlay theme properties managed by this group. </summary>
        private readonly List<IThemePropertyValue> _themePropertyValues;

        internal CommonThemeProperty Clone()
        {
            return new CommonThemeProperty()
            {
                ThemeName = this.ThemeName.Clone(),
                FontSize_Default = this.FontSize_Default.Clone(),
                FontSize_Header1 = this.FontSize_Header1.Clone(),
                FontSize_Header2 = this.FontSize_Header2.Clone(),
                FontSize_Header3 = this.FontSize_Header3.Clone(),
                FontSize_Header4 = this.FontSize_Header4.Clone(),
                FontSize_Header5 = this.FontSize_Header5.Clone(),
                FontSize_Header6 = this.FontSize_Header6.Clone(),
                Thickness_Default = this.Thickness_Default.Clone(),
                Thickness_Zero = this.Thickness_Zero.Clone(),
                ColorPalette_Background = this.ColorPalette_Background.Clone(),
                ColorPalette_Foreground = this.ColorPalette_Foreground.Clone(),
                ColorPalette_Foreground_Disable = this.ColorPalette_Foreground_Disable.Clone(),
                ColorPalette_Highlight = this.ColorPalette_Highlight.Clone(),
                ColorPalette_Line = this.ColorPalette_Line.Clone(),
                ColorPalette_Mask = this.ColorPalette_Mask.Clone(),
                ColorPalette_Outline = this.ColorPalette_Outline.Clone(),
                ColorPalette_Selection = this.ColorPalette_Selection.Clone(),
            };
        }

        /// <summary> Initializes the <see cref="CommonThemeProperty"/> with all default values. </summary>
        internal CommonThemeProperty()
        {
            _themePropertyValues = new()
            {
                ThemeName,
                FontSize_Default,
                FontSize_Header1,
                FontSize_Header2,
                FontSize_Header3,
                FontSize_Header4,
                FontSize_Header5,
                FontSize_Header6,
                Thickness_Default,
                Thickness_Zero,
                ColorPalette_Background,
                ColorPalette_Foreground,
                ColorPalette_Foreground_Disable,
                ColorPalette_Highlight,
                ColorPalette_Line,
                ColorPalette_Mask,
                ColorPalette_Outline,
                ColorPalette_Selection,
            };
        }
    }

    #region ========== Interface - IThemeProperty ==========
    internal partial class CommonThemeProperty
    {

        /// <inheritdoc />
        public bool Apply(IINIState? iniState)
        {
            if (_themePropertyValues is null)
                return false;
            bool result = true;
            foreach (var item in _themePropertyValues)
                result &= item.Apply(iniState);
            return result;
        }

        /// <inheritdoc />
        public bool Restore(IINIState? iniState)
        {
            if (_themePropertyValues is null)
                return false;
            bool result = true;
            foreach (var item in _themePropertyValues)
                result &= item.Restore(iniState);
            return result;
        }

        /// <inheritdoc />
        public void ResetValueToDefault()
        {
            if (_themePropertyValues is null)
                return;
            foreach (var item in _themePropertyValues)
                item.ResetValueToDefault();
        }

    }
    #endregion

    #region ========== Identity ==========
    internal partial class CommonThemeProperty
    {

        /// <summary>  Gets or sets the name of the theme.</summary>
        internal ThemePropertyValue<string> ThemeName { get; private set; }
            = new(ThemeKey.Common.ThemeName.Ini.Section,
                ThemeKey.Common.ThemeName.Ini.Key, "Temp");

    }
    #endregion

    #region ========== Font Sizes ==========
    internal partial class CommonThemeProperty
    {

        /// <summary>Gets or sets the default body font size.</summary>
        internal ThemePropertyValue<double> FontSize_Default { get; private set; }
            = new(ThemeKey.FontSize.Default.Ini.Section,
                ThemeKey.FontSize.Default.Ini.Key, 10.0);

        /// <summary>Gets or sets the font size for Header1.</summary>
        internal ThemePropertyValue<double> FontSize_Header1 { get; private set; }
            = new(ThemeKey.FontSize.Header1.Ini.Section,
                ThemeKey.FontSize.Header1.Ini.Key, 32.0);

        /// <summary>Gets or sets the font size for Header2.</summary>
        internal ThemePropertyValue<double> FontSize_Header2 { get; private set; }
            = new(ThemeKey.FontSize.Header2.Ini.Section,
                ThemeKey.FontSize.Header2.Ini.Key, 24.0);

        /// <summary>Gets or sets the font size for Header3.</summary>
        internal ThemePropertyValue<double> FontSize_Header3 { get; private set; }
            = new(ThemeKey.FontSize.Header3.Ini.Section,
                ThemeKey.FontSize.Header3.Ini.Key, 18.72);

        /// <summary>Gets or sets the font size for Header4.</summary>
        internal ThemePropertyValue<double> FontSize_Header4 { get; private set; }
            = new(ThemeKey.FontSize.Header4.Ini.Section,
                ThemeKey.FontSize.Header4.Ini.Key, 16.0);

        /// <summary>Gets or sets the font size for Header5.</summary>
        internal ThemePropertyValue<double> FontSize_Header5 { get; private set; }
            = new(ThemeKey.FontSize.Header5.Ini.Section,
                ThemeKey.FontSize.Header5.Ini.Key, 13.28);

        /// <summary>Gets or sets the font size for Header6.</summary>
        internal ThemePropertyValue<double> FontSize_Header6 { get; private set; }
            = new(ThemeKey.FontSize.Header6.Ini.Section,
                ThemeKey.FontSize.Header6.Ini.Key, 10.72);

    }
    #endregion

    #region ========== Thickness ==========
    internal partial class CommonThemeProperty
    {

        /// <summary>Gets or sets the default UI element thickness.</summary>
        internal ThemePropertyValue<Thickness> Thickness_Default { get; private set; }
            = new(ThemeKey.Tickness.Default.Ini.Section,
                ThemeKey.Tickness.Default.Ini.Key, new Thickness(1));

        /// <summary>Gets or sets zero-thickness, often used for spacing removal.</summary>
        internal ThemePropertyValue<Thickness> Thickness_Zero { get; private set; }
            = new(ThemeKey.Tickness.Zero.Ini.Section,
                ThemeKey.Tickness.Zero.Ini.Key, new Thickness(0));

    }
    #endregion

    #region ========== Color Palette ==========
    internal partial class CommonThemeProperty
    {

        /// <summary>Main background color.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Background { get; private set; }
            = new(ThemeKey.ColorPalette.Background.Ini.Section,
                ThemeKey.ColorPalette.Background.Ini.Key, Color.FromArgb(255, 255, 255, 255));

        /// <summary>Main foreground color.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Foreground { get; private set; }
            = new(ThemeKey.ColorPalette.Foreground.Ini.Section,
                ThemeKey.ColorPalette.Foreground.Ini.Key, Color.FromArgb(255, 21, 21, 21));

        /// <summary>Foreground color when disabled.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Foreground_Disable { get; private set; }
            = new(ThemeKey.ColorPalette.Foreground_Disable.Ini.Section,
                ThemeKey.ColorPalette.Foreground_Disable.Ini.Key, Color.FromArgb(160, 128, 128, 128));

        /// <summary>Highlight color used for hover or active indication.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Highlight { get; private set; }
            = new(ThemeKey.ColorPalette.Highlight.Ini.Section,
                ThemeKey.ColorPalette.Highlight.Ini.Key, Color.FromArgb(180, 21, 21, 21));

        /// <summary>Line color, typically used for underlines or separators.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Line { get; private set; }
            = new(ThemeKey.ColorPalette.Line.Ini.Section,
                ThemeKey.ColorPalette.Line.Ini.Key, Color.FromArgb(255, 128, 128, 128));

        /// <summary>Mask or overlay tint color, often semi-transparent.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Mask { get; private set; }
            = new(ThemeKey.ColorPalette.Mask.Ini.Section,
                ThemeKey.ColorPalette.Mask.Ini.Key, Color.FromArgb(160, 128, 128, 128));

        /// <summary>Outline color used for borders and frames.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Outline { get; private set; }
            = new(ThemeKey.ColorPalette.Outline.Ini.Section,
                ThemeKey.ColorPalette.Outline.Ini.Key, Color.FromArgb(128, 128, 128, 128));

        /// <summary>Selection background color.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Selection { get; private set; }
            = new(ThemeKey.ColorPalette.Selection.Ini.Section,
                ThemeKey.ColorPalette.Selection.Ini.Key, Color.FromArgb(255, 128, 128, 128));

    }
    #endregion
}