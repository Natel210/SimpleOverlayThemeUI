using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SimpleOverlayTheme.Object.TextBoxObject.Helper
{
    public class OverlayBackground
    {
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        #region SetDefaultVisible

        public static readonly DependencyProperty SetDefaultVisibleProperty = DependencyProperty.RegisterAttached("SetDefaultVisible", typeof(bool), typeof(OverlayBackground), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.OverlayBackground}")]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetSetDefaultVisible(UIElement element)
        {
            return (bool)element.GetValue(SetDefaultVisibleProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.OverlayBackground}")]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static void SetSetDefaultVisible(UIElement element, bool value)
        {
            element.SetValue(SetDefaultVisibleProperty, value);
        }

        #endregion

        #region SetBackgroundVisible

        public static readonly DependencyProperty SetBackgroundVisibleProperty = DependencyProperty.RegisterAttached("SetBackgroundVisible", typeof(bool), typeof(OverlayBackground), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.OverlayBackground}")]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetSetBackgroundVisible(UIElement element)
        {
            return (bool)element.GetValue(SetBackgroundVisibleProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.OverlayBackground}")]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static void SetSetBackgroundVisible(UIElement element, bool value)
        {
            element.SetValue(SetBackgroundVisibleProperty, value);
        }

        #endregion

        #region SetOutlineVisible

        public static readonly DependencyProperty SetOutlineVisibleProperty = DependencyProperty.RegisterAttached("SetOutlineVisible", typeof(bool), typeof(OverlayBackground), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.OverlayBackground}")]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetSetOutlineVisible(UIElement element)
        {
            return (bool)element.GetValue(SetOutlineVisibleProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.OverlayBackground}")]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static void SetSetOutlineVisible(UIElement element, bool value)
        {
            element.SetValue(SetOutlineVisibleProperty, value);
        }

        #endregion
    }
}
