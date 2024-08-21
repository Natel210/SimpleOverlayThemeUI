using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GrayThemeUI
{
    /// <summary>
    /// WindowHeader.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WindowHeader : UserControl
    {
        public WindowHeader()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += MainWindowHeader_MouseLeftButtonDown;
            this.MouseMove += MainWindowHeader_MouseMove;
            this.MouseLeftButtonUp += MainWindowHeader_MouseLeftButtonUp;
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(WindowHeader), new PropertyMetadata(""));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty AddOnItemProperty =
            DependencyProperty.Register(nameof(AddOnItem), typeof(object), typeof(WindowHeader), new PropertyMetadata(null));

        public object AddOnItem
        {
            get => GetValue(AddOnItemProperty);
            set => SetValue(AddOnItemProperty, value);
        }

        public static readonly DependencyProperty WindowUnlockedProperty =
            DependencyProperty.Register("WindowUnlocked", typeof(bool), typeof(WindowHeader), new PropertyMetadata(true));
        public bool WindowUnlocked
        {
            get { return (bool)GetValue(WindowUnlockedProperty); }
            set { SetValue(WindowUnlockedProperty, value); }
        }

        public static readonly DependencyProperty ShowMinimizeProperty =
            DependencyProperty.Register("ShowMinimize", typeof(Visibility), typeof(WindowHeader), new PropertyMetadata(Visibility.Visible));
        public Visibility ShowMinimize
        {
            get { return (Visibility)GetValue(ShowMinimizeProperty); }
            set { SetValue(ShowMinimizeProperty, value); }
        }

        public static readonly DependencyProperty ShowToggleMaximizeRestoreProperty =
            DependencyProperty.Register("ShowToggleMaximizeRestore", typeof(Visibility), typeof(WindowHeader), new PropertyMetadata(Visibility.Visible));
        public Visibility ShowToggleMaximizeRestore
        {
            get { return (Visibility)GetValue(ShowToggleMaximizeRestoreProperty); }
            set { SetValue(ShowToggleMaximizeRestoreProperty, value); }
        }

        public static readonly DependencyProperty ShowCloseProperty =
            DependencyProperty.Register("ShowClose", typeof(Visibility), typeof(WindowHeader), new PropertyMetadata(Visibility.Visible));
        public Visibility ShowClose
        {
            get { return (Visibility)GetValue(ShowCloseProperty); }
            set { SetValue(ShowCloseProperty, value); }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow is null)
                return;
            parentWindow.WindowState = WindowState.Minimized;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }

        private bool isDragging = false;
        private Point startPoint;

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

                    if (fullScreen.IsChecked is true)
                    {
                        if (offsetX is not 0.0 || offsetY is not 0.0)
                            fullScreen.IsChecked = false;
                    }
            }
        }

        private void MainWindowHeader_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            this.ReleaseMouseCapture();
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
    }
}
