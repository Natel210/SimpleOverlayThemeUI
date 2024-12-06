using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;

namespace SimpleOverlayTheme.Object.GroupBoxObject.Helper
{
    public class HeaderUnderline
    {
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        #region HeaderUnderLineBrush

        public static readonly DependencyProperty HeaderUnderLineBrushProperty
            = DependencyProperty.RegisterAttached(
                "HeaderUnderLineBrush",
                typeof(SolidColorBrush),
                typeof(HeaderUnderline),
                new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.Header}")]
        [AttachedPropertyBrowsableForType(typeof(GroupBox))]
        public static SolidColorBrush? GetHeaderUnderLineBrush(UIElement element)
        {
            return (SolidColorBrush)element.GetValue(HeaderUnderLineBrushProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Header}")]
        [AttachedPropertyBrowsableForType(typeof(GroupBox))]
        public static void SetHeaderUnderLineBrush(UIElement element, SolidColorBrush? value)
        {
            element.SetValue(HeaderUnderLineBrushProperty, value);
        }

        #endregion

        #region HeaderUnderLineHeight

        public static readonly DependencyProperty HeaderUnderLineHeightProperty
            = DependencyProperty.RegisterAttached(
                "HeaderUnderLineHeight",
                typeof(double),
                typeof(HeaderUnderline),
                new FrameworkPropertyMetadata(0.0, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.Header}")]
        [AttachedPropertyBrowsableForType(typeof(GroupBox))]
        public static double GetHeaderUnderLineHeight(UIElement element)
        {
            return (double)element.GetValue(HeaderUnderLineHeightProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Header}")]
        [AttachedPropertyBrowsableForType(typeof(GroupBox))]
        public static void SetHeaderUnderLineHeight(UIElement element, double value)
        {
            element.SetValue(HeaderUnderLineHeightProperty, value);
        }

        #endregion
    }
}
