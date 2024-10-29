using SimpleOverlayTheme.CustomControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SimpleOverlayTheme.Object.WindowObject.Helper
{
    public class Items
    {
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        #region WindowTitleHeader

        public static readonly DependencyProperty WindowTitleHeaderProperty
            = DependencyProperty.RegisterAttached(
                "WindowTitleHeader",
                typeof(WindowHeader),
                typeof(Items),
                new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.Items}")]
        [AttachedPropertyBrowsableForType(typeof(Window))]
        public static WindowHeader? GetWindowTitleHeader(UIElement element)
        {
            return (WindowHeader)element.GetValue(WindowTitleHeaderProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Items}")]
        [AttachedPropertyBrowsableForType(typeof(Window))]
        public static void SetWindowTitleHeader(UIElement element, WindowHeader? value)
        {
            element.SetValue(WindowTitleHeaderProperty, value);
        }

        #endregion

    }
}
