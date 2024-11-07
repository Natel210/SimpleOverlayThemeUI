using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace SimpleOverlayTheme.Object.DataGridObject.Helper
{
    public class Cell
    {
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        #region ContentPadding

        public static readonly DependencyProperty ContentPaddingProperty
            = DependencyProperty.RegisterAttached(
                "ContentPadding",
                typeof(Thickness),
                typeof(Cell),
                new FrameworkPropertyMetadata(new Thickness(0), _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.Cell}")]
        [AttachedPropertyBrowsableForType(typeof(DataGridCell))]
        public static Thickness GetContentPadding(UIElement element)
        {
            return (Thickness)element.GetValue(ContentPaddingProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Cell}")]
        [AttachedPropertyBrowsableForType(typeof(DataGridCell))]
        public static void SetContentPadding(UIElement element, Thickness value)
        {
            element.SetValue(ContentPaddingProperty, value);
        }
        #endregion
    }
}
