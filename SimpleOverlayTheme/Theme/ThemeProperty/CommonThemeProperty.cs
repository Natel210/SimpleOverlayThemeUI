using SimpleFileIO.State.Ini;
using SimpleOverlayTheme.Theme.Interface;
using System.Windows;
using System.Windows.Media;

namespace SimpleOverlayTheme.Theme.ThemeProperty
{
    /// <summary>
    /// Represents the common theme properties group. <br/>
    /// Includes base information such as theme name, font sizes, UI spacing, and basic color palette.
    /// </summary>
    internal class CommonThemeProperty : IThemeProperty
    {
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Interface - IThemeProperty ==========

        /// <inheritdoc />
        public bool Apply(IINIState? iniState)
        {
            if (_themePropertyValues is null)
                return false;
            try
            {
                return _themePropertyValues.AsParallel().All(x => x.Apply(iniState));
            }
            catch (NotSupportedException)
            {
                return _themePropertyValues.All(x => x.Apply(iniState)); // Fallback
            }
        }

        /// <inheritdoc />
        public bool Restore(IINIState? iniState)
        {
            if (_themePropertyValues is null)
                return false;
            try
            {
                return _themePropertyValues.AsParallel().All(x => x.Restore(iniState));
            }
            catch (NotSupportedException)
            {
                return _themePropertyValues.All(x => x.Restore(iniState)); // Fallback
            }
        }

        /// <inheritdoc />
        public void ResetValueToDefault()
        {
            if (_themePropertyValues is null)
                return;
            try
            {
                _themePropertyValues.AsParallel().ForAll(x => x.ResetValueToDefault());
            }
            catch (NotSupportedException)
            {
                _themePropertyValues.ForEach(x => x.ResetValueToDefault()); // Fallback
            }
        }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Identity ==========

        /// <summary>  Gets or sets the name of the theme.</summary>
        internal ThemePropertyValue<string> ThemeName { get; } = new(_sectionName, nameof(ThemeName), "N/A");

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Font Sizes ==========

        /// <summary>Gets or sets the font size for Header1.</summary>
        internal ThemePropertyValue<double> FontSize_Header1 { get; } = new(_sectionName, nameof(FontSize_Header1), 32.0);

        /// <summary>Gets or sets the font size for Header2.</summary>
        internal ThemePropertyValue<double> FontSize_Header2 { get; } = new(_sectionName, nameof(FontSize_Header2), 24.0);

        /// <summary>Gets or sets the font size for Header3.</summary>
        internal ThemePropertyValue<double> FontSize_Header3 { get; } = new(_sectionName, nameof(FontSize_Header3), 18.72);

        /// <summary>Gets or sets the font size for Header4.</summary>
        internal ThemePropertyValue<double> FontSize_Header4 { get; } = new(_sectionName, nameof(FontSize_Header4), 16.0);

        /// <summary>Gets or sets the font size for Header5.</summary>
        internal ThemePropertyValue<double> FontSize_Header5 { get; } = new(_sectionName, nameof(FontSize_Header5), 13.28);

        /// <summary>Gets or sets the font size for Header6.</summary>
        internal ThemePropertyValue<double> FontSize_Header6 { get; } = new(_sectionName, nameof(FontSize_Header6), 10.72);

        /// <summary>Gets or sets the default body font size.</summary>
        internal ThemePropertyValue<double> FontSize_Default { get; } = new(_sectionName, nameof(FontSize_Default), 10.0);

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Thickness ==========

        /// <summary>Gets or sets the default UI element thickness.</summary>
        internal ThemePropertyValue<Thickness> Thickness_Default { get; } = new(_sectionName, nameof(Thickness_Default), new Thickness(1));

        /// <summary>Gets or sets zero-thickness, often used for spacing removal.</summary>
        internal ThemePropertyValue<Thickness> Thickness_Zero { get; } = new(_sectionName, nameof(Thickness_Zero), new Thickness(0));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Color Palette ==========

        /// <summary>Main foreground color.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Foreground { get; } = new(_sectionName, nameof(ColorPalette_Foreground), Color.FromArgb(255, 21, 21, 21));

        /// <summary>Foreground color when disabled.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Foreground_Disable { get; } = new(_sectionName, nameof(ColorPalette_Foreground_Disable), Color.FromArgb(160, 128, 128, 128));

