using System.ComponentModel;
using System.Runtime.CompilerServices;
using SimpleOverlayTheme.Theme.ThemeDictionary;
using System.Windows.Media;
using System.Windows;
using SimpleOverlayTheme.Theme.Interface;
using SimpleFileIO.State.Ini;
using SimpleOverlayTheme.Theme.ThemeProperty;
using SimpleFileIO.Utility;
using static System.Net.Mime.MediaTypeNames;

namespace SimpleOverlayTheme.Theme
{
    /// <summary>
    /// Represents the current theme as a singleton ViewModel. <br/>
    /// This class manages theme-related values (fonts, colors, thicknesses, etc.) <br/>
    /// and ensures dynamic update of WPF resources when values are changed.
    /// </summary>
    /// <remarks>
    /// - Implements <see cref="ITheme"/> interface to expose theming properties. <br/>
    /// - Implements <see cref="INotifyPropertyChanged"/> to notify UI bindings when properties change. <br/>
    /// - Uses <see cref="ResourceDictionary"/> to apply changes in real-time.
    /// </remarks>
    internal partial class Current : ICurrent
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

    // ========== Interface - INotifyPropertyChanged ==========
    internal partial class Current
    {
        /// <inheritdoc />
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary> Raises the PropertyChanged event to notify UI that a bound property has changed. </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // ========== Interface - ICurrent ==========
    internal partial class Current
    {
        /// <inheritdoc />
        public bool AutoSave { get; set; } = true;
        /// <inheritdoc />
        public bool Save() => SaveToFile();
        /// <inheritdoc />
        public bool Load() => LoadFromFile();
        /// <inheritdoc />
        public bool RestoreAndSyncUI() => Restore_Private();
        /// <inheritdoc />
        public void ResetValueToDefault() => ResetValueToDefault_Private();
    }

    internal partial class Current
    {
        /// <summary> Singleton instance of the current theme. </summary>
        /// <remarks> Prevents multiple instantiations and ensures one global source of theme state. </remarks>
        internal static Current Instance { get; } = new Current();

        /// <summary> Private constructor to enforce singleton pattern. </summary>
        private Current()
        {
            _common = new();
            _overlay = new();

            _themeProperties = new() {
                { "Common", _common }, { "Overlay", _overlay },
            };

            PathProperty pathProperty = new()
            {
                RootDirectory = new("./Theme"),
                FileName = "Current",
                Extension = "ini"
            };

            _iniState = SimpleFileIO.Manager.CreateIniState("Theme_Current", pathProperty) ?? throw new ArgumentNullException($"Not make Theme Current.");
            RegisterStringTypeParser();

        }

        /// <summary> INI-based persistence layer for theme settings (optional, depending on implementation). </summary>
        private readonly IINIState _iniState;
        /// <summary> Dictionary of all theme properties for dynamic access. </summary>
        private readonly Dictionary<string, IThemeProperty> _themeProperties;
        /// <summary> Holds common theme properties (e.g., font sizes, global colors, spacing). </summary>
        private CommonThemeProperty _common;
        /// <summary> Holds overlay-specific properties (e.g., border/mask appearance). </summary>
        private OverlayThemeProperty _overlay;

        internal void CopyFrom(ThemeObejct source)
        {
            UpdateThemeProperty_All(source);
            if (AutoSave)
            {
                Apply();
                SaveToFile();
            }
        }

        /// <summary> Creates a deep copy of the current theme instance. </summary>
        /// <returns>A new <see cref="ThemeObejct"/> instance with identical property values.</returns>
        internal ThemeObejct CreateCopy()
        {
            var copy = new ThemeObejct(ThemeName);

            copy.FontSize_Header1 = FontSize_Header1;
            copy.FontSize_Header2 = FontSize_Header2;
            copy.FontSize_Header3 = FontSize_Header3;
            copy.FontSize_Header4 = FontSize_Header4;
            copy.FontSize_Header5 = FontSize_Header5;
            copy.FontSize_Header6 = FontSize_Header6;
            copy.FontSize_Default = FontSize_Default;

            copy.Thickness_Default = Thickness_Default;
            copy.Thickness_Zero = Thickness_Zero;

            copy.ColorPalette_Foreground = ColorPalette_Foreground;
            copy.ColorPalette_Foreground_Disable = ColorPalette_Foreground_Disable;
            copy.ColorPalette_Background = ColorPalette_Background;
            copy.ColorPalette_Outline = ColorPalette_Outline;
            copy.ColorPalette_Line = ColorPalette_Line;
            copy.ColorPalette_Highlight = ColorPalette_Highlight;
            copy.ColorPalette_Selection = ColorPalette_Selection;
            copy.ColorPalette_Mask = ColorPalette_Mask;

            copy.OverlayBorderBackground_Disable = OverlayBorderBackground_Disable;
            copy.OverlayBorderBackground_Default = OverlayBorderBackground_Default;
            copy.OverlayBorderBackground_MouseOver = OverlayBorderBackground_MouseOver;
            copy.OverlayBorderBackground_Active = OverlayBorderBackground_Active;

            copy.OverlayBorderOutline_Disable = OverlayBorderOutline_Disable;
            copy.OverlayBorderOutline_Default = OverlayBorderOutline_Default;
            copy.OverlayBorderOutline_MouseOver = OverlayBorderOutline_MouseOver;
            copy.OverlayBorderOutline_Active = OverlayBorderOutline_Active;

            copy.OverlayMaskForeground_Disable = OverlayMaskForeground_Disable;
            copy.OverlayMaskForeground_Default = OverlayMaskForeground_Default;
            copy.OverlayMaskForeground_MouseOver = OverlayMaskForeground_MouseOver;
            copy.OverlayMaskForeground_Active = OverlayMaskForeground_Active;

            return copy;
        }

