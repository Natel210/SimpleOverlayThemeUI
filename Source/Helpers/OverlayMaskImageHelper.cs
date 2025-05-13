using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace SimpleOverlayTheme.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class OverlayMaskImageHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // DefaultImageMask
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty DefaultImageMaskProperty
            = GeneratorProperty("DefaultImageMask",
                typeof(ImageBrush), typeof(OverlayMaskImageHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(OverlayMaskImageHelper))]
        [DisplayName("DefaultImageMask")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static ImageBrush? GetDefaultImageMask(UIElement element)
            => (ImageBrush)element.GetValue(DefaultImageMaskProperty);

        /// <summary></summary>
        public static void SetDefaultImageMask(UIElement element, ImageBrush? value)
            => element.SetValue(DefaultImageMaskProperty, value);

        ////////////////////////////////////////
        // UseActiveImageMask
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty UseActiveImageMaskProperty
            = GeneratorProperty("UseActiveImageMask",
                typeof(bool), typeof(OverlayMaskImageHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(OverlayMaskImageHelper))]
        [DisplayName("UseActiveImageMask")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetUseActiveImageMask(UIElement element)
            => (bool)element.GetValue(UseActiveImageMaskProperty);

        /// <summary></summary>
        public static void SetUseActiveImageMask(UIElement element, bool value)
            => element.SetValue(UseActiveImageMaskProperty, value);

        ////////////////////////////////////////
        // ActiveImageMask
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty ActiveImageMaskProperty
            = GeneratorProperty("ActiveImageMask",
                typeof(ImageBrush), typeof(OverlayMaskImageHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(OverlayMaskImageHelper))]
        [DisplayName("ActiveImageMask")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static ImageBrush? GetActiveImageMask(UIElement element)
            => (ImageBrush)element.GetValue(ActiveImageMaskProperty);

        /// <summary></summary>
        public static void SetActiveImageMask(UIElement element, ImageBrush? value)
            => element.SetValue(ActiveImageMaskProperty, value);

        ////////////////////////////////////////
        // UseDisableImageMask
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty UseDisableImageMaskProperty
            = GeneratorProperty("UseDisableImageMask",
                typeof(bool), typeof(OverlayMaskImageHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(OverlayMaskImageHelper))]
        [DisplayName("UseDisableImageMask")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetUseDisableImageMask(UIElement element)
            => (bool)element.GetValue(UseDisableImageMaskProperty);

        /// <summary></summary>
        public static void SetUseDisableImageMask(UIElement element, bool value)
            => element.SetValue(UseDisableImageMaskProperty, value);

        ////////////////////////////////////////
        // DisableImageMask
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty DisableImageMaskProperty
            = GeneratorProperty("DisableImageMask",
                typeof(ImageBrush), typeof(OverlayMaskImageHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(OverlayMaskImageHelper))]
        [DisplayName("DisableImageMask")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static ImageBrush? GetDisableImageMask(UIElement element)
            => (ImageBrush)element.GetValue(DisableImageMaskProperty);

        /// <summary></summary>
        public static void SetDisableImageMask(UIElement element, ImageBrush? value)
            => element.SetValue(DisableImageMaskProperty, value);

        ////////////////////////////////////////
        // UseMouseoverImageMask
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty UseMouseoverImageMaskProperty
            = GeneratorProperty("UseMouseoverImageMask",
                typeof(bool), typeof(OverlayMaskImageHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(OverlayMaskImageHelper))]
        [DisplayName("UseMouseoverImageMask")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetUseMouseoverImageMask(UIElement element)
            => (bool)element.GetValue(UseMouseoverImageMaskProperty);

        /// <summary></summary>
        public static void SetUseMouseoverImageMask(UIElement element, bool value)
            => element.SetValue(UseMouseoverImageMaskProperty, value);

        ////////////////////////////////////////
        // MouseoverImageMask
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty MouseoverImageMaskProperty
            = GeneratorProperty("MouseoverImageMask",
                typeof(ImageBrush), typeof(OverlayMaskImageHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(OverlayMaskImageHelper))]
        [DisplayName("MouseoverImageMask")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static ImageBrush? GetMouseoverImageMask(UIElement element)
            => (ImageBrush)element.GetValue(MouseoverImageMaskProperty);

        /// <summary></summary>
        public static void SetMouseoverImageMask(UIElement element, ImageBrush? value)
            => element.SetValue(MouseoverImageMaskProperty, value);
    }
}
