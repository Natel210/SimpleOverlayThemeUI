using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOverlayTheme.Share.StringTable
{
    static public class ThemeKey
    {
        public const string AssemblyName = "SimpleOverlayTheme";

        public const string ThemeName = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(ThemeName)}";

        static public class ColorPalette
        {
            public const string Background = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(ColorPalette)}.{nameof(Background)}";
            public const string Foreground = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(ColorPalette)}.{nameof(Foreground)}";
            public const string Foreground_Disable = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(ColorPalette)}.{nameof(Foreground_Disable)}";
            public const string Highlight = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(ColorPalette)}.{nameof(Highlight)}";
            public const string Line = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(ColorPalette)}.{nameof(Line)}";
            public const string Mask = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(ColorPalette)}.{nameof(Mask)}";
            public const string Outline = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(ColorPalette)}.{nameof(Outline)}";
            public const string Selection = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(ColorPalette)}.{nameof(Selection)}";
        }

        static public class FontSize
        {
            public const string Default = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(FontSize)}.{nameof(Default)}";
            public const string Header1 = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(FontSize)}.{nameof(Header1)}";
            public const string Header2 = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(FontSize)}.{nameof(Header2)}";
            public const string Header3 = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(FontSize)}.{nameof(Header3)}";
            public const string Header4 = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(FontSize)}.{nameof(Header4)}";
            public const string Header5 = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(FontSize)}.{nameof(Header5)}";
            public const string Header6 = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(FontSize)}.{nameof(Header6)}";
        }

        static public class Tickness
        {
            public const string Default = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(Tickness)}.{nameof(Default)}";
            public const string Zero = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(Tickness)}.{nameof(Zero)}";
        }


        static public class Overlay
        {
            static public class Border
            {
                static public class Background
                {
                    public const string Active = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Border)}.{nameof(Background)}.{nameof(Active)}";
                    public const string Default = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Border)}.{nameof(Background)}.{nameof(Default)}";
                    public const string Disable = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Border)}.{nameof(Background)}.{nameof(Disable)}";
                    public const string MouseOver = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Border)}.{nameof(Background)}.{nameof(MouseOver)}";
                }

                static public class Outline
                {
                    public const string Active = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Border)}.{nameof(Outline)}.{nameof(Active)}";
                    public const string Default = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Border)}.{nameof(Outline)}.{nameof(Default)}";
                    public const string Disable = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Border)}.{nameof(Outline)}.{nameof(Disable)}";
                    public const string MouseOver = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Border)}.{nameof(Outline)}.{nameof(MouseOver)}";
                }

            }

            static public class Mask
            {
                static public class Foreground
                {
                    public const string Active = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Mask)}.{nameof(Foreground)}.{nameof(Active)}";
                    public const string Default = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Mask)}.{nameof(Foreground)}.{nameof(Default)}";
                    public const string Disable = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Mask)}.{nameof(Foreground)}.{nameof(Disable)}";
                    public const string MouseOver = $"{AssemblyName}.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Mask)}.{nameof(Foreground)}.{nameof(MouseOver)}";
                }
            }
        }
    }
}
