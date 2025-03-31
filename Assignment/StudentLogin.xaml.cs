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
    /// Interaction logic for StudentLogin.xaml
    /// </summary>
    public partial class StudentLogin : Window
    {
        public StudentLogin()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Password = "";
        }

        private void btnName_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "Student" && txtPassword.Password == "123")
            {
                MessageBox.Show("Login Success!!!");
                Dashboard dashboard = new Dashboard(txtUsername.Text, "Student"); 
                dashboard.Show();
                

            }
            else
            {
                MessageBox.Show("Faild login.");
            }
        }
    }
}
