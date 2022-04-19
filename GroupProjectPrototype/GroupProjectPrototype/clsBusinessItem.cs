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
        /// <summary>
        /// String variable to hold the itemID
        /// </summary>
        private string itemID;

        /// <summary>
        /// String variable to hold the ItemID
        /// </summary>
        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        /// <summary>
        /// String variable to hold the itemName
        /// </summary>
        private string itemName;

        /// <summary>
        /// String variable to hold the ItemName
        /// </summary>
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        /// <summary>
        /// String variable to hold the itemDescription
        /// </summary>
        private string itemDescription;

        /// <summary>
        /// String variable to hold the ItemDescription
        /// </summary>
        public string ItemDescription
        {
            get { return itemDescription; }
            set { itemDescription = value; }
        }

        /// <summary>
        /// String variable to hold the cost
        /// </summary>
        private string cost;

        /// <summary>
        /// String variable to hold the Cost
        /// </summary>
        public string Cost
        {
            get { return cost; }
            set { cost = value; }
        }


        #region Parameterized Constructor
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="itemName"></param>
        /// <param name="itemDescription"></param>
        /// <param name="cost"></param>
        public clsBusinessItem(string ItemID, string ItemName, string ItemDescription, string Cost)
        {
            try
            {
                this.ItemID = ItemID;
                this.ItemName = ItemName;
                this.ItemDescription = ItemDescription;
                this.Cost = Cost;               
            } 
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Copy object for list cloning
        /// </summary>
        public clsBusinessItem(clsBusinessItem copy)
        {
            this.itemID = copy.ItemID;
            this.itemName = copy.ItemName;
            this.itemDescription = copy.ItemDescription;
            this.cost = copy.Cost;

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
