using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;

namespace GrayThemeUI.Helper
{
    public class OverlayBorderHelper
    {
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;
        private const string _category = "GrayThemeUI.Overlay.Border";

        #region Disable

        public static readonly DependencyProperty IsDisableProperty = DependencyProperty.RegisterAttached("IsDisable", typeof(bool), typeof(OverlayBorderHelper), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions, OnIsDisableChanged));

        [Category($"{_category}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetIsDisable(UIElement element)
        {
            return (bool)element.GetValue(IsDisableProperty);
        }

        [Category($"{_category}")]
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

        public static readonly DependencyProperty IsDefaultProperty = DependencyProperty.RegisterAttached("IsDefault", typeof(bool), typeof(OverlayBorderHelper), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions, OnIsDefaultChanged));

        [Category($"{_category}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetIsDefault(UIElement element)
        {
            return (bool)element.GetValue(IsDefaultProperty);
        }

        [Category($"{_category}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static void SetIsDefault(UIElement element, bool value)
        {
            element.SetValue(IsDefaultProperty, value);
        }

        private static void OnIsDefaultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //if (d is Border border && e.NewValue is bool isDefault)
            //{
            //}
        }

        #endregion //Default

        #region MouseOver

        public static readonly DependencyProperty IsMouseOverProperty = DependencyProperty.RegisterAttached("IsMouseOver", typeof(bool), typeof(OverlayBorderHelper), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions, OnIsMouseOverChanged));

        [Category($"{_category}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetIsMouseOver(UIElement element)
        {
            return (bool)element.GetValue(IsMouseOverProperty);
        }

        [Category($"{_category}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static void SetIsMouseOver(UIElement element, bool value)
        {
            element.SetValue(IsMouseOverProperty, value);
        }

        private static void OnIsMouseOverChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Border border && e.NewValue is bool isMouseOver)
            {
            }
        }

        #endregion //MouseOver

        #region Active

        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.RegisterAttached("IsActive", typeof(bool), typeof(OverlayBorderHelper), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions, OnIsActiveChanged));

        [Category($"{_category}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetIsActive(UIElement element)
        {
            return (bool)element.GetValue(IsActiveProperty);
        }

        [Category($"{_category}")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static void SetIsActive(UIElement element, bool value)
        {
            element.SetValue(IsActiveProperty, value);
        }

        private static void OnIsActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //if (d is Border border && e.NewValue is bool isActive)
            //{
            //}
        }

        #endregion //Active
    }
}
