using GroupProjectPrototype.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace GroupProjectPrototype
{
    class clsItemsLogic
    {

        /// <summary>
        /// in variable to hold the itemID
        /// </summary>
        private int ItemID;

        /// <summary>
        /// clsItemSQL object to access the sql statements under the clsItemSQL methods.
        /// </summary>
        clsItemsSQL itemSQL;

        /// <summary>
        /// clsItemManager object to access the methods used to manipulate the database
        /// </summary>
        clsItemManager itemManage;

        /// <summary>
        /// dataset to hold value returned from the executesqlquery method under the clsItemManager class.
        /// </summary>
        DataSet ds;


        /// <summary>
        /// recieves the invoiceID from the main window when edit is selected
        /// </summary>
        /// <param name="invoiceID"></param>
        public clsItemsLogic(int ItemID)
        {
            try
            {
                this.ItemID = ItemID;
                itemSQL = new clsItemsSQL();
                itemManage = new clsItemManager();
                ds = new DataSet();
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// checks that the item isnt on any invoices
        /// deletes item if it isnt
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <param name="itemName"></param>
        public void deleteItem()
        {
            try
            {
                //check that the item isnt on an invoice
                int rows = 0;
                ds = itemManage.ExecuteSQLStatement(itemSQL.checkInvoices(), ref rows);

                if(rows == 0 || rows == null) //if true, then that means this item isnt on any invoices, then it can be deleted
                {
                    itemManage.ExecuteNonQuery(itemSQL.deleteItem()); //deletes the item.
                }
                else
                {
                    //sends error message
                }
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Changes price of item
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="itemName"></param>
        public void changePrice(double newCost)
        {
            try
            {
                itemManage.ExecuteNonQuery(itemSQL.editCost(newCost));
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// changes the description of the item
        /// </summary>
        /// <param name="newDescription"></param>
        public void changeDescription(string newDescription)
        {
            try
            {
                itemManage.ExecuteNonQuery(itemSQL.editDescription(newDescription));
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// adds new item to the database
        /// </summary>
        public void addNewItem(string name, string description, double cost)
        {
            try
            {
                itemManage.ExecuteNonQuery(itemSQL.addItem(name, cost, description));
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
