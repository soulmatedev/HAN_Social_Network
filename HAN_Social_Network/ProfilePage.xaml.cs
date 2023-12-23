using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public static ObservableCollection<Database.Account> Accounts { get; set; }
        private Database.Account Account { get; set; }
        public ProfilePage(int id)
        {
            InitializeComponent();
            Account = new Database.Account();
            Accounts = new ObservableCollection<Database.Account>();


            Binding test = new Binding();
            test.Source = Accounts;
            tbFullName.SetBinding(TextBox.TextProperty, test);

            var account = MainWindow.connection.Accounts.FirstOrDefault(x => x.id== id);
            tbFullName = account.fullname

        }


    }
}
