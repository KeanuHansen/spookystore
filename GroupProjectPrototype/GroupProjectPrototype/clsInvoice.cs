using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectPrototype
{
    public class clsInvoice
    {
        /// <summary>
        /// Public data members
        /// </summary>
        public string invoiceID;
        public string totalCost;
        public string selDate;

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <param name="total"></param>
        /// <param name="selDate"></param>
        public clsInvoice(string invoiceID, string total, string selDate)
        {
            try
            {
                this.invoiceID = invoiceID;
                this.totalCost = total;
                this.selDate = selDate;
            } 
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

    }
}
