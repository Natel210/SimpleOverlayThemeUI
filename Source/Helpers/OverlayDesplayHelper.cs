using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace SimpleOverlayTheme.Helpers
{
    /// <summary>
    /// Provides attached properties for controlling overlay-related visual effects such as background
    /// and outline visibility on supported UI elements, including <see cref="Border"/>, <see cref="CheckBox"/>, 
    /// <see cref="DataGrid"/>, and others.
    /// </summary>
    public class OverlayDesplayHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // Background
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>Background</c> attached property. <br/>
        /// Enables or disables the overlay background rendering for the target element.
        /// </summary>
        public static readonly DependencyProperty BackgroundProperty
            = GeneratorProperty("Background",
                typeof(bool), typeof(OverlayDesplayHelper));

        /// <summary> Gets whether the overlay background should be rendered for the specified element. </summary>
        [Browsable(true)]
        [Category(nameof(OverlayDesplayHelper))]
        [DisplayName("Background")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        [AttachedPropertyBrowsableForType(typeof(DataGridCell))]
        [AttachedPropertyBrowsableForType(typeof(DataGridColumnHeader))]
        [AttachedPropertyBrowsableForType(typeof(DataGridRowHeader))]
        [AttachedPropertyBrowsableForType(typeof(DataGridRow))]
        [AttachedPropertyBrowsableForType(typeof(DataGrid))]
        [AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetBackground(UIElement element)
            => (bool)element.GetValue(BackgroundProperty);

        /// <summary> Sets whether the overlay background should be rendered for the specified element. </summary>
        public static void SetBackground(UIElement element, bool value)
            => element.SetValue(BackgroundProperty, value);

        ////////////////////////////////////////
        // BackgroundAtDefault
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>BackgroundAtDefault</c> attached property. <br/>
        /// Specifies whether the background should be drawn even in the default (non-hovered, non-active) state.
        /// </summary>
        public static readonly DependencyProperty BackgroundAtDefaultProperty
            = GeneratorProperty("BackgroundAtDefault",
                typeof(bool), typeof(OverlayDesplayHelper));

        /// <summary> Gets whether the background should be rendered in the default state. </summary>
        [Browsable(true)]
        [Category(nameof(OverlayDesplayHelper))]
        [DisplayName("BackgroundAtDefault")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        [AttachedPropertyBrowsableForType(typeof(DataGridCell))]
        [AttachedPropertyBrowsableForType(typeof(DataGridColumnHeader))]
        [AttachedPropertyBrowsableForType(typeof(DataGridRowHeader))]
        [AttachedPropertyBrowsableForType(typeof(DataGridRow))]
        [AttachedPropertyBrowsableForType(typeof(DataGrid))]
        [AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetBackgroundAtDefault(UIElement element)
            => (bool)element.GetValue(BackgroundAtDefaultProperty);

        /// <summary> Sets whether the background should be rendered in the default state. </summary>
        public static void SetBackgroundAtDefault(UIElement element, bool value)
            => element.SetValue(BackgroundAtDefaultProperty, value);

        ////////////////////////////////////////
        // Outline
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>Outline</c> attached property. <br/>
        /// Enables or disables rendering of an outline around the target element.
        /// </summary>
        public static readonly DependencyProperty OutlineProperty
            = GeneratorProperty("Outline",
                typeof(bool), typeof(OverlayDesplayHelper));

        /// <summary> Gets whether an outline should be rendered around the specified element. </summary>
        [Browsable(true)]
        [Category(nameof(OverlayDesplayHelper))]
        [DisplayName("Outline")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        [AttachedPropertyBrowsableForType(typeof(DataGridCell))]
        [AttachedPropertyBrowsableForType(typeof(DataGridColumnHeader))]
        [AttachedPropertyBrowsableForType(typeof(DataGridRowHeader))]
        [AttachedPropertyBrowsableForType(typeof(DataGridRow))]
        [AttachedPropertyBrowsableForType(typeof(DataGrid))]
        [AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetOutline(UIElement element)
            => (bool)element.GetValue(OutlineProperty);

        /// <summary> Sets whether an outline should be rendered around the specified element. </summary>
        public static void SetOutline(UIElement element, bool value)
            => element.SetValue(OutlineProperty, value);

        ////////////////////////////////////////
        // OutlineAtDefault
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>OutlineAtDefault</c> attached property. <br/>
        /// Specifies whether the outline should be visible even in the default state.
        /// </summary>
        public static readonly DependencyProperty OutlineAtDefaultProperty
            = GeneratorProperty("OutlineAtDefault",
                typeof(bool), typeof(OverlayDesplayHelper));

        /// <summary> Gets whether the outline should be shown in the default (non-hovered, non-active) state. </summary>
        [Browsable(true)]
        [Category(nameof(OverlayDesplayHelper))]
        [DisplayName("OutlineAtDefault")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(CheckBox))]
        [AttachedPropertyBrowsableForType(typeof(DataGridCell))]
        [AttachedPropertyBrowsableForType(typeof(DataGridColumnHeader))]
        [AttachedPropertyBrowsableForType(typeof(DataGridRowHeader))]
        [AttachedPropertyBrowsableForType(typeof(DataGridRow))]
        [AttachedPropertyBrowsableForType(typeof(DataGrid))]
        [AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetOutlineAtDefault(UIElement element)
            => (bool)element.GetValue(OutlineAtDefaultProperty);

        /// <summary> Sets whether the outline should be shown in the default (non-hovered, non-active) state. </summary>
        public static void SetOutlineAtDefault(UIElement element, bool value)
            => element.SetValue(OutlineAtDefaultProperty, value);
    }
}