        internal void Initialize()
        {
            if (_iniState is null)
                throw new Exception();
            if (_iniState.Load() is false)
                throw new Exception();
            if (_themeProperties is null)
                throw new Exception();
            foreach (var item in _themeProperties)
                item.Value.Restore(_iniState);

            var makeBrush = (Color color) =>
            {
                var brush = new SolidColorBrush(color);
                brush.Freeze();
                return brush;
            };

            bool isLoad = Load();
            if (isLoad is true)
                return;
            var changedProperties = new List<string>() {
                nameof(ThemeName),
                nameof(FontSize_Header1), nameof(FontSize_Header2), nameof(FontSize_Header3),
                nameof(FontSize_Header4), nameof(FontSize_Header5), nameof(FontSize_Header6),
                nameof(FontSize_Default), nameof(Thickness_Default), nameof(Thickness_Zero),
                nameof(ColorPalette_Foreground), nameof(ColorPalette_Foreground_Disable),
                nameof(ColorPalette_Background), nameof(ColorPalette_Outline), nameof(ColorPalette_Line),
                nameof(ColorPalette_Highlight), nameof(ColorPalette_Selection), nameof(ColorPalette_Mask),
                nameof(OverlayBorderBackground_Disable), nameof(OverlayBorderBackground_Default),
                nameof(OverlayBorderBackground_MouseOver), nameof(OverlayBorderBackground_Active),
                nameof(OverlayBorderOutline_Disable),
            };
            var changedDictionary = new Dictionary<string, object>() {
                { ThemeDictionaryKey.ThemeName, ThemeName },
                { ThemeDictionaryKey.FontSize_Header1, FontSize_Header1 }, { ThemeDictionaryKey.FontSize_Header2, FontSize_Header2 },
                { ThemeDictionaryKey.FontSize_Header3, FontSize_Header3 }, { ThemeDictionaryKey.FontSize_Header4, FontSize_Header4 },
                { ThemeDictionaryKey.FontSize_Header5, FontSize_Header5 }, { ThemeDictionaryKey.FontSize_Header6, FontSize_Header6 },
                { ThemeDictionaryKey.FontSize_Default, FontSize_Default },
                { ThemeDictionaryKey.Thickness_Default, Thickness_Default }, { ThemeDictionaryKey.Thickness_Zero, Thickness_Zero },
                { ThemeDictionaryKey.ColorPalette_Foreground, makeBrush(ColorPalette_Foreground) },
                { ThemeDictionaryKey.ColorPalette_Foreground_Disable, makeBrush(ColorPalette_Foreground_Disable) },
                { ThemeDictionaryKey.ColorPalette_Background, makeBrush(ColorPalette_Background) },
                { ThemeDictionaryKey.ColorPalette_Outline, makeBrush(ColorPalette_Outline) },
                { ThemeDictionaryKey.ColorPalette_Line, makeBrush(ColorPalette_Line) },
                { ThemeDictionaryKey.ColorPalette_Highlight, makeBrush(ColorPalette_Highlight) },
                { ThemeDictionaryKey.ColorPalette_Selection, makeBrush(ColorPalette_Selection) },
                { ThemeDictionaryKey.ColorPalette_Mask, makeBrush(ColorPalette_Mask) },
                { ThemeDictionaryKey.OverlayBorderBackground_Disable, makeBrush(OverlayBorderBackground_Disable) },
                { ThemeDictionaryKey.OverlayBorderBackground_Default, makeBrush(OverlayBorderBackground_Default) },
                { ThemeDictionaryKey.OverlayBorderBackground_MouseOver, makeBrush(OverlayBorderBackground_MouseOver) },
                { ThemeDictionaryKey.OverlayBorderBackground_Active, makeBrush(OverlayBorderBackground_Active) },
                { ThemeDictionaryKey.OverlayBorderOutline_Disable, makeBrush(OverlayBorderOutline_Disable) },
                { ThemeDictionaryKey.OverlayBorderOutline_Default, makeBrush(OverlayBorderOutline_Default) },
                { ThemeDictionaryKey.OverlayBorderOutline_MouseOver, makeBrush(OverlayBorderOutline_MouseOver) },
                { ThemeDictionaryKey.OverlayBorderOutline_Active, makeBrush(OverlayBorderOutline_Active) },

                { ThemeDictionaryKey.OverlayMaskForeground_Disable, makeBrush(OverlayMaskForeground_Disable) },
                { ThemeDictionaryKey.OverlayMaskForeground_Default, makeBrush(OverlayMaskForeground_Default) },
                { ThemeDictionaryKey.OverlayMaskForeground_MouseOver, makeBrush(OverlayMaskForeground_MouseOver) },
                { ThemeDictionaryKey.OverlayMaskForeground_Active, makeBrush(OverlayMaskForeground_Active) },
            };

            var dicts = GetAllDictionaries().ToList();
            foreach (var pair in changedDictionary)
            {
                bool updated = false;

                foreach (var dict in dicts)
                {
                    if (dict.Contains(pair.Key))
                    {
                        dict[pair.Key] = pair.Value;
                        updated = true;
                    }
                }

                if (!updated)
                {
                    System.Windows.Application.Current.Resources[pair.Key] = pair.Value;
                }
            }

            // Notify Property Changed
            foreach (var item in changedProperties)
                OnPropertyChanged(item);
        }
    }

    // private methods
    internal partial class Current
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
        /// Generic setter logic for theme values. <br/>
        /// Compares current and new value, applies change, updates dictionary, and raises notification.
        /// </summary>
        private void SetValue<T>(T current, T next, string key, Action setter, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(current, next) is false)
            {
                setter();
                UpdateResource(key, next);
                OnPropertyChanged(propertyName);
                if (AutoSave)
                {
                    Apply();
                    SaveToFile();
                }
            }
        }

