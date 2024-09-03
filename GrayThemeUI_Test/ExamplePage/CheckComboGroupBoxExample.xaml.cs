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

namespace GrayThemeUI_Test.ExamplePage
{
    /// <summary>
    /// CheckComboGroupBoxExample.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CheckComboGroupBoxExample : Page
    {
        public CheckComboGroupBoxExample()
        {
            InitializeComponent();
            grayThemeUIComboBox.SelectedIndex = 0;
            grayThemeUIComboBox2.SelectedIndex = 1;
            grayThemeUIComboBox3.SelectedIndex = 2;
        }
    }
}
