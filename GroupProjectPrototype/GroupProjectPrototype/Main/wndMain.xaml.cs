using GroupProjectPrototype.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroupProjectPrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Search Windows object
        /// </summary>
        SearchWindow wndSearch;

        /// <summary>
        /// Items window object
        /// </summary>
        EditWindow wndUpdateItems;

        /// <summary>
        /// Create main windows logic object
        /// </summary>
        clsMainLogic mLogic;

        /// <summary>
        /// Holds in added items from the user
        /// </summary>
        //clsScaryThing newItem;
        clsBusinessItem newItem;

        /// <summary>
        /// Holds in every item user added
        /// </summary>
        clsBigBoxOfScaryThings itemList;

        /// <summary>
        /// Allows communication between datagrid and invoice list
        /// </summary>
        BindingList<clsBusinessItem> bList;

        /// <summary>
        /// Keep track of total cost
        /// </summary>
        public double totalCost;

        /// <summary>
        /// Keeps track of how many items are in the invoice
        /// </summary>
        public int numItems;

        /// <summary>
        /// Keep track of selected date
        /// </summary>
        public DateTime selectedDate;

        /// <summary>
        /// Checks if user hit the save button
        /// </summary>
        public bool isEdit;

        /// <summary>
        /// Holds in passed ID from search window
        /// </summary>
        public string invoiceID;

        // Make sure to delete bin and maybe obj before committing

        #region Default Constructor 
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;


                // Initialize cost, isEdit, and number of items
                totalCost = 0;
                isEdit = false;
                numItems = 0;

                // Set the day to current day
                selectedDate = DateTime.Now;                

                // Create a new mainLogic object
                mLogic = new clsMainLogic();

                // Create a new item object
                //newItem = new clsScaryThing();
               // newItem = new clsBusinessItem();

               bList = new BindingList<clsBusinessItem>();

                // Create a new list object
                itemList = new clsBigBoxOfScaryThings();

                // Create a new business item list object
                //bList = new clsBusinessList();

                // Disable edit, delete buttons, and items manager portion
                UIhandler(true, false, true, false, false);

                // Load items into combobox by binding it
                cbitemList.ItemsSource = clsBigBoxOfScaryThings.GetBusinessItems();

            } catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        // Needs work
        #region Create Invoice
        /// <summary>
        /// Allows user to create a new invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Make sure this is cleared out
                emptyLbl.Content = "";

                // We wont know invoice ID till user saves it
                invoiceLbl.Content = "TBD";

                // Enable items manager, disable the create btn & menu
                UIhandler(false, true, false, false, false );

                // Dont allow user to save invoice till they've added one item - use if statement
                //SaveInvoice.IsEnabled = false;


            }
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        // Needs work
        #region Edit Invoice
        /// <summary>
        /// Allows user to edit invoice once they created one or searched it up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // User clicked edit button
                isEdit = true;

                // Disable the buttons & menu
                UIhandler(false, true, false, false, false);

            } 
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        // Finished?
        #region Delete Invoice
        /// <summary>
        /// Allows user to delete invoice once they created one or is searched up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Call function to delete the invoice
                //mLogic.deleteInvoice(invoiceLbl.Content.ToString());

                // Refresh the datagrid
                invoiceDG.RowStyle = null;

                // Clear out labels
                invoiceLbl.Content = "";
                costLbl.Content = "";
                numItemsLbl.Content = "";

                // "Reset" Date and Textbox
                itemCost.Text = "";
                itemDesc.Text = "";
                selectedDate = DateTime.Now;
                cbitemList.SelectedItem = null;

                // Reset the totals
                totalCost = 0;
                numItems = 0;


                // Enable menu & create btn
                UIhandler(true, false, true, false, false );


            } 
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        // Finished?
        #region Update Items
        /// <summary>
        /// Allows user to update items for their business
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Make sure this is cleared out
                emptyLbl.Content = "";

                // Create a new items window object
                wndUpdateItems = new EditWindow();

                // Update the combobox
                cbitemList.ItemsSource = clsBigBoxOfScaryThings.GetBusinessItems();
            } 
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        // Needs work
        #region Search Invoice
        /// <summary>
        /// Allows user to search for an invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Make sure this is cleared out
                emptyLbl.Content = "";

                // Error will occur if they search invoice when there's nothing to look up
                if (mLogic.isEmpty())
                {
                    /*Nothing is in our DB*/
                    // Update label
                    emptyLbl.Content = "There are no invoices to look up!";
                    return;
                }

                // Create a new search window object
                wndSearch = new SearchWindow();

                // Open the new window
                wndSearch.ShowDialog();

                /*Once Keanu's window is closed, we get back here*/

                // Save the InvoiceID from the search window
                invoiceID = wndSearch.SelectedID;

                // Update the invoice label
                invoiceLbl.Content = invoiceID;

                // Pass in ID to function that will return us the invoice list
                // Bind that list to the datagrid
                //clsBigBoxOfScaryThings.bigBox(invoiceID);



                // Disable create invoice btn & menu and enable edit & delete btns
                UIhandler(false, true, false, true, true);



            } 
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        // Finished
        #region Select Item
        /// <summary>
        /// Allows user to see the price of the selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbitemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbitemList.SelectedItem is null)
                {
                    return;
                }
                // Update Textbox
                itemCost.Text = "$" + ((clsBusinessItem)cbitemList.SelectedItem).cost.ToString();
                itemDesc.Text = ((clsBusinessItem)cbitemList.SelectedItem).itemDescription.ToString();
            } 
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        // Needs Work
        #region Add Item
        /// <summary>
        /// Allows user to add item to their invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbitemList.SelectedItem is null)
                {
                    return;
                }
                // Save the selected item to business object
                newItem = (clsBusinessItem)cbitemList.SelectedItem;

                // Update the items list
                bList.Add(newItem);

                // Update the datagrid
                invoiceDG.DataContext = bList;

                // Update the total cost
                totalCost += Convert.ToDouble(newItem.cost);

                // Update the total cost label
                costLbl.Content = totalCost.ToString();

                // Increment number of items
                numItems++;

                // Update number of items label
                numItemsLbl.Content = numItems.ToString();

            } 
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        //Needs Work
        #region Save Invoice
        /// <summary>
        /// Saves invoice to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Checks if user is on edit mode
                if (isEdit)
                {
                    // The user is on edit mode
                    UIhandler(true, false, true, false, false);
                    // Set back to false 
                    isEdit = false;
                }
                else
                {
                    // Only enables items manager, edit, and delete btn
                    UIhandler(false, false, false, true, true);
                }

                // Pass in information to function to save to database


                // Reset the label after user submitted or updated invoice
                invoiceLbl.Content = "";
                costLbl.Content = "";
                numItemsLbl.Content = "";

                // "Reset" Date, Textbox, and combobox
                itemCost.Text = "";
                selectedDate = DateTime.Now;
                cbitemList.SelectedItem = null;
                itemDesc.Text = "";

                // Reset the totals
                totalCost = 0;
                numItems = 0;

            } 
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        // Finished
        #region UI Handler
        /// <summary>
        /// Handles the enabling and disabling of UI
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void UIhandler(bool menu, bool items, bool create, bool edit, bool delete)
        {
            try
            {
                businessMenu.IsEnabled = menu;
                itemsManager.IsEnabled = items;
                createBtn.IsEnabled = create;
                editBtn.IsEnabled = edit;
                deleteBtn.IsEnabled = delete;
            } 
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        // Finished
        #region Exception Handling
        /// <summary>
        /// Exception Handling
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
        #endregion

    } // end of class
}
