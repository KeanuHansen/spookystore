
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
        clsDataAccess itemManage;

        /// <summary>
        /// dataset to hold value returned from the executesqlquery method under the clsItemManager class.
        /// </summary>
        DataSet ds;

        /// <summary>
        /// constructor for adding new item to database
        /// </summary>
        public clsItemsLogic()
        {
            try
            {
                itemSQL = new clsItemsSQL(this.ItemID);
                itemManage = new clsDataAccess();
                ds = new DataSet();
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// recieves the itemID from the item window 
        /// </summary>
        /// <param name="invoiceID"></param>
        public clsItemsLogic(int ItemID)
        {
            try
            {
                this.ItemID = ItemID;
                itemSQL = new clsItemsSQL(this.ItemID);
                itemManage = new clsDataAccess();
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

                itemManage.ExecuteNonQuery(itemSQL.deleteItem()); //deletes the item.


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
        /// changes the name of the item
        /// </summary>
        /// <param name="newName"></param>
        public void changeName(string newName)
        {
            try
            {
                itemManage.ExecuteNonQuery(itemSQL.editName(newName));
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
                /// <summary>
                /// variable to hold the return value reference
                /// </summary>
                int retVal = 0;
                itemManage.ExecuteSQLStatement(itemSQL.checkDoubleItem(name), ref retVal);

                if (retVal == 0)
                {
                    itemManage.ExecuteNonQuery(itemSQL.addItem(name, cost, description));
                }

            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns the item name
        /// </summary>
        /// <returns></returns>
        public string getItemName()
        {
            try
            {
                /// <summary>
                /// variable to hold the return value reference
                /// </summary>
                int retVal = 0;

                /// <summary>
                /// string variable to hold the name
                /// </summary>
                string name = "";

                ds = itemManage.ExecuteSQLStatement(itemSQL.getItemName(), ref retVal);
                name = ds.Tables[0].Rows[0][0].ToString();

                return name;

            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns the cost of the item
        /// </summary>
        /// <returns></returns>
        public double getCost()
        {
            try
            {
                /// <summary>
                /// variable to hold the return value reference
                /// </summary>
                int retVal = 0;

                /// <summary>
                /// double variable to hold the cost
                /// </summary>
                double cost = 0.0;

                ds = itemManage.ExecuteSQLStatement(itemSQL.getItemCost(), ref retVal);
                cost = Convert.ToDouble(ds.Tables[0].Rows[0][0]);

                return cost;

            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns the items description
        /// </summary>
        /// <returns></returns>
        public string getDescription()
        {
            try
            {
                /// <summary>
                /// variable to hold the return value reference
                /// </summary>
                int retVal = 0;

                /// <summary>
                /// string variable to hold the description
                /// </summary>
                string des = "";

                ds = itemManage.ExecuteSQLStatement(itemSQL.getItemDes(), ref retVal);
                des = ds.Tables[0].Rows[0][0].ToString();

                return des;

            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
