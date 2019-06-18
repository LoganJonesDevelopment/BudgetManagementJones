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
using BudgetManagement.BL;

namespace BudgetManagement.WPF.UI1
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        UserList users;
        User user;

        public Admin()
        {
            InitializeComponent();
            Rebind();
        }
        private void Rebind()
        {
            users = new UserList();
            users.Load();

            dgAdmin.ItemsSource = null;
            dgAdmin.ItemsSource = users;
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (dgAdmin.SelectedIndex > -1)
            {
                user = users[dgAdmin.SelectedIndex];
                users[dgAdmin.SelectedIndex] = user;
                user.Delete();
                users.Remove(user);

                Rebind();

            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            WPF.UI1.MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
       //     user.Id = Guid.NewGuid();
            user.FirstName = txtFirstname.Text;
            user.LastName = txtLastName.Text;
            user.Address = txtAddress.Text;
            user.BillingAddress = txtBillingAddress.Text;
            user.City = txtCity.Text;
            user.State = txtState.Text;
            user.ZipCode = Int32.Parse(txtZipCode.Text);
            user.Email = txtEmail.Text;
            user.Password = txtPassword.Text;


           

            

            user.Insert();
            users.Add(user);
            Rebind();
        }
    }
}
