using GrayThemeUI.Theme;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Windows.ApplicationModel.Activation;
namespace GrayThemeUI.Theme
{
    public class ThemeSetting : ResourceDictionary
    {
        public ThemeSetting()
        {
            ApplyThemeSettings();
            ThemeSettingDataManager.PropertyChanged += OnGlobalVariableChanged;
        }

        private void ApplyThemeSettings()
        {
            // Theme
            this[CurrentThemeName_DictionaryKey] = ThemeSettingDataManager.CurrentThemeName;
            // Font Sizes
            this[FontSize_Header1_DictionaryKey] = ThemeSettingDataManager.FontSize_Header1;
            this[FontSize_Header2_DictionaryKey] = ThemeSettingDataManager.FontSize_Header2;
            this[FontSize_Header3_DictionaryKey] = ThemeSettingDataManager.FontSize_Header3;
            this[FontSize_Header4_DictionaryKey] = ThemeSettingDataManager.FontSize_Header4;
            this[FontSize_Header5_DictionaryKey] = ThemeSettingDataManager.FontSize_Header5;
            this[FontSize_Header6_DictionaryKey] = ThemeSettingDataManager.FontSize_Header6;
            this[FontSize_Default_DictionaryKey] = ThemeSettingDataManager.FontSize_Default;
            // Thickness
            this[Thickness_Default_DictionaryKey] = new Thickness(1.0);
            this[Thickness_Zero_DictionaryKey] = new Thickness(0.0);
            // Default Brush
            this[DefaultBrush_Foreground_DictionaryKey] = ThemeSettingDataManager.DefaultBrush_Foreground;
            this[DefaultBrush_Foreground_Disable_DictionaryKey] = ThemeSettingDataManager.DefaultBrush_Foreground_Disable;
            this[DefaultBrush_Background_DictionaryKey] = Color.FromArgb(255, 0, 255, 255);//ThemeSettingDataManager.DefaultBrush_Background;
            this[DefaultBrush_Outline_DictionaryKey] = ThemeSettingDataManager.DefaultBrush_Outline;
            this[DefaultBrush_Line_DictionaryKey] = ThemeSettingDataManager.DefaultBrush_Line;
            this[DefaultBrush_Highlight_DictionaryKey] = ThemeSettingDataManager.DefaultBrush_Highlight;
            this[DefaultBrush_Selection_DictionaryKey] = ThemeSettingDataManager.DefaultBrush_Selection;
            this[DefaultBrush_Mask_DictionaryKey] = ThemeSettingDataManager.DefaultBrush_Mask;
            // Overlay Boader Background
            this[OverlayBoaderBackground_Disable_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderBackground_Disable;
            this[OverlayBoaderBackground_Default_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderBackground_Default;
            this[OverlayBoaderBackground_MouseOver_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderBackground_MouseOver;
            this[OverlayBoaderBackground_Active_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderBackground_Active;
            // Overlay Boader Outline
            this[OverlayBoaderOutline_Disable_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderOutline_Disable;
            this[OverlayBoaderOutline_Default_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderOutline_Default;
            this[OverlayBoaderOutline_MouseOver_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderOutline_MouseOver;
            this[OverlayBoaderOutline_Active_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderOutline_Active;
            // Overlay Mask Foreground
            this[OverlayMaskForeground_Disable_DictionaryKey] = ThemeSettingDataManager.OverlayMaskForeground_Disable;
            this[OverlayMaskForeground_Default_DictionaryKey] = ThemeSettingDataManager.OverlayMaskForeground_Default;
            this[OverlayMaskForeground_MouseOver_DictionaryKey] = ThemeSettingDataManager.OverlayMaskForeground_MouseOver;
            this[OverlayMaskForeground_Active_DictionaryKey] = ThemeSettingDataManager.OverlayMaskForeground_Active;
        }

        private void OnGlobalVariableChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName is null)
                return;
            // Get the new value using reflection
            var newValue = typeof(ThemeSettingDataManager).GetProperty(e.PropertyName)?.GetValue(null);
            if (newValue is not null 
                && ToDictionaryKey(e.PropertyName) is string dictionaryKey
                && string.IsNullOrEmpty(dictionaryKey) is false)
            {
                // Update the ResourceDictionary with the new value
                this[dictionaryKey] = newValue;
                // Force the UI to update
                //Application.Current.Resources[dictionaryKey] = newValue;
            }
        }

        #region Dictionary Key
        //To.
        private string ToDictionaryKey(string items)
        {

            switch (items)
            {
                //Theme
                case nameof(ThemeSettingDataManager.CurrentThemeName):
                    return CurrentThemeName_DictionaryKey;
                //FontSize
                case nameof(ThemeSettingDataManager.FontSize_Header1):
                    return FontSize_Header1_DictionaryKey;
                case nameof(ThemeSettingDataManager.FontSize_Header2):
                    return FontSize_Header2_DictionaryKey;
                case nameof(ThemeSettingDataManager.FontSize_Header3):
                    return FontSize_Header3_DictionaryKey;
                case nameof(ThemeSettingDataManager.FontSize_Header4):
                    return FontSize_Header4_DictionaryKey;
                case nameof(ThemeSettingDataManager.FontSize_Header5):
                    return FontSize_Header5_DictionaryKey;
                case nameof(ThemeSettingDataManager.FontSize_Header6):
                    return FontSize_Header6_DictionaryKey;
                case nameof(ThemeSettingDataManager.FontSize_Default):
                    return FontSize_Default_DictionaryKey;
                // Thickness
                //case nameof(ThemeSettingDataManager.Thickness_Default):
                //    return Thickness_Default_DictionaryKey;
                //case nameof(ThemeSettingDataManager.Thickness_Zero):
                //    return Thickness_Zero_DictionaryKey;
                // Default Brush
                case nameof(ThemeSettingDataManager.DefaultBrush_Foreground):
                    return DefaultBrush_Foreground_DictionaryKey;
                case nameof(ThemeSettingDataManager.DefaultBrush_Foreground_Disable):
                    return DefaultBrush_Foreground_Disable_DictionaryKey;
                case nameof(ThemeSettingDataManager.DefaultBrush_Background):
                    return DefaultBrush_Background_DictionaryKey;
                case nameof(ThemeSettingDataManager.DefaultBrush_Outline):
                    return DefaultBrush_Outline_DictionaryKey;
                case nameof(ThemeSettingDataManager.DefaultBrush_Line):
                    return DefaultBrush_Line_DictionaryKey;
                case nameof(ThemeSettingDataManager.DefaultBrush_Highlight):
                    return DefaultBrush_Highlight_DictionaryKey;
                case nameof(ThemeSettingDataManager.DefaultBrush_Selection):
                    return DefaultBrush_Selection_DictionaryKey;
                case nameof(ThemeSettingDataManager.DefaultBrush_Mask):
                    return DefaultBrush_Mask_DictionaryKey;
                // Overlay Boader Background
                case nameof(ThemeSettingDataManager.OverlayBoaderBackground_Disable):
                    return OverlayBoaderBackground_Disable_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayBoaderBackground_Default):
                    return OverlayBoaderBackground_Default_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayBoaderBackground_MouseOver):
                    return OverlayBoaderBackground_MouseOver_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayBoaderBackground_Active):
                    return OverlayBoaderBackground_Active_DictionaryKey;
                // Overlay Boader Outline
                case nameof(ThemeSettingDataManager.OverlayBoaderOutline_Disable):
                    return OverlayBoaderOutline_Disable_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayBoaderOutline_Default):
                    return OverlayBoaderOutline_Default_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayBoaderOutline_MouseOver):
                    return OverlayBoaderOutline_MouseOver_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayBoaderOutline_Active):
                    return OverlayBoaderOutline_Active_DictionaryKey;
                // Overlay Mask Foreground
                case nameof(ThemeSettingDataManager.OverlayMaskForeground_Disable):
                    return OverlayMaskForeground_Disable_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayMaskForeground_Default):
                    return OverlayMaskForeground_Default_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayMaskForeground_MouseOver):
                    return OverlayMaskForeground_MouseOver_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayMaskForeground_Active):
                    return OverlayMaskForeground_Active_DictionaryKey;
                // Default
                default:
                    break;
            }

            return "";
        }
        //Theme
        internal static string CurrentThemeName_DictionaryKey { get; } = $"GrayThemeUI.Internal.CurrentThemeName";
        //FontSize
        private static readonly string _fontSizeDictionaryKey = "GrayThemeUI.Internal.FontSize";
        internal static string FontSize_Header1_DictionaryKey { get; } = $"{_fontSizeDictionaryKey}.Header1";
        internal static string FontSize_Header2_DictionaryKey { get; } = $"{_fontSizeDictionaryKey}.Header2";
        internal static string FontSize_Header3_DictionaryKey { get; } = $"{_fontSizeDictionaryKey}.Header3";
        internal static string FontSize_Header4_DictionaryKey { get; } = $"{_fontSizeDictionaryKey}.Header4";
        internal static string FontSize_Header5_DictionaryKey { get; } = $"{_fontSizeDictionaryKey}.Header5";
        internal static string FontSize_Header6_DictionaryKey { get; } = $"{_fontSizeDictionaryKey}.Header6";
        internal static string FontSize_Default_DictionaryKey { get; } = $"{_fontSizeDictionaryKey}.Default";
        // Thickness
        internal static string Thickness_Default_DictionaryKey { get; } = $"GrayThemeUI.Internal.Thickness.Default";
        internal static string Thickness_Zero_DictionaryKey { get; } = $"GrayThemeUI.Internal.Thickness.Zero";
        //Default Brush
        private static readonly string _defaultBrushDictionaryKey = "GrayThemeUI.Internal.DefaultBrush";
        internal static string DefaultBrush_Foreground_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Foreground";
        internal static string DefaultBrush_Foreground_Disable_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Foreground.Disable";
        internal static string DefaultBrush_Background_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Background";
        internal static string DefaultBrush_Outline_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Outline";
        internal static string DefaultBrush_Line_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Line";
        internal static string DefaultBrush_Highlight_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Highlight";
        internal static string DefaultBrush_Selection_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Selection";
        internal static string DefaultBrush_Mask_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Mask";
        //Overlay Boader Background
        private static readonly string _overlayBoaderBackgroundDictionaryKey = "GrayThemeUI.Internal.OverlayBoader.Background";
        internal static string OverlayBoaderBackground_Disable_DictionaryKey { get; } = $"{_overlayBoaderBackgroundDictionaryKey}.Disable";
        internal static string OverlayBoaderBackground_Default_DictionaryKey { get; } = $"{_overlayBoaderBackgroundDictionaryKey}.Default";
        internal static string OverlayBoaderBackground_MouseOver_DictionaryKey { get; } = $"{_overlayBoaderBackgroundDictionaryKey}.MouseOver";
        internal static string OverlayBoaderBackground_Active_DictionaryKey { get; } = $"{_overlayBoaderBackgroundDictionaryKey}.Active";
        //Overlay Boader Outline
        private static readonly string _overlayBoaderOutlineDictionaryKey = "GrayThemeUI.Internal.OverlayBoader.Outline";
        internal static string OverlayBoaderOutline_Disable_DictionaryKey { get; } = $"{_overlayBoaderOutlineDictionaryKey}.Disable";
        internal static string OverlayBoaderOutline_Default_DictionaryKey { get; } = $"{_overlayBoaderOutlineDictionaryKey}.Default";
        internal static string OverlayBoaderOutline_MouseOver_DictionaryKey { get; } = $"{_overlayBoaderOutlineDictionaryKey}.MouseOver";
        internal static string OverlayBoaderOutline_Active_DictionaryKey { get; } = $"{_overlayBoaderOutlineDictionaryKey}.Active";
        //Overlay Mask Foreground
        private static readonly string _overlayMaskForegroundDictionaryKey = "GrayThemeUI.Internal.OverlayMask.Foreground";
        internal static string OverlayMaskForeground_Disable_DictionaryKey { get; } = $"{_overlayMaskForegroundDictionaryKey}.Disable";
        internal static string OverlayMaskForeground_Default_DictionaryKey { get; } = $"{_overlayMaskForegroundDictionaryKey}.Default";
        internal static string OverlayMaskForeground_MouseOver_DictionaryKey { get; } = $"{_overlayMaskForegroundDictionaryKey}.MouseOver";
        internal static string OverlayMaskForeground_Active_DictionaryKey { get; } = $"{_overlayMaskForegroundDictionaryKey}.Active";
        #endregion
    }
}
