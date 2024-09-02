using GrayThemeUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace GrayThemeUI.CustomControl
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
            MouseInit();
        }

        public static readonly DependencyProperty TitleContentProperty
            = DependencyProperty.Register(
                nameof(TitleContent),
                typeof(object),
                typeof(WindowHeader),
                new PropertyMetadata(null/*new TextBlock() { Text = ""}*/));
        public object TitleContent
        {
            get { return GetValue(TitleContentProperty); }
            set { SetValue(TitleContentProperty, value); }
        }

        public static readonly DependencyProperty SideContentProperty =
            DependencyProperty.Register(nameof(SideContent), typeof(object),
                typeof(WindowHeader), new PropertyMetadata(null));

        public object SideContent
        {
            get => GetValue(SideContentProperty);
            set => SetValue(SideContentProperty, value);
        }

        public static readonly DependencyProperty WindowUnlockedProperty =
            DependencyProperty.Register("WindowUnlocked", typeof(bool),
                typeof(WindowHeader), new PropertyMetadata(true));
        public bool WindowUnlocked
        {
            get { return (bool)GetValue(WindowUnlockedProperty); }
            set { SetValue(WindowUnlockedProperty, value); }
        }

        public static readonly DependencyProperty WindowControlForegroundProperty
            = DependencyProperty.Register("WindowControlForeground", typeof(SolidColorBrush), typeof(WindowHeader),
            new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));
        public SolidColorBrush WindowControlForeground
        {
            get { return (SolidColorBrush)GetValue(WindowControlForegroundProperty); }
            set { SetValue(WindowControlForegroundProperty, value); }
        }



        public static readonly DependencyProperty ShowMinimizeProperty =
            DependencyProperty.Register("ShowMinimize", typeof(Visibility),
                typeof(WindowHeader), new PropertyMetadata(Visibility.Visible));
        public Visibility ShowMinimize
        {
            get { return (Visibility)GetValue(ShowMinimizeProperty); }
            set { SetValue(ShowMinimizeProperty, value); }
        }

        public static readonly DependencyProperty ShowToggleMaximizeRestoreProperty =
            DependencyProperty.Register("ShowToggleMaximizeRestore",
                typeof(Visibility), typeof(WindowHeader), new PropertyMetadata(Visibility.Visible));
        public Visibility ShowToggleMaximizeRestore
        {
            get { return (Visibility)GetValue(ShowToggleMaximizeRestoreProperty); }
            set { SetValue(ShowToggleMaximizeRestoreProperty, value); }
        }

        public static readonly DependencyProperty ShowCloseProperty =
            DependencyProperty.Register("ShowClose", typeof(Visibility),
                typeof(WindowHeader), new PropertyMetadata(Visibility.Visible));
        public Visibility ShowClose
        {
            get { return (Visibility)GetValue(ShowCloseProperty); }
            set { SetValue(ShowCloseProperty, value); }
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
                ToggleButton? fullScreen = GetTemplateChild("fullScreen") as ToggleButton;
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

            Button? minimizeButton = GetTemplateChild("minimizeButton") as Button;
            if (minimizeButton != null)
                minimizeButton.Click += Minimize_Click;

            ToggleButton? fullScreen = GetTemplateChild("fullScreen") as ToggleButton;
            if (fullScreen != null)
            {
                fullScreen.Checked += ToMaximized;
                fullScreen.Unchecked += ToRestore;
            }

            Button? closeButton = GetTemplateChild("closeButton") as Button;
            if (closeButton != null)
                closeButton.Click += Exit_Click;
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
