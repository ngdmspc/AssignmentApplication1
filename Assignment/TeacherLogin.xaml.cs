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


namespace Assignment
{
    /// <summary>
    /// Interaction logic for TeacherLogin.xaml
    /// </summary>
    public partial class TeacherLogin : Window
    {
        public TeacherLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Password = "";
        }

        private void btnName_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "Teacher" && txtPassword.Password == "123")
            {
                MessageBox.Show("Login Success!!!");
                Dashboard dashboard = new Dashboard(txtUsername.Text, "Teacher"); 
                dashboard.Show();
                

            }
            else
            {
                MessageBox.Show("Faild login.");
            }
        }
    }
}
