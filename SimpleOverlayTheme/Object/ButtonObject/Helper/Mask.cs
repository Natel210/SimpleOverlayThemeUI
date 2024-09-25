using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace SimpleOverlayTheme.Object.ButtonObject.Helper
{
    public class Mask
    {
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        #region MaskBrushDefault

        public static readonly DependencyProperty MaskBrushDefaultProperty = DependencyProperty.RegisterAttached("MaskBrushDefault", typeof(ImageBrush), typeof(Mask), new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.Mask}")]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static ImageBrush? GetMaskBrushDefault(UIElement element)
        {
            return (ImageBrush)element.GetValue(MaskBrushDefaultProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Mask}")]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static void SetMaskBrushDefault(UIElement element, ImageBrush? value)
        {
            element.SetValue(MaskBrushDefaultProperty, value);
        }

        #endregion



        #region MaskBrushChecked

        public static readonly DependencyProperty MaskBrushCheckedProperty = DependencyProperty.RegisterAttached("MaskBrushChecked", typeof(ImageBrush), typeof(Mask), new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.Mask}")]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static ImageBrush? GetMaskBrushChecked(UIElement element)
        {
            return (ImageBrush)element.GetValue(MaskBrushCheckedProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Mask}")]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static void SetMaskBrushChecked(UIElement element, ImageBrush? value)
        {
            element.SetValue(MaskBrushCheckedProperty, value);
        }

        #endregion
    }
}
