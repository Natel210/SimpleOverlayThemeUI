using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using SimpleOverlayTheme.Theme.ThemeDictionary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using SimpleOverlayTheme.Theme.Interface;
using SimpleFileIO.State.Ini;
using SimpleOverlayTheme.Theme.ThemeProperty;

namespace SimpleOverlayTheme.Theme
{
    /// <summary>
    /// 현재 테마에 대한 ViewModel 역할을 수행하며,
    /// 변경 시 ResourceDictionary 반영 및 UI 반응을 위해 INotifyPropertyChanged 구현.
    /// </summary>
    public class Current : ITheme, INotifyPropertyChanged
    {
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Single ton ==========

        internal static Current Instance { get; } = new Current();

        private Current() { }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Interface - INotifyPropertyChanged ==========

        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
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

        #region OverlayBorderBackground

        /// <inheritdoc />
        public Color OverlayBorderBackground_Disable { get => GetOverlayBorderBackground_Disable(); set => SetOverlayBorderBackground_Disable(value); }

        /// <inheritdoc />
        public Color OverlayBorderBackground_Default { get => GetOverlayBorderBackground_Default(); set => SetOverlayBorderBackground_Default(value); }

        /// <inheritdoc />
        public Color OverlayBorderBackground_MouseOver { get => GetOverlayBorderBackground_MouseOver(); set => SetOverlayBorderBackground_MouseOver(value); }

        /// <inheritdoc />
        public Color OverlayBorderBackground_Active { get => GetOverlayBorderBackground_Active(); set => SetOverlayBorderBackground_Active(value); }


        public new Color OverlayBorderBackground_Disable
        {
            get => base.OverlayBorderBackground_Disable;
            set => SetBrush(value, base.OverlayBorderBackground_Disable, ThemeDictionaryKey.OverlayBorderBackground_Disable,
                () => base.OverlayBorderBackground_Disable = value, nameof(OverlayBorderBackground_Disable));
        }
        public new Color OverlayBorderBackground_Default
        {
            get => base.OverlayBorderBackground_Default;
            set => SetBrush(value, base.OverlayBorderBackground_Default, ThemeDictionaryKey.OverlayBorderBackground_Default,
                () => base.OverlayBorderBackground_Default = value, nameof(OverlayBorderBackground_Default));
        }
        public new Color OverlayBorderBackground_MouseOver
        {
            get => base.OverlayBorderBackground_MouseOver;
            set => SetBrush(value, base.OverlayBorderBackground_MouseOver, ThemeDictionaryKey.OverlayBorderBackground_MouseOver,
                () => base.OverlayBorderBackground_MouseOver = value, nameof(OverlayBorderBackground_MouseOver));
        }
        public new Color OverlayBorderBackground_Active
        {
            get => base.OverlayBorderBackground_Active;
            set => SetBrush(value, base.OverlayBorderBackground_Active, ThemeDictionaryKey.OverlayBorderBackground_Active,
                () => base.OverlayBorderBackground_Active = value, nameof(OverlayBorderBackground_Active));
        }
        #endregion

        #region OverlayBorderOutline
        public new Color OverlayBorderOutline_Disable
        {
            get => base.OverlayBorderOutline_Disable;
            set => SetBrush(value, base.OverlayBorderOutline_Disable, ThemeDictionaryKey.OverlayBorderOutline_Disable,
                () => base.OverlayBorderOutline_Disable = value, nameof(OverlayBorderOutline_Disable));
        }
        public new Color OverlayBorderOutline_Default
        {
            get => base.OverlayBorderOutline_Default;
            set => SetBrush(value, base.OverlayBorderOutline_Default, ThemeDictionaryKey.OverlayBorderOutline_Default,
                () => base.OverlayBorderOutline_Default = value, nameof(OverlayBorderOutline_Default));
        }
        public new Color OverlayBorderOutline_MouseOver
        {
            get => base.OverlayBorderOutline_MouseOver;
            set => SetBrush(value, base.OverlayBorderOutline_MouseOver, ThemeDictionaryKey.OverlayBorderOutline_MouseOver,
                () => base.OverlayBorderOutline_MouseOver = value, nameof(OverlayBorderOutline_MouseOver));
        }
        public new Color OverlayBorderOutline_Active
        {
            get => base.OverlayBorderOutline_Active;
            set => SetBrush(value, base.OverlayBorderOutline_Active, ThemeDictionaryKey.OverlayBorderOutline_Active,
                () => base.OverlayBorderOutline_Active = value, nameof(OverlayBorderOutline_Active));
        }
        #endregion

