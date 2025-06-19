using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SimpleOverlayTheme.Converters
{
    /// <summary>
    /// Converts a <see cref="SolidColorBrush"/> by multiplying its alpha (opacity) channel 
    /// by a specified factor passed through the converter parameter. <br/>
    /// This is useful when you want to dynamically adjust the transparency of a brush.
    /// </summary>
    public class AlphaMultiplyConverter : IValueConverter
    {
        /// <summary> Multiplies the alpha value of the provided <see cref="SolidColorBrush"/> by the given parameter. </summary>
        /// <param name="value">The input value, expected to be a <see cref="SolidColorBrush"/>.</param>
        /// <param name="targetType">The target type of the binding (ignored in this implementation).</param>
        /// <param name="parameter">A string or numeric value representing the multiplier for the alpha channel (e.g., 0.5).</param>
        /// <param name="culture">The culture info (not used in this converter).</param>
        /// <returns>
        /// A new <see cref="SolidColorBrush"/> with modified alpha value, 
        /// or the original value if the input is invalid.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush brush && parameter != null && double.TryParse(parameter.ToString(), out double factor))
            {
                var color = brush.Color;
                return new SolidColorBrush(Color.FromArgb((byte)(color.A * factor), color.R, color.G, color.B));
            }
            return value;
        }

        /// <summary> Not implemented. This converter does not support converting back. </summary>
        /// <param name="value">The value to convert back (not used).</param>
        /// <param name="targetType">The target type (not used).</param>
        /// <param name="parameter">The converter parameter (not used).</param>
        /// <param name="culture">The culture info (not used).</param>
        /// <returns>This method always throws <see cref="NotImplementedException"/>.</returns>
        /// <exception cref="NotImplementedException">Always thrown because ConvertBack is not supported.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }

}