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
        
        // Finished
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

        // Finished
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

        // Finished
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
                /// <summary>
                /// String variable to hold the query
                /// </summary>
                string sql = String.Format("SELECT Items.Item_ID, Items.Item_Name, Items.Item_Description, Items.Cost ");
                sql += String.Format("FROM Items ");
                sql += String.Format("INNER JOIN Invoice_Item_Relation ON Invoice_Item_Relation.Item_ID = Items.Item_ID ");
                sql += String.Format("WHERE Invoice_Item_Relation.Invoice_ID = {0} ", invoiceID);
                return sql;

                //return "SELECT I.Item_ID, I.Item_Name, I.Item_Description, I.Cost " +
                //       " FROM Invoices IN " +
                //       " JOIN Invoice_Item_Relation IR ON IR.Invoice_ID = IN.Invoice_ID " +
                //       " JOIN Items I ON I.Item_ID = IR.Item_ID " +
                //       " WHERE IN.Invoice_ID = " + invoiceID;
            } catch 
            (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Statement that returns total cost based on ID
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string getTotalCost(string invoiceID)
        {
            try
            {
                return "SELECT Total_COST " +
                       "FROM Invoices " +
                       "WHERE Invoice_ID = " + invoiceID;
            } 
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns the selected date
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string getDate(string invoiceID)
        {
            try
            {
                return "SELECT Sell_Date " +
                       "FROM Invoices " +
                       "WHERE Invoice_ID = " + invoiceID;
            } 
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        // Finished
        #region Delete Invoice
        /// <summary>
        /// Statement that deletes the invoice link based in ID
        /// </summary>
        /// <returns></returns>
        public string delLinkInvoice(BindingList<clsBusinessItem> itemList, string invoiceID)
        {
            try
            {
                // This is wrong
                return "DELETE FROM Invoice_Item_Relation WHERE Invoice_ID = " + invoiceID;
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
        public string addInvoiceLink(clsBusinessItem item, string invoiceID)
        {
            try
            {
                /// <summary>
                /// String variable to hold the query
                /// </summary>
                // I only need Item & Invoice ID
                string sql = "INSERT INTO Invoice_Item_Relation (Item_ID, Invoice_ID) VALUES ";
                sql += "('";
                sql += item.ItemID;
                sql += "', '";
                sql += invoiceID;
                sql += "')";

                return sql;
            } 
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Statement that adds Invoice to invoice table
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string addInvoice(string totalCost, string selDate)
        {
            try
            {
                return "INSERT INTO Invoices (Total_Cost, Sell_Date)" +
                       "VALUES( '" + totalCost + "', '" + selDate + "');";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns the max ID of the newly inserted Invoice
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string maxID()
        {
            try
            {
                return "SELECT TOP 1 Invoice_ID" +
                       " FROM Invoices " +
                       "ORDER BY Invoice_ID DESC";
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
        /// Updates date and total cost based on invoice
        /// </summary>
        /// <returns></returns>
        public string updateInvoice(string ID, string tCost, string sDate)
        {
            try
            {
                return "UPDATE Invoices " +
                       "SET Total_Cost = " + tCost +
                       ", Sell_Date = '" + sDate +
                       "' WHERE Invoice_ID = " + ID;
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