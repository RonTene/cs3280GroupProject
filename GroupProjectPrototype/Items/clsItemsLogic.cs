using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;

namespace GroupProjectPrototype.Items
{
    /// <summary>
    /// Class that handles the logic
    /// </summary>
    class clsItemsLogic
    {

        // Get Database data to populate DataGrid (calls SelectItemData())

        // Update Item when user cursors out of a field (calls UpdateItem())

        // Add Item when user adds a row in the DataGrid (calls InsertItem())

        // Delete Item when user deletes row in the DataGrid (calls DeleteItem())
        // Checks to see if item is on invoice (calls SelectInvoiceForItem())
        // Displays error message with invoice that item is on

        // Method for when Window is closing that updates the list for the drop-down on main menu
        // Also updates cost of invoice if deleted



        /// <summary>
        /// Instance of Item class
        /// </summary>
        clsItem Item;

        /// Collection of Items objects
        /// </summary>
        private ObservableCollection<clsItem> lItems;

        /// <summary>
        /// Instance of the DataAccess class
        /// </summary>
        ///clsDataAccess db;

        /// <summary>
        /// Instance of the ItemsSQL class
        /// </summary>
        clsItemsSQL SQL;

        /// <summary>
        /// Dataset
        /// </summary>
        private DataSet ds;

        /// <summary>
        /// Number of SQL rows retrieved
        /// </summary>
        public int iRet;

        /// <summary>
        /// Gets items to populate Data Grid
        /// </summary>
        /// <returns></returns>
        /*
        public ObservableCollection<clsItem> GetItems()
        {
            ///call SelectItemData())
            ///TODO
        }
        */

        /// <summary>
        /// Gets item data from Data Grid
        /// </summary>
        /// <returns></returns>
        /*
        public clsItem GetItemData()
        {
            //TODO
        }
        */

        /// <summary>
        /// Update existing Item in database
        /// </summary>
        public void UpdateItem()
        {
            //TODO
        }

        /// <summary>
        /// Create new item in database
        /// </summary>
        public void CreateItem()
        {
            ///TODO
        }

        /// <summary>
        /// Delete Item from database
        /// </summary>
        /*
        public List<string> DeleteItem()
        {
            ///TODO
        }
        */

        /*
        /// <summary>
        /// Handles errors
        /// </summary>
        public void HandleError()
        {
            ///TODO
        }
        */
    }
}
