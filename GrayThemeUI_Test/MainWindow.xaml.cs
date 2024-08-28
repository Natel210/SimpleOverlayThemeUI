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
            LoadData();
            GrayThemeUI.Theme.ThemeSettingDataManager.CurrentThemeName = "Dark";
        }

        private void LoadData()
        {
            //var data = new List<Person>
            //{
            //    new Person { Id = 1, Name = "John Doe", Age = 30 },
            //    new Person { Id = 2, Name = "Jane Smith", Age = 25 },
            //    new Person { Id = 3, Name = "Sam Brown", Age = 35 }
            //};

            //dataGrid.ItemsSource = data;

        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}