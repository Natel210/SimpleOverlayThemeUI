using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shell;
using CommunityToolkit.Mvvm.Input;

namespace SimpleOverlayTheme.CustomControl
{
    public partial class WindowHeader : Control
    {
        static WindowHeader()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowHeader),
                new FrameworkPropertyMetadata(typeof(WindowHeader)));
        }

        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        public WindowHeader()
        {
        }

        public static readonly DependencyProperty TitleContentProperty
            = DependencyProperty.Register(
                nameof(TitleContent),
                typeof(object),
                typeof(WindowHeader),
                new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        public object? TitleContent
        {
            get { return GetValue(TitleContentProperty); }
            set { SetValue(TitleContentProperty, value); }
        }

        public static readonly DependencyProperty SideContentProperty
            = DependencyProperty.Register(
                nameof(SideContent),
                typeof(object),
                typeof(WindowHeader),
                new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        public object? SideContent
        {
            get => GetValue(SideContentProperty);
            set => SetValue(SideContentProperty, value);
        }

        public static readonly DependencyProperty WindowUnlockedProperty
            = DependencyProperty.Register(
                nameof(WindowUnlocked),
                typeof(bool),
                typeof(WindowHeader),
                new FrameworkPropertyMetadata(true, _frameworkPropertyMetadataOptions));

        public bool WindowUnlocked
        {
            get { return (bool)GetValue(WindowUnlockedProperty); }
            set { SetValue(WindowUnlockedProperty, value); }
        }

        public static readonly DependencyProperty UseDoubleClickMaximizeRestoreProperty
            = DependencyProperty.Register(
                nameof(UseDoubleClickMaximizeRestore),
                typeof(bool),
                typeof(WindowHeader),
                new FrameworkPropertyMetadata(true, _frameworkPropertyMetadataOptions));

        public bool UseDoubleClickMaximizeRestore
        {
            get { return (bool)GetValue(UseDoubleClickMaximizeRestoreProperty); }
            set { SetValue(UseDoubleClickMaximizeRestoreProperty, value); }
        }

        public static readonly DependencyProperty WindowControlForegroundProperty
            = DependencyProperty.Register(
                nameof(WindowControlForeground),
                typeof(SolidColorBrush),
                typeof(WindowHeader),
                new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        public SolidColorBrush? WindowControlForeground
        {
            get { return (SolidColorBrush?)GetValue(WindowControlForegroundProperty); }
            set { SetValue(WindowControlForegroundProperty, value); }
        }

        public static readonly DependencyProperty ShowMinimizeProperty
            = DependencyProperty.Register(
                nameof(ShowMinimize),
                typeof(Visibility),
                typeof(WindowHeader),
                new FrameworkPropertyMetadata(Visibility.Visible, _frameworkPropertyMetadataOptions));

        public Visibility ShowMinimize
        {
            get { return (Visibility)GetValue(ShowMinimizeProperty); }
            set { SetValue(ShowMinimizeProperty, value); }
        }

        public static readonly DependencyProperty ShowToggleMaximizeRestoreProperty
            = DependencyProperty.Register(
                nameof(ShowToggleMaximizeRestore),
                typeof(Visibility),
                typeof(WindowHeader),
                new FrameworkPropertyMetadata(Visibility.Visible, _frameworkPropertyMetadataOptions));

        public Visibility ShowToggleMaximizeRestore
        {
            get { return (Visibility)GetValue(ShowToggleMaximizeRestoreProperty); }
            set { SetValue(ShowToggleMaximizeRestoreProperty, value); }
        }

        public static readonly DependencyProperty ShowCloseProperty
            = DependencyProperty.Register(
                nameof(ShowClose),
                typeof(Visibility),
                typeof(WindowHeader),
                new FrameworkPropertyMetadata(Visibility.Visible, _frameworkPropertyMetadataOptions));

        public Visibility ShowClose
        {
            get { return (Visibility)GetValue(ShowCloseProperty); }
            set { SetValue(ShowCloseProperty, value); }
        }
    }
}