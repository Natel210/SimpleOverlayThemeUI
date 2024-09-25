using SimpleOverlayTheme.ThemeSystem;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleOverlayThemeExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private bool _isdark = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _isdark = !_isdark;


            if (_isdark is true)
                Manager.CurrentThemeName = "Dark";
            else
                Manager.CurrentThemeName = "Light";
        }
    }
}