using GroupProjectPrototype.Main;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectPrototype
{
    class clsMainLogic
    {
        /// <summary>
        /// clsBigBoxOfScaryThings variable that holds the data
        /// </summary>
        clsBigBoxOfScaryThings userInvoice = new clsBigBoxOfScaryThings();

        /// <summary>
        /// Create an SQL Object
        /// </summary>
        clsMainSQL sqlObect = new clsMainSQL();


        #region Adding Item
        /// <summary>
        /// Adds item to user's invoice 
        /// </summary>
        public void addItem(string item, double cost)
        {
            try
            {
                // Make an Item to append
                clsScaryThing newItem = new clsScaryThing();
                newItem.item = item;
                newItem.cost = cost;

                // Append item to the user's invoice
                userInvoice.bigBox.Add(newItem);
            } catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
        
        /// <summary>
        /// Adds item to existing invoice
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cost"></param>
        /// <param name="itemID"></param>
        public void edAddItem(string item, double cost, string invoiceID)
        {
            try
            {

                // Make an Item to append
                clsScaryThing newItem = new clsScaryThing();
                newItem.item = item;
                newItem.cost = cost;

                // Return existing invoice and append newItem to that
            } catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #region Delete Item
        /// <summary>
        /// Passes in ID into a delete query
        /// </summary>
        public void deleteItem(string itemID)
        {
            try
            {
                /// <summary>
                /// clsBigBoxOfScaryThings variable that holds the data
                /// </summary>
                clsBigBoxOfScaryThings boxScary = new clsBigBoxOfScaryThings();

                /// <summary>
                /// DataSet variable that holds the DataSet
                /// </summary>
                DataSet ds = new DataSet();

                /// <summary>
                /// Int variable that holds the integer ret type for the loop 
                /// </summary>
                int ret = 0;

                /// <summary>
                /// Item Manager object that holds the database variable
                /// </summary>
                clsItemManager db = new clsItemManager();

                // Return the query for insert
                string sql = sqlObect.deleteQ(itemID);

                //Delete the invoice
                ds = db.ExecuteSQLStatement(sql, ref ret);
            } catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Insert Invoice
        /// <summary>
        /// Loop through all of the items in the box and insert them into our database
        /// </summary>
        public void insertBox(double totalCost, DateTime selectedDate)
        {
            try
            {


                /// <summary>
                /// clsBigBoxOfScaryThings variable that holds the data
                /// </summary>
                clsBigBoxOfScaryThings boxScary = new clsBigBoxOfScaryThings();

                /// <summary>
                /// DataSet variable that holds the DataSet
                /// </summary>
                DataSet ds = new DataSet();

                /// <summary>
                /// Int variable that holds the integer ret type for the loop 
                /// </summary>
                int ret = 0;

                /// <summary>
                /// Item Manager object that holds the database variable
                /// </summary>
                clsItemManager db = new clsItemManager();

                // Return the query for insert
                string sql = sqlObect.insertInvoice(totalCost, selectedDate);

                //Create the invoice
                ds = db.ExecuteSQLStatement(sql, ref ret);


                // returns the id
                int returnID = Convert.ToInt32(db.ExecuteNonQuery(sqlObect.InvoiceID(totalCost, selectedDate)));

                // Loop through each item in the invoice
                foreach (var item in userInvoice.bigBox)
                {
                    // Execute query to add to relation table 
                    db.ExecuteNonQuery(sqlObect.relation(returnID, item.itemID));

                }
            } catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion


        /// <summary>
        /// Updates the selected invoice
        /// </summary>
        /// <param name="totalCost"></param>
        /// <param name="selectedDate"></param>
        /// <param name="InvoiceID"></param>
        public void upInsertBox(double totalCost, DateTime selectedDate, string InvoiceID)
        {
            try
            {


                // Retrieve the invoice list based on invoiceID

                string selDate = Convert.ToString(selectedDate);

                /// <summary>
                /// DataSet variable that holds the DataSet
                /// </summary>
                DataSet ds = new DataSet();

                /// <summary>
                /// Int variable that holds the integer ret type for the loop 
                /// </summary>
                int ret = 0;

                /// <summary>
                /// Item Manager object that holds the database variable
                /// </summary>
                clsItemManager db = new clsItemManager();

                // Return the query for insert
                string sql = sqlObect.updateInvoice(selDate, InvoiceID);


                //Update the invoice
                ds = db.ExecuteSQLStatement(sql, ref ret);

                // Loop through each item in the invoice
                /* foreach (var item in userInvoice.bigBox)
                 {
                     // Execute query to add to relation table 
                     db.ExecuteNonQuery(sqlObect.relation(returnID, item.itemID));

                 }*/

            } catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
