using System.ComponentModel;
using System.Windows;
using System.Xml.Linq;
using SimpleOverlayTheme.Share.StringTable;

namespace SimpleOverlayTheme.Helpers.Overlay
{
    /// <summary> Provides attached properties for customizing the visual states of a Border control. </summary>
    public class Border
    {
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Common ==========

        /// <summary> Defines common metadata options for the attached properties. </summary>
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions
            = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        /// <summary> Generates an attached DependencyProperty for the Border helper. </summary>
        /// <param name="name">The name of the DependencyProperty.</param>
        /// <param name="type">The type of the DependencyProperty.</param>
        /// <returns>The registered DependencyProperty instance.</returns>
        private static DependencyProperty GeneratorProperty(string name, Type type)
            => DependencyProperty.RegisterAttached(name, type, typeof(Border), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Disable ==========

        /// <summary> Identifies the IsDisable attached property. </summary>
        [Category(CategoryKey.Overlay.Border)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty IsDisableProperty
            = GeneratorProperty(HelperKey.Overlay.Border.Trigger.IsDisable, typeof(bool));

        /// <summary> Gets the IsDisable attached property value. </summary>
        [Category(CategoryKey.Overlay.Border)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static bool GetIsDisable(UIElement element)
            => (bool)element.GetValue(IsDisableProperty);

        /// <summary> Sets the IsDisable attached property value. </summary>
        [Category(CategoryKey.Overlay.Border)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static void SetIsDisable(UIElement element, bool value)
            => element.SetValue(IsDisableProperty, value);

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Default ==========

        /// <summary> Identifies the IsDefault attached property. </summary>
        [Category(CategoryKey.Overlay.Border)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty IsDefaultProperty
            = GeneratorProperty(HelperKey.Overlay.Border.Trigger.IsDefault, typeof(bool));

        /// <summary> Gets the IsDefault attached property value. </summary>
        [Category(CategoryKey.Overlay.Border)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static bool GetIsDefault(UIElement element)
            => (bool)element.GetValue(IsDefaultProperty);

        /// <summary> Sets the IsDefault attached property value. </summary>
        [Category(CategoryKey.Overlay.Border)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static void SetIsDefault(UIElement element, bool value)
            => element.SetValue(IsDefaultProperty, value);

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== MouseOver ==========

        /// <summary> Identifies the IsMouseOver attached property. </summary>
        [Category(CategoryKey.Overlay.Border)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty IsMouseOverProperty
            = GeneratorProperty(HelperKey.Overlay.Border.Trigger.IsMouseOver, typeof(bool));

        /// <summary> Gets the IsMouseOver attached property value. </summary>
        [Category(CategoryKey.Overlay.Border)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static bool GetIsMouseOver(UIElement element)
            => (bool)element.GetValue(IsMouseOverProperty);

        /// <summary> Sets the IsMouseOver attached property value. </summary>
        [Category(CategoryKey.Overlay.Border)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static void SetIsMouseOver(UIElement element, bool value)
            => element.SetValue(IsMouseOverProperty, value);

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Active ==========

        /// <summary> Identifies the IsActive attached property. </summary>
        [Category(CategoryKey.Overlay.Border)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty IsActiveProperty
            = GeneratorProperty(HelperKey.Overlay.Border.Trigger.IsActive, typeof(bool));

        /// <summary> Gets the IsActive attached property value. </summary>
        [Category(CategoryKey.Overlay.Border)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static bool GetIsActive(UIElement element)
            => (bool)element.GetValue(IsActiveProperty);


        /// <summary> Sets the IsActive attached property value. </summary>
        [Category(CategoryKey.Overlay.Border)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static void SetIsActive(UIElement element, bool value)
            => element.SetValue(IsActiveProperty, value);

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
    }
}
