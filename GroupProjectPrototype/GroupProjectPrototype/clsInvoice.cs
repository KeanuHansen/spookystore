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
        public string InvoiceID
        {
            get { return invoiceID; }
            set { invoiceID = value; }
        }
        public string totalCost;
        public string TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }
        public string selDate;
        public string SellDate
        {
            get { return selDate; }
            set { selDate = value; }
        }
        public string stringType { get; set; }

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
                stringType = "invoice";
                this.totalCost = total;
                stringType = "cost";
                this.selDate = selDate;
                stringType = "sell";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="totalCost"></param>
        public clsInvoice(string value, string type)
        {
            try
            {
                if(type == "cost")
                {
                    this.totalCost = value;
                    stringType = "cost";
                }
                else
                {
                    this.invoiceID = value;
                    stringType = "invoice";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Override ToString()
        /// </summary>
        public override string ToString()
        {
            if(stringType == "sell")
            {
                return this.selDate;
            }

            if(stringType == "cost")
            {
                return this.totalCost;
            }

            return this.invoiceID;
        }
    }
}
