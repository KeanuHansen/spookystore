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
        clsDataAccess db;
        DataSet ds;

        int itemID;

        /// <summary>
        /// constructor for adding an item
        /// </summary>
        public clsItemsSQL()
        {
            ds = new DataSet();
            db = new clsDataAccess();
        }

        /// <summary>
        /// constructor for editing and item
        /// </summary>
        public clsItemsSQL(int itemID)
        {
            this.itemID = itemID;
            db = new clsDataAccess();
            ds = new DataSet();
        }

        /// <summary>
        /// returns sql statement to update the cost of an item.
        /// </summary>
        /// <param name="newCost"></param>
        public string editCost(double newCost)
        {
            try
            {
                string updateCost = "UPDATE Items SET Cost = " + newCost + "WHERE Item_ID = " + itemID;
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
                string delete = "DELETE FROM Items WHERE Item_ID = " + itemID;
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

                string addingItem = "INSERT INTO Items (Item_Name, Item_Description, Cost) VALUES ('" + name + "', '" + description + "', " + cost + ")";
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
                string check = "SELECT * FROM Invoice_Item_Relation WHERE Item_ID = " + itemID;
                return check;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns a sql statement to get info on all items in database
        /// </summary>
        /// <returns></returns>
        public string getItemsInfo()
        {
            try
            {
                string sql = "SELECT * FROM Items";
                return sql;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns sql statement to make sure we are not adding an item that we already have
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string checkDoubleItem(string name)
        {
            try
            {
                string sql = "SELECT * FROM Items WHERE Item_Name LIKE '" + name + "'";
                return sql;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns a sql statement that gets the item name
        /// </summary>
        /// <returns></returns>
        public string getItemName()
        {
            try
            {
                string sql = "SELECT Item_Name FROM Items WHERE Item_ID = " + this.itemID;
                return sql;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns a sql statements that get the items cost
        /// </summary>
        /// <returns></returns>
        public string getItemCost()
        {
            try
            {
                string sql = "SELECT Cost FROM Items WHERE Item_ID = " + this.itemID;
                return sql;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns a sql statement that gets the items description
        /// </summary>
        /// <returns></returns>
        public string getItemDes()
        {
            try
            {
                string sql = "SELECT Item_Description FROM Items WHERE Item_ID = " + this.itemID;
                return sql;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
