using SimpleFileIO.State.Ini;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace SimpleOverlayTheme.Theme.Interface
{
    /// <summary>
    /// Represents a complete theme contract including visual properties, persistence logic, and memory operations.
    /// </summary>
    public partial interface ITheme {}

    #region ========== Identity ==========
    public partial interface ITheme
    {

        /// <summary>  Gets or sets the name of the theme.</summary>
        string ThemeName { get; set; }

    }
    #endregion

    #region ========== Font Sizes ==========
    public partial interface ITheme
    {

        /// <summary>Gets or sets the default body font size.</summary>
        double FontSize_Default { get; set; }

        /// <summary>Gets or sets the font size for Header1.</summary>
        double FontSize_Header1 { get; set; }

        /// <summary>Gets or sets the font size for Header2.</summary>
        double FontSize_Header2 { get; set; }

        /// <summary>Gets or sets the font size for Header3.</summary>
        double FontSize_Header3 { get; set; }

        /// <summary>Gets or sets the font size for Header4.</summary>
        double FontSize_Header4 { get; set; }

        /// <summary>Gets or sets the font size for Header5.</summary>
        double FontSize_Header5 { get; set; }

        /// <summary>Gets or sets the font size for Header6.</summary>
        double FontSize_Header6 { get; set; }

    }
    #endregion

    #region ========== Thickness ==========
    public partial interface ITheme
    {

        /// <summary>Gets or sets the default UI element thickness.</summary>
        Thickness Thickness_Default { get; set; }

        /// <summary>Gets or sets zero-thickness, often used for spacing removal.</summary>
        Thickness Thickness_Zero { get; set; }

    }
    #endregion

    #region ========== Color Palette ==========
    public partial interface ITheme
    {

        /// <summary>Main background color.</summary>
        Color ColorPalette_Background { get; set; }

        /// <summary>Main foreground color.</summary>
        Color ColorPalette_Foreground { get; set; }

        /// <summary>Foreground color when disabled.</summary>
        Color ColorPalette_Foreground_Disable { get; set; }

        /// <summary>Highlight color used for hover or active indication.</summary>
        Color ColorPalette_Highlight { get; set; }

        /// <summary>Line color, typically used for underlines or separators.</summary>
        Color ColorPalette_Line { get; set; }

        /// <summary>Mask or overlay tint color, often semi-transparent.</summary>
        Color ColorPalette_Mask { get; set; }

        /// <summary>Outline color used for borders and frames.</summary>
        Color ColorPalette_Outline { get; set; }

        /// <summary>Selection background color.</summary>
        Color ColorPalette_Selection { get; set; }

    }
    #endregion

    #region ========== Overlay - Background ==========
    public partial interface ITheme
    {

        /// <summary>Overlay background when active.</summary>
        Color OverlayBackground_Active { get; set; }

        /// <summary>Overlay background in default state.</summary>
        Color OverlayBackground_Default { get; set; }

        /// <summary>Overlay background when disabled.</summary>
        Color OverlayBackground_Disable { get; set; }

        /// <summary>Overlay background on mouse-over.</summary>
        Color OverlayBackground_MouseOver { get; set; }

    }
    #endregion

    #region ========== Overlay - Outline ==========
    public partial interface ITheme
    {

        /// <summary>Overlay outline when active.</summary>
        Color OverlayOutline_Active { get; set; }

        /// <summary>Overlay outline in default state.</summary>
        Color OverlayOutline_Default { get; set; }

        /// <summary>Overlay outline when disabled.</summary>
        Color OverlayOutline_Disable { get; set; }

        /// <summary>Overlay outline on mouse-over.</summary>
        Color OverlayOutline_MouseOver { get; set; }

    }
    #endregion

    #region ========== Overlay - Mask Background ==========
    public partial interface ITheme
    {

        /// <summary>Overlay mask background when active.</summary>
        Color OverlayMaskBackground_Active { get; set; }

        /// <summary>Overlay mask background in default state.</summary>
        Color OverlayMaskBackground_Default { get; set; }

        /// <summary>Overlay mask background when disabled.</summary>
        Color OverlayMaskBackground_Disable { get; set; }

        /// <summary>Overlay mask background on mouse-over.</summary>
        Color OverlayMaskBackground_MouseOver { get; set; }

    }
    #endregion

}
