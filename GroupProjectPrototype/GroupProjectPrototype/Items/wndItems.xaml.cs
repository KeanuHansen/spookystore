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
        public EditWindow()
        {
            InitializeComponent();
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

        }

        /// <summary>
        /// selects the item 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectItem_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// deletes the item from the database then updates the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// changes the edits made to the selected item to the database, updates the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
