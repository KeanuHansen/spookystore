using GroupProjectPrototype.Search;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectPrototype
{
    class clsSearchLogic
    {
        // Poor Code Decisions to be credited to: Keanu Hansen

        /// <summary>
        /// clsSearchSQL variable that holds the class so I can pull the query
        /// </summary>
        clsSearchSQL searchSQL = new clsSearchSQL();

        /// <summary>
        /// This method filters for items in an invoice based on the Invoice_ID, Total_Cost, Sell_Date.
        /// </summary>
        /// <param name="invoiceID">The SQL filter to be executed by.</param>
        /// <param name="totalCost">The SQL filter to be executed by.</param>
        /// <param name="sellDate">The SQL filter to be executed by.</param>
        /// <returns>Returns a clsBigBoxOfScaryThings that contains the data from the SQL statement.</returns>
        // READ NOTE BELOW
        // NOTE: I could have split this up into multiple queries, but I found making a dynamic one to be best. That way it is less clunky.
        public clsBigBoxOfScaryThings Filter(string invoiceID, string totalCost, string sellDate)
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
                clsDataAccess db = new clsDataAccess(); ;

                // Select all items in this invoice ID in a query
                string sql = searchSQL.Filter(invoiceID, totalCost, sellDate);

                //Extract the items and put them into the DataSet
                ds = db.ExecuteSQLStatement(sql, ref ret);

                // Add them all to the list
                // Loop through the data and create scary thing classes
                for (int i = 0; i < ret; i++)
                {
                    /// <summary>
                    /// Make an item to append.
                    /// </summary>
                    clsScaryThing Invoice = new clsScaryThing();

                    //Invoice.invoiceID = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                   // Invoice.cost = Double.Parse(ds.Tables[0].Rows[i]["total_cost"].ToString());
                   // Invoice.sellDate = DateTime.Parse(ds.Tables[0].Rows[i]["sell_date"].ToString());

                    //boxScary.bigBox.Add(Invoice);
                }

                return boxScary;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
