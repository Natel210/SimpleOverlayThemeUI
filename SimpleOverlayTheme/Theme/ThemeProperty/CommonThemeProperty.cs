using Microsoft.VisualBasic;
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

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Identity ==========

        /// <summary>  Gets or sets the name of the theme.</summary>
        internal ThemePropertyValue<string> ThemeName { get; private set; } = new(_sectionName, nameof(ThemeName), "Temp");

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Font Sizes ==========

        /// <summary>Gets or sets the font size for Header1.</summary>
        internal ThemePropertyValue<double> FontSize_Header1 { get; private set; } = new(_sectionName, nameof(FontSize_Header1), 32.0);

        /// <summary>Gets or sets the font size for Header2.</summary>
        internal ThemePropertyValue<double> FontSize_Header2 { get; private set; } = new(_sectionName, nameof(FontSize_Header2), 24.0);

        /// <summary>Gets or sets the font size for Header3.</summary>
        internal ThemePropertyValue<double> FontSize_Header3 { get; private set; } = new(_sectionName, nameof(FontSize_Header3), 18.72);

        /// <summary>Gets or sets the font size for Header4.</summary>
        internal ThemePropertyValue<double> FontSize_Header4 { get; private set; } = new(_sectionName, nameof(FontSize_Header4), 16.0);

        /// <summary>Gets or sets the font size for Header5.</summary>
        internal ThemePropertyValue<double> FontSize_Header5 { get; private set; } = new(_sectionName, nameof(FontSize_Header5), 13.28);

        /// <summary>Gets or sets the font size for Header6.</summary>
        internal ThemePropertyValue<double> FontSize_Header6 { get; private set; } = new(_sectionName, nameof(FontSize_Header6), 10.72);

        /// <summary>Gets or sets the default body font size.</summary>
        internal ThemePropertyValue<double> FontSize_Default { get; private set; } = new(_sectionName, nameof(FontSize_Default), 10.0);

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Thickness ==========

        /// <summary>Gets or sets the default UI element thickness.</summary>
        internal ThemePropertyValue<Thickness> Thickness_Default { get; private set; } = new(_sectionName, nameof(Thickness_Default), new Thickness(1));

        /// <summary>Gets or sets zero-thickness, often used for spacing removal.</summary>
        internal ThemePropertyValue<Thickness> Thickness_Zero { get; private set; } = new(_sectionName, nameof(Thickness_Zero), new Thickness(0));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Color Palette ==========

        /// <summary>Main foreground color.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Foreground { get; private set; } = new(_sectionName, nameof(ColorPalette_Foreground), Color.FromArgb(255, 21, 21, 21));

        /// <summary>Foreground color when disabled.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Foreground_Disable { get; private set; } = new(_sectionName, nameof(ColorPalette_Foreground_Disable), Color.FromArgb(160, 128, 128, 128));

        /// <summary>Main background color.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Background { get; private set; } = new(_sectionName, nameof(ColorPalette_Background), Color.FromArgb(255, 255, 255, 255));

        /// <summary>Outline color used for borders and frames.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Outline { get; private set; } = new(_sectionName, nameof(ColorPalette_Outline), Color.FromArgb(128, 128, 128, 128));

        /// <summary>Line color, typically used for underlines or separators.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Line { get; private set; } = new(_sectionName, nameof(ColorPalette_Line), Color.FromArgb(255, 128, 128, 128));

        /// <summary>Highlight color used for hover or active indication.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Highlight { get; private set; } = new(_sectionName, nameof(ColorPalette_Highlight), Color.FromArgb(180, 21, 21, 21));

        /// <summary>Selection background color.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Selection { get; private set; } = new(_sectionName, nameof(ColorPalette_Selection), Color.FromArgb(255, 128, 128, 128));

        /// <summary>Mask or overlay tint color, often semi-transparent.</summary>
        internal ThemePropertyValue<Color> ColorPalette_Mask { get; private set; } = new(_sectionName, nameof(ColorPalette_Mask), Color.FromArgb(160, 128, 128, 128));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        /// <summary> Section name used for all INI keys in this group. </summary>
        private const string _sectionName = "Common";

        /// <summary> Collection of all overlay theme properties managed by this group. </summary>
        private readonly List<IThemePropertyValue> _themePropertyValues;

        internal CommonThemeProperty Clone()
        {
            return new CommonThemeProperty()
            {
                ThemeName = this.ThemeName.Clone(),
                FontSize_Header1 = this.FontSize_Header1.Clone(),
                FontSize_Header2 = this.FontSize_Header2.Clone(),
                FontSize_Header3 = this.FontSize_Header3.Clone(),
                FontSize_Header4 = this.FontSize_Header4.Clone(),
                FontSize_Header5 = this.FontSize_Header5.Clone(),
                FontSize_Header6 = this.FontSize_Header6.Clone(),
                FontSize_Default = this.FontSize_Default.Clone(),
                Thickness_Default = this.Thickness_Default.Clone(),
                Thickness_Zero = this.Thickness_Zero.Clone(),
                ColorPalette_Foreground = this.ColorPalette_Foreground.Clone(),
                ColorPalette_Foreground_Disable = this.ColorPalette_Foreground_Disable.Clone(),
                ColorPalette_Background = this.ColorPalette_Background.Clone(),
                ColorPalette_Outline = this.ColorPalette_Outline.Clone(),
                ColorPalette_Line = this.ColorPalette_Line.Clone(),
                ColorPalette_Highlight = this.ColorPalette_Highlight.Clone(),
                ColorPalette_Selection = this.ColorPalette_Selection.Clone(),
                ColorPalette_Mask = this.ColorPalette_Mask.Clone()
            };
        }

        /// <summary> Initializes the <see cref="CommonThemeProperty"/> with all default values. </summary>
        internal CommonThemeProperty()
        {
            _themePropertyValues = new()
            {
                ThemeName,
                FontSize_Header1, FontSize_Header2, FontSize_Header3,
                FontSize_Header4, FontSize_Header5, FontSize_Header6,
                FontSize_Default,
                Thickness_Default, Thickness_Zero,
                ColorPalette_Foreground, ColorPalette_Foreground_Disable, ColorPalette_Background,
                ColorPalette_Outline, ColorPalette_Line, ColorPalette_Highlight,
                ColorPalette_Selection, ColorPalette_Mask
            };
        }
    }
}