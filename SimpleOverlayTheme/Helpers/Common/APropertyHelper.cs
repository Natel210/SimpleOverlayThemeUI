using System.Windows;

namespace SimpleOverlayTheme.Helpers.Common
{
    /// <summary>
    /// Provides utility methods for registering attached dependency properties with common metadata options
    /// used across WPF helper classes.
    /// </summary>
    public abstract class APropertyHelper
    {
        /// <summary>
        /// Defines the default <see cref="FrameworkPropertyMetadataOptions"/> 
        /// applied to all attached properties registered using this helper.
        /// It affects both rendering and layout measurements.
        /// </summary>
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions
            = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        /// <summary>
        /// Registers an attached <see cref="DependencyProperty"/> with the common metadata options.
        /// </summary>
        /// <param name="name">The name of the dependency property.</param>
        /// <param name="propertyType">The type of the property to register.</param>
        /// <param name="ownerType">The owner type that will register the property.</param>
        /// <returns>The registered <see cref="DependencyProperty"/> instance.</returns>
        protected static DependencyProperty GeneratorProperty(string name, Type propertyType, Type ownerType)
            => DependencyProperty.RegisterAttached(name, propertyType, ownerType, new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions));
    }
}