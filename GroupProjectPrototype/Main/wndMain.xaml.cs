using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace GroupProjectPrototype.Main
{
    /// <summary>
    /// This class handles events in the GUI of the window for the invoice system.
    /// Created by Daniel Stagg
    /// </summary>
    public partial class wndMain : Window
    {
        //wndSearch searchWnd; //This creates an instance variable of a search window to let us pass data between forms.
        //wndItems itemsWnd; //This creates an instance variable of a item window to allow data passing.

        /// <summary>
        /// This method is ran as the form is initialized.
        /// </summary>
        public wndMain()
        {
            try
            {
                InitializeComponent();
                /*
                 * We initialize our search window and pass this instance of the form through so that the search window
                 * can call public methods in this form to let us pass data back and forth via methods.
                 */
                //searchWnd = new wndSearch(this);
                //itemsWnd = new wndItems(this);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine("Search button clicked!");
                //searchWnd.ShowDialog;
                /*
                 This button event will open our search window so we can work with it and search for invoices
                for this main form.
                 */
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method takes an invoiceID and then updates the window to display that selected invoice as well
        /// as its items that are apart of the invoice.
        /// </summary>
        /// <param name="invoiceID">The ID of the invoice to be selected.</param>
        public void retSelectedInvoice(int invoiceID)
        {
            try
            {
                /*
                 This method will be called from the search window whenever an invoice is selected with the select button.
                On that screen, this method will be ran with a given invoice ID. When ran, this method will set an instance
                variable currentInvoice to the given invoice, and then call another method that takes this invoiceID as
                well as 3 strings which will be strings from the form's textboxes. The other method will be called genInvData
                and will use the sql class to get data from the tables and will then set the given strings to that data, which
                will update the textboxes on wndMain. Then this method will call one last method from clsMainLogic called
                updateDG that takes the invoiceID and a Data Grid. This method will use a SQL statement to get a table
                full of all LineItems that belong to the given invoice and will then populate the Data Grid so it contains
                all the LineItems.
                 */
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method will be called by other windows to refresh this window's items in the drop box.
        /// </summary>
        public void refreshItemBox()
        {
            try
            {
                /*
                 This method will be called when the close button is clicked on the items window. This method will update
                the drop box in this window (combo box is what it is.) and it will do this by calling another method in
                clsMainLogic called refreshDropBox. That method will return a list that contains all the items in the
                database. It will do that by calling a SQL statement that returns all the items in the database and then
                going through the table and adding the items to the list.
                Since the item window will allow adding and deleting from the database, this method should
                return an accurate list everytime it is called. So everytime that the items window is closed, this method
                will run which will bind the drop box of items to a new list everytime that contains all the items in the
                database, effectively updating the items.
                 */
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
    }
}
