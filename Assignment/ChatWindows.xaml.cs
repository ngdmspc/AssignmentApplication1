using System.Windows;
using System.Windows.Controls;

namespace Assignment
{
    public partial class ChatWindow : Window
    {
        private string userName;
        private string chatPartner;

        public ChatWindow(string userName, string currentUserType)
        {
            InitializeComponent();
            this.userName = userName;
            this.Title = $"Chat Window - {userName}";

            
            cmbUserSelection = new ComboBox
            {
                Margin = new Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 200
            };
            cmbUserSelection.SelectionChanged += cmbUserSelection_SelectionChanged;
            chatContainer.Children.Add(cmbUserSelection);

            
            LoadUserSelection();
        }

        private void LoadUserSelection()
        {
            cmbUserSelection.Items.Add("Student");
            cmbUserSelection.Items.Add("Teacher");
            cmbUserSelection.SelectedIndex = 0; 
        }

        private void cmbUserSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chatPartner = cmbUserSelection.SelectedItem.ToString();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMessage.Text) && !string.IsNullOrEmpty(chatPartner))
            {
                TextBlock messageText = new TextBlock
                {
                    Text = $"{userName}: {txtMessage.Text}",
                    FontSize = 14,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(0, 5, 0, 0)
                };

                chatContainer.Children.Add(messageText);
                txtMessage.Clear();
            }
        }
    }
}