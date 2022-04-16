using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectPrototype
{
	// If you dont love the name of this class, I will be very sad.
	class clsScaryThing
	{
		//public string invoiceID { get; set; } I dont think this one is necessary since main is passing in ID
		public string itemID { get; set; }
		public string item { get; set; }
		public DateTime sellDate { get; set; }
		public string cost { get; set; } // is this total cost or cost of singular item? 
		public string description { get; set; }
        
		/// <summary>
		/// Default Parameter
		/// </summary>
		public clsScaryThing()
        {

        }
		/// <summary>
		/// Parameterized Constructor
		/// </summary>
		public clsScaryThing(/*string invoiceID,*/ string itemID, string item, DateTime sellDate, string cost, string description)
        {
			try
			{
				//this.invoiceID = invoiceID;
				this.itemID = itemID;
				this.item = item;
				this.sellDate = sellDate;
				this.cost = cost;
				this.description = description;
			} 
			catch(Exception ex)
            {
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
					MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
        }
	} // end of class
}
