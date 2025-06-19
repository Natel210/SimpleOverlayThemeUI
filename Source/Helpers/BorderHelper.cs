using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SimpleOverlayTheme.Helpers
{
    /// <summary> Provides attached properties for <see cref="Border"/> controls, including support for custom overlay state handling. </summary>
    public class BorderHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // OverlayState
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>OverlayState</c> attached dependency property. <br/>
        /// This property is used to associate a custom <see cref="EOverlayState"/> value with a <see cref="Border"/>.
        /// </summary>
        public static readonly DependencyProperty OverlayStateProperty
            = GeneratorProperty("OverlayState", typeof(EOverlayState), typeof(BorderHelper));

        /// <summary> Gets the <see cref="EOverlayState"/> value associated with the specified <see cref="UIElement"/>. </summary>
        /// <param name="element">The UI element (typically a <see cref="Border"/>) from which to retrieve the overlay state.</param>
        /// <returns>The current <see cref="EOverlayState"/> value of the element.</returns>
        [Browsable(true)]
        [Category(nameof(BorderHelper))]
        [DisplayName("OverlayState")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static EOverlayState GetOverlayState(UIElement element)
            => (EOverlayState)element.GetValue(OverlayStateProperty);

        /// <summary> Sets the <see cref="EOverlayState"/> value on the specified <see cref="UIElement"/>. </summary>
        /// <param name="element">The UI element (typically a <see cref="Border"/>) on which to set the overlay state.</param>
        /// <param name="value">The <see cref="EOverlayState"/> value to assign.</param>
        public static void SetOverlayState(UIElement element, EOverlayState value)
            => element.SetValue(OverlayStateProperty, value);
    }
}
