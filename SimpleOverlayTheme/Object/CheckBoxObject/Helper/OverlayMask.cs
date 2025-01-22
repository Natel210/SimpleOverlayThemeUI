using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;

namespace SimpleOverlayTheme.Object.CheckBoxObject.Helper
{
    public class OverlayMask
    {
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        #region SetDefaultVisible

        public static readonly DependencyProperty SetDefaultVisibleProperty = DependencyProperty.RegisterAttached("SetDefaultVisible", typeof(bool), typeof(OverlayMask), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.OverlayMask}")]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        public static bool GetSetDefaultVisible(UIElement element)
        {
            return (bool)element.GetValue(SetDefaultVisibleProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.OverlayMask}")]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        public static void SetSetDefaultVisible(UIElement element, bool value)
        {
            element.SetValue(SetDefaultVisibleProperty, value);
        }

        #endregion
    }
}
