using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectPrototype.Search
{
    class clsSearchSQL
    {
        // Poor Code Decisions to be credited to: Keanu Hansen

        /// <summary>
        /// This method filters for items in an invoice based on the Invoice_ID, Total_Cost, Sell_Date.
        /// </summary>
        /// <param name="invoiceID">The SQL filter to be executed by.</param>
        /// <param name="totalCost">The SQL filter to be executed by.</param>
        /// <param name="sellDate">The SQL filter to be executed by.</param>
        /// <returns>Returns a sql query.</returns>
        // READ NOTE BELOW
        // NOTE: I could have split this up into multiple queries, but I found making a dynamic one to be best. That way it is less clunky.
        public string Filter(string invoiceID, string totalCost, string sellDate)
        {
            try
            {
                // I don't know if the if statements are considered 'business logic', I feel like they aren't though since they are purely just for constructing the sql string. 
                // IF that is wrong I can change how I do it, thank you!

                /// <summary>
                /// String variable that holds the sql query
                /// </summary>
                string sql = String.Format("");

                sql += String.Format("SELECT ");
                    sql += String.Format("* ");
                sql += String.Format("FROM ");
                    sql += String.Format("Invoices ");
                sql += String.Format("WHERE ");

                    // Instead of having various different types of queries, I allow it to filter through which data exists and which doesn't, and choose it that way.
                    if(invoiceID != null && invoiceID != "")
                    {
                        sql += String.Format("Invoices.Invoice_ID = {0} ", invoiceID);
                    }

                    if (totalCost != null && totalCost != "")
                    {
                        // Only add an AND if it is not the first WHERE clause.
                        if (invoiceID != null && invoiceID != "")
                        {
                            sql += String.Format("AND ");
                        }

                        sql += String.Format("Invoices.Total_Cost = {0} ", totalCost);
                    }

                    if (totalCost != null && totalCost != "")
                    {
                        // Only add an AND if it is not the first WHERE clause.
                        if ((invoiceID != null && invoiceID != "") || (totalCost != null && totalCost != ""))
                        {
                            sql += String.Format("AND ");
                        }

                        sql += String.Format("Invoices.Sell_Date = '{0}' ", sellDate);
                    }

                return sql;
            }
            catch (Exception ex)
            {
                // Calling methods need to throw the exception with meaningful information.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
