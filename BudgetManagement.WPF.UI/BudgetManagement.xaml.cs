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
using BudgetManagement.BL;

namespace BudgetManagement.WPF.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BillList bills;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                bills = new BillList();
                bills.Load();

                dgvBills.ItemsSource = null;
                dgvBills.ItemsSource = bills;

                


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dgvBills_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
