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
        // Poor Code Decisions to be credited to: Keanu Hansen (W01402803)

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
        public List<clsInvoice> Filter(string invoiceID, string totalCost, string sellDate)
        {
            try
            {
                /// <summary>
                /// clsBigBoxOfScaryThings variable that holds the data
                /// </summary>
                List<clsInvoice> boxInvoice = new List<clsInvoice>();

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
                /// <summary>
                /// Creates a string variable to hold the query.
                /// </summary>
                string sql = searchSQL.Filter(invoiceID, totalCost, sellDate);

                //Extract the items and put them into the DataSet
                ds = db.ExecuteSQLStatement(sql, ref ret);

                // Add them all to the list
                // Loop through the data and create scary thing classes
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    // Create Scary item and add to bix box list
                    boxInvoice.Add(new clsInvoice(dr[0].ToString(), dr[1].ToString(), dr[2].ToString()));
                }

                return boxInvoice;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method gets the invoices for the combo box.
        /// </summary>
        /// <returns>Returns List<clsInvoice></returns>
        public List<clsInvoice> GetInvoices()
        {
            try
            {
                /// <summary>
                /// Creates a dataset variable to hold the data.
                /// </summary>
                // Create a dataset to hold our data
                DataSet ds = new DataSet();

                /// <summary>
                /// Creates a List<clsInvoice> variable to hold the data.
                /// </summary>
                // Create a new list each time this method is called
                List<clsInvoice> bigBox = new List<clsInvoice>();

                /// <summary>
                /// Creates a database variable to run the query.
                /// </summary>
                // Create SQL object within static method
                clsDataAccess db = new clsDataAccess();

                /// <summary>
                /// Creates an int variable to hold the reference integer.
                /// </summary>
                // Create reference
                int refItems = 0;

                // Execute Query
                ds = db.ExecuteSQLStatement(searchSQL.GetInvoiceID, ref refItems);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    // Create Scary item and add to bix box list
                    bigBox.Add(new clsInvoice(dr[0].ToString(), "invoiceID"));
                }

                return bigBox;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method gets the total cost for the combo box.
        /// </summary>
        /// <returns>Returns List<clsInvoice></returns>
        public List<clsInvoice> GetTotalCost()
        {
            try
            {
                /// <summary>
                /// Creates a dataset variable to hold the data.
                /// </summary>
                // Create a dataset to hold our data
                DataSet ds = new DataSet();

                /// <summary>
                /// Creates a List<clsInvoice> variable to hold the data.
                /// </summary>
                // Create a new list each time this method is called
                List<clsInvoice> bigBox = new List<clsInvoice>();

                /// <summary>
                /// Creates a database variable to run the query.
                /// </summary>
                // Create SQL object within static method
                clsDataAccess db = new clsDataAccess();

                /// <summary>
                /// Creates an int variable to hold the reference integer.
                /// </summary>
                // Create reference
                int refItems = 0;

                // Execute Query
                ds = db.ExecuteSQLStatement(searchSQL.GetTotalCharge, ref refItems);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    // Create Scary item and add to bix box list
                    bigBox.Add(new clsInvoice(dr[0].ToString(), "cost"));
                }

                return bigBox;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
