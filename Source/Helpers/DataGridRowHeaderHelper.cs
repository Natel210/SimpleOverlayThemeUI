using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace SimpleOverlayTheme.Helpers
{
    /// <summary>
    /// Provides attached properties for customizing the behavior and layout of <see cref="DataGridRowHeader"/> elements,
    /// including the ability to control the row header width.
    /// </summary>
    public class DataGridRowHeaderHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // HeaderWidth
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the attached <c>HeaderWidth</c> property. <br/>
        /// This property allows specifying a fixed width for row headers in a <see cref="DataGrid"/>.
        /// </summary>
        public static readonly DependencyProperty HeaderWidthProperty
            = GeneratorProperty("HeaderWidth",
                typeof(double), typeof(DataGridRowHeaderHelper), 20.0);

        /// <summary> Gets the custom width value set for the <see cref="DataGridRowHeader"/> of the specified element. </summary>
        /// <param name="element">The target <see cref="UIElement"/>, typically a <see cref="DataGrid"/> or <see cref="DataGridRowHeader"/>.</param>
        /// <returns>The width (in device-independent units) to apply to the row header. Default is 20.0.</returns>
        [Browsable(true)]
        [Category(nameof(DataGridRowHeaderHelper))]
        [DisplayName("HeaderWidth")]
        [AttachedPropertyBrowsableForType(typeof(DataGrid))]
        [AttachedPropertyBrowsableForType(typeof(DataGridRowHeader))]
        public static double GetHeaderWidth(UIElement element)
            => (double)element.GetValue(HeaderWidthProperty);

        /// <summary> Sets the custom width value for the <see cref="DataGridRowHeader"/> of the specified element. </summary>
        /// <param name="element">The target <see cref="UIElement"/>, typically a <see cref="DataGrid"/> or <see cref="DataGridRowHeader"/>.</param>
        /// <param name="value">The width (in device-independent units) to apply to the row header.</param>
        public static void SetHeaderWidth(UIElement element, double value)
            => element.SetValue(HeaderWidthProperty, value);
    }
}
