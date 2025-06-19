using System.Windows;

namespace SimpleOverlayTheme.Helpers
{
    /// <summary>
    /// Provides utility methods for registering attached dependency properties with common metadata options
    /// used across WPF helper classes.
    /// </summary>
    public abstract class APropertyHelper
    {
        /// <summary>
        /// Defines the default <see cref="FrameworkPropertyMetadataOptions"/>
        /// applied to all attached properties registered using this helper. <br/>
        /// It affects both rendering and layout measurements.
        /// </summary>
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions
            = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        /// <summary>
        /// Registers an attached <see cref="DependencyProperty"/> with the specified name, type, and owner,
        /// and infers an appropriate default value based on the property type.
        /// </summary>
        /// <param name="name">The name of the dependency property to register.</param>
        /// <param name="propertyType">The CLR type of the dependency property.</param>
        /// <param name="ownerType">The owner type that defines and registers the dependency property.</param>
        /// <returns>The registered <see cref="DependencyProperty"/> instance.</returns>
        /// <remarks>
        /// The default value is inferred as follows:
        /// <list type="bullet">
        /// <item><description>If the type is an enum, its first defined value is used.</description></item>
        /// <item><description>If the type is another value type, <c>Activator.CreateInstance</c> is used.</description></item>
        /// <item><description>If the type is a reference type, <c>null</c> is used.</description></item>
        /// </list>
        /// </remarks>
        protected static DependencyProperty GeneratorProperty(string name, Type propertyType, Type ownerType)
        {
            object? defaultValue;
            if (propertyType.IsValueType)
            {
                if (propertyType.IsEnum)
                    defaultValue = Enum.GetValues(propertyType).GetValue(0);
                else
                    defaultValue = Activator.CreateInstance(propertyType);
            }
            else
                defaultValue = null;

            return GeneratorProperty(name, propertyType, ownerType, defaultValue);
        }

        /// <summary>
        /// Registers an attached <see cref="DependencyProperty"/> with the specified name, type, owner,
        /// and a specified default value, validating type compatibility.
        /// </summary>
        /// <param name="name">The name of the dependency property to register.</param>
        /// <param name="propertyType">The CLR type of the dependency property.</param>
        /// <param name="ownerType">The owner type that defines and registers the dependency property.</param>
        /// <param name="defaultValue">The default value to associate with the property.</param>
        /// <returns>The registered <see cref="DependencyProperty"/> instance.</returns>
        /// <exception cref="InvalidCastException">
        /// Thrown if the provided default value is not assignable to the specified property type.
        /// </exception>
        protected static DependencyProperty GeneratorProperty(string name, Type propertyType, Type ownerType, object? defaultValue)
            => GeneratorProperty(name, propertyType, ownerType, defaultValue, null);


        /// <summary>
        /// Registers an attached <see cref="DependencyProperty"/> with the specified name, type, owner,
        /// and a specified default value, validating type compatibility.
        /// </summary>
        /// <param name="name">The name of the dependency property to register.</param>
        /// <param name="propertyType">The CLR type of the dependency property.</param>
        /// <param name="ownerType">The owner type that defines and registers the dependency property.</param>
        /// <param name="defaultValue">The default value to associate with the property.</param>
        /// <param name="propertyChangedCallback">Value changed Callback Func.</param>
        /// <returns>The registered <see cref="DependencyProperty"/> instance.</returns>
        /// <exception cref="InvalidCastException">
        /// Thrown if the provided default value is not assignable to the specified property type.
        /// </exception>
        protected static DependencyProperty GeneratorProperty(string name, Type propertyType, Type ownerType, object? defaultValue, PropertyChangedCallback? propertyChangedCallback)
        {
            if (defaultValue != null && !propertyType.IsAssignableFrom(defaultValue.GetType()))
                throw new InvalidCastException($"Default value of type '{defaultValue.GetType()}' cannot be assigned to property type '{propertyType}'.");

            if (propertyChangedCallback is null)
                return DependencyProperty.RegisterAttached(name, propertyType, ownerType,
                    new FrameworkPropertyMetadata(defaultValue, _frameworkPropertyMetadataOptions));
            else
                return DependencyProperty.RegisterAttached(name, propertyType, ownerType,
                    new FrameworkPropertyMetadata(defaultValue, _frameworkPropertyMetadataOptions, propertyChangedCallback));
        }
    }
}