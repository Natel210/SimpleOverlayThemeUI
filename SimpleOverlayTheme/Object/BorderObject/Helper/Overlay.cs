using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SimpleOverlayTheme.Object.BorderObject.Helper
{
    public class Overlay
    {
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        #region Disable

        public static readonly DependencyProperty IsDisableProperty = DependencyProperty.RegisterAttached("IsDisable", typeof(bool), typeof(Overlay), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions, OnIsDisableChanged));

        [Category($"{KeywordDictionary.CategoryKey.Overlay}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetIsDisable(UIElement element)
        {
            return (bool)element.GetValue(IsDisableProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Overlay}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static void SetIsDisable(UIElement element, bool value)
        {
            element.SetValue(IsDisableProperty, value);
        }

        private static void OnIsDisableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //if (d is Border border && e.NewValue is bool isDisable)
            //{
            //}
        }

        #endregion //Disable

        #region Default

        public static readonly DependencyProperty IsDefaultProperty = DependencyProperty.RegisterAttached("IsDefault", typeof(bool), typeof(Overlay), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions, OnIsDefaultChanged));

        [Category($"{KeywordDictionary.CategoryKey.Overlay}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetIsDefault(UIElement element)
        {
            return (bool)element.GetValue(IsDefaultProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Overlay}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static void SetIsDefault(UIElement element, bool value)
        {
            element.SetValue(IsDefaultProperty, value);
        }

        private static void OnIsDefaultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //if (d is System.Windows.Controls.Border border && e.NewValue is bool isDefault)
            //{
            //}
        }

        #endregion //Default

        #region MouseOver

        public static readonly DependencyProperty IsMouseOverProperty = DependencyProperty.RegisterAttached("IsMouseOver", typeof(bool), typeof(Overlay), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions, OnIsMouseOverChanged));

        [Category($"{KeywordDictionary.CategoryKey.Overlay}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetIsMouseOver(UIElement element)
        {
            return (bool)element.GetValue(IsMouseOverProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Overlay}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static void SetIsMouseOver(UIElement element, bool value)
        {
            element.SetValue(IsMouseOverProperty, value);
        }

        private static void OnIsMouseOverChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //if (d is System.Windows.Controls.Border border && e.NewValue is bool isMouseOver)
            //{
            //}
        }

        #endregion //MouseOver

        #region Active

        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.RegisterAttached("IsActive", typeof(bool), typeof(Overlay), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions, OnIsActiveChanged));

        [Category($"{KeywordDictionary.CategoryKey.Overlay}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetIsActive(UIElement element)
        {
            return (bool)element.GetValue(IsActiveProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Overlay}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static void SetIsActive(UIElement element, bool value)
        {
            element.SetValue(IsActiveProperty, value);
        }

        private static void OnIsActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //if (d is System.Windows.Controls.Border border && e.NewValue is bool isActive)
            //{
            //}
        }

        #endregion //Active

        #region BackgroundVisible

        public static readonly DependencyProperty BackgroundVisibleProperty = DependencyProperty.RegisterAttached("BackgroundVisible", typeof(bool), typeof(Overlay), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.Overlay}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetBackgroundVisible(UIElement element)
        {
            return (bool)element.GetValue(BackgroundVisibleProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Overlay}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static void SetBackgroundVisible(UIElement element, bool value)
        {
            element.SetValue(BackgroundVisibleProperty, value);
        }

        #endregion //BackgroundVisible

        #region OutlineVisible

        public static readonly DependencyProperty OutlineVisibleProperty = DependencyProperty.RegisterAttached("OutlineVisible", typeof(bool), typeof(Overlay), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.Overlay}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetOutlineVisible(UIElement element)
        {
            return (bool)element.GetValue(OutlineVisibleProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Overlay}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static void SetOutlineVisible(UIElement element, bool value)
        {
            element.SetValue(OutlineVisibleProperty, value);
        }

        #endregion //OutlineVisible
    }
}
