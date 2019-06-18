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

namespace BudgetManagement.WPF.UI1
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        log4net.ILog log = log4net.LogManager.GetLogger("Utility.Logger");
        

        public AdminLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            if(txtUsername.Text == "admin" && txtPassword.Password == "password") { 
            Admin admin = new Admin();
            admin.Show();
            this.Close();
            } else
            {
                MessageBox.Show("Incorrect username or password, please try again");
            }
            if (log.IsInfoEnabled)
            {
                log.Info(txtPassword.Password);
                log.Info(txtUsername.Text);
            } else
            {
                MessageBox.Show("Log Error");
            }

            
        }

        private void TxtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
