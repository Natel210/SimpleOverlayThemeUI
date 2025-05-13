using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace SimpleOverlayTheme.Helpers
{
    /// <summary></summary>
    public class CheckBoxHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // CheckedMaskBrush
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty CheckedMaskBrushProperty
            = GeneratorProperty("CheckedMaskBrush",
                typeof(Brush), typeof(CheckBoxHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(OverlayMaskImageHelper))]
        [DisplayName("CheckedMaskBrush")]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        public static Brush? GetCheckedMaskBrush(UIElement element)
            => (Brush)element.GetValue(CheckedMaskBrushProperty);

        /// <summary></summary>
        public static void SetCheckedMaskBrush(UIElement element, Brush? value)
            => element.SetValue(CheckedMaskBrushProperty, value);

        ////////////////////////////////////////
        // UseOverlayBackground
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty UseOverlayBackgroundProperty
            = GeneratorProperty("UseOverlayBackground",
                typeof(bool), typeof(CheckBoxHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(CheckBoxHelper))]
        [DisplayName("UseOverlayBackground")]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        public static bool GetUseOverlayBackground(UIElement element)
            => (bool)element.GetValue(UseOverlayBackgroundProperty);

        /// <summary></summary>
        public static void SetUseOverlayBackground(UIElement element, bool value)
            => element.SetValue(UseOverlayBackgroundProperty, value);

        ////////////////////////////////////////
        // UseOverlayMask
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty UseOverlayMaskProperty
            = GeneratorProperty("UseOverlayMask",
                typeof(bool), typeof(CheckBoxHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(CheckBoxHelper))]
        [DisplayName("UseOverlayMask")]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        public static bool GetUseOverlayMask(UIElement element)
            => (bool)element.GetValue(UseOverlayMaskProperty);

        /// <summary></summary>
        public static void SetUseOverlayMask(UIElement element, bool value)
            => element.SetValue(UseOverlayMaskProperty, value);
    }
}
