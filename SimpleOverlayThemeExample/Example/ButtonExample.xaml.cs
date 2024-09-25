using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleOverlayThemeExample.Example
{
    /// <summary>
    /// ButtonExample.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ButtonExample : UserControl
    {
        public ButtonExample()
        {
            InitializeComponent();
        }

        private int _repeatNormalClickCount = 0;

        private void NormalClick(object sender, RoutedEventArgs e)
        {
            ++_repeatNormalClickCount;
            NormalRepeatButtonDis.Content = $"Disable({_repeatNormalClickCount})";
        }

        private void NormalPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            _repeatNormalClickCount = 0;
            NormalRepeatButtonDis.Content = $"Disable({_repeatNormalClickCount})";
        }

        private int _repeatNoBackDefCount = 0;

        private void NoBackDefClick(object sender, RoutedEventArgs e)
        {
            ++_repeatNoBackDefCount;
            NoBackDefRepeatButtonDis.Content = $"Disable({_repeatNoBackDefCount})";
        }

        private void NoBackDefPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            _repeatNoBackDefCount = 0;
            NoBackDefRepeatButtonDis.Content = $"Disable({_repeatNoBackDefCount})";
        }

        private int _repeatNoBackCount = 0;

        private void NoBackClick(object sender, RoutedEventArgs e)
        {
            ++_repeatNoBackCount;
            NoBackRepeatButtonDis.Content = $"Disable({_repeatNoBackCount})";
        }

        private void NoBackPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            _repeatNoBackCount = 0;
            NoBackRepeatButtonDis.Content = $"Disable({_repeatNoBackCount})";
        }

        private int _repeatNoOutlineCount = 0;

        private void NoOutlineClick(object sender, RoutedEventArgs e)
        {
            ++_repeatNoOutlineCount;
            NoOutlineRepeatButtonDis.Content = $"Disable({_repeatNoOutlineCount})";
        }
        private void NoOutlinePreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            _repeatNoOutlineCount = 0;
            NoOutlineRepeatButtonDis.Content = $"Disable({_repeatNoOutlineCount})";
        }

        private int _repeatImageNormalCount = 0;

        private void ImageNormalClick(object sender, RoutedEventArgs e)
        {
            ++_repeatImageNormalCount;
            ImageNormalCounter.Text = $"({_repeatImageNormalCount})";
        }
        private void ImageNormalPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            _repeatImageNormalCount = 0;
            ImageNormalCounter.Text = $"({_repeatImageNormalCount})";
        }

        private int _repeatImageUseDefCount = 0;

        private void ImageUseDefClick(object sender, RoutedEventArgs e)
        {
            ++_repeatImageUseDefCount;
            ImageUseDefCounter.Text = $"({_repeatImageUseDefCount})";
        }
        private void ImageUseDefPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            _repeatImageUseDefCount = 0;
            ImageUseDefCounter.Text = $"({_repeatImageUseDefCount})";
        }
    }
}
