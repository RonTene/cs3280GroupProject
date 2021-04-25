using System;
using System.Reflection;

namespace GroupProjectPrototype.Main
{
    /// <summary>
    /// This class contains the code for the item type. It's used to interact with items in the main form.
    /// All items are filled with data from item queries from the DB
    /// </summary>
    public class clsItems
    {
        /// <summary>
        /// This is the item's code. I think it's the PK of the item.
        /// </summary>
        public String itemCode;
        /// <summary>
        /// This is the item's description. It's essentially the item's name.
        /// </summary>
        public String itemDesc;
        /// <summary>
        /// This is the item's cost. It's self explanatory.
        /// </summary>
        public String itemCost;

        /// <summary>
        /// This is the constructor for the item type.
        /// </summary>
        /// <param name="itemCode">The code from the item queried</param>
        /// <param name="itemDesc">The name of the item queried</param>
        /// <param name="itemCost">The cost of the item queried</param>
        public clsItems(String itemCode, String itemDesc, String itemCost)
        {
            try
            {
                this.itemCode = itemCode;
                this.itemDesc = itemDesc;
                this.itemCost = itemCost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method handles the toString implementation for this object. It makes sure the item's name is what's
        /// displayed in things like the Combo Box.
        /// </summary>
        /// <returns>String representation of the item object.</returns>
        override
        public String ToString()
        {
            try
            {
                //We display the name of the item when getting a string representation.
                return this.itemDesc;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
