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
    public partial class NewsFeed : Page
    {
        public static ObservableCollection<Database.Account> Accounts { get; set; }
        public static ObservableCollection<Database.Post> Post { get; set; }
        private Database.Account Account { get; set; }

        public NewsFeed()
        {
            InitializeComponent();
            UpdatePage();
        }

        private void NavigateToProfile(object sender, RoutedEventArgs e)
        {
            MainWindow.pageContainer.Navigate(PageController.ProfilePage);
        }

        public void UpdatePage()
        {
            Account = new Database.Account();
            Accounts = new ObservableCollection<Database.Account>();
            Post = new ObservableCollection<Database.Post>();

            Binding test = new Binding();
            Binding binding = new Binding();
            test.Source = Accounts;

            var posts = MainWindow.connection.Posts;
            lvPosts.Items.Clear();
            foreach (var post in posts)
            {
                GeneralPostFrame postFrame = new GeneralPostFrame(post);
                lvPosts.Items.Add(postFrame);
            }
        }

        private void lvPosts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
