using SimpleOverlayTheme.Helpers.Overlay;
using SimpleOverlayTheme.Share.StringTable;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace SimpleOverlayTheme.Helpers.Common
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Mask : APropertyHelper { }

    #region ========== Default Image ==========
    public partial class Mask
    {
        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty DefaultImageProperty
            = GeneratorProperty(HelperPropertyKey.Common.Mask.DefaultImage.PropertyName,
                typeof(ImageBrush), typeof(Mask));

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.Mask.DefaultImage.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static ImageBrush? GetDefaultImage(UIElement element)
            => (ImageBrush)element.GetValue(DefaultImageProperty);

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.Mask.DefaultImage.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static void SetDefaultImage(UIElement element, ImageBrush? value)
            => element.SetValue(DefaultImageProperty, value);
    }
    #endregion


    #region ========== Use Custom Image Active ==========
    public partial class Mask
    {
        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty UseCustomImageActiveProperty
            = GeneratorProperty(HelperPropertyKey.Common.Mask.UseCustomImage.Active.PropertyName,
                typeof(bool), typeof(Mask));

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.Mask.UseCustomImage.Active.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static bool GetUseCustomImageActive(UIElement element)
            => (bool)element.GetValue(UseCustomImageActiveProperty);

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.Mask.UseCustomImage.Active.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static void SetUseCustomImageActive(UIElement element, bool value)
            => element.SetValue(UseCustomImageActiveProperty, value);
    }
    #endregion

    #region ========== Custom Image Active ==========
    public partial class Mask
    {
        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty CustomImageActiveProperty
            = GeneratorProperty(HelperPropertyKey.Common.Mask.CustomImage.Active.PropertyName,
                typeof(ImageBrush), typeof(Mask));

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.Mask.CustomImage.Active.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static ImageBrush? GetCustomImageActive(UIElement element)
            => (ImageBrush)element.GetValue(CustomImageActiveProperty);

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.Mask.CustomImage.Active.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static void SetCustomImageActive(UIElement element, ImageBrush? value)
            => element.SetValue(CustomImageActiveProperty, value);
    }
    #endregion

    #region ========== Use Custom Image Disable ==========
    public partial class Mask
    {
        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty UseCustomImageDisableProperty
            = GeneratorProperty(HelperPropertyKey.Common.Mask.UseCustomImage.Disable.PropertyName,
                typeof(bool), typeof(Mask));

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.Mask.UseCustomImage.Disable.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static bool GetUseCustomImageDisable(UIElement element)
            => (bool)element.GetValue(UseCustomImageDisableProperty);

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.Mask.UseCustomImage.Disable.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static void SetUseCustomImageDisable(UIElement element, bool value)
            => element.SetValue(UseCustomImageDisableProperty, value);
    }
    #endregion

    #region ========== Custom Image Disable ==========
    public partial class Mask
    {
        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty CustomImageDisableProperty
            = GeneratorProperty(HelperPropertyKey.Common.Mask.CustomImage.Disable.PropertyName,
                typeof(ImageBrush), typeof(Mask));

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.Mask.CustomImage.Disable.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static ImageBrush? GetCustomImageDisable(UIElement element)
            => (ImageBrush)element.GetValue(CustomImageDisableProperty);

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.Mask.CustomImage.Disable.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static void SetCustomImageDisable(UIElement element, ImageBrush? value)
            => element.SetValue(CustomImageDisableProperty, value);
    }
    #endregion

    #region ========== Use Custom Image Disable ==========
    public partial class Mask
    {
        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty UseCustomImageMouseOverProperty
            = GeneratorProperty(HelperPropertyKey.Common.Mask.UseCustomImage.MouseOver.PropertyName,
                typeof(bool), typeof(Mask));

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.Mask.UseCustomImage.MouseOver.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static bool GetUseCustomImageMouseOver(UIElement element)
            => (bool)element.GetValue(UseCustomImageMouseOverProperty);

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.Mask.UseCustomImage.MouseOver.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static void SetUseCustomImageMouseOver(UIElement element, bool value)
            => element.SetValue(UseCustomImageMouseOverProperty, value);
    }
    #endregion

    #region ========== Custom Image MouseOver ==========
    public partial class Mask
    {
        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty CustomImageMouseOverProperty
            = GeneratorProperty(HelperPropertyKey.Common.Mask.CustomImage.MouseOver.PropertyName, typeof(ImageBrush), typeof(Mask));

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.Mask.CustomImage.MouseOver.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static ImageBrush? GetCustomImageMouseOver(UIElement element)
            => (ImageBrush)element.GetValue(CustomImageMouseOverProperty);

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.Mask.CustomImage.MouseOver.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static void SetCustomImageMouseOver(UIElement element, ImageBrush? value)
            => element.SetValue(CustomImageMouseOverProperty, value);
    }
    #endregion
}
