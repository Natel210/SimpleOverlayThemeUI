using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace GrayThemeUI.Helper
{
    public static class BorderHelper
    {

    }

    public static class OverlayBorderHelper
    {
        public static readonly DependencyProperty IsDefaultProperty = DependencyProperty.RegisterAttached("GrayThemeUI.OverlayBorder.Overlay.IsDefault", typeof(bool), typeof(OverlayBorderHelper), new PropertyMetadata(false, OnIsDefaultChanged));

        public static bool GetIsDefault(UIElement element)
        {
            return (bool)element.GetValue(IsDefaultProperty);
        }

        public static void SetIsDefault(UIElement element, bool value)
        {
            element.SetValue(IsDefaultProperty, value);
        }

        private static void OnIsDefaultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Border border && e.NewValue is bool isDefault)
            {
            }
        }

        //Disable

        public static readonly DependencyProperty IsMouseOverProperty = DependencyProperty.RegisterAttached("GrayThemeUI.OverlayBorder.Overlay.IsMouseOver", typeof(bool), typeof(OverlayBorderHelper), new PropertyMetadata(false, OnIsMouseOverChanged));

        public static bool GetIsMouseOver(UIElement element)
        {
            return (bool)element.GetValue(IsMouseOverProperty);
        }

        public static void SetIsMouseOver(UIElement element, bool value)
        {
            element.SetValue(IsMouseOverProperty, value);
        }

        private static void OnIsMouseOverChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Border border && e.NewValue is bool isMouseOver)
            {
                //if (isPressed)
                //{
                //    border.Opacity = 0.5; // 예: 클릭된 상태에서 불투명도 변경
                //}
                //else
                //{
                //    border.Opacity = 1.0; // 예: 클릭되지 않은 상태로 돌아갈 때 불투명도 복원
                //}
            }
        }


        public static readonly DependencyProperty IsFocusedProperty = DependencyProperty.RegisterAttached("GrayThemeUI.OverlayBorder.Overlay.IsFocused", typeof(bool),typeof(OverlayBorderHelper), new PropertyMetadata(false, OnIsFocusedChanged));

        public static bool GetIsFocused(UIElement element)
        {
            return (bool)element.GetValue(IsFocusedProperty);
        }

        public static void SetIsFocused(UIElement element, bool value)
        {
            element.SetValue(IsFocusedProperty, value);
        }

        private static void OnIsFocusedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Border border && e.NewValue is bool isFocused)
            {
            }
        }
    }
}
