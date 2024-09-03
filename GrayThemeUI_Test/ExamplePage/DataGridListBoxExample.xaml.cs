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
    /// DataGridListBoxExample.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DataGridListBoxExample : Page
    {
        public DataGridListBoxExample()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var data = new List<Person>
            {
                new Person { Id = 1, Name = "John Doe", Age = 30 },
                new Person { Id = 2, Name = "Jane Smith", Age = 25 },
                new Person { Id = 3, Name = "Sam Brown", Age = 35 }
            };

            dataGrid.ItemsSource = data;
        }


    }

    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }

}
