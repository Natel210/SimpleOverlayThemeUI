using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace SimpleOverlayTheme.Object.CheckBoxObject.Helper
{
    public class Mask
    {
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        #region MaskBrushDefault

        public static readonly DependencyProperty MaskBrushDefaultProperty = DependencyProperty.RegisterAttached("MaskBrushDefault", typeof(ImageBrush), typeof(Mask), new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.Mask}")]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        public static ImageBrush? GetMaskBrushDefault(UIElement element)
        {
            return (ImageBrush)element.GetValue(MaskBrushDefaultProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Mask}")]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        public static void SetMaskBrushDefault(UIElement element, ImageBrush? value)
        {
            element.SetValue(MaskBrushDefaultProperty, value);
        }

        #endregion
    }
}
