using System;
using System.Reflection;

namespace GroupProjectPrototype.Search
{
    class clsSearchSQL
    {
        // Poor Code Decisions to be credited to: Keanu Hansen

        /// <summary>
        /// This method filters for items in an invoice based on the Invoice_ID, Total_Cost, Sell_Date.
        /// </summary>
        /// <returns>Returns a sql query.</returns>
        // READ NOTE BELOW
        // NOTE: I could have split this up into multiple queries, but I found making a dynamic one to be best. That way it is less clunky.
        public string Filter(string invoice, string cost, string date)
        {
            {
                try
                {
                    string sql = String.Format("SELECT Invoice_ID, Total_Cost, Sell_Date FROM Invoices WHERE ");

                    if(invoice != "")
                    {
                        sql += String.Format(" Invoice_ID = {0} ", invoice);
                    }

                    if(cost != "")
                    {
                        if (invoice != "")
                        {
                            sql += String.Format(" AND ");
                        }

                        sql += String.Format(" Total_Cost = {0} ", cost);
                    }

                    if (date != "")
                    {
                        if (invoice != "" || cost != "")
                        {
                            sql += String.Format(" AND ");
                        }

                        sql += String.Format(" Sell_Date = #{0}# ", DateTime.Parse(date).ToString("yyyy/MM/dd"));
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

        /// <summary>
        /// Gets the Invoice ID's for the main page
        /// </summary>
        public string GetInvoiceID
        {
            get
            {
                return "SELECT DISTINCT Invoice_ID FROM Invoices ";
            }
        }

        /// <summary>
        /// Gets the Total Charges for the main page
        /// </summary>
        public string GetTotalCharge
        {
            get
            {
                return "SELECT DISTINCT Total_Cost FROM Invoices ";
            }
        }
    }
}
