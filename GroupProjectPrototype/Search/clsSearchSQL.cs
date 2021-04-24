using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;

namespace GroupProjectPrototype.Search
{
    public class clsSearchSQL
    {


        /// <summary>
        /// default constructor
        /// </summary>
        public clsSearchSQL()
        {
        }

        /// <summary>
        /// returns the full Invoices table from the database
        /// </summary>
        /// <param name="retval">an int indicating the length of the returned table</param>
        /// <returns>a dataset containing the selected table</returns>
        public string getInvoicesTable()
        {
            return "select * from Invoices";
        }
        /// <summary>
        /// returns invoices filtered by cost alone
        /// </summary>
        /// <param name="cost">the total cost of the invoice</param>
        /// <returns>invoices filtered by cost alone</returns>
        public string getInvoicesFiltered(float cost)
        {
            return "select * from Invoices where TotalCost =" + cost;
        }
        /// <summary>
        /// returns invoices filtered by date alone
        /// </summary>
        /// <param name="date">the date of the invoice</param>
        /// <returns>invoices filtered by date alone</returns>
        public string getInvoicesFiltered(string date)
        {
            return "select * from Invoices where Format(InvoiceDate, \"yyyymmdd\") = " + date;
        }
        /// <summary>
        /// returns invoices filtered by both cost and date
        /// </summary>
        /// <param name="cost">the total cost of the invoice</param>
        /// <param name="date">the date of the invoice</param>
        /// <returns>invoices filtered by both cost and date</returns>
        public string getInvoicesFiltered(float cost, string date)
        {
            return "select * from Invoices where TotalCost = " + cost + " and Format(InvoiceDate, \"yyyymmdd\") = " + date;
        }
        /// <summary>
        /// returns an invoice based on its InvoiceNum

        /// </summary>
        /// <param name="invoiceNum">the invoice number used to search</param>
        /// <returns>the invoice with the specified InvoiceNum</returns>
        public string getInvoicesFiltered(int invoiceNum)
        {
            return "select * from Invoices where InvoiceNum = " + invoiceNum;
        }
        
        /// <summary>
        /// returns an invoice based on its number and cost
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public string getInvoicesFiltered(int invoiceNum, float cost)
        {
            return "select * from Invoices where InvoiceNum = " + invoiceNum + " and TotalCost = " + cost;
        }

        /// <summary>
        /// returns an invoice based on its invoicenum and date
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string getInvoicesFiltered(int invoiceNum, string date)
        {
            return "select * from Invoices where InvoiceNum = " + invoiceNum + " and Format(InvoiceDate, \"yyyymmdd\") = " + date;
        }

        /// <summary>
        /// returns an invoice based on its invoicenum, cost, and date.
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="cost"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string getInvoicesFiltered(int invoiceNum, float cost, string date)
        {
            return "select * from Invoices where InvoiceNum = " + invoiceNum + " and TotalCost = " + cost + " and Format(InvoiceDate, \"yyyymmdd\") = " + date;
        }


    }
}