        #region OverlayMaskForeground
        public new Color OverlayMaskForeground_Disable
        {
            get => base.OverlayMaskForeground_Disable;
            set => SetBrush(value, base.OverlayMaskForeground_Disable, ThemeDictionaryKey.OverlayMaskForeground_Disable,
                () => base.OverlayMaskForeground_Disable = value, nameof(OverlayMaskForeground_Disable));
        }
        public new Color OverlayMaskForeground_Default
        {
            get => base.OverlayMaskForeground_Default;
            set => SetBrush(value, base.OverlayMaskForeground_Default, ThemeDictionaryKey.OverlayMaskForeground_Default,
                () => base.OverlayMaskForeground_Default = value, nameof(OverlayMaskForeground_Default));
        }
        public new Color OverlayMaskForeground_MouseOver
        {
            get => base.OverlayMaskForeground_MouseOver;
            set => SetBrush(value, base.OverlayMaskForeground_MouseOver, ThemeDictionaryKey.OverlayMaskForeground_MouseOver,
                () => base.OverlayMaskForeground_MouseOver = value, nameof(OverlayMaskForeground_MouseOver));
        }
        public new Color OverlayMaskForeground_Active
        {
            get => base.OverlayMaskForeground_Active;
            set => SetBrush(value, base.OverlayMaskForeground_Active, ThemeDictionaryKey.OverlayMaskForeground_Active,
                () => base.OverlayMaskForeground_Active = value, nameof(OverlayMaskForeground_Active));
        }
        #endregion


        private readonly IINIState _iniFile;
        private readonly Dictionary<string, IThemeProperty> _themeProperties;

