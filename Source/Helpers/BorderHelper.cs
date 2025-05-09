using SimpleOverlayTheme.Helpers.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static SimpleOverlayTheme.Helpers.KeyWord.BorderHelper;

namespace SimpleOverlayTheme.Helpers
{
    /// <summary></summary>
    public class BorderHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // Overlay_State
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty Overlay_StateProperty
            = GeneratorProperty("Overlay_State", typeof(EOverlayState), typeof(BorderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(BorderHelper))]
        [DisplayName("Overlay_State")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static EOverlayState GetOverlay_State(UIElement element)
            => (EOverlayState)element.GetValue(Overlay_StateProperty);

        /// <summary></summary>
        public static void SetOverlay_State(UIElement element, EOverlayState value)
            => element.SetValue(Overlay_StateProperty, value);


        ////////////////////////////////////////
        // Overlay_DisplayBackground
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty Overlay_DisplayBackgroundProperty
            = GeneratorProperty("Overlay_DisplayBackground",
                typeof(bool), typeof(BorderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(BorderHelper))]
        [DisplayName("Overlay_DisplayBackground")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetOverlay_DisplayBackground(UIElement element)
            => (bool)element.GetValue(Overlay_DisplayBackgroundProperty);

        /// <summary></summary>
        public static void SetOverlay_DisplayBackground(UIElement element, bool value)
            => element.SetValue(Overlay_DisplayBackgroundProperty, value);

        ////////////////////////////////////////
        // Overlay_DisplayBackground_AtDefault
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty Overlay_DisplayBackground_AtDefaultProperty
            = GeneratorProperty("Overlay_DisplayBackground_AtDefault",
                typeof(bool), typeof(BorderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(BorderHelper))]
        [DisplayName("Overlay_DisplayBackground_AtDefault")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetOverlay_DisplayBackground_AtDefault(UIElement element)
            => (bool)element.GetValue(Overlay_DisplayBackground_AtDefaultProperty);

        /// <summary></summary>
        public static void SetOverlay_DisplayBackground_AtDefault(UIElement element, bool value)
            => element.SetValue(Overlay_DisplayBackground_AtDefaultProperty, value);

        ////////////////////////////////////////
        // Overlay_DisplayOutline
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty Overlay_DisplayOutlineProperty
            = GeneratorProperty("Overlay_DisplayOutline",
                typeof(bool), typeof(BorderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(BorderHelper))]
        [DisplayName("Overlay_DisplayOutline")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetOverlay_DisplayOutline(UIElement element)
            => (bool)element.GetValue(Overlay_DisplayOutlineProperty);

        /// <summary></summary>
        public static void SetOverlay_DisplayOutline(UIElement element, bool value)
            => element.SetValue(Overlay_DisplayOutlineProperty, value);

        ////////////////////////////////////////
        // Overlay_DisplayOutline_AtDefault
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty Overlay_DisplayOutline_AtDefaultProperty
            = GeneratorProperty("Overlay_DisplayOutline_AtDefault",
                typeof(bool), typeof(BorderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(BorderHelper))]
        [DisplayName("Overlay_DisplayOutline_AtDefault")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetOverlay_DisplayOutline_AtDefault(UIElement element)
            => (bool)element.GetValue(Overlay_DisplayOutline_AtDefaultProperty);

        /// <summary></summary>
        public static void SetOverlay_DisplayOutline_AtDefault(UIElement element, bool value)
            => element.SetValue(Overlay_DisplayOutline_AtDefaultProperty, value);

        ////////////////////////////////////////
        // Mask_DefaultImageBrush
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty Mask_DefaultImageBrushProperty
            = GeneratorProperty("Mask_DefaultImageBrush",
                typeof(ImageBrush), typeof(BorderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(BorderHelper))]
        [DisplayName("Mask_DefaultImageBrush")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static ImageBrush? GetMask_DefaultImageBrush(UIElement element)
            => (ImageBrush)element.GetValue(Mask_DefaultImageBrushProperty);

        /// <summary></summary>
        public static void SetMask_DefaultImageBrush(UIElement element, ImageBrush? value)
            => element.SetValue(Mask_DefaultImageBrushProperty, value);

        ////////////////////////////////////////
        // CustomMask_Use_AtActive
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty CustomMask_Use_AtActiveProperty
            = GeneratorProperty("CustomMask_Use_AtActive",
                typeof(bool), typeof(BorderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(BorderHelper))]
        [DisplayName("CustomMask_Use_AtActive")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetCustomMask_Use_AtActive(UIElement element)
            => (bool)element.GetValue(CustomMask_Use_AtActiveProperty);

        /// <summary></summary>
        public static void SetCustomMask_Use_AtActive(UIElement element, bool value)
            => element.SetValue(CustomMask_Use_AtActiveProperty, value);

        ////////////////////////////////////////
        // CustomMask_ImageBrush_AtActive
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty CustomMask_ImageBrush_AtActiveProperty
            = GeneratorProperty("CustomMask_ImageBrush_AtActive",
                typeof(ImageBrush), typeof(BorderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(BorderHelper))]
        [DisplayName("CustomMask_ImageBrush_AtActive")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static ImageBrush? GetCustomMask_ImageBrush_AtActive(UIElement element)
            => (ImageBrush)element.GetValue(CustomMask_ImageBrush_AtActiveProperty);

        /// <summary></summary>
        public static void SetCustomMask_ImageBrush_AtActive(UIElement element, ImageBrush? value)
            => element.SetValue(CustomMask_ImageBrush_AtActiveProperty, value);

        ////////////////////////////////////////
        // CustomMask_Use_AtDisable
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty CustomMask_Use_AtDisableProperty
            = GeneratorProperty("CustomMask_Use_AtDisable",
                typeof(bool), typeof(BorderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(BorderHelper))]
        [DisplayName("CustomMask_Use_AtDisable")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetCustomMask_Use_AtDisable(UIElement element)
            => (bool)element.GetValue(CustomMask_Use_AtDisableProperty);

        /// <summary></summary>
        public static void SetCustomMask_Use_AtDisable(UIElement element, bool value)
            => element.SetValue(CustomMask_Use_AtDisableProperty, value);

        ////////////////////////////////////////
        // CustomMask_ImageBrush_AtDisable
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty CustomMask_ImageBrush_AtDisableProperty
            = GeneratorProperty("CustomMask_ImageBrush_AtDisable",
                typeof(ImageBrush), typeof(BorderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(BorderHelper))]
        [DisplayName("CustomMask_ImageBrush_AtDisable")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static ImageBrush? GetCustomMask_ImageBrush_AtDisable(UIElement element)
            => (ImageBrush)element.GetValue(CustomMask_ImageBrush_AtDisableProperty);

        /// <summary></summary>
        public static void SetCustomMask_ImageBrush_AtDisable(UIElement element, ImageBrush? value)
            => element.SetValue(CustomMask_ImageBrush_AtDisableProperty, value);

        ////////////////////////////////////////
        // CustomMask_Use_AtMouseover
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty CustomMask_Use_AtMouseoverProperty
            = GeneratorProperty("CustomMask_Use_AtMouseover",
                typeof(bool), typeof(BorderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(BorderHelper))]
        [DisplayName("CustomMask_Use_AtMouseover")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static bool GetCustomMask_Use_AtMouseover(UIElement element)
            => (bool)element.GetValue(CustomMask_Use_AtMouseoverProperty);

        /// <summary></summary>
        public static void SetCustomMask_Use_AtMouseover(UIElement element, bool value)
            => element.SetValue(CustomMask_Use_AtMouseoverProperty, value);

        ////////////////////////////////////////
        // CustomMask_ImageBrush_AtMouseover
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty CustomMask_ImageBrush_AtMouseoverProperty
            = GeneratorProperty("CustomMask_ImageBrush_AtMouseover",
                typeof(ImageBrush), typeof(BorderHelper));

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(BorderHelper))]
        [DisplayName("CustomMask_ImageBrush_AtMouseover")]
        [AttachedPropertyBrowsableForType(typeof(Border))]
        public static ImageBrush? GetCustomMask_ImageBrush_AtMouseover(UIElement element)
            => (ImageBrush)element.GetValue(CustomMask_ImageBrush_AtMouseoverProperty);

        /// <summary></summary>
        public static void SetCustomMask_ImageBrush_AtMouseover(UIElement element, ImageBrush? value)
            => element.SetValue(CustomMask_ImageBrush_AtMouseoverProperty, value);
    }
}
