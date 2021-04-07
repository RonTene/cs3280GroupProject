using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows;

namespace GroupProjectPrototype.Items
{
    /// <summary>
    /// Class that handles the SQL
    /// </summary>
    class clsItemsSQL
    {
        /// <summary>
        /// Select all from ItemDesc
        /// </summary>
        /// <returns></returns>
        public string SelectItemData()
        {
            string sSQL = "SELECT * FROM ItemDesc";
            return sSQL;
        }


        /// <summary>
        /// Select invoice number for item
        /// </summary>
        /// <param name="sItemCode">Item code</param>
        /// <returns></returns>
        public string SelectInvoiceForItem(string sItemCode)
        {
            string sSQL = "SELECT InvoiceNum FROM LineItems " +
                "WHERE ItemCode = '" + sItemCode + "'";
            return sSQL;
        }

        /// <summary>
        /// Update item in the ItemDesc
        /// </summary>
        /// <param name="sItemCode">Item code</param>
        /// <param name="sItemDescription">Item description</param>
        /// <param name="sItemCost">Item cost</param>
        /// <returns></returns>
        public string UpdateItem(string sItemCode, string sItemDescription, string sItemCost)
        {
            string sSQL = "UPDATE ItemDesc SET ItemDesc = '" + sItemDescription + "', Cost = " + sItemCost +
                " WHERE ItemCode = '" + sItemCode + "'";
            return sSQL;
        }

        /// <summary>
        /// Inserts a new Item into the ItemDesc
        /// </summary>
        /// <param name="sItemCode">New Item code</param>
        /// <param name="sItemDesc">Item description</param>
        /// <param name="sItemCost">Item cost</param>
        /// <returns></returns>
        public string InsertItem(string sItemCode, string sItemDesc, string sItemCost)
        {
            string sSQL = "INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost) " +
                "VALUES ('" + sItemCode + "', '" + sItemDesc + "', " + sItemCost + ")";
            return sSQL;
        }

        /// <summary>
        /// Delete item from the ItemDesc
        /// </summary>
        /// <param name="sItemCode">Item code to be deleted</param>
        /// <returns></returns>
        public string DeleteItem(string sItemCode)
        {
            string sSQL = "DELETE * FROM ItemDesc WHERE ItemCode = '" + sItemCode + "'";
            return sSQL;
        }

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
