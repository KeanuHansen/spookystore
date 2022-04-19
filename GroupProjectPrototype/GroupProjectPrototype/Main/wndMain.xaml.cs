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
        /// Make a copy of total cost
        /// </summary>
        public double copyTotalCost;

        /// <summary>
        /// Keeps track of how many items are in the invoice
        /// </summary>
        public int numItems;

        /// <summary>
        /// Make a copy of total cost
        /// </summary>
        public int copyNumItems;

        /// <summary>
        /// Keep track of selected date
        /// </summary>
        public string sDate;

        /// <summary>
        /// Checks if user hit the save button
        /// </summary>
        public bool isEdit;

        /// <summary>
        /// Holds in passed ID
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

                selectedDate.DisplayDate = DateTime.Now.AddDays(-1);

                // Create a new mainLogic object
                mLogic = new clsMainLogic();

                bList = new BindingList<clsBusinessItem>();

                // Create a new list object
                itemList = new clsBigBoxOfScaryThings();

                // Disable edit, delete buttons, and items manager portion
                UIhandler(true, false, true, false, false);

                // Load items into combobox by binding it
                cbitemList.ItemsSource = clsBigBoxOfScaryThings.GetBusinessItems();

                // Create 4 Columns to be displayed in the Datagrid
                DataGridTextColumn column1 = new DataGridTextColumn();
                DataGridTextColumn column2 = new DataGridTextColumn();
                DataGridTextColumn column3 = new DataGridTextColumn();
                DataGridTextColumn column4 = new DataGridTextColumn();

                // Set the properties of the columns
                column1.Header = "Item ID";
                column1.Binding = new Binding("ItemID");

                column2.Header = "Item Name";
                column2.Binding = new Binding("ItemName");

                column3.Header = "Item Description";
                column3.Binding = new Binding("ItemDescription");

                column4.Header = "Cost";
                column4.Binding = new Binding("Cost");

                // Add the columns to the datagrid
                invoiceDG.Columns.Add(column1);
                invoiceDG.Columns.Add(column2);
                invoiceDG.Columns.Add(column3);
                invoiceDG.Columns.Add(column4);

                // Don't generate columns automatically
                invoiceDG.AutoGenerateColumns = false;                

            } catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        // Finished
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

        // Finished
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

        // Needs work
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
                mLogic.deleteInvoice(bList, invoiceLbl.Content.ToString());

                // Delete the items list
                bList.Clear();

                // Change to false since save invoice initiallay turned this to true
                isEdit = false;

                // Refresh the datagrid
                invoiceDG.ItemsSource = null;

                // Clear out labels
                invoiceLbl.Content = "";
                costLbl.Content = "";
                numItemsLbl.Content = "";

                // "Reset" Date and Textbox
                itemCost.Text = "";
                itemDesc.Text = "";

                // Make sure the combobox is not selecting anything
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

        // Finished
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

                // Display the window
                wndUpdateItems.ShowDialog();

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

        // Finished
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
                    emptyLbl.Content = "There are no invoices to look up!";
                    return;
                }

                // Create a new search window object
                wndSearch = new SearchWindow();

                // Open the new window
                wndSearch.ShowDialog();

                /*Once Keanu's window is closed, we get back here*/

                // Check if user canceled out of the window
                if(wndSearch.SelectedID is null)
                {
                    return;
                }

                // Disable create invoice btn & menu and enable edit & delete btns
                UIhandler(false, true, false, true, true);

                // Save the InvoiceID from the search window
                invoiceID = wndSearch.SelectedID;

                // Update the invoice label
                invoiceLbl.Content = invoiceID;

                // Bind that list to the datagrid
                invoiceDG.ItemsSource = clsBigBoxOfScaryThings.getInvoiceItems(invoiceID);

                //Update Selected date, Total cost, and number of items
                totalCost = Convert.ToDouble(clsBigBoxOfScaryThings.TotalCost);
                costLbl.Content = totalCost;

                numItems = clsBigBoxOfScaryThings.numItems;
                numItemsLbl.Content = Convert.ToString(numItems);

                // Update the date
                selectedDate.SelectedDate = DateTime.Parse(clsBigBoxOfScaryThings.SelDate);

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
                // Do Nothing if there is no selected item
                if (cbitemList.SelectedItem is null)
                {
                    return;
                }

                // Update Textbox
                itemCost.Text = "$" + ((clsBusinessItem)cbitemList.SelectedItem).Cost.ToString();
                itemDesc.Text = ((clsBusinessItem)cbitemList.SelectedItem).ItemDescription.ToString();
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
                // If theres nothing selected in combobox, do nothing
                if (cbitemList.SelectedItem is null)
                {
                    return;
                }
                // Save the selected item to business object
                newItem = (clsBusinessItem)cbitemList.SelectedItem;

                // Update the items list
                bList.Add(newItem);

                // Update the datagrid
                invoiceDG.ItemsSource = bList;

                // They're currently not editing the invoice
                if (!isEdit)
                {
                    // Update the total cost
                    totalCost += Convert.ToDouble(newItem.Cost);

                    // Update the total cost label
                    costLbl.Content = totalCost.ToString();

                    // Increment number of items
                    numItems++;

                    // Update number of items label
                    numItemsLbl.Content = numItems.ToString();
                }
                else
                {
                    // Update the copied total cost
                    copyTotalCost += Convert.ToDouble(newItem.Cost);
                    costLbl.Content = copyTotalCost.ToString();

                    // Update the copied number of items
                    copyNumItems++;
                    numItemsLbl.Content = copyNumItems.ToString();

                }
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
        #region Delete Item
        /// <summary>
        /// Allows user to delete item from datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Prevent user from deleting if they haven't selected anything in datagrid or the datagrid is empty
                if (invoiceDG.SelectedItem is null || numItems == 0)
                {
                    return;
                }

                // User is currently not editing the invoice
                if (!isEdit)
                {
                    // Decrement number of items and update the label
                    numItems--;
                    numItemsLbl.Content = numItems.ToString();

                    // There is sum issues with subracting doubles
                    if (numItems == 0)
                    {
                        totalCost = 0;
                    }
                    else
                    {
                        // Decrement total cost and number of items
                        totalCost -= Convert.ToDouble(((clsBusinessItem)invoiceDG.SelectedItem).Cost);
                    }

                    // Update the total cost label
                    costLbl.Content = totalCost.ToString();
                }
                else
                {
                    // Decrement copied number of items and update the label
                    copyNumItems--;
                    numItemsLbl.Content = copyNumItems.ToString();

                    // There is sum issues w/ subracting doubles
                    if(copyNumItems == 0)
                    {
                        copyTotalCost = 0;
                    }
                    else
                    {
                        copyTotalCost -= Convert.ToDouble(((clsBusinessItem)invoiceDG.SelectedItem).Cost);
                    }

                    // Update the total cost label
                    costLbl.Content = copyTotalCost.ToString();
                }

                // Remove the item from the items list and datagrid
                bList.Remove((clsBusinessItem)invoiceDG.SelectedItem);

                // Prevents multiple deletes in one hit
                invoiceDG.SelectedItem = null;

            }
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        //Issues adding items to relation table
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
                // Prevent user from saving invoice if no items are added
                if(invoiceDG.ItemsSource is null || numItems == 0)
                {
                    return;
                }

                // This it the final date they selected
                sDate = selectedDate.DisplayDate.ToShortDateString();

                // Checks if user is on edit mode
                if (!isEdit)
                {
                    /* User Saved the invoice for the first time */
                    mLogic.addInvoice(bList, Convert.ToString(totalCost), sDate);

                    // Retrieve the ID main logic class
                    invoiceID = mLogic.invoiceID;

                    // Update the ID label
                    invoiceLbl.Content = invoiceID;

                    // Change is edit to true
                    isEdit = true;

                    // Create copy of total num of items and total cost
                    copyTotalCost = totalCost;
                    copyNumItems = numItems;

                    // Only enables items manager, edit, and delete btn
                    UIhandler(false, false, false, true, true);
                }
                else
                {
                    // Prevents user if there are no items in edit mode
                    if (copyNumItems == 0 || invoiceDG.ItemsSource is null)
                    {
                        return;
                    }

                    // The user is on edit mode
                    UIhandler(true, false, true, false, false);

                    // Check  if there were any changes
                    // If not, Update the database
                    if ((totalCost != copyTotalCost) || (numItems != copyNumItems))
                    {
                        // Update the database
                        mLogic.updateInvoice(bList, Convert.ToString(copyTotalCost), sDate, Convert.ToString(invoiceLbl.Content));
                    }

                    // Clear out labels
                    invoiceLbl.Content = "";
                    costLbl.Content = "";
                    numItemsLbl.Content = "";

                    // "Reset" Date, Textbox, and combobox
                    itemCost.Text = "";
                    itemDesc.Text = "";
                    //selectedDate = DateTime.Now;
                    cbitemList.SelectedItem = null;

                    // Reset the totals
                    totalCost = 0;
                    numItems = 0;

                    // Clear out the list 
                    bList.Clear();

                    // Set back to false 
                    isEdit = false;
                }
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
