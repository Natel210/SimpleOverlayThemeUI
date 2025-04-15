using SimpleFileIO.State.Ini;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SimpleOverlayTheme.Theme.Interface
{
    /// <summary>
    /// Represents a complete theme contract including visual properties, persistence logic, and memory operations.
    /// </summary>
    public interface ITheme
    {
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Identity ==========

        /// <summary>  Gets or sets the name of the theme.</summary>
        string ThemeName { get; set; }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Font Sizes ==========

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

        /// <summary>Gets or sets the default body font size.</summary>
        double FontSize_Default { get; set; }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Thickness ==========

        /// <summary>Gets or sets the default UI element thickness.</summary>
        Thickness Thickness_Default { get; set; }

        /// <summary>Gets or sets zero-thickness, often used for spacing removal.</summary>
        Thickness Thickness_Zero { get; set; }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Color Palette ==========

        /// <summary>Main foreground color.</summary>
        Color ColorPalette_Foreground { get; set; }

        /// <summary>Foreground color when disabled.</summary>
        Color ColorPalette_Foreground_Disable { get; set; }

        /// <summary>Main background color.</summary>
        Color ColorPalette_Background { get; set; }

        /// <summary>Outline color used for borders and frames.</summary>
        Color ColorPalette_Outline { get; set; }

        /// <summary>Line color, typically used for underlines or separators.</summary>
        Color ColorPalette_Line { get; set; }

        /// <summary>Highlight color used for hover or active indication.</summary>
        Color ColorPalette_Highlight { get; set; }

        /// <summary>Selection background color.</summary>
        Color ColorPalette_Selection { get; set; }

        /// <summary>Mask or overlay tint color, often semi-transparent.</summary>
        Color ColorPalette_Mask { get; set; }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Border Background ==========
        
        /// <summary>Overlay border background when disabled.</summary>
        Color OverlayBorderBackground_Disable { get; set; }

        /// <summary>Overlay border background in default state.</summary>
        Color OverlayBorderBackground_Default { get; set; }

        /// <summary>Overlay border background on mouse-over.</summary>
        Color OverlayBorderBackground_MouseOver { get; set; }

        /// <summary>Overlay border background when active.</summary>
        Color OverlayBorderBackground_Active { get; set; }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Interface - Border Outline ==========

        /// <summary>Overlay border outline when disabled.</summary>
        Color OverlayBorderOutline_Disable { get; set; }

        /// <summary>Overlay border outline in default state.</summary>
        Color OverlayBorderOutline_Default { get; set; }

        /// <summary>Overlay border outline on mouse-over.</summary>
        Color OverlayBorderOutline_MouseOver { get; set; }

        /// <summary>Overlay border outline when active.</summary>
        Color OverlayBorderOutline_Active { get; set; }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Mask Foreground ==========

        /// <summary>Overlay mask foreground when disabled.</summary>
        Color OverlayMaskForeground_Disable { get; set; }

        /// <summary>Overlay mask foreground in default state.</summary>
        Color OverlayMaskForeground_Default { get; set; }

        /// <summary>Overlay mask foreground on mouse-over.</summary>
        Color OverlayMaskForeground_MouseOver { get; set; }

        /// <summary>Overlay mask foreground when active.</summary>
        Color OverlayMaskForeground_Active { get; set; }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== INI File Interaction ==========

        /// <summary>
        /// Saves the current theme settings to the associated INI file.
        /// </summary>
        /// <returns>True if save operation was successful; otherwise, false.</returns>
        bool SaveToFile();

        /// <summary>
        /// Loads theme settings from the associated INI file and applies them to the current object.
        /// </summary>
        /// <returns>True if loading and application were successful; otherwise, false.</returns>
        bool LoadFromFile();

        /// <summary>
        /// Deletes the INI file associated with this theme instance.
        /// </summary>
        /// <returns>True if the file was deleted successfully; otherwise, false.</returns>
        bool DeleteFile();

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== INI State Interaction ==========

        /// <summary>
        /// Applies values from a preloaded INI state to the in-memory properties.<br/>
        /// This does not involve file access and assumes the INI was already loaded.
        /// </summary>
        /// <returns>True if apply succeeded; otherwise, false.</returns>
        bool Apply();

        /// <summary>
        /// Restores current values into a temporary INI memory structure.<br/>
        /// This is used for preparing save operations, but does not write to file.
        /// </summary>
        /// <returns>True if restore succeeded; otherwise, false.</returns>
        bool Restore();

        /// <summary>
        /// Resets all values in this theme to their predefined default values.
        /// </summary>
        void ResetValueToDefault();

        #endregion
    }
}
