using SimpleOverlayTheme.Theme.Interface;
using SimpleOverlayTheme.Theme.ThemeDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SimpleOverlayTheme.Theme
{
    public class ThemeObejct : ATheme
    {
        public ThemeObejct(string name) :base(name)
        {

        }


        public new string ThemeName { get => base.ThemeName; set => base.ThemeName = value; }

        #region FontSize
        public new double FontSize_Header1 { get => base.FontSize_Header1; internal set => base.FontSize_Header1 = value; }
        public new double FontSize_Header2 { get => base.FontSize_Header2; internal set => base.FontSize_Header2 = value; }
        public new double FontSize_Header3 { get => base.FontSize_Header3; internal set => base.FontSize_Header3 = value; }
        public new double FontSize_Header4 { get => base.FontSize_Header4; internal set => base.FontSize_Header4 = value; }
        public new double FontSize_Header5 { get => base.FontSize_Header5; internal set => base.FontSize_Header5 = value; }
        public new double FontSize_Header6 { get => base.FontSize_Header6; internal set => base.FontSize_Header6 = value; }
        public new double FontSize_Default { get => base.FontSize_Default; internal set => base.FontSize_Default = value; }
        #endregion

        #region Thickness
        public new Thickness Thickness_Default { get => base.Thickness_Default; internal set => base.Thickness_Default = value; }
        public new Thickness Thickness_Zero { get => base.Thickness_Zero; internal set => base.Thickness_Zero = value; }
        #endregion

        #region ColorPalette
        public new Color ColorPalette_Foreground { get => base.ColorPalette_Foreground; internal set => base.ColorPalette_Foreground = value; }
        public new Color ColorPalette_Foreground_Disable { get => base.ColorPalette_Foreground_Disable; internal set => base.ColorPalette_Foreground_Disable = value; }
        public new Color ColorPalette_Background { get => base.ColorPalette_Background; internal set => base.ColorPalette_Background = value; }
        public new Color ColorPalette_Outline { get => base.ColorPalette_Outline; internal set => base.ColorPalette_Outline = value; }
        public new Color ColorPalette_Line { get => base.ColorPalette_Line; internal set => base.ColorPalette_Line = value; }
        public new Color ColorPalette_Highlight { get => base.ColorPalette_Highlight; internal set => base.ColorPalette_Highlight = value; }
        public new Color ColorPalette_Selection { get => base.ColorPalette_Selection; internal set => base.ColorPalette_Selection = value; }
        public new Color ColorPalette_Mask { get => base.ColorPalette_Mask; internal set => base.ColorPalette_Mask = value; }
        #endregion

        #region OverlayBorderBackground
        public new Color OverlayBorderBackground_Disable { get => base.ColorPalette_Mask; internal set => base.ColorPalette_Mask = value; }
        public new Color OverlayBorderBackground_Default { get => base.ColorPalette_Mask; internal set => base.ColorPalette_Mask = value; }
        public new Color OverlayBorderBackground_MouseOver { get => base.ColorPalette_Mask; internal set => base.ColorPalette_Mask = value; }
        public new Color OverlayBorderBackground_Active { get => base.ColorPalette_Mask; internal set => base.ColorPalette_Mask = value; }
        #endregion

        #region OverlayBorderOutline
        public new Color OverlayBorderOutline_Disable { get => base.ColorPalette_Mask; internal set => base.ColorPalette_Mask = value; }
        public new Color OverlayBorderOutline_Default { get => base.ColorPalette_Mask; internal set => base.ColorPalette_Mask = value; }
        public new Color OverlayBorderOutline_MouseOver { get => base.ColorPalette_Mask; internal set => base.ColorPalette_Mask = value; }
        public new Color OverlayBorderOutline_Active { get => base.ColorPalette_Mask; internal set => base.ColorPalette_Mask = value; }
        #endregion

        #region OverlayMaskForeground
        public new Color OverlayMaskForeground_Disable { get => base.ColorPalette_Mask; internal set => base.ColorPalette_Mask = value; }
        public new Color OverlayMaskForeground_Default { get => base.ColorPalette_Mask; internal set => base.ColorPalette_Mask = value; }
        public new Color OverlayMaskForeground_MouseOver { get => base.ColorPalette_Mask; internal set => base.ColorPalette_Mask = value; }
        public new Color OverlayMaskForeground_Active { get => base.ColorPalette_Mask; internal set => base.ColorPalette_Mask = value; }



    }
}
