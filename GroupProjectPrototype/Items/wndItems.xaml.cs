using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace GroupProjectPrototype.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        clsItemsLogic ItemsLogic;
        public wndItems()
        {
            InitializeComponent();

            ItemsLogic = new clsItemsLogic();
            // Must populate DataGrid with ItemDesc table data.
        }

        // Method required to execute SQL statement when entering in new information to existing items.

        // Method required to execute SQL statement when inserting a new item.

        // Method required to execute SQL statement when deleting an item.

        // This method needs to pass in the updated list of items for the drop-down box and update the cost of the currently selected invoice
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void itemsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bDeleteItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bEditItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bAddItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
