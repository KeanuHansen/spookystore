using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.ComponentModel;

namespace GroupProjectPrototype.Main
{
    /// <summary>
    /// Main SQL Class
    /// </summary>
    class clsMainSQL
    {
        
        #region All Invoices
        /// <summary>
        /// Statement that returns all rows from the Invoices Table
        /// </summary>
        /// <returns></returns>
        public string allInvoices()
        {
            try
            {
                return "SELECT * FROM Invoices";
            } 
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Retrieve Business Items
        /// <summary>
        /// Statement that returns all business items
        /// </summary>
        /// <returns></returns>
        public string getBusinessItems()
        {
            try
            {
                return "SELECT * FROM Items";
            } 
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Retrieve Invoice Items
        /// <summary>
        /// Statement that returns the items based on ID
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <returns></returns>
        public string getInvoiceItems(string invoiceID)
        {
            try
            {
                return "Select " +
                       " FROM Invoices IN, Invoice_Item_Relation IR, Items I" +
                       " WHERE IN.Invoice_ID = "
                    ;
            } catch 
            (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        // Needs work
        #region Delete Invoice
        /// <summary>
        /// Statement that deletes the invoice link based in ID
        /// </summary>
        /// <returns></returns>
        public string delLinkInvoice(string ID)
        {
            try
            {
                // This is wrong
                return "DELETE FROM Invoice_Item_Relation WHERE Invoice_ID = " + ID;
            } 
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Statement that deletes the invoice based on ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string delInvoice(string ID)
        {
            try
            {
                return "DELETE FROM Invoices WHERE Invoice_ID = " + ID;
            } 
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion

        #region Add Invoice
        /// <summary>
        /// Statment that adds each item in Link Table
        /// </summary>
        /// <returns></returns>
        public string addInvoiceLink(BindingList<clsBusinessItem> itemsList, string invoiceID)
        {
            try
            {
                // I only need Item & Invoice ID
                string sql = "INSERT INTO Invoice_Item_Relation (Item_ID, Invoice_ID)";
                sql += "Values ";

                // Loop through each item in list
                foreach(clsBusinessItem item in itemsList)
                {
                    sql += "(";
                    sql += item.itemID + ", " + invoiceID;
                    sql += "), ";
                }

                //sql = sql.Trim;

                return sql;
            } 
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Statement that adds invoice to invoice table
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string addInvoice(BindingList<clsBusinessItem> items, string invoiceID, DateTime selTime, string totalCost)
        {
            try
            {
                return "";
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
/*		public string invoiceID { get; set; }
		public string itemID { get; set; }
		public string item { get; set; }
		public DateTime sellDate { get; set; }
		public string cost { get; set; }
		public string description { get; set; }

    I need:
        total cost
        item name
        sell Date
        invoice id? 
 */