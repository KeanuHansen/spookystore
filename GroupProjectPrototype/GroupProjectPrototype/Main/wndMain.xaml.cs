using GroupProjectPrototype.Main;
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
        /// Creates SQL Object
        /// </summary>
        clsMainSQL mainDB;

        /// <summary>
        /// Keep track of total cost
        /// </summary>
        double totalCost = 0;

        /// <summary>
        /// Create main logic object
        /// </summary>
        clsMainLogic mainLogic;

        /// <summary>
        /// Keep track of selected date
        /// </summary>
        DateTime selectedDate;

        
        public MainWindow()
        {
            try
            {


                InitializeComponent();
                mainDB = new clsMainSQL();

                // Create a datetime object
                selectedDate = new DateTime();

                //// Populate combo box
                //mainDB.display();
            } catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }
        }

        //
        //
        //
        //
        //
        // Make a constructor that takes an Invoice ID
        //
        //
        //
        //
        //

        /// <summary>
        /// Allows the user to create their invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                // Display the edit/create UI
                deleteUI.Visibility = Visibility.Hidden;
                create.Visibility = Visibility.Visible;
                edit.Visibility = Visibility.Hidden;
            } catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }
        }

        /// <summary>
        /// Pass invoice id to edit class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                // Display the edit/create UI 
                deleteUI.Visibility = Visibility.Hidden;
                create.Visibility = Visibility.Hidden;
                edit.Visibility = Visibility.Visible;
            } catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }
        }

        /// <summary>
        /// Pass in ID into a delete sql query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                //Display the Delete UI
                create.Visibility = Visibility.Hidden;
                deleteUI.Visibility = Visibility.Visible;
                edit.Visibility = Visibility.Hidden;
            } catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }
        }

        /// <summary>
        /// Adds item to user's invoice 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                // Retrive info from combo box and textBox
                string selectedItem = itemList.SelectedItem.ToString();
                double cost = Convert.ToDouble(itemCost.Text);

                // Checks if user selected something
                if (String.IsNullOrEmpty(selectedItem))
                {
                    // Let them know that they haven't selected anything
                }
                else
                {
                    // call addItem() and pass in the item name and cost
                    mainLogic.addItem(selectedItem, cost);
                }
            } catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }
        }

        /// <summary>
        /// Adds an item to existing invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EdAddItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                string selectedInvoice = InvoiceList.SelectedItem.ToString();

                // Populate datagrid based on selected invoice


                // Retrive info from combo box and textBox
                string selectedItem = EditemList.SelectedItem.ToString();
                double cost = Convert.ToDouble(EdItemCost.Text);

                // Checks if user selected something
                if (String.IsNullOrEmpty(selectedItem) || String.IsNullOrEmpty(selectedInvoice))
                {
                    // Let them know that they haven't selected anything
                }
                else
                {
                    // call EDaddItem() and pass in the item name and cost
                    mainLogic.edAddItem(selectedItem, cost, selectedInvoice);
                }
            } catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }

        }



        /// <summary>
        /// Allows user to create their invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                // pass total cost and sell date
                mainLogic.insertBox(totalCost, selectedDate);
            } catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }
        }

        /// <summary>
        /// Saves the edited draft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EdSaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                // Retreive the invoice ID that was selected
                string selectedInvoice = InvoiceList.SelectedItem.ToString();

                mainLogic.upInsertBox(totalCost, selectedDate, selectedInvoice);
            } catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }

        }

        /// <summary>
        /// Sends the user to the Items form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Items_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                // Create the wndItems variable.
                EditWindow wndItems = new EditWindow();

                // Go to the wndItems page.
                this.Hide();
                wndItems.ShowDialog();
                this.Show();
            } catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }
        }

        /// <summary>
        /// Sends the user to the Search Invoice Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                // Create the wndSearch variable.
                SearchWindow wndSearch = new SearchWindow();

                // Go to the wndSearch page.
                this.Hide();
                wndSearch.ShowDialog();
                this.Show();
            } catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }
        }


        /// <summary>
        /// Cancels the entire invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                // clear out the labels throughout the main screen
            } catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }
        }

        /// <summary>
        /// Allows user to delete Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delDelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                // Retreive information from comboBox
                string selectedID = InvoicesCmbBox.SelectedItem.ToString();

                // Populate dategrid, update total cost, and number of items

                // Checks if user selected something
                if (String.IsNullOrEmpty(selectedID))
                {
                    // Let them know that they haven't selected anything
                }
                else
                {
                    // call deleteItem() and pass in the item ID from combobox
                    mainLogic.deleteItem(selectedID);

                }
            } catch (Exception ex)
            {
                // Handle the error in top level method calls.
                System.IO.File.AppendAllText("C:\\HandleError.txt",
                    Environment.NewLine + "HandleError Exception " +
                        ex.Message);
            }

        }




    }
}
