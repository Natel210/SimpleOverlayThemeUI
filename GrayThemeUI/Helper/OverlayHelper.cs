using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls.Primitives;

namespace GrayThemeUI.Helper
{
    public class OverlayHelper
    {
        public static readonly DependencyProperty IsDisableProperty
            =  DependencyProperty.RegisterAttached(
                "IsDisable",
                typeof(bool),
                typeof(OverlayHelper),
                new FrameworkPropertyMetadata(
                    false,
                    FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure,
                    OnIsDisableChanged));

        [Category("GrayThemeUI.Overlay.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static bool GetIsDisable(UIElement element)
        {
            return (bool)element.GetValue(IsDisableProperty);
        }

        [Category("GrayThemeUI.Overlay.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
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

        public static readonly DependencyProperty IsDefaultProperty
            = DependencyProperty.RegisterAttached(
                "IsDefault",
                typeof(bool),
                typeof(OverlayHelper),
                new FrameworkPropertyMetadata(
                    false,
                    FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure,
                    OnIsDefaultChanged));


        [Category("GrayThemeUI.Overlay.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static bool GetIsDefault(UIElement element)
        {
            return (bool)element.GetValue(IsDefaultProperty);
        }

        [Category("GrayThemeUI.Overlay.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
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

        //Disable

        public static readonly DependencyProperty IsMouseOverProperty
            = DependencyProperty.RegisterAttached(
                "IsMouseOver",
                typeof(bool),
                typeof(OverlayHelper),
                new FrameworkPropertyMetadata(
                    false,
                    FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure,
                    OnIsMouseOverChanged));

        [Category("GrayThemeUI.Overlay.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static bool GetIsMouseOver(UIElement element)
        {
            return (bool)element.GetValue(IsMouseOverProperty);
        }

        [Category("GrayThemeUI.Overlay.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
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


        public static readonly DependencyProperty IsActiveProperty
            = DependencyProperty.RegisterAttached(
                "IsActive",
                typeof(bool),
                typeof(OverlayHelper),
                new FrameworkPropertyMetadata(
                    false,
                    FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure,
                    OnIsActiveChanged));

        [Category("GrayThemeUI.Overlay.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static bool GetIsActive(UIElement element)
        {
            return (bool)element.GetValue(IsActiveProperty);
        }

        [Category("GrayThemeUI.Overlay.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
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
    }
}
