using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace SimpleOverlayTheme.CustomControl
{
    [TemplatePart(Name = "PART_MinimizeButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_FullScreen", Type = typeof(ToggleButton))]
    [TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_FocusLostOverlay", Type = typeof(Border))]
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
            MouseInit();
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

        public static readonly DependencyProperty UnderbarSpaceProperty
            = DependencyProperty.Register(
                nameof(UnderbarSpace),
                typeof(GridLength),
                typeof(WindowHeader),
                new FrameworkPropertyMetadata(new GridLength(1.0), _frameworkPropertyMetadataOptions));
        public GridLength UnderbarSpace
        {
            get { return (GridLength)GetValue(UnderbarSpaceProperty); }
            set { SetValue(UnderbarSpaceProperty, value); }
        }

        public static readonly DependencyProperty UnderbarHeightProperty
            = DependencyProperty.Register(
                nameof(UnderbarHeight),
                typeof(GridLength),
                typeof(WindowHeader),
                new FrameworkPropertyMetadata(new GridLength(1.0), _frameworkPropertyMetadataOptions));
        public GridLength UnderbarHeight
        {
            get { return (GridLength)GetValue(UnderbarHeightProperty); }
            set { SetValue(UnderbarHeightProperty, value); }
        }

        public static readonly DependencyProperty UnderbarBrushProperty
            = DependencyProperty.Register(
                nameof(UnderbarBrush),
                typeof(SolidColorBrush),
                typeof(WindowHeader),
                new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));
        public SolidColorBrush? UnderbarBrush
        {
            get { return (SolidColorBrush?)GetValue(UnderbarBrushProperty); }
            set { SetValue(UnderbarBrushProperty, value); }
        }

        public static readonly DependencyProperty FocusLostOverlayBrushProperty
            = DependencyProperty.Register(
                nameof(FocusLostOverlayBrush),
                typeof(SolidColorBrush),
                typeof(WindowHeader),
                new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));
        public SolidColorBrush? FocusLostOverlayBrush
        {
            get { return (SolidColorBrush?)GetValue(FocusLostOverlayBrushProperty); }
            set { SetValue(FocusLostOverlayBrushProperty, value); }
        }
    }


    public partial class WindowHeader : Control
    {
        private bool isDragging = false;
        private Point startPoint;

        private void MouseInit()
        {
            this.MouseLeftButtonDown += MainWindowHeader_MouseLeftButtonDown;
            this.MouseMove += MainWindowHeader_MouseMove;
            this.MouseLeftButtonUp += MainWindowHeader_MouseLeftButtonUp;
            //this.MouseDoubleClick += MainWindowHeader_MouseLeftButtonUp;
        }

        private void MainWindowHeader_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            startPoint = e.GetPosition(this);
            this.CaptureMouse();
        }

        private void MainWindowHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (WindowUnlocked is false)
                return;
            var parentWindow = Window.GetWindow(this);
            if (parentWindow is null)
                return;
            if (isDragging)
            {
                Point currentPoint = e.GetPosition(this);
                double offsetX = currentPoint.X - startPoint.X;
                double offsetY = currentPoint.Y - startPoint.Y;

                parentWindow.Left += offsetX;
                parentWindow.Top += offsetY;

                // 상태 값에 대한 추가 보정
                ToggleButton? fullScreen = GetTemplateChild("PART_FullScreen") as ToggleButton;
                if (fullScreen is null)
                    return;
                if (!fullScreen.IsChecked is false)
                    return;
                if (offsetX is not 0.0 || offsetY is not 0.0)
                    fullScreen.IsChecked = false;
            }
        }

        private void MainWindowHeader_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            this.ReleaseMouseCapture();
        }
    }

    public partial class WindowHeader : Control
    {

        public override void OnApplyTemplate()
        {


            base.OnApplyTemplate();

            Button? minimizeButton = GetTemplateChild("PART_MinimizeButton") as Button;
            if (minimizeButton != null)
                minimizeButton.Click += Minimize_Click;

            ToggleButton? fullScreen = GetTemplateChild("PART_FullScreen") as ToggleButton;
            if (fullScreen != null)
            {
                fullScreen.Checked += ToMaximized;
                fullScreen.Unchecked += ToRestore;
            }

            Button? closeButton = GetTemplateChild("PART_CloseButton") as Button;
            if (closeButton != null)
                closeButton.Click += Exit_Click;

            //windows
            //Setting
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Activated += (object? sender, EventArgs e) => {
                Border? focusOverlay = GetTemplateChild("PART_FocusLostOverlay") as Border;
                if (focusOverlay != null)
                    focusOverlay.Visibility = Visibility.Hidden;
            };

            parentWindow.Deactivated += (object? sender, EventArgs e) => {
                Border? focusOverlay = GetTemplateChild("PART_FocusLostOverlay") as Border;
                if (focusOverlay != null)
                    focusOverlay.Visibility = Visibility.Visible;
            };

        }


        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow is null)
                return;
            parentWindow.WindowState = WindowState.Minimized;
        }

        private void ToMaximized(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow is null)
                return;
            if (parentWindow.WindowState is not WindowState.Maximized)
                parentWindow.WindowState = WindowState.Maximized;
        }

        private void ToRestore(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow is null)
                return;
            if (parentWindow.WindowState is not WindowState.Normal)
                parentWindow.WindowState = WindowState.Normal;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }
    }
}
