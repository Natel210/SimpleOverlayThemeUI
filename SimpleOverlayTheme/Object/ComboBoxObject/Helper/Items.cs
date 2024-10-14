using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Security.Cryptography;

namespace SimpleOverlayTheme.Object.ComboBoxObject.Helper
{
    public class Items
    {
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        #region ItemPadding

        public static readonly DependencyProperty ItemPaddingProperty
            = DependencyProperty.RegisterAttached(
                "ItemPadding",
                typeof(Thickness),
                typeof(Items),
                new FrameworkPropertyMetadata(new Thickness(0), _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.Items}")]
        [AttachedPropertyBrowsableForType(typeof(ComboBox))]
        public static Thickness GetItemPadding(UIElement element)
        {
            return (Thickness)element.GetValue(ItemPaddingProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.Items}")]
        [AttachedPropertyBrowsableForType(typeof(ComboBox))]
        public static void SetItemPadding(UIElement element, Thickness value)
        {
            element.SetValue(ItemPaddingProperty, value);
        }

        #endregion
    }
}