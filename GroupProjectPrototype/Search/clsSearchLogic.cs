using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;

namespace GroupProjectPrototype.Search { 
    class clsSearchLogic
    {

        //list containing all invoiceIDs
        public List<int> invoiceIDs;

        //list containing all total prices
        public List<float> invoicePrices;

        private clsDataAccess dataAccess;

        private clsSearchSQL sql;

        /// <summary>
        /// the default constructor for this class
        /// </summary>
        public clsSearchLogic()
        {
            dataAccess = new clsDataAccess();
            sql = new clsSearchSQL();

            invoiceIDs = new List<int>();

            invoicePrices = new List<float>();

            int retval = 0;

            DataTable invoices = dataAccess.ExecuteSQLStatement(sql.getInvoicesTable(), ref retval).Tables[0];

            foreach(DataRow row in invoices.Rows)
            {
                invoiceIDs.Add(int.Parse(row[0].ToString()));
                invoicePrices.Add(float.Parse(row[2].ToString()));
            }

            //it specifies that invoicePrices should be sorted descending, and this accomplishes that
            invoicePrices.Sort();
            invoicePrices.Reverse();


        }


        /// <summary>
        /// gets all invoices
        /// </summary>
        /// <returns>datatable of all invoices</returns>
        public DataTable getInvoices()
        { 
            try
            {
                int retval = 0;
                return dataAccess.ExecuteSQLStatement(sql.getInvoicesTable(), ref retval).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "."
                          + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// gets all invoices filtered by  index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public DataTable getInvoices(int index)
        {
            try
            {
                int retval = 0;
                return dataAccess.ExecuteSQLStatement(sql.getInvoicesFiltered(index), ref retval).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "."
                          + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            
        }


        /// <summary>
        /// gets invoices filtered by index and cost
        /// </summary>
        /// <param name="index"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public DataTable getInvoices(int index, float cost)
        {
            try
            {
                int retval = 0;
                return dataAccess.ExecuteSQLStatement(sql.getInvoicesFiltered(index, cost), ref retval).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "."
                          + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// gets invoices filtered by cost, date, and string
        /// </summary>
        /// <param name="index"></param>
        /// <param name="cost"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataTable getInvoices(int index, float cost, string date)
        {
            try
            {
                int retval = 0;
                return dataAccess.ExecuteSQLStatement(sql.getInvoicesFiltered(index, cost, date), ref retval).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "."
                          + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// gets invoices filtered by cost
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public DataTable getInvoices(float cost)
        {
            try
            {
                int retval = 0;
                return dataAccess.ExecuteSQLStatement(sql.getInvoicesFiltered(cost), ref retval).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "."
                          + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// gets invoices filtered by date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataTable getInvoices(string date)
        {
            try
            {
                int retval = 0;
                return dataAccess.ExecuteSQLStatement(sql.getInvoicesFiltered(date), ref retval).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "."
                          + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// gets invoices filtered by cost and date
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataTable getInvoices(float cost, string date)
        {
            try
            {
                int retval = 0;
                return dataAccess.ExecuteSQLStatement(sql.getInvoicesFiltered(cost, date), ref retval).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "."
                          + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }




    }
}
