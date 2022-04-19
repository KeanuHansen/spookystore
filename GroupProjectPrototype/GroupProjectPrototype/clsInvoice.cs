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

        /// <summary>
        /// String variable to hold the invoiceID
        /// </summary>
        public string invoiceID;

        /// <summary>
        /// String variable to hold the InvoiceID
        /// </summary>
        public string InvoiceID
        {
            get { return invoiceID; }
            set { invoiceID = value; }
        }

        /// <summary>
        /// String variable to hold the totalCost
        /// </summary>
        public string totalCost;

        /// <summary>
        /// String variable to hold the TotalCost
        /// </summary>
        public string TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        /// <summary>
        /// String variable to hold the sellDate
        /// </summary>
        public string selDate;

        /// <summary>
        /// String variable to hold the SellDate
        /// </summary>
        public string SellDate
        {
            get { return selDate; }
            set { selDate = value; }
        }

        /// <summary>
        /// String variable to hold the stringType
        /// </summary>
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
