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
    class clsSearchSQL
    {

        //this section is all just copy-pasted database connection handling, the actual queries are below starting on line 158

        /// <summary>
        /// Connection string to the database.
        /// </summary>
        private string sConnectionString;

        /// <summary>
        /// Constructor that sets the connection string to the database
        /// </summary>
		public clsSearchSQL()
        {
            sConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + Directory.GetCurrentDirectory() + "\\Invoice.accdb";
        }

        /// <summary>
        /// This method takes an SQL statment that is passed in and executes it.  The resulting values
        /// are returned in a DataSet.  The number of rows returned from the query will be put into
        /// the reference parameter iRetVal.
        /// </summary>
        /// <param name="sSQL">The SQL statement to be executed.</param>
        /// <param name="iRetVal">Reference parameter that returns the number of selected rows.</param>
        /// <returns>Returns a DataSet that contains the data from the SQL statement.</returns>
		public DataSet ExecuteSQLStatement(string sSQL, ref int iRetVal)
        {
            try
            {
                //Create a new DataSet
                DataSet ds = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {

                        //Open the connection to the database
                        conn.Open();

                        //Add the information for the SelectCommand using the SQL statement and the connection object
                        adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Fill up the DataSet with data
                        adapter.Fill(ds);
                    }
                }

                //Set the number of values returned
                iRetVal = ds.Tables[0].Rows.Count;

                //return the DataSet
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method takes an SQL statment that is passed in and executes it.  The resulting single 
        /// value is returned.
        /// </summary>
        /// <param name="sSQL">The SQL statement to be executed.</param>
        /// <returns>Returns a string from the scalar SQL statement.</returns>
		public string ExecuteScalarSQL(string sSQL)
        {
            try
            {
                //Holds the return value
                object obj;

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {

                        //Open the connection to the database
                        conn.Open();

                        //Add the information for the SelectCommand using the SQL statement and the connection object
                        adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Execute the scalar SQL statement
                        obj = adapter.SelectCommand.ExecuteScalar();
                    }
                }

                //See if the object is null
                if (obj == null)
                {
                    //Return a blank
                    return "";
                }
                else
                {
                    //Return the value
                    return obj.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method takes an SQL statment that is a non query and executes it.
        /// </summary>
        /// <param name="sSQL">The SQL statement to be executed.</param>
        /// <returns>Returns the number of rows affected by the SQL statement.</returns>
        public int ExecuteNonQuery(string sSQL)
        {
            try
            {
                //Number of rows affected
                int iNumRows;

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    //Open the connection to the database
                    conn.Open();

                    //Add the information for the SelectCommand using the SQL statement and the connection object
                    OleDbCommand cmd = new OleDbCommand(sSQL, conn);
                    cmd.CommandTimeout = 0;

                    //Execute the non query SQL statement
                    iNumRows = cmd.ExecuteNonQuery();
                }

                //return the number of rows affected
                return iNumRows;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        //end of generic database connection handling, actual sql queries start here

        /// <summary>
        /// returns the full Invoices table from the database
        /// </summary>
        /// <param name="retval">an int indicating the length of the returned table</param>
        /// <returns>a dataset containing the selected table</returns>
        public DataSet getInvoicesTable(ref int retval)
        {
            return ExecuteSQLStatement("select * from Invoices", ref retval);
        }
        /// <summary>
        /// returns invoices filtered by cost alone
        /// </summary>
        /// <param name="retval">an int indicating the length of the returned table</param>
        /// <param name="cost">the total cost of the invoice</param>
        /// <returns>invoices filtered by cost alone</returns>
        public DataSet getInvoicesFiltered(ref int retval, int cost)
        {
            return ExecuteSQLStatement("select * from Invoices where TotalCost =" + cost, ref retval);
        }
        /// <summary>
        /// returns invoices filtered by date alone
        /// </summary>
        /// <param name="retval">an int indicating the length of the returned table</param>
        /// <param name="date">the date of the invoice</param>
        /// <returns>invoices filtered by date alone</returns>
        public DataSet getInvoicesFiltered(ref int retval, string date)
        {
            return ExecuteSQLStatement("select * from Invoices where InvoiceDate =" + date, ref retval);
        }
        /// <summary>
        /// returns invoices filtered by both cost and date
        /// </summary>
        /// <param name="retval">an int indicating the length of the returned table</param>
        /// <param name="cost">the total cost of the invoice</param>
        /// <param name="date">the date of the invoice</param>
        /// <returns>invoices filtered by both cost and date</returns>
        public DataSet getInvoicesFiltered(ref int retval, int cost, string date)
        {
            return ExecuteSQLStatement("select * from Invoices where TotalCost = " + cost + " and InvoiceDate = " + date, ref retval);
        }
        /// <summary>
        /// returns an invoice based on its InvoiceNum
        /// as InvoiceNum is the primary key, if an invoiceNum is selected no other criteria are necessary
        /// to identify a unique invoice, so we can safely ignore all other filters as far as SQL is concerned
        /// if we have an InvoiceNum
        /// </summary>
        /// <param name="retval">an int indicating the length of the returned table, though in this usage it should always be 0 or 1</param>
        /// <param name="invoiceNum">the invoice number used to search</param>
        /// <returns>the invoice with the specified InvoiceNum</returns>
        public DataSet getInvoiceByNum(ref int retval, int invoiceNum)
        {
            return ExecuteSQLStatement("select * from Invoices where InvoiceNum = " + invoiceNum, ref retval);
        }


    }
}
