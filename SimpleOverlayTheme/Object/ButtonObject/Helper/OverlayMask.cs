using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;

namespace SimpleOverlayTheme.Object.ButtonObject.Helper
{
    public class OverlayMask
    {
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        #region SetDefaultVisible

        public static readonly DependencyProperty SetDefaultVisibleProperty
            = DependencyProperty.RegisterAttached(
                "SetDefaultVisible",
                typeof(bool),
                typeof(OverlayMask),
                new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.OverlayMask}")]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        public static bool GetSetDefaultVisible(UIElement element)
        {
            return (bool)element.GetValue(SetDefaultVisibleProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.OverlayMask}")]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        public static void SetSetDefaultVisible(UIElement element, bool value)
        {
            element.SetValue(SetDefaultVisibleProperty, value);
        }

        #endregion

        #region OverlayMaskVisible

        public static readonly DependencyProperty OverlayMaskVisibleProperty
            = DependencyProperty.RegisterAttached(
                "OverlayMaskVisible",
                typeof(bool),
                typeof(OverlayMask),
                new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.OverlayMask}")]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        public static bool GetOverlayMaskVisible(UIElement element)
        {
            return (bool)element.GetValue(OverlayMaskVisibleProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.OverlayMask}")]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        public static void SetOverlayMaskVisible(UIElement element, bool value)
        {
            element.SetValue(OverlayMaskVisibleProperty, value);
        }

        #endregion

    }
}
