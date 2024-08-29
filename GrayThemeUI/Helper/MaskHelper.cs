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

namespace GrayThemeUI.Helper
{
    public class MaskHelper
    {
        public static readonly DependencyProperty DefaultMaskProperty = DependencyProperty.RegisterAttached("DefaultMask", typeof(ImageBrush), typeof(MaskHelper), new PropertyMetadata(null, OnDefaultMaskChanged));

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static ImageBrush GetDefaultMask(UIElement element)
        {
            return (ImageBrush)element.GetValue(DefaultMaskProperty);
        }

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static void SetDefaultMask(UIElement element, ImageBrush value)
        {
            element.SetValue(DefaultMaskProperty, value);
        }

        private static void OnDefaultMaskChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Button button && e.NewValue is ImageBrush newImageBrush)
            {
                // OpacityMask 속성에 ImageBrush를 적용
                button.OpacityMask = newImageBrush;
            }
        }

        public static readonly DependencyProperty CheckedMaskProperty = DependencyProperty.RegisterAttached("CheckedMask", typeof(ImageBrush), typeof(MaskHelper), new PropertyMetadata(null, OnCheckedMaskChanged));

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static ImageBrush GetCheckedMask(UIElement element)
        {
            return (ImageBrush)element.GetValue(CheckedMaskProperty);
        }

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static void SetCheckedMask(UIElement element, ImageBrush value)
        {
            element.SetValue(CheckedMaskProperty, value);
        }

        private static void OnCheckedMaskChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Button button && e.NewValue is ImageBrush newImageBrush)
            {
                // OpacityMask 속성에 ImageBrush를 적용
                button.OpacityMask = newImageBrush;
            }
        }

        public static readonly DependencyProperty Background_Overlay_VisibilityProperty = DependencyProperty.RegisterAttached("Background_Overlay_Visibility", typeof(Visibility), typeof(MaskHelper), new PropertyMetadata(Visibility.Hidden, OnBackground_Overlay_VisibilityChanged));

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static Visibility GetBackground_Overlay_Visibility(UIElement element)
        {
            return (Visibility)element.GetValue(Background_Overlay_VisibilityProperty);
        }

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static void SetBackground_Overlay_Visibility(UIElement element, Visibility value)
        {
            element.SetValue(Background_Overlay_VisibilityProperty, value);
        }

        private static void OnBackground_Overlay_VisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public static readonly DependencyProperty Background_Overlay_Outline_ThicknessProperty =            DependencyProperty.RegisterAttached("Background_Overlay_Outline_Thickness", typeof(Thickness), typeof(MaskHelper), new PropertyMetadata(new Thickness(0.0), OnBackground_Overlay_Outline_ThicknessChanged));

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static Thickness GetBackground_Overlay_Outline_Thickness(UIElement element)
        {
            return (Thickness)element.GetValue(Background_Overlay_Outline_ThicknessProperty);
        }

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static void SetBackground_Overlay_Outline_Thickness(UIElement element, Thickness value)
        {
            element.SetValue(Background_Overlay_Outline_ThicknessProperty, value);
        }

        private static void OnBackground_Overlay_Outline_ThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
