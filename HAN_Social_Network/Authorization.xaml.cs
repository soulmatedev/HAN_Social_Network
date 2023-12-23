using Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace HAN_Social_Network
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        private Database.Account Account { get; set; }
        public Authorization()
        {
            InitializeComponent();
            Account = new Database.Account();
        }

        private void Button_Reg(object sender, RoutedEventArgs e)
        {
            MainWindow.pageContainer.Navigate(PageController.Registration);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Поля пустые",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Account.username = tbUsername.Text.Trim();
            Account.password = tbPassword.Text.Trim();

            var account = MainWindow.connection.Accounts.FirstOrDefault(x => x.username == Account.username && x.password == Account.password);
            PageController.SetAccount(account.id);

            if (account != null)
            {
                MainWindow.pageContainer.Navigate(PageController.ProfilePage);
            }
            else
            {
                MessageBox.Show("не найдено",
                   "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
