using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectPrototype
{
    /// <summary>
    /// Business Item Class
    /// </summary>
    public class clsBusinessItem
    {
        // Public Date Members
        public string itemID;
        public string itemName;
        public string itemDescription;
        public string cost;


        #region Parameterized Constructor
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="itemName"></param>
        /// <param name="itemDescription"></param>
        /// <param name="cost"></param>
        public clsBusinessItem(string itemID, string itemName, string itemDescription, string cost)
        {
            try
            {
                this.itemID = itemID;
                this.itemName = itemName;
                this.itemDescription = itemDescription;
                this.cost = cost;
            } 
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Override ToString()
        /// <summary>
        /// Overrides the ToString() method to display item name
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            try
            {
                return itemName;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    } // end of class
}
