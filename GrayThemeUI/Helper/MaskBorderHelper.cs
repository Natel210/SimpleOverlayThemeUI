using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace GrayThemeUI.Helper
{
    public class MaskBorderHelper
    {
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;
        private const string _category = "GrayThemeUI.MaskBorder.Helper";

        public static readonly DependencyProperty Mask1Property = DependencyProperty.RegisterAttached("DefaultMask", typeof(ImageBrush), typeof(MaskHelper), new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        public static ImageBrush GetDefaultMask(UIElement element)
        {
            return (ImageBrush)element.GetValue(DefaultMaskProperty);
        }

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        public static void SetDefaultMask(UIElement element, ImageBrush value)
        {
            element.SetValue(DefaultMaskProperty, value);
        }

        public static readonly DependencyProperty CheckedMaskProperty
            = DependencyProperty.RegisterAttached("CheckedMask", typeof(ImageBrush), typeof(MaskHelper),
                new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        public static ImageBrush GetCheckedMask(UIElement element)
        {
            return (ImageBrush)element.GetValue(CheckedMaskProperty);
        }

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        public static void SetCheckedMask(UIElement element, ImageBrush value)
        {
            element.SetValue(CheckedMaskProperty, value);
        }
    }
}
