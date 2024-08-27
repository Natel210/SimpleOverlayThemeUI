using GrayThemeUI.Theme;
using System.ComponentModel;
using System.Windows;
namespace GrayThemeUI.Theme
{
    public class ThemeSetting : ResourceDictionary
    {
        public ThemeSetting()
        {
            this["GrayThemeUI.Internal.FontSize.Header1"] = ThemeSettingDataManager.FontSize_Header1;
            this["GrayThemeUI.Internal.FontSize.Header2"] = ThemeSettingDataManager.FontSize_Header2;
            this["GrayThemeUI.Internal.FontSize.Header3"] = ThemeSettingDataManager.FontSize_Header3;
            this["GrayThemeUI.Internal.FontSize.Header4"] = ThemeSettingDataManager.FontSize_Header4;
            this["GrayThemeUI.Internal.FontSize.Header5"] = ThemeSettingDataManager.FontSize_Header5;
            this["GrayThemeUI.Internal.FontSize.Header6"] = ThemeSettingDataManager.FontSize_Header6;
            this["GrayThemeUI.Internal.FontSize.Default"] = ThemeSettingDataManager.FontSize_Default;

            this["GrayThemeUI.Internal.Thickness.Default"] = new Thickness(1.0); // 만약에 받아야한다면 추가할예정
            this["GrayThemeUI.Internal.Thickness.Zero"] = new Thickness(0.0);

            this["GrayThemeUI.Internal.DefaultBrush.Foreground"] = ThemeSettingDataManager.DefaultBrush_Foreground;
            this["GrayThemeUI.Internal.DefaultBrush.Foreground.Disable"] = ThemeSettingDataManager.DefaultBrush_Foreground_Disable;
            this["GrayThemeUI.Internal.DefaultBrush.Background"] = ThemeSettingDataManager.DefaultBrush_Background;
            this["GrayThemeUI.Internal.DefaultBrush.Line"] = ThemeSettingDataManager.DefaultBrush_Line;
            this["GrayThemeUI.Internal.DefaultBrush.Highlight"] = ThemeSettingDataManager.DefaultBrush_Highlight;
            this["GrayThemeUI.Internal.DefaultBrush.Selection"] = ThemeSettingDataManager.DefaultBrush_Selection;
            this["GrayThemeUI.Internal.DefaultBrush.Mask"] = ThemeSettingDataManager.DefaultBrush_Mask;

            this["GrayThemeUI.Internal.OverlayBoader.Background.Disable"] = ThemeSettingDataManager.OverlayBoaderBackground_Disable;
            this["GrayThemeUI.Internal.OverlayBoader.Background.Default"] = ThemeSettingDataManager.OverlayBoaderBackground_Default;
            this["GrayThemeUI.Internal.OverlayBoader.Background.MouseOver"] = ThemeSettingDataManager.OverlayBoaderBackground_MouseOver;
            this["GrayThemeUI.Internal.OverlayBoader.Background.Active"] = ThemeSettingDataManager.OverlayBoaderBackground_Active;

            this["GrayThemeUI.Internal.OverlayBoader.Outline.Disable"] = ThemeSettingDataManager.OverlayBoaderOutline_Disable;
            this["GrayThemeUI.Internal.OverlayBoader.Outline.Default"] = ThemeSettingDataManager.OverlayBoaderOutline_Default;
            this["GrayThemeUI.Internal.OverlayBoader.Outline.MouseOver"] = ThemeSettingDataManager.OverlayBoaderOutline_MouseOver;
            this["GrayThemeUI.Internal.OverlayBoader.Outline.Active"] = ThemeSettingDataManager.OverlayBoaderOutline_Active;

            this["GrayThemeUI.Internal.OverlayMask.Foreground.Disable"] = ThemeSettingDataManager.OverlayMaskForeground_Disable;
            this["GrayThemeUI.Internal.OverlayMask.Foreground.Default"] = ThemeSettingDataManager.OverlayMaskForeground_Default;
            this["GrayThemeUI.Internal.OverlayMask.Foreground.MouseOver"] = ThemeSettingDataManager.OverlayMaskForeground_MouseOver;
            this["GrayThemeUI.Internal.OverlayMask.Foreground.Active"] = ThemeSettingDataManager.OverlayMaskForeground_Active;

            ThemeSettingDataManager.PropertyChanged += OnGlobalVariableChanged;
        }

        private void OnGlobalVariableChanged(object? sender, PropertyChangedEventArgs e)
        {
#pragma warning disable CS8604 // 가능한 null 참조 인수입니다.
            this[e.PropertyName] = typeof(ThemeSetting).GetProperty(e.PropertyName)?.GetValue(null);
#pragma warning restore CS8604 // 가능한 null 참조 인수입니다.
        }
    }
}
