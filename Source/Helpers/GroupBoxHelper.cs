using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace SimpleOverlayTheme.Helpers
{
    /// <summary>
    /// Provides attached properties for customizing the visual appearance of <see cref="GroupBox"/> headers,
    /// including an underline brush and underline thickness beneath the header text.
    /// </summary>
    public class GroupBoxHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // HeaderUnderLineBrush
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the attached property that specifies the brush used to draw an underline
        /// below the header text of a <see cref="GroupBox"/>.
        /// </summary>
        public static readonly DependencyProperty HeaderUnderLineBrushProperty
            = GeneratorProperty("HeaderUnderLineBrush",
                typeof(Brush), typeof(GroupBoxHelper));

        /// <summary> Gets the brush used to render the underline beneath the header of a <see cref="GroupBox"/>. </summary>
        /// <param name="element">The target <see cref="UIElement"/>, typically a <see cref="GroupBox"/>.</param>
        /// <returns>The <see cref="Brush"/> used for the underline, or <c>null</c> if not set.</returns>
        [Browsable(true)]
        [Category(nameof(GroupBoxHelper))]
        [DisplayName("HeaderUnderLineBrush")]
        [AttachedPropertyBrowsableForType(typeof(GroupBox))]
        public static Brush? GetHeaderUnderLineBrush(UIElement element)
            => (Brush)element.GetValue(HeaderUnderLineBrushProperty);

        /// <summary> Sets the brush used to render the underline beneath the header of a <see cref="GroupBox"/>. </summary>
        /// <param name="element">The target <see cref="UIElement"/>, typically a <see cref="GroupBox"/>.</param>
        /// <param name="value">The <see cref="Brush"/> to apply.</param>
        public static void SetHeaderUnderLineBrush(UIElement element, Brush? value)
            => element.SetValue(HeaderUnderLineBrushProperty, value);

        ////////////////////////////////////////
        // HeaderUnderLineHeight
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the attached property that specifies the height (thickness) of the underline
        /// rendered below the header text of a <see cref="GroupBox"/>.
        /// </summary>
        public static readonly DependencyProperty HeaderUnderLineHeightProperty
            = GeneratorProperty("HeaderUnderLineHeight",
                typeof(double), typeof(GroupBoxHelper), 1.0);

        /// <summary> Gets the height of the underline rendered beneath the header of a <see cref="GroupBox"/>. </summary>
        /// <param name="element">The target <see cref="UIElement"/>, typically a <see cref="GroupBox"/>.</param>
        /// <returns>The height (in device-independent units) of the underline. Default is 1.0.</returns>
        [Browsable(true)]
        [Category(nameof(GroupBoxHelper))]
        [DisplayName("HeaderUnderLineHeight")]
        [AttachedPropertyBrowsableForType(typeof(GroupBox))]
        public static double GetHeaderUnderLineHeight(UIElement element)
            => (double)element.GetValue(HeaderUnderLineHeightProperty);

        /// <summary> Sets the height of the underline rendered beneath the header of a <see cref="GroupBox"/>. </summary>
        /// <param name="element">The target <see cref="UIElement"/>, typically a <see cref="GroupBox"/>.</param>
        /// <param name="value">The height (in device-independent units) to apply.</param>
        public static void SetHeaderUnderLineHeight(UIElement element, double value)
            => element.SetValue(HeaderUnderLineHeightProperty, value);

    }
}
