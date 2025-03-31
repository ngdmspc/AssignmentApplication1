using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Assignment
{
    public partial class Dashboard : Window
    {
        private string currentUserName;
        private string currentUserType;

        public Dashboard(string userName, string userType)
        {
            InitializeComponent();
            currentUserName = userName;
            currentUserType = userType;
            this.Title = $"Dashboard - {currentUserName} ({currentUserType})";
        }

        private void TxtStatus_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtStatus.Text == "Bạn đang nghĩ gì?")
            {
                txtStatus.Text = "";
                txtStatus.Foreground = Brushes.Black;
            }
        }

        private void TxtStatus_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                txtStatus.Text = "Bạn đang nghĩ gì?";
                txtStatus.Foreground = Brushes.Gray;
            }
        }

        private void BtnPost_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtStatus.Text) && txtStatus.Text != "Bạn đang nghĩ gì?")
            {
                StackPanel statusPanel = new StackPanel
                {
                    Margin = new Thickness(0, 5, 0, 5)
                };

                TextBlock statusText = new TextBlock
                {
                    Text = txtStatus.Text,
                    FontSize = 14,
                    TextWrapping = TextWrapping.Wrap
                };

                Button messageButton = new Button
                {
                    Content = "Nhắn tin",
                    Margin = new Thickness(0, 3, 0, 0),
                    Tag = txtStatus.Text
                };

                messageButton.Click += MessageButton_Click;

                statusPanel.Children.Add(statusText);
                statusPanel.Children.Add(messageButton);

                statusContainer.Children.Insert(0, statusPanel);

                txtStatus.Text = "Bạn đang nghĩ gì?";
                txtStatus.Foreground = Brushes.Gray;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập nội dung!");
            }
        }

        private void MessageButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBox userSelection = new ComboBox();
            userSelection.Items.Add("Student");
            userSelection.Items.Add("Teacher");
            userSelection.SelectedIndex = 0;

            Window selectionWindow = new Window
            {
                Title = "Chọn người nhận",
                Content = userSelection,
                Width = 200,
                Height = 100
            };

            selectionWindow.ShowDialog();

            string selectedUser = userSelection.SelectedItem.ToString();
            ChatWindow chatWindow = new ChatWindow(currentUserName, selectedUser);
            chatWindow.Show();
        }
    }
}
