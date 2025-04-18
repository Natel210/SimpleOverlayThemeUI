using SimpleFileIO.State.Ini;
using SimpleOverlayTheme.Theme.Interface;
using System.Windows.Media;

namespace SimpleOverlayTheme.Theme.ThemeProperty
{
    /// <summary>
    /// Represents the overlay-related theme property group, <br/>
    /// including background, outline, and mask foreground color settings. <br/>
    /// These values are typically used to style overlay UI components.
    /// </summary>
    internal class OverlayThemeProperty : IThemeProperty
    {
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Interface - IThemeProperty ==========
        
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

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Border Background ==========

        /// <summary>Overlay border background when disabled.</summary>
        internal ThemePropertyValue<Color> BorderBackground_Disable { get; private set; } = new(_sectionName, nameof(BorderBackground_Disable), Color.FromArgb(5, 128, 128, 128));

        /// <summary>Overlay border background in default state.</summary>
        internal ThemePropertyValue<Color> BorderBackground_Default { get; private set; } = new(_sectionName, nameof(BorderBackground_Default), Color.FromArgb(16, 128, 128, 128));

        /// <summary>Overlay border background on mouse-over.</summary>
        internal ThemePropertyValue<Color> BorderBackground_MouseOver { get; private set; } = new(_sectionName, nameof(BorderBackground_MouseOver), Color.FromArgb(37, 128, 128, 128));

        /// <summary>Overlay border background when active.</summary>
        internal ThemePropertyValue<Color> BorderBackground_Active { get; private set; } = new(_sectionName, nameof(BorderBackground_Active), Color.FromArgb(64, 128, 128, 128));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Border Outline ==========

        /// <summary>Overlay border outline when disabled.</summary>
        internal ThemePropertyValue<Color> BorderOutline_Disable { get; private set; } = new(_sectionName, nameof(BorderOutline_Disable), Color.FromArgb(37, 128, 128, 128));

        /// <summary>Overlay border outline in default state.</summary>
        internal ThemePropertyValue<Color> BorderOutline_Default { get; private set; } = new(_sectionName, nameof(BorderOutline_Default), Color.FromArgb(51, 21, 21, 21));

        /// <summary>Overlay border outline on mouse-over.</summary>
        internal ThemePropertyValue<Color> BorderOutline_MouseOver { get; private set; } = new(_sectionName, nameof(BorderOutline_MouseOver), Color.FromArgb(128, 21, 21, 21));

        /// <summary>Overlay border outline when active.</summary>
        internal ThemePropertyValue<Color> BorderOutline_Active { get; private set; } = new(_sectionName, nameof(BorderOutline_Active), Color.FromArgb(255, 21, 21, 21));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Mask Foreground ==========

        /// <summary>Overlay mask foreground when disabled.</summary>
        internal ThemePropertyValue<Color> MaskForeground_Disable { get; private set; } = new(_sectionName, nameof(MaskForeground_Disable), Color.FromArgb(37, 21, 21, 21));

        /// <summary>Overlay mask foreground in default state.</summary>
        internal ThemePropertyValue<Color> MaskForeground_Default { get; private set; } = new(_sectionName, nameof(MaskForeground_Default), Color.FromArgb(80, 21, 21, 21));

        /// <summary>Overlay mask foreground on mouse-over.</summary>
        internal ThemePropertyValue<Color> MaskForeground_MouseOver { get; private set; } = new(_sectionName, nameof(MaskForeground_MouseOver), Color.FromArgb(160, 21, 21, 21));

        /// <summary>Overlay mask foreground when active.</summary>
        internal ThemePropertyValue<Color> MaskForeground_Active { get; private set; } = new(_sectionName, nameof(MaskForeground_Active), Color.FromArgb(240, 21, 21, 21));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////

        /// <summary> Section name used for all INI keys in this group. </summary>
        private const string _sectionName = "Overlay";

        /// <summary> Collection of all overlay theme properties managed by this group. </summary>
        private readonly List<IThemePropertyValue> _themePropertyValues;

        internal OverlayThemeProperty Clone()
        {
            return new OverlayThemeProperty()
            {
                BorderBackground_Disable = BorderBackground_Disable.Clone(),
                BorderBackground_Default = BorderBackground_Default.Clone(),
                BorderBackground_MouseOver = BorderBackground_MouseOver.Clone(),
                BorderBackground_Active = BorderBackground_Active.Clone(),
                BorderOutline_Disable = BorderOutline_Disable.Clone(),
                BorderOutline_Default = BorderOutline_Default.Clone(),
                BorderOutline_MouseOver = BorderOutline_MouseOver.Clone(),
                BorderOutline_Active = BorderOutline_Active.Clone(),
                MaskForeground_Disable = MaskForeground_Disable.Clone(),
                MaskForeground_Default = MaskForeground_Default.Clone(),
                MaskForeground_MouseOver = MaskForeground_MouseOver.Clone(),
                MaskForeground_Active = MaskForeground_Active.Clone()
            };
        }

        /// <summary> Initializes the <see cref="OverlayThemeProperty"/> with all default values. </summary>
        internal OverlayThemeProperty()
        {
            //// Border Background
            //BorderBackground_Disable = new(_sectionName, nameof(BorderBackground_Disable), Color.FromArgb(5, 128, 128, 128));
            //BorderBackground_Default = new(_sectionName, nameof(BorderBackground_Default), Color.FromArgb(16, 128, 128, 128));
            //BorderBackground_MouseOver = new(_sectionName, nameof(BorderBackground_MouseOver), Color.FromArgb(37, 128, 128, 128));
            //BorderBackground_Active = new(_sectionName, nameof(BorderBackground_Active), Color.FromArgb(64, 128, 128, 128));

            //// Border Outline
            //BorderOutline_Disable = new(_sectionName, nameof(BorderOutline_Disable), Color.FromArgb(37, 128, 128, 128));
            //BorderOutline_Default = new(_sectionName, nameof(BorderOutline_Default), Color.FromArgb(51, 21, 21, 21));
            //BorderOutline_MouseOver = new(_sectionName, nameof(BorderOutline_MouseOver), Color.FromArgb(128, 21, 21, 21));
            //BorderOutline_Active = new(_sectionName, nameof(BorderOutline_Active), Color.FromArgb(255, 21, 21, 21));

            //// Mask Foreground
            //MaskForeground_Disable = new(_sectionName, nameof(MaskForeground_Disable), Color.FromArgb(37, 21, 21, 21));
            //MaskForeground_Default = new(_sectionName, nameof(MaskForeground_Default), Color.FromArgb(80, 21, 21, 21));
            //MaskForeground_MouseOver = new(_sectionName, nameof(MaskForeground_MouseOver), Color.FromArgb(160, 21, 21, 21));
            //MaskForeground_Active = new(_sectionName, nameof(MaskForeground_Active), Color.FromArgb(240, 21, 21, 21));

            _themePropertyValues = new()
            {
                BorderBackground_Disable, BorderBackground_Default,
                BorderBackground_MouseOver, BorderBackground_Active,
                BorderOutline_Disable, BorderOutline_Default,
                BorderOutline_MouseOver, BorderOutline_Active,
                MaskForeground_Disable, MaskForeground_Default,
                MaskForeground_MouseOver, MaskForeground_Active
            };
        }
    }
}
