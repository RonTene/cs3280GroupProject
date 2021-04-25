using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace GroupProjectPrototype.Main
{
    /// <summary>
    /// This class handles all the business logic for the main window. It handles all interaction with the database
    /// and other objects.
    /// </summary>
    public class clsMainLogic
    {
        /// <summary>
        /// This is a string that holds the ID of the current invoice, which is the invoice being viewed or manipulated
        /// in the main window.
        /// </summary>
        public string currentInvID;
        /// <summary>
        /// This is the instance variable of the sql class so we can access the sql queries.
        /// </summary>
        private clsMainSQL sql;
        /// <summary>
        /// This is a data access variable used so we can access the database
        /// </summary>
        private clsDataAccess clsData;
        /// <summary>
        /// This is a dataset variable used so we can represent tables and pull data from said tables.
        /// </summary>
        private DataSet ds;
        /// <summary>
        /// This is a list that holds all lineItems of the current invoice. It's used for mainWindow interaction
        /// as well as being able to add items to an invoice when the save button is clicked.
        /// </summary>
        public List<clsLineItems> lineItemList;
        /// <summary>
        /// This is the toDeleteList which holds lineItems that have been deleted in the mainWindow, but have yet
        /// to be deleted from the data base.
        /// </summary>
        public List<clsLineItems> toDeleteList;

        /// <summary>
        /// This is the constructor for the clsMainLogic object type. It initalizes all necessary variables.
        /// </summary>
        public clsMainLogic()
        {
            try
            {
                sql = new clsMainSQL();
                clsData = new clsDataAccess();
                ds = new DataSet();
                lineItemList = new List<clsLineItems>();
                toDeleteList = new List<clsLineItems>();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method creates a new invoice with a given date and total cost.
        /// </summary>
        /// <param name="date">Date of the invoice.</param>
        /// <param name="totalCost">Total cost of the invoice (sum of all lineItem cost)</param>
        public void CreateInvoice(String date, String totalCost)
        {
            try
            {
                clsData.ExecuteNonQuery(sql.InsertInvoice(date,totalCost));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method creates a new lineItem for the current invoice with a given itemCode.
        /// </summary>
        /// <param name="itemCode">Code of the item being added to the invoice.</param>
        public void CreateLineItem(String itemCode)
        {
            try
            {
                clsData.ExecuteNonQuery(sql.InsertLineItem(currentInvID, GetNextLineNumber(), itemCode));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// This method updates the current invoice with the given date.
        /// </summary>
        /// <param name="date">The date we'd like to set the invoice's date to.</param>
        public void UpdateInvoice(String date)
        {
            try
            {
                //This string is set to the result of a query to find the sum of all lineItem costs belonging to an invoice.
                String totalCost = clsData.ExecuteScalarSQL(sql.SelectInvoiceTotal(currentInvID));
                //This query updates the totalCost attribute of an invoice with our string above
                clsData.ExecuteNonQuery(sql.UpdateInvoiceCost(currentInvID,totalCost));
                //This query updates the invoice's date based on the given date string
                clsData.ExecuteNonQuery(sql.UpdateInvoiceDate(currentInvID, date));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns an array containing the data of an invoice that's selected based on a given invoiceNum (ID)
        /// </summary>
        /// <param name="invoiceNum">The ID or PK of the invoice to be selected.</param>
        /// <returns>String array containing invoice information.</returns>
        public String[] GetInvoice(String invoiceNum)
        {
            try
            {
                int iRet = 0;
                ds = clsData.ExecuteSQLStatement(sql.SelectInvoice(invoiceNum), ref iRet);
                return new string[] { 
                    ds.Tables[0].Rows[0][0].ToString() , //This is the invoiceNum [0]
                    ds.Tables[0].Rows[0][1].ToString() , //This is the invoiceDate [1]
                    ds.Tables[0].Rows[0][2].ToString() };//This is the invoiceTotalCost [2]
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method returns an array containing the information of the invoice last inserted (created most recently)
        /// </summary>
        /// <returns>String array containing the information of the most recently created invoice.</returns>
        public String[] GetLastInvoice()
        {
            try
            {
                String lastInvNum = clsData.ExecuteScalarSQL(sql.SelectLastInvoice());
                return GetInvoice(lastInvNum);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method finds the lineItem with the maximum ID number and adds 1 to it to find a new free ID number
        /// which is used to create new lineItems.
        /// </summary>
        /// <returns>String representation of the maximum lineItem number + 1</returns>
        public String GetNextLineNumber()
        {
            try
            {
                int maxNum; //Integer to cast the string to
                String maxLineItem = clsData.ExecuteScalarSQL(sql.SelectLastLineItem());//Maximum lineItemNumber query
                Int32.TryParse(maxLineItem, out maxNum); //Parsing string to int
                maxNum++;//Adding 1 to find new ID
                return ""+maxNum; //Cast back to string for return.
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method queries the database to get all the items, turn those into objects, and then return
        /// a list of those objects for use in the mainWindow.
        /// </summary>
        /// <returns>List containing every item in the DB.</returns>
        public List<clsItems> GetItemList()
        {
            try
            {
                List<clsItems> items = new List<clsItems>();
                int iRet = 0;
                ds = clsData.ExecuteSQLStatement(sql.SelectItems(), ref iRet);
                for (int i = 0; i < iRet; i++) //For loop to cycle through all returned values and create an object from returned values
                {
                    items.Add(new clsItems(
                    ds.Tables[0].Rows[i][0].ToString(),
                    ds.Tables[0].Rows[i][1].ToString(),
                    ds.Tables[0].Rows[i][2].ToString()));
                }
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method returns all the lineItems for the current invoice in a list of the object type clsLineItems.
        /// </summary>
        /// <returns>Returns list of all lineItems of the current invoice.</returns>
        public List<clsLineItems> GetLineItems()
        {
            try
            {
                List<clsLineItems> items = new List<clsLineItems>();
                int iRet = 0;
                ds = clsData.ExecuteSQLStatement(sql.SelectLineItems(currentInvID), ref iRet);
                for (int i = 0; i < iRet; i++)
                {
                    items.Add(new clsLineItems(
                    ds.Tables[0].Rows[i][0].ToString(),
                    ds.Tables[0].Rows[i][1].ToString(),
                    ds.Tables[0].Rows[i][2].ToString(),
                    ds.Tables[0].Rows[i][3].ToString()));
                }
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method deletes the current invoice. First it deletes all its lineItems, and then the invoice is deleted.
        /// </summary>
        public void DeleteInvoice()
        {
            try
            {
                    //Deletes all lineItems belonging to the currentInvoice.
                    clsData.ExecuteNonQuery(sql.DeleteInvoiceLineItems(currentInvID));
                    //Deletes the current invoice itself once it has no corresponding data.
                    clsData.ExecuteNonQuery(sql.DeleteInvoice(currentInvID));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method deletes a lineItem based on its ID. It's used for individual lineItems.
        /// </summary>
        /// <param name="lineItemNum">The number or ID of the lineItem to be deleted.</param>
        public void DeleteLineItem(String lineItemNum)
        {
            try
            {
                clsData.ExecuteNonQuery(sql.DeleteLineItem(lineItemNum));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method gives a preview of the totalCost of an invoice. It's not the official one in the database
        /// until the save button is clicked. This scrolls through the lineItemList used to populate the data grid
        /// and sums up the costs of all items on the invoice.
        /// </summary>
        /// <returns>String representing the totalCost.</returns>
        public String PreviewTotal()
        {
            try
            {
                int total = 0;
                //We make sure the list isn't null and that it has items before we do anything.
                if (lineItemList != null) {
                    for (int i = 0;i<lineItemList.Count;i++)//We loop through the list to select every item.
                    {
                        int itemCost = 0;
                        Int32.TryParse(lineItemList[i].itemCost,out itemCost);//The string is parsed to an int.
                        total += itemCost;//The new int representing item cost is added to the total.
                    }
                }
                return "" + total;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method is called whenever an invoice is saved. It goes through the itemsList representing
        /// invoice items (lineItems) and saves any temporary items to the database under the current invoice.
        /// </summary>
        public void SaveInvoiceItems()
        {
            try
            {
                if (lineItemList != null) {
                    for (int i = 0; i < lineItemList.Count; i++) {
                        //The program is set up so that added items that aren't saved (temporary items) will have
                        //a lineItemNum of -1 (a value that no other lineItem has for ID) When the invoice is saved
                        //and this method is called, we go through the list of lineItems and save all the temporary items
                        //By inserting them into the database.
                        if (lineItemList[i].lineItemNum == "-1") {
                            CreateLineItem(lineItemList[i].itemCode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Whenever an item in the data grid on wndMain is deleted, it is added to the toDeleteList.
        /// If the invoice is saved, this method is called and the delete list is cycled through.
        /// If the lineItem is in the database, it is then deleted from the database to save the changes.
        /// </summary>
        public void DeleteInvoiceItems()
        {
            try
            {
                if (toDeleteList != null)
                {
                    for (int i = 0; i < toDeleteList.Count; i++)
                    {
                        //LineItems in the database won't have an ID of -1, so if it doesn't have ID of -1
                        //we will delete that lineItem from the database.
                        if (toDeleteList[i].lineItemNum != "-1")
                        {
                            DeleteLineItem(toDeleteList[i].lineItemNum);
                        }
                    }
                }
                //Whenever this method is called and all the deleting is done, we empty the delete list
                //by re-initializing the list into an empty new one.
                toDeleteList = new List<clsLineItems>();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
