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

    public partial class UserEdit : Page
    {
        public UserEdit()
        {
            InitializeComponent();
        }

        public void SetAccount(Database.Account account)
        {
            DataContext = account;
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            MainWindow.connection.SaveChanges();
            PageController.ProfilePage.UpdatePage();
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }


        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
