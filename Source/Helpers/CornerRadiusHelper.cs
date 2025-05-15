using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace SimpleOverlayTheme.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class CornerRadiusHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // CornerRadius
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty CornerRadiusProperty
            = GeneratorProperty("CornerRadius",
                typeof(CornerRadius), typeof(CornerRadiusHelper), new CornerRadius(0));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(CornerRadiusHelper))]
        [DisplayName("CornerRadius")]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        [AttachedPropertyBrowsableForType(typeof(GroupBox))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static CornerRadius GetCornerRadius(UIElement element)
            => (CornerRadius)element.GetValue(CornerRadiusProperty);

        /// <summary></summary>
        public static void SetCornerRadius(UIElement element, CornerRadius value)
            => element.SetValue(CornerRadiusProperty, value);
    }
}
