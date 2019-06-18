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

   // BillDestinationList destinations;
    /// <summary>
    /// Interaction logic for AddBillDestination.xaml
    /// </summary>
    public partial class AddBillDestination : Window
    {
        public AddBillDestination()
        {
            InitializeComponent();
        }

        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-apikey", "12345");
            client.BaseAddress = new Uri("http://localhost:63307/api/"); //local
            //client.BaseAddress = new Uri("http://otsvehicletracker.azurewebsites.net/api/"); //published
            return client;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            WPF.UI1.MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            BillDestination destination = new BillDestination();

            destination.Id = Guid.NewGuid();
            destination.BusinessName = txtName.Text;
            destination.BusinessAddress = txtAddress.Text;
            
            BillDestinationList destinations = new BillDestinationList();

            HttpClient client = InitializeClient();
            string serializedDestination = JsonConvert.SerializeObject(destination);
            var content = new StringContent(serializedDestination);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PostAsync("BillDestination", content).Result;

            destinations.Add(destination);
            lblLog.Content = "Destination Added";
            
        }
    }
}
