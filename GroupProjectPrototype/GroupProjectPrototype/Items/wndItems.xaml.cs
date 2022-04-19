
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
using System.Reflection;

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

            btnSelectItem.IsEnabled = false;
            btnDeleteItem.IsEnabled = false;
            btnSaveEdit.IsEnabled = false;

            cmbItemList.ItemsSource = clsBigBoxOfScaryThings.GetBusinessItems();
            itemsGrid.ItemsSource = clsBigBoxOfScaryThings.GetBusinessItems();
        }

        /// <summary>
        /// cancels and closes the items window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            //close the window
            this.Close();
        }


        /// <summary>
        /// adds item to database and updates datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtNewItemCost.Text != "" && txtNewItemName.Text != "" && txtNewItemDes.Text != "")
                {
                    newItem.addNewItem(txtNewItemName.Text, txtNewItemDes.Text, Convert.ToDouble(txtNewItemCost.Text));
                    txtNewItemCost.Text = "";
                    txtNewItemDes.Text = "";
                    txtNewItemName.Text = "";
                    cmbItemList.ItemsSource = clsBigBoxOfScaryThings.GetBusinessItems();
                    itemsGrid.ItemsSource = clsBigBoxOfScaryThings.GetBusinessItems();
                }
            }
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
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
                ItemID = Convert.ToInt32(((clsBusinessItem)cmbItemList.SelectedItem).ItemID);
                editItem = new clsItemsLogic(ItemID);
                txtItemName.Text = editItem.getItemName();
                txtCost.Text = editItem.getCost().ToString();
                txtDescription.Text = editItem.getDescription();
            }
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
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
                editItem = new clsItemsLogic(ItemID);
                editItem.deleteItem();

                cmbItemList.ItemsSource = clsBigBoxOfScaryThings.GetBusinessItems();
                itemsGrid.ItemsSource = clsBigBoxOfScaryThings.GetBusinessItems();

                txtItemName.Text = "";
                txtCost.Text = "";
                txtDescription.Text = "";
            }
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
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
                //change the stuff
                editItem.changePrice(Convert.ToDouble(txtCost.Text));
                editItem.changeDescription(txtDescription.Text);
                editItem.changeName(txtItemName.Text);

                //clear the textboxes
                txtCost.Text = "";
                txtDescription.Text = "";
                txtItemName.Text = "";

                //update the lists
                cmbItemList.ItemsSource = clsBigBoxOfScaryThings.GetBusinessItems();
                itemsGrid.ItemsSource = clsBigBoxOfScaryThings.GetBusinessItems();

            }
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

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

        /// <summary>
        /// for when the selected item in the combobox is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbItemList is null)
                {
                    btnSaveEdit.IsEnabled = false;
                    btnSelectItem.IsEnabled = false;
                    btnDeleteItem.IsEnabled = false;
                }
                else
                {
                    btnSaveEdit.IsEnabled = true;
                    btnSelectItem.IsEnabled = true;
                    btnDeleteItem.IsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                // Handle the error in top level method calls.
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
