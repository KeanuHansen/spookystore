using GroupProjectPrototype.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectPrototype
{
    /// <summary>
    /// Main Logic Class 
    /// </summary>
    class clsMainLogic
    {
        /// <summary>
        /// Database object
        /// </summary>
        clsDataAccess db;

        /// <summary>
        /// Object that holds our SQL statements
        /// </summary>
        clsMainSQL sSQL;

        /// <summary>
        /// Tracks the Invoice ID of created invoice. Pass this back to main wnd
        /// </summary>
        public string invoiceID;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public clsMainLogic()
        {
            db = new clsDataAccess();
            sSQL = new clsMainSQL();
        }
        // Finished
        #region Is DB Empty
        /// <summary>
        /// Checks if the database is empty
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            try
            {
                // Keeps track of rows affected by query
                int iRet = 0;

                // Execute SQL Statement
                db.ExecuteSQLStatement(sSQL.allInvoices(), ref iRet);

                // If it returned zero, our DB is empty
                if (iRet == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        // Finished
        #region Delete Invoice
        /// <summary>
        /// Delete the invoice from the database
        /// </summary>
        /// <param name="ID"></param>
        public void deleteInvoice(BindingList<clsBusinessItem> itemList, string ID)
        {
            try
            {
                // Deletes invoice from Link table
                db.ExecuteNonQuery(sSQL.delLinkInvoice(itemList, ID));

                // Deletes invoice from Invoices table
                db.ExecuteNonQuery(sSQL.delInvoice(ID));
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
        /// Adds the invoice to the database
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void addInvoice(BindingList<clsBusinessItem> itemsList, string totalCost, string selDate)
        {
            try
            {
                // Add Invoice to Invoices table
                db.ExecuteNonQuery(sSQL.addInvoice(totalCost, selDate));

                // Retrieve the new ID
                invoiceID = db.ExecuteScalarSQL(sSQL.maxID());

                // Add Items to relation table
                db.ExecuteNonQuery(sSQL.addInvoiceLink(itemsList, invoiceID));

            } 
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Update Invoice
        /// <summary>
        /// Updates Selected invoice based on invoice ID
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void updateInvoice(BindingList<clsBusinessItem> itemsList, string totalCost, string selDate, string iID)
        {
            try
            {
                // Update total cost and date from Invoice table
                db.ExecuteNonQuery(sSQL.updateInvoice(iID, totalCost, selDate));

                // Delete everything in the relation table
                db.ExecuteNonQuery(sSQL.delLinkInvoice(itemsList, iID));

                // Add Items to relation table
                db.ExecuteNonQuery(sSQL.addInvoiceLink(itemsList, iID));
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
