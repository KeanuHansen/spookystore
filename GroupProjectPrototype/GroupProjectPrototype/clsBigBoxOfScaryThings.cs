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
	// If you dont love the name of this class, I will be very sad.
	class clsBigBoxOfScaryThings
	{

		/// <summary>
		/// List that will hold items based on ID
		/// </summary>
		public static List<clsScaryThing> bigBox;

		/// <summary>
		/// List that will hold business items
		/// </summary>
		public static List<clsBusinessItem> bList;


		public clsBigBoxOfScaryThings()
        {
			bigBox = new List<clsScaryThing>();
			bList = new List<clsBusinessItem>();
        }

        #region Get Business Items
        /// <summary>
        /// Retrieves all business items from the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<clsBusinessItem> GetBusinessItems()
        {
            try
            {
				
				clsMainSQL sSQL = new clsMainSQL();

				// Create a dataset to hold our data
				DataSet ds = new DataSet();

				// Create a new list each time this method is called
				bList = new List<clsBusinessItem>();

				// Create SQL object within static method
				clsDataAccess db = new clsDataAccess();

				// Number of returned rows from query 
				int retVal = 0;

				// Execute the query and save it in dataset
				ds = db.ExecuteSQLStatement(sSQL.getBusinessItems(), ref retVal);

				// Loop through the entire dataset
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
					// Create a business object and append it to the business list
					bList.Add(new clsBusinessItem(
							  Convert.ToString(dr[0]), Convert.ToString(dr[1]), 
							  Convert.ToString(dr[2]), Convert.ToString(dr[3])));
                }

				return bList;
			} 
			catch (Exception ex)
            {
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
					MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
        }
        #endregion

		/// <summary>
		/// Retrieves all items based on invoice ID
		/// </summary>
		/// <returns></returns>
		public List<clsScaryThing> getInvoiceItems(string invoiceID)
        {
            try
            {
				clsMainSQL sSQL = new clsMainSQL();

				// Create a dataset to hold our data
				DataSet ds = new DataSet();

				// Create a new list each time this method is called
				bigBox = new List<clsScaryThing>();

				// Create SQL object within static method
				clsDataAccess db = new clsDataAccess();

				// Number of returned rows from query 
				int retVal = 0;

				// Execute Query
				ds = db.ExecuteSQLStatement(sSQL.getInvoiceItems(invoiceID), ref retVal);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
					// Create Scary item and add to bix box list
					bigBox.Add(new clsScaryThing(
							   Convert.ToString(dr[0]), Convert.ToString(dr[1]), (DateTime)dr[2],
							   Convert.ToString( dr[3]), Convert.ToString(dr[4])));
                }

				return bigBox;

			} 
			catch (Exception ex)
            {
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
					MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
        }
    } // end of class
}

