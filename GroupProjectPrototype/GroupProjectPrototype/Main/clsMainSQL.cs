using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;



namespace GroupProjectPrototype.Main
{
    class clsMainSQL
    {
        /// <summary>
        /// Item Manager object that holds the database variable
        /// </summary>
        clsItemManager db = new clsItemManager();

       
        /// <summary>
        /// Populate the list with items table
        /// </summary>
        /// <returns></returns>
        public clsBigBoxOfScaryThings display()
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
                /// String variable that holds the sql query
                /// </summary>
                string sql = "SELECT Item_ID, Item_Name, Cost FROM Items";

                //Extract the items and put them into the DataSet
                ds = db.ExecuteSQLStatement(sql, ref ret);


                //Loop through the data and create scary thing classes
                for (int i = 0; i < ret; i++)
                {
                    /// <summary>
                    /// Make an item to append.
                    /// </summary>
                    clsScaryThing Item = new clsScaryThing();
                    Item.invoiceID = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                    Item.item = ds.Tables[0].Rows[i]["Item_Name"].ToString();
                    //Item.sellDate = DateTime.Parse(ds.Tables[0].Rows[i]["sellDate"].ToString());
                    Item.cost = double.Parse(ds.Tables[0].Rows[i]["cost"].ToString());
                    Item.description = ds.Tables[0].Rows[i]["description"].ToString();

                    boxScary.bigBox.Add(Item);
                }
                

                return boxScary;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        } // end of display()

        /// <summary>
        /// Add user's invoice to database
        /// </summary>
        public string insertInvoice(double totalCost, DateTime selectedDate)
        {
            try
            {
                string insertStr = "INSERT INTO Invoices (Total_Cost, Sell_Date) VALUES ('" + Convert.ToString(totalCost) + "', " + Convert.ToString(selectedDate) + "')";
                return insertStr;
            } catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Returns the ID of the specific Invoice
        /// </summary>
        /// <param name="totalCost"></param>
        /// <param name="selectedDate"></param>
        /// <returns></returns>
        public string InvoiceID(double totalCost, DateTime selectedDate)
        {
            try
            {


                string cost = Convert.ToString(totalCost);
                string selDate = Convert.ToString(selectedDate);
                string sql = "SELECT Invoice_ID FROM Invoices WHERE Total_Cost = " + cost + " AND " + "Sell_Date = " + selectedDate;

                return sql;
            } catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Create a query that adds to our invoice item relation table
        /// </summary> 
        public string relation(int returnID, int itemID)
        {
            try
            {
                string query = String.Format("INSERT INTO Invoice_Item_Relation (InvoiceID, ItemID) VALUES ({0}, {1})", returnID, itemID);

                return query;
            } catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Return string that is a delete query
        /// </summary>
        public string deleteQ(string InvoiceID)
        {
            try
            {
                // Create the delete query string
                string query = "DELETE FROM Invoices WHERE Invoice_ID = " + InvoiceID;
                return query;
            } catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Edit Invoices based on selection
        /// </summary>
        public string updateInvoice(string newDate, string invoiceID)
        {
            try
            {


                string sql = String.Format("UPDATE Invoices SET Selling_Date = '{0}' WHERE InvoiceID = {1}", newDate, invoiceID);

                return sql;
            } catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


    } // end of class
}
