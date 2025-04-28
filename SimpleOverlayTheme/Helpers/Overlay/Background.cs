using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;

namespace SimpleOverlayTheme.Helpers.Overlay
{
    public class Background
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
            => DependencyProperty.RegisterAttached(name, type, typeof(Background), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions));

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region SetDefaultVisible

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty SetDefaultVisibleProperty = DependencyProperty.RegisterAttached("SetDefaultVisible", typeof(bool), typeof(OverlayBackground), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.OverlayBackground}")]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        [AttachedPropertyBrowsableForType(typeof(CustomControl.NumericUpDown))]
        public static bool GetSetDefaultVisible(UIElement element)
        {
            return (bool)element.GetValue(SetDefaultVisibleProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.OverlayBackground}")]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        [AttachedPropertyBrowsableForType(typeof(CustomControl.NumericUpDown))]
        public static void SetSetDefaultVisible(UIElement element, bool value)
        {
            element.SetValue(SetDefaultVisibleProperty, value);
        }

        #endregion

        #region SetBackgroundVisible

        public static readonly DependencyProperty SetBackgroundVisibleProperty = DependencyProperty.RegisterAttached("SetBackgroundVisible", typeof(bool), typeof(OverlayBackground), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.OverlayBackground}")]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        [AttachedPropertyBrowsableForType(typeof(CustomControl.NumericUpDown))]
        public static bool GetSetBackgroundVisible(UIElement element)
        {
            return (bool)element.GetValue(SetBackgroundVisibleProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.OverlayBackground}")]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        [AttachedPropertyBrowsableForType(typeof(CustomControl.NumericUpDown))]
        public static void SetSetBackgroundVisible(UIElement element, bool value)
        {
            element.SetValue(SetBackgroundVisibleProperty, value);
        }

        #endregion

        #region SetOutlineVisible

        public static readonly DependencyProperty SetOutlineVisibleProperty = DependencyProperty.RegisterAttached("SetOutlineVisible", typeof(bool), typeof(OverlayBackground), new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions));

        [Category($"{KeywordDictionary.CategoryKey.OverlayBackground}")]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        [AttachedPropertyBrowsableForType(typeof(CustomControl.NumericUpDown))]
        public static bool GetSetOutlineVisible(UIElement element)
        {
            return (bool)element.GetValue(SetOutlineVisibleProperty);
        }

        [Category($"{KeywordDictionary.CategoryKey.OverlayBackground}")]
        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [AttachedPropertyBrowsableForType(typeof(RepeatButton))]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        [AttachedPropertyBrowsableForType(typeof(CustomControl.NumericUpDown))]
        public static void SetSetOutlineVisible(UIElement element, bool value)
        {
            element.SetValue(SetOutlineVisibleProperty, value);
        }

        #endregion
    }
}
