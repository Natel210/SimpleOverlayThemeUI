namespace SimpleOverlayTheme.Share.StringTable
{
    /// <summary></summary>
    static public class ThemeKey
    {
        /// <summary></summary>
        static public class Common
        {

            /// <summary></summary>
            static public readonly Item.ThemePair ThemeName
                = new($"{NamespacePrefix}.{nameof(ThemeName)}",
                    nameof(Common), nameof(ThemeName));

            /// <summary></summary>
            private const string NamespacePrefix
                = $"SimpleOverlayTheme.{nameof(ThemeKey)}.{nameof(Common)}";

        }

        /// <summary></summary>
        static public class FontSize
        {

            /// <summary></summary>
            static public readonly Item.ThemePair Default
                = new($"{NamespacePrefix}.{nameof(Default)}",
                    nameof(ColorPalette), nameof(Default));

            /// <summary></summary>
            static public readonly Item.ThemePair Header1
                = new($"{NamespacePrefix}.{nameof(Header1)}",
                    nameof(ColorPalette), nameof(Header1));

            /// <summary></summary>
            static public readonly Item.ThemePair Header2
                = new($"{NamespacePrefix}.{nameof(Header2)}",
                    nameof(ColorPalette), nameof(Header2));

            /// <summary></summary>
            static public readonly Item.ThemePair Header3
                = new($"{NamespacePrefix}.{nameof(Header3)}",
                    nameof(ColorPalette), nameof(Header3));

            /// <summary></summary>
            static public readonly Item.ThemePair Header4
                = new($"{NamespacePrefix}.{nameof(Header4)}",
                    nameof(ColorPalette), nameof(Header4));

            /// <summary></summary>
            static public readonly Item.ThemePair Header5
                = new($"{NamespacePrefix}.{nameof(Header5)}",
                    nameof(ColorPalette), nameof(Header5));

            /// <summary></summary>
            static public readonly Item.ThemePair Header6
                = new($"{NamespacePrefix}.{nameof(Header6)}",
                    nameof(ColorPalette), nameof(Header6));

            /// <summary></summary>
            private const string NamespacePrefix
                = $"SimpleOverlayTheme.{nameof(ThemeKey)}.{nameof(FontSize)}";

        }

        /// <summary></summary>
        static public class Thickness
        {

            /// <summary></summary>
            static public readonly Item.ThemePair Default
                = new($"{NamespacePrefix}.{nameof(Default)}",
                    nameof(Thickness), nameof(Default));

            /// <summary></summary>
            private const string NamespacePrefix
                = $"SimpleOverlayTheme.{nameof(ThemeKey)}.{nameof(Thickness)}";

        }

        /// <summary></summary>
        static public class ColorPalette
        {

            /// <summary></summary>
            static public readonly Item.ThemePair Background
                = new($"{NamespacePrefix}.{nameof(Background)}",
                    nameof(ColorPalette), nameof(Background));

            /// <summary></summary>
            static public readonly Item.ThemePair Foreground
                = new($"{NamespacePrefix}.{nameof(Foreground)}",
                    nameof(ColorPalette), nameof(Foreground));

            /// <summary></summary>
            static public readonly Item.ThemePair Foreground_Disable
                = new($"{NamespacePrefix}.{nameof(Foreground_Disable)}",
                    nameof(ColorPalette), nameof(Foreground_Disable));

            /// <summary></summary>
            static public readonly Item.ThemePair Highlight
                = new($"{NamespacePrefix}.{nameof(Highlight)}",
                    nameof(ColorPalette), nameof(Highlight));

            /// <summary></summary>
            static public readonly Item.ThemePair Mask
                = new($"{NamespacePrefix}.{nameof(Mask)}",
                    nameof(ColorPalette), nameof(Mask));

            /// <summary></summary>
            static public readonly Item.ThemePair Outline
                = new($"{NamespacePrefix}.{nameof(Outline)}",
                    nameof(ColorPalette), nameof(Outline));

            /// <summary></summary>
            static public readonly Item.ThemePair Selection
                = new($"{NamespacePrefix}.{nameof(Selection)}",
                    nameof(ColorPalette), nameof(Selection));

            /// <summary></summary>
            private const string NamespacePrefix
                = $"SimpleOverlayTheme.{nameof(ThemeKey)}.{nameof(ColorPalette)}";

        }

        /// <summary></summary>
        static public class Overlay
        {
            /// <summary></summary>
            static public class Background
            {

                /// <summary></summary>
                static public readonly Item.ThemePair Active
                    = new($"{NamespacePrefix}.{nameof(Active)}",
                        Section, nameof(Active));

                /// <summary></summary>
                static public readonly Item.ThemePair Default
                    = new($"{NamespacePrefix}.{nameof(Default)}",
                        Section, nameof(Default));

                /// <summary></summary>
                static public readonly Item.ThemePair Disable
                    = new($"{NamespacePrefix}.{nameof(Disable)}",
                        Section, nameof(Disable));

                /// <summary></summary>
                static public readonly Item.ThemePair Mouseover
                    = new($"{NamespacePrefix}.{nameof(Mouseover)}",
                        Section, nameof(Mouseover));

                /// <summary></summary>
                private const string NamespacePrefix
                    = $"SimpleOverlayTheme.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Background)}";

                private const string Section
                    = $"{nameof(Overlay)}.{nameof(Background)}";

            }

            /// <summary></summary>
            static public class Outline
            {

                /// <summary></summary>
                static public readonly Item.ThemePair Active
                    = new($"{NamespacePrefix}.{nameof(Active)}",
                        Section, nameof(Active));

                /// <summary></summary>
                static public readonly Item.ThemePair Default
                    = new($"{NamespacePrefix}.{nameof(Default)}",
                        Section, nameof(Default));

                /// <summary></summary>
                static public readonly Item.ThemePair Disable
                    = new($"{NamespacePrefix}.{nameof(Disable)}",
                        Section, nameof(Disable));

                /// <summary></summary>
                static public readonly Item.ThemePair Mouseover
                    = new($"{NamespacePrefix}.{nameof(Mouseover)}",
                        Section, nameof(Mouseover));

                /// <summary></summary>
                private const string NamespacePrefix
                    = $"SimpleOverlayTheme.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Outline)}";

                private const string Section
                    = $"{nameof(Overlay)}.{nameof(Outline)}";

            }



            /// <summary></summary>
            static public class Mask
            {

                /// <summary></summary>
                static public class Background
                {

                    /// <summary></summary>
                    static public readonly Item.ThemePair Active
                        = new($"{NamespacePrefix}.{nameof(Active)}",
                            Section, nameof(Active));

                    /// <summary></summary>
                    static public readonly Item.ThemePair Default
                        = new($"{NamespacePrefix}.{nameof(Default)}",
                            Section, nameof(Default));

                    /// <summary></summary>
                    static public readonly Item.ThemePair Disable
                        = new($"{NamespacePrefix}.{nameof(Disable)}",
                            Section, nameof(Disable));

                    /// <summary></summary>
                    static public readonly Item.ThemePair Mouseover
                        = new($"{NamespacePrefix}.{nameof(Mouseover)}",
                            Section, nameof(Mouseover));

                    /// <summary></summary>
                    private const string NamespacePrefix
                        = $"SimpleOverlayTheme.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Mask)}.{nameof(Background)}";

                    /// <summary></summary>
                    private const string Section
                        = $"{nameof(Overlay)}.{nameof(Mask)}.{nameof(Background)}";

                }
            }
        }
    }
}
