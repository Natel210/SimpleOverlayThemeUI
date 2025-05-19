using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace SimpleOverlayTheme.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WindowHeader : Control
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty CloseButtonProperty = PropertyRegister(nameof(CloseButton), typeof(Button), null);
        /// <summary>
        /// 
        /// </summary>
        public Button? CloseButton { get => GetValue(CloseButtonProperty) as Button; set => SetValue(CloseButtonProperty, value); }

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty MaximizeRestoreButtonProperty = PropertyRegister(nameof(MaximizeRestoreButton), typeof(ToggleButton), null);
        /// <summary>
        /// 
        /// </summary>
        public ToggleButton? MaximizeRestoreButton { get => GetValue(MaximizeRestoreButtonProperty) as ToggleButton; set => SetValue(MaximizeRestoreButtonProperty, value); }

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty MinimizeButtonProperty = PropertyRegister(nameof(MinimizeButton), typeof(Button), null);
        /// <summary>
        /// 
        /// </summary>
        public Button? MinimizeButton { get => GetValue(MinimizeButtonProperty) as Button; set => SetValue(MinimizeButtonProperty, value); }

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty TailContentProperty = PropertyRegister(nameof(TailContent), typeof(object), null);
        /// <summary>
        /// 
        /// </summary>
        public object? TailContent { get { return GetValue(TailContentProperty); } set { SetValue(TailContentProperty, value); } }

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty TitleContentProperty = PropertyRegister(nameof(TitleContent), typeof(object), null);
        /// <summary>
        /// 
        /// </summary>
        public object? TitleContent { get { return GetValue(TitleContentProperty); } set { SetValue(TitleContentProperty, value); } }

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty WindowUnlockedProperty = PropertyRegister(nameof(WindowUnlocked), typeof(bool), true);
        /// <summary>
        /// 
        /// </summary>
        public bool WindowUnlocked { get { return (bool)GetValue(WindowUnlockedProperty); } set { SetValue(WindowUnlockedProperty, value); } }

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty VisibleCloseButtonProperty = PropertyRegister(nameof(VisibleCloseButton), typeof(Visibility), Visibility.Visible);
        /// <summary>
        /// 
        /// </summary>
        public Visibility VisibleCloseButton { get => (Visibility)GetValue(VisibleCloseButtonProperty); set => SetValue(VisibleCloseButtonProperty, value); }

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty VisibleMaximizeRestoreButtonProperty = PropertyRegister(nameof(VisibleMaximizeRestoreButton), typeof(Visibility), Visibility.Visible);
        /// <summary>
        /// 
        /// </summary>
        public Visibility VisibleMaximizeRestoreButton { get => (Visibility)GetValue(VisibleMaximizeRestoreButtonProperty); set => SetValue(VisibleMaximizeRestoreButtonProperty, value); }

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty VisibleMinimizeButtonProperty = PropertyRegister(nameof(VisibleMinimizeButton), typeof(Visibility), Visibility.Visible);
        /// <summary>
        /// 
        /// </summary>
        public Visibility VisibleMinimizeButton { get => (Visibility)GetValue(VisibleMinimizeButtonProperty); set => SetValue(VisibleMinimizeButtonProperty, value); }

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty VisibleTailContentProperty = PropertyRegister(nameof(VisibleTailContent), typeof(Visibility), Visibility.Visible);
        /// <summary>
        /// 
        /// </summary>
        public Visibility VisibleTailContent { get { return (Visibility)GetValue(VisibleTailContentProperty); } set { SetValue(VisibleTailContentProperty, value); } }


    }

    public partial class WindowHeader
    {
        static WindowHeader()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowHeader),
                new FrameworkPropertyMetadata(typeof(WindowHeader)));
        }

        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions
            = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        private static DependencyProperty PropertyRegister(string name, Type propertyType, object? defaultValue = null)
        {
            return DependencyProperty.Register(name, propertyType, 
                typeof(WindowHeader), new FrameworkPropertyMetadata(defaultValue, _frameworkPropertyMetadataOptions));
        }
    }







}
