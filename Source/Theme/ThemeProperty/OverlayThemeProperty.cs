using SimpleFileIO.State.Ini;
using SimpleOverlayTheme.Share.StringTable;
using SimpleOverlayTheme.Theme.Interface;
using System.Windows.Media;

namespace SimpleOverlayTheme.Theme.ThemeProperty
{
    /// <summary>
    /// Represents the overlay-related theme property group, <br/>
    /// including background, outline, and mask foreground color settings. <br/>
    /// These values are typically used to style overlay UI components.
    /// </summary>
    internal partial class OverlayThemeProperty : IThemeProperty
    {
        /// <summary> Collection of all overlay theme properties managed by this group. </summary>
        private readonly List<IThemePropertyValue> _themePropertyValues;

        /// <summary> Creates a deep copy of the current <see cref="OverlayThemeProperty"/> instance. </summary>
        internal OverlayThemeProperty Clone()
        {
            return new OverlayThemeProperty()
            {
                Background_Active = Background_Active.Clone(),
                Background_Default = Background_Default.Clone(),
                Background_Disable = Background_Disable.Clone(),
                Background_MouseOver = Background_MouseOver.Clone(),
                Outline_Active = Outline_Active.Clone(),
                Outline_Default = Outline_Default.Clone(),
                Outline_Disable = Outline_Disable.Clone(),
                Outline_MouseOver = Outline_MouseOver.Clone(),
                MaskBackground_Active = MaskBackground_Active.Clone(),
                MaskBackground_Default = MaskBackground_Default.Clone(),
                MaskBackground_Disable = MaskBackground_Disable.Clone(),
                MaskBackground_MouseOver = MaskBackground_MouseOver.Clone(),
            };
        }

        /// <summary> Initializes the <see cref="OverlayThemeProperty"/> with all default values. </summary>
        internal OverlayThemeProperty()
        {
            _themePropertyValues = new()
            {
                Background_Active,
                Background_Default,
                Background_Disable,
                Background_MouseOver,
                Outline_Active,
                Outline_Default,
                Outline_Disable,
                Outline_MouseOver,
                MaskBackground_Active,
                MaskBackground_Default,
                MaskBackground_Disable,
                MaskBackground_MouseOver,
            };
        }
    }

    #region ========== Interface - IThemeProperty ==========
    internal partial class OverlayThemeProperty
    {

        /// <inheritdoc />
        public bool Apply(IINIState? iniState)
        {
            if (_themePropertyValues is null)
                return false;
            bool result = true;
            foreach (var item in _themePropertyValues)
                result &= item.Apply(iniState);
            return result;
        }

        /// <inheritdoc />
        public bool Restore(IINIState? iniState)
        {
            if (_themePropertyValues is null)
                return false;
            bool result = true;
            foreach (var item in _themePropertyValues)
                result &= item.Restore(iniState);
            return result;
        }

        /// <inheritdoc />
        public void ResetValueToDefault()
        {
            if (_themePropertyValues is null)
                return;
            foreach (var item in _themePropertyValues)
                item.ResetValueToDefault();
        }
    
    }
    #endregion

    #region ========== Overlay - Background ==========
    internal partial class OverlayThemeProperty
    {
        
        /// <summary>Overlay background when active.</summary>
        internal ThemePropertyValue<Color> Background_Active { get; private set; }
            = new(ThemeKey.Overlay.Background.Active.Ini.Section,
                ThemeKey.Overlay.Background.Active.Ini.Key,
                Color.FromArgb(64, 128, 128, 128));

        /// <summary>Overlay background in default state.</summary>
        internal ThemePropertyValue<Color> Background_Default { get; private set; }
            = new(ThemeKey.Overlay.Background.Default.Ini.Section,
                ThemeKey.Overlay.Background.Default.Ini.Key,
                Color.FromArgb(16, 128, 128, 128));

        /// <summary>Overlay background when disabled.</summary>
        internal ThemePropertyValue<Color> Background_Disable { get; private set; }
            = new(ThemeKey.Overlay.Background.Disable.Ini.Section,
                ThemeKey.Overlay.Background.Disable.Ini.Key,
                Color.FromArgb(5, 128, 128, 128));

        /// <summary>Overlay background on mouse-over.</summary>
        internal ThemePropertyValue<Color> Background_MouseOver { get; private set; }
            = new(ThemeKey.Overlay.Background.MouseOver.Ini.Section,
                ThemeKey.Overlay.Background.MouseOver.Ini.Key,
                Color.FromArgb(37, 128, 128, 128));

    }
    #endregion

    #region ========== Overlay - Outline ==========
    internal partial class OverlayThemeProperty
    {
        
        /// <summary>Overlay outline when active.</summary>
        internal ThemePropertyValue<Color> Outline_Active { get; private set; }
            = new(ThemeKey.Overlay.Outline.Active.Ini.Section,
                ThemeKey.Overlay.Outline.Active.Ini.Key,
                Color.FromArgb(255, 21, 21, 21));

        /// <summary>Overlay outline in default state.</summary>
        internal ThemePropertyValue<Color> Outline_Default { get; private set; }
            = new(ThemeKey.Overlay.Outline.Default.Ini.Section,
                ThemeKey.Overlay.Outline.Default.Ini.Key,
                Color.FromArgb(51, 21, 21, 21));

        /// <summary>Overlay outline when disabled.</summary>
        internal ThemePropertyValue<Color> Outline_Disable { get; private set; }
            = new(ThemeKey.Overlay.Outline.Disable.Ini.Section,
                ThemeKey.Overlay.Outline.Disable.Ini.Key,
                Color.FromArgb(37, 128, 128, 128));

        /// <summary>Overlay outline on mouse-over.</summary>
        internal ThemePropertyValue<Color> Outline_MouseOver { get; private set; }
            = new(ThemeKey.Overlay.Outline.MouseOver.Ini.Section,
                ThemeKey.Overlay.Outline.MouseOver.Ini.Key,
                Color.FromArgb(128, 21, 21, 21));

    }
    #endregion

    #region ========== Overlay - Mask Background ==========
    internal partial class OverlayThemeProperty
    {

        /// <summary>Overlay mask foreground when active.</summary>
        internal ThemePropertyValue<Color> MaskBackground_Active { get; private set; }
            = new(ThemeKey.Overlay.Mask.Background.Active.Ini.Section,
                ThemeKey.Overlay.Mask.Background.Active.Ini.Key,
                Color.FromArgb(240, 21, 21, 21));

        /// <summary>Overlay mask foreground in default state.</summary>
        internal ThemePropertyValue<Color> MaskBackground_Default { get; private set; }
            = new(ThemeKey.Overlay.Mask.Background.Default.Ini.Section,
                ThemeKey.Overlay.Mask.Background.Default.Ini.Key,
                Color.FromArgb(80, 21, 21, 21));

        /// <summary>Overlay mask foreground when disabled.</summary>
        internal ThemePropertyValue<Color> MaskBackground_Disable { get; private set; }
            = new(ThemeKey.Overlay.Mask.Background.Disable.Ini.Section,
                ThemeKey.Overlay.Mask.Background.Disable.Ini.Key,
                Color.FromArgb(37, 21, 21, 21));

        /// <summary>Overlay mask foreground on mouse-over.</summary>
        internal ThemePropertyValue<Color> MaskBackground_MouseOver { get; private set; }
            = new(ThemeKey.Overlay.Mask.Background.MouseOver.Ini.Section,
                ThemeKey.Overlay.Mask.Background.MouseOver.Ini.Key,
                Color.FromArgb(160, 21, 21, 21));

    }
    #endregion

}
