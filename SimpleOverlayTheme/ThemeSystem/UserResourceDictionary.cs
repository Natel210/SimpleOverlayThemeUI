using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleOverlayTheme.ThemeSystem
{
    public class UserResourceDictionary : ResourceDictionary
    {
        public UserResourceDictionary()
        {
            ApplyThemeSettings();
            Manager.PropertyChanged += OnGlobalVariableChanged;
        }

        private void ApplyThemeSettings()
        {
            // Theme
            this[KeywordDictionary.ThemeSystemKey.CurrentThemeName] = Manager.CurrentThemeName;
            // Font Sizes
            this[KeywordDictionary.ThemeSystemKey.FontSize.Header1] = Manager.FontSize_Header1;
            this[KeywordDictionary.ThemeSystemKey.FontSize.Header2] = Manager.FontSize_Header2;
            this[KeywordDictionary.ThemeSystemKey.FontSize.Header3] = Manager.FontSize_Header3;
            this[KeywordDictionary.ThemeSystemKey.FontSize.Header4] = Manager.FontSize_Header4;
            this[KeywordDictionary.ThemeSystemKey.FontSize.Header5] = Manager.FontSize_Header5;
            this[KeywordDictionary.ThemeSystemKey.FontSize.Header6] = Manager.FontSize_Header6;
            this[KeywordDictionary.ThemeSystemKey.FontSize.Default] = Manager.FontSize_Default;
            // Thickness
            this[KeywordDictionary.ThemeSystemKey.DefaultThickness.Default] = new Thickness(1.0);
            this[KeywordDictionary.ThemeSystemKey.DefaultThickness.Zero] = new Thickness(0.0);
            // Default Brush
            this[KeywordDictionary.ThemeSystemKey.DefaultBrush.Foreground] = Manager.DefaultBrush_Foreground;
            this[KeywordDictionary.ThemeSystemKey.DefaultBrush.Foreground_Disable] = Manager.DefaultBrush_Foreground_Disable;
            this[KeywordDictionary.ThemeSystemKey.DefaultBrush.Background] = Manager.DefaultBrush_Background;
            this[KeywordDictionary.ThemeSystemKey.DefaultBrush.Outline] = Manager.DefaultBrush_Outline;
            this[KeywordDictionary.ThemeSystemKey.DefaultBrush.Line] = Manager.DefaultBrush_Line;
            this[KeywordDictionary.ThemeSystemKey.DefaultBrush.Highlight] = Manager.DefaultBrush_Highlight;
            this[KeywordDictionary.ThemeSystemKey.DefaultBrush.Selection] = Manager.DefaultBrush_Selection;
            this[KeywordDictionary.ThemeSystemKey.DefaultBrush.Mask] = Manager.DefaultBrush_Mask;
            // Overlay Boader Background
            this[KeywordDictionary.ThemeSystemKey.OverlayBoader.Background.Disable] = Manager.OverlayBoaderBackground_Disable;
            this[KeywordDictionary.ThemeSystemKey.OverlayBoader.Background.Default] = Manager.OverlayBoaderBackground_Default;
            this[KeywordDictionary.ThemeSystemKey.OverlayBoader.Background.MouseOver] = Manager.OverlayBoaderBackground_MouseOver;
            this[KeywordDictionary.ThemeSystemKey.OverlayBoader.Background.Active] = Manager.OverlayBoaderBackground_Active;
            // Overlay Boader Outline
            this[KeywordDictionary.ThemeSystemKey.OverlayBoader.Outline.Disable] = Manager.OverlayBoaderOutline_Disable;
            this[KeywordDictionary.ThemeSystemKey.OverlayBoader.Outline.Default] = Manager.OverlayBoaderOutline_Default;
            this[KeywordDictionary.ThemeSystemKey.OverlayBoader.Outline.MouseOver] = Manager.OverlayBoaderOutline_MouseOver;
            this[KeywordDictionary.ThemeSystemKey.OverlayBoader.Outline.Active] = Manager.OverlayBoaderOutline_Active;
            // Overlay Mask Foreground
            this[KeywordDictionary.ThemeSystemKey.OverlayMask.Foreground.Disable] = Manager.OverlayMaskForeground_Disable;
            this[KeywordDictionary.ThemeSystemKey.OverlayMask.Foreground.Default] = Manager.OverlayMaskForeground_Default;
            this[KeywordDictionary.ThemeSystemKey.OverlayMask.Foreground.MouseOver] = Manager.OverlayMaskForeground_MouseOver;
            this[KeywordDictionary.ThemeSystemKey.OverlayMask.Foreground.Active] = Manager.OverlayMaskForeground_Active;
        }

        private void OnGlobalVariableChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName is null)
                return;
            // Get the new value using reflection
            var newValue = typeof(Manager).GetProperty(e.PropertyName)?.GetValue(null);
            if (newValue is not null
                && Manager.PropertyNameToThemeSystemKey(e.PropertyName) is string dictionaryKey
                && string.IsNullOrEmpty(dictionaryKey) is false)
            {
                // Update the ResourceDictionary with the new value
                if (dictionaryKey == KeywordDictionary.ThemeSystemKey.OverlayBoader.Outline.Default)
                {
                    //int a = 0;
                }

                this[dictionaryKey] = newValue;
                // Force the UI to update
                //Application.Current.Resources[dictionaryKey] = newValue;
            }
        }
    }
}
