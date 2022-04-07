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
        string SelectedID;

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
                // PASSING DATA: Get the data from the selected item in the DataGrid. It is passed into the SelectedItem variable.
                // Not needed for this part though, just need to plan it, if I understand the instructions.

                // Create the wndMain variable.
                // PASSING DATA: Pass the selected invoice into the constructor, as it should have a constructor for specific invoices.
                MainWindow wndMain = new MainWindow();

                // Go to the wndMain page.
                this.Hide();
                wndMain.ShowDialog();
                this.Show();
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
                // Create the wndMain variable.
                MainWindow wndMain = new MainWindow();

                // Go to the wndMain page.
                this.Hide();
                wndMain.ShowDialog();
                this.Show();
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
        /// Return to the main window, but under the pretense of editing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create the wndItems variable.
                EditWindow wndItems = new EditWindow();

                // Go to the wndItems page.
                this.Hide();
                wndItems.ShowDialog();
                this.Show();
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
