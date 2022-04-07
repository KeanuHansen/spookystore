using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectPrototype.Search
{
    class clsItemsSQL
    {
        /// <summary>
        /// Item Manager object that holds the database variable
        /// </summary>
        clsItemManager db = new clsItemManager();

        /// <summary>
        /// holds the id of the item we are looking at.
        /// </summary>
        int itemID;

        /// <summary>
        /// constructor for when we are only adding an item.
        /// </summary>
        public clsItemsSQL()
        {
            try
            {
                ///we just need this to be able to add a new item.
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// constructor for when we are editing or deleting or checking invoices for a specified item.
        /// </summary>
        /// <param name="itemID"></param>
        public clsItemsSQL(int itemID)
        {
            try
            {
                this.itemID = itemID;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// takes in a number then sets the current items cost to that number
        /// </summary>
        /// <param name="newCost"></param>
        public string editCost(double newCost)
        {
            try
            {
                string updateCost = "UPDATE Items SET Cost = " + newCost + "WHERE Item_ID LIKE " + itemID;
                return updateCost;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// provides the sql statement to update the items name to the newName passed in
        /// </summary>
        /// <param name="newName"></param>
        /// <returns></returns>
        public string editName(string newName)
        {
            try
            {
                string updateName = ("UPDATE Items SET Item_Name = " + newName + "WHere Item_ID LIKE " + itemID);
                return updateName;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns the sql statement to update the items description to newDes
        /// </summary>
        /// <param name="newDes"></param>
        /// <returns></returns>
        public string editDescription(string newDes)
        {
            try
            {
                string updateDes = "UPDATE Items SET Item_Description = " + newDes + "WHERE Item_ID LIKE " + itemID;
                return updateDes;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// provides the sql statement that would be used to delete the specified item.
        /// </summary>
        /// <returns></returns>
        public string deleteItem()
        {
            try
            {
                string delete = "DELETE FROM Items WHERE Item_ID LIKE " + itemID;
                return delete;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns the sql statement that would add an item to the items table in the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public string addItem(string name, double cost, string description)
        {
            try
            {

                string addingItem = "INSERT INTO Items VALUES (" + name + ", " + cost + ", " + description + ")";
                return addingItem;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns a sql statement that is used to see if an item is in any invoice.
        /// </summary>
        /// <returns></returns>
        public string checkInvoices()
        {
            try
            {
                string check = "SELECT * FROM Invoice_Item_Relation WHERE Item_ID LIKE " + itemID;
                return check;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
