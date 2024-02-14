using Database;
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
    /// Логика взаимодействия для CreatePostPage.xaml
    /// </summary>
    public partial class CreatePostPage : Page
    {
        public static ObservableCollection<Database.Post> Posts { get; set; }
        private Database.Post Post { get; set; }
        private int idAccount;
        public CreatePostPage(int _idAccount)
        {
            InitializeComponent();
            Post = new Database.Post();
            this.idAccount = _idAccount;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void addPostClick(object sender, RoutedEventArgs e)
        {
            if (tbTitle.Text == "" || tbDescription.Text == "")
            {
                MessageBox.Show("Поля пустые"
                    , "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            MainWindow.pageContainer.Navigate(PageController.Authorization);

            Post.accountID = idAccount;
            Post.title = tbTitle.Text.Trim();
            Post.description = tbDescription.Text.Trim();

            MainWindow.connection.Posts.Add(Post);
            MainWindow.connection.SaveChanges();
            MainWindow.pageContainer.Navigate(PageController.ProfilePage);
            PageController.ProfilePage.UpdatePage();
        }
    }
}
