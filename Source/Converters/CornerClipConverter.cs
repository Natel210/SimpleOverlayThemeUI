using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;

namespace SimpleOverlayTheme.Converters
{
    /// <summary>
    /// Converts a set of values including width, height, and corner radius into a <see cref="RectangleGeometry"/>
    /// that can be used for clipping rounded corners on visual elements.
    /// </summary>
    public class CornerClipConverter : IMultiValueConverter
    {
        /// <summary>
        /// Converts an array of values representing width, height, and <see cref="CornerRadius"/> 
        /// into a <see cref="RectangleGeometry"/> for UI clipping.
        /// </summary>
        /// <param name="values">
        /// An array of three values:
        /// <list type="number">
        /// <item><description><see cref="Double"/>: The width of the rectangle.</description></item>
        /// <item><description><see cref="Double"/>: The height of the rectangle.</description></item>
        /// <item><description><see cref="CornerRadius"/>: The corner radius to apply.</description></item>
        /// </list>
        /// </param>
        /// <param name="targetType">The type of the binding target property (typically <see cref="Geometry"/>).</param>
        /// <param name="parameter">Optional parameter (not used).</param>
        /// <param name="culture">The culture to use in the converter (not used).</param>
        /// <returns>
        /// A <see cref="RectangleGeometry"/> with the specified dimensions and rounded corners,
        /// or <c>null</c> if the inputs are invalid.
        /// </returns>
        public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 3 ||
                values[0] is not double width ||
                values[1] is not double height ||
                values[2] is not CornerRadius radius)
                return null;

            return new RectangleGeometry
            {
                Rect = new Rect(0, 0, width, height),
                RadiusX = radius.TopLeft,
                RadiusY = radius.BottomRight // usually the same value
            };
        }

        /// <summary>
        /// Not implemented. This converter does not support converting back from geometry to size or radius.
        /// </summary>
        /// <param name="value">The value produced by the binding target (not used).</param>
        /// <param name="targetTypes">The array of target types (not used).</param>
        /// <param name="parameter">Optional parameter (not used).</param>
        /// <param name="culture">The culture to use (not used).</param>
        /// <returns>This method always throws <see cref="NotImplementedException"/>.</returns>
        /// <exception cref="NotImplementedException">Always thrown because ConvertBack is not supported.</exception>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}