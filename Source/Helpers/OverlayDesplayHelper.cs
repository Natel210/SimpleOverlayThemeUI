using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace SimpleOverlayTheme.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class OverlayDesplayHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // Background
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty BackgroundProperty
            = GeneratorProperty("Background",
                typeof(bool), typeof(OverlayDesplayHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(OverlayDesplayHelper))]
        [DisplayName("Background")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
        [AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
        public static bool GetBackground(UIElement element)
            => (bool)element.GetValue(BackgroundProperty);

        /// <summary></summary>
        public static void SetBackground(UIElement element, bool value)
            => element.SetValue(BackgroundProperty, value);

        ////////////////////////////////////////
        // BackgroundAtDefault
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty BackgroundAtDefaultProperty
            = GeneratorProperty("BackgroundAtDefault",
                typeof(bool), typeof(OverlayDesplayHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(OverlayDesplayHelper))]
        [DisplayName("BackgroundAtDefault")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
        [AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
        public static bool GetBackgroundAtDefault(UIElement element)
            => (bool)element.GetValue(BackgroundAtDefaultProperty);

        /// <summary></summary>
        public static void SetBackgroundAtDefault(UIElement element, bool value)
            => element.SetValue(BackgroundAtDefaultProperty, value);

        ////////////////////////////////////////
        // Outline
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty OutlineProperty
            = GeneratorProperty("Outline",
                typeof(bool), typeof(OverlayDesplayHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(OverlayDesplayHelper))]
        [DisplayName("Outline")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
        [AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
        public static bool GetOutline(UIElement element)
            => (bool)element.GetValue(OutlineProperty);

        /// <summary></summary>
        public static void SetOutline(UIElement element, bool value)
            => element.SetValue(OutlineProperty, value);

        ////////////////////////////////////////
        // OutlineAtDefault
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty OutlineAtDefaultProperty
            = GeneratorProperty("OutlineAtDefault",
                typeof(bool), typeof(OverlayDesplayHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(OverlayDesplayHelper))]
        [DisplayName("OutlineAtDefault")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
        [AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
        public static bool GetOutlineAtDefault(UIElement element)
            => (bool)element.GetValue(OutlineAtDefaultProperty);

        /// <summary></summary>
        public static void SetOutlineAtDefault(UIElement element, bool value)
            => element.SetValue(OutlineAtDefaultProperty, value);
    }
}
