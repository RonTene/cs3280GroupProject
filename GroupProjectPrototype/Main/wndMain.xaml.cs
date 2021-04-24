using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace GroupProjectPrototype.Main
{
    /// <summary>
    /// This class handles events in the GUI of the window for the invoice system.
    /// </summary>
    public partial class wndMain : Window
    {
        /// <summary>
        /// This is an instance variable of the wndSearch type. This lets us access a search window so we can find and
        /// retrieve invoices in the invoice program.
        /// </summary>
        Search.wndSearch searchWnd;
        /// <summary>
        /// This is an instance variable of the wndItems type. It lets us access the items window so we can modify the
        /// available items in the DB and the program.
        /// </summary>
        Items.wndItems itemsWnd;
        /// <summary>
        /// This is an instance variable of my business logic class. It allows for access to business logic methods.
        /// </summary>
        clsMainLogic logic;

        /// <summary>
        /// This method is ran as the form is initialized.
        /// </summary>
        public wndMain()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;//Shutdown program on close.
                //We pass the current invoice variable of the logic class so it can be modified to represent the newly selected invoice.
                


                itemsWnd = new Items.wndItems();
                logic = new clsMainLogic();
                //Ron Tene changes: added ref keywork to reference pass, moved below logic so that logic.currentInvID actually exists
                //actually, I changed it to use a static value in the wndsearch class
                searchWnd = new Search.wndSearch();
                //We bind the items combo box to a list returned containing all items.
                itemsCB.ItemsSource = logic.GetItemList();
                //We bind the data grid of lineItems to the lineItem list in the logic class.
                itemsDG.ItemsSource = logic.lineItemList;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                                MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method is called whenever the search button is clicked. It opens the search window to search for
        /// invoices in the database. We make a copy of the original value of our current invoice.
        /// When the search window is closed, we check the copy against the current invoice and if they are different
        /// we query the new current invoice.
        /// </summary>
        /// <param name="sender">Object invoking the method</param>
        /// <param name="e">Event invoking the method.</param>
        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String originalInvoice = "";
                if (logic.currentInvID != null) {
                    originalInvoice = (String)logic.currentInvID.Clone();
                }
                searchWnd.ShowDialog();
                logic.currentInvID = Search.wndSearch.invoiceID;
                if (originalInvoice != "") {
                    if (!originalInvoice.Equals(logic.currentInvID)) {
                        ViewInvoice();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method updates the GUI to show the current invoice from the logic class. It also displays all
        /// the current invoice's lineItems.
        /// </summary>
        public void ViewInvoice()
        {
            try
            {
                //Clearing GUI data and changing GUI state.
                ClearForm();
                SelectedInvoiceState();
                //Setting invoice data in the GUI
                String[] invoiceData = logic.GetInvoice(logic.currentInvID);
                invNumTxt.Text = invoiceData[0];
                invDate.Text = invoiceData[1];
                totalCostTxt.Text = invoiceData[2];
                //Reseting DataGrid ItemSource
                itemsDG.ItemsSource = null;
                logic.lineItemList = logic.GetLineItems();
                itemsDG.ItemsSource = logic.lineItemList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Handle the error.
        /// </summary>
        /// <param name="sClass">The class in which the error occurred in.</param>
        /// <param name="sMethod">The method in which the error occurred in.</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                //Would write to a file or database here.
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// This method changes what's enabled and disabled on the form when the form is just barely started.
        /// </summary>
        private void InitialState()
        {
            try
            {
                //Invoice txt boxes
                invNumTxt.IsEnabled = false;
                invDate.IsEnabled = false;
                totalCostTxt.IsEnabled = false;
                //Invoice buttons
                newInvBtn.IsEnabled = true;
                editInvBtn.IsEnabled = false;
                deleteInvBtn.IsEnabled = false;
                saveInvBtn.IsEnabled = false;
                //Items controls
                itemsCB.IsEnabled = false;
                addItemBtn.IsEnabled = false;
                deleteItemBtn.IsEnabled = false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method enables and disables parts of the form so the user can only do things that are appropriate when
        /// creating a new invoice.
        /// </summary>
        private void NewInvoiceState()
        {
            try
            {
                //Invoice txt boxes
                invNumTxt.IsEnabled = false;
                invDate.IsEnabled = true;
                totalCostTxt.IsEnabled = false;
                //Invoice buttons
                newInvBtn.IsEnabled = true;
                editInvBtn.IsEnabled = false;
                deleteInvBtn.IsEnabled = false;
                saveInvBtn.IsEnabled = true;
                //Items controls
                itemsCB.IsEnabled = true;
                addItemBtn.IsEnabled = true;
                deleteItemBtn.IsEnabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method enables and disables controls on the form to make sure the user can only do appropriate actions
        /// when an invoice is selected and to be read-only.
        /// </summary>
        private void SelectedInvoiceState()
        {
            try
            {
                //Invoice txt boxes
                invNumTxt.IsEnabled = false;
                invDate.IsEnabled = false;
                totalCostTxt.IsEnabled = false;
                //Invoice buttons
                newInvBtn.IsEnabled = true;
                editInvBtn.IsEnabled = true;
                deleteInvBtn.IsEnabled = true;
                saveInvBtn.IsEnabled = false;
                //Items controls
                itemsCB.IsEnabled = false;
                addItemBtn.IsEnabled = false;
                deleteItemBtn.IsEnabled = false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method enables and disables controls on the form to only allow the user to do appropriate things
        /// when editing an invoice.
        /// </summary>
        private void EditInvoiceState()
        {
            try
            {
                //Invoice txt boxes
                invNumTxt.IsEnabled = false;
                invDate.IsEnabled = true;
                totalCostTxt.IsEnabled = false;
                //Invoice buttons
                newInvBtn.IsEnabled = true;
                editInvBtn.IsEnabled = false;
                deleteInvBtn.IsEnabled = true;
                saveInvBtn.IsEnabled = true;
                //Items controls
                itemsCB.IsEnabled = true;
                addItemBtn.IsEnabled = true;
                deleteItemBtn.IsEnabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method clears all the data from the form as well as reset the DataGrid.
        /// </summary>
        private void ClearForm()
        {
            try
            {
                invNumTxt.Text = "";
                invDate.Text = "";
                totalCostTxt.Text = "";
                itemsCB.SelectedItem = null;
                costTxt.Text = "";
                itemsDG.ItemsSource = null;
                //This essentially resets the logic class's lineItem list.
                logic.lineItemList = new List<clsLineItems>();
                //We reset the toDelete list as well.
                logic.toDeleteList = new List<clsLineItems>();
                itemsDG.ItemsSource = logic.lineItemList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method is called whenever the items combo box selection is changed. It fills the cost txt box for items.
        /// </summary>
        /// <param name="sender">Object invoking method.</param>
        /// <param name="e">Event invoking method.</param>
        private void itemsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((clsItems)itemsCB.SelectedItem!= null) {
                    costTxt.Text = ((clsItems)itemsCB.SelectedItem).itemCost;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method is called whenever the add button is clicked. It adds a temporary lineItem to the logic class's
        /// lineItem list.
        /// </summary>
        /// <param name="sender">Object invoking method.</param>
        /// <param name="e">Event invoking method.</param>
        private void addItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clsItems selectedItem = ((clsItems)itemsCB.SelectedItem);
                if (selectedItem != null)
                {
                    //When adding a lineItem to the list, that lineItem is temporary until the save button is clicked.
                    //It's assigned an ID of -1 to indicate it is temporary and will be assigned a real ID when the
                    //save button is clicked and the lineItem is added to the database.
                    logic.lineItemList.Add(new clsLineItems("-1", selectedItem.itemCode,selectedItem.itemDesc, selectedItem.itemCost));
                    /////I found this method of refreshing DataGrids here: https://stackoverflow.com/questions/7008361/how-can-i-refresh-c-sharp-datagridview-after-update
                    itemsDG.ItemsSource = null;
                    itemsDG.ItemsSource = logic.lineItemList;
                    /////
                    totalCostTxt.Text = logic.PreviewTotal();
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method is called when the delete item button is clicked. It adds the item to the toDeleteList in the
        /// business logic class and then it removes the item from the lineItem list used to populate the data grid.
        /// </summary>
        /// <param name="sender">Object invoking the method.</param>
        /// <param name="e">Event invoking the method.</param>
        private void deleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clsLineItems selectedItem = ((clsLineItems)itemsDG.SelectedItem);
                if (selectedItem != null)
                {
                    //Add deleted item to toDeleteList (to be deleted list)
                    logic.toDeleteList.Add(selectedItem);
                    //Remove item form the lineItemList
                    logic.lineItemList.Remove(selectedItem);
                    //Refresh data grid.
                    itemsDG.ItemsSource = null;
                    itemsDG.ItemsSource = logic.lineItemList;
                    //Update the totalCost text box.
                    totalCostTxt.Text = logic.PreviewTotal();
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method is called when the save invoice button is clicked. It either creates a new invoice or saves the
        /// changes to an existing invoice.
        /// </summary>
        /// <param name="sender">Object invoking method.</param>
        /// <param name="e">Event invoking method.</param>
        private void saveInvBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (invDate.Text != "") {
                    if (invNumTxt.Text != "TBD") {
                        logic.SaveInvoiceItems();
                        logic.DeleteInvoiceItems();
                        logic.UpdateInvoice(invDate.Text);
                    }
                    else
                    {
                        logic.CreateInvoice(invDate.Text, totalCostTxt.Text);
                        //We set our current invoice ID to the ID returned from getting the most recently inserted invoice.
                        logic.currentInvID = logic.GetLastInvoice()[0];
                        logic.SaveInvoiceItems();
                        logic.DeleteInvoiceItems();
                    }
                    //Refresh and re-display invoice.
                    ViewInvoice();
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method is called when the delete invoice button is clicked. It deletes the invoice and then clears the
        /// form and the toDeleteList as well as putting the form into its initalState.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteInvBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logic.DeleteInvoice();
                ClearForm();
                InitialState(); 
                logic.currentInvID = "";
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method is called when the edit invoice button is clicked. All it really does is change the states
        /// of the form's contorls (isEnabled or !isEnabled).
        /// </summary>
        /// <param name="sender">Object invoking the method.</param>
        /// <param name="e">Event invoking the method.</param>
        private void editInvBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditInvoiceState();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// THis method is called when the new invoice button is clicked. It modifies the data in the form to allow
        /// the user to enter a new invoice, though the invoice and its items aren't created until the save button
        /// is clicked.
        /// </summary>
        /// <param name="sender">Object invoking the method.</param>
        /// <param name="e">Event invoking the method.</param>
        private void newInvBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearForm();
                NewInvoiceState();
                invNumTxt.Text = "TBD";
                totalCostTxt.Text = "0";
                logic.currentInvID = "";
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method is called when the edit items button is clicked. This opens the items window so that the user
        /// can modify the items in the DB to change what they can use in the program.
        /// </summary>
        /// <param name="sender">Object invoking method</param>
        /// <param name="e">Event invoking method</param>
        private void itemsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                itemsWnd.ShowDialog();
                itemsCB.ItemsSource = logic.GetItemList();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