        /// <summary>Main background color.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Background { get; } = new(_sectionName, nameof(ColorPalette_Background), Color.FromArgb(255, 255, 255, 255));

        /// <summary>Outline color used for borders and frames.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Outline { get; } = new(_sectionName, nameof(ColorPalette_Outline), Color.FromArgb(128, 128, 128, 128));

        /// <summary>Line color, typically used for underlines or separators.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Line { get; } = new(_sectionName, nameof(ColorPalette_Line), Color.FromArgb(255, 128, 128, 128));

        /// <summary>Highlight color used for hover or active indication.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Highlight { get; } = new(_sectionName, nameof(ColorPalette_Highlight), Color.FromArgb(180, 21, 21, 21));

        /// <summary>Selection background color.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Selection { get; } = new(_sectionName, nameof(ColorPalette_Selection), Color.FromArgb(255, 128, 128, 128));

        /// <summary>Mask or overlay tint color, often semi-transparent.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Mask { get; } = new(_sectionName, nameof(ColorPalette_Mask), Color.FromArgb(160, 128, 128, 128));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        /// <summary> Section name used for all INI keys in this group. </summary>
        private const string _sectionName = "Common";

        /// <summary> Collection of all overlay theme properties managed by this group. </summary>
        private readonly List<IThemePropertyValue> _themePropertyValues;

        /// <summary> Initializes the <see cref="CommonThemeProperty"/> with all default values. </summary>
        internal CommonThemeProperty()
        {
            //// Name
            //ThemeName = new(_sectionName, nameof(ThemeName), "N/A");

            //// Font Sizes
            //FontSize_Header1 = new(_sectionName, nameof(FontSize_Header1), 32.0);
            //FontSize_Header2 = new(_sectionName, nameof(FontSize_Header2), 24.0);
            //FontSize_Header3 = new(_sectionName, nameof(FontSize_Header3), 18.72);
            //FontSize_Header4 = new(_sectionName, nameof(FontSize_Header4), 16.0);
            //FontSize_Header5 = new(_sectionName, nameof(FontSize_Header5), 13.28);
            //FontSize_Header6 = new(_sectionName, nameof(FontSize_Header6), 10.72);
            //FontSize_Default = new(_sectionName, nameof(FontSize_Default), 10.0);

            //// Thickness
            //Thickness_Default = new(_sectionName, nameof(Thickness_Default), new Thickness(1));
            //Thickness_Zero = new(_sectionName, nameof(Thickness_Zero), new Thickness(0));

            //// Color Palette
            //ColorPalette_Foreground = new(_sectionName, nameof(ColorPalette_Foreground), Color.FromArgb(255, 21, 21, 21));
            //ColorPalette_Foreground_Disable = new(_sectionName, nameof(ColorPalette_Foreground_Disable), Color.FromArgb(160, 128, 128, 128));
            //ColorPalette_Background = new(_sectionName, nameof(ColorPalette_Background), Color.FromArgb(255, 255, 255, 255));
            //ColorPalette_Outline = new(_sectionName, nameof(ColorPalette_Outline), Color.FromArgb(128, 128, 128, 128));
            //ColorPalette_Line = new(_sectionName, nameof(ColorPalette_Line), Color.FromArgb(255, 128, 128, 128));
            //ColorPalette_Highlight = new(_sectionName, nameof(ColorPalette_Highlight), Color.FromArgb(180, 21, 21, 21));
            //ColorPalette_Selection = new(_sectionName, nameof(ColorPalette_Selection), Color.FromArgb(255, 128, 128, 128));
            //ColorPalette_Mask = new(_sectionName, nameof(ColorPalette_Mask), Color.FromArgb(160, 128, 128, 128));

            _themePropertyValues = new()
            {
                ThemeName,
                FontSize_Header1, FontSize_Header2, FontSize_Header3,
                FontSize_Header4, FontSize_Header5, FontSize_Header6,
                FontSize_Default,
                ColorPalette_Foreground, ColorPalette_Foreground_Disable, ColorPalette_Background,
                ColorPalette_Outline, ColorPalette_Line, ColorPalette_Highlight,
                ColorPalette_Selection, ColorPalette_Mask
            };
        }
    }
}