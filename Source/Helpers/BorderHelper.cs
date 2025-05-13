using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SimpleOverlayTheme.Helpers
{
    /// <summary></summary>
    public class BorderHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // OverlayState
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty OverlayStateProperty
            = GeneratorProperty("OverlayState", typeof(EOverlayState), typeof(BorderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(BorderHelper))]
        [DisplayName("OverlayState")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static EOverlayState GetOverlayState(UIElement element)
            => (EOverlayState)element.GetValue(OverlayStateProperty);

        /// <summary></summary>
        public static void SetOverlayState(UIElement element, EOverlayState value)
            => element.SetValue(OverlayStateProperty, value);
    }
}