        /// <summary> Specialized setter for color values that creates a frozen SolidColorBrush for performance. </summary>
        private void SetBrush(Color current, Color next, string key, Action setter, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<Color>.Default.Equals(current, next) is false)
            {
                setter();
                var brush = new SolidColorBrush(next);
                brush.Freeze();
                UpdateResource(key, brush);
                OnPropertyChanged(propertyName);
                if (AutoSave)
                {
                    Apply();
                    SaveToFile();
                }
            }
        }

        /// <summary> Updates a WPF resource identified by key with a new value. </summary>
        private void UpdateResource<T>(string key, T value)
        {
            foreach (var dict in GetAllDictionaries())
            {
                if (dict.Contains(key))
                {
                    dict[key] = value;
                    return;
                }
            }
            System.Windows.Application.Current.Resources[key] = value;
        }

        /// <summary>
        /// Compares all theming properties with those from a specified source theme,
        /// and updates this instance only where values differ. <br/>
        /// This method performs a bulk update operation that:
        /// <list type="bullet">
        /// <item><description>Copies property values from <paramref name="source"/> into the current instance if they differ.</description></item>
        /// <item><description>Accumulates resource keys to be updated in a single WPF resource dictionary batch operation.</description></item>
        /// <item><description>Notifies property changes via <see cref="INotifyPropertyChanged"/> only once per property.</description></item>
        /// </list>
        /// </summary>
        /// <param name="source">The source <see cref="ThemeObejct"/> to compare and copy values from.</param>
        /// <returns>
        /// Returns <c>true</c> if at least one property was updated (resource or property change triggered); otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method is designed to optimize performance by minimizing the number of UI invalidation and WPF resource update calls.
        /// Instead of calling <see cref="OnPropertyChanged"/> and updating resource dictionaries for every property individually,
        /// it collects all changes and applies them in bulk.
        /// </remarks>
        private bool UpdateThemeProperty_All(ThemeObejct source)
        {
            var makeBrush = (Color color) =>
            {
                var brush = new SolidColorBrush(color);
                brush.Freeze();
                return brush;
            };
            var changedProperties = new List<string>();
            var changedDictionary = new Dictionary<string, object>();
            if (EqualityComparer<string>.Default.Equals(_common.ThemeName.Value, source.ThemeName))
            {
                _common.ThemeName.Value = source.ThemeName;
                changedProperties.Add(nameof(ThemeName));
                changedDictionary.Add(ThemeDictionaryKey.ThemeName, ThemeName);
            }
            if (EqualityComparer<double>.Default.Equals(_common.FontSize_Header1.Value, source.FontSize_Header1))
            {
                _common.FontSize_Header1.Value = source.FontSize_Header1;
                changedProperties.Add(nameof(FontSize_Header1));
                changedDictionary.Add(ThemeDictionaryKey.FontSize_Header1, FontSize_Header1);
            }
            if (EqualityComparer<double>.Default.Equals(_common.FontSize_Header2.Value, source.FontSize_Header2))
            {
                _common.FontSize_Header2.Value = source.FontSize_Header2;
                changedProperties.Add(nameof(FontSize_Header2));
                changedDictionary.Add(ThemeDictionaryKey.FontSize_Header2, FontSize_Header2);
            }
            if (EqualityComparer<double>.Default.Equals(_common.FontSize_Header3.Value, source.FontSize_Header3))
            {
                _common.FontSize_Header3.Value = source.FontSize_Header3;
                changedProperties.Add(nameof(FontSize_Header3));
                changedDictionary.Add(ThemeDictionaryKey.FontSize_Header3, FontSize_Header3);
            }
            if (EqualityComparer<double>.Default.Equals(_common.FontSize_Header4.Value, source.FontSize_Header4))
            {
                _common.FontSize_Header4.Value = source.FontSize_Header4;
                changedProperties.Add(nameof(FontSize_Header4));
                changedDictionary.Add(ThemeDictionaryKey.FontSize_Header4, FontSize_Header4);
            }
            if (EqualityComparer<double>.Default.Equals(_common.FontSize_Header5.Value, source.FontSize_Header5))
            {
                _common.FontSize_Header5.Value = source.FontSize_Header5;
                changedProperties.Add(nameof(FontSize_Header5));
                changedDictionary.Add(ThemeDictionaryKey.FontSize_Header5, FontSize_Header5);
            }
            if (EqualityComparer<double>.Default.Equals(_common.FontSize_Header6.Value, source.FontSize_Header6))
            {
                _common.FontSize_Header6.Value = source.FontSize_Header6;
                changedProperties.Add(nameof(FontSize_Header6));
                changedDictionary.Add(ThemeDictionaryKey.FontSize_Header6, FontSize_Header6);
            }
            if (EqualityComparer<double>.Default.Equals(_common.FontSize_Default.Value, source.FontSize_Default))
            {
                _common.FontSize_Default.Value = source.FontSize_Default;
                changedProperties.Add(nameof(FontSize_Default));
                changedDictionary.Add(ThemeDictionaryKey.FontSize_Default, FontSize_Default);
            }

            if (EqualityComparer<Thickness>.Default.Equals(_common.Thickness_Default.Value, source.Thickness_Default))
            {
                _common.Thickness_Default.Value = source.Thickness_Default;
                changedProperties.Add(nameof(Thickness_Default));
                changedDictionary.Add(ThemeDictionaryKey.Thickness_Default, Thickness_Default);
            }
            if (EqualityComparer<Thickness>.Default.Equals(_common.Thickness_Zero.Value, source.Thickness_Zero))
            {
                _common.Thickness_Zero.Value = source.Thickness_Zero;
                changedProperties.Add(nameof(Thickness_Zero));
                changedDictionary.Add(ThemeDictionaryKey.Thickness_Zero, Thickness_Zero);
            }

            if (EqualityComparer<Color>.Default.Equals(_common.ColorPalette_Foreground.Value, source.ColorPalette_Foreground))
            {
                _common.ColorPalette_Foreground.Value = source.ColorPalette_Foreground;
                changedProperties.Add(nameof(ColorPalette_Foreground));
                var brush = new SolidColorBrush(ColorPalette_Foreground);
                brush.Freeze();
                changedDictionary.Add(ThemeDictionaryKey.ColorPalette_Foreground, brush);
            }
            if (EqualityComparer<Color>.Default.Equals(_common.ColorPalette_Foreground_Disable.Value, source.ColorPalette_Foreground_Disable))
            {
                _common.ColorPalette_Foreground_Disable.Value = source.ColorPalette_Foreground_Disable;
                changedProperties.Add(nameof(ColorPalette_Foreground_Disable));
                changedDictionary.Add(ThemeDictionaryKey.ColorPalette_Foreground_Disable, makeBrush(ColorPalette_Foreground_Disable));
            }
            if (EqualityComparer<Color>.Default.Equals(_common.ColorPalette_Background.Value, source.ColorPalette_Background))
            {
                _common.ColorPalette_Background.Value = source.ColorPalette_Background;
                changedProperties.Add(nameof(ColorPalette_Background));
                changedDictionary.Add(ThemeDictionaryKey.ColorPalette_Background, makeBrush(ColorPalette_Background));
            }
            if (EqualityComparer<Color>.Default.Equals(_common.ColorPalette_Outline.Value, source.ColorPalette_Outline))
            {
                _common.ColorPalette_Outline.Value = source.ColorPalette_Outline;
                changedProperties.Add(nameof(ColorPalette_Outline));
                changedDictionary.Add(ThemeDictionaryKey.ColorPalette_Outline, makeBrush(ColorPalette_Outline));
            }
            if (EqualityComparer<Color>.Default.Equals(_common.ColorPalette_Line.Value, source.ColorPalette_Line))
            {
                _common.ColorPalette_Line.Value = source.ColorPalette_Line;
                changedProperties.Add(nameof(ColorPalette_Line));
                changedDictionary.Add(ThemeDictionaryKey.ColorPalette_Line, makeBrush(ColorPalette_Line));
            }
            if (EqualityComparer<Color>.Default.Equals(_common.ColorPalette_Highlight.Value, source.ColorPalette_Highlight))
            {
                _common.ColorPalette_Highlight.Value = source.ColorPalette_Highlight;
                changedProperties.Add(nameof(ColorPalette_Highlight));
                changedDictionary.Add(ThemeDictionaryKey.ColorPalette_Highlight, makeBrush(ColorPalette_Highlight));
            }
            if (EqualityComparer<Color>.Default.Equals(_common.ColorPalette_Selection.Value, source.ColorPalette_Selection))
            {
                _common.ColorPalette_Selection.Value = source.ColorPalette_Selection;
                changedProperties.Add(nameof(ColorPalette_Selection));
                changedDictionary.Add(ThemeDictionaryKey.ColorPalette_Selection, makeBrush(ColorPalette_Selection));
            }
            if (EqualityComparer<Color>.Default.Equals(_common.ColorPalette_Mask.Value, source.ColorPalette_Mask))
            {
                _common.ColorPalette_Mask.Value = source.ColorPalette_Mask;
                changedProperties.Add(nameof(ColorPalette_Mask));
                changedDictionary.Add(ThemeDictionaryKey.ColorPalette_Mask, makeBrush(ColorPalette_Mask));
            }

            if (EqualityComparer<Color>.Default.Equals(_overlay.BorderBackground_Disable.Value, source.OverlayBorderBackground_Disable))
            {
                _overlay.BorderBackground_Disable.Value = source.OverlayBorderBackground_Disable;
                changedProperties.Add(nameof(OverlayBorderBackground_Disable));
                changedDictionary.Add(ThemeDictionaryKey.OverlayBorderBackground_Disable, makeBrush(OverlayBorderBackground_Disable));
            }
            if (EqualityComparer<Color>.Default.Equals(_overlay.BorderBackground_Default.Value, source.OverlayBorderBackground_Default))
            {
                _overlay.BorderBackground_Default.Value = source.OverlayBorderBackground_Default;
                changedProperties.Add(nameof(OverlayBorderBackground_Default));
                changedDictionary.Add(ThemeDictionaryKey.OverlayBorderBackground_Default, makeBrush(OverlayBorderBackground_Default));
            }
            if (EqualityComparer<Color>.Default.Equals(_overlay.BorderBackground_MouseOver.Value, source.OverlayBorderBackground_MouseOver))
            {
                _overlay.BorderBackground_MouseOver.Value = source.OverlayBorderBackground_MouseOver;
                changedProperties.Add(nameof(OverlayBorderBackground_MouseOver));
                changedDictionary.Add(ThemeDictionaryKey.OverlayBorderBackground_MouseOver, makeBrush(OverlayBorderBackground_MouseOver));
            }
            if (EqualityComparer<Color>.Default.Equals(_overlay.BorderBackground_Active.Value, source.OverlayBorderBackground_Active))
            {
                _overlay.BorderBackground_Active.Value = source.OverlayBorderBackground_Active;
                changedProperties.Add(nameof(OverlayBorderBackground_Active));
                changedDictionary.Add(ThemeDictionaryKey.OverlayBorderBackground_Active, makeBrush(OverlayBorderBackground_Active));
            }

            if (EqualityComparer<Color>.Default.Equals(_overlay.BorderOutline_Disable.Value, source.OverlayBorderOutline_Disable))
            {
                _overlay.BorderOutline_Disable.Value = source.OverlayBorderOutline_Disable;
                changedProperties.Add(nameof(OverlayBorderOutline_Disable));
                changedDictionary.Add(ThemeDictionaryKey.OverlayBorderOutline_Disable, makeBrush(OverlayBorderOutline_Disable));
            }
            if (EqualityComparer<Color>.Default.Equals(_overlay.BorderOutline_Default.Value, source.OverlayBorderOutline_Default))
            {
                _overlay.BorderOutline_Default.Value = source.OverlayBorderOutline_Default;
                changedProperties.Add(nameof(OverlayBorderOutline_Default));
                changedDictionary.Add(ThemeDictionaryKey.OverlayBorderOutline_Default, makeBrush(OverlayBorderOutline_Default));
            }
            if (EqualityComparer<Color>.Default.Equals(_overlay.BorderOutline_MouseOver.Value, source.OverlayBorderOutline_MouseOver))
            {
                _overlay.BorderOutline_MouseOver.Value = source.OverlayBorderOutline_MouseOver;
                changedProperties.Add(nameof(OverlayBorderOutline_MouseOver));
                changedDictionary.Add(ThemeDictionaryKey.OverlayBorderOutline_MouseOver, makeBrush(OverlayBorderOutline_MouseOver));
            }
            if (EqualityComparer<Color>.Default.Equals(_overlay.BorderOutline_Active.Value, source.OverlayBorderOutline_Active))
            {
                _overlay.BorderOutline_Active.Value = source.OverlayBorderOutline_Active;
                changedProperties.Add(nameof(OverlayBorderOutline_Active));
                changedDictionary.Add(ThemeDictionaryKey.OverlayBorderOutline_Active, makeBrush(OverlayBorderOutline_Active));
            }

            if (EqualityComparer<Color>.Default.Equals(_overlay.MaskForeground_Disable.Value, source.OverlayMaskForeground_Disable))
            {
                _overlay.MaskForeground_Disable.Value = source.OverlayMaskForeground_Disable;
                changedProperties.Add(nameof(OverlayMaskForeground_Disable));
                changedDictionary.Add(ThemeDictionaryKey.OverlayMaskForeground_Disable, makeBrush(OverlayMaskForeground_Disable));
            }
            if (EqualityComparer<Color>.Default.Equals(_overlay.MaskForeground_Default.Value, source.OverlayMaskForeground_Default))
            {
                _overlay.MaskForeground_Default.Value = source.OverlayMaskForeground_Default;
                changedProperties.Add(nameof(OverlayMaskForeground_Default));
                changedDictionary.Add(ThemeDictionaryKey.OverlayMaskForeground_Default, makeBrush(OverlayMaskForeground_Default));
            }
            if (EqualityComparer<Color>.Default.Equals(_overlay.MaskForeground_MouseOver.Value, source.OverlayMaskForeground_MouseOver))
            {
                _overlay.MaskForeground_MouseOver.Value = source.OverlayMaskForeground_MouseOver;
                changedProperties.Add(nameof(OverlayMaskForeground_MouseOver));
                changedDictionary.Add(ThemeDictionaryKey.OverlayMaskForeground_MouseOver, makeBrush(OverlayMaskForeground_MouseOver));
            }
            if (EqualityComparer<Color>.Default.Equals(_overlay.MaskForeground_Active.Value, source.OverlayMaskForeground_Active))
            {
                _overlay.MaskForeground_Active.Value = source.OverlayMaskForeground_Active;
                changedProperties.Add(nameof(OverlayMaskForeground_Active));
                changedDictionary.Add(ThemeDictionaryKey.OverlayMaskForeground_Active, makeBrush(OverlayMaskForeground_Active));
            }

            // Bulk Update Dictionary
            var dicts = GetAllDictionaries().ToList();
            foreach (var pair in changedDictionary)
            {
                bool updated = false;

                foreach (var dict in dicts)
                {
                    if (dict.Contains(pair.Key))
                    {
                        dict[pair.Key] = pair.Value;
                        updated = true;
                    }
                }

                if (!updated)
                {
                    System.Windows.Application.Current.Resources[pair.Key] = pair.Value;
                }
            }

            // Notify Property Changed
            foreach (var item in changedProperties)
                OnPropertyChanged(item);

            return changedProperties.Count > 0 || changedDictionary.Count > 0;
        }

        /// <summary> Returns all flattened merged dictionaries in the current application. </summary>
        private IEnumerable<ResourceDictionary> GetAllDictionaries()
        {
            return System.Windows.Application.Current.Resources.MergedDictionaries != null
                ? System.Windows.Application.Current.Resources.MergedDictionaries.SelectMany(Flatten)
                : Array.Empty<ResourceDictionary>();
        }

        /// <summary> Recursively flattens nested merged dictionaries. </summary>
        private IEnumerable<ResourceDictionary> Flatten(ResourceDictionary dict)
        {
            yield return dict;
            foreach (var child in dict.MergedDictionaries)
            {
                foreach (var nested in Flatten(child))
                    yield return nested;
            }
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
    internal partial class Current
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
            SetValue(value, _common.ThemeName.Value, ThemeDictionaryKey.ThemeName,
            () => _common.ThemeName.Value = value, nameof(ThemeName));
        }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Font Sizes Private Get Set ==========

        /// <summary> Gets the font size for <see cref="FontSize_Header1"/> elements. </summary>
        private double GetFontSize_Header1() => _common.FontSize_Header1.Value;
        /// <summary> Sets the font size for <see cref="FontSize_Header1"/> elements and applies changes to the resource dictionary. </summary>
        private void SetFontSize_Header1(double value) => SetValue(value, _common.FontSize_Header1.Value,
            ThemeDictionaryKey.FontSize_Header1, () => _common.FontSize_Header1.Value = value, nameof(FontSize_Header1));

        /// <summary> Gets the font size for <see cref="FontSize_Header2"/> elements. </summary>
        private double GetFontSize_Header2() => _common.FontSize_Header2.Value;
        /// <summary> Sets the font size for <see cref="FontSize_Header2"/> elements and applies changes to the resource dictionary. </summary>
        private void SetFontSize_Header2(double value) => SetValue(value, _common.FontSize_Header2.Value,
            ThemeDictionaryKey.FontSize_Header2, () => _common.FontSize_Header2.Value = value, nameof(FontSize_Header2));

        /// <summary> Gets the font size for <see cref="FontSize_Header3"/> elements. </summary>
        private double GetFontSize_Header3() => _common.FontSize_Header3.Value;
        /// <summary> Sets the font size for <see cref="FontSize_Header3"/> elements and applies changes to the resource dictionary. </summary>
        private void SetFontSize_Header3(double value) => SetValue(value, _common.FontSize_Header3.Value,
            ThemeDictionaryKey.FontSize_Header3, () => _common.FontSize_Header3.Value = value, nameof(FontSize_Header3));

        /// <summary> Gets the font size for <see cref="FontSize_Header4"/> elements. </summary>
        private double GetFontSize_Header4() => _common.FontSize_Header4.Value;
        /// <summary> Sets the font size for <see cref="FontSize_Header4"/> elements and applies changes to the resource dictionary. </summary>
        private void SetFontSize_Header4(double value) => SetValue(value, _common.FontSize_Header4.Value,
            ThemeDictionaryKey.FontSize_Header4, () => _common.FontSize_Header4.Value = value, nameof(FontSize_Header4));

        /// <summary> Gets the font size for <see cref="FontSize_Header5"/> elements. </summary>
        private double GetFontSize_Header5() => _common.FontSize_Header5.Value;
        /// <summary> Sets the font size for <see cref="FontSize_Header5"/> elements and applies changes to the resource dictionary. </summary>
        private void SetFontSize_Header5(double value) => SetValue(value, _common.FontSize_Header5.Value,
            ThemeDictionaryKey.FontSize_Header5, () => _common.FontSize_Header5.Value = value, nameof(FontSize_Header5));

        /// <summary> Gets the font size for <see cref="FontSize_Header6"/> elements. </summary>
        private double GetFontSize_Header6() => _common.FontSize_Header6.Value;
        /// <summary> Sets the font size for <see cref="FontSize_Header6"/> elements and applies changes to the resource dictionary. </summary>
        private void SetFontSize_Header6(double value) => SetValue(value, _common.FontSize_Header6.Value,
            ThemeDictionaryKey.FontSize_Header6, () => _common.FontSize_Header6.Value = value, nameof(FontSize_Header6));

        /// <summary> Gets the font size for <see cref="FontSize_Default"/> elements. </summary>
        private double GetFontSize_Default() => _common.FontSize_Default.Value;
        /// <summary> Sets the font size for <see cref="FontSize_Default"/> elements and applies changes to the resource dictionary. </summary>
        private void SetFontSize_Default(double value) => SetValue(value, _common.FontSize_Default.Value,
            ThemeDictionaryKey.FontSize_Default, () => _common.FontSize_Default.Value = value, nameof(FontSize_Default));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Thickness Private Get Set ==========

        /// <summary> Gets the default thickness value used in UI components. </summary>
        private Thickness GetThickness_Default() => _common.Thickness_Default.Value;
        /// <summary> Sets the default thickness value and updates the resource dictionary. </summary>
        private void SetThickness_Default(Thickness value) => SetValue(value, _common.Thickness_Default.Value,
            ThemeDictionaryKey.Thickness_Default, () => _common.Thickness_Default.Value = value, nameof(Thickness_Default));

        /// <summary> Gets the zero-thickness value, typically used for borderless or padding-less elements. </summary>
        private Thickness GetThickness_Zero() => _common.Thickness_Zero.Value;
        /// <summary> Sets the zero-thickness value and updates the resource dictionary. </summary>
        private void SetThickness_Zero(Thickness value) => SetValue(value, _common.Thickness_Zero.Value,
            ThemeDictionaryKey.Thickness_Zero, () => _common.Thickness_Zero.Value = value, nameof(Thickness_Zero));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Color Palette Private Get Set ==========

        /// <summary> Gets the primary foreground color used in the theme. </summary>
        private Color GetColorPalette_Foreground() => _common.ColorPalette_Foreground.Value;
        /// <summary> Sets the primary foreground color and updates related resources. </summary>
        private void SetColorPalette_Foreground(Color value) => SetBrush(value, _common.ColorPalette_Foreground.Value,
            ThemeDictionaryKey.ColorPalette_Foreground, () => _common.ColorPalette_Foreground.Value = value, nameof(ColorPalette_Foreground));

        /// <summary> Gets the foreground color for disabled UI states. </summary>
        private Color GetColorPalette_Foreground_Disable() => _common.ColorPalette_Foreground_Disable.Value;
        /// <summary> Sets the disabled foreground color and applies it to the resources. </summary>
        private void SetColorPalette_Foreground_Disable(Color value) => SetBrush(value, _common.ColorPalette_Foreground_Disable.Value,
            ThemeDictionaryKey.ColorPalette_Foreground_Disable, () => _common.ColorPalette_Foreground_Disable.Value = value, nameof(ColorPalette_Foreground_Disable));

        /// <summary> Gets the background color for content areas. </summary>
        private Color GetColorPalette_Background() => _common.ColorPalette_Background.Value;
        /// <summary> Sets the background color and updates the resource dictionary. </summary>
        private void SetColorPalette_Background(Color value) => SetBrush(value, _common.ColorPalette_Background.Value,
            ThemeDictionaryKey.ColorPalette_Background, () => _common.ColorPalette_Background.Value = value, nameof(ColorPalette_Background));

        /// <summary> Gets the outline color used around themed UI components. </summary>
        private Color GetColorPalette_Outline() => _common.ColorPalette_Outline.Value;
        /// <summary> Sets the outline color and updates the resource dictionary accordingly. </summary>
        private void SetColorPalette_Outline(Color value) => SetBrush(value, _common.ColorPalette_Outline.Value,
            ThemeDictionaryKey.ColorPalette_Outline, () => _common.ColorPalette_Outline.Value = value, nameof(ColorPalette_Outline));

        /// <summary> Gets the line color typically used for separators or borders. </summary>
        private Color GetColorPalette_Line() => _common.ColorPalette_Line.Value;
        /// <summary> Sets the line color and reflects the change in the resource dictionary. </summary>
        private void SetColorPalette_Line(Color value) => SetBrush(value, _common.ColorPalette_Line.Value,
            ThemeDictionaryKey.ColorPalette_Line, () => _common.ColorPalette_Line.Value = value, nameof(ColorPalette_Line));

        /// <summary> Gets the highlight color used to indicate focus or emphasis. </summary>
        private Color GetColorPalette_Highlight() => _common.ColorPalette_Highlight.Value;
        /// <summary> Sets the highlight color and updates resource values. </summary>
        private void SetColorPalette_Highlight(Color value) => SetBrush(value, _common.ColorPalette_Highlight.Value,
            ThemeDictionaryKey.ColorPalette_Highlight, () => _common.ColorPalette_Highlight.Value = value, nameof(ColorPalette_Highlight));

        /// <summary> Gets the selection color used for selected items or highlights. </summary>
        private Color GetColorPalette_Selection() => _common.ColorPalette_Selection.Value;
        /// <summary> Sets the selection color and updates related resources. </summary>
        private void SetColorPalette_Selection(Color value) => SetBrush(value, _common.ColorPalette_Selection.Value,
            ThemeDictionaryKey.ColorPalette_Selection, () => _common.ColorPalette_Selection.Value = value, nameof(ColorPalette_Selection));

        /// <summary> Gets the mask color overlay applied to obscured content. </summary>
        private Color GetColorPalette_Mask() => _common.ColorPalette_Mask.Value;
        /// <summary> Sets the mask color overlay and updates the resource dictionary. </summary>
        private void SetColorPalette_Mask(Color value) => SetBrush(value, _common.ColorPalette_Mask.Value,
            ThemeDictionaryKey.ColorPalette_Mask, () => _common.ColorPalette_Mask.Value = value, nameof(ColorPalette_Mask));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Border Background Private Get Set ==========

        /// <summary> Gets the background color of overlay borders in the [Disabled] state. </summary>
        private Color GetOverlayBorderBackground_Disable() => _overlay.BorderBackground_Disable.Value;
        /// <summary> Sets the background color of overlay borders in the [Disabled] state. </summary>
        private void SetOverlayBorderBackground_Disable(Color value) => SetBrush(value, _overlay.BorderBackground_Disable.Value,
            ThemeDictionaryKey.OverlayBorderBackground_Disable, () => _overlay.BorderBackground_Disable.Value = value, nameof(OverlayBorderBackground_Disable));

        /// <summary> Gets the background color of overlay borders in the [Default] state. </summary>
        private Color GetOverlayBorderBackground_Default() => _overlay.BorderBackground_Default.Value;
        /// <summary> Sets the background color of overlay borders in the [Default] state. </summary>
        private void SetOverlayBorderBackground_Default(Color value) => SetBrush(value, _overlay.BorderBackground_Default.Value,
            ThemeDictionaryKey.OverlayBorderBackground_Default, () => _overlay.BorderBackground_Default.Value = value, nameof(OverlayBorderBackground_Default));

        /// <summary> Gets the background color of overlay borders in the [Mouse-Over] state. </summary>
        private Color GetOverlayBorderBackground_MouseOver() => _overlay.BorderBackground_MouseOver.Value;
        /// <summary> Sets the background color of overlay borders in the [Mouse-Over] state. </summary>
        private void SetOverlayBorderBackground_MouseOver(Color value) => SetBrush(value, _overlay.BorderBackground_MouseOver.Value,
            ThemeDictionaryKey.OverlayBorderBackground_MouseOver, () => _overlay.BorderBackground_MouseOver.Value = value, nameof(OverlayBorderBackground_MouseOver));

        /// <summary> Gets the background color of overlay borders in the [Active] state. </summary>
        private Color GetOverlayBorderBackground_Active() => _overlay.BorderBackground_Active.Value;
        /// <summary> Sets the background color of overlay borders in the [Active] state. </summary>
        private void SetOverlayBorderBackground_Active(Color value) => SetBrush(value, _overlay.BorderBackground_Active.Value,
            ThemeDictionaryKey.OverlayBorderBackground_Active, () => _overlay.BorderBackground_Active.Value = value, nameof(OverlayBorderBackground_Active));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Border Outline Private Get Set ==========

        /// <summary> Gets the outline color of overlay components in the [Disabled] state. </summary>
        private Color GetOverlayBorderOutline_Disable() => _overlay.BorderOutline_Disable.Value;
        /// <summary> Sets the outline color of overlay components in the [Disabled] state. </summary>
        private void SetOverlayBorderOutline_Disable(Color value) => SetBrush(value, _overlay.BorderOutline_Disable.Value,
            ThemeDictionaryKey.OverlayBorderOutline_Disable, () => _overlay.BorderOutline_Disable.Value = value, nameof(OverlayBorderOutline_Disable));

        /// <summary> Gets the outline color of overlay components in the [Default] state. </summary>
        private Color GetOverlayBorderOutline_Default() => _overlay.BorderOutline_Default.Value;
        /// <summary> Sets the outline color of overlay components in the [Default] state. </summary>
        private void SetOverlayBorderOutline_Default(Color value) => SetBrush(value, _overlay.BorderOutline_Default.Value,
            ThemeDictionaryKey.OverlayBorderOutline_Default, () => _overlay.BorderOutline_Default.Value = value, nameof(OverlayBorderOutline_Default));

        /// <summary> Gets the outline color of overlay components in the [Mouse-Over] state. </summary>
        private Color GetOverlayBorderOutline_MouseOver() => _overlay.BorderOutline_MouseOver.Value;
        /// <summary> Sets the outline color of overlay components in the [Mouse-Over] state. </summary>
        private void SetOverlayBorderOutline_MouseOver(Color value) => SetBrush(value, _overlay.BorderOutline_MouseOver.Value,
            ThemeDictionaryKey.OverlayBorderOutline_MouseOver, () => _overlay.BorderOutline_MouseOver.Value = value, nameof(OverlayBorderOutline_MouseOver));

        /// <summary> Gets the outline color of overlay components in the [Active] state. </summary>
        private Color GetOverlayBorderOutline_Active() => _overlay.BorderOutline_Active.Value;
        /// <summary> Sets the outline color of overlay components in the [Active] state. </summary>
        private void SetOverlayBorderOutline_Active(Color value) => SetBrush(value, _overlay.BorderOutline_Active.Value,
            ThemeDictionaryKey.OverlayBorderOutline_Active, () => _overlay.BorderOutline_Active.Value = value, nameof(OverlayBorderOutline_Active));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Mask Foreground Private Get Set ==========

        /// <summary> Gets the foreground mask color of overlay content on [Disabled]. </summary>
        private Color GetOverlayMaskForeground_Disable() => _overlay.MaskForeground_Disable.Value;
        /// <summary> Sets the [Disabled] foreground mask color for overlays. </summary>
        private void SetOverlayMaskForeground_Disable(Color value) => SetBrush(value, _overlay.MaskForeground_Disable.Value,
            ThemeDictionaryKey.OverlayMaskForeground_Disable, () => _overlay.MaskForeground_Disable.Value = value, nameof(OverlayMaskForeground_Disable));

        /// <summary> Gets the foreground mask color of overlay content on [Default]. </summary>
        private Color GetOverlayMaskForeground_Default() => _overlay.MaskForeground_Default.Value;
        /// <summary> Sets the [Default] foreground mask color for overlays. </summary>
        private void SetOverlayMaskForeground_Default(Color value) => SetBrush(value, _overlay.MaskForeground_Default.Value,
            ThemeDictionaryKey.OverlayMaskForeground_Default, () => _overlay.MaskForeground_Default.Value = value, nameof(OverlayMaskForeground_Default));

        /// <summary> Gets the foreground mask color of overlay content on [Mouse-Over]. </summary>
        private Color GetOverlayMaskForeground_MouseOver() => _overlay.MaskForeground_MouseOver.Value;
        /// <summary> Sets the [Mouse-Over] foreground mask color for overlays. </summary>
        private void SetOverlayMaskForeground_MouseOver(Color value) => SetBrush(value, _overlay.MaskForeground_MouseOver.Value,
            ThemeDictionaryKey.OverlayMaskForeground_MouseOver, () => _overlay.MaskForeground_MouseOver.Value = value, nameof(OverlayMaskForeground_MouseOver));

        /// <summary> Gets the foreground mask color of overlay content on [Active]. </summary>
        private Color GetOverlayMaskForeground_Active() => _overlay.MaskForeground_Active.Value;
        /// <summary> Sets the [Active] foreground mask color for overlays. </summary>
        private void SetOverlayMaskForeground_Active(Color value) => SetBrush(value, _overlay.MaskForeground_Active.Value,
            ThemeDictionaryKey.OverlayMaskForeground_Active, () => _overlay.MaskForeground_Active.Value = value, nameof(OverlayMaskForeground_Active));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Interface - ICurrent - Private Methods ==========

        /// <summary>
        /// Saves the current theme values to the associated INI file. <br/>
        /// Applies all theme properties before saving.
        /// </summary>
        /// <returns>True if the file was saved successfully; otherwise, false.</returns>
        private bool SaveToFile()
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

        private bool LoadFromFile()
        {
            if (_iniState is null)
                return false;
            if (_iniState.Load() is false)
                return false;
            return RestoreAndSyncUI();
        }

        /// <summary>
        /// Restores all theme values from the INI state into memory. <br/>
        /// Uses parallel processing where supported.
        /// </summary>
        /// <returns>True if all theme values were restored successfully; otherwise, false.</returns>
        private bool Restore_Private()
        {
            if (_themeProperties is null)
                return false;
            if (_iniState is null)
                return false;

            var beforeTheme = CreateCopy();
            bool result = true;
            foreach (var item in _themeProperties)
                result &= item.Value.Restore(_iniState);
            result &= UpdateThemeProperty_All(beforeTheme);
            return result;
        }

        /// <summary>
        /// Resets all theme properties to their default values. <br/>
        /// This operation does not save changes to the INI file.
        /// </summary>
        private void ResetValueToDefault_Private()
        {
            if (_themeProperties is null)
                return;
            foreach (var item in _themeProperties)
                item.Value.ResetValueToDefault();
        }

        #endregion
    }
}