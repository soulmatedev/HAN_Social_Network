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

namespace HAN_Social_Network
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Database.Account Account { get; set; }
        public Registration()
        {
            InitializeComponent();
            Account= new Database.Account();
        }

        private void addAdminClick(object sender, RoutedEventArgs e)
        {
            if(tbUsername.Text == "" || tbLastName.Text == "" || tbPassword.Text == "" || tbBirthday.DisplayDate == null)
            {
                MessageBox.Show("Поля пустые"
                    ,"Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
            }

            MainWindow.pageContainer.Navigate(PageController.Authorization);

            Account.username = tbUsername.Text.Trim();
            Account.fullname = tbLastName.Text.Trim();
            Account.password= tbPassword.Text.Trim();
            Account.birthday = tbBirthday.DisplayDate;

            MainWindow.connection.Accounts.Add(Account);
            MainWindow.connection.SaveChanges();
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
