using SimpleOverlayTheme.Helpers.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

/// <summary></summary>
namespace SimpleOverlayTheme.Helpers
{
    /// <summary></summary>
    public class GroupBoxHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // CornerRadius
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty CornerRadiusProperty
            = GeneratorProperty("CornerRadius",
                typeof(CornerRadius), typeof(GroupBoxHelper), new CornerRadius(0));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(GroupBoxHelper))]
        [DisplayName("CornerRadius")]
        [AttachedPropertyBrowsableForType(typeof(GroupBox))]
        public static CornerRadius GetCornerRadius(UIElement element)
            => (CornerRadius)element.GetValue(CornerRadiusProperty);

        /// <summary></summary>
        public static void SetCornerRadius(UIElement element, CornerRadius value)
            => element.SetValue(CornerRadiusProperty, value);

        ////////////////////////////////////////
        // HeaderUnderLineBrush
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty HeaderUnderLineBrushProperty
            = GeneratorProperty("HeaderUnderLineBrush",
                typeof(Brush), typeof(GroupBoxHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(GroupBoxHelper))]
        [DisplayName("HeaderUnderLineBrush")]
        [AttachedPropertyBrowsableForType(typeof(GroupBox))]
        public static Brush GetHeaderUnderLineBrush(UIElement element)
            => (Brush)element.GetValue(HeaderUnderLineBrushProperty);

        /// <summary></summary>
        public static void SetHeaderUnderLineBrush(UIElement element, Brush value)
            => element.SetValue(HeaderUnderLineBrushProperty, value);

        ////////////////////////////////////////
        // HeaderUnderLineHeight
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty HeaderUnderLineHeightProperty
            = GeneratorProperty("HeaderUnderLineHeight",
                typeof(double), typeof(GroupBoxHelper), 1.0);

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(GroupBoxHelper))]
        [DisplayName("HeaderUnderLineHeight")]
        [AttachedPropertyBrowsableForType(typeof(GroupBox))]
        public static double GetHeaderUnderLineHeight(UIElement element)
            => (double)element.GetValue(HeaderUnderLineHeightProperty);

        /// <summary></summary>
        public static void SetHeaderUnderLineHeight(UIElement element, double value)
            => element.SetValue(HeaderUnderLineHeightProperty, value);

    }
}
