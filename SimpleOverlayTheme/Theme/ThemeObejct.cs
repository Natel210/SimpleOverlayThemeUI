using Microsoft.VisualBasic;
using SimpleFileIO.State.Ini;
using SimpleFileIO.Utility;
using SimpleOverlayTheme.Theme.Interface;
using SimpleOverlayTheme.Theme.ThemeDictionary;
using SimpleOverlayTheme.Theme.ThemeProperty;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SimpleOverlayTheme.Theme
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class ThemeObejct : ITheme
    {
        // ========== Interface - ITheme ==========

        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Identity ==========

        /// <inheritdoc />
        public string ThemeName { get => GetThemeName(); set => SetThemeName(value); }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Font Sizes ==========

        /// <inheritdoc />
        public double FontSize_Header1 { get => GetFontSize_Header1(); set => SetFontSize_Header1(value); }

        /// <inheritdoc />
        public double FontSize_Header2 { get => GetFontSize_Header2(); set => SetFontSize_Header2(value); }

        /// <inheritdoc />
        public double FontSize_Header3 { get => GetFontSize_Header3(); set => SetFontSize_Header3(value); }

        /// <inheritdoc />
        public double FontSize_Header4 { get => GetFontSize_Header4(); set => SetFontSize_Header4(value); }

        /// <inheritdoc />
        public double FontSize_Header5 { get => GetFontSize_Header5(); set => SetFontSize_Header5(value); }

        /// <inheritdoc />
        public double FontSize_Header6 { get => GetFontSize_Header6(); set => SetFontSize_Header6(value); }

        /// <inheritdoc />
        public double FontSize_Default { get => GetFontSize_Default(); set => SetFontSize_Default(value); }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Thickness ==========

        /// <inheritdoc />
        public Thickness Thickness_Default { get => GetThickness_Default(); set => SetThickness_Default(value); }

        /// <inheritdoc />
        public Thickness Thickness_Zero { get => GetThickness_Zero(); set => SetThickness_Zero(value); }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Color Palette ==========

        /// <inheritdoc />
        public Color ColorPalette_Foreground { get => GetColorPalette_Foreground(); set => SetColorPalette_Foreground(value); }

        /// <inheritdoc />
        public Color ColorPalette_Foreground_Disable { get => GetColorPalette_Foreground_Disable(); set => SetColorPalette_Foreground_Disable(value); }

        /// <inheritdoc />
        public Color ColorPalette_Background { get => GetColorPalette_Background(); set => SetColorPalette_Background(value); }

        /// <inheritdoc />
        public Color ColorPalette_Outline { get => GetColorPalette_Outline(); set => SetColorPalette_Outline(value); }

        /// <inheritdoc />
        public Color ColorPalette_Line { get => GetColorPalette_Line(); set => SetColorPalette_Line(value); }

        /// <inheritdoc />
        public Color ColorPalette_Highlight { get => GetColorPalette_Highlight(); set => SetColorPalette_Highlight(value); }

        /// <inheritdoc />
        public Color ColorPalette_Selection { get => GetColorPalette_Selection(); set => SetColorPalette_Selection(value); }

        /// <inheritdoc />
        public Color ColorPalette_Mask { get => GetColorPalette_Mask(); set => SetColorPalette_Mask(value); }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Border Background ==========

        /// <inheritdoc />
        public Color OverlayBorderBackground_Disable { get => GetOverlayBorderBackground_Disable(); set => SetOverlayBorderBackground_Disable(value); }

        /// <inheritdoc />
        public Color OverlayBorderBackground_Default { get => GetOverlayBorderBackground_Default(); set => SetOverlayBorderBackground_Default(value); }

        /// <inheritdoc />
        public Color OverlayBorderBackground_MouseOver { get => GetOverlayBorderBackground_MouseOver(); set => SetOverlayBorderBackground_MouseOver(value); }

        /// <inheritdoc />
        public Color OverlayBorderBackground_Active { get => GetOverlayBorderBackground_Active(); set => SetOverlayBorderBackground_Active(value); }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Border Outline ==========

        /// <inheritdoc />
        public Color OverlayBorderOutline_Disable { get => GetOverlayBorderOutline_Disable(); set => SetOverlayBorderOutline_Disable(value); }

        /// <inheritdoc />
        public Color OverlayBorderOutline_Default { get => GetOverlayBorderOutline_Default(); set => SetOverlayBorderOutline_Default(value); }

        /// <inheritdoc />
        public Color OverlayBorderOutline_MouseOver { get => GetOverlayBorderOutline_MouseOver(); set => SetOverlayBorderOutline_MouseOver(value); }

        /// <inheritdoc />
        public Color OverlayBorderOutline_Active { get => GetOverlayBorderOutline_Active(); set => SetOverlayBorderOutline_Active(value); }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Mask Foreground ==========

        /// <inheritdoc />
        public Color OverlayMaskForeground_Disable { get => GetOverlayMaskForeground_Disable(); set => SetOverlayMaskForeground_Disable(value); }

        /// <inheritdoc />
        public Color OverlayMaskForeground_Default { get => GetOverlayMaskForeground_Default(); set => SetOverlayMaskForeground_Default(value); }

        /// <inheritdoc />
        public Color OverlayMaskForeground_MouseOver { get => GetOverlayMaskForeground_MouseOver(); set => SetOverlayMaskForeground_MouseOver(value); }

        /// <inheritdoc />
        public Color OverlayMaskForeground_Active { get => GetOverlayMaskForeground_Active(); set => SetOverlayMaskForeground_Active(value); }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
    }


    internal partial class ThemeObejct
    {
        internal ThemeObejct(string themeName)
        {
            _common = new();
            _overlay = new();

            _themeProperties = new() {
                { "Common", _common }, { "Overlay", _overlay },
            };

            ThemeName = themeName;

            PathProperty pathProperty = new()
            {
                RootDirectory = new("./Theme/List"),
                FileName = $"{ThemeName}",
                Extension = "ini"
            };

            _iniState = SimpleFileIO.Manager.CreateIniState($"Theme_{ThemeName}", pathProperty) ?? throw new ArgumentNullException($"Not make Theme {ThemeName}."); ;
            RegisterStringTypeParser();
        }

        ~ThemeObejct()
        {
            //SimpleFileIO.Manager.Deleate
        }

        /// <summary> INI-based persistence layer for theme settings (optional, depending on implementation). </summary>
        private readonly IINIState _iniState;
        /// <summary> Dictionary of all theme properties for dynamic access. </summary>
        private readonly Dictionary<string, IThemeProperty> _themeProperties;
        /// <summary> Holds common theme properties (e.g., font sizes, global colors, spacing). </summary>
        private CommonThemeProperty _common;
        /// <summary> Holds overlay-specific properties (e.g., border/mask appearance). </summary>
        private OverlayThemeProperty _overlay;

        /// <summary>
        /// Saves the current theme values to the associated INI file. <br/>
        /// Applies all theme properties before saving.
        /// </summary>
        /// <returns>True if the file was saved successfully; otherwise, false.</returns>
        internal bool SaveToFile()
        {
            if (_iniState is null)
                return false;
            if (Apply() is false)
                return false;
            return _iniState.Save();
        }

        /// <summary>
        /// Loads theme values from the INI file and restores them to the current theme. <br/>
        /// Returns false if loading or restoring fails.
        /// </summary>
        /// <returns>True if loading and restoring were successful; otherwise, false.</returns>
        internal bool LoadFromFile()
        {
            if (_iniState is null)
                return false;
            if (_iniState.Load())
                return false;
            return Restore();
        }

        /// <summary>
        /// Deletes the existing INI file that stores the current theme configuration. <br/>
        /// Throws an exception if the delete operation fails.
        /// </summary>
        /// <returns>True if the file was successfully deleted; otherwise, false.</returns>
        /// <exception cref="IOException">Thrown when the file cannot be deleted.</exception>
        internal bool DeleteFile()
        {
            if (_iniState is null)
                return false;
            var pathProperty = _iniState.PathProperty;
            string fullPath = Path.Combine(pathProperty.RootDirectory.FullName, $"{pathProperty.FileName}.{pathProperty.Extension}");
            if (File.Exists(fullPath))
            {
                try
                {
                    File.Delete(fullPath);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new IOException($"[DeleteFile] File Delete Fail: '{fullPath}'", ex);
                }
            }
            return false;
        }


        /// <summary> Copies all properties from the specified theme instance into this instance. </summary>
        /// <param name="source">The source theme to copy values from.</param>
        internal void CopyFrom(ThemeObejct source)
        {
            _common = source._common.Clone();
            _overlay = source._overlay.Clone();
        }

        /// <summary> Creates a deep copy of the current theme instance. </summary>
        /// <returns>A new <see cref="ThemeObejct"/> instance with identical property values.</returns>
        internal ThemeObejct CreateCopy()
        {
            return new ThemeObejct(ThemeName)
            {
                _common = this._common.Clone(),
                _overlay = this._overlay.Clone(),
            };
        }
    }

    // private methods
    internal partial class ThemeObejct
    {
        /// <summary>
        /// Applies all theme values to the INI state before saving. <br/>
        /// Uses parallel processing where supported.
        /// </summary>
        /// <returns>True if all theme values were applied successfully; otherwise, false.</returns>
        private bool Apply()
        {
            if (_themeProperties is null)
                return false;
            if (_iniState is null)
                return false;
            bool result = true;
            foreach (var item in _themeProperties)
                result &= item.Value.Apply(_iniState);
            return result;
        }

        /// <summary>
        /// Restores all theme values from the INI state into memory. <br/>
        /// Uses parallel processing where supported.
        /// </summary>
        /// <returns>True if all theme values were restored successfully; otherwise, false.</returns>
        private bool Restore()
        {
            if (_themeProperties is null)
                return false;
            if (_iniState is null)
                return false;
            bool result = true;
            foreach (var item in _themeProperties)
                result &= item.Value.Restore(_iniState);
            return result;
        }

        /// <summary>
        /// Generic setter logic for theme values. <br/>
        /// Compares current and new value, applies change, updates dictionary, and raises notification.
        /// </summary>
        private void SetValue<T>(T current, T next, Action setter)
        {
            if (EqualityComparer<T>.Default.Equals(current, next) is false)
                setter();
        }

        /// <summary>
        /// Registers custom string parsers to the <see cref="IINIState"/> for handling complex types such as <see cref="Color"/> and <see cref="Thickness"/>. <br/>
        /// Enables serialization and deserialization of theme properties to/from string format in INI files.
        /// </summary>
        private void RegisterStringTypeParser()
        {
            // Color
            StringTypeParser colorStringTypeParser = new()
            {
                TargetType = typeof(Color),
                ObjectToString = obj => obj is Color color ? $"{color.A},{color.R},{color.G},{color.B}" : "0,0,0,0",
                StringToObject = str =>
                {
                    var strArray = str.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    return strArray.Length switch
                    {
                        3 => Color.FromRgb(byte.Parse(strArray[0]), byte.Parse(strArray[1]), byte.Parse(strArray[2])),
                        4 => Color.FromArgb(byte.Parse(strArray[0]), byte.Parse(strArray[1]), byte.Parse(strArray[2]), byte.Parse(strArray[3])),
                        _ => Colors.Transparent,
                    };
                }
            };

            _iniState.AddParser(typeof(Color), colorStringTypeParser, true);

            // Thickness
            var thicknessStringTypeParser = new StringTypeParser
            {
                TargetType = typeof(Thickness),

                ObjectToString = (obj) =>
                {
                    if (obj is Thickness t)
                    {
                        if (t.Left == t.Top && t.Top == t.Right && t.Right == t.Bottom)
                            return $"{t.Left}";
                        else if (t.Left == t.Right && t.Top == t.Bottom)
                            return $"{t.Left},{t.Top}";
                        else
                            return $"{t.Left},{t.Top},{t.Right},{t.Bottom}";
                    }
                    return "0";
                },

                StringToObject = (str) =>
                {
                    var parts = str.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 1 && double.TryParse(parts[0], out double all))
                    {
                        return new Thickness(all);
                    }
                    else if (parts.Length == 2 &&
                             double.TryParse(parts[0], out double h) &&
                             double.TryParse(parts[1], out double v))
                    {
                        return new Thickness(h, v, h, v);
                    }
                    else if (parts.Length == 4 &&
                             double.TryParse(parts[0], out double l) &&
                             double.TryParse(parts[1], out double t) &&
                             double.TryParse(parts[2], out double r) &&
                             double.TryParse(parts[3], out double b))
                    {
                        return new Thickness(l, t, r, b);
                    }

                    return new Thickness(0);
                }
            };

            _iniState.AddParser(typeof(Thickness), thicknessStringTypeParser, true);
        }

    }

    // private properetes setting
    internal partial class ThemeObejct
    {
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Identity Private Get Set ==========

        /// <summary> Gets the name of the currently applied theme. </summary>
        private string GetThemeName() => _common.ThemeName.Value;
        /// <summary> Sets the name of the theme and updates the corresponding resource if the value changes. </summary>
        private void SetThemeName(string value)
        {
            if (string.IsNullOrEmpty(value))
                return;
            SetValue(value, _common.ThemeName.Value, () => _common.ThemeName.Value = value);
        }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Font Sizes Private Get Set ==========

        /// <summary> Gets the font size for <see cref="FontSize_Header1"/> elements. </summary>
        private double GetFontSize_Header1() => _common.FontSize_Header1.Value;
        /// <summary> Sets the font size for <see cref="FontSize_Header1"/> elements and applies changes to the resource dictionary. </summary>
        private void SetFontSize_Header1(double value) => SetValue(value,
            _common.FontSize_Header1.Value, () => _common.FontSize_Header1.Value = value);

        /// <summary> Gets the font size for <see cref="FontSize_Header2"/> elements. </summary>
        private double GetFontSize_Header2() => _common.FontSize_Header2.Value;
        /// <summary> Sets the font size for <see cref="FontSize_Header2"/> elements and applies changes to the resource dictionary. </summary>
        private void SetFontSize_Header2(double value) => SetValue(value,
            _common.FontSize_Header2.Value, () => _common.FontSize_Header2.Value = value);

        /// <summary> Gets the font size for <see cref="FontSize_Header3"/> elements. </summary>
        private double GetFontSize_Header3() => _common.FontSize_Header3.Value;
        /// <summary> Sets the font size for <see cref="FontSize_Header3"/> elements and applies changes to the resource dictionary. </summary>
        private void SetFontSize_Header3(double value) => SetValue(value,
            _common.FontSize_Header3.Value, () => _common.FontSize_Header3.Value = value);

        /// <summary> Gets the font size for <see cref="FontSize_Header4"/> elements. </summary>
        private double GetFontSize_Header4() => _common.FontSize_Header4.Value;
        /// <summary> Sets the font size for <see cref="FontSize_Header4"/> elements and applies changes to the resource dictionary. </summary>
        private void SetFontSize_Header4(double value) => SetValue(value,
            _common.FontSize_Header4.Value, () => _common.FontSize_Header4.Value = value);

        /// <summary> Gets the font size for <see cref="FontSize_Header5"/> elements. </summary>
        private double GetFontSize_Header5() => _common.FontSize_Header5.Value;
        /// <summary> Sets the font size for <see cref="FontSize_Header5"/> elements and applies changes to the resource dictionary. </summary>
        private void SetFontSize_Header5(double value) => SetValue(value,
            _common.FontSize_Header5.Value, () => _common.FontSize_Header5.Value = value);

        /// <summary> Gets the font size for <see cref="FontSize_Header6"/> elements. </summary>
        private double GetFontSize_Header6() => _common.FontSize_Header6.Value;
        /// <summary> Sets the font size for <see cref="FontSize_Header6"/> elements and applies changes to the resource dictionary. </summary>
        private void SetFontSize_Header6(double value) => SetValue(value,
            _common.FontSize_Header6.Value, () => _common.FontSize_Header6.Value = value);

        /// <summary> Gets the font size for <see cref="FontSize_Default"/> elements. </summary>
        private double GetFontSize_Default() => _common.FontSize_Default.Value;
        /// <summary> Sets the font size for <see cref="FontSize_Default"/> elements and applies changes to the resource dictionary. </summary>
        private void SetFontSize_Default(double value) => SetValue(value,
            _common.FontSize_Default.Value, () => _common.FontSize_Default.Value = value);

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Thickness Private Get Set ==========

        /// <summary> Gets the default thickness value used in UI components. </summary>
        private Thickness GetThickness_Default() => _common.Thickness_Default.Value;
        /// <summary> Sets the default thickness value and updates the resource dictionary. </summary>
        private void SetThickness_Default(Thickness value) => SetValue(value,
            _common.Thickness_Default.Value, () => _common.Thickness_Default.Value = value);

        /// <summary> Gets the zero-thickness value, typically used for borderless or padding-less elements. </summary>
        private Thickness GetThickness_Zero() => _common.Thickness_Zero.Value;
        /// <summary> Sets the zero-thickness value and updates the resource dictionary. </summary>
        private void SetThickness_Zero(Thickness value) => SetValue(value,
            _common.Thickness_Zero.Value, () => _common.Thickness_Zero.Value = value);

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Color Palette Private Get Set ==========

        /// <summary> Gets the primary foreground color used in the theme. </summary>
        private Color GetColorPalette_Foreground() => _common.ColorPalette_Foreground.Value;
        /// <summary> Sets the primary foreground color and updates related resources. </summary>
        private void SetColorPalette_Foreground(Color value) => SetValue(value,
            _common.ColorPalette_Foreground.Value, () => _common.ColorPalette_Foreground.Value = value);

        /// <summary> Gets the foreground color for disabled UI states. </summary>
        private Color GetColorPalette_Foreground_Disable() => _common.ColorPalette_Foreground_Disable.Value;
        /// <summary> Sets the disabled foreground color and applies it to the resources. </summary>
        private void SetColorPalette_Foreground_Disable(Color value) => SetValue(value,
            _common.ColorPalette_Foreground_Disable.Value, () => _common.ColorPalette_Foreground_Disable.Value = value);

        /// <summary> Gets the background color for content areas. </summary>
        private Color GetColorPalette_Background() => _common.ColorPalette_Background.Value;
        /// <summary> Sets the background color and updates the resource dictionary. </summary>
        private void SetColorPalette_Background(Color value) => SetValue(value,
            _common.ColorPalette_Background.Value, () => _common.ColorPalette_Background.Value = value);

        /// <summary> Gets the outline color used around themed UI components. </summary>
        private Color GetColorPalette_Outline() => _common.ColorPalette_Outline.Value;
        /// <summary> Sets the outline color and updates the resource dictionary accordingly. </summary>
        private void SetColorPalette_Outline(Color value) => SetValue(value,
            _common.ColorPalette_Outline.Value, () => _common.ColorPalette_Outline.Value = value);

        /// <summary> Gets the line color typically used for separators or borders. </summary>
        private Color GetColorPalette_Line() => _common.ColorPalette_Line.Value;
        /// <summary> Sets the line color and reflects the change in the resource dictionary. </summary>
        private void SetColorPalette_Line(Color value) => SetValue(value,
            _common.ColorPalette_Line.Value, () => _common.ColorPalette_Line.Value = value);

        /// <summary> Gets the highlight color used to indicate focus or emphasis. </summary>
        private Color GetColorPalette_Highlight() => _common.ColorPalette_Highlight.Value;
        /// <summary> Sets the highlight color and updates resource values. </summary>
        private void SetColorPalette_Highlight(Color value) => SetValue(value,
            _common.ColorPalette_Highlight.Value, () => _common.ColorPalette_Highlight.Value = value);

        /// <summary> Gets the selection color used for selected items or highlights. </summary>
        private Color GetColorPalette_Selection() => _common.ColorPalette_Selection.Value;
        /// <summary> Sets the selection color and updates related resources. </summary>
        private void SetColorPalette_Selection(Color value) => SetValue(value,
            _common.ColorPalette_Selection.Value, () => _common.ColorPalette_Selection.Value = value);

        /// <summary> Gets the mask color overlay applied to obscured content. </summary>
        private Color GetColorPalette_Mask() => _common.ColorPalette_Mask.Value;
        /// <summary> Sets the mask color overlay and updates the resource dictionary. </summary>
        private void SetColorPalette_Mask(Color value) => SetValue(value,
            _common.ColorPalette_Mask.Value, () => _common.ColorPalette_Mask.Value = value);

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Border Background Private Get Set ==========

        /// <summary> Gets the background color of overlay borders in the [Disabled] state. </summary>
        private Color GetOverlayBorderBackground_Disable() => _overlay.BorderBackground_Disable.Value;
        /// <summary> Sets the background color of overlay borders in the [Disabled] state. </summary>
        private void SetOverlayBorderBackground_Disable(Color value) => SetValue(value,
            _overlay.BorderBackground_Disable.Value, () => _overlay.BorderBackground_Disable.Value = value);

        /// <summary> Gets the background color of overlay borders in the [Default] state. </summary>
        private Color GetOverlayBorderBackground_Default() => _overlay.BorderBackground_Default.Value;
        /// <summary> Sets the background color of overlay borders in the [Default] state. </summary>
        private void SetOverlayBorderBackground_Default(Color value) => SetValue(value,
            _overlay.BorderBackground_Default.Value, () => _overlay.BorderBackground_Default.Value = value);

        /// <summary> Gets the background color of overlay borders in the [Mouse-Over] state. </summary>
        private Color GetOverlayBorderBackground_MouseOver() => _overlay.BorderBackground_MouseOver.Value;
        /// <summary> Sets the background color of overlay borders in the [Mouse-Over] state. </summary>
        private void SetOverlayBorderBackground_MouseOver(Color value) => SetValue(value,
            _overlay.BorderBackground_MouseOver.Value, () => _overlay.BorderBackground_MouseOver.Value = value);

        /// <summary> Gets the background color of overlay borders in the [Active] state. </summary>
        private Color GetOverlayBorderBackground_Active() => _overlay.BorderBackground_Active.Value;
        /// <summary> Sets the background color of overlay borders in the [Active] state. </summary>
        private void SetOverlayBorderBackground_Active(Color value) => SetValue(value,
            _overlay.BorderBackground_Active.Value, () => _overlay.BorderBackground_Active.Value = value);

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Border Outline Private Get Set ==========

        /// <summary> Gets the outline color of overlay components in the [Disabled] state. </summary>
        private Color GetOverlayBorderOutline_Disable() => _overlay.BorderOutline_Disable.Value;
        /// <summary> Sets the outline color of overlay components in the [Disabled] state. </summary>
        private void SetOverlayBorderOutline_Disable(Color value) => SetValue(value,
            _overlay.BorderOutline_Disable.Value, () => _overlay.BorderOutline_Disable.Value = value);

        /// <summary> Gets the outline color of overlay components in the [Default] state. </summary>
        private Color GetOverlayBorderOutline_Default() => _overlay.BorderOutline_Default.Value;
        /// <summary> Sets the outline color of overlay components in the [Default] state. </summary>
        private void SetOverlayBorderOutline_Default(Color value) => SetValue(value,
            _overlay.BorderOutline_Default.Value, () => _overlay.BorderOutline_Default.Value = value);

        /// <summary> Gets the outline color of overlay components in the [Mouse-Over] state. </summary>
        private Color GetOverlayBorderOutline_MouseOver() => _overlay.BorderOutline_MouseOver.Value;
        /// <summary> Sets the outline color of overlay components in the [Mouse-Over] state. </summary>
        private void SetOverlayBorderOutline_MouseOver(Color value) => SetValue(value,
            _overlay.BorderOutline_MouseOver.Value, () => _overlay.BorderOutline_MouseOver.Value = value);

        /// <summary> Gets the outline color of overlay components in the [Active] state. </summary>
        private Color GetOverlayBorderOutline_Active() => _overlay.BorderOutline_Active.Value;
        /// <summary> Sets the outline color of overlay components in the [Active] state. </summary>
        private void SetOverlayBorderOutline_Active(Color value) => SetValue(value,
            _overlay.BorderOutline_Active.Value, () => _overlay.BorderOutline_Active.Value = value);

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Mask Foreground Private Get Set ==========

        /// <summary> Gets the foreground mask color of overlay content on [Disabled]. </summary>
        private Color GetOverlayMaskForeground_Disable() => _overlay.MaskForeground_Disable.Value;
        /// <summary> Sets the [Disabled] foreground mask color for overlays. </summary>
        private void SetOverlayMaskForeground_Disable(Color value) => SetValue(value,
            _overlay.MaskForeground_Disable.Value, () => _overlay.MaskForeground_Disable.Value = value);

        /// <summary> Gets the foreground mask color of overlay content on [Default]. </summary>
        private Color GetOverlayMaskForeground_Default() => _overlay.MaskForeground_Default.Value;
        /// <summary> Sets the [Default] foreground mask color for overlays. </summary>
        private void SetOverlayMaskForeground_Default(Color value) => SetValue(value,
            _overlay.MaskForeground_Default.Value, () => _overlay.MaskForeground_Default.Value = value);

        /// <summary> Gets the foreground mask color of overlay content on [Mouse-Over]. </summary>
        private Color GetOverlayMaskForeground_MouseOver() => _overlay.MaskForeground_MouseOver.Value;
        /// <summary> Sets the [Mouse-Over] foreground mask color for overlays. </summary>
        private void SetOverlayMaskForeground_MouseOver(Color value) => SetValue(value,
            _overlay.MaskForeground_MouseOver.Value, () => _overlay.MaskForeground_MouseOver.Value = value);

        /// <summary> Gets the foreground mask color of overlay content on [Active]. </summary>
        private Color GetOverlayMaskForeground_Active() => _overlay.MaskForeground_Active.Value;
        /// <summary> Sets the [Active] foreground mask color for overlays. </summary>
        private void SetOverlayMaskForeground_Active(Color value) => SetValue(value,
            _overlay.MaskForeground_Active.Value, () => _overlay.MaskForeground_Active.Value = value);

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
    }

}
