using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace SimpleOverlayTheme.Helpers
{
    /// <summary>
    /// Provides attached properties for customizing the appearance of <see cref="CheckBox"/> controls,
    /// such as applying overlay brushes or toggling overlay rendering options.
    /// </summary>
    public class CheckBoxHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // CheckedMaskBrush
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>CheckedMaskBrush</c> attached dependency property. <br/>
        /// This brush is rendered as a visual mask when the <see cref="CheckBox"/> is checked.
        /// </summary>
        public static readonly DependencyProperty CheckedMaskBrushProperty
            = GeneratorProperty("CheckedMaskBrush",
                typeof(Brush), typeof(CheckBoxHelper));

        /// <summary> Gets the <c>CheckedMaskBrush</c> value for the specified UI element. </summary>
        /// <param name="element">The target UI element (typically a <see cref="CheckBox"/>).</param>
        /// <returns>The brush used as a visual mask when the CheckBox is checked.</returns>
        [Browsable(true)]
        [Category(nameof(CheckBoxHelper))]
        [DisplayName("CheckedMaskBrush")]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        public static Brush? GetCheckedMaskBrush(UIElement element)
            => (Brush)element.GetValue(CheckedMaskBrushProperty);

        /// <summary> Sets the <c>CheckedMaskBrush</c> value for the specified UI element. </summary>
        /// <param name="element">The target UI element (typically a <see cref="CheckBox"/>).</param>
        /// <param name="value">The brush to use as a visual mask when checked.</param>
        public static void SetCheckedMaskBrush(UIElement element, Brush? value)
            => element.SetValue(CheckedMaskBrushProperty, value);

        ////////////////////////////////////////
        // UseOverlayBackground
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>UseOverlayBackground</c> attached dependency property. <br/>
        /// When set to true, a custom overlay background will be applied to the <see cref="CheckBox"/>.
        /// </summary>
        public static readonly DependencyProperty UseOverlayBackgroundProperty
            = GeneratorProperty("UseOverlayBackground",
                typeof(bool), typeof(CheckBoxHelper));

        /// <summary> Gets whether the <see cref="CheckBox"/> should use an overlay background. </summary>
        /// <param name="element">The target UI element (typically a <see cref="CheckBox"/>).</param>
        /// <returns><c>true</c> if overlay background is enabled; otherwise, <c>false</c>.</returns>
        [Browsable(true)]
        [Category(nameof(CheckBoxHelper))]
        [DisplayName("UseOverlayBackground")]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        public static bool GetUseOverlayBackground(UIElement element)
            => (bool)element.GetValue(UseOverlayBackgroundProperty);

        /// <summary> Sets whether the <see cref="CheckBox"/> should use an overlay background. </summary>
        /// <param name="element">The target UI element (typically a <see cref="CheckBox"/>).</param>
        /// <param name="value"><c>true</c> to enable overlay background; otherwise, <c>false</c>.</param>
        public static void SetUseOverlayBackground(UIElement element, bool value)
            => element.SetValue(UseOverlayBackgroundProperty, value);

        ////////////////////////////////////////
        // UseOverlayMask
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>UseOverlayMask</c> attached dependency property. <br/>
        /// When enabled, an additional visual mask will be rendered on the <see cref="CheckBox"/> based on internal logic.
        /// </summary>
        public static readonly DependencyProperty UseOverlayMaskProperty
            = GeneratorProperty("UseOverlayMask",
                typeof(bool), typeof(CheckBoxHelper));

        /// <summary> Gets whether the <see cref="CheckBox"/> should render an overlay mask. </summary>
        /// <param name="element">The target UI element (typically a <see cref="CheckBox"/>).</param>
        /// <returns><c>true</c> if an overlay mask is applied; otherwise, <c>false</c>.</returns>
        [Browsable(true)]
        [Category(nameof(CheckBoxHelper))]
        [DisplayName("UseOverlayMask")]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        public static bool GetUseOverlayMask(UIElement element)
            => (bool)element.GetValue(UseOverlayMaskProperty);

        /// <summary> Sets whether the <see cref="CheckBox"/> should render an overlay mask. </summary>
        /// <param name="element">The target UI element (typically a <see cref="CheckBox"/>).</param>
        /// <param name="value"><c>true</c> to enable the overlay mask; otherwise, <c>false</c>.</param>
        public static void SetUseOverlayMask(UIElement element, bool value)
            => element.SetValue(UseOverlayMaskProperty, value);
    }
}
