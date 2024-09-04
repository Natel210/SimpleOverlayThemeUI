﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using GrayThemeUI.CustomControl;

namespace GrayThemeUI.Helper
{
    public class MaskHelper
    {
        

        public static readonly DependencyProperty Background_Overlay_VisibilityProperty
            = DependencyProperty.RegisterAttached("Background_Overlay_Visibility", typeof(Visibility), typeof(MaskHelper),
                new FrameworkPropertyMetadata(Visibility.Collapsed, _frameworkPropertyMetadataOptions));

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        [AttachedPropertyBrowsableForType(typeof(ComboBox))]
        public static Visibility GetBackground_Overlay_Visibility(UIElement element)
        {
            return (Visibility)element.GetValue(Background_Overlay_VisibilityProperty);
        }

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        [AttachedPropertyBrowsableForType(typeof(ComboBox))]
        public static void SetBackground_Overlay_Visibility(UIElement element, Visibility value)
        {
            element.SetValue(Background_Overlay_VisibilityProperty, value);
        }

        public static readonly DependencyProperty Background_Overlay_Outline_ThicknessProperty
            = DependencyProperty.RegisterAttached("Background_Overlay_Outline_Thickness", typeof(Thickness), typeof(MaskHelper),
                new FrameworkPropertyMetadata(new Thickness(0.0), _frameworkPropertyMetadataOptions));

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        [AttachedPropertyBrowsableForType(typeof(ComboBox))]
        public static Thickness GetBackground_Overlay_Outline_Thickness(UIElement element)
        {
            return (Thickness)element.GetValue(Background_Overlay_Outline_ThicknessProperty);
        }

        [Category("GrayThemeUI.Mask.Helper")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        [AttachedPropertyBrowsableForType(typeof(ComboBox))]
        public static void SetBackground_Overlay_Outline_Thickness(UIElement element, Thickness value)
        {
            element.SetValue(Background_Overlay_Outline_ThicknessProperty, value);
        }


    }
}
