using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SimpleOverlayTheme.KeywordDictionary.ThemeSystemKey.OverlayBoader;

namespace SimpleOverlayTheme
{
    internal static class KeywordDictionary
    {
        internal const string App = "SimpleOverlayTheme";

        internal static class ThemeSystemKey
        {
            private const string ThemeSystemKeyName = $"{App}";
            internal const string CurrentThemeName = $"{ThemeSystemKeyName}.{nameof(CurrentThemeName)}";

            internal static class FontSize
            {
                internal const string Header1 = $"{ThemeSystemKeyName}.{nameof(FontSize)}.{nameof(Header1)}";
                internal const string Header2 = $"{ThemeSystemKeyName}.{nameof(FontSize)}.{nameof(Header2)}";
                internal const string Header3 = $"{ThemeSystemKeyName}.{nameof(FontSize)}.{nameof(Header3)}";
                internal const string Header4 = $"{ThemeSystemKeyName}.{nameof(FontSize)}.{nameof(Header4)}";
                internal const string Header5 = $"{ThemeSystemKeyName}.{nameof(FontSize)}.{nameof(Header5)}";
                internal const string Header6 = $"{ThemeSystemKeyName}.{nameof(FontSize)}.{nameof(Header6)}";
                internal const string Default = $"{ThemeSystemKeyName}.{nameof(FontSize)}.{nameof(Default)}";
            }

            internal static class DefaultThickness
            {
                internal const string Default = $"{ThemeSystemKeyName}.{nameof(DefaultThickness)}.{nameof(Default)}";
                internal const string Zero = $"{ThemeSystemKeyName}.{nameof(DefaultThickness)}.{nameof(Zero)}";
            }

            internal static class DefaultBrush
            {
                internal const string Foreground = $"{ThemeSystemKeyName}.{nameof(DefaultBrush)}.{nameof(Foreground)}";
                internal const string Foreground_Disable = $"{ThemeSystemKeyName}.{nameof(DefaultBrush)}.{nameof(Foreground_Disable)}";
                internal const string Background = $"{ThemeSystemKeyName}.{nameof(DefaultBrush)}.{nameof(Background)}";
                internal const string Outline = $"{ThemeSystemKeyName}.{nameof(DefaultBrush)}.{nameof(Outline)}";
                internal const string Line = $"{ThemeSystemKeyName}.{nameof(DefaultBrush)}.{nameof(Line)}";
                internal const string Highlight = $"{ThemeSystemKeyName}.{nameof(DefaultBrush)}.{nameof(Highlight)}";
                internal const string Selection = $"{ThemeSystemKeyName}.{nameof(DefaultBrush)}.{nameof(Selection)}";
                internal const string Mask = $"{ThemeSystemKeyName}.{nameof(DefaultBrush)}.{nameof(Mask)}";
            }


            internal static class OverlayBoader
            {
                internal static class Background
                {
                    internal const string Disable = $"{ThemeSystemKeyName}.{nameof(OverlayBoader)}.{nameof(Background)}.{nameof(Disable)}";
                    internal const string Default = $"{ThemeSystemKeyName}.{nameof(OverlayBoader)}.{nameof(Background)}.{nameof(Default)}";
                    internal const string MouseOver = $"{ThemeSystemKeyName}.{nameof(OverlayBoader)}.{nameof(Background)}.{nameof(MouseOver)}";
                    internal const string Active = $"{ThemeSystemKeyName}.{nameof(OverlayBoader)}.{nameof(Background)}.{nameof(Active)}";
                }

                internal static class Outline
                {
                    internal const string Disable = $"{ThemeSystemKeyName}.{nameof(OverlayBoader)}.{nameof(Outline)}.{nameof(Disable)}";
                    internal const string Default = $"{ThemeSystemKeyName}.{nameof(OverlayBoader)}.{nameof(Outline)}.{nameof(Default)}";
                    internal const string MouseOver = $"{ThemeSystemKeyName}.{nameof(OverlayBoader)}.{nameof(Outline)}.{nameof(MouseOver)}";
                    internal const string Active = $"{ThemeSystemKeyName}.{nameof(OverlayBoader)}.{nameof(Outline)}.{nameof(Active)}";
                }
            }

            internal static class OverlayMask
            {
                internal static class Foreground
                {
                    internal const string Disable = $"{ThemeSystemKeyName}.{nameof(OverlayMask)}.{nameof(Foreground)}.{nameof(Disable)}";
                    internal const string Default = $"{ThemeSystemKeyName}.{nameof(OverlayMask)}.{nameof(Foreground)}.{nameof(Default)}";
                    internal const string MouseOver = $"{ThemeSystemKeyName}.{nameof(OverlayMask)}.{nameof(Foreground)}.{nameof(MouseOver)}";
                    internal const string Active = $"{ThemeSystemKeyName}.{nameof(OverlayMask)}.{nameof(Foreground)}.{nameof(Active)}";
                }
            }

        }

        internal static class CategoryKey
        {
            internal const string Overlay = $"{App}.{nameof(Overlay)}";
            internal const string OverlayBackground = $"{Overlay}.Background";
            internal const string OverlayMask = $"{Overlay}.Mask";
            internal const string OverlayCheckedBackground = $"{OverlayBackground}.Background";
            
            internal const string Mask = $"{App}.{nameof(Mask)}";
            internal const string Func = $"{App}.{nameof(Func)}";
        }

    }
}
