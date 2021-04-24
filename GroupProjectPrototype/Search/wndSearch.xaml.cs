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
using GroupProjectPrototype.Main;
using System.Data;

namespace GroupProjectPrototype.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        /// <summary>
        /// the invoice ID for main to access
        /// </summary>
        public int selectedInvoiceID;

        /// <summary>
        /// a boolean indicating whether the 
        /// </summary>
        public bool invoiceSelected;

        /// <summary>
        /// represents whether a row in the datagrid is selected, and therefore whether I should let the user hit the select button
        /// </summary>
        private bool rowSelected;

        /// <summary>
        /// the search logic class for this window
        /// </summary>
        clsSearchLogic driver;

        /// <summary>
        /// the default constructor for this class
        /// </summary>
        public wndSearch()
        {
            InitializeComponent();
            driver = new clsSearchLogic();
            invoiceNumSelect.ItemsSource = driver.invoiceIDs;
            InvoiceCostSelect.ItemsSource = driver.invoicePrices;

            //make the default selection blank
            invoiceNumSelect.SelectedIndex = -1;
            InvoiceCostSelect.SelectedIndex = -1;

            rowSelected = false;

            //the submit button should only be enabled if a row is selected to submit
            submitButton.IsEnabled = false;

            dataDisplay.ItemsSource = driver.getInvoices().DefaultView;
        }


        

        /// <summary>
        /// prevents disposal of the form on close.  It seems this would cause a memory leak if you create enough search forms,
        /// but it was a suggestion by the instructor so we're going with it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        

        /// <summary>
        /// handles any of the filters being changed by refreshing the filters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filters_changed(object sender, SelectionChangedEventArgs e)
        {
            bool indexSelected = (invoiceNumSelect.SelectedIndex != -1);
            bool priceSelected = (InvoiceCostSelect.SelectedIndex != -1);
            bool dateSelected = (invoiceDateSelect.SelectedDate != null);

            //we need to verify that the values are selected before we try to retreive them, or we will have issues
            //the initial values put in are not meaningful, and should always be overwritten before use,
            //but it won't let me compile unless I have them.
            int index = -1;
            float price = -1;
            string date = "dummy";
            if(indexSelected)
            {
                index = (int)invoiceNumSelect.SelectedItem;
            }
            if(priceSelected)
            {
                price = (float)InvoiceCostSelect.SelectedItem;
            }
            if(dateSelected)
            {
                //this is code which should output the date as a string in a format which sql can read
                DateTime time = (DateTime)invoiceDateSelect.SelectedDate;
                date = time.ToString("yyyyMMdd");
            }

            //again, a dummy value that should always be overwritten, but the compiler is not smart enough to realise
            //that this else-if block literally always chooses at least one of the branches and will define it
            DataTable toDisplay = new DataTable();
            //this is ugly and bad, but I don't know how else to do it
            if(!indexSelected && !priceSelected && !dateSelected)
            {
                toDisplay = driver.getInvoices();
            }
            else if(indexSelected && !priceSelected && !dateSelected)
            {
                toDisplay = driver.getInvoices(index);
            }
            else if (indexSelected && priceSelected && !dateSelected)
            {
                toDisplay = driver.getInvoices(index, price);
            }
            else if (indexSelected && !priceSelected && dateSelected)
            {
                toDisplay = driver.getInvoices(index, date);
            }
            else if (indexSelected && priceSelected && dateSelected)
            {
                toDisplay = driver.getInvoices(index, price, date);
            }
            else if (!indexSelected && priceSelected && !dateSelected)
            {
                toDisplay = driver.getInvoices(price);
            }
            else if (!indexSelected && !priceSelected && dateSelected)
            {
                toDisplay = driver.getInvoices(date);
            }
            else if (!indexSelected && priceSelected && dateSelected)
            {
                toDisplay = driver.getInvoices(price, date);
            }

            dataDisplay.ItemsSource = toDisplay.DefaultView;

            //unselect anything they had selected if they change the index
            rowSelected = false;
            dataDisplay.SelectedIndex = -1;

        }

        /// <summary>
        /// handles the user selecting a cell in the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataDisplay_CurrentCellChanged(object sender, EventArgs e)
        {
            rowSelected = true;
            submitButton.IsEnabled = true;
        }
        
        /// <summary>
        /// handles the user clicking the clear selection button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            invoiceNumSelect.SelectedIndex = -1;
            InvoiceCostSelect.SelectedIndex = -1;

            rowSelected = false;
            submitButton.IsEnabled = false;

            dataDisplay.ItemsSource = driver.getInvoices().DefaultView;
        }

        /// <summary>
        /// handles the user clicking the submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selected = (DataRowView) dataDisplay.SelectedItem;
            selectedInvoiceID = int.Parse(selected.Row[0].ToString());
            invoiceSelected = true;
            //close the form once an index is selected
            this.Close();
        }
    }
}
