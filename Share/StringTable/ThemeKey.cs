namespace SimpleOverlayTheme.Share.StringTable
{
    /// <summary>
    /// A central repository of shared theme keys for the application. <br/>
    /// Each nested static class organizes <see cref="Item.ThemePair"/> instances
    /// that map XAML resource names to corresponding INI section/key pairs. <br/>
    /// This enables consistent and configurable UI theming.
    /// </summary>
    static public class ThemeKey
    {
        /// <summary> Common theme keys used across the application. </summary>
        static public class Common
        {

            /// <summary> The theme display name identifier. </summary>
            static public readonly Item.ThemePair ThemeName
                = new($"{NamespacePrefix}.{nameof(ThemeName)}",
                    nameof(Common), nameof(ThemeName));

            /// <summary> The namespace prefix used for theme keys in this section. </summary>
            private const string NamespacePrefix
                = $"SimpleOverlayTheme.{nameof(ThemeKey)}.{nameof(Common)}";

        }

        /// <summary> Theme keys for font sizes used in various heading levels. </summary>
        static public class FontSize
        {

            /// <summary>Font size for default text.</summary>
            static public readonly Item.ThemePair Default
                = new($"{NamespacePrefix}.{nameof(Default)}",
                    nameof(ColorPalette), nameof(Default));

            /// <summary>Font size for Header 1.</summary>
            static public readonly Item.ThemePair Header1
                = new($"{NamespacePrefix}.{nameof(Header1)}",
                    nameof(ColorPalette), nameof(Header1));

            /// <summary>Font size for Header 2.</summary>
            static public readonly Item.ThemePair Header2
                = new($"{NamespacePrefix}.{nameof(Header2)}",
                    nameof(ColorPalette), nameof(Header2));

            /// <summary>Font size for Header 3.</summary>
            static public readonly Item.ThemePair Header3
                = new($"{NamespacePrefix}.{nameof(Header3)}",
                    nameof(ColorPalette), nameof(Header3));

            /// <summary>Font size for Header 4.</summary>
            static public readonly Item.ThemePair Header4
                = new($"{NamespacePrefix}.{nameof(Header4)}",
                    nameof(ColorPalette), nameof(Header4));

            /// <summary>Font size for Header 5.</summary>
            static public readonly Item.ThemePair Header5
                = new($"{NamespacePrefix}.{nameof(Header5)}",
                    nameof(ColorPalette), nameof(Header5));

            /// <summary>Font size for Header 6.</summary>
            static public readonly Item.ThemePair Header6
                = new($"{NamespacePrefix}.{nameof(Header6)}",
                    nameof(ColorPalette), nameof(Header6));

            /// <summary> The namespace prefix used for font size keys. </summary>
            private const string NamespacePrefix
                = $"SimpleOverlayTheme.{nameof(ThemeKey)}.{nameof(FontSize)}";

        }

        /// <summary> Theme keys for thickness-related values such as padding or margins. </summary>
        static public class Thickness
        {

            /// <summary>Default thickness value.</summary>
            static public readonly Item.ThemePair Default
                = new($"{NamespacePrefix}.{nameof(Default)}",
                    nameof(Thickness), nameof(Default));

            /// <summary> The namespace prefix used for thickness keys. </summary>
            private const string NamespacePrefix
                = $"SimpleOverlayTheme.{nameof(ThemeKey)}.{nameof(Thickness)}";

        }

        /// <summary> Theme keys for standard UI color palette definitions. </summary>
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

        /// <summary> Theme keys related to overlay states like background and outline. </summary>
        static public class Overlay
        {
            /// <summary> Background overlay colors for different UI states. </summary>
            static public class Background
            {

                /// <summary>
                /// Background overlay color used when the element is in the active state.
                /// </summary>
                static public readonly Item.ThemePair Active
                    = new($"{NamespacePrefix}.{nameof(Active)}",
                        Section, nameof(Active));

                /// <summary>
                /// Background overlay color used in the default (idle) state.
                /// </summary>
                static public readonly Item.ThemePair Default
                    = new($"{NamespacePrefix}.{nameof(Default)}",
                        Section, nameof(Default));

                /// <summary>
                /// Background overlay color used when the element is disabled.
                /// </summary>
                static public readonly Item.ThemePair Disable
                    = new($"{NamespacePrefix}.{nameof(Disable)}",
                        Section, nameof(Disable));

                /// <summary>
                /// Background overlay color used when the mouse is hovering over the element.
                /// </summary>
                static public readonly Item.ThemePair Mouseover
                    = new($"{NamespacePrefix}.{nameof(Mouseover)}",
                        Section, nameof(Mouseover));

                /// <summary>
                /// The fully qualified XAML resource key prefix for these background overlay entries.
                /// </summary>
                private const string NamespacePrefix
                    = $"SimpleOverlayTheme.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Background)}";

                /// <summary>
                /// The INI section name corresponding to these background overlay theme values.
                /// </summary>
                private const string Section
                    = $"{nameof(Overlay)}.{nameof(Background)}";

            }

            /// <summary> Outline overlay colors for different UI states. </summary>
            static public class Outline
            {

                /// <summary> Outline color used when the element is in the active state. </summary>
                static public readonly Item.ThemePair Active
                    = new($"{NamespacePrefix}.{nameof(Active)}",
                        Section, nameof(Active));

                /// <summary> Outline color used in the default (idle) state. </summary>
                static public readonly Item.ThemePair Default
                    = new($"{NamespacePrefix}.{nameof(Default)}",
                        Section, nameof(Default));

                /// <summary> Outline color used when the element is disabled. </summary>
                static public readonly Item.ThemePair Disable
                    = new($"{NamespacePrefix}.{nameof(Disable)}",
                        Section, nameof(Disable));

                /// <summary> Outline color used when the mouse is hovering over the element. </summary>
                static public readonly Item.ThemePair Mouseover
                    = new($"{NamespacePrefix}.{nameof(Mouseover)}",
                        Section, nameof(Mouseover));

                /// <summary> The XAML resource namespace prefix for the outline overlay color keys. </summary>
                private const string NamespacePrefix
                    = $"SimpleOverlayTheme.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Outline)}";

                /// <summary> The INI section name for outline overlay theme entries. </summary>
                private const string Section
                    = $"{nameof(Overlay)}.{nameof(Outline)}";

            }



            /// <summary> Image masks used for overlay background rendering. </summary>
            static public class Mask
            {

                /// <summary> Background image mask overlays for different states. </summary>
                static public class Background
                {

                    /// <summary> Image mask used when the overlay is in the active state. </summary>
                    static public readonly Item.ThemePair Active
                        = new($"{NamespacePrefix}.{nameof(Active)}",
                            Section, nameof(Active));

                    /// <summary> Image mask used in the default (idle) state. </summary>
                    static public readonly Item.ThemePair Default
                        = new($"{NamespacePrefix}.{nameof(Default)}",
                            Section, nameof(Default));

                    /// <summary> Image mask used when the element is disabled. </summary>
                    static public readonly Item.ThemePair Disable
                        = new($"{NamespacePrefix}.{nameof(Disable)}",
                            Section, nameof(Disable));

                    /// <summary> Image mask used when the mouse is hovering over the element. </summary>
                    static public readonly Item.ThemePair Mouseover
                        = new($"{NamespacePrefix}.{nameof(Mouseover)}",
                            Section, nameof(Mouseover));

                    /// <summary> The fully qualified XAML resource key prefix for these background overlay masks. </summary>
                    private const string NamespacePrefix
                        = $"SimpleOverlayTheme.{nameof(ThemeKey)}.{nameof(Overlay)}.{nameof(Mask)}.{nameof(Background)}";

                    /// <summary> The INI section name representing this group of background mask settings. </summary>
                    private const string Section
                        = $"{nameof(Overlay)}.{nameof(Mask)}.{nameof(Background)}";

                }
            }
        }
    }
}
