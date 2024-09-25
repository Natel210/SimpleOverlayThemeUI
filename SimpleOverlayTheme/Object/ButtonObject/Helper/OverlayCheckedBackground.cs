using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace SimpleOverlayTheme.Object.ButtonObject.Helper
{
    public class OverlayCheckedBackground
    {
        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        #region Background


        public static readonly DependencyProperty BackgroundProperty = DependencyProperty.RegisterAttached("Background", typeof(SolidColorBrush), typeof(OverlayCheckedBackground), new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.OverlayCheckedBackground}")]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static SolidColorBrush? GetBackground(UIElement element)
        {
            return (SolidColorBrush)element.GetValue(BackgroundProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.OverlayCheckedBackground}")]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static void SetBackground(UIElement element, SolidColorBrush? value)
        {
            element.SetValue(BackgroundProperty, value);
        }

        #endregion

        #region Thickness

        public static readonly DependencyProperty ThicknessProperty = DependencyProperty.RegisterAttached("Thickness", typeof(Thickness), typeof(OverlayCheckedBackground), new FrameworkPropertyMetadata(new Thickness(1.0), _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.OverlayCheckedBackground}")]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static Thickness GetThickness(UIElement element)
        {
            return (Thickness)element.GetValue(ThicknessProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.OverlayCheckedBackground}")]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static void SetThickness(UIElement element, Thickness value)
        {
            element.SetValue(ThicknessProperty, value);
        }

        #endregion

        #region Outline

        public static readonly DependencyProperty OutlineProperty = DependencyProperty.RegisterAttached("Outline", typeof(SolidColorBrush), typeof(OverlayCheckedBackground), new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.OverlayCheckedBackground}")]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static SolidColorBrush? GetOutline(UIElement element)
        {
            return (SolidColorBrush)element.GetValue(OutlineProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.OverlayCheckedBackground}")]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static void SetOutline(UIElement element, SolidColorBrush? value)
        {
            element.SetValue(OutlineProperty, value);
        }

        #endregion
    }
}
