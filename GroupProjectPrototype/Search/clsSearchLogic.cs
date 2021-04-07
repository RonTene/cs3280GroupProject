using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectPrototype.Search { 
    class clsSearchLogic
    {
        /// <summary>
        /// the search window associated with this instance of the logic class
        /// </summary>
        wndSearch parent;

        /// <summary>
        /// the default constructor for this class
        /// </summary>
        /// <param name="p">the search window associated with this class</param>
        public clsSearchLogic(wndSearch p)
        {
            parent = p;
        }

        /// <summary>
        /// returns the selected invoice number to the main
        /// </summary>
        public void selectInvoice(int invoiceID)
        {
            //this method name is not final, as it is from the main window, which is not my section of code
            //but there should be a method in the main window which takes back a selected invoiceID and displays it
            parent.main.retSelectedInvoice(invoiceID);
            parent.Close();
        }
    }
}
