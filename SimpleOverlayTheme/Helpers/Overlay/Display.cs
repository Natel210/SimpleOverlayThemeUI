using System.ComponentModel;
using System.Windows;
using SimpleOverlayTheme.Share.StringTable;
using SimpleOverlayTheme.Helpers.Common;

namespace SimpleOverlayTheme.Helpers.Overlay
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Display : APropertyHelper {}

    #region ========== Display Background ==========
    public partial class Display
    {
        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Overlay.CategoryName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty DisplayBackgroundProperty
            = GeneratorProperty(HelperPropertyKey.Overlay.Display.Background.PropertyName,
                typeof(bool), typeof(State));

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Overlay.CategoryName)]
        [DisplayName(HelperPropertyKey.Overlay.Display.Background.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static bool GetDisplayBackground(UIElement element)
            => (bool)element.GetValue(DisplayBackgroundProperty);

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Overlay.CategoryName)]
        [DisplayName(HelperPropertyKey.Overlay.Display.Background.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static void SetDisplayBackground(UIElement element, bool value)
            => element.SetValue(DisplayBackgroundProperty, value);
    }
    #endregion

    #region ========== Display Outline ==========
    public partial class Display
    {
        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Overlay.CategoryName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty DisplayOutlineProperty
            = GeneratorProperty(HelperPropertyKey.Overlay.Display.Outline.PropertyName,
                typeof(bool), typeof(State));

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Overlay.CategoryName)]
        [DisplayName(HelperPropertyKey.Overlay.Display.Outline.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static bool GetDisplayOutline(UIElement element)
            => (bool)element.GetValue(DisplayOutlineProperty);

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Overlay.CategoryName)]
        [DisplayName(HelperPropertyKey.Overlay.Display.Outline.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static void SetDisplayOutline(UIElement element, bool value)
            => element.SetValue(DisplayOutlineProperty, value);
    }
    #endregion

    #region ========== Default Background ==========
    public partial class Display
    {
        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Overlay.CategoryName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty DisplayDefaultBackgroundProperty
            = GeneratorProperty(HelperPropertyKey.Overlay.Display.DefaultBackground.PropertyName,
                typeof(bool), typeof(State));

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Overlay.CategoryName)]
        [DisplayName(HelperPropertyKey.Overlay.Display.DefaultBackground.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static bool GetDisplayDefaultBackground(UIElement element)
            => (bool)element.GetValue(DisplayDefaultBackgroundProperty);

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Overlay.CategoryName)]
        [DisplayName(HelperPropertyKey.Overlay.Display.DefaultBackground.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static void SetDisplayDefaultBackground(UIElement element, bool value)
            => element.SetValue(DisplayDefaultBackgroundProperty, value);
    }
    #endregion

    #region ========== Default Outline ==========
    public partial class Display
    {
        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Overlay.CategoryName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty DisplayDefaultOutlineProperty
            = GeneratorProperty(HelperPropertyKey.Overlay.Display.DefaultOutline.PropertyName,
                typeof(bool), typeof(State));

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Overlay.CategoryName)]
        [DisplayName(HelperPropertyKey.Overlay.Display.DefaultOutline.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static bool GetDisplayDefaultOutline(UIElement element)
            => (bool)element.GetValue(DisplayDefaultOutlineProperty);

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Overlay.CategoryName)]
        [DisplayName(HelperPropertyKey.Overlay.Display.DefaultOutline.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static void SetDisplayDefaultOutline(UIElement element, bool value)
            => element.SetValue(DisplayDefaultOutlineProperty, value);
    }
    #endregion
}
