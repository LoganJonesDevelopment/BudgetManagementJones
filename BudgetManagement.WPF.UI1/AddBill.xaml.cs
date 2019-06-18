using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using BudgetManagement.BL;
using Newtonsoft.Json;

namespace BudgetManagement.WPF.UI1
{
    /// <summary>
    /// Interaction logic for AddBill.xaml
    /// </summary>
    public partial class AddBill : Window
    {
        BillList bills;
        Bill bill;
        public AddBill()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Bill bill = new Bill();
       //     bill.UserId = ((BL.User)(cboUser.SelectedItem)).Id;
         //   bill.DesinationId = ((BillDestination)(cboBillDestination.SelectedItem)).Id;
          //  bill.BillAmount = Int32.Parse(txtAmount.Text);
          //  bill.DueDate = (DateTime)calDue.SelectedDate;
            bill.PaidOnTime = true;

    //        HttpClient client = InitializeClient();
            string serializedBill = JsonConvert.SerializeObject(bill);
            var content = new StringContent(serializedBill);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
    //        HttpResponseMessage response = client.PostAsync("Bill", content).Result;

            bills.Add(bill);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bills = new BillList();

      //      LoadBills();

    //        dgBills.ItemsSource = null;
   //         dgBills.ItemsSource = bills.Where(c => c.UserId == ((BL.User)(cboUser.SelectedItem)).Id);
        }
    }
}
