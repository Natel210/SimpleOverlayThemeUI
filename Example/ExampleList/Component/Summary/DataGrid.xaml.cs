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

namespace SimpleOverlayTheme.Example.ExampleList.Component.Summary
{
    /// <summary>
    /// DataGrid.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DataGrid : UserControl
    {
        public DataGrid()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var data = new List<Person>
            {

            };

            var data1 = new Person { ID = 1, Check = false, Name = "John Doe", Age = 30 };
            var data2 = new Person { ID = 2, Check = false, Name = "Jane Smith", Age = 25 };
            var data3 = new Person { ID = 3, Check = false, Name = "Sam Brown", Age = 35 };

            dataGrid.ItemsSource = new List<Person> { data1, data2, data3 };
        }

        public class Person
        {
            public int ID { get; set; }
            public bool Check { get; set; }
            public string? Name { get; set; }
            public int Age { get; set; }
        }

        private void SelectionUnit_Cell_Checked(object sender, RoutedEventArgs e)
        {
            if (dataGrid is null)
                return;
            dataGrid.SelectionUnit = DataGridSelectionUnit.Cell;
        }

        private void SelectionUnit_CellOrRowHeader_Checked(object sender, RoutedEventArgs e)
        {
            if (dataGrid is null)
                return;
            dataGrid.SelectionUnit = DataGridSelectionUnit.CellOrRowHeader;
        }

        private void SelectionUnit_FullRow_Checked(object sender, RoutedEventArgs e)
        {
            if (dataGrid is null)
                return;
            dataGrid.SelectionUnit = DataGridSelectionUnit.FullRow;
        }
    }
}
