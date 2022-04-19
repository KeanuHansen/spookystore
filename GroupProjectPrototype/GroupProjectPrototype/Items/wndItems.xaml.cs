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
using System.Data;
using System.Windows.Data;
using System.Windows.Navigation;

namespace GroupProjectPrototype
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {

        /// <summary>
        /// object for adding new item
        /// </summary>
        clsItemsLogic newItem; 

        /// <summary>
        /// object for editing an item
        /// </summary>
        clsItemsLogic editItem;

        int ItemID;
        
        public EditWindow()
        {
            newItem = new clsItemsLogic();
            InitializeComponent();

            cmbItemList.ItemsSource = clsBigBoxOfScaryThings.GetBusinessItems();
            itemsGrid.ItemsSource = clsBigBoxOfScaryThings.GetBusinessItems();
        }

        private void mainButton_Click(object sender, RoutedEventArgs e)
        {
            // Create the wndMain variable.
            MainWindow wndMain = new MainWindow();

            // Go to the wndMain page.
            this.Hide();
            wndMain.ShowDialog();
            this.Show();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            // Create the wndSearch variable.
            SearchWindow wndSearch = new SearchWindow();

            // Go to the wndSearch page.
            this.Hide();
            wndSearch.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// adds item to database and updates datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e) {
            try
            {
                if (txtNewItemCost.Text != "" && txtNewItemName.Text != "" && txtNewItemDes.Text != "")
                {
                    newItem.addNewItem(txtNewItemName.Text, txtNewItemDes.Text, Convert.ToDouble(txtNewItemCost.Text));
                }
                else
                {
                    //error
                }
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// selects the item 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// deletes the item from the database then updates the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// changes the edits made to the selected item to the database, updates the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// for when the selected item in the combobox is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

    }
}
