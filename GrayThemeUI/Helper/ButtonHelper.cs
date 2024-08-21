using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GrayThemeUI.Helper
{
    public static class ButtonHelper
    {
        public static readonly DependencyProperty DefaultMaskProperty =
            DependencyProperty.RegisterAttached(
                "DefaultMask",
                typeof(ImageBrush),
                typeof(ButtonHelper),
                new PropertyMetadata(null, OnDefaultMaskChanged));

        public static ImageBrush GetDefaultMask(UIElement element)
        {
            return (ImageBrush)element.GetValue(DefaultMaskProperty);
        }

        public static void SetDefaultMask(UIElement element, ImageBrush value)
        {
            element.SetValue(DefaultMaskProperty, value);
        }
        private static void OnDefaultMaskChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Button button && e.NewValue is ImageBrush newImageBrush)
            {

                // OpacityMask 속성에 ImageBrush를 적용
                //button.OpacityMask = newImageBrush;
            }
        }
    }

    public static class ToggleButtonHelper
    {
        public static readonly DependencyProperty DefaultMaskProperty =
            DependencyProperty.RegisterAttached("DefaultMask", typeof(ImageBrush),
                typeof(ToggleButtonHelper), new PropertyMetadata(null, OnDefaultMaskChanged));

        public static ImageBrush GetDefaultMask(UIElement element)
        {
            return (ImageBrush)element.GetValue(DefaultMaskProperty);
        }

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

        public static readonly DependencyProperty CheckedMaskProperty =
            DependencyProperty.RegisterAttached("CheckedMask", typeof(ImageBrush),
        typeof(ToggleButtonHelper), new PropertyMetadata(null, OnCheckedMaskChanged));

        public static ImageBrush GetCheckedMask(UIElement element)
        {
            return (ImageBrush)element.GetValue(CheckedMaskProperty);
        }

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
    }
}