        private CommonThemeProperty _common;
        private OverlayThemeProperty _overlay;

        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Tools ==========

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="current"></param>
        /// <param name="next"></param>
        /// <param name="key"></param>
        /// <param name="setter"></param>
        /// <param name="propertyName"></param>
        private void SetValue<T>(T current, T next, string key, Action setter, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(current, next) is false)
            {
                setter();
                UpdateResource(key, next);
                OnPropertyChanged(propertyName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="next"></param>
        /// <param name="key"></param>
        /// <param name="setter"></param>
        /// <param name="propertyName"></param>
        private void SetBrush(Color current, Color next, string key, Action setter, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<Color>.Default.Equals(current, next) is false)
            {
                setter();
                var brush = new SolidColorBrush(current);
                brush.Freeze();
                UpdateResource(key, brush);
                OnPropertyChanged(propertyName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
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
            Application.Current.Resources[key] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ResourceDictionary> GetAllDictionaries()
        {
            return Application.Current.Resources.MergedDictionaries != null
                ? Application.Current.Resources.MergedDictionaries.SelectMany(Flatten)
                : Array.Empty<ResourceDictionary>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        private IEnumerable<ResourceDictionary> Flatten(ResourceDictionary dict)
        {
            yield return dict;
            foreach (var child in dict.MergedDictionaries)
            {
                foreach (var nested in Flatten(child))
                    yield return nested;
            }
        }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Identity ==========

        private string GetThemeName() => _common.ThemeName.Value;
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
        #region ========== Font Sizes ==========

        private double GetFontSize_Header1() => _common.FontSize_Header1.Value;
        private void SetFontSize_Header1(double value) => SetValue(value, _common.FontSize_Header1.Value,
            ThemeDictionaryKey.FontSize_Header1, () => _common.FontSize_Header1.Value = value, nameof(FontSize_Header1));

        private double GetFontSize_Header2() => _common.FontSize_Header2.Value;
        private void SetFontSize_Header2(double value) => SetValue(value, _common.FontSize_Header2.Value,
            ThemeDictionaryKey.FontSize_Header2, () => _common.FontSize_Header2.Value = value, nameof(FontSize_Header2));

        private double GetFontSize_Header3() => _common.FontSize_Header3.Value;
        private void SetFontSize_Header3(double value) => SetValue(value, _common.FontSize_Header3.Value,
            ThemeDictionaryKey.FontSize_Header3, () => _common.FontSize_Header3.Value = value, nameof(FontSize_Header3));

        private double GetFontSize_Header4() => _common.FontSize_Header4.Value;
        private void SetFontSize_Header4(double value) => SetValue(value, _common.FontSize_Header4.Value,
            ThemeDictionaryKey.FontSize_Header4, () => _common.FontSize_Header4.Value = value, nameof(FontSize_Header4));

        private double GetFontSize_Header5() => _common.FontSize_Header5.Value;
        private void SetFontSize_Header5(double value) => SetValue(value, _common.FontSize_Header5.Value,
            ThemeDictionaryKey.FontSize_Header5, () => _common.FontSize_Header5.Value = value, nameof(FontSize_Header5));

        private double GetFontSize_Header6() => _common.FontSize_Header6.Value;
        private void SetFontSize_Header6(double value) => SetValue(value, _common.FontSize_Header6.Value,
            ThemeDictionaryKey.FontSize_Header6, () => _common.FontSize_Header6.Value = value, nameof(FontSize_Header6));

        private double GetFontSize_Default() => _common.FontSize_Default.Value;
        private void SetFontSize_Default(double value) => SetValue(value, _common.FontSize_Default.Value,
            ThemeDictionaryKey.FontSize_Default, () => _common.FontSize_Default.Value = value, nameof(FontSize_Default));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Thickness ==========

        private Thickness GetThickness_Default() => _common.Thickness_Default.Value;
        private void SetThickness_Default(Thickness value) => SetValue(value, _common.Thickness_Default.Value,
            ThemeDictionaryKey.Thickness_Default, () => _common.Thickness_Default.Value = value, nameof(Thickness_Default));
        

        private Thickness GetThickness_Zero() => _common.Thickness_Zero.Value;
        private void SetThickness_Zero(Thickness value) => SetValue(value, _common.Thickness_Zero.Value,
            ThemeDictionaryKey.Thickness_Zero, () => _common.Thickness_Zero.Value = value, nameof(Thickness_Zero));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Color Palette ==========

        private Color GetColorPalette_Foreground() => _common.ColorPalette_Foreground.Value;
        private void SetColorPalette_Foreground(Color value) => SetBrush(value, _common.ColorPalette_Foreground.Value,
            ThemeDictionaryKey.ColorPalette_Foreground, () => _common.ColorPalette_Foreground.Value = value, nameof(ColorPalette_Foreground));

        private Color GetColorPalette_Foreground_Disable() => _common.ColorPalette_Foreground_Disable.Value;
        private void SetColorPalette_Foreground_Disable(Color value) => SetBrush(value, _common.ColorPalette_Foreground_Disable.Value,
            ThemeDictionaryKey.ColorPalette_Foreground_Disable, () => _common.ColorPalette_Foreground_Disable.Value = value, nameof(ColorPalette_Foreground_Disable));

        private Color GetColorPalette_Background() => _common.ColorPalette_Background.Value;
        private void SetColorPalette_Background(Color value) => SetBrush(value, _common.ColorPalette_Background.Value,
            ThemeDictionaryKey.ColorPalette_Background, () => _common.ColorPalette_Background.Value = value, nameof(ColorPalette_Background));

        private Color GetColorPalette_Outline() => _common.ColorPalette_Outline.Value;
        private void SetColorPalette_Outline(Color value) => SetBrush(value, _common.ColorPalette_Outline.Value,
            ThemeDictionaryKey.ColorPalette_Outline, () => _common.ColorPalette_Outline.Value = value, nameof(ColorPalette_Outline));

        private Color GetColorPalette_Line() => _common.ColorPalette_Line.Value;
        private void SetColorPalette_Line(Color value) => SetBrush(value, _common.ColorPalette_Line.Value,
            ThemeDictionaryKey.ColorPalette_Line, () => _common.ColorPalette_Line.Value = value, nameof(ColorPalette_Line));

        private Color GetColorPalette_Highlight() => _common.ColorPalette_Highlight.Value;
        private void SetColorPalette_Highlight(Color value) => SetBrush(value, _common.ColorPalette_Highlight.Value,
            ThemeDictionaryKey.ColorPalette_Highlight, () => _common.ColorPalette_Highlight.Value = value, nameof(ColorPalette_Highlight));

        private Color GetColorPalette_Selection() => _common.ColorPalette_Selection.Value;
        private void SetColorPalette_Selection(Color value) => SetBrush(value, _common.ColorPalette_Selection.Value,
            ThemeDictionaryKey.ColorPalette_Selection, () => _common.ColorPalette_Selection.Value = value, nameof(ColorPalette_Selection));

        private Color GetColorPalette_Mask() => _common.ColorPalette_Mask.Value;
        private void SetColorPalette_Mask(Color value) => SetBrush(value, _common.ColorPalette_Mask.Value,
            ThemeDictionaryKey.ColorPalette_Mask, () => _common.ColorPalette_Mask.Value = value, nameof(ColorPalette_Mask));


        #endregion
    }
}

