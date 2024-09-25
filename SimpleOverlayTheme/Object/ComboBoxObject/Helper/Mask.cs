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

namespace SimpleOverlayTheme.Object.ComboBoxObject.Helper
{
    public class Mask
    {
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        #region MaskBrushDefault

        public static readonly DependencyProperty MaskBrushDefaultProperty = DependencyProperty.RegisterAttached("MaskBrushDefault", typeof(ImageBrush), typeof(Mask), new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.Mask}")]
        [AttachedPropertyBrowsableForType(typeof(ComboBox))]
        public static ImageBrush? GetMaskBrushDefault(UIElement element)
        {
            return (ImageBrush)element.GetValue(MaskBrushDefaultProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Mask}")]
        [AttachedPropertyBrowsableForType(typeof(ComboBox))]
        public static void SetMaskBrushDefault(UIElement element, ImageBrush? value)
        {
            element.SetValue(MaskBrushDefaultProperty, value);
        }

        #endregion



        #region MaskBrushActiveList

        public static readonly DependencyProperty MaskBrushActiveListProperty = DependencyProperty.RegisterAttached("MaskBrushActiveList", typeof(ImageBrush), typeof(Mask), new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.Mask}")]
        [AttachedPropertyBrowsableForType(typeof(ComboBox))]
        public static ImageBrush? GetMaskBrushActiveList(UIElement element)
        {
            return (ImageBrush)element.GetValue(MaskBrushActiveListProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Mask}")]
        [AttachedPropertyBrowsableForType(typeof(ComboBox))]
        public static void SetMaskBrushActiveList(UIElement element, ImageBrush? value)
        {
            element.SetValue(MaskBrushActiveListProperty, value);
        }

        #endregion
    }
}
