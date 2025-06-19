using System.ComponentModel;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace SimpleOverlayTheme.Helpers
{
    /// <summary>
    /// Provides attached properties for customizing the visual appearance of <see cref="DataGridColumnHeader"/>,
    /// including optional usage of image masks for ascending and descending sort indicators.
    /// </summary>
    public class DataGridColumnHeaderHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // UseSortImageMask
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>UseSortImageMask</c> attached dependency property. <br/>
        /// When enabled, the column header will use custom image masks for sort indicators.
        /// </summary>
        public static readonly DependencyProperty UseSortImageMaskProperty
            = GeneratorProperty("UseSortImageMask",
                typeof(bool), typeof(DataGridColumnHeaderHelper));

        /// <summary> Gets whether a <see cref="DataGridColumnHeader"/> should use a sort image mask. </summary>
        /// <param name="element">The target UI element (typically a <see cref="DataGridColumnHeader"/>).</param>
        /// <returns><c>true</c> if the sort image mask should be used; otherwise, <c>false</c>.</returns>
        [Browsable(true)]
        [Category(nameof(DataGridColumnHeaderHelper))]
        [DisplayName("UseSortImageMask")]
        [AttachedPropertyBrowsableForType(typeof(DataGridColumnHeader))]
        public static bool GetUseSortImageMask(UIElement element)
            => (bool)element.GetValue(UseSortImageMaskProperty);

        /// <summary> Sets whether a <see cref="DataGridColumnHeader"/> should use a sort image mask. </summary>
        /// <param name="element">The target UI element (typically a <see cref="DataGridColumnHeader"/>).</param>
        /// <param name="value"><c>true</c> to enable the sort image mask; otherwise, <c>false</c>.</param>
        public static void SetUseSortImageMask(UIElement element, bool value)
            => element.SetValue(UseSortImageMaskProperty, value);


        ////////////////////////////////////////
        // AscendingImageMask
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>AscendingImageMask</c> attached dependency property. <br/>
        /// Specifies the <see cref="ImageBrush"/> to be used when the column is sorted in ascending order.
        /// </summary>
        public static readonly DependencyProperty AscendingImageMaskProperty
            = GeneratorProperty("AscendingImageMask",
                typeof(ImageBrush), typeof(DataGridColumnHeaderHelper));

        /// <summary> Gets the <see cref="ImageBrush"/> to use as a mask for ascending sort order. </summary>
        /// <param name="element">The target UI element (typically a <see cref="DataGridColumnHeader"/>).</param>
        /// <returns>The image brush for ascending sort order, or <c>null</c> if not set.</returns>
        [Browsable(true)]
        [Category(nameof(DataGridColumnHeaderHelper))]
        [DisplayName("AscendingImageMask")]
        [AttachedPropertyBrowsableForType(typeof(DataGridColumnHeader))]
        public static ImageBrush? GetAscendingImageMask(UIElement element)
            => (ImageBrush)element.GetValue(AscendingImageMaskProperty);

        /// <summary> Sets the <see cref="ImageBrush"/> to use as a mask for ascending sort order. </summary>
        /// <param name="element">The target UI element (typically a <see cref="DataGridColumnHeader"/>).</param>
        /// <param name="value">The image brush to apply for ascending sort.</param>
        public static void SetAscendingImageMask(UIElement element, ImageBrush? value)
            => element.SetValue(AscendingImageMaskProperty, value);

        ////////////////////////////////////////
        // DescendingImageMask
        ////////////////////////////////////////

        /// <summary>
        /// Identifies the <c>DescendingImageMask</c> attached dependency property. <br/>
        /// Specifies the <see cref="ImageBrush"/> to be used when the column is sorted in descending order.
        /// </summary>
        public static readonly DependencyProperty DescendingImageMaskProperty
            = GeneratorProperty("DescendingImageMask",
                typeof(ImageBrush), typeof(DataGridColumnHeaderHelper));

        /// <summary> Gets the <see cref="ImageBrush"/> to use as a mask for descending sort order. </summary>
        /// <param name="element">The target UI element (typically a <see cref="DataGridColumnHeader"/>).</param>
        /// <returns>The image brush for descending sort order, or <c>null</c> if not set.</returns>
        [Browsable(true)]
        [Category(nameof(DataGridColumnHeaderHelper))]
        [DisplayName("DescendingImageMask")]
        [AttachedPropertyBrowsableForType(typeof(DataGridColumnHeader))]
        public static ImageBrush? GetDescendingImageMask(UIElement element)
            => (ImageBrush)element.GetValue(DescendingImageMaskProperty);

        /// <summary> Sets the <see cref="ImageBrush"/> to use as a mask for descending sort order. </summary>
        /// <param name="element">The target UI element (typically a <see cref="DataGridColumnHeader"/>).</param>
        /// <param name="value">The image brush to apply for descending sort.</param>
        public static void SetDescendingImageMask(UIElement element, ImageBrush? value)
            => element.SetValue(DescendingImageMaskProperty, value);
    }
}
