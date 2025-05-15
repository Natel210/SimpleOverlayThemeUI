using System.ComponentModel;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace SimpleOverlayTheme.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class DataGridColumnHeaderHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // UseSortImageMask
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty UseSortImageMaskProperty
            = GeneratorProperty("UseSortImageMask",
                typeof(bool), typeof(DataGridColumnHeaderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(DataGridColumnHeaderHelper))]
        [DisplayName("UseSortImageMask")]
        [AttachedPropertyBrowsableForType(typeof(DataGridColumnHeader))]
        public static bool GetUseSortImageMask(UIElement element)
            => (bool)element.GetValue(UseSortImageMaskProperty);

        /// <summary></summary>
        public static void SetUseSortImageMask(UIElement element, bool value)
            => element.SetValue(UseSortImageMaskProperty, value);


        ////////////////////////////////////////
        // AscendingImageMask
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty AscendingImageMaskProperty
            = GeneratorProperty("AscendingImageMask",
                typeof(ImageBrush), typeof(DataGridColumnHeaderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(DataGridColumnHeaderHelper))]
        [DisplayName("AscendingImageMask")]
        [AttachedPropertyBrowsableForType(typeof(DataGridColumnHeader))]
        public static ImageBrush? GetAscendingImageMask(UIElement element)
            => (ImageBrush)element.GetValue(AscendingImageMaskProperty);

        /// <summary></summary>
        public static void SetAscendingImageMask(UIElement element, ImageBrush? value)
            => element.SetValue(AscendingImageMaskProperty, value);

        ////////////////////////////////////////
        // DescendingImageMask
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty DescendingImageMaskProperty
            = GeneratorProperty("DescendingImageMask",
                typeof(ImageBrush), typeof(DataGridColumnHeaderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(DataGridColumnHeaderHelper))]
        [DisplayName("DescendingImageMask")]
        [AttachedPropertyBrowsableForType(typeof(DataGridColumnHeader))]
        public static ImageBrush? GetDescendingImageMask(UIElement element)
            => (ImageBrush)element.GetValue(DescendingImageMaskProperty);

        /// <summary></summary>
        public static void SetDescendingImageMask(UIElement element, ImageBrush? value)
            => element.SetValue(DescendingImageMaskProperty, value);
    }
}
