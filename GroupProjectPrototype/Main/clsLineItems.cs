using System;
using System.Reflection;

namespace GroupProjectPrototype.Main
{
    /// <summary>
    /// This class defines the LineItem object type. It's used to show object representations of items belonging
    /// to invoices in the mainWindow.
    /// </summary>
    public class clsLineItems
    {
        /*
         * I was having issues because my data grid would populate, but it wouldn't show the data of the items, so I 
         * found a solution to the problem here: https://stackoverflow.com/questions/28711940/wpf-datagrid-adds-rows-but-not-the-data-blank-rows
         * Essentially I didn't know that {get;set;} was needed to show the data in a datagrid. After I found this solution
         * I decided I didn't want lineItemNum showing in the datagrid as it's a primary key and rather useless to the
         * user and so I didn't give it {get;set;}
        */
        /// <summary>
        /// This is the PK for a lineItem entry which identifies an individual item that's added to an invoice.
        /// </summary>
        public String lineItemNum;
        /// <summary>
        /// This is the code of the item being added to an invoice.
        /// </summary>
        public String itemCode { get; set; }
        /// <summary>
        /// This is the name of the item being added to an invoice.
        /// </summary>
        public String itemDescription { get; set; }
        /// <summary>
        /// This is the cost of the item being added to an invoice.
        /// </summary>
        public String itemCost { get; set; }

        /// <summary>
        /// This is the constructor for the lineItem type.
        /// </summary>
        /// <param name="lineItemNum">This is the PK of the lineItem.</param>
        /// <param name="itemCode">This is the code of the item being entered.</param>
        /// <param name="itemDescription">This is the name of the item being entered.</param>
        /// <param name="itemCost">This is the cost of the item being entered.</param>
        public clsLineItems(String lineItemNum, String itemCode, String itemDescription, String itemCost)
        {
            try
            {
                this.lineItemNum = lineItemNum; 
                this.itemCode = itemCode;
                this.itemDescription = itemDescription;
                this.itemCost = itemCost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This is the string representation of this item type. It's just the item name, a space, and then the cost.
        /// </summary>
        /// <returns>String representation of object.</returns>
        override
        public String ToString()
        {
            try
            {
                return this.itemDescription + " " + itemCost;
            } 
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
