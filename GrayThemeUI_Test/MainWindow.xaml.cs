using GrayThemeUI_Test.ExamplePage;
using System.Windows;

namespace GrayThemeUI_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            windowHeaderExample.Navigate(new WindowHeaderExample());
            labelTextsExample.Navigate(new LabelTextsExample());
            buttonExample.Navigate(new ButtonExample());
            checkComboGroupBoxExample.Navigate(new CheckComboGroupBoxExample());
            dataGridListBoxExample.Navigate(new DataGridListBoxExample());
            
        }

    }
}