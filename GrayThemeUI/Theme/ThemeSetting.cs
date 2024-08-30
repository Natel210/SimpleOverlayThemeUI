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
            this[ThemeSettingData.CurrentThemeName_DictionaryKey] = ThemeSettingDataManager.CurrentThemeName;
            // Font Sizes
            this[ThemeSettingData.FontSize_Header1_DictionaryKey] = ThemeSettingDataManager.FontSize_Header1;
            this[ThemeSettingData.FontSize_Header2_DictionaryKey] = ThemeSettingDataManager.FontSize_Header2;
            this[ThemeSettingData.FontSize_Header3_DictionaryKey] = ThemeSettingDataManager.FontSize_Header3;
            this[ThemeSettingData.FontSize_Header4_DictionaryKey] = ThemeSettingDataManager.FontSize_Header4;
            this[ThemeSettingData.FontSize_Header5_DictionaryKey] = ThemeSettingDataManager.FontSize_Header5;
            this[ThemeSettingData.FontSize_Header6_DictionaryKey] = ThemeSettingDataManager.FontSize_Header6;
            this[ThemeSettingData.FontSize_Default_DictionaryKey] = ThemeSettingDataManager.FontSize_Default;
            // Thickness
            this[ThemeSettingData.Thickness_Default_DictionaryKey] = new Thickness(1.0);
            this[ThemeSettingData.Thickness_Zero_DictionaryKey] = new Thickness(0.0);
            // Default Brush
            this[ThemeSettingData.DefaultBrush_Foreground_DictionaryKey] = ThemeSettingDataManager.DefaultBrush_Foreground;
            this[ThemeSettingData.DefaultBrush_Foreground_Disable_DictionaryKey] = ThemeSettingDataManager.DefaultBrush_Foreground_Disable;
            this[ThemeSettingData.DefaultBrush_Background_DictionaryKey] = ThemeSettingDataManager.DefaultBrush_Background;
            this[ThemeSettingData.DefaultBrush_Outline_DictionaryKey] = ThemeSettingDataManager.DefaultBrush_Outline;
            this[ThemeSettingData.DefaultBrush_Line_DictionaryKey] = ThemeSettingDataManager.DefaultBrush_Line;
            this[ThemeSettingData.DefaultBrush_Highlight_DictionaryKey] = ThemeSettingDataManager.DefaultBrush_Highlight;
            this[ThemeSettingData.DefaultBrush_Selection_DictionaryKey] = ThemeSettingDataManager.DefaultBrush_Selection;
            this[ThemeSettingData.DefaultBrush_Mask_DictionaryKey] = ThemeSettingDataManager.DefaultBrush_Mask;
            // Overlay Boader Background
            this[ThemeSettingData.OverlayBoaderBackground_Disable_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderBackground_Disable;
            this[ThemeSettingData.OverlayBoaderBackground_Default_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderBackground_Default;
            this[ThemeSettingData.OverlayBoaderBackground_MouseOver_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderBackground_MouseOver;
            this[ThemeSettingData.OverlayBoaderBackground_Active_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderBackground_Active;
            // Overlay Boader Outline
            this[ThemeSettingData.OverlayBoaderOutline_Disable_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderOutline_Disable;
            this[ThemeSettingData.OverlayBoaderOutline_Default_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderOutline_Default;
            this[ThemeSettingData.OverlayBoaderOutline_MouseOver_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderOutline_MouseOver;
            this[ThemeSettingData.OverlayBoaderOutline_Active_DictionaryKey] = ThemeSettingDataManager.OverlayBoaderOutline_Active;
            // Overlay Mask Foreground
            this[ThemeSettingData.OverlayMaskForeground_Disable_DictionaryKey] = ThemeSettingDataManager.OverlayMaskForeground_Disable;
            this[ThemeSettingData.OverlayMaskForeground_Default_DictionaryKey] = ThemeSettingDataManager.OverlayMaskForeground_Default;
            this[ThemeSettingData.OverlayMaskForeground_MouseOver_DictionaryKey] = ThemeSettingDataManager.OverlayMaskForeground_MouseOver;
            this[ThemeSettingData.OverlayMaskForeground_Active_DictionaryKey] = ThemeSettingDataManager.OverlayMaskForeground_Active;
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

        //To.
        private string ToDictionaryKey(string items)
        {

            switch (items)
            {
                //Theme
                case nameof(ThemeSettingDataManager.CurrentThemeName):
                    return ThemeSettingData.CurrentThemeName_DictionaryKey;
                //FontSize
                case nameof(ThemeSettingDataManager.FontSize_Header1):
                    return ThemeSettingData.FontSize_Header1_DictionaryKey;
                case nameof(ThemeSettingDataManager.FontSize_Header2):
                    return ThemeSettingData.FontSize_Header2_DictionaryKey;
                case nameof(ThemeSettingDataManager.FontSize_Header3):
                    return ThemeSettingData.FontSize_Header3_DictionaryKey;
                case nameof(ThemeSettingDataManager.FontSize_Header4):
                    return ThemeSettingData.FontSize_Header4_DictionaryKey;
                case nameof(ThemeSettingDataManager.FontSize_Header5):
                    return ThemeSettingData.FontSize_Header5_DictionaryKey;
                case nameof(ThemeSettingDataManager.FontSize_Header6):
                    return ThemeSettingData.FontSize_Header6_DictionaryKey;
                case nameof(ThemeSettingDataManager.FontSize_Default):
                    return ThemeSettingData.FontSize_Default_DictionaryKey;
                // Thickness
                //case nameof(ThemeSettingDataManager.Thickness_Default):
                //    return Thickness_Default_DictionaryKey;
                //case nameof(ThemeSettingDataManager.Thickness_Zero):
                //    return Thickness_Zero_DictionaryKey;
                // Default Brush
                case nameof(ThemeSettingDataManager.DefaultBrush_Foreground):
                    return ThemeSettingData.DefaultBrush_Foreground_DictionaryKey;
                case nameof(ThemeSettingDataManager.DefaultBrush_Foreground_Disable):
                    return ThemeSettingData.DefaultBrush_Foreground_Disable_DictionaryKey;
                case nameof(ThemeSettingDataManager.DefaultBrush_Background):
                    return ThemeSettingData.DefaultBrush_Background_DictionaryKey;
                case nameof(ThemeSettingDataManager.DefaultBrush_Outline):
                    return ThemeSettingData.DefaultBrush_Outline_DictionaryKey;
                case nameof(ThemeSettingDataManager.DefaultBrush_Line):
                    return ThemeSettingData.DefaultBrush_Line_DictionaryKey;
                case nameof(ThemeSettingDataManager.DefaultBrush_Highlight):
                    return ThemeSettingData.DefaultBrush_Highlight_DictionaryKey;
                case nameof(ThemeSettingDataManager.DefaultBrush_Selection):
                    return ThemeSettingData.DefaultBrush_Selection_DictionaryKey;
                case nameof(ThemeSettingDataManager.DefaultBrush_Mask):
                    return ThemeSettingData.DefaultBrush_Mask_DictionaryKey;
                // Overlay Boader Background
                case nameof(ThemeSettingDataManager.OverlayBoaderBackground_Disable):
                    return ThemeSettingData.OverlayBoaderBackground_Disable_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayBoaderBackground_Default):
                    return ThemeSettingData.OverlayBoaderBackground_Default_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayBoaderBackground_MouseOver):
                    return ThemeSettingData.OverlayBoaderBackground_MouseOver_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayBoaderBackground_Active):
                    return ThemeSettingData.OverlayBoaderBackground_Active_DictionaryKey;
                // Overlay Boader Outline
                case nameof(ThemeSettingDataManager.OverlayBoaderOutline_Disable):
                    return ThemeSettingData.OverlayBoaderOutline_Disable_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayBoaderOutline_Default):
                    return ThemeSettingData.OverlayBoaderOutline_Default_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayBoaderOutline_MouseOver):
                    return ThemeSettingData.OverlayBoaderOutline_MouseOver_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayBoaderOutline_Active):
                    return ThemeSettingData.OverlayBoaderOutline_Active_DictionaryKey;
                // Overlay Mask Foreground
                case nameof(ThemeSettingDataManager.OverlayMaskForeground_Disable):
                    return ThemeSettingData.OverlayMaskForeground_Disable_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayMaskForeground_Default):
                    return ThemeSettingData.OverlayMaskForeground_Default_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayMaskForeground_MouseOver):
                    return ThemeSettingData.OverlayMaskForeground_MouseOver_DictionaryKey;
                case nameof(ThemeSettingDataManager.OverlayMaskForeground_Active):
                    return ThemeSettingData.OverlayMaskForeground_Active_DictionaryKey;
                // Default
                default:
                    break;
            }

            return "";
        }

    }
}
