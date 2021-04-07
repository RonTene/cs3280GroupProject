using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectPrototype.Main
{
    /// <summary>
    /// This class contains all the sql statements that will be needed for this window.
    /// Created by Daniel Stagg
    /// </summary>
    public class clsMainSQL
    {

        /// <summary>
        /// This SQL gets all data on an invoice for a given InvoiceID.
        /// </summary>
        /// <param name="sInvoiceID">The InvoiceID for the invoice to retrieve all data.</param>
        /// <returns>All data for the given invoice.</returns>
        public string SelectInvoiceData(string sInvoiceID)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This SQL statement returns every piece of data for every item in the system.
        /// </summary>
        /// <returns>Returns all data from every item.</returns>
        public string SelectItemData()
        {
            try
            {
                string sSQL = "SELECT * FROM ItemDesc";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This SQL will return all LineItems in an invoice and show what the items are, 
        /// their cost, and their description, as well as the LineItems ID (for deleting specific LineItems).
        /// </summary>
        /// <param name="sInvoiceID">This is the Invoice's ID which is used so we can find every item under an invoice.</param>
        /// <returns>All items that are part of an invoice</returns>
        public string SelectInvoiceItems(String sInvoiceID)
        {
            try
            {
                string sSQL = "SELECT LineItems.LineItemNum, LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost " +
                    "FROM LineItems, ItemDesc " +
                    "Where LineItems.ItemCode = ItemDesc.ItemCode And LineItems.InvoiceNum = "+ sInvoiceID;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This SQL statement inserts an invoice based on the given date and cost.
        /// </summary>
        /// <param name="date">The date the user would like the invoice to have. (should be in form MM/DD/YYYY)</param>
        /// <param name="totalCost">The total cost of the invoice.</param>
        /// <returns>This returns the string of the statement needed to execute an insert SQL statement.</returns>
        public string InsertInvoice(String date, String totalCost)
        {
            try
            {
                string sSQL = "INSERT INTO Invoices (InvoiceDate, TotalCost) Values ('#"+date+"#', "+totalCost+")";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This SQL statement inserts a LineItem, meaning it adds items to an invoice.
        /// </summary>
        /// <param name="invoiceNum">This is the invoice we'd like to add an item to.</param>
        /// <param name="lineItemNum">This is the PK for the item entry.</param>
        /// <param name="itemCode">This is the item we'd like to add to the invoice.</param>
        /// <returns>Returns the SQL string for inserting an item to an invoice.</returns>
        public string InsertLineItem(String invoiceNum, String lineItemNum, String itemCode)
        {
            try
            {
                string sSQL = "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) " +
                    "Values ("+invoiceNum+", "+lineItemNum+", "+itemCode+")";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This SQL will delete an invoice based on a given InvoiceNumber
        /// </summary>
        /// <param name="invoiceNum">The identifying number for the invoice to be deleted.</param>
        /// <returns>A string of the sql statement to delete a specific invoice.</returns>
        public string DeleteInvoice(String invoiceNum)
        {
            try
            {
                string sSQL = "DELETE From Invoices WHERE InvoiceNum = "+invoiceNum;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This SQL deletes all lineItems associated with a given invoice.
        /// </summary>
        /// <param name="invoiceNum">Identifying number of the invoice we'd like to delete all lineItems of.</param>
        /// <returns>Returns string to delete all lineItems of a given invoice.</returns>
        public string DeleteInvoiceLineItems(String invoiceNum)
        {
            try
            {
                string sSQL = "DELETE From LineItems WHERE InvoiceNum = " + invoiceNum;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This SQL deletes a singular lineItem based on its identifying number.
        /// </summary>
        /// <param name="lineItemNum">The identifer of the lineItem to be deleted.</param>
        /// <returns>Returns SQL string to delete a line item based on Line item number.</returns>
        public string DeleteLineItem(String lineItemNum)
        {
            try
            {
                string sSQL = "DELETE From LineItems WHERE LineItemNum = " + lineItemNum;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This SQL Updates the totalCost of an invoice based on invoice number and given cost.
        /// </summary>
        /// <param name="invoiceNum">Identifier of the invoice to be changed.</param>
        /// <param name="totalCost">This is what we'd like to change the total cost to.</param>
        /// <returns>Returns a string of the SQL to update the cost of a given invoice.</returns>
        public string UpdateInvoiceCost(String invoiceNum, String totalCost)
        {
            try
            {
                string sSQL = "UPDATE Invoices SET TotalCost = "+totalCost+" WHERE InvoiceNum = " + invoiceNum;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

       /// <summary>
       /// This SQL updates an invoice's date to the given date.
       /// </summary>
       /// <param name="invoiceNum">The invoice identifier for the invoice to be changed.</param>
       /// <param name="date">The new date the invoice will be given.</param>
       /// <returns>This returns a string for updating the date of an invoice.</returns>
        public string UpdateInvoiceDate(String invoiceNum, String date)
        {
            try
            {
                string sSQL = "UPDATE Invoices SET InvoiceDate = #" + date + "# WHERE InvoiceNum = " + invoiceNum;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This generates a SQL statement that can go through invoices and find the total cost of all items.
        /// </summary>
        /// <param name="invoiceNum">The invoice we'd like to find the total for</param>
        /// <returns>Returns a SQL string that finds the sum of all invoice item's costs.</returns>
        public string SelectInvoiceTotal(String invoiceNum)
        {
            try
            {
                string sSQL = "SELECT SUM(i.Cost) FROM ItemDesc i" +
                    "inner join LineItems l on l.ItemCode = i.ItemCode" +
                    "where l.InvoiceNum = " + invoiceNum;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method returns the invoice with the largest identifier, meanign the last since invoice is on 
        /// auto increment.
        /// </summary>
        /// <returns>Returns string that executes SQL to return invoice with largest ID number.</returns>
        public string SelectLastInvoice()
        {
            try
            {
                string sSQL = "SELECT MAX(InvoiceNum) FROM Invoices";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method returns a sql statement that gives the LineItem with the largest LineItemNum.
        /// This will most likely be used to have an easy way to find a free PK for lineItems since once you find
        /// the largest number, you just add one and you have a new ID.
        /// </summary>
        /// <returns>Returns a SQL string that will return the largest lineItem num.</returns>
        public string SelectLastLineItem()
        {
            try
            {
                string sSQL = "SELECT MAX(LineItemNum) FROM LineItems";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
