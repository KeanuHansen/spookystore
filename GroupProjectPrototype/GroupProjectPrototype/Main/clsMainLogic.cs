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

        List<clsScaryThing> iList;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public clsMainLogic()
        {
            db = new clsDataAccess();
            sSQL = new clsMainSQL();
        }

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

        #region Delete Invoice
        /// <summary>
        /// Delete the invoice from the database
        /// </summary>
        /// <param name="ID"></param>
        public void deleteInvoice(string ID)
        {
            try
            {
                // Deletes invoice from Link table
                db.ExecuteNonQuery(sSQL.delLinkInvoice(ID));

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

    } // end of class
}
