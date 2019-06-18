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
using BudgetManagement.Utilities.Reporting;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Data;
//using EASendMail; //add EASendMail namespace

namespace BudgetManagement.WPF.UI1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BillList bills;
        Bill bill;
        BillDestinationList billDestinations = new BillDestinationList();
        UserList users = new UserList();

        private void LoadBills()
        {
            try
            {
                HttpClient client = InitializeClient();

                string result;
                dynamic items;
                HttpResponseMessage response;

                // Call the api
                response = client.GetAsync("Bill").Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Process the response
                    result = response.Content.ReadAsStringAsync().Result;

                    // REALLY COOL LINE OF CODE HERE
                    items = (JArray)JsonConvert.DeserializeObject(result);
                    bills = items.ToObject<BillList>();

                }
                else
                {
                    throw new Exception("Error: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDestinations()
        {
            try
            {
                HttpClient client = InitializeClient();

                string result;
                dynamic items;
                HttpResponseMessage response;

                // Call the api
                response = client.GetAsync("BillDestination").Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Process the response
                    result = response.Content.ReadAsStringAsync().Result;

                    // REALLY COOL LINE OF CODE HERE
                    items = (JArray)JsonConvert.DeserializeObject(result);
                    billDestinations = items.ToObject<BillDestinationList>();

                    Rebind();
                }
                else
                {
                    throw new Exception("Error: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadUsers()
        {
            try
            {
                HttpClient client = InitializeClient();

                string result;
                dynamic items;
                HttpResponseMessage response;

                // Call the api
                response = client.GetAsync("User").Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Process the response
                    result = response.Content.ReadAsStringAsync().Result;

                    // REALLY COOL LINE OF CODE HERE
                    items = (JArray)JsonConvert.DeserializeObject(result);
                    users = items.ToObject<UserList>();

                    Rebind();
                }
                else
                {
                    throw new Exception("Error: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            bills = new BillList();
            LoadBills();

            LoadUsers();

            cboUser.ItemsSource = null;
            cboUser.ItemsSource = users;
            cboUser.DisplayMemberPath = "FullName";
            cboUser.SelectedValuePath = "Id";


            LoadDestinations();

            cboBillDestination.ItemsSource = null;
            cboBillDestination.ItemsSource = billDestinations;
            cboBillDestination.DisplayMemberPath = "BusinessName";
            cboBillDestination.SelectedValuePath = "Id";


        }

        private void Rebind()
        {
            dgBills.ItemsSource = null;

            SqlConnection con = new SqlConnection("data source=sprangersdb.database.windows.net;initial catalog=sprangersdb;user id=sprangersdb;password=Test123!");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_GetUserBillsDestinations", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgBills.ItemsSource = ds.Tables[0].DefaultView;
            }
            con.Close();
        }


        private void btnEmail_Click(object sender, RoutedEventArgs e)
        {


            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("BudgetManagementEmailTest@gmail.com");
                mail.To.Add("700146346@fvtc.edu");
                mail.Subject = "Hello World";
                mail.Body = "<h1>Hello</h1>";
                mail.IsBodyHtml = true;


                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("BudgetManagementEmailTest@gmail.com", "Test123!");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Bill bill = new Bill();
            bill.UserId = ((BL.User)(cboUser.SelectedItem)).Id;
            bill.DesinationId = ((BillDestination)(cboBillDestination.SelectedItem)).Id;
            bill.BillAmount = Int32.Parse(txtAmount.Text);
            bill.DueDate = (DateTime)calDue.SelectedDate;
            bill.PaidOnTime = true;

            HttpClient client = InitializeClient();
            string serializedBill = JsonConvert.SerializeObject(bill);
            var content = new StringContent(serializedBill);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PostAsync("Bill", content).Result;

            bills.Add(bill);


             Rebind();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgBills.SelectedIndex > -1)
            {
                bill = bills[dgBills.SelectedIndex];

                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.DeleteAsync("Bill/" + bill.Id).Result;

                bills.Remove(bill);

                Rebind();

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bills = new BillList();

            LoadBills();

            dgBills.ItemsSource = null;
            dgBills.ItemsSource = bills.Where(c => c.UserId == ((BL.User)(cboUser.SelectedItem)).Id);

            dgBills.Columns[0].Visibility = Visibility.Hidden;
            dgBills.Columns[1].Visibility = Visibility.Hidden;
            dgBills.Columns[2].Visibility = Visibility.Hidden;
            dgBills.Columns[3].Visibility = Visibility.Hidden;
            dgBills.Columns[4].Visibility = Visibility.Hidden;

        }

        private void CboBillDestination_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            Excel.Export(@"C:\Users\test.xls", null);
        }

        private void btnEmail1_Click(object sender, RoutedEventArgs e)
        {
            ExportToExcel();
        }

        private void btnExport_Click_1(object sender, RoutedEventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            dgBills.SelectAllCells();
            dgBills.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dgBills);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            dgBills.UnselectAllCells();
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\700146346\testExcel.xls");
            file.WriteLine(result.Replace(',', ' '));
            file.Close();

            MessageBox.Show("Exporting DataGrid data to Excel: file created");
        }

        private void btnAdminWindow_Click(object sender, RoutedEventArgs e)
        {
            AdminLogin adminlogin = new AdminLogin();
            adminlogin.Show();
            this.Close();
        }

        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-apikey", "12345");
            client.BaseAddress = new Uri("http://localhost:63307/api/"); //local
            //client.BaseAddress = new Uri("http://otsvehicletracker.azurewebsites.net/api/"); //published
            return client;
        }

        private void BtnAddBillDestination_Click(object sender, RoutedEventArgs e)
        {
            AddBillDestination billDestination = new AddBillDestination();
            billDestination.Show();
            this.Close();
        }

        private void BtnAddBillWindow_Click(object sender, RoutedEventArgs e)
        {
            AddBillDestination billDestination = new AddBillDestination();
            billDestination.Show();
            this.Close();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {

            dgBills.Items.Refresh();
        }
    }

}
