using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace SimpleOverlayTheme.Helpers
{
    /// <summary>
    /// Provides attached properties for configuring overlay image masks corresponding <br/>
    /// to UI states such as default, active, disabled, and mouse-over. <br/>
    /// These properties are primarily used for applying <see cref="ImageBrush"/> masks
    /// on elements like <see cref="Border"/> to reflect overlay styling.
    /// </summary>
    public class OverlayMaskImageHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // DefaultImageMask
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>DefaultImageMask</c> attached property. <br/>
        /// Specifies the <see cref="ImageBrush"/> used as the default background mask.
        /// </summary>
        public static readonly DependencyProperty DefaultImageMaskProperty
            = GeneratorProperty("DefaultImageMask",
                typeof(ImageBrush), typeof(OverlayMaskImageHelper));

        /// <summary> Gets the default overlay mask brush for the specified element. </summary>
        [Browsable(true)]
        [Category(nameof(OverlayMaskImageHelper))]
        [DisplayName("DefaultImageMask")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static ImageBrush? GetDefaultImageMask(UIElement element)
            => (ImageBrush)element.GetValue(DefaultImageMaskProperty);

        /// <summary> Sets the default overlay mask brush for the specified element. </summary>
        public static void SetDefaultImageMask(UIElement element, ImageBrush? value)
            => element.SetValue(DefaultImageMaskProperty, value);

        ////////////////////////////////////////
        // UseActiveImageMask
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>UseActiveImageMask</c> attached property. <br/>
        /// Indicates whether the active state overlay mask should be used.
        /// </summary>
        public static readonly DependencyProperty UseActiveImageMaskProperty
            = GeneratorProperty("UseActiveImageMask",
                typeof(bool), typeof(OverlayMaskImageHelper));

        /// <summary> Gets whether the active image mask should be used. </summary>
        [Browsable(true)]
        [Category(nameof(OverlayMaskImageHelper))]
        [DisplayName("UseActiveImageMask")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetUseActiveImageMask(UIElement element)
            => (bool)element.GetValue(UseActiveImageMaskProperty);

        /// <summary> Sets whether the active image mask should be used. </summary>
        public static void SetUseActiveImageMask(UIElement element, bool value)
            => element.SetValue(UseActiveImageMaskProperty, value);

        ////////////////////////////////////////
        // ActiveImageMask
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>ActiveImageMask</c> attached property. <br/>
        /// Specifies the <see cref="ImageBrush"/> to use when the element is in the active state.
        /// </summary>
        public static readonly DependencyProperty ActiveImageMaskProperty
            = GeneratorProperty("ActiveImageMask",
                typeof(ImageBrush), typeof(OverlayMaskImageHelper));

        /// <summary> Gets the image mask brush for the active state. </summary>
        [Browsable(true)]
        [Category(nameof(OverlayMaskImageHelper))]
        [DisplayName("ActiveImageMask")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static ImageBrush? GetActiveImageMask(UIElement element)
            => (ImageBrush)element.GetValue(ActiveImageMaskProperty);

        /// <summary> Sets the image mask brush for the active state. </summary>
        public static void SetActiveImageMask(UIElement element, ImageBrush? value)
            => element.SetValue(ActiveImageMaskProperty, value);

        ////////////////////////////////////////
        // UseDisableImageMask
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>UseDisableImageMask</c> attached property. <br/>
        /// Indicates whether the disabled state image mask should be used.
        /// </summary>
        public static readonly DependencyProperty UseDisableImageMaskProperty
            = GeneratorProperty("UseDisableImageMask",
                typeof(bool), typeof(OverlayMaskImageHelper));

        /// <summary> Gets whether the disabled image mask should be used. </summary>
        [Browsable(true)]
        [Category(nameof(OverlayMaskImageHelper))]
        [DisplayName("UseDisableImageMask")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetUseDisableImageMask(UIElement element)
            => (bool)element.GetValue(UseDisableImageMaskProperty);

        /// <summary> Sets whether the disabled image mask should be used. </summary>
        public static void SetUseDisableImageMask(UIElement element, bool value)
            => element.SetValue(UseDisableImageMaskProperty, value);

        ////////////////////////////////////////
        // DisableImageMask
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>DisableImageMask</c> attached property. <br/>
        /// Specifies the <see cref="ImageBrush"/> to use when the element is in the disabled state.
        /// </summary>
        public static readonly DependencyProperty DisableImageMaskProperty
            = GeneratorProperty("DisableImageMask",
                typeof(ImageBrush), typeof(OverlayMaskImageHelper));

        /// <summary> Gets the image mask brush for the disabled state. </summary>
        [Browsable(true)]
        [Category(nameof(OverlayMaskImageHelper))]
        [DisplayName("DisableImageMask")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static ImageBrush? GetDisableImageMask(UIElement element)
            => (ImageBrush)element.GetValue(DisableImageMaskProperty);

        /// <summary> Sets the image mask brush for the disabled state. </summary>
        public static void SetDisableImageMask(UIElement element, ImageBrush? value)
            => element.SetValue(DisableImageMaskProperty, value);

        ////////////////////////////////////////
        // UseMouseoverImageMask
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>UseMouseoverImageMask</c> attached property. <br/>
        /// Indicates whether the mouse-over image mask should be applied.
        /// </summary>
        public static readonly DependencyProperty UseMouseoverImageMaskProperty
            = GeneratorProperty("UseMouseoverImageMask",
                typeof(bool), typeof(OverlayMaskImageHelper));

        /// <summary> Gets whether the mouse-over image mask should be used. </summary>
        [Browsable(true)]
        [Category(nameof(OverlayMaskImageHelper))]
        [DisplayName("UseMouseoverImageMask")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetUseMouseoverImageMask(UIElement element)
            => (bool)element.GetValue(UseMouseoverImageMaskProperty);

        /// <summary> Sets whether the mouse-over image mask should be used. </summary>
        public static void SetUseMouseoverImageMask(UIElement element, bool value)
            => element.SetValue(UseMouseoverImageMaskProperty, value);

        ////////////////////////////////////////
        // MouseoverImageMask
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>MouseoverImageMask</c> attached property. <br/>
        /// Specifies the <see cref="ImageBrush"/> to use when the element is in the mouse-over (hovered) state.
        /// </summary>
        public static readonly DependencyProperty MouseoverImageMaskProperty
            = GeneratorProperty("MouseoverImageMask",
                typeof(ImageBrush), typeof(OverlayMaskImageHelper));

        /// <summary> Gets the image mask brush for the mouse-over state. </summary>
        [Browsable(true)]
        [Category(nameof(OverlayMaskImageHelper))]
        [DisplayName("MouseoverImageMask")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static ImageBrush? GetMouseoverImageMask(UIElement element)
            => (ImageBrush)element.GetValue(MouseoverImageMaskProperty);

        /// <summary> Sets the image mask brush for the mouse-over state. </summary>
        public static void SetMouseoverImageMask(UIElement element, ImageBrush? value)
            => element.SetValue(MouseoverImageMaskProperty, value);
    }
}
