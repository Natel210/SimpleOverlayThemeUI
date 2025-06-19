using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace SimpleOverlayTheme.Helpers
{
    /// <summary>
    /// Provides an attached <see cref="CornerRadius"/> property for various WPF controls such as <br/>
    ///   <list type="bullet">
    ///     <item>
    ///       <term>Buttons</term>
    ///       <description> <see cref="Button"/>, <see cref="ToggleButton"/>, <see cref="RepeatButton"/></description>
    ///     </item>
    ///     <item>
    ///       <term>Boxs</term>
    ///       <description> <see cref="TextBox"/>, <see cref="CheckBox"/>, <see cref="GroupBox"/></description>
    ///     </item>
    ///   </list>
    /// Enables the application of rounded corners through styles or themes.
    /// </summary>
    public class CornerRadiusHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // CornerRadius
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>CornerRadius</c> attached dependency property. <br/>
        /// This property can be used to assign rounded corners to supported controls.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty
            = GeneratorProperty("CornerRadius",
                typeof(CornerRadius), typeof(CornerRadiusHelper), new CornerRadius(0));

        /// <summary> Gets the value of the <c>CornerRadius</c> attached property for the specified element. </summary>
        /// <param name="element">
        /// Use UIElement Type
        ///   <list type="bullet">
        ///     <item>
        ///       <term>Buttons</term>
        ///       <description> <see cref="Button"/>, <see cref="ToggleButton"/>, <see cref="RepeatButton"/></description>
        ///     </item>
        ///     <item>
        ///       <term>Boxs</term>
        ///       <description> <see cref="TextBox"/>, <see cref="CheckBox"/>, <see cref="GroupBox"/></description>
        ///     </item>
        ///   </list>
        /// </param>
        /// <returns>The <see cref="CornerRadius"/> value assigned to the element.</returns>
        [Browsable(true)]
        [Category(nameof(CornerRadiusHelper))]
        [DisplayName("CornerRadius")]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        [AttachedPropertyBrowsableForType(typeof(GroupBox))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static CornerRadius GetCornerRadius(UIElement element)
            => (CornerRadius)element.GetValue(CornerRadiusProperty);

        /// <summary> Sets the value of the <c>CornerRadius</c> attached property on the specified element. </summary>
        /// <param name="element">
        /// Use UIElement Type
        ///   <list type="bullet">
        ///     <item>
        ///       <term>Buttons</term>
        ///       <description> <see cref="Button"/>, <see cref="ToggleButton"/>, <see cref="RepeatButton"/></description>
        ///     </item>
        ///     <item>
        ///       <term>Boxs</term>
        ///       <description> <see cref="TextBox"/>, <see cref="CheckBox"/>, <see cref="GroupBox"/></description>
        ///     </item>
        ///   </list>
        /// </param>
        /// <param name="value">The <see cref="CornerRadius"/> value to apply.</param>
        public static void SetCornerRadius(UIElement element, CornerRadius value)
            => element.SetValue(CornerRadiusProperty, value);
    }
}
