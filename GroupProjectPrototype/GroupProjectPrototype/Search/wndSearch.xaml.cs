using GroupProjectPrototype.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GroupProjectPrototype
{
    // Poor Code Decisions to be credited to: Keanu Hansen

    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        /// <summary>
        /// Variable to fulfill the requirement: Search window should have a comment about when the invoice is selected, the Invoice ID is saved in a local variable that the main window can access.
        /// </summary>
        /// From Mario - I made this public to access
        public string SelectedID;

        /// <summary>
        /// Make a logic object to run queries through
        /// </summary>
        clsSearchLogic objectSQL = new clsSearchLogic();

        /// <summary>
        /// Constructor
        /// </summary>
        public SearchWindow()
        {
            // PASSING DATA: Refresh the invoices, do this by having constructors that take data and running the query through that.

            InitializeComponent();

            // Add the Invoice ID's to the page.
            invoiceNum.ItemsSource = objectSQL.GetInvoices();

            // Add the Invoice Total Cost's
            invoiceTotalCharge.ItemsSource = objectSQL.GetTotalCost();

            // Initially display all the data

            // Filter based on what it has, and save it to a list to append to the data on the screen.
            var list = objectSQL.Filter("","","");

            // Append the list to the data grid.
            ItemDatagrid.ItemsSource = list;

            // Create 4 Columns to be displayed in the Datagrid
            DataGridTextColumn column1 = new DataGridTextColumn();
            DataGridTextColumn column2 = new DataGridTextColumn();
            DataGridTextColumn column3 = new DataGridTextColumn();

            // Set the properties of the columns
            column1.Header = "Invoice ID";
            column1.Binding = new Binding("InvoiceID");

            column2.Header = "Total Cost";
            column2.Binding = new Binding("TotalCost");

            column3.Header = "Sell Date";
            column3.Binding = new Binding("SellDate");

            // Add the columns to the datagrid
            ItemDatagrid.Columns.Add(column1);
            ItemDatagrid.Columns.Add(column2);
            ItemDatagrid.Columns.Add(column3);

            // Don't generate columns automatically
            ItemDatagrid.AutoGenerateColumns = false;
        }

        /// <summary>
        /// Pass the data to the relevant function (parse by invoice id, or parse by date, or parse by total charge)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFilter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ItemDatagrid.ItemsSource = null;
                ItemDatagrid.Columns.Clear();

                // Redo this, but make it so it can do one of many queries.

                // Have three query / four query options, based on the selection.

                // Append the clsInvoiceList to the datagrid

                /// <summary>
                /// Make a string to hold the Invoice_ID for the filter function.
                /// </summary>
                string invoiceID = "";

                /// <summary>
                /// Make a string to hold the Total_Cost for the filter function.
                /// </summary>
                string totalCost = "";

                /// <summary>
                /// Make a string to hold the Sell_Date for the filter function.
                /// </summary>
                string sellDate = "";

                // Parse through each possible filter to see if it has anything.

                if (invoiceNum.Text != "" && invoiceNum.Text != null)
                {
                    invoiceID = invoiceNum.Text;
                }

                if (invoiceTotalCharge.Text != "" && invoiceTotalCharge.Text != null)
                {
                    totalCost = invoiceTotalCharge.Text;
                }

                if (invoiceDate.SelectedDate != null)
                {
                    sellDate = invoiceDate.SelectedDate.ToString();
                }

                // Filter based on what it has, and save it to a list to append to the data on the screen.
                var list = objectSQL.Filter(invoiceID, totalCost, sellDate);

                // Append the list to the data grid.
                ItemDatagrid.ItemsSource = list;

                // Create 4 Columns to be displayed in the Datagrid
                DataGridTextColumn column1 = new DataGridTextColumn();
                DataGridTextColumn column2 = new DataGridTextColumn();
                DataGridTextColumn column3 = new DataGridTextColumn();

                // Set the properties of the columns
                column1.Header = "Invoice ID";
                column1.Binding = new Binding("InvoiceID");

                column2.Header = "Total Cost";
                column2.Binding = new Binding("TotalCost");

                column3.Header = "Sell Date";
                column3.Binding = new Binding("SellDate");

                // Add the columns to the datagrid
                ItemDatagrid.Columns.Add(column1);
                ItemDatagrid.Columns.Add(column2);
                ItemDatagrid.Columns.Add(column3);

                // Don't generate columns automatically
                ItemDatagrid.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }
        }

        /// <summary>
        /// Clear all the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Clear all the items in the datagrid
                ItemDatagrid.ItemsSource = null;
                ItemDatagrid.Columns.Clear();

                // Clear all the search values
                invoiceDate.SelectedDate = null;
                invoiceNum.SelectedItem = null;
                invoiceTotalCharge.SelectedItem = null;

                // Set the ID to null
                SelectedID = null;

                // Filter based on what it has, and save it to a list to append to the data on the screen.
                var list = objectSQL.Filter("", "", "");

                // Append the list to the data grid.
                ItemDatagrid.ItemsSource = list;

                // Create 4 Columns to be displayed in the Datagrid
                DataGridTextColumn column1 = new DataGridTextColumn();
                DataGridTextColumn column2 = new DataGridTextColumn();
                DataGridTextColumn column3 = new DataGridTextColumn();

                // Set the properties of the columns
                column1.Header = "Invoice ID";
                column1.Binding = new Binding("InvoiceID");

                column2.Header = "Total Cost";
                column2.Binding = new Binding("TotalCost");

                column3.Header = "Sell Date";
                column3.Binding = new Binding("SellDate");

                // Add the columns to the datagrid
                ItemDatagrid.Columns.Add(column1);
                ItemDatagrid.Columns.Add(column2);
                ItemDatagrid.Columns.Add(column3);

                // Don't generate columns automatically
                ItemDatagrid.AutoGenerateColumns = false;

            }
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }
        }

        /// <summary>
        /// Pass the invoice id to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Main Window deals with the data extraction
                this.Close();
            }
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }
        }

        /// <summary>
        /// Return to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Set this to null, as they are pushing cancel
                SelectedID = null;

                // Main Window deals with the data extraction
                this.Close();
            }
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }
        }

        /// <summary>
        /// Change to the selected InvoiceID.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Change the option to the SelectedID up top.
                var item = ((clsInvoice)ItemDatagrid.SelectedItem);

                if(item != null)
                {
                    SelectedID = item.InvoiceID;
                }
            }
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }
        }
    }
}
